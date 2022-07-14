using Persistance.Context;
using Common.Dto;

namespace Application.Services.Admin.Categories.Commands.EditCategory
{
    public class EditProductCategoryService : IEditCategoryService
    {
        private readonly IDataBaseContext db;
        public EditProductCategoryService(IDataBaseContext context)
        {
            db = context;
        }

        public ResultDto Execute(EditCategoryDto entry)
        {
            var parent = db.ProductCategories.Find(entry.ParentId);
            var category = db.ProductCategories.Find(entry.Id);

            if(parent != null)
            {
                EditParent(entry.Id, entry.ParentId);
                category.Parent = parent;
            }

            category.Name = entry.Name;
            
            db.ProductCategories.Update(category);
            db.SaveChanges();

            return new ResultDto
            {
                IsSuccess = true,
                Message = "دسته بندی با موفقیت ویرایش شد."
            };
        }

        private void EditParent(int id, int parentId)
        {
            var category = db.ProductCategories.Find(id);
            var parent = db.ProductCategories.Find(parentId);

            if (category.IsParent)
            {
                parent.IsParent = true;
                parent.Parent = null;
                category.IsParent = false;
            }
        }
    }
}
