using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.Services.Admin.NewsBulletin.Queries.GetAllEmails
{
    public class GetEmailsDto
    {
        public int TotalRow { get; set; }
        public List<string> Emails { get; set; }
    }
}
