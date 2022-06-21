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
using AutoMapper;

namespace Application.Services.Admin.Products.Commands.CreateProduct
{
    public class CreateProductService : ICreateProductService
    {
        private readonly IDataBaseContext db;
        private readonly IHostingEnvironment _environment;
        private readonly IMapper _mapper;
        public CreateProductService(IDataBaseContext context
            , IHostingEnvironment environment , IMapper mapper)
        {
            db = context;
            _environment = environment;
            _mapper = mapper;   
        }

        public ResultDto Execute(CreateProductServiceDto entry)
        {
            var product = _mapper.Map<ProductViewModel , Product>(entry.Product);

            SetColors(product, entry.Colors);
            SetSizes(product, entry.Sizes);

            //set product options in database
            db.ProductImages.AddRange(AddImages(product, entry.Images));
            db.ProductKeywords.AddRange(AddKeywords(product, entry.Keywords));
            db.ProductFutures.AddRange(AddFeature(product, entry.Features));
            SetInventoryAndPrice(product, entry.InventoryAndPrices);

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
                    Value = item.KeywordValue,
                    Parent = product,
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
                    Src = FileUploader.Upload(item, _environment, "Products/" + product.Name)
                });
            }

            return finallyImages;
        }

        private List<Domain.Entities.Products.ProductFeature> AddFeature(Product product, List<FeatureViewModel> features)
        {
            List<Domain.Entities.Products.ProductFeature> finallyFeatures = new List<Domain.Entities.Products.ProductFeature>();
            foreach (var item in features)
            {
                var feature = _mapper.Map<FeatureViewModel, Domain.Entities.Products.ProductFeature>(item);
                feature.Product = product;
                finallyFeatures.Add(feature);
            }
            return finallyFeatures;
        }

        private void SetColors(Product product, List<ColorViewModel> entrycolors)
        {
            if (entrycolors != null)
            {
                foreach (var item in entrycolors)
                {
                    var color = db.ProductColors.Where(c => c.Name == item.Name).FirstOrDefault();
                    if (color != null)
                        db.ColorsInProducts.Add(new ColorInProduct { Color = color, Product = product });

                    else
                    {
                        var newColor = db.ProductColors.Add(new ProductColor { Name = item.Name }).Entity;
                        db.ColorsInProducts.Add(new ColorInProduct { Color = newColor, Product = product });
                    }
                }
            }
        }

        private void SetSizes(Product product, List<SizeViewModel> entrySizes)
        {
            if (entrySizes != null)
            {
                foreach (var item in entrySizes)
                {
                    var size = db.ProductSizes.Where(c => c.SizeValue == item.SizeValue).FirstOrDefault();
                    if (size != null)
                        db.SizesInProducts.Add(new SizeInProduct { Size = size, Product = product });

                    else
                    {
                        var newSize = db.ProductSizes.Add(new ProductSize { SizeValue = item.SizeValue }).Entity;
                        db.SizesInProducts.Add(new SizeInProduct { Size = newSize, Product = product });
                    }
                }
            }
        }

        private void SetInventoryAndPrice(Product product , List<InventoryAndPriceViewModel> inventoryAndPrices)
        {
            if(inventoryAndPrices != null)
            {
                foreach(var item in inventoryAndPrices)
                {
                    var addingItem = _mapper.Map<InventoryAndPriceViewModel, ProductInventory>(item);
                    addingItem.Product = product;
                    db.ProductInventories.Add(addingItem);
                }
            }
        }
    }
}
