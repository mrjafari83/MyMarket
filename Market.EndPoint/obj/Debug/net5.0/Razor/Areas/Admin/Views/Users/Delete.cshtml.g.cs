#pragma checksum "E:\asp.net projects\Market\Market.EndPoint\Areas\Admin\Views\Users\Delete.cshtml" "{ff1816ec-aa5e-4d10-87f7-6f4963833460}" "ffcc7e73fd67e562d4d6dd4e87208d9d3ffba5bb"
// <auto-generated/>
#pragma warning disable 1591
[assembly: global::Microsoft.AspNetCore.Razor.Hosting.RazorCompiledItemAttribute(typeof(AspNetCore.Areas_Admin_Views_Users_Delete), @"mvc.1.0.view", @"/Areas/Admin/Views/Users/Delete.cshtml")]
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
#line 1 "E:\asp.net projects\Market\Market.EndPoint\Areas\Admin\Views\Users\Delete.cshtml"
using Common.ViewModels;

#line default
#line hidden
#nullable disable
    [global::Microsoft.AspNetCore.Razor.Hosting.RazorSourceChecksumAttribute(@"SHA1", @"ffcc7e73fd67e562d4d6dd4e87208d9d3ffba5bb", @"/Areas/Admin/Views/Users/Delete.cshtml")]
    public class Areas_Admin_Views_Users_Delete : global::Microsoft.AspNetCore.Mvc.Razor.RazorPage<UserViewModel>
    {
        #pragma warning disable 1998
        public async override global::System.Threading.Tasks.Task ExecuteAsync()
        {
            WriteLiteral("\r\n<div class=\"row\">\r\n    <table>\r\n        <tr>\r\n            <td>");
#nullable restore
#line 7 "E:\asp.net projects\Market\Market.EndPoint\Areas\Admin\Views\Users\Delete.cshtml"
           Write(Model.UserName);

#line default
#line hidden
#nullable disable
            WriteLiteral("</td>\r\n        </tr>\r\n        <tr>\r\n            <td>");
#nullable restore
#line 10 "E:\asp.net projects\Market\Market.EndPoint\Areas\Admin\Views\Users\Delete.cshtml"
           Write(Model.Email);

#line default
#line hidden
#nullable disable
            WriteLiteral("</td>\r\n        </tr>\r\n    </table>\r\n</div>\r\n<div class=\"row\">\r\n    <form method=\"post\" action=\"/Admin/Users/Deleting\"> \r\n        <input type=\"hidden\" name=\"userName\"");
            BeginWriteAttribute("value", " value=\"", 356, "\"", 379, 1);
#nullable restore
#line 16 "E:\asp.net projects\Market\Market.EndPoint\Areas\Admin\Views\Users\Delete.cshtml"
WriteAttributeValue("", 364, Model.UserName, 364, 15, false);

#line default
#line hidden
#nullable disable
            EndWriteAttribute();
            WriteLiteral(" />\r\n        <input type=\"submit\" value=\"حذف\" class=\"waves-effect waves-light btn red\"/>\r\n    </form>\r\n</div>");
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
        public global::Microsoft.AspNetCore.Mvc.Rendering.IHtmlHelper<UserViewModel> Html { get; private set; }
    }
}
#pragma warning restore 1591
