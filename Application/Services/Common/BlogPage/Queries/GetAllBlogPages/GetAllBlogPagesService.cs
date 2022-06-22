using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Application.Interfaces.Context;
using AutoMapper;
using Common.Dto;
using Common.Enums;
using Common.Utilities;
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

        public async Task<ResultDto<GetAllBlogPagesResult>> Execute(Enums.PagesFilter filter = Enums.PagesFilter.Newest
            , int pageNumber = 1, int pageSize = 10, string searchKey = "", int categoryId = 0)
        {
            int totalRows = 0;
            var blogPages = db.BlogPages.AsQueryable();

            switch (filter)
            {
                case Enums.PagesFilter.Newest:
                    {
                        blogPages = blogPages.OrderByDescending(b => b.CreateDate).AsQueryable();
                        break;
                    }
                case Enums.PagesFilter.MostViewed:
                    {
                        blogPages = blogPages.OrderByDescending(b => b.Visits.Count()).AsQueryable();
                        break;
                    }
            }

            if (searchKey != "")
                blogPages = blogPages.Where(b => b.Title.Contains(searchKey) || b.ShortDescription.Contains(searchKey)).AsQueryable();

            if (categoryId != 0)
                blogPages = blogPages.Where(b => b.Category.Id == categoryId).AsQueryable();

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
