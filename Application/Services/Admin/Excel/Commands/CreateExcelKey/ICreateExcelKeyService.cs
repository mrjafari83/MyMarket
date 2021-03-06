using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Application.Persistance.Context;
using Application.Common.Dto;
using Application.Common.Enums;
using Application.Common.Utilities;
using Application.Common.ViewModels;

namespace Application.Services.Admin.Excel.Commands.CreateExcelKey
{
    public interface ICreateExcelKeyService
    {
        Task<ResultDto<int>> Execute<JsonModel>(JsonModel searchFilters, Persistance.Entities.Option.SearchItemType searchType) where JsonModel : class;
    }

    public class CreateExcelKeyService : ICreateExcelKeyService
    {
        private readonly IDataBaseContext db;
        public CreateExcelKeyService(IDataBaseContext context)
        {
            db = context;
        }

        public async Task<ResultDto<int>> Execute<JsonModel>(JsonModel searchFilters, Persistance.Entities.Option.SearchItemType searchType) where JsonModel : class
        {
            var entity = await db.Excels.AddAsync(new Application.Persistance.Entities.Option.Excel
            {
                Status = 0,
                FileName = "",
                SearchType = searchType,
                FilterJson = JsonConvertor<JsonModel>.ToJson(searchFilters)
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
