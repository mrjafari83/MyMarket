#pragma checksum "E:\asp.net projects\MyMarket\Market.EndPoint\Areas\Admin\Views\NewsBulletin\AddEmail.cshtml" "{ff1816ec-aa5e-4d10-87f7-6f4963833460}" "b74a14a2962a88da63f599b1d17b53ddbb9f395a"
// <auto-generated/>
#pragma warning disable 1591
[assembly: global::Microsoft.AspNetCore.Razor.Hosting.RazorCompiledItemAttribute(typeof(AspNetCore.Areas_Admin_Views_NewsBulletin_AddEmail), @"mvc.1.0.view", @"/Areas/Admin/Views/NewsBulletin/AddEmail.cshtml")]
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
    [global::Microsoft.AspNetCore.Razor.Hosting.RazorSourceChecksumAttribute(@"SHA1", @"b74a14a2962a88da63f599b1d17b53ddbb9f395a", @"/Areas/Admin/Views/NewsBulletin/AddEmail.cshtml")]
    public class Areas_Admin_Views_NewsBulletin_AddEmail : global::Microsoft.AspNetCore.Mvc.Razor.RazorPage<dynamic>
    {
        #pragma warning disable 1998
        public async override global::System.Threading.Tasks.Task ExecuteAsync()
        {
            WriteLiteral(@"
<div class=""row"">
    <form class=""col s12"" action=""/Admin/NewsBulletin/AddEmail"" method=""post"">
        <div class=""row"">
            <div class=""input-field col s6"">
                <input required name=""email"" type=""email"">
                <label for=""email""");
            BeginWriteAttribute("class", " class=\"", 268, "\"", 276, 0);
            EndWriteAttribute();
            WriteLiteral(">آدرس ایمیل : </label>\r\n            </div>\r\n        </div>\r\n        <div class=\"row\">\r\n            <input type=\"submit\" value=\"افزودن\" class=\"waves-effect waves-light btn green\" />\r\n        </div>\r\n    </form>\r\n</div>");
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