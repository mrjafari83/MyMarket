using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Persistance.Context;
using AutoMapper;
using Common.Dto;
using Common.Enums;
using Common.Utilities;
using Common.ViewModels.SearchViewModels;
using Microsoft.EntityFrameworkCore;

namespace Application.Services.Common.BlogPage.Queries.GetAllBlogPages
{
    public class GetAllBlogPagesService : IGetAllBlogPagesService
    {
        private readonly IDataBaseContext db;
        private readonly IMapper _mapper;
        public GetAllBlogPagesService(IDataBaseContext context,IMapper mapper)
        {
            db = context;
            _mapper = mapper;
        }

        public async Task<ResultDto<GetAllBlogPagesResult>> Execute(BlogPageSearchViewModel searchModel, int pageNumber = 1, int pageSize = 10)
        {
            int totalRows = 0;
            var blogPages = GetBlogPagesBySearch.GetBlogPagesBySearch.GetBlogPages(db, searchModel);

            var finallyBlogPages = _mapper.ProjectTo<GetAllBlogPagesDto>(blogPages)
                .ToPaged(out totalRows, pageNumber, pageSize);

            if (blogPages != null)
                return new ResultDto<GetAllBlogPagesResult>
                {
                    Data = new GetAllBlogPagesResult
                    {
                        BlogPages = await finallyBlogPages.AsNoTracking().ToListAsync(),
                        TotalRows = totalRows
                    },
                    IsSuccess = true
                };
            else
                return new ResultDto<GetAllBlogPagesResult>
                {
                    Data = null,
                    IsSuccess = false
                };
        }
    }
}
