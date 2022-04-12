using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Application.Services.Client.BlogPages.Queries.GetBlogPageById;

namespace Application.Interfaces.FacadPatterns.Client
{
    public interface IClientBlogPageFacad
    {
        IGetBlogPageByIdService GetBlogPageByIdService { get; }
    }
}
