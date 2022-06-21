using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Application.Interfaces.Context;
using Application.Interfaces.FacadPatterns.Common;
using Application.Services.Common.Cart.Queries.GetUserCartPayings;
using Application.Services.Common.Cart.Queries.GetCartPayingById;
using AutoMapper;

namespace Application.FacadPatterns.Common
{
    public class CommonCartFacad : ICommonCartFacad
    {
        private readonly IDataBaseContext db;
        private readonly IMapper _mapper;
        public CommonCartFacad(IDataBaseContext context , IMapper mapper)
        {
            db = context;
            _mapper = mapper;
        }

        private GetUserCartPayingsService _getUserCartPayingsService;
        public IGetUserCartPayingsService GetUserCartPayings 
        {
            get
            {
                return _getUserCartPayingsService ?? new GetUserCartPayingsService(db);
            }
        }

        private GetCartPayingByIdService _getCartPayingByIdService;
        public IGetCartPayingByIdService GetCartPayingById
        {
            get
            {
                return _getCartPayingByIdService ?? new GetCartPayingByIdService(db,_mapper);
            }
        }
    }
}
