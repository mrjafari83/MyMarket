#pragma checksum "C:\Users\Kar1\Desktop\MyMarket\Market.EndPoint\Areas\Admin\Views\BlogCategories\Delete.cshtml" "{ff1816ec-aa5e-4d10-87f7-6f4963833460}" "a439bf67852c751704d37fbf6cc61012ef213b18"
// <auto-generated/>
#pragma warning disable 1591
[assembly: global::Microsoft.AspNetCore.Razor.Hosting.RazorCompiledItemAttribute(typeof(AspNetCore.Areas_Admin_Views_BlogCategories_Delete), @"mvc.1.0.view", @"/Areas/Admin/Views/BlogCategories/Delete.cshtml")]
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
#line 1 "C:\Users\Kar1\Desktop\MyMarket\Market.EndPoint\Areas\Admin\Views\BlogCategories\Delete.cshtml"
using Application.Services.Admin.Categories.Queries.GetCategoryById;

#line default
#line hidden
#nullable disable
    [global::Microsoft.AspNetCore.Razor.Hosting.RazorSourceChecksumAttribute(@"SHA1", @"a439bf67852c751704d37fbf6cc61012ef213b18", @"/Areas/Admin/Views/BlogCategories/Delete.cshtml")]
    public class Areas_Admin_Views_BlogCategories_Delete : global::Microsoft.AspNetCore.Mvc.Razor.RazorPage<ResultOfGetCategoryByIdDto>
    {
        #pragma warning disable 1998
        public async override global::System.Threading.Tasks.Task ExecuteAsync()
        {
#nullable restore
#line 3 "C:\Users\Kar1\Desktop\MyMarket\Market.EndPoint\Areas\Admin\Views\BlogCategories\Delete.cshtml"
  
    ViewData["Title"] = "Delete";
    Layout = null;

#line default
#line hidden
#nullable disable
            WriteLiteral("\r\n<div class=\"row\">\r\n    <form class=\"col s12\" action=\"/Admin/BlogCategories/Deleting\" method=\"post\">\r\n        <div class=\"row\">\r\n            <input type=\"hidden\" name=\"id\"");
            BeginWriteAttribute("value", " value=\"", 342, "\"", 359, 1);
#nullable restore
#line 11 "C:\Users\Kar1\Desktop\MyMarket\Market.EndPoint\Areas\Admin\Views\BlogCategories\Delete.cshtml"
WriteAttributeValue("", 350, Model.Id, 350, 9, false);

#line default
#line hidden
#nullable disable
            EndWriteAttribute();
            WriteLiteral(" />\r\n\r\n            <div class=\"input-field col s6\">\r\n                <h3>آیا از حذف گروه ");
#nullable restore
#line 14 "C:\Users\Kar1\Desktop\MyMarket\Market.EndPoint\Areas\Admin\Views\BlogCategories\Delete.cshtml"
                               Write(Model.Name);

#line default
#line hidden
#nullable disable
            WriteLiteral(" مطمئن هستید؟</h3>\r\n            </div>\r\n        </div>\r\n        <div class=\"row\">\r\n            <input type=\"submit\" value=\"حذف\" class=\"waves-effect waves-light btn red\" />\r\n        </div>\r\n    </form>\r\n</div>\r\n\r\n");
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
        public global::Microsoft.AspNetCore.Mvc.Rendering.IHtmlHelper<ResultOfGetCategoryByIdDto> Html { get; private set; }
    }
}
#pragma warning restore 1591
