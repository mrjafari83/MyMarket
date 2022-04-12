using System.Collections.Generic;
using System.Linq;
using Common.Dto;
using Common.Utilities;
using Application.Interfaces.Context;

namespace Application.Services.Common.Comment.Queries.GetAllCommentsByPageId
{
    public class GetAllBlogPageCommentsByIdService : IGetAllCommentsByPageIdService
    {
        private readonly IDataBaseContext db;
        public GetAllBlogPageCommentsByIdService(IDataBaseContext context)
        {
            db = context;
        }

        public ResultDto<List<GetAllCommentsByPageIdDto>> Execute(int pageId)
        {
            var comments = db.BlogPageComments.Where(b => b.Location.Id == pageId).Select(b => new GetAllCommentsByPageIdDto
            {
                Id = b.Id,
                Name = b.Name,
                Text = b.Text,
                ImageSrc = b.ImageSrc,
                CreateDate = b.CreateDate.ToShamsi(),
                ParentName = b.Parent.Name == null ? null : b.Parent.Name,
                ParentId = b.Parent.Id == null ? 0 : b.Parent.Id,
                VisitingParent = b.VisitingParent
            }).ToList();

            return new ResultDto<List<GetAllCommentsByPageIdDto>>
            {
                Data = comments,
                IsSuccess = true
            };
        }
    }
}
