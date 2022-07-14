using System;
using System.Text;
using System.Threading.Tasks;
using Common.Dto;
using Persistance.Entities.Categories;
using Persistance.Entities.Products;
using Persistance.Entities.BlogPages;

namespace Application.Services.Admin.Categories.Queries.GetCategoryById
{
    public interface IGetCategoryByIdService
    {
        ResultDto<ResultOfGetCategoryByIdDto> Execute(int id);
    }
}
