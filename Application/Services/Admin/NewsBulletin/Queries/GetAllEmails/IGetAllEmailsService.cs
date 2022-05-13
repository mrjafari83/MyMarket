using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;
using Common.Dto;

namespace Application.Services.Admin.NewsBulletin.Queries.GetAllEmails
{
    public  interface IGetAllEmailsService
    {
        ResultDto<GetEmailsDto> Execute(int pageNumber = 1, int pageSize = 10);
    }
}
