#pragma checksum "E:\asp.net projects\Market\Market.EndPoint\Views\Shared\Components\CategoriesInMenu\CategoriesInMenu.cshtml" "{ff1816ec-aa5e-4d10-87f7-6f4963833460}" "20131372c1453add7659e69b4c7ed4b5a314cdb3"
// <auto-generated/>
#pragma warning disable 1591
[assembly: global::Microsoft.AspNetCore.Razor.Hosting.RazorCompiledItemAttribute(typeof(AspNetCore.Views_Shared_Components_CategoriesInMenu_CategoriesInMenu), @"mvc.1.0.view", @"/Views/Shared/Components/CategoriesInMenu/CategoriesInMenu.cshtml")]
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
#line 1 "E:\asp.net projects\Market\Market.EndPoint\Views\_ViewImports.cshtml"
using Market.EndPoint;

#line default
#line hidden
#nullable disable
#nullable restore
#line 2 "E:\asp.net projects\Market\Market.EndPoint\Views\_ViewImports.cshtml"
using Market.EndPoint.Models;

#line default
#line hidden
#nullable disable
#nullable restore
#line 1 "E:\asp.net projects\Market\Market.EndPoint\Views\Shared\Components\CategoriesInMenu\CategoriesInMenu.cshtml"
using Common.Enums;

#line default
#line hidden
#nullable disable
#nullable restore
#line 2 "E:\asp.net projects\Market\Market.EndPoint\Views\Shared\Components\CategoriesInMenu\CategoriesInMenu.cshtml"
using Application.Services.Common.Category.Queries.GetAllCategories;

#line default
#line hidden
#nullable disable
    [global::Microsoft.AspNetCore.Razor.Hosting.RazorSourceChecksumAttribute(@"SHA1", @"20131372c1453add7659e69b4c7ed4b5a314cdb3", @"/Views/Shared/Components/CategoriesInMenu/CategoriesInMenu.cshtml")]
    [global::Microsoft.AspNetCore.Razor.Hosting.RazorSourceChecksumAttribute(@"SHA1", @"2d7024c64dc247eca8debc4ecf94246dff276bcd", @"/Views/_ViewImports.cshtml")]
    public class Views_Shared_Components_CategoriesInMenu_CategoriesInMenu : global::Microsoft.AspNetCore.Mvc.Razor.RazorPage<List<GetAllCategoriesDto>>
    {
        #pragma warning disable 1998
        public async override global::System.Threading.Tasks.Task ExecuteAsync()
        {
            WriteLiteral("\r\n");
#nullable restore
#line 5 "E:\asp.net projects\Market\Market.EndPoint\Views\Shared\Components\CategoriesInMenu\CategoriesInMenu.cshtml"
  
    ViewData["Title"] = "View";
    Layout = null;

#line default
#line hidden
#nullable disable
            WriteLiteral("\r\n<li class=\"dropdown\">\r\n\r\n");
#nullable restore
#line 12 "E:\asp.net projects\Market\Market.EndPoint\Views\Shared\Components\CategoriesInMenu\CategoriesInMenu.cshtml"
     if (ViewBag.CategoryType == Enums.CategoryType.Product)
    {

#line default
#line hidden
#nullable disable
            WriteLiteral("        <a href=\"/Products\" class=\"dropdown-toggle\">\r\n            <span>محصولات</span>\r\n            <b class=\"caret\"></b>\r\n        </a>\r\n");
            WriteLiteral("        <ul class=\"dropdown-menu\">\r\n");
#nullable restore
#line 20 "E:\asp.net projects\Market\Market.EndPoint\Views\Shared\Components\CategoriesInMenu\CategoriesInMenu.cshtml"
             foreach (var item in Model)
            {
                if (item.IsParent)
                {

#line default
#line hidden
#nullable disable
            WriteLiteral("                    <li class=\"dropdown\">\r\n                        <a");
            BeginWriteAttribute("href", " href=\"", 640, "\"", 676, 2);
            WriteAttributeValue("", 647, "/Products?categoryId=", 647, 21, true);
#nullable restore
#line 25 "E:\asp.net projects\Market\Market.EndPoint\Views\Shared\Components\CategoriesInMenu\CategoriesInMenu.cshtml"
WriteAttributeValue("", 668, item.Id, 668, 8, false);

#line default
#line hidden
#nullable disable
            EndWriteAttribute();
            WriteLiteral(">\r\n");
#nullable restore
#line 26 "E:\asp.net projects\Market\Market.EndPoint\Views\Shared\Components\CategoriesInMenu\CategoriesInMenu.cshtml"
                             if (item.Children.Count() != 0)
                            {

#line default
#line hidden
#nullable disable
            WriteLiteral("                                <i class=\"icon-caret-left pull-right visible-desktop\"></i>\r\n");
#nullable restore
#line 29 "E:\asp.net projects\Market\Market.EndPoint\Views\Shared\Components\CategoriesInMenu\CategoriesInMenu.cshtml"
                            }

#line default
#line hidden
#nullable disable
            WriteLiteral("                            ");
#nullable restore
#line 30 "E:\asp.net projects\Market\Market.EndPoint\Views\Shared\Components\CategoriesInMenu\CategoriesInMenu.cshtml"
                       Write(item.Name);

#line default
#line hidden
#nullable disable
            WriteLiteral("\r\n                        </a>\r\n                        <ul class=\"dropdown-menu\">\r\n");
#nullable restore
#line 33 "E:\asp.net projects\Market\Market.EndPoint\Views\Shared\Components\CategoriesInMenu\CategoriesInMenu.cshtml"
                             foreach (var child in item.Children)
                            {

#line default
#line hidden
#nullable disable
            WriteLiteral("                                <li><a");
            BeginWriteAttribute("href", " href=\"", 1154, "\"", 1191, 2);
            WriteAttributeValue("", 1161, "/Products?categoryId=", 1161, 21, true);
#nullable restore
#line 35 "E:\asp.net projects\Market\Market.EndPoint\Views\Shared\Components\CategoriesInMenu\CategoriesInMenu.cshtml"
WriteAttributeValue("", 1182, child.Id, 1182, 9, false);

#line default
#line hidden
#nullable disable
            EndWriteAttribute();
            WriteLiteral(">");
#nullable restore
#line 35 "E:\asp.net projects\Market\Market.EndPoint\Views\Shared\Components\CategoriesInMenu\CategoriesInMenu.cshtml"
                                                                        Write(child.Name);

#line default
#line hidden
#nullable disable
            WriteLiteral("</a></li>\r\n");
#nullable restore
#line 36 "E:\asp.net projects\Market\Market.EndPoint\Views\Shared\Components\CategoriesInMenu\CategoriesInMenu.cshtml"
                            }

#line default
#line hidden
#nullable disable
            WriteLiteral("                        </ul>\r\n                    </li>\r\n");
#nullable restore
#line 39 "E:\asp.net projects\Market\Market.EndPoint\Views\Shared\Components\CategoriesInMenu\CategoriesInMenu.cshtml"
                }
            }

#line default
#line hidden
#nullable disable
            WriteLiteral("        </ul>\r\n");
#nullable restore
#line 42 "E:\asp.net projects\Market\Market.EndPoint\Views\Shared\Components\CategoriesInMenu\CategoriesInMenu.cshtml"
    }
    else
    {

#line default
#line hidden
#nullable disable
            WriteLiteral("        <a href=\"/Blogs\" class=\"dropdown-toggle\">\r\n            <span>وبلاگ</span>\r\n            <b class=\"caret\"></b>\r\n        </a>\r\n");
            WriteLiteral("        <ul class=\"dropdown-menu\">\r\n");
#nullable restore
#line 51 "E:\asp.net projects\Market\Market.EndPoint\Views\Shared\Components\CategoriesInMenu\CategoriesInMenu.cshtml"
             foreach (var item in Model)
            {
                if (item.IsParent)
                {

#line default
#line hidden
#nullable disable
            WriteLiteral("                    <li class=\"dropdown-menu\">\r\n                        <a");
            BeginWriteAttribute("href", " href=\"", 1733, "\"", 1766, 2);
            WriteAttributeValue("", 1740, "/Blogs?categoryId=", 1740, 18, true);
#nullable restore
#line 56 "E:\asp.net projects\Market\Market.EndPoint\Views\Shared\Components\CategoriesInMenu\CategoriesInMenu.cshtml"
WriteAttributeValue("", 1758, item.Id, 1758, 8, false);

#line default
#line hidden
#nullable disable
            EndWriteAttribute();
            WriteLiteral(">\r\n");
#nullable restore
#line 57 "E:\asp.net projects\Market\Market.EndPoint\Views\Shared\Components\CategoriesInMenu\CategoriesInMenu.cshtml"
                             if (item.Children.Count() != 0)
                            {

#line default
#line hidden
#nullable disable
            WriteLiteral("                                <i class=\"icon-caret-left pull-right visible-desktop\"></i>\r\n");
#nullable restore
#line 60 "E:\asp.net projects\Market\Market.EndPoint\Views\Shared\Components\CategoriesInMenu\CategoriesInMenu.cshtml"
                            }

#line default
#line hidden
#nullable disable
            WriteLiteral("                            ");
#nullable restore
#line 61 "E:\asp.net projects\Market\Market.EndPoint\Views\Shared\Components\CategoriesInMenu\CategoriesInMenu.cshtml"
                       Write(item.Name);

#line default
#line hidden
#nullable disable
            WriteLiteral("\r\n                        </a>\r\n                        <ul class=\"dropdown-menu\">\r\n");
#nullable restore
#line 64 "E:\asp.net projects\Market\Market.EndPoint\Views\Shared\Components\CategoriesInMenu\CategoriesInMenu.cshtml"
                             foreach (var child in item.Children)
                            {

#line default
#line hidden
#nullable disable
            WriteLiteral("                                <li><a");
            BeginWriteAttribute("href", " href=\"", 2244, "\"", 2278, 2);
            WriteAttributeValue("", 2251, "/Blogs?categoryId=", 2251, 18, true);
#nullable restore
#line 66 "E:\asp.net projects\Market\Market.EndPoint\Views\Shared\Components\CategoriesInMenu\CategoriesInMenu.cshtml"
WriteAttributeValue("", 2269, child.Id, 2269, 9, false);

#line default
#line hidden
#nullable disable
            EndWriteAttribute();
            WriteLiteral(">");
#nullable restore
#line 66 "E:\asp.net projects\Market\Market.EndPoint\Views\Shared\Components\CategoriesInMenu\CategoriesInMenu.cshtml"
                                                                     Write(child.Name);

#line default
#line hidden
#nullable disable
            WriteLiteral("</a></li>\r\n");
#nullable restore
#line 67 "E:\asp.net projects\Market\Market.EndPoint\Views\Shared\Components\CategoriesInMenu\CategoriesInMenu.cshtml"
                            }

#line default
#line hidden
#nullable disable
            WriteLiteral("                        </ul>\r\n                    </li>\r\n");
#nullable restore
#line 70 "E:\asp.net projects\Market\Market.EndPoint\Views\Shared\Components\CategoriesInMenu\CategoriesInMenu.cshtml"
                }
            }

#line default
#line hidden
#nullable disable
            WriteLiteral("        </ul>\r\n");
#nullable restore
#line 73 "E:\asp.net projects\Market\Market.EndPoint\Views\Shared\Components\CategoriesInMenu\CategoriesInMenu.cshtml"
    }

#line default
#line hidden
#nullable disable
            WriteLiteral("</li>\r\n\r\n");
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
        public global::Microsoft.AspNetCore.Mvc.Rendering.IHtmlHelper<List<GetAllCategoriesDto>> Html { get; private set; }
    }
}
#pragma warning restore 1591
