using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using Application.Interfaces.FacadPatterns.Admin;
using Application.Interfaces.FacadPatterns.Common;
using Microsoft.AspNetCore.Mvc.Rendering;
using Application.Common.Enums;
using Application.Common.ViewModels;
using Application.Services.Admin.Products.Commands.CreateProduct;
using Application.Services.Admin.Products.Commands.EditProduct;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Authorization;
using AutoMapper;
using Market.EndPoint.Utilities.RabbitMQ;
using System.IO;
using Microsoft.AspNetCore.Hosting;
using System.Net;
using Newtonsoft.Json;
using Application.Services.Admin.Products.Queries.GetAllProducts;
using Application.Common.Utilities;
using Microsoft.Extensions.Logging;
using Microsoft.Extensions.Configuration;
using System.Net.Http;
using Application.Persistance.Entities.User;
using Microsoft.AspNetCore.Identity;
using Microsoft.Extensions.Caching.Memory;
using System.Linq;
using Application.Persistance.Context;
using Application.Common.ViewModels.SearchViewModels;

namespace Market.EndPoint.Areas.Admin.Controllers
{
    [Area("Admin")]
    [Authorize(Roles = "Admin,Owner")]
    public class ProductController : Controller
    {
        private readonly UserManager<ApplicationUser> _userManager;
        private readonly IProductFacad _productFacad;
        private readonly IProductCategoryFacad _productCategoryFacad;
        private readonly ICommonCategorisFacad _commonCategorisFacad;
        private readonly IMapper _mapper;
        private readonly IExcelFacade _excelFacade;
        private readonly ISend _send;
        private readonly IHostingEnvironment _environment;
        private readonly SaveLogInFile _saveLogInFile;
        private readonly IOptionFacade _optionFacade;
        private readonly IConfiguration _configuration;
        private readonly IMemoryCache _memoryCache;
        IDataBaseContext db;

        public ProductController(IProductFacad productFacad, IDataBaseContext context
            , IProductCategoryFacad productCategoryFacad
            , ICommonCategorisFacad commonCategorisFacad, IMapper mapper
            , IExcelFacade excelFacade, ISend send
            , IHostingEnvironment environment, SaveLogInFile saveLogInFile
            , IOptionFacade optionFacade, IConfiguration configuration, UserManager<ApplicationUser> userManager, IMemoryCache memoryCache)
        {
            _productFacad = productFacad;
            _productCategoryFacad = productCategoryFacad;
            _commonCategorisFacad = commonCategorisFacad;
            _mapper = mapper;
            _excelFacade = excelFacade;
            _send = send;
            _environment = environment;
            _saveLogInFile = saveLogInFile;
            _optionFacade = optionFacade;
            _configuration = configuration;
            _userManager = userManager;
            _memoryCache = memoryCache;
            db = context;
        }

        [HttpGet]
        public async Task<IActionResult> Index(ProducsSearchViewModel model, int currentPage = 1)
        {
            ViewBag.CurrentRow = currentPage;
            ViewBag.SearchKey = model.SearchKey;
            ViewBag.StartPrice = model.StartPrice;
            ViewBag.EndPrice = model.EndPrice;
            ViewBag.OrderBy = (int)model.OrderBy;
            ViewBag.SearchBy = (int)model.SearchBy;
            ViewBag.ErrorMessage = "";

            var address = _configuration["Urls:ApiDomain"] + "/Product?";
            address += "PageNumber=" + currentPage;
            if (model.SearchKey != "" && model.SearchKey != null)
                address += "&Search.SearchKey=" + model.SearchKey;
            if (model.StartPrice != 0)
                address += "&Search.StartPrice=" + model.StartPrice;
            if (model.EndPrice != 0)
                address += "&Search.EndPrice=" + model.EndPrice;

            address += "&Search.OrderBy=" + (int)model.OrderBy + "&Search.SearchBy=" + (int)model.SearchBy;

            try
            {
                var user = await _userManager.FindByNameAsync(User.Identity.Name);
                HttpClient client = new HttpClient();
                if (_memoryCache.Get<string>(User.Identity.Name + "_JwtToken") == null)
                {
                    var values = new Dictionary<string, string>
                    {
                        { "UserName", user.UserName },
                        { "Password", user.PasswordHash }
                    };
                    var content = new FormUrlEncodedContent(values);
                    var response = await client.PostAsync(_configuration["Urls:ApiDomain"] + "/Authantication/Login", content);
                    var token = await response.Content.ReadAsStringAsync();

                    var options = new MemoryCacheEntryOptions();
                    options.AbsoluteExpiration = DateTime.Now.AddHours(12);
                    _memoryCache.Set(User.Identity.Name + "_JwtToken", token, options);
                }

                client.DefaultRequestHeaders.Add("Authorization", "Bearer " + _memoryCache.Get<string>(User.Identity.Name + "_JwtToken"));
                var httpResult = await client.GetAsync(address);

                if (httpResult.IsSuccessStatusCode)
                {
                    var json = await client.GetAsync(address);
                    var product = JsonConvert.DeserializeObject<ResultGetAllProductsDto>(await json.Content.ReadAsStringAsync());
                    return View(product);
                }
                if (httpResult.StatusCode == HttpStatusCode.Unauthorized || httpResult.StatusCode == HttpStatusCode.Forbidden)
                {
                    CookiesManager.AddCookie(HttpContext, "AuthMessage", "شما به بخش محصولات دسترسی ندارید.لطفا با حساب دیگری وارد شوید.");
                    return Redirect("/Login");
                }

                _saveLogInFile.Log(LogLevel.Error, HttpContext.Response.StatusCode.ToString(), HttpContext);
                ViewBag.ErrorMessage = "خطایی رخ داده است.";
                return View();
            }
            catch (Exception ex)
            {
                _saveLogInFile.Log(LogLevel.Error, ex.Message + ex.Data, HttpContext);
                ViewBag.ErrorMessage = WebErrorHandler.GetStatusCodeError(ex);
                return View();
            }
        }

        [HttpGet]
        public IActionResult Create()
        {
            ViewBag.categories = new SelectList(
                _commonCategorisFacad.GetAllProductCategories.Execute(new ProductCategoryViewModel(), false, Enums.CategoriesFilter.ForPagesList).Data
                , "Id"
                , "Name"
                );

            return View();
        }

        [HttpPost]
        public async Task<IActionResult> Create(CreateProductViewModel model)
        {
            try
            {
                await _productFacad.CreateProductService.Execute(new CreateProductServiceDto
                {
                    Name = model.Product.Name,
                    Brand = model.Product.Brand,
                    ShortDescription = model.Product.ShortDescription,
                    Description = model.Product.Description,
                    CategoryId = model.Product.CategoryId,
                    Keywords = model.Keywords,
                    Colors = model.Colors,
                    Sizes = model.Sizes,
                    Features = model.Features,
                    InventoryAndPrices = model.InventoryAndPrice
                }, model.Images);
                return Json(true);
            }
            catch (Exception ex)
            {
                _saveLogInFile.Log(LogLevel.Error, ex.Message, HttpContext);
                TempData["ErrorStatusCode"] = 500;
                TempData["ErrorMessage"] = "خطایی رخ داده است.";
                return View("Error");
            }
        }

        [HttpGet]
        public async Task<IActionResult> Edit(int id)
        {
            var product = await _productFacad.GetProductByIdService.Execute(id);
            ViewBag.categories = new SelectList(
           _commonCategorisFacad.GetAllProductCategories.Execute(new ProductCategoryViewModel(), false, Enums.CategoriesFilter.ForPagesList).Data.OrderBy(c => c.Name != product.Data.CategoryName)
           , "Id"
           , "Name"
           );

            if (product.IsSuccess)
                return View(product.Data);


            TempData["ErrorStatusCode"] = 404;
            TempData["ErrorMessage"] = "چیزی یافت نشد.";
            return View("Error");

        }

        [HttpPost]
        public async Task<IActionResult> Edit(ProductViewModel product, List<KeywordViewModel> Keywords
            , List<ColorViewModel> colors, List<SizeViewModel> sizes, List<FeatureViewModel> features
            , List<InventoryAndPriceViewModel> inventoryAndPrice, List<IFormFile> Images)
        {
            try
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
            catch (Exception ex)
            {
                _saveLogInFile.Log(LogLevel.Error, ex.Message, HttpContext);
                TempData["ErrorStatusCode"] = 500;
                TempData["ErrorMessage"] = "خطایی رخ داده است.";
                return View("Error");
            }
        }

        [HttpGet]
        public async Task<IActionResult> Delete(int id)
        {
            var product = await _productFacad.GetProductByIdService.Execute(id);
            if (product.IsSuccess)
                return View(product.Data);

            TempData["ErrorStatusCode"] = 404;
            TempData["ErrorMessage"] = "چیزی یافت نشد.";
            return View("Error");
        }

        [HttpGet]
        public async Task<IActionResult> Deleting(int id)
        {
            await _productFacad.DeleteProductService.Execute(id);

            return Redirect("/Admin/Product");
        }

        [HttpPost]
        public async Task<IActionResult> CreateExcelConfirmed(ProducsSearchViewModel searchModel)
        {
            try
            {
                var model = new ProducsSearchViewModel
                {
                    SearchKey = searchModel.SearchKey,
                    StartPrice = searchModel.StartPrice,
                    EndPrice = searchModel.EndPrice,
                    OrderBy = searchModel.OrderBy,
                    SearchBy = searchModel.SearchBy
                };

                var excelStatus = await _excelFacade.CreateExcelKey.Execute(searchModel,Application.Persistance.Entities.Option.SearchItemType.Product);
                int excelId = excelStatus.Data;

                _send.SendToCreateExcel(excelId, "Product");

                return Redirect("/Admin/Product");
            }
            catch (Exception ex)
            {
                _saveLogInFile.Log(LogLevel.Error, ex.Message, HttpContext);
                TempData["ErrorStatusCode"] = 500;
                TempData["ErrorMessage"] = "خطایی رخ داده است.";
                return View("Error");
            }
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
            try
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
            catch (Exception ex)
            {
                _saveLogInFile.Log(LogLevel.Error, ex.Message, HttpContext);
                TempData["ErrorStatusCode"] = 500;
                TempData["ErrorMessage"] = "خطایی رخ داده است.";
                return View("Error");
            }
        }
    }
}
