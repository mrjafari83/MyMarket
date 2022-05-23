#pragma checksum "E:\asp.net projects\MyMarket\Market.EndPoint\Areas\Admin\Views\NewsBulletin\News.cshtml" "{ff1816ec-aa5e-4d10-87f7-6f4963833460}" "dfb636cfc19afec95e3c7fb7ee1b7dcd1c1889d9"
// <auto-generated/>
#pragma warning disable 1591
[assembly: global::Microsoft.AspNetCore.Razor.Hosting.RazorCompiledItemAttribute(typeof(AspNetCore.Areas_Admin_Views_NewsBulletin_News), @"mvc.1.0.view", @"/Areas/Admin/Views/NewsBulletin/News.cshtml")]
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
#line 1 "E:\asp.net projects\MyMarket\Market.EndPoint\Areas\Admin\Views\NewsBulletin\News.cshtml"
using Application.Services.Admin.NewsBulletin.Queries.GetAllNews;

#line default
#line hidden
#nullable disable
    [global::Microsoft.AspNetCore.Razor.Hosting.RazorSourceChecksumAttribute(@"SHA1", @"dfb636cfc19afec95e3c7fb7ee1b7dcd1c1889d9", @"/Areas/Admin/Views/NewsBulletin/News.cshtml")]
    public class Areas_Admin_Views_NewsBulletin_News : global::Microsoft.AspNetCore.Mvc.Razor.RazorPage<GetNewsDto>
    {
        #pragma warning disable 1998
        public async override global::System.Threading.Tasks.Task ExecuteAsync()
        {
#nullable restore
#line 3 "E:\asp.net projects\MyMarket\Market.EndPoint\Areas\Admin\Views\NewsBulletin\News.cshtml"
  
    ViewData["Title"] = "News";
    Layout = "~/Areas/Admin/Views/Shared/_AdminLayout.cshtml";
    int back = ViewBag.CurrentRow - 1;
    int forward = ViewBag.CurrentRow + 1;

#line default
#line hidden
#nullable disable
            WriteLiteral(@"
<h3>خبر ها</h3>
<table dir=""rtl"" style=""text-align:right"">
    <thead>
        <tr>
            <th>
                <a class=""waves-effect waves-light btn modal-trigger green"" href=""/Admin/NewsBulletin/SendNews"">ارسال خبر جدید</a>
            </th>
        </tr>
        <tr>
            <th>عنوان</th>
            <th></th>
        </tr>
    </thead>
    <tbody>
");
#nullable restore
#line 24 "E:\asp.net projects\MyMarket\Market.EndPoint\Areas\Admin\Views\NewsBulletin\News.cshtml"
         if (Model != null)
            foreach (var item in Model.News)
            {

#line default
#line hidden
#nullable disable
            WriteLiteral("                <tr>\r\n                    <td>");
#nullable restore
#line 28 "E:\asp.net projects\MyMarket\Market.EndPoint\Areas\Admin\Views\NewsBulletin\News.cshtml"
                   Write(item.Subject);

#line default
#line hidden
#nullable disable
            WriteLiteral("</td>\r\n                    <td>\r\n                        <a class=\"waves-effect waves-light btn modal-trigger blue\"");
            BeginWriteAttribute("href", " href=\"", 918, "\"", 965, 2);
            WriteAttributeValue("", 925, "/Admin/NewsBulletin/ShowNews?id=", 925, 32, true);
#nullable restore
#line 30 "E:\asp.net projects\MyMarket\Market.EndPoint\Areas\Admin\Views\NewsBulletin\News.cshtml"
WriteAttributeValue("", 957, item.Id, 957, 8, false);

#line default
#line hidden
#nullable disable
            EndWriteAttribute();
            WriteLiteral(">مشاهده</a>\r\n                    </td>\r\n                </tr>\r\n");
#nullable restore
#line 33 "E:\asp.net projects\MyMarket\Market.EndPoint\Areas\Admin\Views\NewsBulletin\News.cshtml"
            }

#line default
#line hidden
#nullable disable
            WriteLiteral("    </tbody>\r\n</table>\r\n\r\n<div class=\"pagination\">\r\n    <ul>\r\n");
#nullable restore
#line 39 "E:\asp.net projects\MyMarket\Market.EndPoint\Areas\Admin\Views\NewsBulletin\News.cshtml"
         if (ViewBag.CurrentRow == 1)
        {

#line default
#line hidden
#nullable disable
            WriteLiteral("            <li class=\"disabled\"><a");
            BeginWriteAttribute("href", " href=\"", 1191, "\"", 1198, 0);
            EndWriteAttribute();
            WriteLiteral("><i class=\"material-icons\">chevron_right</i></a></li>\r\n");
#nullable restore
#line 42 "E:\asp.net projects\MyMarket\Market.EndPoint\Areas\Admin\Views\NewsBulletin\News.cshtml"
        }
        else
        {

#line default
#line hidden
#nullable disable
            WriteLiteral("            <li class=\"waves-effect\"><a");
            BeginWriteAttribute("href", " href=\"", 1329, "\"", 1378, 2);
            WriteAttributeValue("", 1336, "/Admin/NewsBulletin/News?currentPage=", 1336, 37, true);
#nullable restore
#line 45 "E:\asp.net projects\MyMarket\Market.EndPoint\Areas\Admin\Views\NewsBulletin\News.cshtml"
WriteAttributeValue("", 1373, back, 1373, 5, false);

#line default
#line hidden
#nullable disable
            EndWriteAttribute();
            WriteLiteral("><i class=\"material-icons\">chevron_right</i></a></li>\r\n");
#nullable restore
#line 46 "E:\asp.net projects\MyMarket\Market.EndPoint\Areas\Admin\Views\NewsBulletin\News.cshtml"
        }

#line default
#line hidden
#nullable disable
            WriteLiteral("\r\n");
#nullable restore
#line 48 "E:\asp.net projects\MyMarket\Market.EndPoint\Areas\Admin\Views\NewsBulletin\News.cshtml"
         for (int i = 1; i <= Model.TotalRow; i++)
        {
            if (i == ViewBag.CurrentRow)
            {

#line default
#line hidden
#nullable disable
            WriteLiteral("                <li class=\"active\"><a");
            BeginWriteAttribute("href", " href=\"", 1604, "\"", 1650, 2);
            WriteAttributeValue("", 1611, "/Admin/NewsBulletin/News?currentPage=", 1611, 37, true);
#nullable restore
#line 52 "E:\asp.net projects\MyMarket\Market.EndPoint\Areas\Admin\Views\NewsBulletin\News.cshtml"
WriteAttributeValue("", 1648, i, 1648, 2, false);

#line default
#line hidden
#nullable disable
            EndWriteAttribute();
            WriteLiteral(">");
#nullable restore
#line 52 "E:\asp.net projects\MyMarket\Market.EndPoint\Areas\Admin\Views\NewsBulletin\News.cshtml"
                                                                                Write(i);

#line default
#line hidden
#nullable disable
            WriteLiteral("</a></li>\r\n");
#nullable restore
#line 53 "E:\asp.net projects\MyMarket\Market.EndPoint\Areas\Admin\Views\NewsBulletin\News.cshtml"
            }
            else
            {

#line default
#line hidden
#nullable disable
            WriteLiteral("                <li class=\"waves-effect\"><a");
            BeginWriteAttribute("href", " href=\"", 1756, "\"", 1802, 2);
            WriteAttributeValue("", 1763, "/Admin/NewsBulletin/News?currentPage=", 1763, 37, true);
#nullable restore
#line 56 "E:\asp.net projects\MyMarket\Market.EndPoint\Areas\Admin\Views\NewsBulletin\News.cshtml"
WriteAttributeValue("", 1800, i, 1800, 2, false);

#line default
#line hidden
#nullable disable
            EndWriteAttribute();
            WriteLiteral(">");
#nullable restore
#line 56 "E:\asp.net projects\MyMarket\Market.EndPoint\Areas\Admin\Views\NewsBulletin\News.cshtml"
                                                                                      Write(i);

#line default
#line hidden
#nullable disable
            WriteLiteral("</a></li>\r\n");
#nullable restore
#line 57 "E:\asp.net projects\MyMarket\Market.EndPoint\Areas\Admin\Views\NewsBulletin\News.cshtml"
            }
        }

#line default
#line hidden
#nullable disable
            WriteLiteral("\r\n");
#nullable restore
#line 60 "E:\asp.net projects\MyMarket\Market.EndPoint\Areas\Admin\Views\NewsBulletin\News.cshtml"
         if (ViewBag.CurrentRow == Model.TotalRow)
        {

#line default
#line hidden
#nullable disable
            WriteLiteral("            <li class=\"disabled\"><a");
            BeginWriteAttribute("href", " href=\"", 1943, "\"", 1950, 0);
            EndWriteAttribute();
            WriteLiteral("><i class=\"material-icons\">chevron_left</i></a></li>\r\n");
#nullable restore
#line 63 "E:\asp.net projects\MyMarket\Market.EndPoint\Areas\Admin\Views\NewsBulletin\News.cshtml"
        }
        else
        {

#line default
#line hidden
#nullable disable
            WriteLiteral("            <li class=\"waves-effect\"><a");
            BeginWriteAttribute("href", " href=\"", 2080, "\"", 2132, 2);
            WriteAttributeValue("", 2087, "/Admin/NewsBulletin/News?currentPage=", 2087, 37, true);
#nullable restore
#line 66 "E:\asp.net projects\MyMarket\Market.EndPoint\Areas\Admin\Views\NewsBulletin\News.cshtml"
WriteAttributeValue("", 2124, forward, 2124, 8, false);

#line default
#line hidden
#nullable disable
            EndWriteAttribute();
            WriteLiteral("><i class=\"material-icons\">chevron_left</i></a></li>\r\n");
#nullable restore
#line 67 "E:\asp.net projects\MyMarket\Market.EndPoint\Areas\Admin\Views\NewsBulletin\News.cshtml"
        }

#line default
#line hidden
#nullable disable
            WriteLiteral("\r\n    </ul>\r\n</div>");
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
        public global::Microsoft.AspNetCore.Mvc.Rendering.IHtmlHelper<GetNewsDto> Html { get; private set; }
    }
}
#pragma warning restore 1591