using System.Linq;
using Application.Interfaces.Context;
using AutoMapper;
using Common.Dto;
using Common.Utilities;
using Common.ViewModels;
using Microsoft.EntityFrameworkCore;

namespace Application.Services.Admin.Products.Queries.GetProductById
{
    public class GetProductByIdService : IGetProductByIdService
    {
        private readonly IDataBaseContext db;
        private readonly IMapper _mapper;
        public GetProductByIdService(IDataBaseContext context, IMapper mapper)
        {
            db = context;
            _mapper = mapper;
        }

        public ResultDto<GetProductByIdDto> Execute(int id)
        {
            var product = _mapper.Map<GetProductByIdDto>(db.Products.Include(p => p.Features).Include(p => p.Keywords).Include(p => p.Inventories)
                .Include(p => p.Colors).ThenInclude(c => c.Color).Include(p => p.Sizes).ThenInclude(p => p.Size).Where(p => p.Id == id).FirstOrDefault());

            if (product != null)
                return new ResultDto<GetProductByIdDto>
                {
                    Data = product,
                    IsSuccess = true
                };
            else
                return new ResultDto<GetProductByIdDto>
                {
                    Data = null,
                    IsSuccess = false
                };
        }
    }
}
