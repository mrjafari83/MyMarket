using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Application.Interfaces.FacadPatterns.Common;
using Common.Enums;
using Application.Services.Common.Comment.Queries.GetAllCommentsByPageId;

namespace Market.EndPoint.ViewComponents
{
    public class Comment : ViewComponent
    {
        private readonly ICommonCommentFacad _commonCommentFacad;
        public Comment(ICommonCommentFacad commonCommentFacad)
        {
            _commonCommentFacad = commonCommentFacad;
        }

        public IViewComponentResult Invoke(int pageId , Enums.CategoryType type)
        {
            List<GetAllCommentsByPageIdDto> comments = new List<GetAllCommentsByPageIdDto>();

            switch (type)
            {
                case Enums.CategoryType.Product:
                    {
                        comments = _commonCommentFacad.GetAllProductCommentsById.Execute(pageId).Result.Data;
                        break;
                    }
                case Enums.CategoryType.BlogPage:
                    {
                        comments = _commonCommentFacad.GetAllBlogPageCommentsById.Execute(pageId).Result.Data;
                        break;
                    }
            }
            return View("Comment" , comments);
        }
    }
}
