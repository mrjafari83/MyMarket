using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Application.Services.Admin.ProductSizes.Queries.GetAllProductSizes;
using Application.Services.Admin.ProductSizes.Queries.GetAllSizes;
using Persistance.Context;
using Application.Interfaces.FacadPatterns.Admin;

namespace Application.FacadPatterns.Admin
{
    public class ProductSizeFacad : IProductSizeFacad
    {
        private readonly IDataBaseContext db;
        public ProductSizeFacad(IDataBaseContext context)
        {
            db = context;
        }

        private GetAllProductSizesService _getAllProductSizesService;
        public IGetAllProductSizesService GetAllProductSizesService 
        {
            get
            {
                return _getAllProductSizesService == null ? new GetAllProductSizesService(db) : _getAllProductSizesService;
            }
        }

        private GetAllSizesService _getAllSizesService;
        public IGetAllSizesService GetAllSizes
        {
            get
            {
                return _getAllSizesService ?? new GetAllSizesService(db);
            }
        }
    }
}
