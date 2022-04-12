using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;
using Common.Dto;
using Common.Enums;

namespace Application.Services.Common.Category.Queries.GetAllCategories
{
    public interface IGetAllCategoriesService
    {
        ResultDto<List<GetAllCategoriesDto>> Execute(bool withChildren, Enums.CategoriesFilter filter, int id = 0);
    }
}
