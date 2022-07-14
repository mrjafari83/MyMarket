using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Persistance.Context;
using Application.Interfaces.FacadPatterns.Client;
using Application.Services.Client.Products.Commands.AddNewVisit;
using Application.Services.Client.Products.Queries.GetPriceByColorAndSize;

namespace Application.FacadPatterns.Client
{
    public class ClientProductFacad : IClientProductFacad
    {
        private readonly IDataBaseContext db;
        public ClientProductFacad(IDataBaseContext context)
        {
            db = context;
        }

        private AddNewVisitService _addNewVisitService;
        public IAddNewVisitService AddNewVisit 
        {
            get
            {
                return _addNewVisitService ?? new AddNewVisitService(db);
            }
        }

        private GetPriceAndInventoryByColorAndSizeService _getPriceByColorAndSize;
        public IGetPriceAndInventoryByColorAndSizeService GetPriceByColorAndSize
        {
            get
            {
                return _getPriceByColorAndSize ?? new GetPriceAndInventoryByColorAndSizeService(db);
            }
        }
    }
}
