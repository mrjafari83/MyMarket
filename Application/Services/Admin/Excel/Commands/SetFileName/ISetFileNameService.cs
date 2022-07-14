using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Common.Dto;
using Application.Interfaces.Context;

namespace Application.Services.Admin.Excel.Commands.SetFileName
{
    public interface ISetFileNameService
    {
        ResultDto SetFileName(string fileName , int id);
    }

    public class SetFileNameService : ISetFileNameService
    {
        private readonly IDataBaseContext db;
        public SetFileNameService(IDataBaseContext context)
        {
            db = context;
        }

        public ResultDto SetFileName(string fileName, int excelId)
        {
            var entity = db.Excels.Find(excelId);
            entity.FileName = fileName;
            db.SaveChanges();

            return new ResultDto
            {
                IsSuccess = true,
            };
        }
    }
}
