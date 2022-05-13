using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Application.Interfaces.FacadPatterns.Admin;
using Microsoft.AspNetCore.Http;
using Common.Utilities;
using Common.Utilities.MessageSender;
using Microsoft.AspNetCore.Hosting;

namespace Market.EndPoint.Areas.Admin.Controllers
{
    [Area("Admin")]
    public class NewsBulletinController : Controller
    {
        private readonly INewsBulletinFacad _newsBulletinFacad;
        private readonly IHostingEnvironment _hosting;
        private readonly IMessageSender _messageSender;
        public NewsBulletinController(INewsBulletinFacad newsBulletinFacad, IHostingEnvironment hosting
            , IMessageSender messageSender)
        {
            _newsBulletinFacad = newsBulletinFacad;
            _hosting = hosting;
            _messageSender = messageSender;
        }

        [HttpGet]
        public IActionResult News()
        {
            return View(_newsBulletinFacad.GetNews.Execute().Data);
        }

        [HttpGet]
        public IActionResult SendNews()
        {
            return View();
        }

        [HttpPost]
        public IActionResult SendNews(string subject, string text)
        {
            _newsBulletinFacad.SendNews.Execute(subject, text);

            //Send message with emails
            //var emails = _newsBulletinFacad.GetAllEmails.Execute().Data.Emails;
            //foreach (var item in emails)
            //    _messageSender.SendAsync(item, subject, text, true);

            return Json(true);
        }

        [HttpGet]
        public IActionResult AddEmail()
        {
            return View();
        }

        [HttpPost]
        public IActionResult AddEmail(string email)
        {
            _newsBulletinFacad.AddEmail.Execute(email);
            return Redirect("/Admin/NewsBulletin/News");
        }
    }
}
