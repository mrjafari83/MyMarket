using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Application.Services.Common.Comment.Commands.CreateComment;
using Application.Services.Common.Comment.Queries.GetAllCommentsByPageId;

namespace Application.Interfaces.FacadPatterns.Common
{
   public interface ICommonCommentFacad
    {
        IGetAllCommentsByPageIdService GetAllProductCommentsById { get; }
        IGetAllCommentsByPageIdService GetAllBlogPageCommentsById { get; }
        ICreateCommentService CreateProductComment { get; }
        ICreateCommentService CreateBlogPageComment { get; }
    }
}
