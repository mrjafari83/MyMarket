﻿using Application.Interfaces.FacadPatterns.Admin;
using Common.Utilities;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using System;
using System.IO;

namespace Market.EndPoint.Areas.Admin.Controllers
{
    [Area("Admin")]
    public class ReportController : Controller
    {
        private readonly IExcelFacade _excelFacade;
        private readonly IHostingEnvironment _environment;
        private readonly SaveLogInFile _saveLogInFile;
        public ReportController(IExcelFacade excelFacade , IHostingEnvironment environment,SaveLogInFile saveLogInFile)
        {
            _excelFacade = excelFacade;
            _environment = environment;
            _saveLogInFile = saveLogInFile;
        }
        [HttpGet]
        public IActionResult Index()
        {
            return View(_excelFacade.GetAllExcels.Execute().Data);
        }

        [HttpGet]
        public IActionResult DeleteAllExcelsConfirmed()
        {
            try
            {
                DirectoryInfo directory = new DirectoryInfo(_environment.WebRootPath + "/Excels/");
                var files = directory.GetFiles("*.xlsx");
                foreach (var file in files)
                {
                    System.IO.File.Delete(file.FullName);
                }

                _excelFacade.DeleteAll.Execute();

                return Redirect("/Admin/Report");
            }
            catch (Exception ex)
            {
                _saveLogInFile.Log(LogLevel.Error, ex.Message, HttpContext);
                TempData["ErrorStatusCode"] = 500;
                TempData["ErrorMessage"] = "خطایی رخ داده است.";
                return View("Error");
            }
        }
    }
}
