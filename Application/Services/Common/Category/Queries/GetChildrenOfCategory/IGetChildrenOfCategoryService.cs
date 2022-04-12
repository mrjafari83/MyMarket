using Common.Dto;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.Services.Common.Category.Queries.GetChildrenOfCategory
{
    public interface IGetChildrenOfCategoryService
    {
        ResultDto<List<GetChildrenOfCategoryDto>> Execute(int id);
    }
}
