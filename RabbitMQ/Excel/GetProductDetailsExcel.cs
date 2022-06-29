using Application.Interfaces.FacadPatterns.Admin;
using Microsoft.AspNetCore.Hosting;
using OfficeOpenXml;
using System;
using System.Collections.Generic;
using System.IO;
using System.Threading.Tasks;
using System.Linq;
using System.Drawing;
using System.ComponentModel.DataAnnotations;

namespace RabbitMQ.Excel
{
    public class GetProductDetailsExcel : IGetProductDetailsExcel
    {
        public string GetProductDetails<Type>(List<Type> source, string address, string sheetName)
       {
            if(source != null)
            {
                ExcelPackage.LicenseContext = LicenseContext.NonCommercial;

                using (var excel = new ExcelPackage())
                {
                    excel.Workbook.Worksheets.Add(sheetName);

                    var excelWorkSheet = excel.Workbook.Worksheets[sheetName];
                    excelWorkSheet.View.RightToLeft = true;

                    List<string[]> data = new List<string[]>();
                    int colmnCount = source.First().GetType().GetProperties().Length;

                    var h = source.FirstOrDefault();
                    if (h != null)
                    {
                        var properties = h.GetType().GetProperties();
                        string[] header = new string[properties.Length];
                        for (int i = 0; i < colmnCount; i++)
                        {
                            var attr = properties[i].GetCustomAttributes(typeof(DisplayAttribute), false).Cast<DisplayAttribute>().FirstOrDefault();
                            header[i] = attr.Name ?? properties[i].Name;
                        }
                        data.Add(header);
                    }

                    if (source != null)
                        for(int j = 1; j<=source.Count();j++)
                        {
                            var item = source[j-1];
                            string[] row = new string[colmnCount];
                            var prperties = item.GetType().GetProperties();
                            if (item != null)
                                for(int i = 0; i < colmnCount; i++)
                                {
                                    row[i] = prperties[i].GetValue(item).ToString();
                                }
                            data.Add(row);
                        }

                    for (int i = 1; i <= data.Count; i++)
                    {
                        if (i == 1)
                        {
                            for (int j = 1; j <= data.FirstOrDefault().Length; j++)
                            {
                                ExcelRange range = excelWorkSheet.Cells[i, j];
                                range.Style.Font.SetFromFont("B Narm", 15);
                                range.Style.Font.Bold = true;
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
                                range.Style.Font.SetFromFont("B Narm", 12, false);
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

                    for (int j = 1; j <= colmnCount; j++)
                        excelWorkSheet.Column(j).AutoFit(20.00, 50.00);

                    excelWorkSheet.Cells[1, 1].LoadFromArrays(data);
                    string folderAddress = address + $@"/Excels/";
                    if (!Directory.Exists(folderAddress))
                        Directory.CreateDirectory(folderAddress);
                    string fileName = "products-" + DateTime.Now.ToString("yyyy-M-d-H-m-ss") + ".xlsx";

                    FileInfo excelFile = new FileInfo(folderAddress + fileName);
                    excel.SaveAs(excelFile);

                    return fileName;
                } 
            }
            return "";
        }
    }
}
