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

namespace Market.EndPoint.Areas.Admin.Controllers
{
    [Area("Admin")]
    [Authorize(Roles = "Admin,Owner")]
    public class ProductCategoriesController : Controller
    {
        private IProductCategoryFacad _productCategoryFacad;
        private readonly ICommonCategorisFacad _commonCategorisFacad;
        public ProductCategoriesController(IProductCategoryFacad productCategoryFacad
            ,ICommonCategorisFacad commonCategorisFacad)
        {
            _productCategoryFacad = productCategoryFacad;
            _commonCategorisFacad = commonCategorisFacad;
        }

        [HttpGet]
        public IActionResult Index()
        {
            return View(_commonCategorisFacad.GetAllProductCategories.Execute(true , Enums.CategoriesFilter.Non).Data);
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
                _commonCategorisFacad.GetAllProductCategories.Execute(false , Enums.CategoriesFilter.ForCategoriesList , id).Data
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
    }
}
