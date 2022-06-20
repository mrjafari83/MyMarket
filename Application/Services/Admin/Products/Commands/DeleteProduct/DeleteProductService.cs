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
                 .Include(p => p.Sizes).ThenInclude(s => s.Size).Include(p => p.Features).Include(p=> p.Inventories)
                 .Where(p => p.Id == id).FirstOrDefault();
            product.IsRemoved = true;
            product.RemoveTime = DateTime.Now;

            DeleteKeywords(product.Keywords.ToList());
            DeleteFeatures(product.Features.ToList());
            DeleteImages(product.Images.ToList());
            DeleteInventoryAndPrice(product.Inventories.ToList());
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
            if(productColors != null && colorInProducts != null)
            {
                foreach (var item in productColors)
                {
                    var color = db.ProductColors.Find(item.Id);
                    color.IsRemoved = true;
                    color.RemoveTime = System.DateTime.Now;
                    db.ProductColors.Update(color);
                }
                foreach (var item in colorInProducts)
                {
                    var colorInProdcut = db.ColorsInProducts.Find(item.Id);
                    colorInProdcut.IsRemoved = true;
                    colorInProdcut.RemoveTime = DateTime.Now;
                    db.ColorsInProducts.Update(colorInProdcut);
                }
            }
        }

        private void DeleteSizes(List<ProductSize> productSizes, List<SizeInProduct> sizeInProducts)
        {
            if(productSizes != null && sizeInProducts != null)
            {
                foreach (var item in productSizes)
                {
                    var size = db.ProductSizes.Find(item.Id);
                    size.IsRemoved = true;
                    size.RemoveTime = System.DateTime.Now;
                    db.ProductSizes.Update(size);
                }
                foreach (var item in sizeInProducts)
                {
                    var sizeInProduct = db.SizesInProducts.Find(item.Id);
                    sizeInProduct.IsRemoved = true;
                    sizeInProduct.RemoveTime = DateTime.Now;
                    db.SizesInProducts.Update(sizeInProduct);
                }
            }
        }

        private void DeleteInventoryAndPrice(List<ProductInventory> productInventories)
        {
            foreach (var item in productInventories)
                db.ProductInventories.RemoveRange(productInventories);
        }
    }
}
