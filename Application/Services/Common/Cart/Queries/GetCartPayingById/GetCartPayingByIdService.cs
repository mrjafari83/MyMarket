using System.Linq;
using Application.Persistance.Context;
using Application.Common.Dto;
using Application.Services.Admin.CartPaying.Queries.GetProductsOfCartPaying;
using AutoMapper;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;

namespace Application.Services.Common.Cart.Queries.GetCartPayingById
{
    public class GetCartPayingByIdService : IGetCartPayingByIdService
    {
        private readonly IDataBaseContext db;
        private readonly IMapper _mapper;
        public GetCartPayingByIdService(IDataBaseContext context , IMapper mapper)
        {
            db = context;
            _mapper = mapper;
        }

        public async Task<ResultDto<GetCartPayingByIdDto>> Execute(int id)
        {
            var service = new GetProductsOfCartPayingService(db, _mapper);
            var products = await service.Execute(id);

            var cartPaying = await db.CartPayings.Where(c => c.Id == id).Select(c => new GetCartPayingByIdDto
            {
                Id = c.Id,
                Name = c.Name,
                Family = c.Family,
                Email = c.Email,
                PhoneNymber = c.PhoneNumber,
                Address = c.Address,
                PostalCode = c.PostalCode,
                Sended = c.Sended,
                Products = products.Data
            }).FirstOrDefaultAsync();

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
