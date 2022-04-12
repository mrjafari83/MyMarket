using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;
using Common.Dto;

namespace Application.Services.Admin.Categories.Commands.DeleteCategory
{
    public interface IDeleteCategoryService
    {
        ResultDto Execute(int id);
    }
}
