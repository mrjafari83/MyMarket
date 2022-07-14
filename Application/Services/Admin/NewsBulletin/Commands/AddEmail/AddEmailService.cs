using Application.Common.Dto;
using Application.Persistance.Context;

namespace Application.Services.Admin.NewsBulletin.Commands.AddEmail
{
    public class AddEmailService : IAddEmailService
    {
        private readonly IDataBaseContext db;
        public AddEmailService(IDataBaseContext context)
        {
            db = context;
        }

        public ResultDto Execute(string email)
        {
            var result = db.Emails.Add(new Application.Persistance.Entities.NewsBulletin.Email
            {
                EmailAddress = email
            }).State;
            db.SaveChanges();

            if (result == Microsoft.EntityFrameworkCore.EntityState.Unchanged)
                return new ResultDto
                {
                    IsSuccess = true,
                    Message = "ایمیل با موفقیت اضافه شد."
                };
            return new ResultDto
            {
                IsSuccess = false,
                Message = "خطایی رخ داده است"
            };
        }
    }
}
