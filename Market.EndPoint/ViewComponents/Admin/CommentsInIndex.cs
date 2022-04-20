using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Application.Interfaces.FacadPatterns.Admin;
using Microsoft.AspNetCore.Mvc;

namespace Market.EndPoint.ViewComponents.Admin
{
    public class CommentsInIndex : ViewComponent
    {
        private readonly ICommentFacad _commentFacad;
        public CommentsInIndex(ICommentFacad commentFacad)
        {
            _commentFacad = commentFacad;
        }

        public IViewComponentResult Invoke()
        {
            return View("CommentsInIndex" , _commentFacad.GetAllProductComments.Execute().Data);
        }
    }
}
