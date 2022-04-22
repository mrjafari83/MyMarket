using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Application.Interfaces.Context;
using Common.Dto;
using Common.ViewModels;
using Common.Utilities;

namespace Application.Services.Admin.Comment.Queries.GetAllComments
{
    public interface IGetAllCommentsService
    {
        ResultDto<ResultGetAllCommentsDto> Execute(int pageNumber = 1 , int pageSize = 10);
    }

    public class GetAllProductCommentsService : IGetAllCommentsService
    {
        private readonly IDataBaseContext db;
        public GetAllProductCommentsService(IDataBaseContext context)
        {
            db = context;
        }

        public ResultDto<ResultGetAllCommentsDto> Execute(int pageNumber = 1, int pageSize = 10)
        {
            int totalRows = 0;
            var comments = db.ProductComments.Select(c => new CommentViewModel
            {
                Id = c.Id,
                Name = c.Name,
                Email = c.Email,
                Text = c.Text,
                ImageSrc = c.ImageSrc,
                PageId = c.Location.Id == null ? 0 : c.Location.Id,
                ParentId = c.Parent.Id == null ? 0 : c.Parent.Id,
                VisitingParent = c.VisitingParent
            }).OrderByDescending(c => c.Id).AsQueryable();

            return new ResultDto<ResultGetAllCommentsDto>
            {
                Data = new ResultGetAllCommentsDto
                {
                    Comments = comments.ToPaged(out totalRows, pageNumber, pageSize).ToList(),
                    TotalRows = totalRows
                },
                IsSuccess = true
            };
        }
    }

    public class GetAllBlogCommentsService : IGetAllCommentsService
    {
        private readonly IDataBaseContext db;
        public GetAllBlogCommentsService(IDataBaseContext context)
        {
            db = context;
        }

        public ResultDto<ResultGetAllCommentsDto> Execute(int pageNumber = 1, int pageSize = 10)
        {
            int totalRows = 0;
            var comments = db.BlogPageComments.Select(c => new CommentViewModel
            {
                Id = c.Id,
                Name = c.Name,
                Email = c.Email,
                Text = c.Text,
                ImageSrc = c.ImageSrc,
                PageId = c.Location.Id == null ? 0 : c.Location.Id,
                ParentId = c.Parent.Id == null ? 0 : c.Parent.Id,
                VisitingParent = c.VisitingParent
            }).OrderByDescending(c => c.Id).AsQueryable();

            return new ResultDto<ResultGetAllCommentsDto>
            {
                Data = new ResultGetAllCommentsDto
                {
                    Comments = comments.ToPaged(out totalRows, pageNumber, pageSize).ToList(),
                    TotalRows = totalRows
                },
                IsSuccess = true
            };
        }
    }
}
