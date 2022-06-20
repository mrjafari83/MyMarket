using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Application.Services.Client.Products.Commands.AddNewVisit;
using Application.Services.Client.Products.Queries.GetPriceByColorAndSize;

namespace Application.Interfaces.FacadPatterns.Client
{
    public interface IClientProductFacad
    {
        IAddNewVisitService AddNewVisit { get; }
        IGetPriceAndInventoryByColorAndSizeService GetPriceByColorAndSize { get; }
    }
}
