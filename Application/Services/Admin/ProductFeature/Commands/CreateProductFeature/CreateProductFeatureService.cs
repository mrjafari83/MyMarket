using Application.Persistance.Context;
using Application.Common.Dto;
using Application.Persistance.Entities.Products;

namespace Application.Services.Admin.ProductFeature.Commands.CreateProductFeature
{
    public class CreateProductFeatureService : ICreateProductFeatureService
    {
        private readonly IDataBaseContext db;
        public CreateProductFeatureService(IDataBaseContext context)
        {
            db = context;
        }

        public ResultDto Execute(CreateProductFeatureDto entry)
        {
            db.ProductFutures.Add(new Application.Persistance.Entities.Products.ProductFeature
            {
                Display = entry.Name,
                FeatureValue = entry.Value,
            });

            db.SaveChanges();

            return new ResultDto
            {
                IsSuccess = true,
                Message = "ویژگی با موفقیت اضافه شد."
            };
        }
    }
}
