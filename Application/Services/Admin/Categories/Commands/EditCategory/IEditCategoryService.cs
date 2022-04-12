using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Common.Dto;

namespace Application.Services.Admin.Categories.Commands.EditCategory
{
    public interface IEditCategoryService
    {
        ResultDto Execute(EditCategoryDto entry);
    }
}
