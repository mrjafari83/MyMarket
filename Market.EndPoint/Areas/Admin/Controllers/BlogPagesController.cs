using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Application.Interfaces.FacadPatterns.Admin;
using Application.Interfaces.FacadPatterns.Common;
using Microsoft.AspNetCore.Mvc.Rendering;
using Application.Common.Utilities;
using Microsoft.AspNetCore.Http;
using Application.Services.Admin.BlogPages.Commands.CreateBlogPage;
using Application.Services.Admin.BlogPages.Commands.EditBlogPage;
using Microsoft.AspNetCore.Hosting;
using Application.Common.ViewModels;
using Microsoft.AspNetCore.Authorization;
using Application.Common.ViewModels.SearchViewModels;
using Market.EndPoint.Utilities.RabbitMQ;
using Microsoft.Extensions.Logging;

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
        private readonly SaveLogInFile _saveLogInFile;
        private readonly IExcelFacade _excelFacade;
        private readonly IOptionFacade _optionFacade;
        private readonly ISend _send;
        public BlogPagesController(IBlogPageFacad blogPageFacad
            , IBlogPageCategoryFacad blogPageCategoryFacad
            , IHostingEnvironment environment
            , ICommonBlogPageFacad commonBlogPageFacad
            , ICommonCategorisFacad commonCategorisFacad, IExcelFacade excelFacade, SaveLogInFile saveLogInFile
            , IOptionFacade optionFacade, ISend send)
        {
            _blogPageFacad = blogPageFacad;
            _blogPageCategoryFacad = blogPageCategoryFacad;
            _environment = environment;
            _commonBlogPageFacad = commonBlogPageFacad;
            _commonCategorisFacad = commonCategorisFacad;
            _saveLogInFile = saveLogInFile;
            _excelFacade = excelFacade;
            _optionFacade = optionFacade;
            _send = send;
        }

        [HttpGet]
        public async Task<IActionResult> Index(BlogPageSearchViewModel searchModel, int currentPage = 1)
        {
            ViewBag.Categories = new SelectList(
                _commonCategorisFacad.GetAllBlogCategories.Execute(new BlogCategoryViewModel(), false,  Application.Common.Enums.Enums.CategoriesFilter.ForPagesList).Data
                , "Id"
                , "Name"
            );

            ViewBag.CurrentRow = currentPage;
            ViewBag.SearchKey = searchModel.SearchKey;
            ViewBag.CategoryId = searchModel.CategoryId;
            ViewBag.OrderBy = (int)searchModel.OrderBy;

            return View(await _commonBlogPageFacad.GetAllBlogPages.Execute(searchModel, currentPage));
        }

        [HttpGet]
        public IActionResult Create()
        {
            ViewBag.Categories = new SelectList(
                _commonCategorisFacad.GetAllBlogCategories.Execute(new BlogCategoryViewModel(), false,  Application.Common.Enums.Enums.CategoriesFilter.ForPagesList).Data
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
                _commonCategorisFacad.GetAllBlogCategories.Execute(new BlogCategoryViewModel(), false,  Application.Common.Enums.Enums.CategoriesFilter.ForPagesList).Data
                , "Id"
                , "Name"
                );

            var blogPage = _blogPageFacad.GetBlogPageByIdService.Execute(id).Result;
            if (blogPage.IsSuccess)
                return View(blogPage.Data);
            else
                return Redirect("Admin/Error");
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
                return Redirect("Admin/Error");
        }

        [HttpGet]
        public async Task<IActionResult> Deleting(int id)
        {
            await _blogPageFacad.DeleteBlogPageService.Execute(id);

            return Redirect("/Admin/BlogPages");
        }

        [HttpPost]
        public async Task<IActionResult> CreateExcelConfirmed(BlogPageSearchViewModel searchModel)
        {
            try
            {
                var excelStatus = await _excelFacade.CreateExcelKey.Execute(searchModel, Application.Persistance.Entities.Option.SearchItemType.BlogPages);
                int excelId = excelStatus.Data;

                _send.SendToCreateExcel(excelId, "BlogPage");

                return Redirect("/Admin/BlogPages");
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
