using System.Linq;
using Application.Interfaces.Context;
using AutoMapper;
using Common.Dto;
using Common.Utilities;
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

        public ResultDto<GetBlogPageByIdDto> Execute(int id)
        {
            var blogPage = _mapper.Map<GetBlogPageByIdDto>(db.BlogPages.Include(b => b.Category).Include(b => b.Visits).FirstOrDefault(b => b.Id == id));

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
