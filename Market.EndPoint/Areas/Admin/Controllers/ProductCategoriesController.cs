using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Common.Enums;
using Application.Interfaces.FacadPatterns.Admin;
using Application.Interfaces.FacadPatterns.Common;
using Application.Services.Admin.Categories.Commands.CreateCategory;
using Application.Services.Admin.Categories.Commands.EditCategory;
using Microsoft.AspNetCore.Mvc.Rendering;
using Common.Dto;
using Microsoft.AspNetCore.Authorization;
using Common.ViewModels.SearchViewModels;
using Microsoft.Extensions.Logging;
using Common.Utilities;
using Market.EndPoint.Utilities.RabbitMQ;

namespace Market.EndPoint.Areas.Admin.Controllers
{
    [Area("Admin")]
    [Authorize(Roles = "Admin,Owner")]
    public class ProductCategoriesController : Controller
    {
        private IProductCategoryFacad _productCategoryFacad;
        private readonly ICommonCategorisFacad _commonCategorisFacad;
        private readonly SaveLogInFile _saveLogInFile;
        private readonly IExcelFacade _excelFacade;
        private readonly IOptionFacade _optionFacade;
        private readonly ISend _send;
        public ProductCategoriesController(IProductCategoryFacad productCategoryFacad
            , ICommonCategorisFacad commonCategorisFacad, IExcelFacade excelFacade, SaveLogInFile saveLogInFile
            , IOptionFacade optionFacade, ISend send)
        {
            _productCategoryFacad = productCategoryFacad;
            _commonCategorisFacad = commonCategorisFacad;
            _saveLogInFile = saveLogInFile;
            _excelFacade = excelFacade;
            _optionFacade = optionFacade;
            _send = send;
        }

        [HttpGet]
        public IActionResult Index(ProductCategoryViewModel model)
        {
            ViewBag.ParentId = model.ParentId;
            ViewBag.SearchKey = model.SearchKey;

            ViewBag.CategoriesList = new SelectList(
                _commonCategorisFacad.GetAllProductCategories.Execute(model, false, Enums.CategoriesFilter.Non,true).Data
                .OrderBy(c => c.ParentId != model.ParentId)
                , "Id"
                , "Name");
            return View(_commonCategorisFacad.GetAllProductCategories.Execute(model, true, Enums.CategoriesFilter.Non,true).Data);
        }

        [HttpGet]
        public IActionResult Create(int id)
        {
            ViewBag.ParentId = id;
            return PartialView();
        }

        [HttpPost]
        public IActionResult Create(string name, int parentId)
        {
            if (ModelState.IsValid)
            {
                var result = _productCategoryFacad.Create.Execute(new CreateCategoryDto
                {
                    Name = name,
                    ParentId = parentId
                });
                return Redirect("/Admin/ProductCategories");
            }
            else
            {
                return View();
            }

        }

        [HttpGet]
        public IActionResult Edit(int id)
        {
            ViewBag.CategoriesList = new SelectList(
                _commonCategorisFacad.GetAllProductCategories.Execute(new ProductCategoryViewModel(), false, Enums.CategoriesFilter.ForCategoriesList,false , id).Data
                , "Id"
                , "Name");

            var category = _productCategoryFacad.GetById.Execute(id);
            if (category.IsSuccess)
                return PartialView(category.Data);
            else
                return Redirect("/Admin/Error");
        }

        [HttpPost]
        public IActionResult Edit(string name, int id, int parentId)
        {
            _productCategoryFacad.Edit.Execute(new EditCategoryDto
            {
                Id = id,
                Name = name,
                ParentId = parentId
            });
            return Redirect("/Admin/ProductCategories");
        }

        [HttpGet]
        public IActionResult Delete(int id)
        {
            var category = _productCategoryFacad.GetById.Execute(id);
            if (category.IsSuccess)
                return PartialView(category.Data);
            else
                return Redirect("/Admin/Error");
        }

        [HttpPost]
        public IActionResult Deleting(int id)
        {
            _productCategoryFacad.Delete.Execute(id);
            return Redirect("/Admin/ProductCategories");
        }

        [HttpGet]
        public IActionResult GetChildren(int id)
        {
            return PartialView(_commonCategorisFacad.GetChildrenOfProductCategory.Execute(id).Data);
        }

        [HttpPost]
        public async Task<IActionResult> CreateExcelConfirmed(ProductCategoryViewModel model)
        {
            try
            {
                var searchFilter = await _optionFacade.CreateSearchFilter.Execute(model, Domain.Entities.Option.SearchItemType.ProductCategory);
                var searchId = searchFilter.Data;

                var excelKey = await _excelFacade.CreateExcelKey.Execute(searchId);
                int excelId = excelKey.Data;

                _send.SendToCreateExcel(excelId, searchId,"BlogCategories");

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
    }
}
