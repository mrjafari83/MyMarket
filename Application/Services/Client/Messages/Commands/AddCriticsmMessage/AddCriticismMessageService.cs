using Common.Dto;
using Common.ViewModels;
using Application.Interfaces.Context;

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
            db.CriticismMessages.Add(new Domain.Entities.Message.CriticismMessage
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
