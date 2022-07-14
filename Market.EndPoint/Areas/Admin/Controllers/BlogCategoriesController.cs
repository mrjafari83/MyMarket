using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Application.Persistance.Context;
using Application.FacadPatterns;
using Application.Interfaces.FacadPatterns.Admin;
using Application.Interfaces.FacadPatterns.Common;
using Application.Services.Admin.Categories.Commands.CreateCategory;
using Application.Services.Admin.Categories.Commands.EditCategory;
using Microsoft.AspNetCore.Mvc.Rendering;
using Application.Common.ViewModels.SearchViewModels;
using Microsoft.AspNetCore.Authorization;
using Application.Common.Utilities;
using Microsoft.Extensions.Logging;
using Market.EndPoint.Utilities.RabbitMQ;

namespace Market.EndPoint.Areas.Admin.Controllers
{
    [Area("Admin")]
    [Authorize(Roles = "Admin,Owner")]
    public class BlogCategoriesController : Controller
    {
        private IBlogPageCategoryFacad _blogPageCategoryFacad;
        private readonly ICommonCategorisFacad _commonCategorisFacad;
        private readonly SaveLogInFile _saveLogInFile;
        private readonly IExcelFacade _excelFacade;
        private readonly IOptionFacade _optionFacade;
        private readonly ISend _send;
        public BlogCategoriesController(IBlogPageCategoryFacad productCategoriesFacad
            , ICommonCategorisFacad commonCategorisFacad, IExcelFacade excelFacade, SaveLogInFile saveLogInFile
            , IOptionFacade optionFacade, ISend send)
        {
            _blogPageCategoryFacad = productCategoriesFacad;
            _commonCategorisFacad = commonCategorisFacad;
            _saveLogInFile = saveLogInFile;
            _excelFacade = excelFacade;
            _optionFacade = optionFacade;
            _send = send;
        }

        [HttpGet]
        public IActionResult Index(BlogCategoryViewModel model)
        {
            ViewBag.ParentId = model.ParentId;
            ViewBag.SearchKey = model.SearchKey;

            ViewBag.CategoriesList = new SelectList(
                _commonCategorisFacad.GetAllBlogCategories.Execute(model, false, Application.Common.Enums.Enums.CategoriesFilter.Non).Data
                , "Id"
                , "Name");

            var data = _commonCategorisFacad.GetAllBlogCategories
                .Execute(model, true, Application.Common.Enums.Enums.CategoriesFilter.Non);
            if (data.IsSuccess)
                return View(data.Data);

            else
                return Redirect("Admin/Error");
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
            if (name != null)
            {
                _blogPageCategoryFacad.Create.Execute(new CreateCategoryDto
                {
                    Name = name,
                    ParentId = parentId
                });
                return Redirect("/Admin/BlogCategories");
            }
            else
            {
                return Redirect("/Admin/BlogCategories");
            }

        }

        [HttpGet]
        public IActionResult Edit(int id)
        {
            ViewBag.CategoriesList = new SelectList(
                _commonCategorisFacad.GetAllBlogCategories.Execute(new BlogCategoryViewModel(), false,  Application.Common.Enums.Enums.CategoriesFilter.ForCategoriesList,false , id).Data
                , "Id"
                , "Name");

            var category = _blogPageCategoryFacad.GetById.Execute(id).Data;
            if (category != null)
                return PartialView(category);
            else
                return Redirect("Admin/Error");
        }

        [HttpPost]
        public IActionResult Edit(string name, int id, int parentId)
        {
            if (name != null && id != 0)
            {
                _blogPageCategoryFacad.Edit.Execute(new EditCategoryDto
                {
                    Id = id,
                    Name = name,
                    ParentId = parentId
                });
                return Redirect("/Admin/BlogCategories");
            }
            else
                return Redirect("/Admin/BlogCategories");
        }

        [HttpGet]
        public IActionResult Delete(int id)
        {
            var category = _blogPageCategoryFacad.GetById.Execute(id).Data;
            if (category != null)
                return PartialView(category);
            else
                return Redirect("Admin/Error");
        }

        [HttpPost]
        public IActionResult Deleting(int id)
        {
            _blogPageCategoryFacad.Delete.Execute(id);
            return Redirect("/Admin/BlogCategories");
        }

        [HttpGet]
        public IActionResult GetChildren(int id)
        {
            return PartialView(_commonCategorisFacad.GetChildrenOfBlogCategory.Execute(id).Data);
        }

        [HttpPost]
        public async Task<IActionResult> CreateExcelConfirmed(BlogCategoryViewModel searchModel)
        {
            try
            {
                var excelStatus = await _excelFacade.CreateExcelKey.Execute(searchModel, Application.Persistance.Entities.Option.SearchItemType.BlogCategory);
                int excelId = excelStatus.Data;

                _send.SendToCreateExcel(excelId, "BlogCategory");

                return Redirect("/Admin/BlogCategories");
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
