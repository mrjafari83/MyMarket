using System.Collections.Generic;
using Common.ViewModels;

namespace Application.Services.Admin.NewsBulletin.Queries.GetAllNews
{
    public class GetNewsDto
    {
        public int TotalRow { get; set; }
        public List<NewsViewModel> News { get; set; }
    }
}
