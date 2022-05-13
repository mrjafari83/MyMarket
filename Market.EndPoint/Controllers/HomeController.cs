using Market.EndPoint.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Threading.Tasks;
using Application.Interfaces.FacadPatterns.Common;

namespace Market.EndPoint.Controllers
{
    public class HomeController : Controller
    {
        private readonly ICommonProductFacad _commonProductFacad;
        public HomeController(ICommonProductFacad commonProductFacad)
        {
            _commonProductFacad = commonProductFacad;
        }

        public IActionResult Index()
        {
            return View();
        }

        [Route("ContactUs")]
        public IActionResult ContactUs()
        {
            return View();
        }
    }
}
