#pragma checksum "E:\asp.net projects\MyMarket\Market.EndPoint\Views\Blog\ShowBlogPages.cshtml" "{ff1816ec-aa5e-4d10-87f7-6f4963833460}" "9bc54bca0a33c694797fca0c5f3dec0ea98cf6e1"
// <auto-generated/>
#pragma warning disable 1591
[assembly: global::Microsoft.AspNetCore.Razor.Hosting.RazorCompiledItemAttribute(typeof(AspNetCore.Views_Blog_ShowBlogPages), @"mvc.1.0.view", @"/Views/Blog/ShowBlogPages.cshtml")]
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
#line 1 "E:\asp.net projects\MyMarket\Market.EndPoint\Views\Blog\ShowBlogPages.cshtml"
using Application.Services.Client.BlogPages.Queries.GetBlogPageById;

#line default
#line hidden
#nullable disable
#nullable restore
#line 3 "E:\asp.net projects\MyMarket\Market.EndPoint\Views\Blog\ShowBlogPages.cshtml"
using Common.Utilities;

#line default
#line hidden
#nullable disable
#nullable restore
#line 4 "E:\asp.net projects\MyMarket\Market.EndPoint\Views\Blog\ShowBlogPages.cshtml"
using Application.Interfaces.FacadPatterns.Client;

#line default
#line hidden
#nullable disable
#nullable restore
#line 5 "E:\asp.net projects\MyMarket\Market.EndPoint\Views\Blog\ShowBlogPages.cshtml"
using Application.Interfaces.FacadPatterns.Common;

#line default
#line hidden
#nullable disable
    [global::Microsoft.AspNetCore.Razor.Hosting.RazorSourceChecksumAttribute(@"SHA1", @"9bc54bca0a33c694797fca0c5f3dec0ea98cf6e1", @"/Views/Blog/ShowBlogPages.cshtml")]
    [global::Microsoft.AspNetCore.Razor.Hosting.RazorSourceChecksumAttribute(@"SHA1", @"2d7024c64dc247eca8debc4ecf94246dff276bcd", @"/Views/_ViewImports.cshtml")]
    public class Views_Blog_ShowBlogPages : global::Microsoft.AspNetCore.Mvc.Razor.RazorPage<GetBlogPageByIdDto>
    {
        private static readonly global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute __tagHelperAttribute_0 = new global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute("class", new global::Microsoft.AspNetCore.Html.HtmlString("form"), global::Microsoft.AspNetCore.Razor.TagHelpers.HtmlAttributeValueStyle.DoubleQuotes);
        private static readonly global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute __tagHelperAttribute_1 = new global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute("action", new global::Microsoft.AspNetCore.Html.HtmlString("#"), global::Microsoft.AspNetCore.Razor.TagHelpers.HtmlAttributeValueStyle.DoubleQuotes);
        private static readonly global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute __tagHelperAttribute_2 = new global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute("id", new global::Microsoft.AspNetCore.Html.HtmlString("searchform"), global::Microsoft.AspNetCore.Razor.TagHelpers.HtmlAttributeValueStyle.DoubleQuotes);
        private static readonly global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute __tagHelperAttribute_3 = new global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute("method", "get", global::Microsoft.AspNetCore.Razor.TagHelpers.HtmlAttributeValueStyle.DoubleQuotes);
        private static readonly global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute __tagHelperAttribute_4 = new global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute("role", new global::Microsoft.AspNetCore.Html.HtmlString("search"), global::Microsoft.AspNetCore.Razor.TagHelpers.HtmlAttributeValueStyle.DoubleQuotes);
        #line hidden
        #pragma warning disable 0649
        private global::Microsoft.AspNetCore.Razor.Runtime.TagHelpers.TagHelperExecutionContext __tagHelperExecutionContext;
        #pragma warning restore 0649
        private global::Microsoft.AspNetCore.Razor.Runtime.TagHelpers.TagHelperRunner __tagHelperRunner = new global::Microsoft.AspNetCore.Razor.Runtime.TagHelpers.TagHelperRunner();
        #pragma warning disable 0169
        private string __tagHelperStringValueBuffer;
        #pragma warning restore 0169
        private global::Microsoft.AspNetCore.Razor.Runtime.TagHelpers.TagHelperScopeManager __backed__tagHelperScopeManager = null;
        private global::Microsoft.AspNetCore.Razor.Runtime.TagHelpers.TagHelperScopeManager __tagHelperScopeManager
        {
            get
            {
                if (__backed__tagHelperScopeManager == null)
                {
                    __backed__tagHelperScopeManager = new global::Microsoft.AspNetCore.Razor.Runtime.TagHelpers.TagHelperScopeManager(StartTagHelperWritingScope, EndTagHelperWritingScope);
                }
                return __backed__tagHelperScopeManager;
            }
        }
        private global::Microsoft.AspNetCore.Mvc.TagHelpers.FormTagHelper __Microsoft_AspNetCore_Mvc_TagHelpers_FormTagHelper;
        private global::Microsoft.AspNetCore.Mvc.TagHelpers.RenderAtEndOfFormTagHelper __Microsoft_AspNetCore_Mvc_TagHelpers_RenderAtEndOfFormTagHelper;
        #pragma warning disable 1998
        public async override global::System.Threading.Tasks.Task ExecuteAsync()
        {
            WriteLiteral("\r\n");
#nullable restore
#line 9 "E:\asp.net projects\MyMarket\Market.EndPoint\Views\Blog\ShowBlogPages.cshtml"
  
    ViewData["Title"] = "ShowBlogPages";
    Layout = "~/Views/Shared/_Layout.cshtml";

    if(CookiesManager.ContainCookie(Context , "BrowserCode"))
    {
        string code = CookiesManager.GetCookieValue(Context, "BrowserCode");
        _clientBlogPageFacad.AddNewVisit.Execute(Model.Id,code );
    }
    else
    {
        string code = _commonOptionFacad.CreateBrowser.Execute().Data;
        CookiesManager.AddCookie(Context, "BrowserCode", code);
        _clientBlogPageFacad.AddNewVisit.Execute(Model.Id, code);
    }

#line default
#line hidden
#nullable disable
            WriteLiteral("\r\n<div class=\"darker-stripe\">\r\n    <div class=\"container\">\r\n        <div class=\"row\">\r\n            <div class=\"span12\">\r\n                <ul class=\"breadcrumb\">\r\n                    <li>\r\n                        <a");
            BeginWriteAttribute("href", " href=\"", 1088, "\"", 1095, 0);
            EndWriteAttribute();
            WriteLiteral(">وبلاگ</a>\r\n                    </li>\r\n                    <li><span class=\"icon-chevron-right\"></span></li>\r\n                    <li>\r\n                        <a");
            BeginWriteAttribute("href", " href=\"", 1258, "\"", 1265, 0);
            EndWriteAttribute();
            WriteLiteral(">");
#nullable restore
#line 36 "E:\asp.net projects\MyMarket\Market.EndPoint\Views\Blog\ShowBlogPages.cshtml"
                              Write(Model.CategoryName);

#line default
#line hidden
#nullable disable
            WriteLiteral("</a>\r\n                    </li>\r\n                    <li><span class=\"icon-chevron-right\"></span></li>\r\n                    <li>\r\n                        <a");
            BeginWriteAttribute("href", " href=\"", 1442, "\"", 1449, 0);
            EndWriteAttribute();
            WriteLiteral(">");
#nullable restore
#line 40 "E:\asp.net projects\MyMarket\Market.EndPoint\Views\Blog\ShowBlogPages.cshtml"
                              Write(Model.Title);

#line default
#line hidden
#nullable disable
            WriteLiteral(@"</a>
                    </li>
                </ul>
            </div>
        </div>
    </div>
</div>
<div class=""container"">
    <div class=""push-up top-equal blocks-spacer"">
        <div class=""row"">

            <!--  ==========  -->
            <!--  = Main Title =  -->
            <!--  ==========  -->

            <div class=""span12"">
                <div class=""title-area"">
                    <h1 class=""inline"">");
#nullable restore
#line 57 "E:\asp.net projects\MyMarket\Market.EndPoint\Views\Blog\ShowBlogPages.cshtml"
                                  Write(Model.Title);

#line default
#line hidden
#nullable disable
            WriteLiteral(@"</h1>
                </div>
            </div>

            <!--  ==========  -->
            <!--  = Main content =  -->
            <!--  ==========  -->
            <section class=""span8 single single-post"">

                <!--  ==========  -->
                <!--  = Post =  -->
                <!--  ==========  -->
                <article class=""post format-video"">
                    <div class=""post-inner"">
                        <img");
            BeginWriteAttribute("src", " src=\"", 2382, "\"", 2400, 1);
#nullable restore
#line 71 "E:\asp.net projects\MyMarket\Market.EndPoint\Views\Blog\ShowBlogPages.cshtml"
WriteAttributeValue("", 2388, Model.Image, 2388, 12, false);

#line default
#line hidden
#nullable disable
            EndWriteAttribute();
            WriteLiteral(" alt=\"featured image\" width=\"1540\" height=\"746\">\r\n                        <div class=\"post-title\">\r\n                            <div class=\"metadata\">\r\n                                ");
#nullable restore
#line 74 "E:\asp.net projects\MyMarket\Market.EndPoint\Views\Blog\ShowBlogPages.cshtml"
                           Write(Model.CreateDate);

#line default
#line hidden
#nullable disable
            WriteLiteral("\r\n                            </div>\r\n                        </div>\r\n\r\n                        <div>\r\n                            ");
#nullable restore
#line 79 "E:\asp.net projects\MyMarket\Market.EndPoint\Views\Blog\ShowBlogPages.cshtml"
                       Write(Html.Raw(Model.Text));

#line default
#line hidden
#nullable disable
            WriteLiteral("\r\n                        </div>\r\n\r\n                    </div>\r\n                </article>\r\n\r\n                <hr>\r\n\r\n                <!--  ==========  -->\r\n                <!--  = Comments =  -->\r\n                <!--  ==========  -->\r\n\r\n                ");
#nullable restore
#line 91 "E:\asp.net projects\MyMarket\Market.EndPoint\Views\Blog\ShowBlogPages.cshtml"
           Write(await Component.InvokeAsync("Comment", new { pageId = Model.Id, type = Common.Enums.Enums.CategoryType.BlogPage }));

#line default
#line hidden
#nullable disable
            WriteLiteral(@"

            </section> <!-- /main content -->
            <!--  ==========  -->
            <!--  = Sidebar =  -->
            <!--  ==========  -->
            <aside class=""span4 right-sidebar"">

                <!--  ==========  -->
                <!--  = Search Widget =  -->
                <!--  ==========  -->
                <div class=""sidebar-item widget_search"">
                    <!-- <div class=""underlined"">
                        <h3><span class=""light"">Search</span></h3>
                    </div> -->

                    ");
            __tagHelperExecutionContext = __tagHelperScopeManager.Begin("form", global::Microsoft.AspNetCore.Razor.TagHelpers.TagMode.StartTagAndEndTag, "9bc54bca0a33c694797fca0c5f3dec0ea98cf6e111491", async() => {
                WriteLiteral(@"
                        <input type=""text"" id=""appendedInputButton"" class=""input-block-level"" name=""s"" placeholder=""جستجو ..."">
                        <button type=""submit"">
                            <i class=""icon-search""></i>
                        </button>
                    ");
            }
            );
            __Microsoft_AspNetCore_Mvc_TagHelpers_FormTagHelper = CreateTagHelper<global::Microsoft.AspNetCore.Mvc.TagHelpers.FormTagHelper>();
            __tagHelperExecutionContext.Add(__Microsoft_AspNetCore_Mvc_TagHelpers_FormTagHelper);
            __Microsoft_AspNetCore_Mvc_TagHelpers_RenderAtEndOfFormTagHelper = CreateTagHelper<global::Microsoft.AspNetCore.Mvc.TagHelpers.RenderAtEndOfFormTagHelper>();
            __tagHelperExecutionContext.Add(__Microsoft_AspNetCore_Mvc_TagHelpers_RenderAtEndOfFormTagHelper);
            __tagHelperExecutionContext.AddHtmlAttribute(__tagHelperAttribute_0);
            __tagHelperExecutionContext.AddHtmlAttribute(__tagHelperAttribute_1);
            __tagHelperExecutionContext.AddHtmlAttribute(__tagHelperAttribute_2);
            __Microsoft_AspNetCore_Mvc_TagHelpers_FormTagHelper.Method = (string)__tagHelperAttribute_3.Value;
            __tagHelperExecutionContext.AddTagHelperAttribute(__tagHelperAttribute_3);
            __tagHelperExecutionContext.AddHtmlAttribute(__tagHelperAttribute_4);
            await __tagHelperRunner.RunAsync(__tagHelperExecutionContext);
            if (!__tagHelperExecutionContext.Output.IsContentModified)
            {
                await __tagHelperExecutionContext.SetOutputContentAsync();
            }
            Write(__tagHelperExecutionContext.Output);
            __tagHelperExecutionContext = __tagHelperScopeManager.End();
            WriteLiteral(@"
                </div>


                <!--  ==========  -->
                <!--  = Archive =  -->
                <!--  ==========  -->
                <div class=""sidebar-item widget_archive"">
                    <div class=""underlined"">
                        <h3><span class=""light"">آرشیو</span>نوشته های بلاگ</h3>
                    </div>

                    <ul>
                        <li><a title=""February 2013"" href=""http://localhost/themeforest/wp-theme/2013/02/"">بهمن 92</a>&nbsp;(2)</li>
                        <li><a title=""September 2008"" href=""http://localhost/themeforest/wp-theme/2008/09/"">مهر 92</a>&nbsp;(3)</li>
                        <li><a title=""June 2008"" href=""http://localhost/themeforest/wp-theme/2008/06/"">مرداد 92</a>&nbsp;(10)</li>
                        <li><a title=""May 2008"" href=""http://localhost/themeforest/wp-theme/2008/05/"">تیر 92</a>&nbsp;(5)</li>
                        <li><a title=""April 2008"" href=""http://localhost/themeforest/wp-theme/2008/04/"">ار");
            WriteLiteral(@"دیهبشت 91</a>&nbsp;(1)</li>
                        <li><a title=""March 2008"" href=""http://localhost/themeforest/wp-theme/2008/03/"">فروردین 91</a>&nbsp;(3)</li>
                    </ul>
                </div>

            </aside> <!-- /sidebar -->

        </div>
    </div>
</div>

");
            DefineSection("scripts", async() => {
                WriteLiteral(@"
    <script>
        var commentId = 0;
        var commenterName = """";
        var visitingParent = 0;

        $(document).ready(function () {
            $("".btnAnswer"").click(function (e) {
                commentId = this.getAttribute(""commentId"");
                commenterName = this.getAttribute(""commenterName"");
                visitingParent = this.getAttribute(""visitingParent"");
                document.getElementById(""answerTo"").innerHTML = ""پاسخ به "" + commenterName;
                debugger;
            });

            $(""#btnSendComment"").click(function () {
                var commentData = new FormData();

                commentData.append(""Name"", $(""#name"").val());
                commentData.append(""Email"", $(""#email"").val());
                commentData.append(""Text"", $(""#text"").val());
                commentData.append(""PageId"", ");
#nullable restore
#line 162 "E:\asp.net projects\MyMarket\Market.EndPoint\Views\Blog\ShowBlogPages.cshtml"
                                        Write(Model.Id);

#line default
#line hidden
#nullable disable
                WriteLiteral(@");
                commentData.append(""ParentId"", commentId);
                commentData.append(""VisitingParent"", visitingParent)

                $.ajax({
                    type: ""POST"",
                    processData: false,
                    contentType: false,
                    cache: false,
                    url: ""/Blog/CreateComment"",
                    data: commentData,
                    success: function (response) {
                        location.reload();
                    }
                });
            });
        });
    </script>
");
            }
            );
            WriteLiteral("\r\n");
        }
        #pragma warning restore 1998
        [global::Microsoft.AspNetCore.Mvc.Razor.Internal.RazorInjectAttribute]
        public IClientBlogPageFacad _clientBlogPageFacad { get; private set; }
        [global::Microsoft.AspNetCore.Mvc.Razor.Internal.RazorInjectAttribute]
        public ICommonOptionFacad _commonOptionFacad { get; private set; }
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
