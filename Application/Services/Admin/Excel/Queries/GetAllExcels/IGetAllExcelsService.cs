using Application.Interfaces.Context;
using Common.Dto;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.Services.Admin.Excel.Queries.GetAllExcels
{
    public interface IGetAllExcelsService
    {
        ResultDto<List<GetAllExcelsDto>> Execute();
    }

    public class GetAllExcelsService : IGetAllExcelsService
    {
        private readonly IDataBaseContext db;
        public GetAllExcelsService(IDataBaseContext context)
        {
            db = context;
        }

        public ResultDto<List<GetAllExcelsDto>> Execute()
        {
            var excels = db.ExcelKeys.Select(e=> new GetAllExcelsDto
            {
                FileName = e.FileName,
                StatusCode = e.Status
            }).ToList();

            return new ResultDto<List<GetAllExcelsDto>>
            {
                Data = excels,
                IsSuccess = true
            };
        }
    }

    public class GetAllExcelsDto
    {
        public string FileName { get; set; }
        public int StatusCode { get; set; }
    }
}
