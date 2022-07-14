using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;
using Application.Common.Dto;

namespace Application.Services.Client.Products.Commands.AddNewVisit
{
    public interface IAddNewVisitService
    {
        ResultDto Execute(int id, string browserCode);
    }
}
