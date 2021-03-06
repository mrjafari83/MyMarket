using System.Linq;
using System.Threading.Tasks;
using Application.Persistance.Context;
using AutoMapper;
using Application.Common.Dto;
using Application.Common.Utilities;
using Microsoft.EntityFrameworkCore;

namespace Application.Services.Client.BlogPages.Queries.GetBlogPageById
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
            var blogPage = _mapper.Map<GetBlogPageByIdDto>(await db.BlogPages.Include(b => b.Category).Include(b => b.Visits).FirstOrDefaultAsync(b => b.Id == id));

            if (blogPage != null)
                return new ResultDto<GetBlogPageByIdDto>
                {
                    Data = blogPage,
                    IsSuccess = true,
                };
            else
                return new ResultDto<GetBlogPageByIdDto>
                {
                    Data = null,
                    IsSuccess = false,
                };
        }
    }
}
