#pragma checksum "E:\asp.net projects\Market\Market.EndPoint\Areas\Admin\Views\ProductCategories\Delete.cshtml" "{ff1816ec-aa5e-4d10-87f7-6f4963833460}" "c92076286f0d8a0dfef213442540aaa98bc98952"
// <auto-generated/>
#pragma warning disable 1591
[assembly: global::Microsoft.AspNetCore.Razor.Hosting.RazorCompiledItemAttribute(typeof(AspNetCore.Areas_Admin_Views_ProductCategories_Delete), @"mvc.1.0.view", @"/Areas/Admin/Views/ProductCategories/Delete.cshtml")]
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
#line 1 "E:\asp.net projects\Market\Market.EndPoint\Areas\Admin\Views\ProductCategories\Delete.cshtml"
using Application.Services.Admin.Categories.Queries.GetCategoryById;

#line default
#line hidden
#nullable disable
    [global::Microsoft.AspNetCore.Razor.Hosting.RazorSourceChecksumAttribute(@"SHA1", @"c92076286f0d8a0dfef213442540aaa98bc98952", @"/Areas/Admin/Views/ProductCategories/Delete.cshtml")]
    public class Areas_Admin_Views_ProductCategories_Delete : global::Microsoft.AspNetCore.Mvc.Razor.RazorPage<ResultOfGetCategoryByIdDto>
    {
        #pragma warning disable 1998
        public async override global::System.Threading.Tasks.Task ExecuteAsync()
        {
#nullable restore
#line 3 "E:\asp.net projects\Market\Market.EndPoint\Areas\Admin\Views\ProductCategories\Delete.cshtml"
  
    ViewData["Title"] = "Delete";
    Layout = null;

#line default
#line hidden
#nullable disable
            WriteLiteral("\r\n<div class=\"row\">\r\n    <form class=\"col s12\" action=\"/Admin/ProductCategories/Deleting\" method=\"post\">\r\n        <div class=\"row\">\r\n            <input type=\"hidden\" name=\"id\"");
            BeginWriteAttribute("value", " value=\"", 345, "\"", 362, 1);
#nullable restore
#line 11 "E:\asp.net projects\Market\Market.EndPoint\Areas\Admin\Views\ProductCategories\Delete.cshtml"
WriteAttributeValue("", 353, Model.Id, 353, 9, false);

#line default
#line hidden
#nullable disable
            EndWriteAttribute();
            WriteLiteral(" />\r\n\r\n            <div class=\"input-field col s6\">\r\n                <h3>آیا از حذف گروه ");
#nullable restore
#line 14 "E:\asp.net projects\Market\Market.EndPoint\Areas\Admin\Views\ProductCategories\Delete.cshtml"
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
