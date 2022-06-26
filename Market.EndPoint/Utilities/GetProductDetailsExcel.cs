using Application.Interfaces.FacadPatterns.Admin;
using Microsoft.AspNetCore.Hosting;
using OfficeOpenXml;
using System;
using System.Collections.Generic;
using System.IO;
using System.Threading.Tasks;
using System.Linq;
using System.Drawing;

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
                excelWorkSheet.View.RightToLeft = true;

                List<string[]> header = new List<string[]>
                {
                      new string[]{"نام","نام دسته بندی","برند","رنگ","سایز","تعداد بازدید","تعداد فروخته شده","قیمت","موجودی"}
                 };
                string headerRange = "A1:" + Char.ConvertFromUtf32(header[0].Length + 64) + "1";
                excelWorkSheet.Cells[headerRange].LoadFromArrays(header);
                excelWorkSheet.Column(1).Width = 20;
                excelWorkSheet.Column(2).Width = 25;
                excelWorkSheet.Column(3).Width = 20;
                excelWorkSheet.Column(4).Width = 20;
                excelWorkSheet.Column(5).Width = 20;
                excelWorkSheet.Column(6).Width = 15;
                excelWorkSheet.Column(7).Width = 20;
                excelWorkSheet.Column(8).Width = 25;
                excelWorkSheet.Column(9).Width = 15;

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

                for(int i = 1;i <= data.Count+1; i++)
                {
                    if(i == 1)
                    {
                        for(int j = 1; j <= data.FirstOrDefault().Length; j++)
                        {
                            ExcelRange range = excelWorkSheet.Cells[i,j];
                            range.Style.Font.SetFromFont("B Yekan",15);
                            range.Style.Font.Color.SetColor(1, 7, 16, 177);
                            range.Style.Border.Top.Style = OfficeOpenXml.Style.ExcelBorderStyle.Thin;
                            range.Style.Border.Bottom.Style = OfficeOpenXml.Style.ExcelBorderStyle.Thin;
                            range.Style.Border.Left.Style = OfficeOpenXml.Style.ExcelBorderStyle.Thin;
                            range.Style.Border.Right.Style = OfficeOpenXml.Style.ExcelBorderStyle.Thin;
                            range.Style.VerticalAlignment = OfficeOpenXml.Style.ExcelVerticalAlignment.Center;
                            range.Style.HorizontalAlignment = OfficeOpenXml.Style.ExcelHorizontalAlignment.Center;
                        }
                    }
                    else
                    {
                        for (int j = 1; j <= data.FirstOrDefault().Length; j++)
                        {
                            ExcelRange range = excelWorkSheet.Cells[i, j];
                            range.Style.Font.SetFromFont("B Yekan", 12 , false);
                            range.Style.Font.Color.SetColor(1, 0, 0, 0);
                            range.Style.VerticalAlignment = OfficeOpenXml.Style.ExcelVerticalAlignment.Center;
                            range.Style.HorizontalAlignment = OfficeOpenXml.Style.ExcelHorizontalAlignment.Center;
                            range.Style.Border.Top.Style = OfficeOpenXml.Style.ExcelBorderStyle.Thin;
                            range.Style.Border.Bottom.Style = OfficeOpenXml.Style.ExcelBorderStyle.Thin;
                            range.Style.Border.Left.Style = OfficeOpenXml.Style.ExcelBorderStyle.Thin;
                            range.Style.Border.Right.Style = OfficeOpenXml.Style.ExcelBorderStyle.Thin;
                        }
                    }
                }

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
