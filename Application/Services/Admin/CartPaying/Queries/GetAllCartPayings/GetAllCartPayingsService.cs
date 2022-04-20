using System.Linq;
using System.Collections.Generic;
using Application.Interfaces.Context;
using Common.Dto;
using Common.Utilities;
using Domain.Entities.Cart;
using Microsoft.EntityFrameworkCore;

namespace Application.Services.Admin.CartPaying.Queries.GetAllCartPayings
{
    public class GetAllCartPayingsService : IGetAllCartPayingsService
    {
        private readonly IDataBaseContext db;
        public GetAllCartPayingsService(IDataBaseContext context)
        {
            db = context;
        }

        public ResultDto<ResultGetAllCartPayingsDto> Execute(int pageNumber = 1, int pageSize = 10, bool sended = false)
        {
            int totalRows = 0;
            var cartPayings = db.CartPayings.Include(c => c.Products).ThenInclude(c => c.Product).Where(c=> c.IsPayed).Select(c => new GetAllCartPayingsDto
            {
                CartId = c.Cart.Id,
                CartPayingId = c.Id,
                Name = c.Name,
                Family = c.Family,
                Email = c.Email,
                PhoneNumber = c.PhoneNumber,
                Sended = c.Sended
            }).OrderByDescending(c=> c.CartPayingId).AsQueryable();

            if (sended)
                cartPayings = cartPayings.Where(c => c.Sended);

            if (cartPayings.Any())
                return new ResultDto<ResultGetAllCartPayingsDto>
                {
                    Data = new ResultGetAllCartPayingsDto
                    {
                        CartPayings = cartPayings.ToPaged(out totalRows, pageNumber, pageSize).ToList(),
                        TotalRows = totalRows
                    },
                    IsSuccess = true,
                    Message = ""
                };
            return new ResultDto<ResultGetAllCartPayingsDto>
            {
                Data = null,
                IsSuccess = false
            };
        }
    }
}
