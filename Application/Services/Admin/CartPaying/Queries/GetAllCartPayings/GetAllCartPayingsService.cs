using System.Linq;
using System.Collections.Generic;
using Application.Interfaces.Context;
using Common.Dto;
using Common.Utilities;
using Domain.Entities.Cart;
using Microsoft.EntityFrameworkCore;
using AutoMapper;
using System.Threading.Tasks;

namespace Application.Services.Admin.CartPaying.Queries.GetAllCartPayings
{
    public class GetAllCartPayingsService : IGetAllCartPayingsService
    {
        private readonly IDataBaseContext db;
        private readonly IMapper _mapper;
        public GetAllCartPayingsService(IDataBaseContext context , IMapper mapper)
        {
            db = context;
            _mapper = mapper;
        }

        public async Task<ResultDto<ResultGetAllCartPayingsDto>> Execute(int pageNumber = 1, int pageSize = 10, bool sended = false)
        {
            int totalRows = 0;
            var cartPayings = _mapper.ProjectTo<GetAllCartPayingsDto>(db.CartPayings.Where(c => c.IsPayed));

            if (sended)
                cartPayings = cartPayings.Where(c => c.Sended);

            if (cartPayings.Any())
                return new ResultDto<ResultGetAllCartPayingsDto>
                {
                    Data = new ResultGetAllCartPayingsDto
                    {
                        CartPayings = await cartPayings.OrderByDescending(c => c.CartPayingId).ToPaged(out totalRows, pageNumber, pageSize).AsNoTracking().ToListAsync(),
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
