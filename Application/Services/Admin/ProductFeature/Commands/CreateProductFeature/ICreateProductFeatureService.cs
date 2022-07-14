using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Application.Common.Dto;

namespace Application.Services.Admin.ProductFeature.Commands.CreateProductFeature
{
    public interface ICreateProductFeatureService
    {
        ResultDto Execute(CreateProductFeatureDto entry);
    }
}
