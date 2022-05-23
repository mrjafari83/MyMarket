using System;
using System.Linq;
using System.Collections.Generic;
using Common.Dto;
using Common.Utilities;
using Common.ViewModels;
using Application.Interfaces.Context;
using Application.Interfaces.FacadPatterns.Admin;
using Domain.Entities.Products;
using Domain.Entities.Products.Relations;
using Domain.Entities.Common;
using Application.Services.Admin.Keyword.Commands.CreateKeyword;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Http;

namespace Application.Services.Admin.Products.Commands.CreateProduct
{
    public class CreateProductService : ICreateProductService
    {
        private readonly IDataBaseContext db;
        private readonly IHostingEnvironment _environment;
        public CreateProductService(IDataBaseContext context
            , IHostingEnvironment environment)
        {
            db = context;
            _environment = environment;
        }

        public ResultDto Execute(CreateProductServiceDto entry)
        {
            var product = new Product()
            {
                Name = entry.Name,
                Brand = entry.Brand,
                Description = entry.Description,
                ShortDescription = entry.ShortDescription,
                Inventory = entry.Inventory,
                Price = entry.Price,
                CreateDate = DateTime.Now,
                CategoryId = entry.CategoryId,
                Category = db.ProductCategories.Find(entry.CategoryId)
            };

            SetColors(product, entry.Colors);
            SetSizes(product, entry.Sizes);

            //set product options in database
            db.ProductImages.AddRange(AddImages(product, entry.Images));
            db.ProductKeywords.AddRange(AddKeywords(product, entry.Keywords));
            db.ProductFutures.AddRange(AddFeature(product, entry.Features));

            db.Products.Add(product);

            db.SaveChanges();
            return new ResultDto
            {
                IsSuccess = true,
                Message = "محصول با موفقیت اضافه شد."
            };
        }

        private List<Keyword<Product>> AddKeywords(Product product, List<KeywordViewModel> keywords)
        {
            List<Keyword<Product>> finallykeywords = new List<Keyword<Product>>();
            foreach (var item in keywords)
            {
                finallykeywords.Add(new Keyword<Product>
                {
                    Parent = product,
                    Value = item.KeywordValue
                });
            }

            return finallykeywords;
        }

        private List<ProductImage> AddImages(Product product, List<IFormFile> images)
        {
            List<ProductImage> finallyImages = new List<ProductImage>();
            foreach (var item in images)
            {
                finallyImages.Add(new ProductImage
                {
                    Product = product,
                    Src = FileUploader.Upload(item, _environment , "Products/" + product.Name)
                });
            }

            return finallyImages;
        }

        private List<Domain.Entities.Products.ProductFeature> AddFeature(Product product, List<FeatureViewModel> features)
        {
            List<Domain.Entities.Products.ProductFeature> finallyFeatures = new List<Domain.Entities.Products.ProductFeature>();
            foreach (var item in features)
                finallyFeatures.Add(new Domain.Entities.Products.ProductFeature
                {
                    Display = item.Display,
                    Value = item.FeatureValue,
                    Product = product
                });

            return finallyFeatures;
        }

        private void SetColors(Product product, List<ColorViewModel> entrycolors)
        {
            if (entrycolors != null)
            {
                foreach (var item in entrycolors)
                {
                    if(db.ProductColors.Where(c=> c.Name == item.Name).Count() == 0)
                    {
                        var color = db.ProductColors.Add(new ProductColor { Name = item.Name });
                        db.ColorsInProducts.Add(new ColorInProduct
                        {
                            Product = product,
                            Color = color.Entity
                        });
                    }
                    else
                    {
                        var dbColor = db.ProductColors.Where(c => c.Name == item.Name).FirstOrDefault();
                        db.ColorsInProducts.Add(new ColorInProduct { Color = dbColor, Product = product });
                    }
                }
            }
        }

        private void SetSizes(Product product, List<SizeViewModel> entrySizes)
        {
            if(entrySizes != null)
            {
                foreach(var item in entrySizes)
                {
                    if(db.ProductSizes.Where(s=> s.Value == item.SizeValue).Count() == 0)
                    {
                        var size = db.ProductSizes.Add(new ProductSize { Value = item.SizeValue });
                        db.SizesInProducts.Add(new SizeInProduct
                        {
                            Size = size.Entity,
                            Product = product
                        });
                    }
                    else
                    {
                        var size = db.ProductSizes.Where(s => s.Value == item.SizeValue).FirstOrDefault();
                        db.SizesInProducts.Add(new SizeInProduct
                        {
                            Product = product,
                            Size = size
                        });
                    }
                }
            }
        }
    }
}
