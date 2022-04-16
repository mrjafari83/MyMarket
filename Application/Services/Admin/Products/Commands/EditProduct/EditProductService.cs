using Application.Interfaces.Context;
using Common.Dto;
using Common.ViewModels;
using Domain.Entities.Common;
using Domain.Entities.Products;
using Domain.Entities.Products.Relations;
using Microsoft.EntityFrameworkCore;
using System.Collections.Generic;
using System.Linq;
using Common.Utilities;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Http;

namespace Application.Services.Admin.Products.Commands.EditProduct
{
    public class EditProductService : IEditProductService
    {
        private readonly IDataBaseContext db;
        private readonly IHostingEnvironment _environment;
        public EditProductService(IDataBaseContext context , IHostingEnvironment environment)
        {
            db = context;
            _environment = environment;
        }

        public ResultDto Execute(EditProductDto entry)
        {
            var product = db.Products.Include(p => p.Keywords).Include(p => p.Images).Include(p => p.Colors).ThenInclude(c => c.Color)
                .Include(p => p.Sizes).ThenInclude(s=> s.Size).Include(p => p.Features).Where(p => p.Id == entry.Id).FirstOrDefault();

            product.Name = entry.Name;
            product.Brand = entry.Brand;
            product.Inventory = entry.Inventory;
            product.Description = entry.Description;
            product.Price = entry.Price;
            product.ShortDescription = entry.ShortDescription;

            if (entry.CategoryId != 0)
            {
                product.CategoryId = entry.CategoryId;
                product.Category = db.ProductCategories.Find(entry.CategoryId);
            }
            DeleteImages(product.Images.ToList());

            List<ProductColor> colors = product.Colors.Select(c => new ProductColor { Id = c.Color.Id, Name = c.Color.Name }).ToList();
            AddColors(product, entry.Colors, colors);
            DeleteColors(entry.Colors, colors, product);

            List<ProductSize> sizes = product.Sizes.Select(s => new ProductSize { Id = s.Size.Id, Value = s.Size.Value }).ToList();
            AddSizes(product, entry.Sizes, sizes);
            DeleteSizes(product, entry.Sizes, sizes);

            AddKeywords(product, entry.Keywords, product.Keywords.ToList());
            AddFeaturs(product, entry.Features, product.Features.ToList());
            AddImages(product, entry.Images);

            DeleteKeywords(entry.Keywords, product.Keywords.ToList());
            DeleteFeatures(entry.Features, product.Features.ToList());

            db.Products.Update(product);
            db.SaveChanges();

            return new ResultDto
            {
                IsSuccess = true,
                Message = "محصول ویرایش شد."
            };
        }

        private void AddKeywords(Product product, List<KeywordViewModel> keywords, List<Keyword<Product>> productKeywords)
        {
            foreach (var item in keywords)
            {
                if (productKeywords.Where(k => k.Value == item.KeywordValue).ToList().Count() != 0)
                    continue;

                db.ProductKeywords.Add(new Keyword<Product> { Value = item.KeywordValue, Parent = product });
            }
        }

        private void DeleteKeywords(List<KeywordViewModel> keywords, List<Keyword<Product>> productKeywords)
        {
            foreach (var item in productKeywords)
            {
                if (keywords.Where(k => k.KeywordValue == item.Value).Count() == 0)
                {
                    var keyword = db.ProductKeywords.Find(item.Id);
                    keyword.IsRemoved = true;
                    keyword.RemoveTime = System.DateTime.Now;
                    db.ProductKeywords.Update(keyword);
                }
            }
        }

        private void AddFeaturs(Product product, List<FeatureViewModel> features, List<Domain.Entities.Products.ProductFeature> productFeatures)
        {
            foreach (var item in features)
            {
                if (productFeatures.Where(k => k.Display == item.Display && k.Value == item.FeatureValue).ToList().Count() != 0)
                    continue;

                db.ProductFutures.Add(new Domain.Entities.Products.ProductFeature
                {
                    Display = item.Display,
                    Value = item.FeatureValue,
                    Product = product
                });
            }
        }

        private void DeleteFeatures(List<FeatureViewModel> features, List<Domain.Entities.Products.ProductFeature> productFeatures)
        {
            foreach (var item in productFeatures)
            {
                if (features.Where(k => k.Display == item.Display && k.FeatureValue == item.Value).Count() == 0)
                {
                    var feature = db.ProductFutures.Find(item.Id);
                    feature.IsRemoved = true;
                    feature.RemoveTime = System.DateTime.Now;
                    db.ProductFutures.Update(feature);
                }
            }
        }

        private void AddColors(Product product, List<ColorViewModel> colors, List<ProductColor> productColors)
        {
            foreach (var item in colors)
            {
                if (productColors.Where(c => c.Name == item.Name).ToList().Count() != 0)
                {
                    var dbColor = db.ProductColors.Where(c => c.Name == item.Name).FirstOrDefault();
                    db.ColorsInProducts.Add(new ColorInProduct { Color = dbColor, Product = product });
                    continue;
                }
                    
                var color = db.ProductColors.Add(new ProductColor { Name = item.Name});
                db.ColorsInProducts.Add(new ColorInProduct { Product = product, Color = color.Entity });
            }
        }

        private void DeleteColors(List<ColorViewModel> colors, List<ProductColor> productColors, Product product)
        {
            foreach (var item in productColors)
            {
                if (colors.Where(c => c.Name == item.Name).Count() == 0)
                {
                    var color = db.ProductColors.Find(item.Id);
                    color.IsRemoved = true;
                    color.RemoveTime = System.DateTime.Now;
                    db.ProductColors.Update(color);

                    var relation = db.ColorsInProducts.Where(c => c.Color == color && c.Product == product).FirstOrDefault();
                    relation.IsRemoved = true;
                    relation.RemoveTime = System.DateTime.Now;
                    db.ColorsInProducts.Update(relation);
                }
            }
        }

        private void AddSizes(Product product, List<SizeViewModel> sizes, List<ProductSize> productSizes)
        {
            foreach (var item in sizes)
            {
                if (productSizes.Where(s=> s.Value == item.SizeValue).ToList().Count() != 0)
                {
                    var dbSize = db.ProductSizes.Where(s => s.Value == item.SizeValue).FirstOrDefault();
                    db.SizesInProducts.Add(new SizeInProduct
                    {
                        Product = product,
                        Size = dbSize
                    });
                    continue;
                }
                    
                var size = db.ProductSizes.Add(new ProductSize {Value = item.SizeValue });
                db.SizesInProducts.Add(new SizeInProduct { Product = product, Size = size.Entity });
            }
        }

        private void DeleteSizes(Product product , List<SizeViewModel> sizes, List<ProductSize> productSizes)
        {
            foreach (var item in productSizes)
            {
                if (sizes.Where(s=> s.SizeValue == item.Value).Count() == 0)
                {
                    var size = db.ProductSizes.Find(item.Id);
                    size.IsRemoved = true;
                    size.RemoveTime = System.DateTime.Now;
                    db.ProductSizes.Update(size);

                    var relation = db.SizesInProducts.Where(s=> s.Size == size && s.Product == product).FirstOrDefault();
                    relation.IsRemoved = true;
                    relation.RemoveTime = System.DateTime.Now;
                    db.SizesInProducts.Update(relation);
                }
            }
        }

        private void AddImages(Product product, List<IFormFile> images)
        {
            if(images != null)
                foreach (var item in images)
                {
                    db.ProductImages.Add(new ProductImage
                    {
                        Product = product,
                        Src = FileUploader.Upload(item, _environment, "products/" + product.Name)
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
    }
}
