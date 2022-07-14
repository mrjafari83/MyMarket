using System.Collections.Generic;
using Application.Persistance.Entities.Categories;

namespace Application.Services.Admin.Categories.Queries.GetCategoryById
{
    public class ResultOfGetCategoryByIdDto
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public int ParentId { get; set; }
        public string ParentName { get; set; }
        public bool IsParent { get; set; }
    }
}
