using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Application.Interfaces.FacadPatterns.Admin;
using Application.Interfaces.FacadPatterns.Common;
using Microsoft.AspNetCore.Mvc.Rendering;
using Common.Enums;
using Common.Classes;
using Common.ViewModels;
using Application.Services.Admin.Products.Commands.CreateProduct;
using Application.Services.Admin.Products.Commands.EditProduct;
using Application.Services.Admin.Products.Commands.DeleteProduct;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Authorization;
using AutoMapper;
using Domain.Entities.Products;
using Market.EndPoint.Utilities.RabbitMQ;
using System.IO;
using Microsoft.AspNetCore.Hosting;

namespace Market.EndPoint.Areas.Admin.Controllers
{
    [Area("Admin")]
    [Authorize(Roles = "Admin,Owner")]
    public class ProductController : Controller
    {
        private readonly IProductFacad _productFacad;
        private readonly IProductCategoryFacad _productCategoryFacad;
        private readonly ICommonCategorisFacad _commonCategorisFacad;
        private readonly IMapper _mapper;
        private readonly IExcelFacade _excelFacade;
        private readonly ISend _send;
        private readonly IHostingEnvironment _environment;

        public ProductController(IProductFacad productFacad
            , IProductCategoryFacad productCategoryFacad
            , ICommonCategorisFacad commonCategorisFacad, IMapper mapper
            , IExcelFacade excelFacade, ISend send
            , IHostingEnvironment environment)
        {
            _productFacad = productFacad;
            _productCategoryFacad = productCategoryFacad;
            _commonCategorisFacad = commonCategorisFacad;
            _mapper = mapper;
            _excelFacade = excelFacade;
            _send = send;
            _environment = environment;
        }

        [HttpGet]
        public async Task<IActionResult> Index(SearchViewModel model, int currentPage = 1)
        {
            ViewBag.CurrentRow = currentPage;
            ViewBag.SearchKey = model.SearchKey;
            ViewBag.StartPrice = model.StartPrice;
            ViewBag.EndPrice = model.EndPrice;
            ViewBag.OrderBy = (int)model.OrderBy;
            ViewBag.SearchBy = (int)model.SearchBy;

            return View(await _productFacad.GetAllProductsService.Execute(currentPage, 10, model));
        }

        [HttpGet]
        public IActionResult Create()
        {
            ViewBag.categories = new SelectList(
                _commonCategorisFacad.GetAllProductCategories.Execute(false, Enums.CategoriesFilter.ForPagesList).Data
                , "Id"
                , "Name"
                );

            return View();
        }

        [HttpPost]
        public async Task<IActionResult> Create(ProductViewModel request, List<KeywordViewModel> Keywords
            , List<ColorViewModelCreate> colors, List<SizeViewModel> sizes, List<FeatureViewModel> features
            , List<InventoryAndPriceViewModelCreate> inventoryAndPrice, List<IFormFile> Images)
        {
            await _productFacad.CreateProductService.Execute(new CreateProductServiceDto
            {
                Name = request.Name,
                Brand = request.Brand,
                ShortDescription = request.ShortDescription,
                Description = request.Description,
                CategoryId = request.CategoryId,
                Keywords = Keywords,
                Colors = colors,
                Sizes = sizes,
                Features = features,
                //Images = Images,
                InventoryAndPrices = inventoryAndPrice
            });

            return Json(true);
        }

        [HttpGet]
        public async Task<IActionResult> Edit(int id)
        {
            ViewBag.categories = new SelectList(
                _commonCategorisFacad.GetAllProductCategories.Execute(false, Enums.CategoriesFilter.ForPagesList).Data
                , "Id"
                , "Name"
                );

            var product = await _productFacad.GetProductByIdService.Execute(id);
            if (product.IsSuccess)
                return View(product.Data);
            else
                return Redirect("/Admin/NotFound");
        }

        [HttpPost]
        public async Task<IActionResult> Edit(ProductViewModel product, List<KeywordViewModel> Keywords
            , List<ColorViewModel> colors, List<SizeViewModel> sizes, List<FeatureViewModel> features
            , List<InventoryAndPriceViewModel> inventoryAndPrice, List<IFormFile> Images)
        {
            await _productFacad.EditProductService.Execute(new EditProductDto
            {
                Product = product,
                Images = Images,
                Keywords = Keywords,
                Colors = colors,
                Sizes = sizes,
                Features = features,
                InventoryAndPrices = inventoryAndPrice
            });

            return Redirect("/Admin/Product");
        }

        [HttpGet]
        public async Task<IActionResult> Delete(int id)
        {
            var product = await _productFacad.GetProductByIdService.Execute(id);
            if (product.IsSuccess)
                return View(product.Data);
            else
                return Redirect("/Admin/NotFound");
        }

        [HttpGet]
        public async Task<IActionResult> Deleting(int id)
        {
            await _productFacad.DeleteProductService.Execute(id);

            return Redirect("/Admin/Product");
        }

        [HttpPost]
        public IActionResult CreateExcel(SearchViewModel model)
        {
            TempData["SearchKey"] = model.SearchKey;
            TempData["StartPrice"] = model.StartPrice;
            TempData["EndPrice"] = model.EndPrice;
            TempData["OrderBy"] = (int)model.OrderBy;
            TempData["SearchBy"] = (int)model.SearchBy;

            return View();
        }

        [HttpGet]
        public async Task<IActionResult> CreateExcelConfirmed()
        {
            var orderBy = TempData["OrderBy"] switch
            {
                0 => Enums.PagesFilter.Newest,
                1 => Enums.PagesFilter.Oldest,
                2 => Enums.PagesFilter.MostViewed,
                3 => Enums.PagesFilter.MostSelled,
                4 => Enums.PagesFilter.LessViewed,
                5 => Enums.PagesFilter.LessSelled,
                _ => Enums.PagesFilter.Newest,
            };

            var searchBy = TempData["SearchBy"] switch
            {
                0 => Enums.PageFilterCategory.Name,
                1 => Enums.PageFilterCategory.Brand,
                2 => Enums.PageFilterCategory.CategoryName,
                _=> Enums.PageFilterCategory.Name
            };

            var model = new SearchViewModel
            {
                SearchKey = TempData["SearchKey"] == null ? "" : TempData["SearchKey"].ToString(),
                StartPrice = TempData["StartPrice"]==null ? 0 : (int)TempData["StartPrice"],
                EndPrice = TempData["EndPrice"] == null ? 0 : (int)TempData["EndPrice"],
                OrderBy = orderBy,
                SearchBy = searchBy
            };

            var entity = await _excelFacade.CreateExcelKey.Execute(model);
            int id = entity.Data;

            _send.SendToCreateExcel(id);

            return Redirect("/Admin/Product");
        }

        [HttpGet]
        public IActionResult GetExcels()
        {
            return View(_excelFacade.GetAllExcels.Execute().Data);
        }

        [HttpGet]
        public IActionResult DeleteAllExcels()
        {
            return View();
        }

        [HttpGet]
        public IActionResult DeleteAllExcelsConfirmed()
        {
            DirectoryInfo directory = new DirectoryInfo(_environment.WebRootPath + "/Excels/");
            var files = directory.GetFiles("*.xlsx");
            foreach (var file in files)
            {
                System.IO.File.Delete(file.FullName);
            }

            _excelFacade.DeleteAll.Execute();

            return Redirect("/Admin/Product/Index");
        }
    }

}
