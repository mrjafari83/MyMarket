using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Application.Interfaces.FacadPatterns.Admin;
using Microsoft.AspNetCore.Mvc;
using Common.Enums;

namespace Market.EndPoint.ViewComponents.Admin
{
    public class CommentsInIndex : ViewComponent
    {
        private readonly ICommentFacad _commentFacad;
        public CommentsInIndex(ICommentFacad commentFacad)
        {
            _commentFacad = commentFacad;
        }

        public IViewComponentResult Invoke(Enums.CategoryType categoryType)
        {
            if(categoryType == Enums.CategoryType.BlogPage)
            {
                ViewBag.CategiryType = "وبلاگ";
                return View("CommentsInIndex", _commentFacad.GetAllBlogComments.Execute().Data);
            }

            ViewBag.CategiryType = "محصولات";
            return View("CommentsInIndex" , _commentFacad.GetAllProductComments.Execute().Data);
        }
    }
}
