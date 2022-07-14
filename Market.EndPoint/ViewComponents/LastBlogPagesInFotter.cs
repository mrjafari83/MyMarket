using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Application.Interfaces.FacadPatterns.Common;
using Application.Common.ViewModels.SearchViewModels;

namespace Market.EndPoint.ViewComponents
{
    public class LastBlogPagesInFotter : ViewComponent
    {
        private readonly ICommonBlogPageFacad _commonBlogPageFacad;
        public LastBlogPagesInFotter(ICommonBlogPageFacad commonBlogPageFacad)
        {
            _commonBlogPageFacad = commonBlogPageFacad;
        }

        public IViewComponentResult Invoke()
        {
            return View("LastBlogPagesInFotter" , _commonBlogPageFacad.GetAllBlogPages.Execute(new BlogPageSearchViewModel { OrderBy =  Application.Common.Enums.Enums.BlogPagesFilter.Newest} ,1 , 2).Result.Data);
        }
    }
}
