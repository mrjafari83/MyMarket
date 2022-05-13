using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;
using Common.Dto;
using Common.ViewModels;

namespace Application.Services.Admin.NewsBulletin.Queries.GetNewsById
{
    public interface IGetNewsByIdService
    {
        ResultDto<NewsViewModel> Execute(int id);
    }
}
