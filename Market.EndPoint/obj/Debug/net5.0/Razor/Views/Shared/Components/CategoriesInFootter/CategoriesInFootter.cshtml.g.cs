#pragma checksum "C:\Users\Kar1\Desktop\MyMarket\Market.EndPoint\Views\Shared\Components\CategoriesInFootter\CategoriesInFootter.cshtml" "{ff1816ec-aa5e-4d10-87f7-6f4963833460}" "2624fce418a94f67b8c0b1c7290a7661aa1851a6"
// <auto-generated/>
#pragma warning disable 1591
[assembly: global::Microsoft.AspNetCore.Razor.Hosting.RazorCompiledItemAttribute(typeof(AspNetCore.Views_Shared_Components_CategoriesInFootter_CategoriesInFootter), @"mvc.1.0.view", @"/Views/Shared/Components/CategoriesInFootter/CategoriesInFootter.cshtml")]
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
#line 1 "C:\Users\Kar1\Desktop\MyMarket\Market.EndPoint\Views\_ViewImports.cshtml"
using Market.EndPoint;

#line default
#line hidden
#nullable disable
#nullable restore
#line 2 "C:\Users\Kar1\Desktop\MyMarket\Market.EndPoint\Views\_ViewImports.cshtml"
using Market.EndPoint.Models;

#line default
#line hidden
#nullable disable
#nullable restore
#line 1 "C:\Users\Kar1\Desktop\MyMarket\Market.EndPoint\Views\Shared\Components\CategoriesInFootter\CategoriesInFootter.cshtml"
using Application.Services.Common.Category.Queries.GetAllCategories;

#line default
#line hidden
#nullable disable
#nullable restore
#line 2 "C:\Users\Kar1\Desktop\MyMarket\Market.EndPoint\Views\Shared\Components\CategoriesInFootter\CategoriesInFootter.cshtml"
using Common.Enums;

#line default
#line hidden
#nullable disable
    [global::Microsoft.AspNetCore.Razor.Hosting.RazorSourceChecksumAttribute(@"SHA1", @"2624fce418a94f67b8c0b1c7290a7661aa1851a6", @"/Views/Shared/Components/CategoriesInFootter/CategoriesInFootter.cshtml")]
    [global::Microsoft.AspNetCore.Razor.Hosting.RazorSourceChecksumAttribute(@"SHA1", @"2d7024c64dc247eca8debc4ecf94246dff276bcd", @"/Views/_ViewImports.cshtml")]
    public class Views_Shared_Components_CategoriesInFootter_CategoriesInFootter : global::Microsoft.AspNetCore.Mvc.Razor.RazorPage<List<GetAllCategoriesDto>>
    {
        #pragma warning disable 1998
        public async override global::System.Threading.Tasks.Task ExecuteAsync()
        {
            WriteLiteral("\r\n");
#nullable restore
#line 5 "C:\Users\Kar1\Desktop\MyMarket\Market.EndPoint\Views\Shared\Components\CategoriesInFootter\CategoriesInFootter.cshtml"
 if (ViewBag.CategoryType == Enums.CategoryType.Product)
    foreach (var item in Model)
    {

#line default
#line hidden
#nullable disable
            WriteLiteral("        <li><a");
            BeginWriteAttribute("href", " href=\"", 239, "\"", 275, 2);
            WriteAttributeValue("", 246, "/Products?categoryId=", 246, 21, true);
#nullable restore
#line 8 "C:\Users\Kar1\Desktop\MyMarket\Market.EndPoint\Views\Shared\Components\CategoriesInFootter\CategoriesInFootter.cshtml"
WriteAttributeValue("", 267, item.Id, 267, 8, false);

#line default
#line hidden
#nullable disable
            EndWriteAttribute();
            WriteLiteral(">");
#nullable restore
#line 8 "C:\Users\Kar1\Desktop\MyMarket\Market.EndPoint\Views\Shared\Components\CategoriesInFootter\CategoriesInFootter.cshtml"
                                               Write(item.Name);

#line default
#line hidden
#nullable disable
            WriteLiteral("</a></li>\r\n");
#nullable restore
#line 9 "C:\Users\Kar1\Desktop\MyMarket\Market.EndPoint\Views\Shared\Components\CategoriesInFootter\CategoriesInFootter.cshtml"
    }
else
{
    foreach (var item in Model)
    {

#line default
#line hidden
#nullable disable
            WriteLiteral("        <li><a");
            BeginWriteAttribute("href", " href=\"", 368, "\"", 401, 2);
            WriteAttributeValue("", 375, "/Blogs?categoryId=", 375, 18, true);
#nullable restore
#line 14 "C:\Users\Kar1\Desktop\MyMarket\Market.EndPoint\Views\Shared\Components\CategoriesInFootter\CategoriesInFootter.cshtml"
WriteAttributeValue("", 393, item.Id, 393, 8, false);

#line default
#line hidden
#nullable disable
            EndWriteAttribute();
            WriteLiteral(">");
#nullable restore
#line 14 "C:\Users\Kar1\Desktop\MyMarket\Market.EndPoint\Views\Shared\Components\CategoriesInFootter\CategoriesInFootter.cshtml"
                                            Write(item.Name);

#line default
#line hidden
#nullable disable
            WriteLiteral("</a></li>\r\n");
#nullable restore
#line 15 "C:\Users\Kar1\Desktop\MyMarket\Market.EndPoint\Views\Shared\Components\CategoriesInFootter\CategoriesInFootter.cshtml"
    }
}

#line default
#line hidden
#nullable disable
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
