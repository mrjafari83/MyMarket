using Application.Interfaces.Context;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Application.Services.Admin.Options.Queries.GetAllProductDetails;
using Application.Interfaces.FacadPatterns.Admin;
using Application.Services.Admin.Common.Queries.GetProductsBySearch;

namespace Application.FacadPatterns.Admin
{
    public class OptionFacade : IOptionFacade
    {
        private readonly IDataBaseContext db;
        public OptionFacade(IDataBaseContext context)
        {
            db = context;
        }

        private GetAllProductDetailsService _getAllProductDetailsService;
        public IGetAllProductDetailsService GetAllProductDetailsService 
        {
            get => _getAllProductDetailsService ?? new GetAllProductDetailsService(db);
        }
    }
}
