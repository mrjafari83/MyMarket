﻿using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Application.Interfaces.FacadPatterns.Admin;
using Microsoft.AspNetCore.Authorization;

namespace Market.EndPoint.Areas.Admin.Controllers
{
    [Area("Admin")]
    [Authorize(Roles = "Admin,Owner")]
    public class MessagesController : Controller
    {
        private readonly IMessageFacad _messageFacad;
        public MessagesController(IMessageFacad messageFacad)
        {
            _messageFacad = messageFacad;
        }

        public IActionResult Criticism(int currentPage = 1)
        {
            ViewBag.CurrentRow = currentPage;

            return View(_messageFacad.GetAllCriticsmMessages.Execute(currentPage).Data);
        }
    }
}
