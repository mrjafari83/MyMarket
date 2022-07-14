using System.Collections.Generic;
using System.Linq;
using Application.Persistance.Context;
using Application.Common.Dto;

namespace Application.Services.Common.Category.Queries.GetChildrenOfCategory
{
    public class GetChildrenOfProductCategoryService : IGetChildrenOfCategoryService
    {
        private readonly IDataBaseContext db;
        public GetChildrenOfProductCategoryService(IDataBaseContext context)
        {
            db = context;
        }
        public ResultDto<List<GetChildrenOfCategoryDto>> Execute(int id)
        {
            var children = db.ProductCategories.Where(c => c.Parent.Id == id)
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
