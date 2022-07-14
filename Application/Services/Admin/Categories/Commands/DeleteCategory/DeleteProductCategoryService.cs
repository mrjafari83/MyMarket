using System;
using System.Linq;
using Application.Persistance.Context;
using Application.Common.Dto;

namespace Application.Services.Admin.Categories.Commands.DeleteCategory
{
    public class DeleteProductCategoryService : IDeleteCategoryService
    {
        private readonly IDataBaseContext db;
        public DeleteProductCategoryService(IDataBaseContext context)
        {
            db = context;
        }

        public ResultDto Execute(int id)
        {
            var category = db.ProductCategories.Find(id);

            category.IsRemoved = true;
            category.RemoveTime = DateTime.Now;

            db.ProductCategories.Update(category);

            deleteParentOfChildren(id);

            db.SaveChanges();
            return new ResultDto
            {
                IsSuccess = true,
                Message = "دسته بندی حذف شد."
            };
        }

        private void deleteParentOfChildren(int id)
        {
            var parent = db.ProductCategories.Find(id);
            var children = db.ProductCategories.Where(c => c.Parent.Id == id);
            if (children != null)
                foreach (var item in children)
                {
                    item.Parent = null;
                    if (parent.IsParent)
                        item.IsParent = true;
                }
        }
    }
}
