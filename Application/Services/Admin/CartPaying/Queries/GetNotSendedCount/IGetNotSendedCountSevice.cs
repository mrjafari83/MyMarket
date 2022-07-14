using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Application.Persistance.Context;
using Application.Common.Dto;
using Microsoft.EntityFrameworkCore;

namespace Application.Services.Admin.CartPaying.Queries.GetNotSendedCount
{
    public interface IGetNotSendedCountSevice
    {
        Task<ResultDto<int>> Execute();
    }

    public class GetNotSendedCountSevice : IGetNotSendedCountSevice
    {
        private readonly IDataBaseContext db;
        public GetNotSendedCountSevice(IDataBaseContext context)
        {
            db = context;
        }

        public async Task<ResultDto<int>> Execute()
        {
            return new ResultDto<int>
            {
                Data = await db.CartPayings.Where(c => c.IsPayed && !c.Sended).CountAsync(),
                IsSuccess = true
            };
        }
    }
}
