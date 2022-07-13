using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;
using Common.Dto;
using Common.Enums;
using Common.ViewModels;
using Common.ViewModels.SearchViewModels;

namespace Application.Services.Admin.Products.Queries.GetAllProducts
{
    public interface IGetAllProductsService
    {
        Task<ResultDto<ResultGetAllProductsDto>> Execute(int pageNumber , int pageSize , ProducsSearchViewModel model);
    }
}
