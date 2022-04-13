#pragma checksum "E:\asp.net projects\MyMarket\Market.EndPoint\Areas\Admin\Views\BlogPages\Index.cshtml" "{ff1816ec-aa5e-4d10-87f7-6f4963833460}" "06dd1540546c87f772a08dadecf5a34f08751e9c"
// <auto-generated/>
#pragma warning disable 1591
[assembly: global::Microsoft.AspNetCore.Razor.Hosting.RazorCompiledItemAttribute(typeof(AspNetCore.Areas_Admin_Views_BlogPages_Index), @"mvc.1.0.view", @"/Areas/Admin/Views/BlogPages/Index.cshtml")]
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
#line 1 "E:\asp.net projects\MyMarket\Market.EndPoint\Areas\Admin\Views\BlogPages\Index.cshtml"
using Application.Services.Common.BlogPage.Queries.GetAllBlogPages;

#line default
#line hidden
#nullable disable
    [global::Microsoft.AspNetCore.Razor.Hosting.RazorSourceChecksumAttribute(@"SHA1", @"06dd1540546c87f772a08dadecf5a34f08751e9c", @"/Areas/Admin/Views/BlogPages/Index.cshtml")]
    public class Areas_Admin_Views_BlogPages_Index : global::Microsoft.AspNetCore.Mvc.Razor.RazorPage<GetAllBlogPagesResult>
    {
        #pragma warning disable 1998
        public async override global::System.Threading.Tasks.Task ExecuteAsync()
        {
#nullable restore
#line 3 "E:\asp.net projects\MyMarket\Market.EndPoint\Areas\Admin\Views\BlogPages\Index.cshtml"
  
    ViewData["Title"] = "Index";
    Layout = "~/Areas/Admin/Views/Shared/_AdminLayout.cshtml";
    int back = ViewBag.CurrentRow - 1;
    int forward = ViewBag.CurrentRow + 1;

#line default
#line hidden
#nullable disable
            WriteLiteral(@"
<style>
    th, td {
        width: 16%;
        text-align: right;
    }
</style>

<div class=""row"">
    <table dir=""rtl"" style=""text-align : right"">
        <thead>
            <tr>
                <th>
                    <a class=""waves-effect waves-light btn modal-trigger green"" href=""/Admin/BlogPages/Create"">افزودن</a>
                </th>
            </tr>
            <tr>
                <th>تصویر</th>
                <th>عنوان</th>
                <th>عنوان دسته بندی</th>
                <th>تاریخ انتشار</th>
                <th>تعداد بازدید</th>
                <th></th>
            </tr>
        </thead>
");
#nullable restore
#line 34 "E:\asp.net projects\MyMarket\Market.EndPoint\Areas\Admin\Views\BlogPages\Index.cshtml"
         foreach (var item in Model.BlogPages)
        {

#line default
#line hidden
#nullable disable
            WriteLiteral("            <tr>\r\n                <td><img style=\"max-width:100px\"");
            BeginWriteAttribute("src", " src=\"", 1062, "\"", 1079, 1);
#nullable restore
#line 37 "E:\asp.net projects\MyMarket\Market.EndPoint\Areas\Admin\Views\BlogPages\Index.cshtml"
WriteAttributeValue("", 1068, item.Image, 1068, 11, false);

#line default
#line hidden
#nullable disable
            EndWriteAttribute();
            WriteLiteral(" /></td>\r\n                <td>");
#nullable restore
#line 38 "E:\asp.net projects\MyMarket\Market.EndPoint\Areas\Admin\Views\BlogPages\Index.cshtml"
               Write(item.Title);

#line default
#line hidden
#nullable disable
            WriteLiteral("</td>\r\n                <td>");
#nullable restore
#line 39 "E:\asp.net projects\MyMarket\Market.EndPoint\Areas\Admin\Views\BlogPages\Index.cshtml"
               Write(item.CategoryName);

#line default
#line hidden
#nullable disable
            WriteLiteral("</td>\r\n                <td>");
#nullable restore
#line 40 "E:\asp.net projects\MyMarket\Market.EndPoint\Areas\Admin\Views\BlogPages\Index.cshtml"
               Write(item.CreateDate);

#line default
#line hidden
#nullable disable
            WriteLiteral("</td>\r\n                <td>");
#nullable restore
#line 41 "E:\asp.net projects\MyMarket\Market.EndPoint\Areas\Admin\Views\BlogPages\Index.cshtml"
               Write(item.VisitNumber);

#line default
#line hidden
#nullable disable
            WriteLiteral("</td>\r\n                <td>\r\n                    <a style=\"width:50%\" class=\"waves-effect waves-light btn modal-trigger blue\"");
            BeginWriteAttribute("href", " href=\"", 1378, "\"", 1429, 2);
            WriteAttributeValue("", 1385, "/Admin/BlogPages/DetailInBaseLayout/", 1385, 36, true);
#nullable restore
#line 43 "E:\asp.net projects\MyMarket\Market.EndPoint\Areas\Admin\Views\BlogPages\Index.cshtml"
WriteAttributeValue("", 1421, item.Id, 1421, 8, false);

#line default
#line hidden
#nullable disable
            EndWriteAttribute();
            WriteLiteral(">مشاهده در قالب اصلی</a>\r\n                    <a style=\"width:25%\" class=\"waves-effect waves-light btn modal-trigger yellow\"");
            BeginWriteAttribute("href", " href=\"", 1554, "\"", 1591, 2);
            WriteAttributeValue("", 1561, "/Admin/BlogPages/Edit/", 1561, 22, true);
#nullable restore
#line 44 "E:\asp.net projects\MyMarket\Market.EndPoint\Areas\Admin\Views\BlogPages\Index.cshtml"
WriteAttributeValue("", 1583, item.Id, 1583, 8, false);

#line default
#line hidden
#nullable disable
            EndWriteAttribute();
            WriteLiteral(">ویرایش</a>\r\n                    <a style=\"width:25%\" class=\"waves-effect waves-light btn modal-trigger red\"");
            BeginWriteAttribute("href", " href=\"", 1700, "\"", 1739, 2);
            WriteAttributeValue("", 1707, "/Admin/BlogPages/Delete/", 1707, 24, true);
#nullable restore
#line 45 "E:\asp.net projects\MyMarket\Market.EndPoint\Areas\Admin\Views\BlogPages\Index.cshtml"
WriteAttributeValue("", 1731, item.Id, 1731, 8, false);

#line default
#line hidden
#nullable disable
            EndWriteAttribute();
            WriteLiteral(">حذف</a>\r\n                </td>\r\n            </tr>\r\n");
#nullable restore
#line 48 "E:\asp.net projects\MyMarket\Market.EndPoint\Areas\Admin\Views\BlogPages\Index.cshtml"
        }

#line default
#line hidden
#nullable disable
            WriteLiteral("        <tbody>\r\n        </tbody>\r\n    </table>\r\n\r\n    <div class=\"pagination\">\r\n        <ul>\r\n");
#nullable restore
#line 55 "E:\asp.net projects\MyMarket\Market.EndPoint\Areas\Admin\Views\BlogPages\Index.cshtml"
             if (ViewBag.CurrentRow == 1)
            {

#line default
#line hidden
#nullable disable
            WriteLiteral("                <li class=\"disabled\"><a");
            BeginWriteAttribute("href", " href=\"", 1995, "\"", 2002, 0);
            EndWriteAttribute();
            WriteLiteral("><i class=\"material-icons\">chevron_right</i></a></li>\r\n");
#nullable restore
#line 58 "E:\asp.net projects\MyMarket\Market.EndPoint\Areas\Admin\Views\BlogPages\Index.cshtml"
            }
            else
            {

#line default
#line hidden
#nullable disable
            WriteLiteral("                <li class=\"waves-effect\"><a");
            BeginWriteAttribute("href", " href=\"", 2149, "\"", 2196, 2);
            WriteAttributeValue("", 2156, "/Admin/BlogPages/Index?currentPage=", 2156, 35, true);
#nullable restore
#line 61 "E:\asp.net projects\MyMarket\Market.EndPoint\Areas\Admin\Views\BlogPages\Index.cshtml"
WriteAttributeValue("", 2191, back, 2191, 5, false);

#line default
#line hidden
#nullable disable
            EndWriteAttribute();
            WriteLiteral("><i class=\"material-icons\">chevron_right</i></a></li>\r\n");
#nullable restore
#line 62 "E:\asp.net projects\MyMarket\Market.EndPoint\Areas\Admin\Views\BlogPages\Index.cshtml"
            }

#line default
#line hidden
#nullable disable
            WriteLiteral("\r\n");
#nullable restore
#line 64 "E:\asp.net projects\MyMarket\Market.EndPoint\Areas\Admin\Views\BlogPages\Index.cshtml"
             for (int i = 1; i <= Model.TotalRows; i++)
            {
                if (i == ViewBag.CurrentRow)
                {

#line default
#line hidden
#nullable disable
            WriteLiteral("                    <li class=\"active\"><a");
            BeginWriteAttribute("href", " href=\"", 2447, "\"", 2491, 2);
            WriteAttributeValue("", 2454, "/Admin/BlogPages/Index?currentPage=", 2454, 35, true);
#nullable restore
#line 68 "E:\asp.net projects\MyMarket\Market.EndPoint\Areas\Admin\Views\BlogPages\Index.cshtml"
WriteAttributeValue("", 2489, i, 2489, 2, false);

#line default
#line hidden
#nullable disable
            EndWriteAttribute();
            WriteLiteral(">");
#nullable restore
#line 68 "E:\asp.net projects\MyMarket\Market.EndPoint\Areas\Admin\Views\BlogPages\Index.cshtml"
                                                                                  Write(i);

#line default
#line hidden
#nullable disable
            WriteLiteral("</a></li>\r\n");
#nullable restore
#line 69 "E:\asp.net projects\MyMarket\Market.EndPoint\Areas\Admin\Views\BlogPages\Index.cshtml"
                }
                else
                {

#line default
#line hidden
#nullable disable
            WriteLiteral("                    <li class=\"waves-effect\"><a");
            BeginWriteAttribute("href", " href=\"", 2613, "\"", 2657, 2);
            WriteAttributeValue("", 2620, "/Admin/BlogPages/Index?currentPage=", 2620, 35, true);
#nullable restore
#line 72 "E:\asp.net projects\MyMarket\Market.EndPoint\Areas\Admin\Views\BlogPages\Index.cshtml"
WriteAttributeValue("", 2655, i, 2655, 2, false);

#line default
#line hidden
#nullable disable
            EndWriteAttribute();
            WriteLiteral(">");
#nullable restore
#line 72 "E:\asp.net projects\MyMarket\Market.EndPoint\Areas\Admin\Views\BlogPages\Index.cshtml"
                                                                                        Write(i);

#line default
#line hidden
#nullable disable
            WriteLiteral("</a></li>\r\n");
#nullable restore
#line 73 "E:\asp.net projects\MyMarket\Market.EndPoint\Areas\Admin\Views\BlogPages\Index.cshtml"
                }
            }

#line default
#line hidden
#nullable disable
            WriteLiteral("\r\n");
#nullable restore
#line 76 "E:\asp.net projects\MyMarket\Market.EndPoint\Areas\Admin\Views\BlogPages\Index.cshtml"
             if (ViewBag.CurrentRow == Model.TotalRows)
            {

#line default
#line hidden
#nullable disable
            WriteLiteral("                <li class=\"disabled\"><a");
            BeginWriteAttribute("href", " href=\"", 2819, "\"", 2826, 0);
            EndWriteAttribute();
            WriteLiteral("><i class=\"material-icons\">chevron_left</i></a></li>\r\n");
#nullable restore
#line 79 "E:\asp.net projects\MyMarket\Market.EndPoint\Areas\Admin\Views\BlogPages\Index.cshtml"
            }
            else
            {

#line default
#line hidden
#nullable disable
            WriteLiteral("                <li class=\"waves-effect\"><a");
            BeginWriteAttribute("href", " href=\"", 2972, "\"", 3022, 2);
            WriteAttributeValue("", 2979, "/Admin/BlogPages/Index?currentPage=", 2979, 35, true);
#nullable restore
#line 82 "E:\asp.net projects\MyMarket\Market.EndPoint\Areas\Admin\Views\BlogPages\Index.cshtml"
WriteAttributeValue("", 3014, forward, 3014, 8, false);

#line default
#line hidden
#nullable disable
            EndWriteAttribute();
            WriteLiteral("><i class=\"material-icons\">chevron_left</i></a></li>\r\n");
#nullable restore
#line 83 "E:\asp.net projects\MyMarket\Market.EndPoint\Areas\Admin\Views\BlogPages\Index.cshtml"
            }

#line default
#line hidden
#nullable disable
            WriteLiteral("\r\n        </ul>\r\n    </div> <!-- /pagination -->\r\n</div>");
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
        public global::Microsoft.AspNetCore.Mvc.Rendering.IHtmlHelper<GetAllBlogPagesResult> Html { get; private set; }
    }
}
#pragma warning restore 1591
