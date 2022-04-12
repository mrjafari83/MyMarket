using System.Collections.Generic;

namespace Application.Services.Common.Category.Queries.GetChildrenOfCategory
{
    public class GetChildrenOfCategoryDto
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public int ChildrenCount { get; set; }
    }
}
