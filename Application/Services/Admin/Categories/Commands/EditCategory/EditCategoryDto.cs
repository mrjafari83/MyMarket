using Common.Enums;

namespace Application.Services.Admin.Categories.Commands.EditCategory
{
    public class EditCategoryDto
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public int ParentId { get; set; }
    }
}
