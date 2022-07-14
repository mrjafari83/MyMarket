using Common.Dto;
using Persistance.Context;
using System.Linq;

namespace Application.Services.Admin.Categories.Queries.GetCategoryById
{
    public class GetBlogPagetCategoryByIdService : IGetCategoryByIdService
    {
        private readonly IDataBaseContext db;
        public GetBlogPagetCategoryByIdService(IDataBaseContext context)
        {
            db = context;
        }

        public ResultDto<ResultOfGetCategoryByIdDto> Execute(int id)
        {
            var category = db.BlogPageCategories.Where(c => c.Id == id).Select(c => new ResultOfGetCategoryByIdDto
            {
                Id = c.Id,
                Name = c.Name,
                ParentId = c.Parent.Id == null ? 0 : c.Parent.Id,
                IsParent = c.IsParent,
                ParentName = c.Parent.Name == null ? "" : c.Parent.Name,
            }).First();

            if (category != null)
                return new ResultDto<ResultOfGetCategoryByIdDto>()
                {
                    Data = category,
                    IsSuccess = true
                };

            else
                return new ResultDto<ResultOfGetCategoryByIdDto>()
                {
                    Data = null,
                    IsSuccess = false
                };
        }
    }
}
