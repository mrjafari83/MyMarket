using Application.Services.Admin.Products.Commands.CreateProduct;
using AutoMapper;
using EndPoint.Api.ViewModels.Products;

namespace EndPoint.Api.MapperProfile
{
    public class ProductProfile : Profile
    {
        public ProductProfile()
        {
            CreateMap<CreateProductViewModel, CreateProductServiceDto>().ReverseMap();
            CreateMap<Common.ViewModels.ProducsSearchViewModel, SearchViewModel>().ReverseMap();
        }
    }
}
