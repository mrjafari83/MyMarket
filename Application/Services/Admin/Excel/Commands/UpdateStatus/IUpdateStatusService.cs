using Application.Persistance.Context;
using Application.Common.Dto;
using Application.Common.Enums;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.Services.Admin.Excel.Commands.UpdateStatus
{
    public interface IUpdateStatusService
    {
        ResultDto Execute(Enums.Status status , int id);
    }

    public class UpdateStatusService : IUpdateStatusService
    {
        private readonly IDataBaseContext db;
        public UpdateStatusService(IDataBaseContext context)
        {
            db = context;
        }

        public ResultDto Execute(Enums.Status status , int id)
        {
            var entity = db.Excels.Find(id);
            if(entity != null)
            {
                entity.Status = (int)status;
                db.SaveChanges();

                return new ResultDto
                {
                    IsSuccess = true,
                };
            }

            return new ResultDto
            {
                IsSuccess = false
            };
        }
    }
}
