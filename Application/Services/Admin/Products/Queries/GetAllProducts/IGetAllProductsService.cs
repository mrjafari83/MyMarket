using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;
using Application.Common.Dto;
using Application.Common.Enums;
using Application.Common.ViewModels;
using Application.Common.ViewModels.SearchViewModels;

namespace Application.Services.Admin.Products.Queries.GetAllProducts
{
    public interface IGetAllProductsService
    {
        Task<ResultDto<ResultGetAllProductsDto>> Execute(int pageNumber , int pageSize , ProducsSearchViewModel model);
    }
}
