using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Application.Services.Admin.Categories.Commands.CreateCategory;
using Application.Services.Admin.Categories.Commands.EditCategory;
using Application.Services.Admin.Categories.Commands.DeleteCategory;
using Application.Services.Admin.Categories.Queries.GetCategoryById;

namespace Application.Interfaces.FacadPatterns.Admin
{
    public interface IBlogPageCategoryFacad
    {
        IGetCategoryByIdService GetById { get; }
        ICreateCategoryService Create { get; }
        IEditCategoryService Edit { get; }
        IDeleteCategoryService Delete { get; }
    }
}
