#pragma checksum "C:\Users\Kar1\Desktop\MyMarket\Market.EndPoint\Views\Shared\Components\ProductsInCartPaying\GetCartPayingProducts.cshtml" "{ff1816ec-aa5e-4d10-87f7-6f4963833460}" "5eed6ea251c481e34a6036b2ef4108ade9bb9ec0"
// <auto-generated/>
#pragma warning disable 1591
[assembly: global::Microsoft.AspNetCore.Razor.Hosting.RazorCompiledItemAttribute(typeof(AspNetCore.Views_Shared_Components_ProductsInCartPaying_GetCartPayingProducts), @"mvc.1.0.view", @"/Views/Shared/Components/ProductsInCartPaying/GetCartPayingProducts.cshtml")]
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
#line 3 "C:\Users\Kar1\Desktop\MyMarket\Market.EndPoint\Views\_ViewImports.cshtml"
using Common.Dto;

#line default
#line hidden
#nullable disable
#nullable restore
#line 1 "C:\Users\Kar1\Desktop\MyMarket\Market.EndPoint\Views\Shared\Components\ProductsInCartPaying\GetCartPayingProducts.cshtml"
using Application.Services.Admin.CartPaying.Queries.GetProductsOfCartPaying;

#line default
#line hidden
#nullable disable
    [global::Microsoft.AspNetCore.Razor.Hosting.RazorSourceChecksumAttribute(@"SHA1", @"5eed6ea251c481e34a6036b2ef4108ade9bb9ec0", @"/Views/Shared/Components/ProductsInCartPaying/GetCartPayingProducts.cshtml")]
    [global::Microsoft.AspNetCore.Razor.Hosting.RazorSourceChecksumAttribute(@"SHA1", @"970eb37540a2f0f8a5d92f177ea4548b6362783f", @"/Views/_ViewImports.cshtml")]
    public class Views_Shared_Components_ProductsInCartPaying_GetCartPayingProducts : global::Microsoft.AspNetCore.Mvc.Razor.RazorPage<List<ProductInCartPayingDto>>
    {
        #pragma warning disable 1998
        public async override global::System.Threading.Tasks.Task ExecuteAsync()
        {
#nullable restore
#line 3 "C:\Users\Kar1\Desktop\MyMarket\Market.EndPoint\Views\Shared\Components\ProductsInCartPaying\GetCartPayingProducts.cshtml"
  
    Layout = null;

#line default
#line hidden
#nullable disable
            WriteLiteral(@"<style>
    td{
        width:16%;
        border:solid 1px black;
        padding:1%;
        font-size:115%;
    }
</style>

<table style=""width:100%"">
    <thead>
        <tr>
            <td>نام</td>
            <td>برند</td>
            <td>قیمت</td>
            <td>تعداد</td>
            <td>رنگ</td>
            <td>سایز</td>
        </tr>
    </thead>
    <tbody>
");
#nullable restore
#line 27 "C:\Users\Kar1\Desktop\MyMarket\Market.EndPoint\Views\Shared\Components\ProductsInCartPaying\GetCartPayingProducts.cshtml"
         foreach (var item in Model)
        {

#line default
#line hidden
#nullable disable
            WriteLiteral("            <tr>\r\n                <td>");
#nullable restore
#line 30 "C:\Users\Kar1\Desktop\MyMarket\Market.EndPoint\Views\Shared\Components\ProductsInCartPaying\GetCartPayingProducts.cshtml"
               Write(item.Name);

#line default
#line hidden
#nullable disable
            WriteLiteral("</td>\r\n                <td>");
#nullable restore
#line 31 "C:\Users\Kar1\Desktop\MyMarket\Market.EndPoint\Views\Shared\Components\ProductsInCartPaying\GetCartPayingProducts.cshtml"
               Write(item.Brand);

#line default
#line hidden
#nullable disable
            WriteLiteral("</td>\r\n                <td>");
#nullable restore
#line 32 "C:\Users\Kar1\Desktop\MyMarket\Market.EndPoint\Views\Shared\Components\ProductsInCartPaying\GetCartPayingProducts.cshtml"
               Write(item.Price);

#line default
#line hidden
#nullable disable
            WriteLiteral("</td>\r\n                <td>");
#nullable restore
#line 33 "C:\Users\Kar1\Desktop\MyMarket\Market.EndPoint\Views\Shared\Components\ProductsInCartPaying\GetCartPayingProducts.cshtml"
               Write(item.Count);

#line default
#line hidden
#nullable disable
            WriteLiteral("</td>\r\n                <td>");
#nullable restore
#line 34 "C:\Users\Kar1\Desktop\MyMarket\Market.EndPoint\Views\Shared\Components\ProductsInCartPaying\GetCartPayingProducts.cshtml"
               Write(item.Color);

#line default
#line hidden
#nullable disable
            WriteLiteral("</td>\r\n                <td>");
#nullable restore
#line 35 "C:\Users\Kar1\Desktop\MyMarket\Market.EndPoint\Views\Shared\Components\ProductsInCartPaying\GetCartPayingProducts.cshtml"
               Write(item.Size);

#line default
#line hidden
#nullable disable
            WriteLiteral("</td>\r\n            </tr>\r\n");
#nullable restore
#line 37 "C:\Users\Kar1\Desktop\MyMarket\Market.EndPoint\Views\Shared\Components\ProductsInCartPaying\GetCartPayingProducts.cshtml"
        }

#line default
#line hidden
#nullable disable
            WriteLiteral("    </tbody>\r\n</table>\r\n\r\n");
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
        public global::Microsoft.AspNetCore.Mvc.Rendering.IHtmlHelper<List<ProductInCartPayingDto>> Html { get; private set; }
    }
}
#pragma warning restore 1591
