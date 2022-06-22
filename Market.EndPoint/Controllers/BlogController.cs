using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Application.Interfaces.FacadPatterns.Client;
using Application.Interfaces.FacadPatterns.Common;
using Common.ViewModels;
using Application.Services.Common.Comment.Commands.CreateComment;

namespace Market.EndPoint.Controllers
{
    public class BlogController : Controller
    {
        private readonly IClientBlogPageFacad _clientBlogPageFacad;
        private readonly ICommonBlogPageFacad _commonBlogPageFacad;
        private readonly ICommonCommentFacad _commonCommentFacad;
        private readonly ICommonCategorisFacad _commonCategorisFacad;
        public BlogController(IClientBlogPageFacad clientBlogPageFacad
            ,ICommonBlogPageFacad commonBlogPageFacad
            ,ICommonCommentFacad commonCommentFacad
            ,ICommonCategorisFacad commonCategorisFacad)
        {
            _clientBlogPageFacad = clientBlogPageFacad;
            _commonBlogPageFacad = commonBlogPageFacad;
            _commonCommentFacad = commonCommentFacad;
            _commonCategorisFacad = commonCategorisFacad;
        }

        [Route("Blogs")]
        public async Task<IActionResult> Index(int currentPage = 1 , int categoryId = 0)
        {
            ViewBag.CurrentPage = currentPage;
            if (categoryId == 0)
                ViewBag.HeaderTitle = "همه صفحات";
            else
                ViewBag.HeaderTitle = _commonCategorisFacad.GetBlogCategoryById.Execute(categoryId).Data.Name;

            return View(await _commonBlogPageFacad.GetAllBlogPages.Execute(pageNumber: currentPage, categoryId: categoryId));
        }

        [Route("Blog")]
        public IActionResult ShowBlogPages(int id)
        {
            return View(_clientBlogPageFacad.GetBlogPageByIdService.Execute(id).Result.Data);
        }

        public IActionResult CreateComment(CommentViewModel comment)
        {
            _commonCommentFacad.CreateBlogPageComment.Execute(new CreateCommentDto
            {
                Name = comment.Name,
                Email = comment.Email,
                Text = comment.Text,
                ImageSrc = comment.ImageSrc ?? "/Images/DefaultUser.jpg",
                PageId = comment.PageId,
                ParentId = comment.ParentId,
                VisitingParent = comment.VisitingParent
            });
            return Redirect("/Blog?id=" + comment.PageId);
        }

        [Route("SearchBlogs")]
        [HttpPost]
        public IActionResult SearchBlogPages(int currentPage = 1 , string searchKey = "")
        {
            ViewBag.CurrentPage = currentPage;
            ViewBag.SearchKey = searchKey;
            ViewBag.PageTitle = "جستوجو برای " + searchKey;
            return View(_commonBlogPageFacad.GetAllBlogPages.Execute(pageNumber:currentPage , searchKey:searchKey).Result.Data);
        }
    }
}
