using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Application.Interfaces.FacadPatterns.Admin;
using Application.Interfaces.Context;
using Application.Services.Admin.ProductFeature.Commands.CreateProductFeature;
using Application.Services.Admin.ProductFeature.Commands.DeleteProductFeature;
using Application.Services.Admin.ProductFeature.Queries.GetAllProductFeatures;

namespace Application.FacadPatterns.Admin
{
    public class ProductFeatureFacad : IProductFeatureFacad
    {
        private readonly IDataBaseContext db;
        public ProductFeatureFacad(IDataBaseContext context)
        {
            db = context;
        }

        private GetAllProductFeatureService _getAllProductFeatureService;
        public IGetAllProductFeatureService GetAllProductFeatureService 
        {
            get
            {
                return _getAllProductFeatureService == null ? new GetAllProductFeatureService(db) : _getAllProductFeatureService;
            }
        }

        private CreateProductFeatureService _createProductFeatureService;
        public ICreateProductFeatureService CreateProductFeatureService
        {
            get
            {
                return _createProductFeatureService == null ? new CreateProductFeatureService(db) : _createProductFeatureService;
            }
        }

        private DeleteProductFeatureService _deleteProductFeatureService;
        public IDeleteProductFeatureService DeleteProductFeatureService
        {
            get
            {
                return _deleteProductFeatureService == null ? new DeleteProductFeatureService(db) : _deleteProductFeatureService;
            }
        }
    }
}
