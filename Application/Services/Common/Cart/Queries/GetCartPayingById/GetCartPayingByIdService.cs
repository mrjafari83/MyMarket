﻿using System.Linq;
using Application.Interfaces.Context;
using Common.Dto;
using Application.Services.Admin.CartPaying.Queries.GetProductsOfCartPaying;

namespace Application.Services.Common.Cart.Queries.GetCartPayingById
{
    public class GetCartPayingByIdService : IGetCartPayingByIdService
    {
        private readonly IDataBaseContext db;
        public GetCartPayingByIdService(IDataBaseContext context)
        {
            db = context;
        }

        public ResultDto<GetCartPayingByIdDto> Execute(int id)
        {
            var products = new GetProductsOfCartPayingService(db).Execute(id).Data;

            var cartPaying = db.CartPayings.Where(c => c.Id == id).Select(c => new GetCartPayingByIdDto
            {
                Id = c.Id,
                Name = c.Name,
                Family = c.Family,
                Email = c.Email,
                PhoneNymber = c.PhoneNumber,
                Address = c.Address,
                PostalCode = c.PostalCode,
                Sended = c.Sended,
                Products = products
            }).FirstOrDefault();

            if (cartPaying == null)
                return new ResultDto<GetCartPayingByIdDto>
                {
                    Data = null,
                    IsSuccess = false
                };
            return new ResultDto<GetCartPayingByIdDto>
            {
                Data = cartPaying,
                IsSuccess = true
            };
        }
    }
}