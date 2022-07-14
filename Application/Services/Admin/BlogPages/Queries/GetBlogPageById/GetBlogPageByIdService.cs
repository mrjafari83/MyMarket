using System.Linq;
using Application.Common.Dto;
using Application.Common.Utilities;
using Application.Persistance.Context;
using Application.Common.ViewModels;
using System.Collections.Generic;
using AutoMapper;
using Microsoft.EntityFrameworkCore;
using System.Threading.Tasks;

namespace Application.Services.Admin.BlogPages.Queries.GetBlogPageById
{
    public class GetBlogPageByIdService : IGetBlogPageByIdService
    {
        private readonly IDataBaseContext db;
        private readonly IMapper _mapper;
        public GetBlogPageByIdService(IDataBaseContext context , IMapper mapper)
        {
            db = context;
            _mapper = mapper;
        }

        public async Task<ResultDto<GetBlogPageByIdDto>> Execute(int id)
        {
            var blogPage= _mapper.Map<GetBlogPageByIdDto>(await db.BlogPages.Include(b=> b.Category)
                .Include(b=> b.Visits).Include(b=> b.Keywords).AsNoTracking().FirstOrDefaultAsync(b=> b.Id == id));

            if (blogPage != null)
                return new ResultDto<GetBlogPageByIdDto>
                {
                    Data = blogPage,
                    IsSuccess = true
                };
            else
                return new ResultDto<GetBlogPageByIdDto>
                {
                    Data = null,
                    IsSuccess = false
                };
        }
    }
}
