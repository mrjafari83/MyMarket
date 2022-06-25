using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Mvc;
using System.IO;
using System.Collections.Generic;
using System;
using Market.EndPoint.Utilities;
using System.Threading.Tasks;
using System.Linq;
using Common.Utilities;

namespace Market.EndPoint.Areas.Admin.Controllers
{
    [Area("Admin")]
    public class ReportController : Controller
    {
        private readonly  IHostingEnvironment _environment;
        private readonly IGetProductDetailsExcel _getProductDetailsExcel;
        public ReportController(IHostingEnvironment environment , IGetProductDetailsExcel getProductDetailsExcel)
        {
            _environment = environment;
            _getProductDetailsExcel = getProductDetailsExcel;   
        }

        public IActionResult Index()
        {
            List<string> fileAddresses = new List<string>();
            DirectoryInfo directory = new DirectoryInfo(_environment.WebRootPath +"/Excels/");
            var files = directory.GetFiles("*.xlsx");
            foreach (var file in files)
            {
                fileAddresses.Add(file.Name);
            }

            return View(fileAddresses.OrderByDescending(f=> f).ToList());
        }

        public async Task<IActionResult> Create()
        {
            var address = await _getProductDetailsExcel.GetProductDetails(TempData["Ids"] as List<int>);
            return Json(address);
        }

        public IActionResult Delete(string fileName)
        {
            DirectoryInfo directory = new DirectoryInfo(_environment.WebRootPath + "/Excels/");
            var files = directory.GetFiles("*.xlsx");
            FileUploader.Delete(files.FirstOrDefault(f => f.Name == fileName).FullName);
            return Redirect(nameof(Index));
        }
    }
}
