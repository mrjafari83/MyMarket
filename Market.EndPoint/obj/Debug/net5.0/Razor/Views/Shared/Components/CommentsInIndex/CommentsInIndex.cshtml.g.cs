#pragma checksum "E:\asp.net projects\MyMarket\Market.EndPoint\Views\Shared\Components\CommentsInIndex\CommentsInIndex.cshtml" "{ff1816ec-aa5e-4d10-87f7-6f4963833460}" "077208d24598338358941fa9a8c2f3beb821c3c8"
// <auto-generated/>
#pragma warning disable 1591
[assembly: global::Microsoft.AspNetCore.Razor.Hosting.RazorCompiledItemAttribute(typeof(AspNetCore.Views_Shared_Components_CommentsInIndex_CommentsInIndex), @"mvc.1.0.view", @"/Views/Shared/Components/CommentsInIndex/CommentsInIndex.cshtml")]
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
#line 1 "E:\asp.net projects\MyMarket\Market.EndPoint\Views\_ViewImports.cshtml"
using Market.EndPoint;

#line default
#line hidden
#nullable disable
#nullable restore
#line 2 "E:\asp.net projects\MyMarket\Market.EndPoint\Views\_ViewImports.cshtml"
using Market.EndPoint.Models;

#line default
#line hidden
#nullable disable
#nullable restore
#line 1 "E:\asp.net projects\MyMarket\Market.EndPoint\Views\Shared\Components\CommentsInIndex\CommentsInIndex.cshtml"
using Common.Dto;

#line default
#line hidden
#nullable disable
    [global::Microsoft.AspNetCore.Razor.Hosting.RazorSourceChecksumAttribute(@"SHA1", @"077208d24598338358941fa9a8c2f3beb821c3c8", @"/Views/Shared/Components/CommentsInIndex/CommentsInIndex.cshtml")]
    [global::Microsoft.AspNetCore.Razor.Hosting.RazorSourceChecksumAttribute(@"SHA1", @"2d7024c64dc247eca8debc4ecf94246dff276bcd", @"/Views/_ViewImports.cshtml")]
    public class Views_Shared_Components_CommentsInIndex_CommentsInIndex : global::Microsoft.AspNetCore.Mvc.Razor.RazorPage<ResultGetAllCommentsDto>
    {
        #pragma warning disable 1998
        public async override global::System.Threading.Tasks.Task ExecuteAsync()
        {
            WriteLiteral("\r\n        <div class=\"col s12 m12 l6\">\r\n            <div class=\"card\">\r\n                <div class=\"card-content\">\r\n                    <h5 class=\"card-title\">آخرین کامنت های ");
#nullable restore
#line 7 "E:\asp.net projects\MyMarket\Market.EndPoint\Views\Shared\Components\CommentsInIndex\CommentsInIndex.cshtml"
                                                      Write(ViewBag.CategiryType);

#line default
#line hidden
#nullable disable
            WriteLiteral("</h5>\r\n                    <div class=\"comment-widgets scrollable ps ps--theme_default ps--active-y ps--active-x\" style=\"height:560px;\" data-ps-id=\"e030b43c-3c38-97be-b507-e3897af0ebf5\">\r\n");
#nullable restore
#line 9 "E:\asp.net projects\MyMarket\Market.EndPoint\Views\Shared\Components\CommentsInIndex\CommentsInIndex.cshtml"
                         foreach (var item in Model.Comments)
                        {

#line default
#line hidden
#nullable disable
            WriteLiteral("                            <!-- Comment Row -->\r\n                            <div class=\"d-flex flex-row comment-row\">\r\n                                <div class=\"p-2\"><img");
            BeginWriteAttribute("src", " src=\"", 699, "\"", 719, 1);
#nullable restore
#line 13 "E:\asp.net projects\MyMarket\Market.EndPoint\Views\Shared\Components\CommentsInIndex\CommentsInIndex.cshtml"
WriteAttributeValue("", 705, item.ImageSrc, 705, 14, false);

#line default
#line hidden
#nullable disable
            EndWriteAttribute();
            WriteLiteral(" alt=\"user\" width=\"50\" class=\"circle\"></div>\r\n                                <div class=\"comment-text w-100\">\r\n                                    <h6 class=\"font-medium\">");
#nullable restore
#line 15 "E:\asp.net projects\MyMarket\Market.EndPoint\Views\Shared\Components\CommentsInIndex\CommentsInIndex.cshtml"
                                                       Write(item.Name);

#line default
#line hidden
#nullable disable
            WriteLiteral("</h6>\r\n                                    <span class=\"m-b-15 db\">");
#nullable restore
#line 16 "E:\asp.net projects\MyMarket\Market.EndPoint\Views\Shared\Components\CommentsInIndex\CommentsInIndex.cshtml"
                                                       Write(item.Text);

#line default
#line hidden
#nullable disable
            WriteLiteral(@"</span>
                                    <div class=""comment-footer"">
                                        <span class=""text-muted right"">April 14, 2016</span> <span class=""label label-info"">Pending</span> <span class=""action-icons"">
                                            <a href=""javascript:void(0)""><i class=""ti-pencil-alt""></i></a>
                                            <a href=""javascript:void(0)""><i class=""ti-check""></i></a>
                                            <a href=""javascript:void(0)""><i class=""ti-heart""></i></a>
                                        </span>
                                    </div>
                                </div>
                            </div>
");
#nullable restore
#line 26 "E:\asp.net projects\MyMarket\Market.EndPoint\Views\Shared\Components\CommentsInIndex\CommentsInIndex.cshtml"
                        }

#line default
#line hidden
#nullable disable
            WriteLiteral(@"
                        <div class=""ps__scrollbar-x-rail"" style=""left: -50px; bottom: 0px; width: 498px;""><div class=""ps__scrollbar-x"" tabindex=""0"" style=""left: 0px; width: 452px;""></div></div><div class=""ps__scrollbar-y-rail"" style=""top: 0px; height: 560px; right: 542px;""><div class=""ps__scrollbar-y"" tabindex=""0"" style=""top: 0px; height: 422px;""></div></div>
                    </div>
                </div>
            </div>
        </div>
");
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
        public global::Microsoft.AspNetCore.Mvc.Rendering.IHtmlHelper<ResultGetAllCommentsDto> Html { get; private set; }
    }
}
#pragma warning restore 1591