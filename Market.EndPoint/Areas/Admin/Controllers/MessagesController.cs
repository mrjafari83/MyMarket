using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Application.Interfaces.FacadPatterns.Admin;
using Microsoft.AspNetCore.Authorization;
using Common.ViewModels.SearchViewModels;
using Common.Utilities;
using Market.EndPoint.Utilities.RabbitMQ;
using Microsoft.Extensions.Logging;

namespace Market.EndPoint.Areas.Admin.Controllers
{
    [Area("Admin")]
    [Authorize(Roles = "Admin,Owner")]
    public class MessagesController : Controller
    {
        private readonly IMessageFacad _messageFacad;
        private readonly SaveLogInFile _saveLogInFile;
        private readonly IExcelFacade _excelFacade;
        private readonly IOptionFacade _optionFacade;
        private readonly ISend _send;
        public MessagesController(IMessageFacad messageFacad, IExcelFacade excelFacade, SaveLogInFile saveLogInFile
            , IOptionFacade optionFacade, ISend send)
        {
            _messageFacad = messageFacad;
            _saveLogInFile = saveLogInFile;
            _excelFacade = excelFacade;
            _optionFacade = optionFacade;
            _send = send;
        }

        public IActionResult Criticism(MessageSearchViewModel searchModel ,int currentPage = 1)
        {
            ViewBag.CurrentRow = currentPage;
            ViewBag.SearchBy = (int)searchModel.SearchBy;
            ViewBag.SearchKey = searchModel.SearchKey;

            return View(_messageFacad.GetAllCriticsmMessages.Execute(searchModel ,currentPage).Result.Data);
        }

        [HttpPost]
        public async Task<IActionResult> CreateExcelConfirmed(MessageSearchViewModel searchModel)
        {
            try
            {
                var excelStatus = await _excelFacade.CreateExcelKey.Execute(searchModel, Domain.Entities.Option.SearchItemType.Message);
                int excelId = excelStatus.Data;

                _send.SendToCreateExcel(excelId, "Messages");

                return Redirect("/Admin/Messages/Criticism");
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
