using Market.EndPoint.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Threading.Tasks;
using Application.Interfaces.FacadPatterns.Common;
using Application.Interfaces.FacadPatterns.Client;
using Common.ViewModels;
using Market.EndPoint.Utilities;
using System.IO;

namespace Market.EndPoint.Controllers
{
    public class HomeController : Controller
    {
        private readonly ICommonProductFacad _commonProductFacad;
        private readonly IClientMessageFacad _clientMessageFacad;
        public HomeController(ICommonProductFacad commonProductFacad , IClientMessageFacad clientMessageFacad)
        {
            _commonProductFacad = commonProductFacad;
            _clientMessageFacad = clientMessageFacad;
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

        [Route("SendCriticism")]
        [HttpPost]
        public IActionResult SendCriticism(CriticismMessageViewModel model)
        {
            _clientMessageFacad.AddCriticismMessage.Execute(model);
            return Redirect("/ContactUs");
        }
    }
}
