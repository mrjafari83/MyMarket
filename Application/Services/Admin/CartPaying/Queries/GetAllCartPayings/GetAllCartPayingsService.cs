using System.Linq;
using System.Collections.Generic;
using Application.Interfaces.Context;
using Common.Dto;
using Common.Utilities;
using Domain.Entities.Cart;
using Microsoft.EntityFrameworkCore;
using AutoMapper;

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

        public ResultDto<ResultGetAllCartPayingsDto> Execute(int pageNumber = 1, int pageSize = 10, bool sended = false)
        {
            int totalRows = 0;
            var cartPayings = _mapper.Map<List<GetAllCartPayingsDto>>(db.CartPayings.Where(c => c.IsPayed));

            if (sended)
                cartPayings = cartPayings.Where(c => c.Sended).ToList();

            if (cartPayings.Any())
                return new ResultDto<ResultGetAllCartPayingsDto>
                {
                    Data = new ResultGetAllCartPayingsDto
                    {
                        CartPayings = cartPayings.OrderByDescending(c => c.CartPayingId).ToPaged(out totalRows, pageNumber, pageSize).ToList(),
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
