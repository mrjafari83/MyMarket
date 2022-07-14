using Application.Persistance.Context;
using Application.Common.Dto;
using Application.Persistance.Entities.Categories;
using Application.Persistance.Entities.Products;

namespace Application.Services.Admin.Categories.Commands.CreateCategory
{
    public class CreateProductCategoryService : ICreateCategoryService
    {
        private readonly IDataBaseContext db;
        public CreateProductCategoryService(IDataBaseContext context)
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
                var parent = db.ProductCategories.Find(entry.ParentId);

                if (parent != null)
                    db.ProductCategories.Add(
                    new Category<Product>
                    {
                        Name = entry.Name,
                        Parent = parent,
                        IsParent = false
                    }
                    );
                else
                {
                    db.ProductCategories.Add(
                    new Category<Product>
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
