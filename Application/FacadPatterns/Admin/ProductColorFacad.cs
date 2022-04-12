using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Application.Services.Admin.ProductColors.Queries.GetAllProductColors;
using Application.Services.Admin.ProductColors.Queries.GetAllColors;
using Application.Interfaces.Context;
using Application.Interfaces.FacadPatterns.Admin;

namespace Application.FacadPatterns.Admin
{
    public class ProductColorFacad : IProductColorFacad
    {
        private readonly IDataBaseContext db;
        public ProductColorFacad(IDataBaseContext context)
        {
            db = context;
        }

        private GetAllProductColorsService _getAllProductColorsService;
        public IGetAllProductColorsService GetAllProductColorsService 
        {
            get 
            {
                return _getAllProductColorsService == null ? new GetAllProductColorsService(db) : _getAllProductColorsService;
            }
        }

        private GetAllColorsService _getAllColorsService;
        public IGetAllColorsService GetAllColors
        {
            get
            {
                return _getAllColorsService ?? new GetAllColorsService(db);
            }
        }
    }
}
