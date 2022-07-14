using System.Linq;
using Persistance.Context;
using Common.Dto;
using Common.ViewModels;
using Common.Utilities;
using AutoMapper;
using System.Collections.Generic;
using Microsoft.EntityFrameworkCore;
using System.Threading.Tasks;

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

        public async Task<ResultDto<ResultGetAllCommentsDto>> Execute(int pageNumber = 1, int pageSize = 10)
        {
            int totalRows = 0;
            var comments = _mapper.ProjectTo<CommentViewModel>(db.BlogPageComments.Include(c => c.Parent).Include(c => c.Location))
                .OrderByDescending(c => c.Id).AsQueryable();

            return new ResultDto<ResultGetAllCommentsDto>
            {
                Data = new ResultGetAllCommentsDto
                {
                    Comments = await comments.ToPaged(out totalRows, pageNumber, pageSize).ToListAsync(),
                    TotalRows = totalRows
                },
                IsSuccess = true
            };
        }
    }
}
