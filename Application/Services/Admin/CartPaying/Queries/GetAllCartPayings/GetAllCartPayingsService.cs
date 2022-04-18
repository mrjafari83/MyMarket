using System.Linq;
using Application.Interfaces.Context;
using Common.Dto;
using Common.Utilities;

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
            var cartPayings = db.CartPayings.Select(c => new GetAllCartPayingsDto
            {
                Name = c.Name,
                Family = c.Family,
                Email = c.Email,
                PhoneNumber = c.PhoneNumber,
                Sended = c.Sended
            }).AsQueryable();

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
