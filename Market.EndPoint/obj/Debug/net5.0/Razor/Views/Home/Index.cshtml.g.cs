#pragma checksum "C:\Users\Kar1\Desktop\MyMarket\Market.EndPoint\Views\Home\Index.cshtml" "{ff1816ec-aa5e-4d10-87f7-6f4963833460}" "f94d15ded175b58e555af6b74125b975ea2566cd"
// <auto-generated/>
#pragma warning disable 1591
[assembly: global::Microsoft.AspNetCore.Razor.Hosting.RazorCompiledItemAttribute(typeof(AspNetCore.Views_Home_Index), @"mvc.1.0.view", @"/Views/Home/Index.cshtml")]
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
    [global::Microsoft.AspNetCore.Razor.Hosting.RazorSourceChecksumAttribute(@"SHA1", @"f94d15ded175b58e555af6b74125b975ea2566cd", @"/Views/Home/Index.cshtml")]
    [global::Microsoft.AspNetCore.Razor.Hosting.RazorSourceChecksumAttribute(@"SHA1", @"970eb37540a2f0f8a5d92f177ea4548b6362783f", @"/Views/_ViewImports.cshtml")]
    public class Views_Home_Index : global::Microsoft.AspNetCore.Mvc.Razor.RazorPage<dynamic>
    {
        #pragma warning disable 1998
        public async override global::System.Threading.Tasks.Task ExecuteAsync()
        {
#nullable restore
#line 1 "C:\Users\Kar1\Desktop\MyMarket\Market.EndPoint\Views\Home\Index.cshtml"
  
    ViewData["Title"] = "Home Page";

#line default
#line hidden
#nullable disable
            WriteLiteral("\r\n<!--  = Slider Revolution =  -->\r\n<!--  ==========  -->\r\n");
#nullable restore
#line 7 "C:\Users\Kar1\Desktop\MyMarket\Market.EndPoint\Views\Home\Index.cshtml"
Write(await Component.InvokeAsync("Slider"));

#line default
#line hidden
#nullable disable
            WriteLiteral(@"
<!-- /slider revolution -->
<!--  ==========  -->
<!--  = Main container =  -->
<!--  ==========  -->
<div class=""container"">
    <div class=""row"">
        <div class=""span12"">
            <div class=""push-up over-slider blocks-spacer"">

                <!--  ==========  -->
                <!--  = Three Banners =  -->
                <!--  ==========  -->
                <div class=""row"">
                    <div class=""span4"">
                        <a href=""#"" class=""btn btn-block banner"">
                            <span class=""title""><span class=""light"">فروش</span> تابستانی</span>
                            <em>تا 60% تخفیف روی کفش ها</em>
                        </a>
                    </div>
                    <div class=""span4"">
                        <a href=""#"" class=""btn btn-block colored banner"">
                            <span class=""title""><span class=""light"">ارسال</span> رایگان</span>
                            <em>برای خرید های بیش از 69000 تومان</em>
        ");
            WriteLiteral(@"                </a>
                    </div>
                    <div class=""span4"">
                        <a href=""#"" class=""btn btn-block banner"">
                            <span class=""title""><span class=""light"">محصولات</span> جدید</span>
                            <em>از محصولات جدید دیدن کنید.</em>
                        </a>
                    </div>
                </div> <!-- /three banners -->
            </div>
        </div>
    </div>

    <!--  ==========  -->
    <!--  = Featured Items =  -->
    <!--  ==========  -->
    ");
#nullable restore
#line 47 "C:\Users\Kar1\Desktop\MyMarket\Market.EndPoint\Views\Home\Index.cshtml"
Write(await Component.InvokeAsync("MostViewedProducts"));

#line default
#line hidden
#nullable disable
            WriteLiteral("\r\n</div>\r\n<!-- /container -->\r\n<!--  ==========  -->\r\n<!--  = New Products =  -->\r\n<!--  ==========  -->\r\n<div class=\"boxed-area blocks-spacer\">\r\n    ");
#nullable restore
#line 54 "C:\Users\Kar1\Desktop\MyMarket\Market.EndPoint\Views\Home\Index.cshtml"
Write(await Component.InvokeAsync("NewestProducts"));

#line default
#line hidden
#nullable disable
            WriteLiteral("\r\n</div> <!-- /new products -->\r\n");
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
        public global::Microsoft.AspNetCore.Mvc.Rendering.IHtmlHelper<dynamic> Html { get; private set; }
    }
}
#pragma warning restore 1591
