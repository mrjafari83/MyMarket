using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Application.Interfaces.FacadPatterns.Admin;
using Application.Interfaces.FacadPatterns.Common;
using Microsoft.AspNetCore.Mvc.Rendering;
using Common.Utilities;
using Microsoft.AspNetCore.Http;
using Application.Services.Admin.BlogPages.Commands.CreateBlogPage;
using Application.Services.Admin.BlogPages.Commands.EditBlogPage;
using Microsoft.AspNetCore.Hosting;
using Common.ViewModels;
using Microsoft.AspNetCore.Authorization;

namespace Market.EndPoint.Areas.Admin.Controllers
{
    [Area("Admin")]
    [Authorize(Roles = "Admin,Owner")]
    public class BlogPagesController : Controller
    {
        private readonly IBlogPageFacad _blogPageFacad;
        private readonly IBlogPageCategoryFacad _blogPageCategoryFacad;
        private readonly ICommonBlogPageFacad _commonBlogPageFacad;
        private readonly IHostingEnvironment _environment;
        private readonly ICommonCategorisFacad _commonCategorisFacad;
        public BlogPagesController(IBlogPageFacad blogPageFacad
            , IBlogPageCategoryFacad blogPageCategoryFacad
            , IHostingEnvironment environment
            , ICommonBlogPageFacad commonBlogPageFacad
            , ICommonCategorisFacad commonCategorisFacad)
        {
            _blogPageFacad = blogPageFacad;
            _blogPageCategoryFacad = blogPageCategoryFacad;
            _environment = environment;
            _commonBlogPageFacad = commonBlogPageFacad;
            _commonCategorisFacad = commonCategorisFacad;
        }

        [HttpGet]
        public async Task<IActionResult> Index(int currentPage = 1)
        {
            ViewBag.CurrentRow = currentPage;
            return View(await _commonBlogPageFacad.GetAllBlogPages.Execute(pageNumber: currentPage));
        }

        [HttpGet]
        public IActionResult Create()
        {
            ViewBag.Categories = new SelectList(
                _commonCategorisFacad.GetAllBlogCategories.Execute(false, Common.Enums.Enums.CategoriesFilter.ForPagesList).Data
                , "Id"
                , "Name"
                );

            return View();
        }

        [HttpPost]
        public async Task<IActionResult> Create(BlogPageViewModel model, List<KeywordViewModel> keywords)
        {

            string imageSrc = FileUploader.Upload(model.Image, _environment, "BlogPages/" + model.Title).Result;

            await _blogPageFacad.CreateBlogPageService.Execute(new CreateBlogPageDto
            {
                Title = model.Title,
                ShortDescription = model.ShortDescription,
                Text = model.Text,
                CategoryId = model.CategoryId,
                Image = imageSrc,
                Keywords = keywords
            });

            return Redirect("/Admin/BlogPages");
        }

        [HttpGet]
        public IActionResult Edit(int id)
        {
            ViewBag.Categories = new SelectList(
                _commonCategorisFacad.GetAllBlogCategories.Execute(false, Common.Enums.Enums.CategoriesFilter.ForPagesList).Data
                , "Id"
                , "Name"
                );

            var blogPage = _blogPageFacad.GetBlogPageByIdService.Execute(id).Result;
            if (blogPage.IsSuccess)
                return View(blogPage.Data);
            else
                return Redirect("Admin/NotFound");
        }

        [HttpPost]
        public async Task<IActionResult> Edit(int id, string title, string shortDescription, string text, int categoryId, string imageName, IFormFile image, List<KeywordViewModel> keywords)
        {

            string imageSrc;
            if (image != null)
                imageSrc = FileUploader.Upload(image, _environment, "BlogPages/" + title).Result;
            else
                imageSrc = imageName;

            await _blogPageFacad.EditBlogPageService.Execute(new EditBlogPageDto
            {
                Id = id,
                Title = title,
                ShortDescription = shortDescription,
                Text = text,
                CategoryId = categoryId,
                Image = imageSrc,
                Keywords = keywords
            });

            return Redirect("/Admin/BlogPages");
        }

        [HttpGet]
        public IActionResult Delete(int id)
        {
            var blogPage = _blogPageFacad.GetBlogPageByIdService.Execute(id).Result;
            if (blogPage.IsSuccess)
                return View(blogPage.Data);
            else
                return Redirect("Admin/NotFound");
        }

        [HttpGet]
        public async Task<IActionResult> Deleting(int id)
        {
            await _blogPageFacad.DeleteBlogPageService.Execute(id);

            return Redirect("/Admin/BlogPages");
        }
    }
}
