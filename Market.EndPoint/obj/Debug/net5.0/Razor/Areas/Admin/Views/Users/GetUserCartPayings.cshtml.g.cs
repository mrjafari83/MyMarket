#pragma checksum "E:\asp.net projects\MyMarket\Market.EndPoint\Areas\Admin\Views\Users\GetUserCartPayings.cshtml" "{ff1816ec-aa5e-4d10-87f7-6f4963833460}" "36a1fc9b7d7de4cf31fc572e9f483c16a56b3082"
// <auto-generated/>
#pragma warning disable 1591
[assembly: global::Microsoft.AspNetCore.Razor.Hosting.RazorCompiledItemAttribute(typeof(AspNetCore.Areas_Admin_Views_Users_GetUserCartPayings), @"mvc.1.0.view", @"/Areas/Admin/Views/Users/GetUserCartPayings.cshtml")]
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
#line 1 "E:\asp.net projects\MyMarket\Market.EndPoint\Areas\Admin\Views\Users\GetUserCartPayings.cshtml"
using Application.Services.Admin.CartPaying.Queries.GetUserCartPayings;

#line default
#line hidden
#nullable disable
    [global::Microsoft.AspNetCore.Razor.Hosting.RazorSourceChecksumAttribute(@"SHA1", @"36a1fc9b7d7de4cf31fc572e9f483c16a56b3082", @"/Areas/Admin/Views/Users/GetUserCartPayings.cshtml")]
    public class Areas_Admin_Views_Users_GetUserCartPayings : global::Microsoft.AspNetCore.Mvc.Razor.RazorPage<List<GetUserCartPayingsDto>>
    {
        #pragma warning disable 1998
        public async override global::System.Threading.Tasks.Task ExecuteAsync()
        {
#nullable restore
#line 3 "E:\asp.net projects\MyMarket\Market.EndPoint\Areas\Admin\Views\Users\GetUserCartPayings.cshtml"
  
    ViewData["Title"] = "GetUserCartPayings";
    Layout = null;

#line default
#line hidden
#nullable disable
            WriteLiteral("\r\n<table>\r\n    <thead>\r\n        <tr>\r\n            <th>نام و نام خانوادگی</th>\r\n            <th>تعداد محصولات</th>\r\n            <th>قیمت کل</th>\r\n            <th></th>\r\n        </tr>\r\n    </thead>\r\n    <tbody>\r\n");
#nullable restore
#line 18 "E:\asp.net projects\MyMarket\Market.EndPoint\Areas\Admin\Views\Users\GetUserCartPayings.cshtml"
         if (Model != null)
            foreach (var item in Model)
            {

#line default
#line hidden
#nullable disable
            WriteLiteral("                <tr>\r\n                    <td>");
#nullable restore
#line 22 "E:\asp.net projects\MyMarket\Market.EndPoint\Areas\Admin\Views\Users\GetUserCartPayings.cshtml"
                   Write(item.FullName);

#line default
#line hidden
#nullable disable
            WriteLiteral("</td>\r\n                    <td>");
#nullable restore
#line 23 "E:\asp.net projects\MyMarket\Market.EndPoint\Areas\Admin\Views\Users\GetUserCartPayings.cshtml"
                   Write(item.ProductsCount);

#line default
#line hidden
#nullable disable
            WriteLiteral("</td>\r\n                    <td>");
#nullable restore
#line 24 "E:\asp.net projects\MyMarket\Market.EndPoint\Areas\Admin\Views\Users\GetUserCartPayings.cshtml"
                   Write(item.ProductsPrice);

#line default
#line hidden
#nullable disable
            WriteLiteral("</td>\r\n                    <td>\r\n                        <a class=\"waves-effect waves-light btn modal-trigger green\"");
            BeginWriteAttribute("href", " href=\"", 754, "\"", 799, 2);
            WriteAttributeValue("", 761, "/Admin/Cart/CartPayingInfo?id=", 761, 30, true);
#nullable restore
#line 26 "E:\asp.net projects\MyMarket\Market.EndPoint\Areas\Admin\Views\Users\GetUserCartPayings.cshtml"
WriteAttributeValue("", 791, item.Id, 791, 8, false);

#line default
#line hidden
#nullable disable
            EndWriteAttribute();
            WriteLiteral(">مشاهده سبد</a>\r\n                    </td>\r\n                </tr>\r\n");
#nullable restore
#line 29 "E:\asp.net projects\MyMarket\Market.EndPoint\Areas\Admin\Views\Users\GetUserCartPayings.cshtml"
            }
        else
        {

#line default
#line hidden
#nullable disable
            WriteLiteral("            <tr>\r\n                <td>\r\n                    این کاربر خریدی نداشته است.\r\n                </td>\r\n            </tr>\r\n");
#nullable restore
#line 37 "E:\asp.net projects\MyMarket\Market.EndPoint\Areas\Admin\Views\Users\GetUserCartPayings.cshtml"
        }

#line default
#line hidden
#nullable disable
            WriteLiteral("        <tr>\r\n            <td></td>\r\n            <td></td>\r\n            <td></td>\r\n            <td>جمع خرید ها : ");
#nullable restore
#line 42 "E:\asp.net projects\MyMarket\Market.EndPoint\Areas\Admin\Views\Users\GetUserCartPayings.cshtml"
                         Write(Model.Sum(p=> p.ProductsPrice));

#line default
#line hidden
#nullable disable
            WriteLiteral("</td>\r\n        </tr>\r\n    </tbody>\r\n</table>\r\n\r\n");
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
        public global::Microsoft.AspNetCore.Mvc.Rendering.IHtmlHelper<List<GetUserCartPayingsDto>> Html { get; private set; }
    }
}
#pragma warning restore 1591
