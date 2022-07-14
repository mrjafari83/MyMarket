using System.Linq;
using Persistance.Context;
using Common.Dto;
using Common.ViewModels;
using Common.Utilities;

namespace Application.Services.Admin.NewsBulletin.Queries.GetAllNews
{
    public class GetNewsService : IGetNewsService
    {
        private readonly IDataBaseContext db;
        public GetNewsService(IDataBaseContext context)
        {
            db = context;
        }

        public ResultDto<GetNewsDto> Execute(int pageNumber = 1, int pageSize = 10)
        {
            int totalRow = 0;
            var news = db.News.Select(n => new NewsViewModel
            {
                Id = n.Id,
                Subject = n.Subject,
                Text = n.Text,
            }).ToPaged(out totalRow, pageNumber, pageSize).ToList();

            if (news.Count() != 0)
                return new ResultDto<GetNewsDto>
                {
                    Data = new GetNewsDto { TotalRow = totalRow, News = news },
                    IsSuccess = true,
                };
            return new ResultDto<GetNewsDto>
            {
                IsSuccess = false,
                Data = null
            };
        }
    }
}
