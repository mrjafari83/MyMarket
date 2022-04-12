using System.Collections.Generic;
using Application.Services.Common.Category.Queries.GetChildrenOfCategory;

namespace Application.Services.Common.Category.Queries.GetAllCategories
{
    public class GetAllCategoriesDto
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public int ParentId { get; set; }
        public bool IsParent { get; set; }
        public List<GetAllCategoriesDto> Children { get; set; }
    }
}
