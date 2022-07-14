using System.Linq;
using Application.Common.Dto;
using Application.Common.ViewModels;
using Application.Common.Utilities;
using Application.Persistance.Context;
using Microsoft.EntityFrameworkCore;
using System.Threading.Tasks;
using Application.Common.ViewModels.SearchViewModels;

namespace Application.Services.Admin.Message.Queries.GetAllCriticismMessages
{
    public class GetAllCriticsmMessagesService : IGetAllCriticsmMessagesService
    {
        private readonly IDataBaseContext db;
        public GetAllCriticsmMessagesService(IDataBaseContext context)
        {
            db = context;
        }

        public async Task<ResultDto<GetAllCriticsmMessagesDto>> Execute(MessageSearchViewModel searchModel , int pageNumber = 1, int pageSize = 10)
        {
            int totalRows = 0;
            var messages = await GetMessagesBySearch.GetMessagesBySearch.GetMessages(db,searchModel).Select(m => new CriticismMessageViewModel
            {
                Name = m.Name,
                Email = m.Email,
                Website = m.Website,
                Message = m.Message
            }).ToPaged(out totalRows, pageNumber, pageSize).ToListAsync();

            if (messages.Count() == 0)
                return new ResultDto<GetAllCriticsmMessagesDto>
                {
                    Data = new GetAllCriticsmMessagesDto(),
                    IsSuccess = false
                };
            return new ResultDto<GetAllCriticsmMessagesDto>
            {
                Data = new GetAllCriticsmMessagesDto
                {
                    TotalRows = totalRows,
                    Messages = messages
                },
                IsSuccess = true
            };
        }
    }
}
