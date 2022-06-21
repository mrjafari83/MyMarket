using System.Linq;
using Application.Interfaces.Context;
using Common.Dto;
using Common.ViewModels;
using Common.Utilities;
using AutoMapper;
using System.Collections.Generic;
using Microsoft.EntityFrameworkCore;

namespace Application.Services.Admin.Comment.Queries.GetAllComments
{
    public class GetAllBlogCommentsService : IGetAllCommentsService
    {
        private readonly IDataBaseContext db;
        private readonly IMapper _mapper;
        public GetAllBlogCommentsService(IDataBaseContext context, IMapper mapper)
        {
            db = context;
            _mapper = mapper;
        }

        public ResultDto<ResultGetAllCommentsDto> Execute(int pageNumber = 1, int pageSize = 10)
        {
            int totalRows = 0;
            var comments = _mapper.Map<List<CommentViewModel>>(db.BlogPageComments.Include(c => c.Parent).Include(c => c.Location))
                .OrderByDescending(c => c.Id)
                .ToPaged(out totalRows, pageNumber, pageSize).ToList();

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
