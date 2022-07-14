using System;
using System.Text;
using System.Threading.Tasks;
using Application.Common.Dto;
using Application.Persistance.Entities.Categories;
using Application.Persistance.Entities.Products;
using Application.Persistance.Entities.BlogPages;

namespace Application.Services.Admin.Categories.Queries.GetCategoryById
{
    public interface IGetCategoryByIdService
    {
        ResultDto<ResultOfGetCategoryByIdDto> Execute(int id);
    }
}
