using System.Linq;
using Application.Persistance.Context;
using Application.Common.Dto;
using Application.Common.ViewModels;
using Application.Common.Utilities;
using AutoMapper;
using System.Collections.Generic;
using Microsoft.EntityFrameworkCore;
using System.Threading.Tasks;

namespace Application.Services.Admin.Comment.Queries.GetAllComments
{
    public class GetAllProductCommentsService : IGetAllCommentsService
    {
        private readonly IDataBaseContext db;
        private readonly IMapper _mapper;
        public GetAllProductCommentsService(IDataBaseContext context , IMapper mapper)
        {
            db = context;
            _mapper = mapper;
        }

        public async Task<ResultDto<ResultGetAllCommentsDto>> Execute(int pageNumber = 1, int pageSize = 10)
        {
            int totalRows = 0;
            var com =  await _mapper.ProjectTo<CommentViewModel>(db.ProductComments.Include(c=> c.Parent).Include(c=> c.Location))
                .OrderByDescending(c => c.Id)
                .ToPaged(out totalRows, pageNumber, pageSize).ToListAsync();

            return new ResultDto<ResultGetAllCommentsDto>
            {
                Data = new ResultGetAllCommentsDto
                {
                    Comments = com,
                    TotalRows = totalRows
                },
                IsSuccess = true
            };
        }
    }
}
