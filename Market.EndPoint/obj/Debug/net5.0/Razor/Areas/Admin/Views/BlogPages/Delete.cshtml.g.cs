#pragma checksum "E:\asp.net projects\MyMarket\Market.EndPoint\Areas\Admin\Views\BlogPages\Delete.cshtml" "{ff1816ec-aa5e-4d10-87f7-6f4963833460}" "9853a8003dfd26fad32d43552f97596384e2dff9"
// <auto-generated/>
#pragma warning disable 1591
[assembly: global::Microsoft.AspNetCore.Razor.Hosting.RazorCompiledItemAttribute(typeof(AspNetCore.Areas_Admin_Views_BlogPages_Delete), @"mvc.1.0.view", @"/Areas/Admin/Views/BlogPages/Delete.cshtml")]
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
#line 1 "E:\asp.net projects\MyMarket\Market.EndPoint\Areas\Admin\Views\BlogPages\Delete.cshtml"
using Application.Services.Admin.BlogPages.Queries.GetBlogPageById;

#line default
#line hidden
#nullable disable
    [global::Microsoft.AspNetCore.Razor.Hosting.RazorSourceChecksumAttribute(@"SHA1", @"9853a8003dfd26fad32d43552f97596384e2dff9", @"/Areas/Admin/Views/BlogPages/Delete.cshtml")]
    public class Areas_Admin_Views_BlogPages_Delete : global::Microsoft.AspNetCore.Mvc.Razor.RazorPage<GetBlogPageByIdDto>
    {
        #pragma warning disable 1998
        public async override global::System.Threading.Tasks.Task ExecuteAsync()
        {
#nullable restore
#line 3 "E:\asp.net projects\MyMarket\Market.EndPoint\Areas\Admin\Views\BlogPages\Delete.cshtml"
  
    ViewData["Title"] = "Delete";
    Layout = "~/Areas/Admin/Views/Shared/_AdminLayout.cshtml";

#line default
#line hidden
#nullable disable
            WriteLiteral("\r\n<dl class=\"dl-horizontal\">\r\n    <dt>\r\n        <img class=\"thumbnail\"");
            BeginWriteAttribute("src", " src=\"", 272, "\"", 290, 1);
#nullable restore
#line 10 "E:\asp.net projects\MyMarket\Market.EndPoint\Areas\Admin\Views\BlogPages\Delete.cshtml"
WriteAttributeValue("", 278, Model.Image, 278, 12, false);

#line default
#line hidden
#nullable disable
            EndWriteAttribute();
            WriteLiteral("/>\r\n    </dt>\r\n    <dt>عنوان : ");
#nullable restore
#line 12 "E:\asp.net projects\MyMarket\Market.EndPoint\Areas\Admin\Views\BlogPages\Delete.cshtml"
           Write(Model.Title);

#line default
#line hidden
#nullable disable
            WriteLiteral("</dt>\r\n    <dt>دسته بندی : ");
#nullable restore
#line 13 "E:\asp.net projects\MyMarket\Market.EndPoint\Areas\Admin\Views\BlogPages\Delete.cshtml"
               Write(Model.CategoryName);

#line default
#line hidden
#nullable disable
            WriteLiteral("</dt>\r\n    <dt>تاریخ انتشار : ");
#nullable restore
#line 14 "E:\asp.net projects\MyMarket\Market.EndPoint\Areas\Admin\Views\BlogPages\Delete.cshtml"
                  Write(Model.CreateDate);

#line default
#line hidden
#nullable disable
            WriteLiteral("</dt>\r\n    <dt>تعداد بازدید : ");
#nullable restore
#line 15 "E:\asp.net projects\MyMarket\Market.EndPoint\Areas\Admin\Views\BlogPages\Delete.cshtml"
                  Write(Model.VisitNumber);

#line default
#line hidden
#nullable disable
            WriteLiteral("</dt>\r\n</dl>\r\n<a class=\"btn red waves-effect waves-light right\"");
            BeginWriteAttribute("href", " href=\"", 538, "\"", 580, 2);
            WriteAttributeValue("", 545, "/Admin/BlogPages/Deleting/", 545, 26, true);
#nullable restore
#line 17 "E:\asp.net projects\MyMarket\Market.EndPoint\Areas\Admin\Views\BlogPages\Delete.cshtml"
WriteAttributeValue("", 571, Model.Id, 571, 9, false);

#line default
#line hidden
#nullable disable
            EndWriteAttribute();
            WriteLiteral(">حذف</a>\r\n\r\n\r\n");
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
        public global::Microsoft.AspNetCore.Mvc.Rendering.IHtmlHelper<GetBlogPageByIdDto> Html { get; private set; }
    }
}
#pragma warning restore 1591
