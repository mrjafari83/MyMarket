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
    public class GetAllProductCommentsService : IGetAllCommentsService
    {
        private readonly IDataBaseContext db;
        private readonly IMapper _mapper;
        public GetAllProductCommentsService(IDataBaseContext context , IMapper mapper)
        {
            db = context;
            _mapper = mapper;
        }

        public ResultDto<ResultGetAllCommentsDto> Execute(int pageNumber = 1, int pageSize = 10)
        {
            int totalRows = 0;
            var com = _mapper.Map<List<CommentViewModel>>(db.ProductComments.Include(c=> c.Parent).Include(c=> c.Location))
                .OrderByDescending(c => c.Id)
                .ToPaged(out totalRows, pageNumber, pageSize).ToList();

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
