using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Application.Services.Admin.ProductColors.Queries.GetAllProductColors;
using Application.Services.Admin.ProductColors.Queries.GetAllColors;

namespace Application.Interfaces.FacadPatterns.Admin
{
    public interface IProductColorFacad
    {
        IGetAllProductColorsService GetAllProductColorsService { get; }
        IGetAllColorsService GetAllColors { get; }
    }
}
