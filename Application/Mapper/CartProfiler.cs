using AutoMapper;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Domain.Entities.Cart;
using Application.Services.Admin.CartPaying.Queries.GetAllCartPayings;
using Application.Services.Client.Carts.Commands.AddProductToCart;
using Common.ViewModels;

namespace Application.Mapper
{
    public class CartProfiler : Profile
    {
        public CartProfiler()
        {
            CreateProjection<CartPayingInfo,GetAllCartPayingsDto>()
                .ForMember(d=> d.CartPayingId,i=> i.MapFrom(s=> s.Id));
            CreateMap<CartPayingViewModel ,CartPayingInfo>().ReverseMap();
            CreateMap<AddProductToCartDto, ProductInCart>()
                .ReverseMap();
        }
    }
}
