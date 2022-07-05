using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Application.Interfaces.Context;
using Common.Dto;
using Common.Enums;
using Common.Utilities;
using Common.ViewModels;

namespace Application.Services.Admin.Excel.Commands.CreateExcelKey
{
    public interface ICreateExcelKeyService
    {
        Task<ResultDto<int>> Execute(int searchId);
    }

    public class CreateExcelKeyService : ICreateExcelKeyService
    {
        private readonly IDataBaseContext db;
        public CreateExcelKeyService(IDataBaseContext context)
        {
            db = context;
        }

        public async Task<ResultDto<int>> Execute(int searchId)
        {
            var entity = await db.ExcelStatuses.AddAsync(new Domain.Entities.Option.ExcelStatus
            {
                Status = 0,
                FileName = "",
                SearchFilterId = searchId
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
