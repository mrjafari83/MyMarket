using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;
using Common.Dto;
using Common.Enums;

namespace Application.Services.Admin.Products.Queries.GetAllProducts
{
    public interface IGetAllProductsService
    {
        Task<ResultDto<ResultGetAllProductsDto>> Execute(int pageNumber , int pageSize , int startPrice = 0, int endPrice = 0, string searchKey = ""
            , Enums.PageFilterCategory searchBy = Enums.PageFilterCategory.Name, Enums.PagesFilter orderBy = Enums.PagesFilter.Newest);
    }
}
