using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Application.Interfaces.FacadPatterns.Admin;

namespace Market.EndPoint.Controllers
{
    public class NewsController : Controller
    {
        private readonly INewsBulletinFacad _newsBulletinFacad;
        public NewsController(INewsBulletinFacad newsBulletinFacad)
        {
            _newsBulletinFacad = newsBulletinFacad;
        }

        [HttpPost]
        public IActionResult AddEmail(string email)
        {
            _newsBulletinFacad.AddEmail.Execute(email);

            return Redirect("/");
        }
    }
}
