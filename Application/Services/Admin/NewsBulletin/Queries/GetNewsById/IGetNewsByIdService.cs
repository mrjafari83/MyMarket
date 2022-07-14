using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;
using Application.Common.Dto;
using Application.Common.ViewModels;

namespace Application.Services.Admin.NewsBulletin.Queries.GetNewsById
{
    public interface IGetNewsByIdService
    {
        ResultDto<NewsViewModel> Execute(int id);
    }
}
