using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Application.Interfaces.FacadPatterns.Common;
using Common.Enums;

namespace Market.EndPoint.ViewComponents
{
    public class NewestBlogPaes : ViewComponent
    {
        private readonly ICommonBlogPageFacad _commonBlogPageFacad;
        public NewestBlogPaes(ICommonBlogPageFacad commonBlogPageFacad)
        {
            _commonBlogPageFacad = commonBlogPageFacad;
        }

        public IViewComponentResult Invoke()
        {
            return View(viewName: "NewestBlogPaes" , _commonBlogPageFacad.GetAllBlogPages.Execute(Enums.PagesFilter.Newest , 1 , 6).Result.Data);
        }
    }
}
