using Application.Interfaces.Context;
using Common.Dto;

namespace Application.Services.Admin.Categories.Commands.EditCategory
{
    public class EditBlogPageCategoryService : IEditCategoryService
    {
        private readonly IDataBaseContext db;
        public EditBlogPageCategoryService(IDataBaseContext context)
        {
            db = context;
        }

        public ResultDto Execute(EditCategoryDto entry)
        {
            var parent = db.BlogPageCategories.Find(entry.ParentId);
            var category = db.BlogPageCategories.Find(entry.Id);

            if(parent != null)
            {
                EditParent(entry.Id, entry.ParentId);
                category.Parent = parent;
            }

            category.Name = entry.Name;

            db.BlogPageCategories.Update(category);
            db.SaveChanges();

            return new ResultDto
            {
                IsSuccess = true,
                Message = "دسته بندی با موفقیت ویرایش شد."
            };
        }

        private void EditParent(int id, int parentId)
        {
            var category = db.BlogPageCategories.Find(id);
            var parent = db.BlogPageCategories.Find(parentId);

            if (category.IsParent)
            {
                parent.IsParent = true;
                parent.Parent = null;
                category.IsParent = false;
            }
        }
    }
}
