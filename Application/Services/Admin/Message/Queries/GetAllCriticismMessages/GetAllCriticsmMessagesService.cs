using System.Linq;
using Common.Dto;
using Common.ViewModels;
using Common.Utilities;
using Application.Interfaces.Context;

namespace Application.Services.Admin.Message.Queries.GetAllCriticismMessages
{
    public class GetAllCriticsmMessagesService : IGetAllCriticsmMessagesService
    {
        private readonly IDataBaseContext db;
        public GetAllCriticsmMessagesService(IDataBaseContext context)
        {
            db = context;
        }

        public ResultDto<GetAllCriticsmMessagesDto> Execute(int pageNumber = 1, int pageSize = 10)
        {
            int totalRows = 0;
            var messages = db.CriticismMessages.Select(m => new CriticismMessageViewModel
            {
                Name = m.Name,
                Email = m.Email,
                Website = m.Website,
                Message = m.Message
            }).ToPaged(out totalRows, pageNumber, pageSize).ToList();

            if (messages.Count() == 0)
                return new ResultDto<GetAllCriticsmMessagesDto>
                {
                    Data = null,
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
