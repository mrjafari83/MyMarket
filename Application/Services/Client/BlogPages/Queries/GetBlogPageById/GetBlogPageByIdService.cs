using System.Linq;
using Application.Interfaces.Context;
using Common.Dto;
using Common.Utilities;

namespace Application.Services.Client.BlogPages.Queries.GetBlogPageById
{
    public class GetBlogPageByIdService : IGetBlogPageByIdService
    {
        private readonly IDataBaseContext db;
        public GetBlogPageByIdService(IDataBaseContext context)
        {
            db = context;
        }

        public ResultDto<GetBlogPageByIdDto> Execute(int id)
        {
            GetBlogPageByIdDto blogPage = db.BlogPages.Where(b => b.Id == id).Select(b => new GetBlogPageByIdDto
            {
                Id = b.Id,
                Title = b.Title,
                Text = b.Text,
                Image = b.Image,
                CreateDate = b.CreateDate.ToShamsi(),
                CategoryId = b.Category.Id,
                CategoryName = b.Category.Name
            }).FirstOrDefault();

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
