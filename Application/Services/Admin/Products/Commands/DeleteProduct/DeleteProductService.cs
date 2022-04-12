using System;
using System.Collections.Generic;
using System.Linq;
using Application.Interfaces.Context;
using Common.Dto;
using Domain.Entities.Common;
using Domain.Entities.Products;
using Domain.Entities.Products.Relations;
using Microsoft.EntityFrameworkCore;
using Common.Utilities;

namespace Application.Services.Admin.Products.Commands.DeleteProduct
{
    public class DeleteProductService : IDeleteProductService
    {
        private readonly IDataBaseContext db;
        public DeleteProductService(IDataBaseContext context)
        {
            db = context;
        }

        public ResultDto Execute(int id)
        {
            var product = db.Products.Include(p => p.Keywords).Include(p => p.Images).Include(p => p.Colors).ThenInclude(c => c.Color)
                 .Include(p => p.Sizes).ThenInclude(s => s.Size).Include(p => p.Features).Where(p => p.Id == id).FirstOrDefault();
            product.IsRemoved = true;
            product.RemoveTime = DateTime.Now;

            DeleteKeywords(product.Keywords.ToList());
            DeleteFeatures(product.Features.ToList());
            DeleteImages(product.Images.ToList());
            DeleteColors(product.Colors.Select(c => new ProductColor { Id = c.Color.Id}).ToList(), product.Colors.ToList());
            DeleteSizes(product.Sizes.Select(s => new ProductSize { Id = s.Size.Id }).ToList(), product.Sizes.ToList());

            db.Products.Update(product);
            db.SaveChanges();

            return new ResultDto
            {
                IsSuccess = true,
                Message = "محصول حذف شد."
            };
        }

        private void DeleteKeywords(List<Keyword<Product>> productKeywords)
        {
            foreach (var item in productKeywords)
            {
                item.IsRemoved = true;
                item.RemoveTime = System.DateTime.Now;
                db.ProductKeywords.Update(item);
            }
        }

        private void DeleteFeatures(List<Domain.Entities.Products.ProductFeature> productFeatures)
        {
            foreach (var item in productFeatures)
            {
                item.IsRemoved = true;
                item.RemoveTime = System.DateTime.Now;
                db.ProductFutures.Update(item);
            }
        }

        private void DeleteImages(List<ProductImage> productImages)
        {
            foreach (var item in productImages)
            {
                FileUploader.Delete(item.Src);
                db.ProductImages.Remove(item);
            }
        }

        private void DeleteColors(List<ProductColor> productColors, List<ColorInProduct> colorInProducts)
        {
            foreach (var item in productColors)
            {
                item.IsRemoved = true;
                item.RemoveTime = System.DateTime.Now;
                db.ProductColors.Update(item);
            }
            foreach (var item in colorInProducts)
            {
                item.IsRemoved = true;
                item.RemoveTime = DateTime.Now;
                db.ColorsInProducts.Update(item);
            }
        }

        private void DeleteSizes(List<ProductSize> productSizes, List<SizeInProduct> sizeInProducts)
        {
            foreach (var item in productSizes)
            {
                item.IsRemoved = true;
                item.RemoveTime = System.DateTime.Now;
                db.ProductSizes.Update(item);
            }
            foreach (var item in sizeInProducts)
            {
                item.IsRemoved = true;
                item.RemoveTime = DateTime.Now;
                db.SizesInProducts.Update(item);
            }
        }
    }
}
