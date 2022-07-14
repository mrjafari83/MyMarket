using System.Collections.Generic;
using System.Linq;
using Persistance.Context;
using Common.Dto;
using Common.ViewModels;

namespace Application.Services.Admin.ProductSizes.Queries.GetAllSizes
{
    public class GetAllSizesService : IGetAllSizesService
    {
        private readonly IDataBaseContext db;
        public GetAllSizesService(IDataBaseContext context)
        {
            db = context;
        }
        public ResultDto<List<SizeViewModel>> Execute()
        {
            var sizes = db.ProductSizes.Select(s => new SizeViewModel
            {
                SizeValue = s.SizeValue
            }).ToList();

            return new ResultDto<List<SizeViewModel>>
            {
                Data = sizes,
                IsSuccess = true
            };
        }
    }
}
