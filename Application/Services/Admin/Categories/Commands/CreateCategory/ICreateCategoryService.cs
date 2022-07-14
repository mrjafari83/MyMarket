using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Application.Common.Dto;

namespace Application.Services.Admin.Categories.Commands.CreateCategory
{
    public interface ICreateCategoryService
    {
        ResultDto Execute(CreateCategoryDto entry);
    }
}
