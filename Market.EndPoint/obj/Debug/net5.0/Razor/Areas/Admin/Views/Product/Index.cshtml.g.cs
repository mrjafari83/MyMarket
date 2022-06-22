#pragma checksum "C:\Users\Kar1\Desktop\MyMarket\Market.EndPoint\Areas\Admin\Views\Product\Index.cshtml" "{ff1816ec-aa5e-4d10-87f7-6f4963833460}" "c544188c7595645cb9bb8cb7c38431e7f4171715"
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
    [global::Microsoft.AspNetCore.Razor.Hosting.RazorSourceChecksumAttribute(@"SHA1", @"c544188c7595645cb9bb8cb7c38431e7f4171715", @"/Areas/Admin/Views/Product/Index.cshtml")]
    public class Areas_Admin_Views_Product_Index : global::Microsoft.AspNetCore.Mvc.Razor.RazorPage<ResultDto<ResultGetAllProductsDto>>
    {
        #pragma warning disable 1998
        public async override global::System.Threading.Tasks.Task ExecuteAsync()
        {
#nullable restore
#line 4 "C:\Users\Kar1\Desktop\MyMarket\Market.EndPoint\Areas\Admin\Views\Product\Index.cshtml"
  
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
        <tr>
            <th>
                <a class=""waves-effect waves-light btn modal-trigger green"" href=""/Admin/Product/Create"">افزودن</a>
            </th>
        </tr>
        <tr>
            <th>نام</th>
            <th>نام دسته بندی</th>
            <th>برند</th>
            <th>تعداد بازدید</th>
        </tr>

");
#nullable restore
#line 32 "C:\Users\Kar1\Desktop\MyMarket\Market.EndPoint\Areas\Admin\Views\Product\Index.cshtml"
         foreach (var item in Model.Data.Products)
        {

#line default
#line hidden
#nullable disable
            WriteLiteral("            <tr>\r\n                <td>");
#nullable restore
#line 35 "C:\Users\Kar1\Desktop\MyMarket\Market.EndPoint\Areas\Admin\Views\Product\Index.cshtml"
               Write(item.Name);

#line default
#line hidden
#nullable disable
            WriteLiteral("</td>\r\n                <td>");
#nullable restore
#line 36 "C:\Users\Kar1\Desktop\MyMarket\Market.EndPoint\Areas\Admin\Views\Product\Index.cshtml"
               Write(item.CategoryName);

#line default
#line hidden
#nullable disable
            WriteLiteral("</td>\r\n                <td>");
#nullable restore
#line 37 "C:\Users\Kar1\Desktop\MyMarket\Market.EndPoint\Areas\Admin\Views\Product\Index.cshtml"
               Write(item.Brand);

#line default
#line hidden
#nullable disable
            WriteLiteral("</td>\r\n                <td>");
#nullable restore
#line 38 "C:\Users\Kar1\Desktop\MyMarket\Market.EndPoint\Areas\Admin\Views\Product\Index.cshtml"
               Write(item.VisitNumber);

#line default
#line hidden
#nullable disable
            WriteLiteral("</td>\r\n                <td>\r\n                    <a style=\"width:50%\" class=\"waves-effect waves-light btn modal-trigger yellow\"");
            BeginWriteAttribute("href", " href=\"", 1182, "\"", 1217, 2);
            WriteAttributeValue("", 1189, "/Admin/Product/Edit/", 1189, 20, true);
#nullable restore
#line 40 "C:\Users\Kar1\Desktop\MyMarket\Market.EndPoint\Areas\Admin\Views\Product\Index.cshtml"
WriteAttributeValue("", 1209, item.Id, 1209, 8, false);

#line default
#line hidden
#nullable disable
            EndWriteAttribute();
            WriteLiteral(">ویرایش</a>\r\n                    <a style=\"width:50%\" class=\"waves-effect waves-light btn modal-trigger red\"");
            BeginWriteAttribute("href", " href=\"", 1326, "\"", 1363, 2);
            WriteAttributeValue("", 1333, "/Admin/Product/Delete/", 1333, 22, true);
#nullable restore
#line 41 "C:\Users\Kar1\Desktop\MyMarket\Market.EndPoint\Areas\Admin\Views\Product\Index.cshtml"
WriteAttributeValue("", 1355, item.Id, 1355, 8, false);

#line default
#line hidden
#nullable disable
            EndWriteAttribute();
            WriteLiteral(">حذف</a>\r\n                </td>\r\n            </tr>\r\n");
#nullable restore
#line 44 "C:\Users\Kar1\Desktop\MyMarket\Market.EndPoint\Areas\Admin\Views\Product\Index.cshtml"
        }

#line default
#line hidden
#nullable disable
            WriteLiteral("    </table>\r\n\r\n    <div class=\"pagination\">\r\n        <ul>\r\n");
#nullable restore
#line 49 "C:\Users\Kar1\Desktop\MyMarket\Market.EndPoint\Areas\Admin\Views\Product\Index.cshtml"
             if (ViewBag.CurrentRow == 1)
            {

#line default
#line hidden
#nullable disable
            WriteLiteral("                <li class=\"disabled\"><a");
            BeginWriteAttribute("href", " href=\"", 1584, "\"", 1591, 0);
            EndWriteAttribute();
            WriteLiteral("><i class=\"material-icons\">chevron_right</i></a></li>\r\n");
#nullable restore
#line 52 "C:\Users\Kar1\Desktop\MyMarket\Market.EndPoint\Areas\Admin\Views\Product\Index.cshtml"
            }
            else
            {

#line default
#line hidden
#nullable disable
            WriteLiteral("                <li class=\"waves-effect\"><a");
            BeginWriteAttribute("href", " href=\"", 1738, "\"", 1783, 2);
            WriteAttributeValue("", 1745, "/Admin/Product/Index?currentPage=", 1745, 33, true);
#nullable restore
#line 55 "C:\Users\Kar1\Desktop\MyMarket\Market.EndPoint\Areas\Admin\Views\Product\Index.cshtml"
WriteAttributeValue("", 1778, back, 1778, 5, false);

#line default
#line hidden
#nullable disable
            EndWriteAttribute();
            WriteLiteral("><i class=\"material-icons\">chevron_right</i></a></li>\r\n");
#nullable restore
#line 56 "C:\Users\Kar1\Desktop\MyMarket\Market.EndPoint\Areas\Admin\Views\Product\Index.cshtml"
            }

#line default
#line hidden
#nullable disable
            WriteLiteral("\r\n");
#nullable restore
#line 58 "C:\Users\Kar1\Desktop\MyMarket\Market.EndPoint\Areas\Admin\Views\Product\Index.cshtml"
             for (int i = 1; i <= Model.Data.TotalRows; i++)
            {
                if (i == ViewBag.CurrentRow)
                {

#line default
#line hidden
#nullable disable
            WriteLiteral("                    <li class=\"active\"><a");
            BeginWriteAttribute("href", " href=\"", 2039, "\"", 2081, 2);
            WriteAttributeValue("", 2046, "/Admin/Product/Index?currentPage=", 2046, 33, true);
#nullable restore
#line 62 "C:\Users\Kar1\Desktop\MyMarket\Market.EndPoint\Areas\Admin\Views\Product\Index.cshtml"
WriteAttributeValue("", 2079, i, 2079, 2, false);

#line default
#line hidden
#nullable disable
            EndWriteAttribute();
            WriteLiteral(">");
#nullable restore
#line 62 "C:\Users\Kar1\Desktop\MyMarket\Market.EndPoint\Areas\Admin\Views\Product\Index.cshtml"
                                                                                Write(i);

#line default
#line hidden
#nullable disable
            WriteLiteral("</a></li>\r\n");
#nullable restore
#line 63 "C:\Users\Kar1\Desktop\MyMarket\Market.EndPoint\Areas\Admin\Views\Product\Index.cshtml"
                }
                else
                {

#line default
#line hidden
#nullable disable
            WriteLiteral("                    <li class=\"waves-effect\"><a");
            BeginWriteAttribute("href", " href=\"", 2203, "\"", 2245, 2);
            WriteAttributeValue("", 2210, "/Admin/Product/Index?currentPage=", 2210, 33, true);
#nullable restore
#line 66 "C:\Users\Kar1\Desktop\MyMarket\Market.EndPoint\Areas\Admin\Views\Product\Index.cshtml"
WriteAttributeValue("", 2243, i, 2243, 2, false);

#line default
#line hidden
#nullable disable
            EndWriteAttribute();
            WriteLiteral(">");
#nullable restore
#line 66 "C:\Users\Kar1\Desktop\MyMarket\Market.EndPoint\Areas\Admin\Views\Product\Index.cshtml"
                                                                                      Write(i);

#line default
#line hidden
#nullable disable
            WriteLiteral("</a></li>\r\n");
#nullable restore
#line 67 "C:\Users\Kar1\Desktop\MyMarket\Market.EndPoint\Areas\Admin\Views\Product\Index.cshtml"
                }
            }

#line default
#line hidden
#nullable disable
            WriteLiteral("\r\n");
#nullable restore
#line 70 "C:\Users\Kar1\Desktop\MyMarket\Market.EndPoint\Areas\Admin\Views\Product\Index.cshtml"
             if (ViewBag.CurrentRow == Model.Data.TotalRows)
            {

#line default
#line hidden
#nullable disable
            WriteLiteral("                <li class=\"disabled\"><a");
            BeginWriteAttribute("href", " href=\"", 2412, "\"", 2419, 0);
            EndWriteAttribute();
            WriteLiteral("><i class=\"material-icons\">chevron_left</i></a></li>\r\n");
#nullable restore
#line 73 "C:\Users\Kar1\Desktop\MyMarket\Market.EndPoint\Areas\Admin\Views\Product\Index.cshtml"
            }
            else
            {

#line default
#line hidden
#nullable disable
            WriteLiteral("        <li class=\"waves-effect\"><a");
            BeginWriteAttribute("href", " href=\"", 2557, "\"", 2605, 2);
            WriteAttributeValue("", 2564, "/Admin/Product/Index?currentPage=", 2564, 33, true);
#nullable restore
#line 76 "C:\Users\Kar1\Desktop\MyMarket\Market.EndPoint\Areas\Admin\Views\Product\Index.cshtml"
WriteAttributeValue("", 2597, forward, 2597, 8, false);

#line default
#line hidden
#nullable disable
            EndWriteAttribute();
            WriteLiteral("><i class=\"material-icons\">chevron_left</i></a></li>\r\n");
#nullable restore
#line 77 "C:\Users\Kar1\Desktop\MyMarket\Market.EndPoint\Areas\Admin\Views\Product\Index.cshtml"
            }

#line default
#line hidden
#nullable disable
            WriteLiteral("\r\n        </ul>\r\n    </div> <!-- /pagination -->\r\n</div>\r\n\r\n");
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
