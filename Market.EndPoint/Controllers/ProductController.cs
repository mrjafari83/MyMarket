using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Application.Interfaces.FacadPatterns.Common;
using Application.Interfaces.FacadPatterns.Client;
using Application.Services.Common.Comment.Commands.CreateComment;
using Application.Common.ViewModels;
using Application.Common.Utilities;
using Market.EndPoint.Models;

namespace Market.EndPoint.Controllers
{
    public class ProductController : Controller
    {
        ICommonProductFacad _commonProductFacad;
        ICommonCommentFacad _commonCommentFacad;
        ICommonCategorisFacad _commonCategorisFacad;
        IClientCartFacad _clientCartFacad;
        IClientProductFacad _clientProductFacad;
        SaveLogInFile _saveLogInFile;

        public ProductController(ICommonProductFacad commonProductFacad, ICommonCommentFacad commonCommentFacad
            , ICommonCategorisFacad commonCategorisFacad, IClientCartFacad clientCartFacad, IClientProductFacad clientProductFacad
            , SaveLogInFile saveLogInFile)
        {
            _commonProductFacad = commonProductFacad;
            _commonCommentFacad = commonCommentFacad;
            _commonCategorisFacad = commonCategorisFacad;
            _clientCartFacad = clientCartFacad;
            _clientProductFacad = clientProductFacad;
            _saveLogInFile = saveLogInFile;
        }

        [Route("Products")]
        public async Task<IActionResult> Index(int currentPage = 1, int categoryId = 0)
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
            return View(await _commonProductFacad.GetNewestProduct.Execute(currentPage, 12, categoryId));
        }

        [Route("Product")]
        public async Task<IActionResult> ShowProduct(int id)
        {
            var product = await _commonProductFacad.GetProductById.Execute(id);
            if (product.Data != null)
                return View(product);

            return NotFound();
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
        public async Task<IActionResult> SearchProducts(int currentPage = 1, string searchKey = "")
        {
            ViewBag.CurrentRow = currentPage;
            ViewBag.HeaderTitle = "جستوجو : " + searchKey;
            ViewBag.TopbarTitle = "جستوجو";
            return View(viewName: "Index", await _commonProductFacad.GetProductsBySearch.Execute(searchKey, 12, currentPage));
        }

        [HttpPost]
        public async Task<IActionResult> GetPriceByColorAndSize(string colorName, string sizeName, int productId)
        {
            var price = await _clientProductFacad.GetPriceByColorAndSize.Execute(productId, colorName, sizeName);
            return Json(price.Data);
        }
    }
}
