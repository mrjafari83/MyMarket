using Application.Interfaces.FacadPatterns.Admin;
using System;
using System.Collections.Generic;
using System.Data;
using System.Threading.Tasks;

namespace Market.EndPoint.Utilities
{
    public class GetProductDetailsExcelInterop : IGetProductDetailsExcel
    {
        private readonly IOptionFacade _optionFacade;
        public GetProductDetailsExcelInterop(IOptionFacade optionFacade)
        {
            _optionFacade = optionFacade;
        }

        public async Task<string> GetProductDetails(List<int> Ids)
        {
            System.Data.DataTable table = new System.Data.DataTable();
            table.Columns.Add("نام", typeof(string));
            table.Columns.Add("نام دسته بندی", typeof(string));
            table.Columns.Add("برند ", typeof(string));
            table.Columns.Add("رنگ", typeof(string));
            table.Columns.Add("سایز", typeof(string));
            table.Columns.Add("تعداد بازدید", typeof(string));
            table.Columns.Add("تعداد فروخته شده", typeof(string));
            table.Columns.Add("قیمت", typeof(string));
            table.Columns.Add("موجودی", typeof(string));

            var products = await _optionFacade.GetAllProductDetailsService.Execute(Ids);
            foreach (var product in products.Data)
            {
                table.Rows.Add(
                        product.Name,
                        product.CategoryName,
                        product.Brand,
                        product.Color,
                        product.Size,
                        product.VisitNumber.ToString(),
                        product.SellsCount.ToString(),
                        product.Price.ToString(),
                        product.Inventory.ToString()
                    );
            }

            Microsoft.Office.Interop.Excel.Application excel;
            Microsoft.Office.Interop.Excel.Workbook worKbooK;
            Microsoft.Office.Interop.Excel.Worksheet worksheet;
            Microsoft.Office.Interop.Excel.Range celLrangE;

            excel = new Microsoft.Office.Interop.Excel.Application();
            excel.Visible = false;
            excel.DisplayAlerts = false;

            worKbooK = excel.Workbooks.Add(Type.Missing);
            worksheet = (Microsoft.Office.Interop.Excel.Worksheet)worKbooK.ActiveSheet;
            worksheet.Name = "محصولات";
            worksheet.Range[worksheet.Cells[1, 1], worksheet.Cells[1, 9]].Merge();

            int rowCount = 2;
            foreach (DataRow dataRow in table.Rows)
            {
                rowCount++;
                for (int i = 0; i < table.Columns.Count; i++)
                {
                    if (rowCount == 3)
                    {
                        worksheet.Cells[2, i] = table.Columns[i - 1].ColumnName;
                        worksheet.Cells.Font.Color = System.Drawing.Color.Black;

                    }

                    worksheet.Cells[rowCount, i] = dataRow[i - 1].ToString();

                    if (rowCount > 3)
                    {
                        if (i == table.Columns.Count)
                        {
                            if (rowCount % 2 == 0)
                            {
                                celLrangE = worksheet.Range[worksheet.Cells[rowCount, 1], worksheet.Cells[rowCount, table.Columns.Count]];
                            }

                        }
                    }
                }
            }

            celLrangE = worksheet.Range[worksheet.Cells[1, 1], worksheet.Cells[rowCount, table.Columns.Count]];
            celLrangE.EntireColumn.AutoFit();
            Microsoft.Office.Interop.Excel.Borders border = celLrangE.Borders;
            border.LineStyle = Microsoft.Office.Interop.Excel.XlLineStyle.xlContinuous;
            border.Weight = 2d;

            celLrangE = worksheet.Range[worksheet.Cells[1, 1], worksheet.Cells[2, table.Columns.Count]];

            worKbooK.Close();
            excel.Quit();
            return "He";
        }
    }
}
