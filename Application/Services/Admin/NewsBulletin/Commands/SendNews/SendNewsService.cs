using Common.Dto;
using Persistance.Context;

namespace Application.Services.Admin.NewsBulletin.Commands.SendNews
{
    public class SendNewsService : ISendNewsService
    {
        private readonly IDataBaseContext db;
        public SendNewsService(IDataBaseContext context)
        {
            db = context;
        }

        public ResultDto Execute(string subject, string text)
        {
            db.News.Add(new Persistance.Entities.NewsBulletin.News
            {
                Subject = subject,
                Text = text,
            });
            db.SaveChanges();

            return new ResultDto
            {
                IsSuccess = true,
                Message = "این خبر به ایمیل ها ارسال شد."
            };
        }
    }
}
