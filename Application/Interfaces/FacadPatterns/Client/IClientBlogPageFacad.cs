using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Application.Services.Client.BlogPages.Queries.GetBlogPageById;
using Application.Services.Client.BlogPages.Commands.AddNewVisit;

namespace Application.Interfaces.FacadPatterns.Client
{
    public interface IClientBlogPageFacad
    {
        IGetBlogPageByIdService GetBlogPageByIdService { get; }
        IAddNewVisitService AddNewVisit { get; }
    }
}
