using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Persistance.Context;
using Common.Dto;
using Common.ViewModels;

namespace Application.Services.Admin.ProductColors.Queries.GetAllColors
{
    public interface IGetAllColorsService
    {
        ResultDto<List<ColorViewModel>> Execute();
    }

    public class GetAllColorsService : IGetAllColorsService
    {
        private readonly IDataBaseContext db;
        public GetAllColorsService(IDataBaseContext context)
        {
            db = context;
        }

        public ResultDto<List<ColorViewModel>> Execute()
        {
            var colors = db.ProductColors.Select(c => new ColorViewModel
            {
                Id = c.Id,
                Name = c.Name
            }).ToList();

            return new ResultDto<List<ColorViewModel>>
            {
                Data = colors,
                IsSuccess = true,
            };
        }
    }
}
