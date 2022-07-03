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
            var entity = await db.SearchFilter.AddAsync(new Domain.Entities.Option.SearchFilter
            {
                FilterXml = XmlConvertor<SearchViewModel>.ToXML(model),
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
