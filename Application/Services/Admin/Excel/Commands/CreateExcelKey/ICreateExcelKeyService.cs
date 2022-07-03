using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Application.Interfaces.Context;
using Common.Dto;
using Common.Enums;
using Common.ViewModels;

namespace Application.Services.Admin.Excel.Commands.CreateExcelKey
{
    public interface ICreateExcelKeyService
    {
        Task<ResultDto<int>> Execute(SearchViewModel model);
    }

    public class CreateExcelKeyService : ICreateExcelKeyService
    {
        private readonly IDataBaseContext db;
        public CreateExcelKeyService(IDataBaseContext context)
        {
            db = context;
        }

        public async Task<ResultDto<int>> Execute(SearchViewModel model)
        {
            var entity = await db.ExcelKeys.AddAsync(new Domain.Entities.Option.SearchFilter
            {
                SearchKey = model.SearchKey,
                SearchBy = (int)model.SearchBy,
                OrderBy = (int)model.OrderBy,
                StartPrice = model.StartPrice,
                EndPrice = model.EndPrice,
                Status = (int)Enums.Status.Created
            });

            await db.SaveChangesAsync();

            return new ResultDto<int>
            {
                Data = entity.Entity.Id,
                IsSuccess = true
            };
        }
    }
}
