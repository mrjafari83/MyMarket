using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;
using Common.Dto;
using Common.ViewModels;

namespace Application.Services.Admin.ProductSizes.Queries.GetAllSizes
{
    public interface IGetAllSizesService
    {
        ResultDto<List<SizeViewModel>> Execute();
    }
}
