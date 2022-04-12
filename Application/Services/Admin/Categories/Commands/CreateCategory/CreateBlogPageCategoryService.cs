using Application.Interfaces.Context;
using Common.Dto;
using Domain.Entities.Categories;
using Domain.Entities.BlogPages;

namespace Application.Services.Admin.Categories.Commands.CreateCategory
{
    public class CreateBlogPageCategoryService : ICreateCategoryService
    {
        private readonly IDataBaseContext db;
        public CreateBlogPageCategoryService(IDataBaseContext context)
        {
            db = context;
        }

        public ResultDto Execute(CreateCategoryDto entry)
        {
            if (entry.Name == "بدون دسته بندی")
                return new ResultDto
                {
                    IsSuccess = false
                };

            else
            {
                var parent = db.BlogPageCategories.Find(entry.ParentId);

                if (parent != null)
                    db.BlogPageCategories.Add(
                    new Category<BlogPage>
                    {
                        Name = entry.Name,
                        Parent = parent,
                        IsParent = false
                    }
                    );
                else
                {
                    db.BlogPageCategories.Add(
                    new Category<BlogPage>
                    {
                        Name = entry.Name,
                        Parent = null,
                        IsParent = true
                    }
                    );
                }
                db.SaveChanges();
                return new ResultDto
                {
                    IsSuccess = true,
                    Message = "دسته بندی جدید با موفقست اضافه شد."
                };
            }
        }
    }
}
