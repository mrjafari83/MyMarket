using Persistance.Context;
using Common.Dto;
using Common.ViewModels;
using Persistance.Entities.Common;
using Persistance.Entities.Products;
using Persistance.Entities.Products.Relations;
using Microsoft.EntityFrameworkCore;
using System.Collections.Generic;
using System.Linq;
using Common.Utilities;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Http;
using AutoMapper;
using System.Threading.Tasks;

namespace Application.Services.Admin.Products.Commands.EditProduct
{
    public class EditProductService : IEditProductService
    {
        private readonly IDataBaseContext db;
        private readonly IHostingEnvironment _environment;
        public EditProductService(IDataBaseContext context, IHostingEnvironment environment)
        {
            db = context;
            _environment = environment;
        }

        public async Task<ResultDto> Execute(EditProductDto entry)
        {
            var product = await db.Products.Include(p => p.Keywords).Include(p => p.Images).Include(p => p.Colors).ThenInclude(c => c.Color)
                .Include(p => p.Sizes).ThenInclude(s => s.Size).Include(p => p.Features).Include(p => p.Inventories)
                .Where(p => p.Id == entry.Product.Id).FirstOrDefaultAsync();

            product.Name = entry.Product.Name;
            product.Brand = entry.Product.Brand;
            product.Description = entry.Product.Description;
            product.ShortDescription = entry.Product.ShortDescription;

            if (entry.Product.CategoryId != 0)
            {
                product.CategoryId = entry.Product.CategoryId;
                product.Category = await db.ProductCategories.FindAsync(entry.Product.CategoryId);
            }

            if (entry.Images.Count() != 0)
            {
                DeleteImages(product.Images.ToList());
                await AddImages(product, entry.Images);
            }

            List<ProductColor> colors = product.Colors.Select(c => new ProductColor { Id = c.Color.Id, Name = c.Color.Name }).ToList();
            await AddColors(product, entry.Colors, colors);
            await DeleteColors(entry.Colors, colors, product);

            List<ProductSize> sizes = product.Sizes.Select(s => new ProductSize { Id = s.Size.Id, SizeValue = s.Size.SizeValue }).ToList();
            await AddSizes(product, entry.Sizes, sizes);
            await DeleteSizes(product, entry.Sizes, sizes);

            await AddKeywords(product, entry.Keywords, product.Keywords.ToList());
            await AddFeaturs(product, entry.Features, product.Features.ToList());

            await DeleteKeywords(entry.Keywords, product.Keywords.ToList());
            await DeleteFeatures(entry.Features, product.Features.ToList());

            await EditInventoryAndPrice(entry.InventoryAndPrices, product.Inventories.ToList(), product);

            db.Products.Update(product);
            await db.SaveChangesAsync();

            return new ResultDto
            {
                IsSuccess = true,
                Message = "محصول ویرایش شد."
            };
        }

        private async Task AddKeywords(Product product, List<KeywordViewModel> keywords, List<Keyword<Product>> productKeywords)
        {
            foreach (var item in keywords)
            {
                if (productKeywords.Where(k => k.Value == item.KeywordValue).Count() != 0)
                    continue;

                await db.ProductKeywords.AddAsync(new Keyword<Product> { Value = item.KeywordValue, Parent = product });
            }
        }

        private async Task DeleteKeywords(List<KeywordViewModel> keywords, List<Keyword<Product>> productKeywords)
        {
            foreach (var item in productKeywords)
            {
                if (keywords.Where(k => k.KeywordValue == item.Value).Count() == 0)
                {
                    var keyword = await db.ProductKeywords.FindAsync(item.Id);
                    keyword.IsRemoved = true;
                    keyword.RemoveTime = System.DateTime.Now;
                    db.ProductKeywords.Update(keyword);
                }
            }
        }

        private async Task AddFeaturs(Product product, List<FeatureViewModel> features, List<Persistance.Entities.Products.ProductFeature> productFeatures)
        {
            foreach (var item in features)
            {
                if (productFeatures.Where(k => k.Display == item.Display && k.FeatureValue == item.FeatureValue).Count() != 0)
                    continue;

                await db.ProductFutures.AddAsync(new Persistance.Entities.Products.ProductFeature
                {
                    Display = item.Display,
                    FeatureValue = item.FeatureValue,
                    Product = product
                });
            }
        }

        private async Task DeleteFeatures(List<FeatureViewModel> features, List<Persistance.Entities.Products.ProductFeature> productFeatures)
        {
            foreach (var item in productFeatures)
            {
                if (features.Where(k => k.Display == item.Display && k.FeatureValue == item.FeatureValue).Count() == 0)
                {
                    var feature = await db.ProductFutures.FindAsync(item.Id);
                    feature.IsRemoved = true;
                    feature.RemoveTime = System.DateTime.Now;
                    db.ProductFutures.Update(feature);
                }
            }
        }

        private async Task AddColors(Product product, List<ColorViewModel> colors, List<ProductColor> productColors)
        {
            foreach (var item in colors)
            {
                if (productColors.Where(c => c.Name == item.Name).Any())
                    continue;

                ProductColor color = new ProductColor();
                if (db.ProductColors.Where(c => c.Name == item.Name).Any())
                    color = await db.ProductColors.Where(c => c.Name == item.Name).FirstAsync();
                else
                {
                    var add = await db.ProductColors.AddAsync(new ProductColor { Name = item.Name });
                    color = add.Entity;
                }
                await db.ColorsInProducts.AddAsync(new ColorInProduct { Product = product, Color = color });
            }
        }

        private async Task DeleteColors(List<ColorViewModel> colors, List<ProductColor> productColors, Product product)
        {
            foreach (var item in productColors)
            {
                if (colors.Where(c => c.Name == item.Name).Count() == 0)
                {
                    var color = await db.ProductColors.FindAsync(item.Id);
                    var relation = await db.ColorsInProducts.Where(c => c.Color == color && c.Product == product).FirstOrDefaultAsync();
                    relation.IsRemoved = true;
                    relation.RemoveTime = System.DateTime.Now;
                    db.ColorsInProducts.Update(relation);
                }
            }
        }

        private async Task AddSizes(Product product, List<SizeViewModel> sizes, List<ProductSize> productSizes)
        {
            foreach (var item in sizes)
            {
                if (productSizes.Where(s => s.SizeValue == item.SizeValue).ToList().Count() != 0)
                    continue;

                ProductSize size = new ProductSize();
                if (db.ProductSizes.Where(s => s.SizeValue == item.SizeValue).Any())
                    size = await db.ProductSizes.Where(s => s.SizeValue == item.SizeValue).FirstAsync();
                else
                {
                    var add = await db.ProductSizes.AddAsync(new ProductSize { SizeValue = item.SizeValue });
                    size = add.Entity;
                }
                await db.SizesInProducts.AddAsync(new SizeInProduct { Product = product, Size = size });
            }
        }

        private async Task DeleteSizes(Product product, List<SizeViewModel> sizes, List<ProductSize> productSizes)
        {
            foreach (var item in productSizes)
            {
                if (sizes.Where(s => s.SizeValue == item.SizeValue).Count() == 0)
                {
                    var size = await db.ProductSizes.FindAsync(item.Id);
                    var relation = await db.SizesInProducts.Where(s => s.Size == size && s.Product == product).FirstOrDefaultAsync();
                    relation.IsRemoved = true;
                    relation.RemoveTime = System.DateTime.Now;
                    db.SizesInProducts.Update(relation);
                }
            }
        }

        private async Task AddImages(Product product, List<IFormFile> images)
        {
            foreach (var item in images)
            {
                db.ProductImages.Add(new ProductImage
                {
                    Product = product,
                    Src = await FileUploader.Upload(item, _environment, "products/" + product.Name)
                });
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

        private async Task EditInventoryAndPrice(List<InventoryAndPriceViewModel> inventoryAndPrices
            , List<ProductInventory> productInventories, Product product)
        {
            var itemsInDB = productInventories;
            if (productInventories != null && inventoryAndPrices != null)
            {
                foreach (var item in inventoryAndPrices)
                {
                    var myItem = productInventories.Where(p => p.ColorName == item.ColorName
                    && p.SizeName == item.SizeName
                    && p.ProductId == item.ProductId).FirstOrDefault();

                    if (myItem != null)
                    {
                        myItem.Price = item.Price;
                        myItem.Inventory = item.Inventory;
                        db.ProductInventories.Update(myItem);
                    }

                    else
                    {
                        await db.ProductInventories.AddAsync(new ProductInventory
                        {
                            Product = product,
                            Inventory = item.Inventory,
                            Price = item.Price,
                            ColorName = item.ColorName,
                            SizeName = item.SizeName,
                        });
                    }
                }
                foreach (var item in inventoryAndPrices)
                    if (itemsInDB.Any(p => p.ColorName == item.ColorName && p.SizeName == item.SizeName))
                        itemsInDB.Remove(itemsInDB.First(p => p.ColorName == item.ColorName && p.SizeName == item.SizeName));

                db.ProductInventories.RemoveRange(itemsInDB);
            }
        }
    }
}
