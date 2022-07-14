using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Application.Common.Utilities;
using Microsoft.AspNetCore.Hosting;
using System.Threading.Tasks;
using System.IO;

namespace Market.EndPoint.Areas.Admin.Controllers
{
    [Area("Admin")]
    public class ExcelController : Controller
    {
        private readonly IHostingEnvironment _environment;
        public ExcelController(IHostingEnvironment hostingEnvironment)
        {
            _environment = hostingEnvironment;
        }

        [HttpPost]
        public async Task<IActionResult> GetExcelFile(IFormFile file)
        {
            try
            {
                string folderAddress = @"/Excels";
                string rootFolder = _environment.WebRootPath + folderAddress;

                if (!Directory.Exists(rootFolder))
                {
                    Directory.CreateDirectory(rootFolder);
                }

                var fileAddress = Path.Combine(rootFolder, file.FileName);

                using (var fileStream = new FileStream(fileAddress, FileMode.Create))
                {
                    await file.CopyToAsync(fileStream);
                }
                return Ok();
            }
            catch
            {
                return StatusCode(500);
            }
        }
    }
}
