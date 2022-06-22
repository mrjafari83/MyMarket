using System.Collections.Generic;
using System.Linq;
using Common.Dto;
using Common.Utilities;
using Application.Interfaces.Context;
using Microsoft.EntityFrameworkCore;
using System.Threading.Tasks;

namespace Application.Services.Common.Comment.Queries.GetAllCommentsByPageId
{
    public class GetAllProductCommentsByIdService : IGetAllCommentsByPageIdService
    {
        private readonly IDataBaseContext db;
        public GetAllProductCommentsByIdService(IDataBaseContext context)
        {
            db = context;
        }

        public async Task<ResultDto<List<GetAllCommentsByPageIdDto>>> Execute(int pageId)
        {
            var comments = await db.ProductComments.Where(c => c.Location.Id == pageId).Select(c => new GetAllCommentsByPageIdDto
            {
                Id = c.Id,
                Name = c.Name,
                Text = c.Text,
                ImageSrc = c.ImageSrc,
                CreateDate = c.CreateDate.ToShamsi(),
                ParentName = c.Parent.Name,
                ParentId = c.Parent.Id == null ? 0 : c.Parent.Id,
                VisitingParent = c.VisitingParent
            }).AsNoTracking().ToListAsync();

            return new ResultDto<List<GetAllCommentsByPageIdDto>>
            {
                Data = comments,
                IsSuccess = true
            };
        }
    }
}
