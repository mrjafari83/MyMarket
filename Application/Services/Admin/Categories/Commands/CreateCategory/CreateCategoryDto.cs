using Common.Enums;

namespace Application.Services.Admin.Categories.Commands.CreateCategory
{
    public class CreateCategoryDto
    {
        public string Name { get; set; }
        public int ParentId { get; set; }
    }
}
