using Application.Common.Dto;
using Application.Common.ViewModels;
using Application.Persistance.Context;

namespace Application.Services.Client.Messages.Commands.AddCriticsmMessage
{
    public class AddCriticismMessageService : IAddCriticismMessageService
    {
        private readonly IDataBaseContext db;
        public AddCriticismMessageService(IDataBaseContext context)
        {
            db = context;
        }

        public ResultDto Execute(CriticismMessageViewModel message)
        {
            db.CriticismMessages.Add(new Application.Persistance.Entities.Message.CriticismMessage
            {
                Name = message.Name,
                Email = message.Email,
                Website = message.Website,
                Message = message.Message
            });
            db.SaveChanges();

            return new ResultDto
            {
                IsSuccess = true,
            };
        }
    }
}
