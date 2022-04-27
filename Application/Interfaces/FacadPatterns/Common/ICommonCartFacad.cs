using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Application.Services.Common.Cart.Queries.GetUserCartPayings;
using Application.Services.Common.Cart.Queries.GetCartPayingById;

namespace Application.Interfaces.FacadPatterns.Common
{
    public interface ICommonCartFacad
    {
        IGetUserCartPayingsService GetUserCartPayings { get; }
        IGetCartPayingByIdService GetCartPayingById { get; }
    }
}
