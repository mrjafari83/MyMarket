using System;
using System.Text;
using System.Threading.Tasks;
using Common.Dto;
using Domain.Entities.Categories;
using Domain.Entities.Products;
using Domain.Entities.BlogPages;

namespace Application.Services.Admin.Categories.Queries.GetCategoryById
{
    public interface IGetCategoryByIdService
    {
        ResultDto<ResultOfGetCategoryByIdDto> Execute(int id);
    }
}
