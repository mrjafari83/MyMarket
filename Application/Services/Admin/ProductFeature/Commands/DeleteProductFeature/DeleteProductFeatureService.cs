using System;
using Persistance.Context;
using Common.Dto;

namespace Application.Services.Admin.ProductFeature.Commands.DeleteProductFeature
{
    public class DeleteProductFeatureService : IDeleteProductFeatureService
    {
        private readonly IDataBaseContext db;
        public DeleteProductFeatureService(IDataBaseContext context)
        {
            db = context;
        }

        public ResultDto Execute(int id)
        {
            var feature = db.ProductFutures.Find(id);

            feature.IsRemoved = true;
            feature.RemoveTime = DateTime.Now;

            db.ProductFutures.Update(feature);
            db.SaveChanges();

            return new ResultDto
            {
                IsSuccess = true,
                Message = "ویژگی حذف شد."
            };
        }
    }
}
