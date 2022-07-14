using AutoMapper;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Persistance.Entities.Products;
using Persistance.Entities.Products.Relations;
using Common.ViewModels;
using Application.Services.Admin.Products.Queries.GetAllProducts;
using Persistance.Entities.Categories;
using Application.Services.Admin.Products.Queries.GetBestSellingProducts;
using Application.Services.Admin.Products.Queries.GetProductById;
using Application.Services.Admin.CartPaying.Queries.GetProductsOfCartPaying;
using Application.Services.Client.Carts.Queries.GetUserCart;
using Common.Utilities;
using Persistance.Entities.Cart;

namespace Application.Mapper
{
    public class ProductProfiler : Profile
    {
        public ProductProfiler()
        {
            CreateMap<ProductViewModel, Product>().ReverseMap();
            CreateMap<FeatureViewModel, ProductFeature>().ReverseMap();
            CreateMap<ColorViewModel, ProductColor>().ReverseMap();
            CreateMap<SizeViewModel, ProductSize>().ReverseMap();
            CreateMap<InventoryAndPriceViewModel, ProductInventory>().ReverseMap();
            CreateMap<InventoryAndPriceViewModelCreate, ProductInventory>().ReverseMap();
            CreateProjection<Product, GetAllProductDto>().ForMember(dest => dest.CategoryName, i => i.MapFrom(src => src.Category.Name))
                .ForMember(dest => dest.VisitNumber, i => i.MapFrom(src => src.Visits.Count()));
            CreateProjection<ProductInventory, GetBestSellingDto>()
                .ForMember(d => d.SellingCount, i => i.MapFrom(s => s.ProductInCarts.Sum(c => c.Count)))
                .ForMember(d => d.ImageSrc, i => i.MapFrom(s => s.Product.Images.FirstOrDefault().Src))
                .ForMember(d => d.Name, i => i.MapFrom(s => s.Product.Name));
            CreateProjection<ProductInCart, ProductInCartPayingDto>()
                .ForMember(d => d.ImageSrc, i => i.MapFrom(s => s.Product.Images.FirstOrDefault().Src))
                .ForMember(d => d.Brand, i => i.MapFrom(s => s.Product.Brand))
                .ForMember(d => d.Name, i => i.MapFrom(s => s.Product.Name))
                .ForMember(d => d.Id, i => i.MapFrom(s => s.Product.Id))
                .ForMember(d => d.Price, i => i.MapFrom(s => s.Product.Inventories.FirstOrDefault(k => k.ProductId == s.Product.Id && (k.ColorName == s.Color || k.ColorName == null) && (k.SizeName == s.Size || k.SizeName == null)).Price));
            CreateProjection<ProductInCart, CartProductDto>()
                .ForMember(d => d.Id, i => i.MapFrom(s => s.ProductId))
                .ForMember(d => d.Name, i => i.MapFrom(s => s.Product.Name))
                .ForMember(d => d.Price, i => i.MapFrom(s => s.ProductInventoryAndPrice.Price == null ? 0 : s.ProductInventoryAndPrice.Price))
                .ForMember(d => d.Image, i => i.MapFrom(s => s.Product.Images.FirstOrDefault().Src))
                .ForMember(d => d.ProductInventory, i => i.MapFrom(s => s.ProductInventoryAndPrice.Inventory == null ? 0 : s.ProductInventoryAndPrice.Inventory))
                .ForMember(d => d.ProductInCartId, i => i.MapFrom(s => s.Id));

            GetByIdMapper();

        }

        private void GetByIdMapper()
        {
            var config = new MapperConfiguration(cfg =>
            {
                cfg.CreateMap<FeatureViewModel, ProductFeature>().ReverseMap();
                cfg.CreateMap<ColorViewModel, ProductColor>().ReverseMap();
                cfg.CreateMap<SizeViewModel, ProductSize>().ReverseMap();
                cfg.CreateMap<ProductInventory, InventoryAndPriceViewModel>().ReverseMap();
            });
            var mapper = config.CreateMapper();

            CreateMap<Product, GetProductByIdDto>().ForMember(d => d.CategoryName, i => i.MapFrom(s => s.Category.Name))
                .ForMember(d => d.VisitNumber, i => i.MapFrom(s => s.Visits.Count()))
                .ForMember(d => d.CreateDate, i => i.MapFrom(s => s.CreateDate.ToShamsi()))
                .ForMember(d => d.Colors, i => i.MapFrom(s => mapper.Map<List<ColorViewModel>>(s.Colors.Select(k => k.Color))))
                .ForMember(d => d.Features, i => i.MapFrom(s => mapper.Map<List<FeatureViewModel>>(s.Features)))
                .ForMember(d => d.Sizes, i => i.MapFrom(s => mapper.Map<List<SizeViewModel>>(s.Sizes.Select(k => k.Size))))
                .ForMember(d => d.InventoryAndPrices, i => i.MapFrom(s => mapper.Map<List<InventoryAndPriceViewModel>>(s.Inventories)))
                .ForMember(d => d.Keywords, i => i.MapFrom(s => s.Keywords.Select(k => new KeywordViewModel { KeywordValue = k.Value }).ToList()))
                .ReverseMap();
        }
    }
}
