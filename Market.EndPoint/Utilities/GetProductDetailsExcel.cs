using Application.Interfaces.FacadPatterns.Admin;
using Microsoft.AspNetCore.Hosting;
using OfficeOpenXml;
using System;
using System.Collections.Generic;
using System.IO;
using System.Threading.Tasks;

namespace Market.EndPoint.Utilities
{
    public class GetProductDetailsExcel : IGetProductDetailsExcel
    {
        private readonly IOptionFacade _optionFacade;
        private readonly IHostingEnvironment _environment;
        public GetProductDetailsExcel(IOptionFacade optionFacade, IHostingEnvironment environment)
        {
            _optionFacade = optionFacade;
            _environment = environment;
        }

        public async Task<string> GetProductDetails(List<int> Ids)
        {
            ExcelPackage.LicenseContext = LicenseContext.NonCommercial;

            using (var excel = new ExcelPackage())
            {
                excel.Workbook.Worksheets.Add("محصولات");

                var excelWorkSheet = excel.Workbook.Worksheets["محصولات"];
                List<string[]> header = new List<string[]>
                {
                      new string[]{"نام","نام دسته بندی","برند","رنگ","سایز","تعداد بازدید","تعداد فروخته شده","قیمت","موجودی"}
                 };
                string headerRange = "A1:" + Char.ConvertFromUtf32(header[0].Length + 64) + "1";
                excelWorkSheet.Cells[headerRange].LoadFromArrays(header);

                List<string[]> data = new List<string[]>();
                var products = await _optionFacade.GetAllProductDetailsService.Execute(Ids);
                foreach (var product in products.Data)
                    data.Add(new string[]
                    {
                        product.Name,
                        product.CategoryName,
                        product.Brand,
                        product.Color,
                        product.Size,
                        product.VisitNumber.ToString(),
                        product.SellsCount.ToString(),
                        product.Price.ToString(),
                        product.Inventory.ToString(),
                    });

                excelWorkSheet.Cells[2, 1].LoadFromArrays(data);
                string folderAddress = _environment.WebRootPath + $@"/Excels/";
                if (!Directory.Exists(folderAddress))
                    Directory.CreateDirectory(folderAddress);
                string fileName = "products-" + DateTime.Now.ToString("yyyy-M-d-H-m-ss") + ".xlsx";

                FileInfo excelFile = new FileInfo(folderAddress + fileName);
                excel.SaveAs(excelFile);

                return fileName;
            }
        }
    }
}
