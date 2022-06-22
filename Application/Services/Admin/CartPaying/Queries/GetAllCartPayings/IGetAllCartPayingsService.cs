using System;
using System.Text;
using System.Threading.Tasks;
using Common.Dto;

namespace Application.Services.Admin.CartPaying.Queries.GetAllCartPayings
{
    public interface IGetAllCartPayingsService
    {
        Task<ResultDto<ResultGetAllCartPayingsDto>> Execute(int pageNumber = 1 , int pageSize = 10 , bool sended = false);
    }
}
