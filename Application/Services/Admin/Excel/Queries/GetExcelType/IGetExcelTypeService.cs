using Application.Persistance.Context;
using Application.Common.Enums;
using Application.Persistance.Entities.Option;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.Services.Admin.Excel.Queries.GetExcelType
{
    public interface IGetExcelTypeService
    {
        Application.Persistance.Entities.Option.SearchItemType GetExcelType(int excelId);
    }

    public class GetExcelTypeService : IGetExcelTypeService
    {
        private readonly IDataBaseContext db;
        public GetExcelTypeService(IDataBaseContext context)
        {
            db = context;
        }

        public SearchItemType GetExcelType(int excelId)
        {
            var excel = db.Excels.Find(excelId);
            if (excel != null)
                return excel.SearchType;
            return SearchItemType.Unknown;
        }
    }
}
