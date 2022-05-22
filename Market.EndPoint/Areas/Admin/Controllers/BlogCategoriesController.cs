using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Application.Interfaces.Context;
using Application.FacadPatterns;
using Application.Interfaces.FacadPatterns.Admin;
using Application.Interfaces.FacadPatterns.Common;
using Application.Services.Admin.Categories.Commands.CreateCategory;
using Application.Services.Admin.Categories.Commands.EditCategory;
using Microsoft.AspNetCore.Mvc.Rendering;
using Common.Dto;
using Microsoft.AspNetCore.Authorization;

namespace Market.EndPoint.Areas.Admin.Controllers
{
    [Area("Admin")]
    [Authorize(Roles = "Admin,Owner")]
    public class BlogCategoriesController : Controller
    {
        private IBlogPageCategoryFacad _blogPageCategoryFacad;
        private readonly ICommonCategorisFacad _commonCategorisFacad;
        public BlogCategoriesController(IBlogPageCategoryFacad productCategoriesFacad
            ,ICommonCategorisFacad commonCategorisFacad)
        {
            _blogPageCategoryFacad = productCategoriesFacad;
            _commonCategorisFacad = commonCategorisFacad;
        }

        [HttpGet]
        public IActionResult Index()
        {
            var data = _commonCategorisFacad.GetAllBlogCategories
                .Execute(true, Common.Enums.Enums.CategoriesFilter.Non);
            if (data.IsSuccess)
                return View(data.Data);

            else
                return Redirect("Admin/NotFound");
        }

        [HttpGet]
        public IActionResult Create(int id)
        {
            ViewBag.ParentId = id;
            return PartialView();
        }

        [HttpPost]
        public IActionResult Create(string name , int parentId)
        {
            if (ModelState.IsValid && name != null)
            {
                var result = _blogPageCategoryFacad.Create.Execute(new CreateCategoryDto
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
                _commonCategorisFacad.GetAllBlogCategories.Execute(false , Common.Enums.Enums.CategoriesFilter.ForCategoriesList , id).Data
                , "Id"
                , "Name");

            var category = _blogPageCategoryFacad.GetById.Execute(id).Data;
            if (category != null)
                return PartialView(category);
            else
                return Redirect("Admin/NotFound");
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
                return Redirect("Admin/NotFound");
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
    }
}
