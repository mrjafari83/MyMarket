using System.Collections.Generic;
using System.Linq;
using Persistance.Context;
using Common.Dto;

namespace Application.Services.Common.Category.Queries.GetChildrenOfCategory
{
    public class GetChildrenOfBlogPageCategoryService : IGetChildrenOfCategoryService
    {
        private readonly IDataBaseContext db;
        public GetChildrenOfBlogPageCategoryService(IDataBaseContext context)
        {
            db = context;
        }

        public ResultDto<List<GetChildrenOfCategoryDto>> Execute(int id)
        {
            var children = db.BlogPageCategories.Where(c => c.Parent.Id == id)
                            .Select(c => new GetChildrenOfCategoryDto
                            {
                                Id = c.Id,
                                Name = c.Name,
                                ChildrenCount = c.Children.Count
                            }).ToList();

            if (children != null)
                return new ResultDto<List<GetChildrenOfCategoryDto>>
                {
                    Data = children,
                    IsSuccess = true
                };
            else
                return new ResultDto<List<GetChildrenOfCategoryDto>>
                {
                    Data = null,
                    IsSuccess = false
                };
        }
    }
}
