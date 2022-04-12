using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Application.Services.Common.BlogPage.Queries.GetAllBlogPages;

namespace Application.Interfaces.FacadPatterns.Common
{
    public interface ICommonBlogPageFacad
    {
        IGetAllBlogPagesService GetAllBlogPages { get; }
    }
}
