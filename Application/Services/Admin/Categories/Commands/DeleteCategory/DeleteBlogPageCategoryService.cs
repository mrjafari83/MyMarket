using System;
using System.Linq;
using Application.Interfaces.Context;
using Common.Dto;

namespace Application.Services.Admin.Categories.Commands.DeleteCategory
{
    public class DeleteBlogPageCategoryService : IDeleteCategoryService
    {
        private readonly IDataBaseContext db;
        public DeleteBlogPageCategoryService(IDataBaseContext context)
        {
            db = context;
        }

        public ResultDto Execute(int id)
        {
            var category = db.BlogPageCategories.Find(id);

            category.IsRemoved = true;
            category.RemoveTime = DateTime.Now;

            db.BlogPageCategories.Update(category);

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
            var parent = db.BlogPageCategories.Find(id);
            var children = db.BlogPageCategories.Where(c => c.Parent.Id == id);
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
