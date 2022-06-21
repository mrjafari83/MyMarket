using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Application.Interfaces.FacadPatterns.Common;
using Application.Interfaces.FacadPatterns.Client;
using Application.Services.Common.Comment.Commands.CreateComment;
using Common.ViewModels;
using Common.Utilities;

namespace Market.EndPoint.Controllers
{
    public class ProductController : Controller
    {
        ICommonProductFacad _commonProductFacad;
        ICommonCommentFacad _commonCommentFacad;
        ICommonCategorisFacad _commonCategorisFacad;
        IClientCartFacad _clientCartFacad;
        IClientProductFacad _clientProductFacad;

        public ProductController(ICommonProductFacad commonProductFacad, ICommonCommentFacad commonCommentFacad
            , ICommonCategorisFacad commonCategorisFacad, IClientCartFacad clientCartFacad , IClientProductFacad clientProductFacad)
        {
            _commonProductFacad = commonProductFacad;
            _commonCommentFacad = commonCommentFacad;
            _commonCategorisFacad = commonCategorisFacad;
            _clientCartFacad = clientCartFacad;
            _clientProductFacad = clientProductFacad;
        }

        [Route("Products")]
        public IActionResult Index(int currentPage = 1, int categoryId = 0)
        {
            ViewBag.CurrentRow = currentPage;
            ViewBag.CategoryId = categoryId;

            if (categoryId == 0)
            {
                ViewBag.HeaderTitle = "همه محصولات";
                ViewBag.TopbarTitle = "همه محصولات";
            }
            else
            {
                var categoryName = _commonCategorisFacad.GetProductCategoryById.Execute(categoryId).Data.Name;
                ViewBag.HeaderTitle = "دسته بندی : " + categoryName;
                ViewBag.TopbarTitle = "دسته بندی : " + categoryName;
            }
            return View(_commonProductFacad.GetNewestProduct.Execute(currentPage, 12, categoryId).Data);
        }

        [Route("Product")]
        public IActionResult ShowProduct(int id)
        {
            return View(_commonProductFacad.GetProductById.Execute(id).Data);
        }

        public IActionResult CreateComment(CommentViewModel comment)
        {
            _commonCommentFacad.CreateProductComment.Execute(new CreateCommentDto
            {
                Name = comment.Name,
                Email = comment.Email,
                Text = comment.Text,
                ImageSrc = comment.ImageSrc ?? "/Images/DefaultUser.jpg",
                PageId = comment.PageId,
                ParentId = comment.ParentId,
                VisitingParent = comment.VisitingParent
            });
            return Redirect("/Product?id=" + comment.PageId);
        }

        [Route("SearchProducts")]
        [HttpPost]
        public IActionResult SearchProducts(int currentPage = 1, string searchKey = "")
        {
            ViewBag.CurrentRow = currentPage;
            ViewBag.HeaderTitle = "جستوجو : " + searchKey;
            ViewBag.TopbarTitle = "جستوجو";
            return View(viewName: "Index", _commonProductFacad.GetProductsBySearch.Execute(searchKey, 12, currentPage).Data);
        }

        [HttpPost]
        public IActionResult GetPriceByColorAndSize(string colorName,string sizeName , int productId)
        {
            return Json(_clientProductFacad.GetPriceByColorAndSize.Execute(productId , colorName , sizeName).Data);
        }
    }
}
