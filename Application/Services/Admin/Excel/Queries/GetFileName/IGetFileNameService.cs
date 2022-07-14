using Persistance.Context;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.Services.Admin.Excel.Queries.GetFileName
{
    public interface IGetFileNameService
    {
        string GetFileName(int excelId);
    }

    public class GetFileNameService : IGetFileNameService
    {
        private readonly IDataBaseContext db;
        public GetFileNameService(IDataBaseContext context)
        {
            db = context;
        }

        public string GetFileName(int excelId)
        {
            var excel = db.Excels.Find(excelId);
            if(excel != null)
                return excel.FileName;
            else
                return "";
        }
    }
}
