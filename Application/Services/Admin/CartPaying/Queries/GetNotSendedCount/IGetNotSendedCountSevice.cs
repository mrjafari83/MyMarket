using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Application.Interfaces.Context;
using Common.Dto;
using Microsoft.EntityFrameworkCore;

namespace Application.Services.Admin.CartPaying.Queries.GetNotSendedCount
{
    public interface IGetNotSendedCountSevice
    {
        ResultDto<int> Execute();
    }

    public class GetNotSendedCountSevice : IGetNotSendedCountSevice
    {
        private readonly IDataBaseContext db;
        public GetNotSendedCountSevice(IDataBaseContext context)
        {
            db = context;
        }

        public ResultDto<int> Execute()
        {
            return new ResultDto<int>
            {
                Data = db.CartPayings.Where(c => c.IsPayed && !c.Sended).Count(),
                IsSuccess = true
            };
        }
    }
}
