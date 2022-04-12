using Common.Dto;
using Common.ViewModels;
using Application.Interfaces.Context;
using Domain.Entities.Common;
using Domain.Entities.Products;

namespace Application.Services.Admin.Keyword.Commands.CreateKeyword
{
    public static class CreateProductKeywordService
    {
        public static ResultDto Execute(KeywordViewModel keyword, int productId, IDataBaseContext db)
        {
            db.ProductKeywords.Add(new Keyword<Product>
            {
                Value = keyword.KeywordValue,
                Parent = db.Products.Find(productId)
            });

            return new ResultDto
            {
                IsSuccess = true,
            };
        }
    }
}
