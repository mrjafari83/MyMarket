using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Application.Services.Admin.ProductSizes.Queries.GetAllProductSizes;
using Application.Services.Admin.ProductSizes.Queries.GetAllSizes;

namespace Application.Interfaces.FacadPatterns.Admin
{
    public interface IProductSizeFacad
    {
        IGetAllProductSizesService GetAllProductSizesService { get; }
        IGetAllSizesService GetAllSizes { get; }
    }
}
