using System.Collections.Generic;
using System.Linq;
using Common.Dto;
using Common.Utilities;
using Persistance.Context;

namespace Application.Services.Admin.NewsBulletin.Queries.GetAllEmails
{
    public class GetAllEmailsService : IGetAllEmailsService
    {
        private readonly IDataBaseContext db;
        public GetAllEmailsService(IDataBaseContext context)
        {
            db = context;
        }

        public ResultDto<GetEmailsDto> Execute(int pageNumber = 1, int pageSize = 10)
        {
            int totalRow = 0;
            var emails = db.Emails.Select(e => e.EmailAddress).ToPaged(out totalRow, pageNumber, pageSize).ToList();

            if (emails.Count != 0)
                return new ResultDto<GetEmailsDto>
                {
                    IsSuccess = true,
                    Data = new GetEmailsDto { TotalRow = totalRow, Emails = emails },
                    Message = ""
                };

            return new ResultDto<GetEmailsDto>
            {
                IsSuccess = false,
                Data = null,
            };
        }
    }
}
