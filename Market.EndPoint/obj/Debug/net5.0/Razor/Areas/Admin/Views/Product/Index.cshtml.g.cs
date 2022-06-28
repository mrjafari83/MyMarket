#pragma checksum "C:\Users\Kar1\Desktop\MyMarket\Market.EndPoint\Areas\Admin\Views\Product\Index.cshtml" "{ff1816ec-aa5e-4d10-87f7-6f4963833460}" "a736373f4478d210e626424633e3bf32f861589c"
// <auto-generated/>
#pragma warning disable 1591
[assembly: global::Microsoft.AspNetCore.Razor.Hosting.RazorCompiledItemAttribute(typeof(AspNetCore.Areas_Admin_Views_Product_Index), @"mvc.1.0.view", @"/Areas/Admin/Views/Product/Index.cshtml")]
namespace AspNetCore
{
    #line hidden
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Threading.Tasks;
    using Microsoft.AspNetCore.Mvc;
    using Microsoft.AspNetCore.Mvc.Rendering;
    using Microsoft.AspNetCore.Mvc.ViewFeatures;
#nullable restore
#line 1 "C:\Users\Kar1\Desktop\MyMarket\Market.EndPoint\Areas\Admin\Views\Product\Index.cshtml"
using Application.Services.Admin.Products.Queries.GetAllProducts;

#line default
#line hidden
#nullable disable
#nullable restore
#line 2 "C:\Users\Kar1\Desktop\MyMarket\Market.EndPoint\Areas\Admin\Views\Product\Index.cshtml"
using Common.Dto;

#line default
#line hidden
#nullable disable
#nullable restore
#line 3 "C:\Users\Kar1\Desktop\MyMarket\Market.EndPoint\Areas\Admin\Views\Product\Index.cshtml"
using Common.Enums;

#line default
#line hidden
#nullable disable
    [global::Microsoft.AspNetCore.Razor.Hosting.RazorSourceChecksumAttribute(@"SHA1", @"a736373f4478d210e626424633e3bf32f861589c", @"/Areas/Admin/Views/Product/Index.cshtml")]
    public class Areas_Admin_Views_Product_Index : global::Microsoft.AspNetCore.Mvc.Razor.RazorPage<ResultDto<ResultGetAllProductsDto>>
    {
        private static readonly global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute __tagHelperAttribute_0 = new global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute("id", new global::Microsoft.AspNetCore.Html.HtmlString("searchBy"), global::Microsoft.AspNetCore.Razor.TagHelpers.HtmlAttributeValueStyle.DoubleQuotes);
        private static readonly global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute __tagHelperAttribute_1 = new global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute("id", new global::Microsoft.AspNetCore.Html.HtmlString("orderBy"), global::Microsoft.AspNetCore.Razor.TagHelpers.HtmlAttributeValueStyle.DoubleQuotes);
        private static readonly global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute __tagHelperAttribute_2 = new global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute("id", new global::Microsoft.AspNetCore.Html.HtmlString("searchForm"), global::Microsoft.AspNetCore.Razor.TagHelpers.HtmlAttributeValueStyle.DoubleQuotes);
        private static readonly global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute __tagHelperAttribute_3 = new global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute("method", "get", global::Microsoft.AspNetCore.Razor.TagHelpers.HtmlAttributeValueStyle.DoubleQuotes);
        private static readonly global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute __tagHelperAttribute_4 = new global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute("action", new global::Microsoft.AspNetCore.Html.HtmlString("/Admin/Product/Index"), global::Microsoft.AspNetCore.Razor.TagHelpers.HtmlAttributeValueStyle.DoubleQuotes);
        #line hidden
        #pragma warning disable 0649
        private global::Microsoft.AspNetCore.Razor.Runtime.TagHelpers.TagHelperExecutionContext __tagHelperExecutionContext;
        #pragma warning restore 0649
        private global::Microsoft.AspNetCore.Razor.Runtime.TagHelpers.TagHelperRunner __tagHelperRunner = new global::Microsoft.AspNetCore.Razor.Runtime.TagHelpers.TagHelperRunner();
        #pragma warning disable 0169
        private string __tagHelperStringValueBuffer;
        #pragma warning restore 0169
        private global::Microsoft.AspNetCore.Razor.Runtime.TagHelpers.TagHelperScopeManager __backed__tagHelperScopeManager = null;
        private global::Microsoft.AspNetCore.Razor.Runtime.TagHelpers.TagHelperScopeManager __tagHelperScopeManager
        {
            get
            {
                if (__backed__tagHelperScopeManager == null)
                {
                    __backed__tagHelperScopeManager = new global::Microsoft.AspNetCore.Razor.Runtime.TagHelpers.TagHelperScopeManager(StartTagHelperWritingScope, EndTagHelperWritingScope);
                }
                return __backed__tagHelperScopeManager;
            }
        }
        private global::Microsoft.AspNetCore.Mvc.TagHelpers.FormTagHelper __Microsoft_AspNetCore_Mvc_TagHelpers_FormTagHelper;
        private global::Microsoft.AspNetCore.Mvc.TagHelpers.RenderAtEndOfFormTagHelper __Microsoft_AspNetCore_Mvc_TagHelpers_RenderAtEndOfFormTagHelper;
        private global::Microsoft.AspNetCore.Mvc.TagHelpers.SelectTagHelper __Microsoft_AspNetCore_Mvc_TagHelpers_SelectTagHelper;
        #pragma warning disable 1998
        public async override global::System.Threading.Tasks.Task ExecuteAsync()
        {
#nullable restore
#line 6 "C:\Users\Kar1\Desktop\MyMarket\Market.EndPoint\Areas\Admin\Views\Product\Index.cshtml"
  
    ViewData["Title"] = "Index";
    Layout = "~/Areas/Admin/Views/Shared/_AdminLayout.cshtml";
    int back = ViewBag.CurrentRow - 1;
    int forward = ViewBag.CurrentRow + 1;

    List<int> Ids = new List<int>();
    foreach (var item in Model.Data.Products)
        Ids.Add(item.Id);

    TempData["Ids"] = Ids;

#line default
#line hidden
#nullable disable
            WriteLiteral(@"
<style>
    th, td {
        width: 20%;
        text-align: right;
    }
</style>
<h3 style=""margin:0% 2%"">محصولات</h3>
<hr />

<div class=""row"" style=""margin:2%;"">
    <table dir=""rtl"" style=""text-align : right"">
        <thead>
            <tr>
                <th>
                    <a class=""waves-effect waves-light btn modal-trigger green"" style=""width:95%"" href=""/Admin/Product/Create"">افزودن</a>
                </th>
                <th>
                    <a class=""waves-effect waves-light btn modal-trigger green"" style=""width:95%"" id=""btnCreateExcel"">درخواست فایل اکسل</a>
                </th>
                <th>
                    <a class=""waves-effect waves-light btn modal-trigger green"" style=""width:95%"" href=""#modal1"" id=""btnGetExcel"">فایل های اکسل</a>
                </th>
                <th></th>
                <th></th>
            </tr>
            ");
            __tagHelperExecutionContext = __tagHelperScopeManager.Begin("form", global::Microsoft.AspNetCore.Razor.TagHelpers.TagMode.StartTagAndEndTag, "a736373f4478d210e626424633e3bf32f861589c6639", async() => {
                WriteLiteral("\r\n            <tr>\r\n                <td>\r\n                    <label for=\"searchKey\">جستوجو کنید : </label>\r\n                    <input type=\"text\" id=\"searchKey\"");
                BeginWriteAttribute("value", " value=\"", 1675, "\"", 1701, 1);
#nullable restore
#line 48 "C:\Users\Kar1\Desktop\MyMarket\Market.EndPoint\Areas\Admin\Views\Product\Index.cshtml"
WriteAttributeValue("", 1683, ViewBag.SearchKey, 1683, 18, false);

#line default
#line hidden
#nullable disable
                EndWriteAttribute();
                WriteLiteral(" />\r\n                </td>\r\n                <td>\r\n                    <label for=\"searchBy\">بر اساس : </label>\r\n                    ");
                __tagHelperExecutionContext = __tagHelperScopeManager.Begin("select", global::Microsoft.AspNetCore.Razor.TagHelpers.TagMode.StartTagAndEndTag, "a736373f4478d210e626424633e3bf32f861589c7600", async() => {
                }
                );
                __Microsoft_AspNetCore_Mvc_TagHelpers_SelectTagHelper = CreateTagHelper<global::Microsoft.AspNetCore.Mvc.TagHelpers.SelectTagHelper>();
                __tagHelperExecutionContext.Add(__Microsoft_AspNetCore_Mvc_TagHelpers_SelectTagHelper);
                __tagHelperExecutionContext.AddHtmlAttribute(__tagHelperAttribute_0);
#nullable restore
#line 52 "C:\Users\Kar1\Desktop\MyMarket\Market.EndPoint\Areas\Admin\Views\Product\Index.cshtml"
__Microsoft_AspNetCore_Mvc_TagHelpers_SelectTagHelper.Items = Html.GetEnumSelectList<Enums.PageFilterCategory>().OrderBy(p=> p.Value != ViewBag.SearchBy.ToString());

#line default
#line hidden
#nullable disable
                __tagHelperExecutionContext.AddTagHelperAttribute("asp-items", __Microsoft_AspNetCore_Mvc_TagHelpers_SelectTagHelper.Items, global::Microsoft.AspNetCore.Razor.TagHelpers.HtmlAttributeValueStyle.DoubleQuotes);
                await __tagHelperRunner.RunAsync(__tagHelperExecutionContext);
                if (!__tagHelperExecutionContext.Output.IsContentModified)
                {
                    await __tagHelperExecutionContext.SetOutputContentAsync();
                }
                Write(__tagHelperExecutionContext.Output);
                __tagHelperExecutionContext = __tagHelperScopeManager.End();
                WriteLiteral("\r\n                </td>\r\n                <td>\r\n");
#nullable restore
#line 55 "C:\Users\Kar1\Desktop\MyMarket\Market.EndPoint\Areas\Admin\Views\Product\Index.cshtml"
                         if (ViewBag.StartPrice == 0)
                        {

#line default
#line hidden
#nullable disable
                WriteLiteral("                        <label for=\"startPrice\">از قیمت :</label>\r\n                        <input type=\"number\" id=\"startPrice\" />\r\n");
#nullable restore
#line 59 "C:\Users\Kar1\Desktop\MyMarket\Market.EndPoint\Areas\Admin\Views\Product\Index.cshtml"
                        }
                        else
                        {

#line default
#line hidden
#nullable disable
                WriteLiteral("                        <label for=\"startPrice\">از قیمت :</label>\r\n                        <input type=\"number\"");
                BeginWriteAttribute("value", " value=\"", 2436, "\"", 2463, 1);
#nullable restore
#line 63 "C:\Users\Kar1\Desktop\MyMarket\Market.EndPoint\Areas\Admin\Views\Product\Index.cshtml"
WriteAttributeValue("", 2444, ViewBag.StartPrice, 2444, 19, false);

#line default
#line hidden
#nullable disable
                EndWriteAttribute();
                WriteLiteral(" id=\"startPrice\" />\r\n");
#nullable restore
#line 64 "C:\Users\Kar1\Desktop\MyMarket\Market.EndPoint\Areas\Admin\Views\Product\Index.cshtml"
                        }

#line default
#line hidden
#nullable disable
                WriteLiteral("                </td>\r\n                <td>\r\n");
#nullable restore
#line 67 "C:\Users\Kar1\Desktop\MyMarket\Market.EndPoint\Areas\Admin\Views\Product\Index.cshtml"
                         if (ViewBag.EndPrice == 0)
                        {

#line default
#line hidden
#nullable disable
                WriteLiteral("                        <label for=\"endPrice\">تا قیمت : </label>\r\n                        <input type=\"number\" id=\"endPrice\" />\r\n");
#nullable restore
#line 71 "C:\Users\Kar1\Desktop\MyMarket\Market.EndPoint\Areas\Admin\Views\Product\Index.cshtml"
                        }
                        else
                        {

#line default
#line hidden
#nullable disable
                WriteLiteral("                        <label for=\"endPrice\">تا قیمت : </label>\r\n                        <input type=\"number\"");
                BeginWriteAttribute("value", " value=\"", 2960, "\"", 2985, 1);
#nullable restore
#line 75 "C:\Users\Kar1\Desktop\MyMarket\Market.EndPoint\Areas\Admin\Views\Product\Index.cshtml"
WriteAttributeValue("", 2968, ViewBag.EndPrice, 2968, 17, false);

#line default
#line hidden
#nullable disable
                EndWriteAttribute();
                WriteLiteral(" id=\"endPrice\" />\r\n");
#nullable restore
#line 76 "C:\Users\Kar1\Desktop\MyMarket\Market.EndPoint\Areas\Admin\Views\Product\Index.cshtml"
                        }

#line default
#line hidden
#nullable disable
                WriteLiteral("                </td>\r\n                <td>\r\n                    <label for=\"orderBy\">مرتب سازی بر اساس : </label>\r\n                    ");
                __tagHelperExecutionContext = __tagHelperScopeManager.Begin("select", global::Microsoft.AspNetCore.Razor.TagHelpers.TagMode.StartTagAndEndTag, "a736373f4478d210e626424633e3bf32f861589c12394", async() => {
                }
                );
                __Microsoft_AspNetCore_Mvc_TagHelpers_SelectTagHelper = CreateTagHelper<global::Microsoft.AspNetCore.Mvc.TagHelpers.SelectTagHelper>();
                __tagHelperExecutionContext.Add(__Microsoft_AspNetCore_Mvc_TagHelpers_SelectTagHelper);
                __tagHelperExecutionContext.AddHtmlAttribute(__tagHelperAttribute_1);
#nullable restore
#line 80 "C:\Users\Kar1\Desktop\MyMarket\Market.EndPoint\Areas\Admin\Views\Product\Index.cshtml"
__Microsoft_AspNetCore_Mvc_TagHelpers_SelectTagHelper.Items = Html.GetEnumSelectList<Enums.PagesFilter>().OrderBy(p=> p.Value != ViewBag.OrderBy.ToString());

#line default
#line hidden
#nullable disable
                __tagHelperExecutionContext.AddTagHelperAttribute("asp-items", __Microsoft_AspNetCore_Mvc_TagHelpers_SelectTagHelper.Items, global::Microsoft.AspNetCore.Razor.TagHelpers.HtmlAttributeValueStyle.DoubleQuotes);
                await __tagHelperRunner.RunAsync(__tagHelperExecutionContext);
                if (!__tagHelperExecutionContext.Output.IsContentModified)
                {
                    await __tagHelperExecutionContext.SetOutputContentAsync();
                }
                Write(__tagHelperExecutionContext.Output);
                __tagHelperExecutionContext = __tagHelperScopeManager.End();
                WriteLiteral(@"
                </td>
            </tr>
            <tr>
                <td></td>
                <td></td>
                <td></td>
                <td></td>
                <td>
                    <a class=""waves-effect waves-light btn modal-trigger blue"" id=""btnSearch"">جستوجو</a>
                </td>
            </tr>
            ");
            }
            );
            __Microsoft_AspNetCore_Mvc_TagHelpers_FormTagHelper = CreateTagHelper<global::Microsoft.AspNetCore.Mvc.TagHelpers.FormTagHelper>();
            __tagHelperExecutionContext.Add(__Microsoft_AspNetCore_Mvc_TagHelpers_FormTagHelper);
            __Microsoft_AspNetCore_Mvc_TagHelpers_RenderAtEndOfFormTagHelper = CreateTagHelper<global::Microsoft.AspNetCore.Mvc.TagHelpers.RenderAtEndOfFormTagHelper>();
            __tagHelperExecutionContext.Add(__Microsoft_AspNetCore_Mvc_TagHelpers_RenderAtEndOfFormTagHelper);
            __tagHelperExecutionContext.AddHtmlAttribute(__tagHelperAttribute_2);
            __Microsoft_AspNetCore_Mvc_TagHelpers_FormTagHelper.Method = (string)__tagHelperAttribute_3.Value;
            __tagHelperExecutionContext.AddTagHelperAttribute(__tagHelperAttribute_3);
            __tagHelperExecutionContext.AddHtmlAttribute(__tagHelperAttribute_4);
            await __tagHelperRunner.RunAsync(__tagHelperExecutionContext);
            if (!__tagHelperExecutionContext.Output.IsContentModified)
            {
                await __tagHelperExecutionContext.SetOutputContentAsync();
            }
            Write(__tagHelperExecutionContext.Output);
            __tagHelperExecutionContext = __tagHelperScopeManager.End();
            WriteLiteral("\r\n            <tr>\r\n                <th>نام</th>\r\n                <th>نام دسته بندی</th>\r\n                <th>برند</th>\r\n                <th>تعداد بازدید</th>\r\n            </tr>\r\n        </thead>\r\n\r\n        <tbody id=\"productTable\">\r\n");
#nullable restore
#line 102 "C:\Users\Kar1\Desktop\MyMarket\Market.EndPoint\Areas\Admin\Views\Product\Index.cshtml"
             foreach (var item in Model.Data.Products)
            {

#line default
#line hidden
#nullable disable
            WriteLiteral("                <tr>\r\n                    <td>");
#nullable restore
#line 105 "C:\Users\Kar1\Desktop\MyMarket\Market.EndPoint\Areas\Admin\Views\Product\Index.cshtml"
                   Write(item.Name);

#line default
#line hidden
#nullable disable
            WriteLiteral("</td>\r\n                    <td>");
#nullable restore
#line 106 "C:\Users\Kar1\Desktop\MyMarket\Market.EndPoint\Areas\Admin\Views\Product\Index.cshtml"
                   Write(item.CategoryName);

#line default
#line hidden
#nullable disable
            WriteLiteral("</td>\r\n                    <td>");
#nullable restore
#line 107 "C:\Users\Kar1\Desktop\MyMarket\Market.EndPoint\Areas\Admin\Views\Product\Index.cshtml"
                   Write(item.Brand);

#line default
#line hidden
#nullable disable
            WriteLiteral("</td>\r\n                    <td>");
#nullable restore
#line 108 "C:\Users\Kar1\Desktop\MyMarket\Market.EndPoint\Areas\Admin\Views\Product\Index.cshtml"
                   Write(item.VisitNumber);

#line default
#line hidden
#nullable disable
            WriteLiteral("</td>\r\n                    <td>\r\n                        <a style=\"width:45%;background-color:#d1ac12\" class=\"waves-effect waves-light btn modal-trigger\"");
            BeginWriteAttribute("href", " href=\"", 4317, "\"", 4352, 2);
            WriteAttributeValue("", 4324, "/Admin/Product/Edit/", 4324, 20, true);
#nullable restore
#line 110 "C:\Users\Kar1\Desktop\MyMarket\Market.EndPoint\Areas\Admin\Views\Product\Index.cshtml"
WriteAttributeValue("", 4344, item.Id, 4344, 8, false);

#line default
#line hidden
#nullable disable
            EndWriteAttribute();
            WriteLiteral(">ویرایش</a>\r\n                        <a style=\"width:45%\" class=\"waves-effect waves-light btn modal-trigger red\"");
            BeginWriteAttribute("href", " href=\"", 4465, "\"", 4502, 2);
            WriteAttributeValue("", 4472, "/Admin/Product/Delete/", 4472, 22, true);
#nullable restore
#line 111 "C:\Users\Kar1\Desktop\MyMarket\Market.EndPoint\Areas\Admin\Views\Product\Index.cshtml"
WriteAttributeValue("", 4494, item.Id, 4494, 8, false);

#line default
#line hidden
#nullable disable
            EndWriteAttribute();
            WriteLiteral(">حذف</a>\r\n                    </td>\r\n                    <td hidden>");
#nullable restore
#line 113 "C:\Users\Kar1\Desktop\MyMarket\Market.EndPoint\Areas\Admin\Views\Product\Index.cshtml"
                          Write(item.Id);

#line default
#line hidden
#nullable disable
            WriteLiteral("</td>\r\n                </tr>\r\n");
#nullable restore
#line 115 "C:\Users\Kar1\Desktop\MyMarket\Market.EndPoint\Areas\Admin\Views\Product\Index.cshtml"
            }

#line default
#line hidden
#nullable disable
            WriteLiteral("        </tbody>\r\n    </table>\r\n\r\n    <div style=\"margin-top:2% ; text-align:center\">\r\n        <div class=\"pagination\">\r\n            <ul>\r\n");
#nullable restore
#line 122 "C:\Users\Kar1\Desktop\MyMarket\Market.EndPoint\Areas\Admin\Views\Product\Index.cshtml"
                 if (ViewBag.CurrentRow == 1)
                {

#line default
#line hidden
#nullable disable
            WriteLiteral("                    <li class=\"disabled\"><a");
            BeginWriteAttribute("href", " href=\"", 4872, "\"", 4879, 0);
            EndWriteAttribute();
            WriteLiteral("><i class=\"material-icons\">chevron_right</i></a></li>\r\n");
#nullable restore
#line 125 "C:\Users\Kar1\Desktop\MyMarket\Market.EndPoint\Areas\Admin\Views\Product\Index.cshtml"
                }
                else
                {

#line default
#line hidden
#nullable disable
            WriteLiteral("                    <li class=\"waves-effect\"><a");
            BeginWriteAttribute("href", " href=\"", 5042, "\"", 5227, 12);
            WriteAttributeValue("", 5049, "/Admin/Product/Index?currentPage=", 5049, 33, true);
#nullable restore
#line 128 "C:\Users\Kar1\Desktop\MyMarket\Market.EndPoint\Areas\Admin\Views\Product\Index.cshtml"
WriteAttributeValue("", 5082, back, 5082, 5, false);

#line default
#line hidden
#nullable disable
            WriteAttributeValue("", 5087, "&searchKey=", 5087, 11, true);
#nullable restore
#line 128 "C:\Users\Kar1\Desktop\MyMarket\Market.EndPoint\Areas\Admin\Views\Product\Index.cshtml"
WriteAttributeValue("", 5098, ViewBag.SearchKey, 5098, 18, false);

#line default
#line hidden
#nullable disable
            WriteAttributeValue("", 5116, "&searchBy=", 5116, 10, true);
#nullable restore
#line 128 "C:\Users\Kar1\Desktop\MyMarket\Market.EndPoint\Areas\Admin\Views\Product\Index.cshtml"
WriteAttributeValue("", 5126, ViewBag.SearchKey, 5126, 18, false);

#line default
#line hidden
#nullable disable
            WriteAttributeValue("", 5144, "&startPrice=", 5144, 12, true);
#nullable restore
#line 128 "C:\Users\Kar1\Desktop\MyMarket\Market.EndPoint\Areas\Admin\Views\Product\Index.cshtml"
WriteAttributeValue("", 5156, ViewBag.StartPrice, 5156, 19, false);

#line default
#line hidden
#nullable disable
            WriteAttributeValue("", 5175, "&endPrice=", 5175, 10, true);
#nullable restore
#line 128 "C:\Users\Kar1\Desktop\MyMarket\Market.EndPoint\Areas\Admin\Views\Product\Index.cshtml"
WriteAttributeValue("", 5185, ViewBag.EndPrice, 5185, 17, false);

#line default
#line hidden
#nullable disable
            WriteAttributeValue("", 5202, "&orderBy=", 5202, 9, true);
#nullable restore
#line 128 "C:\Users\Kar1\Desktop\MyMarket\Market.EndPoint\Areas\Admin\Views\Product\Index.cshtml"
WriteAttributeValue("", 5211, ViewBag.OrderBy, 5211, 16, false);

#line default
#line hidden
#nullable disable
            EndWriteAttribute();
            WriteLiteral("><i class=\"material-icons\">chevron_right</i></a></li>\r\n");
#nullable restore
#line 129 "C:\Users\Kar1\Desktop\MyMarket\Market.EndPoint\Areas\Admin\Views\Product\Index.cshtml"
                }

#line default
#line hidden
#nullable disable
            WriteLiteral("\r\n");
#nullable restore
#line 131 "C:\Users\Kar1\Desktop\MyMarket\Market.EndPoint\Areas\Admin\Views\Product\Index.cshtml"
                 for (int i = 1; i <= Model.Data.TotalRows; i++)
                {
                    if (i == ViewBag.CurrentRow)
                    {

#line default
#line hidden
#nullable disable
            WriteLiteral("                        <li class=\"active\"><a");
            BeginWriteAttribute("href", " href=\"", 5507, "\"", 5689, 12);
            WriteAttributeValue("", 5514, "/Admin/Product/Index?currentPage=", 5514, 33, true);
#nullable restore
#line 135 "C:\Users\Kar1\Desktop\MyMarket\Market.EndPoint\Areas\Admin\Views\Product\Index.cshtml"
WriteAttributeValue("", 5547, i, 5547, 2, false);

#line default
#line hidden
#nullable disable
            WriteAttributeValue("", 5549, "&searchKey=", 5549, 11, true);
#nullable restore
#line 135 "C:\Users\Kar1\Desktop\MyMarket\Market.EndPoint\Areas\Admin\Views\Product\Index.cshtml"
WriteAttributeValue("", 5560, ViewBag.SearchKey, 5560, 18, false);

#line default
#line hidden
#nullable disable
            WriteAttributeValue("", 5578, "&searchBy=", 5578, 10, true);
#nullable restore
#line 135 "C:\Users\Kar1\Desktop\MyMarket\Market.EndPoint\Areas\Admin\Views\Product\Index.cshtml"
WriteAttributeValue("", 5588, ViewBag.SearchKey, 5588, 18, false);

#line default
#line hidden
#nullable disable
            WriteAttributeValue("", 5606, "&startPrice=", 5606, 12, true);
#nullable restore
#line 135 "C:\Users\Kar1\Desktop\MyMarket\Market.EndPoint\Areas\Admin\Views\Product\Index.cshtml"
WriteAttributeValue("", 5618, ViewBag.StartPrice, 5618, 19, false);

#line default
#line hidden
#nullable disable
            WriteAttributeValue("", 5637, "&endPrice=", 5637, 10, true);
#nullable restore
#line 135 "C:\Users\Kar1\Desktop\MyMarket\Market.EndPoint\Areas\Admin\Views\Product\Index.cshtml"
WriteAttributeValue("", 5647, ViewBag.EndPrice, 5647, 17, false);

#line default
#line hidden
#nullable disable
            WriteAttributeValue("", 5664, "&orderBy=", 5664, 9, true);
#nullable restore
#line 135 "C:\Users\Kar1\Desktop\MyMarket\Market.EndPoint\Areas\Admin\Views\Product\Index.cshtml"
WriteAttributeValue("", 5673, ViewBag.OrderBy, 5673, 16, false);

#line default
#line hidden
#nullable disable
            EndWriteAttribute();
            WriteLiteral(">");
#nullable restore
#line 135 "C:\Users\Kar1\Desktop\MyMarket\Market.EndPoint\Areas\Admin\Views\Product\Index.cshtml"
                                                                                                                                                                                                                                Write(i);

#line default
#line hidden
#nullable disable
            WriteLiteral("</a></li>\r\n");
#nullable restore
#line 136 "C:\Users\Kar1\Desktop\MyMarket\Market.EndPoint\Areas\Admin\Views\Product\Index.cshtml"
                    }
                    else
                    {

#line default
#line hidden
#nullable disable
            WriteLiteral("                        <li class=\"waves-effect\"><a");
            BeginWriteAttribute("href", " href=\"", 5827, "\"", 6009, 12);
            WriteAttributeValue("", 5834, "/Admin/Product/Index?currentPage=", 5834, 33, true);
#nullable restore
#line 139 "C:\Users\Kar1\Desktop\MyMarket\Market.EndPoint\Areas\Admin\Views\Product\Index.cshtml"
WriteAttributeValue("", 5867, i, 5867, 2, false);

#line default
#line hidden
#nullable disable
            WriteAttributeValue("", 5869, "&searchKey=", 5869, 11, true);
#nullable restore
#line 139 "C:\Users\Kar1\Desktop\MyMarket\Market.EndPoint\Areas\Admin\Views\Product\Index.cshtml"
WriteAttributeValue("", 5880, ViewBag.SearchKey, 5880, 18, false);

#line default
#line hidden
#nullable disable
            WriteAttributeValue("", 5898, "&searchBy=", 5898, 10, true);
#nullable restore
#line 139 "C:\Users\Kar1\Desktop\MyMarket\Market.EndPoint\Areas\Admin\Views\Product\Index.cshtml"
WriteAttributeValue("", 5908, ViewBag.SearchKey, 5908, 18, false);

#line default
#line hidden
#nullable disable
            WriteAttributeValue("", 5926, "&startPrice=", 5926, 12, true);
#nullable restore
#line 139 "C:\Users\Kar1\Desktop\MyMarket\Market.EndPoint\Areas\Admin\Views\Product\Index.cshtml"
WriteAttributeValue("", 5938, ViewBag.StartPrice, 5938, 19, false);

#line default
#line hidden
#nullable disable
            WriteAttributeValue("", 5957, "&endPrice=", 5957, 10, true);
#nullable restore
#line 139 "C:\Users\Kar1\Desktop\MyMarket\Market.EndPoint\Areas\Admin\Views\Product\Index.cshtml"
WriteAttributeValue("", 5967, ViewBag.EndPrice, 5967, 17, false);

#line default
#line hidden
#nullable disable
            WriteAttributeValue("", 5984, "&orderBy=", 5984, 9, true);
#nullable restore
#line 139 "C:\Users\Kar1\Desktop\MyMarket\Market.EndPoint\Areas\Admin\Views\Product\Index.cshtml"
WriteAttributeValue("", 5993, ViewBag.OrderBy, 5993, 16, false);

#line default
#line hidden
#nullable disable
            EndWriteAttribute();
            WriteLiteral(">");
#nullable restore
#line 139 "C:\Users\Kar1\Desktop\MyMarket\Market.EndPoint\Areas\Admin\Views\Product\Index.cshtml"
                                                                                                                                                                                                                                      Write(i);

#line default
#line hidden
#nullable disable
            WriteLiteral("</a></li>\r\n");
#nullable restore
#line 140 "C:\Users\Kar1\Desktop\MyMarket\Market.EndPoint\Areas\Admin\Views\Product\Index.cshtml"
                    }
                }

#line default
#line hidden
#nullable disable
            WriteLiteral("\r\n");
#nullable restore
#line 143 "C:\Users\Kar1\Desktop\MyMarket\Market.EndPoint\Areas\Admin\Views\Product\Index.cshtml"
                 if (ViewBag.CurrentRow == Model.Data.TotalRows)
                {

#line default
#line hidden
#nullable disable
            WriteLiteral("                    <li class=\"disabled\"><a");
            BeginWriteAttribute("href", " href=\"", 6196, "\"", 6203, 0);
            EndWriteAttribute();
            WriteLiteral("><i class=\"material-icons\">chevron_left</i></a></li>\r\n");
#nullable restore
#line 146 "C:\Users\Kar1\Desktop\MyMarket\Market.EndPoint\Areas\Admin\Views\Product\Index.cshtml"
                }
                else
                {

#line default
#line hidden
#nullable disable
            WriteLiteral("                    <li class=\"waves-effect\"><a");
            BeginWriteAttribute("href", " href=\"", 6365, "\"", 6553, 12);
            WriteAttributeValue("", 6372, "/Admin/Product/Index?currentPage=", 6372, 33, true);
#nullable restore
#line 149 "C:\Users\Kar1\Desktop\MyMarket\Market.EndPoint\Areas\Admin\Views\Product\Index.cshtml"
WriteAttributeValue("", 6405, forward, 6405, 8, false);

#line default
#line hidden
#nullable disable
            WriteAttributeValue("", 6413, "&searchKey=", 6413, 11, true);
#nullable restore
#line 149 "C:\Users\Kar1\Desktop\MyMarket\Market.EndPoint\Areas\Admin\Views\Product\Index.cshtml"
WriteAttributeValue("", 6424, ViewBag.SearchKey, 6424, 18, false);

#line default
#line hidden
#nullable disable
            WriteAttributeValue("", 6442, "&searchBy=", 6442, 10, true);
#nullable restore
#line 149 "C:\Users\Kar1\Desktop\MyMarket\Market.EndPoint\Areas\Admin\Views\Product\Index.cshtml"
WriteAttributeValue("", 6452, ViewBag.SearchKey, 6452, 18, false);

#line default
#line hidden
#nullable disable
            WriteAttributeValue("", 6470, "&startPrice=", 6470, 12, true);
#nullable restore
#line 149 "C:\Users\Kar1\Desktop\MyMarket\Market.EndPoint\Areas\Admin\Views\Product\Index.cshtml"
WriteAttributeValue("", 6482, ViewBag.StartPrice, 6482, 19, false);

#line default
#line hidden
#nullable disable
            WriteAttributeValue("", 6501, "&endPrice=", 6501, 10, true);
#nullable restore
#line 149 "C:\Users\Kar1\Desktop\MyMarket\Market.EndPoint\Areas\Admin\Views\Product\Index.cshtml"
WriteAttributeValue("", 6511, ViewBag.EndPrice, 6511, 17, false);

#line default
#line hidden
#nullable disable
            WriteAttributeValue("", 6528, "&orderBy=", 6528, 9, true);
#nullable restore
#line 149 "C:\Users\Kar1\Desktop\MyMarket\Market.EndPoint\Areas\Admin\Views\Product\Index.cshtml"
WriteAttributeValue("", 6537, ViewBag.OrderBy, 6537, 16, false);

#line default
#line hidden
#nullable disable
            EndWriteAttribute();
            WriteLiteral("><i class=\"material-icons\">chevron_left</i></a></li>\r\n");
#nullable restore
#line 150 "C:\Users\Kar1\Desktop\MyMarket\Market.EndPoint\Areas\Admin\Views\Product\Index.cshtml"
                }

#line default
#line hidden
#nullable disable
            WriteLiteral(@"
            </ul>
        </div> <!-- /pagination -->
    </div>
</div>

<!-- Modal Structure -->
<div id=""modal1"" class=""modal"">
    <div class=""modal-content"">
        <h4 id=""title"">Modal Header</h4>
        <p id=""body"">A bunch of text</p>
    </div>
</div>

");
            DefineSection("Scripts", async() => {
                WriteLiteral(@"
<script>
    $(document).ready(function(){

        $(""#btnSearch"").click(function(e){
             var formdata = new FormData();

             var searchKey = $(""#searchKey"").val();
             var searchBy = $(""#searchBy"").val();
             var startPrice = $(""#startPrice"").val();
             var endPrice = $(""#endPrice"").val();
             var orderBy = $(""#orderBy"").val();

             var address = ""/Admin/Product/Index?currentPage="" + ");
#nullable restore
#line 178 "C:\Users\Kar1\Desktop\MyMarket\Market.EndPoint\Areas\Admin\Views\Product\Index.cshtml"
                                                            Write(ViewBag.CurrentRow);

#line default
#line hidden
#nullable disable
                WriteLiteral(@"
             +""&SearchKey=""+ searchKey+""&SearchBy="" +searchBy+""&StartPrice=""+startPrice
             +""&EndPrice=""+endPrice+""&OrderBy=""+orderBy;

             location.href = address;
        });

        $(""#btnCreateExcel"").click(function(e){
             var formdata = new FormData();

             formdata.append(""SearchKey"",$(""#searchKey"").val());
             formdata.append(""SearchBy"",$(""#searchBy"").val());
             formdata.append(""StartPrice"",$(""#startPrice"").val());
             formdata.append(""EndPrice"",$(""#endPrice"").val());
             formdata.append(""OrderBy"",$(""#orderBy"").val());

             $.ajax({
                    type: ""POST"",
                    processData: false,
                    contentType: false,
                    cache: false,
                    enctype: ""multipart/form-data"",
                    url: ""/Admin/Product/CreateExcel"",
                    data: formdata,
                    success: function (response) {
                        ");
                WriteLiteral(@"location.href = ""/Admin/Product"";
                    }
                });
        });

        $(""#btnGetExcel"").click(function () {
            $.get(""/Admin/Product/GetExcels"", function (result) {
                $(""#title"").html(""فایل های اکسل"");
                $(""#body"").html(result);
            });
        });
    });
</script>
");
            }
            );
            WriteLiteral("\r\n");
        }
        #pragma warning restore 1998
        [global::Microsoft.AspNetCore.Mvc.Razor.Internal.RazorInjectAttribute]
        public global::Microsoft.AspNetCore.Mvc.ViewFeatures.IModelExpressionProvider ModelExpressionProvider { get; private set; }
        [global::Microsoft.AspNetCore.Mvc.Razor.Internal.RazorInjectAttribute]
        public global::Microsoft.AspNetCore.Mvc.IUrlHelper Url { get; private set; }
        [global::Microsoft.AspNetCore.Mvc.Razor.Internal.RazorInjectAttribute]
        public global::Microsoft.AspNetCore.Mvc.IViewComponentHelper Component { get; private set; }
        [global::Microsoft.AspNetCore.Mvc.Razor.Internal.RazorInjectAttribute]
        public global::Microsoft.AspNetCore.Mvc.Rendering.IJsonHelper Json { get; private set; }
        [global::Microsoft.AspNetCore.Mvc.Razor.Internal.RazorInjectAttribute]
        public global::Microsoft.AspNetCore.Mvc.Rendering.IHtmlHelper<ResultDto<ResultGetAllProductsDto>> Html { get; private set; }
    }
}
#pragma warning restore 1591
