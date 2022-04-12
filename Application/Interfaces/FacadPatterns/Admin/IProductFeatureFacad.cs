using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Application.Services.Admin.ProductFeature.Commands.CreateProductFeature;
using Application.Services.Admin.ProductFeature.Commands.DeleteProductFeature;
using Application.Services.Admin.ProductFeature.Queries.GetAllProductFeatures;

namespace Application.Interfaces.FacadPatterns.Admin
{
    public interface IProductFeatureFacad
    {
        IGetAllProductFeatureService GetAllProductFeatureService { get; }
        ICreateProductFeatureService CreateProductFeatureService { get; }
        IDeleteProductFeatureService DeleteProductFeatureService { get; }
    }
}
