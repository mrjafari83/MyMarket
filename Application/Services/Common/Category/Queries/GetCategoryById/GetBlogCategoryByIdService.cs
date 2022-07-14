using System.Linq;
using Application.Common.Dto;
using Application.Persistance.Context;

namespace Application.Services.Common.Category.Queries.GetCategoryById
{
    public class GetBlogCategoryByIdService : IGetCategoryByIdService
    {
        private readonly IDataBaseContext db;
        public GetBlogCategoryByIdService(IDataBaseContext context)
        {
            db = context;
        }

        public ResultDto<GetCategoryByIdDto> Execute(int id)
        {
            var category = db.BlogPageCategories.Where(c => c.Id == id).Select(c => new GetCategoryByIdDto
            {
                Id = c.Id,
                Name = c.Name
            }).FirstOrDefault();

            if (category == null)
                return new ResultDto<GetCategoryByIdDto>
                {
                    IsSuccess = false,
                    Data = null
                };
            else
                return new ResultDto<GetCategoryByIdDto>
                {
                    Data = category,
                    IsSuccess = true
                };

        }
    }
}
