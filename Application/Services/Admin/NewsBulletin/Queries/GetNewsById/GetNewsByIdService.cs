using System.Linq;
using Application.Common.Dto;
using Application.Common.ViewModels;
using Application.Persistance.Context;

namespace Application.Services.Admin.NewsBulletin.Queries.GetNewsById
{
    public class GetNewsByIdService : IGetNewsByIdService
    {
        private readonly IDataBaseContext db;
        public GetNewsByIdService(IDataBaseContext context)
        {
            db = context;
        }

        public ResultDto<NewsViewModel> Execute(int id)
        {
            var news = db.News.Where(n => n.Id == id).Select(n => new NewsViewModel
            {
                Id = n.Id,
                Subject = n.Subject,
                Text = n.Text
            }).FirstOrDefault();

            if (news != null)
                return new ResultDto<NewsViewModel>
                {
                    Data = news,
                    IsSuccess = true
                };
            return new ResultDto<NewsViewModel>
            {
                IsSuccess = false,
            };
        }
    }
}
