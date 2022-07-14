using System;
using System.Collections.Generic;
using System.Linq;
using Persistance.Context;
using Common.Dto;
using Persistance.Entities.Common;
using Persistance.Entities.Products;
using Persistance.Entities.Products.Relations;
using Microsoft.EntityFrameworkCore;
using Common.Utilities;
using System.Threading.Tasks;

namespace Application.Services.Admin.Products.Commands.DeleteProduct
{
    public class DeleteProductService : IDeleteProductService
    {
        private readonly IDataBaseContext db;
        public DeleteProductService(IDataBaseContext context)
        {
            db = context;
        }

        public async Task<ResultDto> Execute(int id)
        {
            var product = await db.Products.Include(p => p.Keywords).Include(p => p.Images).Include(p => p.Colors).ThenInclude(c => c.Color)
                 .Include(p => p.Sizes).ThenInclude(s => s.Size).Include(p => p.Features).Include(p => p.Inventories)
                 .Where(p => p.Id == id).FirstOrDefaultAsync();
            product.IsRemoved = true;
            product.RemoveTime = DateTime.Now;

            DeleteKeywords(product.Keywords.ToList());
            DeleteFeatures(product.Features.ToList());
            DeleteImages(product.Images.ToList());
            DeleteInventoryAndPrice(product.Inventories.ToList());
            await DeleteColors(product.Colors.Select(c => new ProductColor { Id = c.Color.Id}).ToList(), product.Colors.ToList());
            await DeleteSizes(product.Sizes.Select(s => new ProductSize { Id = s.Size.Id }).ToList(), product.Sizes.ToList());
            db.Products.Update(product);
            await db.SaveChangesAsync();

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

        private void DeleteFeatures(List<Persistance.Entities.Products.ProductFeature> productFeatures)
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

        private async Task DeleteColors(List<ProductColor> productColors, List<ColorInProduct> colorInProducts)
        {
            if(productColors != null && colorInProducts != null)
            {
                //foreach (var item in productColors)
                //{
                ////    var color = db.ProductColors.Find(item.Id);
                ////    color.IsRemoved = true;
                ////    color.RemoveTime = System.DateTime.Now;
                ////    db.ProductColors.Update(color);
                ////}
                foreach (var item in colorInProducts)
                {
                    var colorInProdcut = await db.ColorsInProducts.FindAsync(item.Id);
                    colorInProdcut.IsRemoved = true;
                    colorInProdcut.RemoveTime = DateTime.Now;
                    db.ColorsInProducts.Update(colorInProdcut);
                }
            }
        }

        private async Task DeleteSizes(List<ProductSize> productSizes, List<SizeInProduct> sizeInProducts)
        {
            if(productSizes != null && sizeInProducts != null)
            {
                //foreach (var item in productSizes)
                //{
                //    var size = db.ProductSizes.Find(item.Id);
                //    size.IsRemoved = true;
                //    size.RemoveTime = System.DateTime.Now;
                //    db.ProductSizes.Update(size);
                //}
                foreach (var item in sizeInProducts)
                {
                    var sizeInProduct = await db.SizesInProducts.FindAsync(item.Id);
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
