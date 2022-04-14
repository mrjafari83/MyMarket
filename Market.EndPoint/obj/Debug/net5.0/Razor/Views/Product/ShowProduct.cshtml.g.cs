#pragma checksum "E:\asp.net projects\MyMarket\Market.EndPoint\Views\Product\ShowProduct.cshtml" "{ff1816ec-aa5e-4d10-87f7-6f4963833460}" "18dcbed0b9313e2b2d2f411bc8b8902eb2d57bc0"
// <auto-generated/>
#pragma warning disable 1591
[assembly: global::Microsoft.AspNetCore.Razor.Hosting.RazorCompiledItemAttribute(typeof(AspNetCore.Views_Product_ShowProduct), @"mvc.1.0.view", @"/Views/Product/ShowProduct.cshtml")]
namespace AspNetCore
{
    #line hidden
    using System;
    using System.Collections.Generic;
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
#line 1 "E:\asp.net projects\MyMarket\Market.EndPoint\Views\Product\ShowProduct.cshtml"
using System.Linq;

#line default
#line hidden
#nullable disable
#nullable restore
#line 2 "E:\asp.net projects\MyMarket\Market.EndPoint\Views\Product\ShowProduct.cshtml"
using Application.Services.Common.Product.Queries.GetProductById;

#line default
#line hidden
#nullable disable
    [global::Microsoft.AspNetCore.Razor.Hosting.RazorSourceChecksumAttribute(@"SHA1", @"18dcbed0b9313e2b2d2f411bc8b8902eb2d57bc0", @"/Views/Product/ShowProduct.cshtml")]
    [global::Microsoft.AspNetCore.Razor.Hosting.RazorSourceChecksumAttribute(@"SHA1", @"2d7024c64dc247eca8debc4ecf94246dff276bcd", @"/Views/_ViewImports.cshtml")]
    public class Views_Product_ShowProduct : global::Microsoft.AspNetCore.Mvc.Razor.RazorPage<GetProductByIdDto>
    {
        private static readonly global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute __tagHelperAttribute_0 = new global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute("action", new global::Microsoft.AspNetCore.Html.HtmlString("/AddToCart"), global::Microsoft.AspNetCore.Razor.TagHelpers.HtmlAttributeValueStyle.DoubleQuotes);
        private static readonly global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute __tagHelperAttribute_1 = new global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute("class", new global::Microsoft.AspNetCore.Html.HtmlString("form form-inline clearfix"), global::Microsoft.AspNetCore.Razor.TagHelpers.HtmlAttributeValueStyle.DoubleQuotes);
        private static readonly global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute __tagHelperAttribute_2 = new global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute("method", "post", global::Microsoft.AspNetCore.Razor.TagHelpers.HtmlAttributeValueStyle.DoubleQuotes);
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
        private global::Microsoft.AspNetCore.Mvc.TagHelpers.OptionTagHelper __Microsoft_AspNetCore_Mvc_TagHelpers_OptionTagHelper;
        #pragma warning disable 1998
        public async override global::System.Threading.Tasks.Task ExecuteAsync()
        {
            WriteLiteral("\r\n");
#nullable restore
#line 5 "E:\asp.net projects\MyMarket\Market.EndPoint\Views\Product\ShowProduct.cshtml"
  
    ViewData["Title"] = "ShowProduct";
    Layout = "~/Views/Shared/_Layout.cshtml";

#line default
#line hidden
#nullable disable
            WriteLiteral(@"
<div class=""darker-stripe"">
    <div class=""container"">
        <div class=""row"">
            <div class=""span12"">
                <ul class=""breadcrumb"">
                    <li>
                        <a href=""index.html"">فروشگاه</a>
                    </li>
                    <li><span class=""icon-chevron-right""></span></li>
                    <li>
                        <a href=""shop.html"">");
#nullable restore
#line 20 "E:\asp.net projects\MyMarket\Market.EndPoint\Views\Product\ShowProduct.cshtml"
                                       Write(Model.CategoryName);

#line default
#line hidden
#nullable disable
            WriteLiteral("</a>\r\n                    </li>\r\n                    <li><span class=\"icon-chevron-right\"></span></li>\r\n                    <li>\r\n                        <a href=\"product.html\">");
#nullable restore
#line 24 "E:\asp.net projects\MyMarket\Market.EndPoint\Views\Product\ShowProduct.cshtml"
                                          Write(Model.Name);

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

        <!--  ==========  -->
        <!--  = Product =  -->
        <!--  ==========  -->
        <div class=""row blocks-spacer"">

            <!--  ==========  -->
            <!--  = Preview Images =  -->
            <!--  ==========  -->
            <div class=""span5"">
                <div class=""product-preview"">
                    <div class=""picture"">
                        <img");
            BeginWriteAttribute("src", " src=\"", 1423, "\"", 1449, 1);
#nullable restore
#line 46 "E:\asp.net projects\MyMarket\Market.EndPoint\Views\Product\ShowProduct.cshtml"
WriteAttributeValue("", 1429, Model.Images[0].Src, 1429, 20, false);

#line default
#line hidden
#nullable disable
            EndWriteAttribute();
            BeginWriteAttribute("alt", " alt=\"", 1450, "\"", 1456, 0);
            EndWriteAttribute();
            WriteLiteral(" width=\"940\" height=\"940\" id=\"mainPreviewImg\">\r\n                    </div>\r\n                    <div class=\"thumbs clearfix\">\r\n");
#nullable restore
#line 49 "E:\asp.net projects\MyMarket\Market.EndPoint\Views\Product\ShowProduct.cshtml"
                         foreach (var item in Model.Images)
                        {
                            if (item == Model.Images[0])
                            {

#line default
#line hidden
#nullable disable
            WriteLiteral("                                <div class=\"thumb active\">\r\n                                    <a href=\"#mainPreviewImg\"><img");
            BeginWriteAttribute("src", " src=\"", 1887, "\"", 1902, 1);
#nullable restore
#line 54 "E:\asp.net projects\MyMarket\Market.EndPoint\Views\Product\ShowProduct.cshtml"
WriteAttributeValue("", 1893, item.Src, 1893, 9, false);

#line default
#line hidden
#nullable disable
            EndWriteAttribute();
            BeginWriteAttribute("alt", " alt=\"", 1903, "\"", 1909, 0);
            EndWriteAttribute();
            WriteLiteral(" width=\"940\" height=\"940\"></a>\r\n                                </div>\r\n");
#nullable restore
#line 56 "E:\asp.net projects\MyMarket\Market.EndPoint\Views\Product\ShowProduct.cshtml"
                            }
                            else
                            {

#line default
#line hidden
#nullable disable
            WriteLiteral("                                <div class=\"thumb\">\r\n                                    <a href=\"#mainPreviewImg\"><img");
            BeginWriteAttribute("src", " src=\"", 2197, "\"", 2212, 1);
#nullable restore
#line 60 "E:\asp.net projects\MyMarket\Market.EndPoint\Views\Product\ShowProduct.cshtml"
WriteAttributeValue("", 2203, item.Src, 2203, 9, false);

#line default
#line hidden
#nullable disable
            EndWriteAttribute();
            BeginWriteAttribute("alt", " alt=\"", 2213, "\"", 2219, 0);
            EndWriteAttribute();
            WriteLiteral(" width=\"940\" height=\"940\"></a>\r\n                                </div>\r\n");
#nullable restore
#line 62 "E:\asp.net projects\MyMarket\Market.EndPoint\Views\Product\ShowProduct.cshtml"
                            }
                        }

#line default
#line hidden
#nullable disable
            WriteLiteral(@"                    </div>
                </div>
            </div>

            <!--  ==========  -->
            <!--  = Title and short desc =  -->
            <!--  ==========  -->
            <div class=""span7"">
                <div class=""product-title"">
                    <h1 class=""name"">");
#nullable restore
#line 73 "E:\asp.net projects\MyMarket\Market.EndPoint\Views\Product\ShowProduct.cshtml"
                                Write(Model.Name);

#line default
#line hidden
#nullable disable
            WriteLiteral("</h1>\r\n                    <div class=\"meta\">\r\n                        <span class=\"tag\">");
#nullable restore
#line 75 "E:\asp.net projects\MyMarket\Market.EndPoint\Views\Product\ShowProduct.cshtml"
                                     Write(Model.Price);

#line default
#line hidden
#nullable disable
            WriteLiteral(" تومان</span>\r\n                        <span class=\"stock\">\r\n");
#nullable restore
#line 77 "E:\asp.net projects\MyMarket\Market.EndPoint\Views\Product\ShowProduct.cshtml"
                             if (Model.Inventory != 0)
                            {

#line default
#line hidden
#nullable disable
            WriteLiteral("                                <span class=\"btn btn-success\">موجود</span>\r\n");
#nullable restore
#line 80 "E:\asp.net projects\MyMarket\Market.EndPoint\Views\Product\ShowProduct.cshtml"

                            }
                            else
                            {

#line default
#line hidden
#nullable disable
            WriteLiteral("                                <span class=\"btn btn-danger\">اتمام موجودی</span>\r\n");
#nullable restore
#line 85 "E:\asp.net projects\MyMarket\Market.EndPoint\Views\Product\ShowProduct.cshtml"

                            }

#line default
#line hidden
#nullable disable
            WriteLiteral("                        </span>\r\n                    </div>\r\n                </div>\r\n                <div class=\"product-description\">\r\n                    <p>\r\n                        ");
#nullable restore
#line 92 "E:\asp.net projects\MyMarket\Market.EndPoint\Views\Product\ShowProduct.cshtml"
                   Write(Model.ShortDescription);

#line default
#line hidden
#nullable disable
            WriteLiteral("\r\n                    </p>\r\n                    <hr>\r\n\r\n                    <!--  ==========  -->\r\n                    <!--  = Add to cart form =  -->\r\n                    <!--  ==========  -->\r\n                    ");
            __tagHelperExecutionContext = __tagHelperScopeManager.Begin("form", global::Microsoft.AspNetCore.Razor.TagHelpers.TagMode.StartTagAndEndTag, "18dcbed0b9313e2b2d2f411bc8b8902eb2d57bc012233", async() => {
                WriteLiteral("\r\n                        <div class=\"numbered\">\r\n");
#nullable restore
#line 101 "E:\asp.net projects\MyMarket\Market.EndPoint\Views\Product\ShowProduct.cshtml"
                               
                                var routeUrl = Url.RouteUrl(ViewContext.RouteData.Values);
                                var qsPath = ViewContext.HttpContext.Request.QueryString.Value;
                                var returnUrl = $"{routeUrl}{qsPath}";
                            

#line default
#line hidden
#nullable disable
                WriteLiteral("                            <input type=\"hidden\" name=\"productId\"");
                BeginWriteAttribute("value", " value=\"", 4144, "\"", 4161, 1);
#nullable restore
#line 106 "E:\asp.net projects\MyMarket\Market.EndPoint\Views\Product\ShowProduct.cshtml"
WriteAttributeValue("", 4152, Model.Id, 4152, 9, false);

#line default
#line hidden
#nullable disable
                EndWriteAttribute();
                WriteLiteral(" />\r\n                            <input type=\"hidden\" name=\"returnUrl\"");
                BeginWriteAttribute("value", " value=\"", 4232, "\"", 4250, 1);
#nullable restore
#line 107 "E:\asp.net projects\MyMarket\Market.EndPoint\Views\Product\ShowProduct.cshtml"
WriteAttributeValue("", 4240, returnUrl, 4240, 10, false);

#line default
#line hidden
#nullable disable
                EndWriteAttribute();
                WriteLiteral(@" />
                            <input type=""text"" name=""count"" value=""1"" class=""tiny-size"">
                            <span class=""clickable add-one icon-plus-sign-alt""></span>
                            <span class=""clickable remove-one icon-minus-sign-alt""></span>
                        </div>
                        &nbsp;
");
#nullable restore
#line 113 "E:\asp.net projects\MyMarket\Market.EndPoint\Views\Product\ShowProduct.cshtml"
                         if (Model.Colors.Count() != 0)
                        {

#line default
#line hidden
#nullable disable
                WriteLiteral("                            <select name=\"color\" class=\"span2\" id=\"colorSelector\">\r\n");
#nullable restore
#line 116 "E:\asp.net projects\MyMarket\Market.EndPoint\Views\Product\ShowProduct.cshtml"
                                 foreach (var color in Model.Colors)
                                {

#line default
#line hidden
#nullable disable
                WriteLiteral("                                    ");
                __tagHelperExecutionContext = __tagHelperScopeManager.Begin("option", global::Microsoft.AspNetCore.Razor.TagHelpers.TagMode.StartTagAndEndTag, "18dcbed0b9313e2b2d2f411bc8b8902eb2d57bc015013", async() => {
#nullable restore
#line 118 "E:\asp.net projects\MyMarket\Market.EndPoint\Views\Product\ShowProduct.cshtml"
                                                           Write(color.Name);

#line default
#line hidden
#nullable disable
                }
                );
                __Microsoft_AspNetCore_Mvc_TagHelpers_OptionTagHelper = CreateTagHelper<global::Microsoft.AspNetCore.Mvc.TagHelpers.OptionTagHelper>();
                __tagHelperExecutionContext.Add(__Microsoft_AspNetCore_Mvc_TagHelpers_OptionTagHelper);
                BeginWriteTagHelperAttribute();
#nullable restore
#line 118 "E:\asp.net projects\MyMarket\Market.EndPoint\Views\Product\ShowProduct.cshtml"
                                       WriteLiteral(color.Name);

#line default
#line hidden
#nullable disable
                __tagHelperStringValueBuffer = EndWriteTagHelperAttribute();
                __Microsoft_AspNetCore_Mvc_TagHelpers_OptionTagHelper.Value = __tagHelperStringValueBuffer;
                __tagHelperExecutionContext.AddTagHelperAttribute("value", __Microsoft_AspNetCore_Mvc_TagHelpers_OptionTagHelper.Value, global::Microsoft.AspNetCore.Razor.TagHelpers.HtmlAttributeValueStyle.DoubleQuotes);
                await __tagHelperRunner.RunAsync(__tagHelperExecutionContext);
                if (!__tagHelperExecutionContext.Output.IsContentModified)
                {
                    await __tagHelperExecutionContext.SetOutputContentAsync();
                }
                Write(__tagHelperExecutionContext.Output);
                __tagHelperExecutionContext = __tagHelperScopeManager.End();
                WriteLiteral("\r\n");
#nullable restore
#line 119 "E:\asp.net projects\MyMarket\Market.EndPoint\Views\Product\ShowProduct.cshtml"
                                }

#line default
#line hidden
#nullable disable
                WriteLiteral("                            </select>\r\n");
#nullable restore
#line 121 "E:\asp.net projects\MyMarket\Market.EndPoint\Views\Product\ShowProduct.cshtml"
                        }

#line default
#line hidden
#nullable disable
                WriteLiteral("                        &nbsp;\r\n");
#nullable restore
#line 123 "E:\asp.net projects\MyMarket\Market.EndPoint\Views\Product\ShowProduct.cshtml"
                         if (Model.Sizes.Count() != 0)
                        {

#line default
#line hidden
#nullable disable
                WriteLiteral("                            <select name=\"size\" class=\"span2\" id=\"sizeSelector\">\r\n");
#nullable restore
#line 126 "E:\asp.net projects\MyMarket\Market.EndPoint\Views\Product\ShowProduct.cshtml"
                                 foreach (var size in Model.Sizes)
                                {

#line default
#line hidden
#nullable disable
                WriteLiteral("                                    ");
                __tagHelperExecutionContext = __tagHelperScopeManager.Begin("option", global::Microsoft.AspNetCore.Razor.TagHelpers.TagMode.StartTagAndEndTag, "18dcbed0b9313e2b2d2f411bc8b8902eb2d57bc018135", async() => {
#nullable restore
#line 128 "E:\asp.net projects\MyMarket\Market.EndPoint\Views\Product\ShowProduct.cshtml"
                                                               Write(size.SizeValue);

#line default
#line hidden
#nullable disable
                }
                );
                __Microsoft_AspNetCore_Mvc_TagHelpers_OptionTagHelper = CreateTagHelper<global::Microsoft.AspNetCore.Mvc.TagHelpers.OptionTagHelper>();
                __tagHelperExecutionContext.Add(__Microsoft_AspNetCore_Mvc_TagHelpers_OptionTagHelper);
                BeginWriteTagHelperAttribute();
#nullable restore
#line 128 "E:\asp.net projects\MyMarket\Market.EndPoint\Views\Product\ShowProduct.cshtml"
                                       WriteLiteral(size.SizeValue);

#line default
#line hidden
#nullable disable
                __tagHelperStringValueBuffer = EndWriteTagHelperAttribute();
                __Microsoft_AspNetCore_Mvc_TagHelpers_OptionTagHelper.Value = __tagHelperStringValueBuffer;
                __tagHelperExecutionContext.AddTagHelperAttribute("value", __Microsoft_AspNetCore_Mvc_TagHelpers_OptionTagHelper.Value, global::Microsoft.AspNetCore.Razor.TagHelpers.HtmlAttributeValueStyle.DoubleQuotes);
                await __tagHelperRunner.RunAsync(__tagHelperExecutionContext);
                if (!__tagHelperExecutionContext.Output.IsContentModified)
                {
                    await __tagHelperExecutionContext.SetOutputContentAsync();
                }
                Write(__tagHelperExecutionContext.Output);
                __tagHelperExecutionContext = __tagHelperScopeManager.End();
                WriteLiteral("\r\n");
#nullable restore
#line 129 "E:\asp.net projects\MyMarket\Market.EndPoint\Views\Product\ShowProduct.cshtml"
                                }

#line default
#line hidden
#nullable disable
                WriteLiteral("                            </select>\r\n");
#nullable restore
#line 131 "E:\asp.net projects\MyMarket\Market.EndPoint\Views\Product\ShowProduct.cshtml"
                        }

#line default
#line hidden
#nullable disable
                WriteLiteral("                        <button class=\"btn btn-danger pull-right\"><i class=\"icon-shopping-cart\"></i> اضافه به سبد خرید</button>\r\n                    ");
            }
            );
            __Microsoft_AspNetCore_Mvc_TagHelpers_FormTagHelper = CreateTagHelper<global::Microsoft.AspNetCore.Mvc.TagHelpers.FormTagHelper>();
            __tagHelperExecutionContext.Add(__Microsoft_AspNetCore_Mvc_TagHelpers_FormTagHelper);
            __Microsoft_AspNetCore_Mvc_TagHelpers_RenderAtEndOfFormTagHelper = CreateTagHelper<global::Microsoft.AspNetCore.Mvc.TagHelpers.RenderAtEndOfFormTagHelper>();
            __tagHelperExecutionContext.Add(__Microsoft_AspNetCore_Mvc_TagHelpers_RenderAtEndOfFormTagHelper);
            __tagHelperExecutionContext.AddHtmlAttribute(__tagHelperAttribute_0);
            __tagHelperExecutionContext.AddHtmlAttribute(__tagHelperAttribute_1);
            __Microsoft_AspNetCore_Mvc_TagHelpers_FormTagHelper.Method = (string)__tagHelperAttribute_2.Value;
            __tagHelperExecutionContext.AddTagHelperAttribute(__tagHelperAttribute_2);
            await __tagHelperRunner.RunAsync(__tagHelperExecutionContext);
            if (!__tagHelperExecutionContext.Output.IsContentModified)
            {
                await __tagHelperExecutionContext.SetOutputContentAsync();
            }
            Write(__tagHelperExecutionContext.Output);
            __tagHelperExecutionContext = __tagHelperScopeManager.End();
            WriteLiteral(@"

                    <hr>

                    <!--  ==========  -->
                    <!--  = Share buttons =  -->
                    <!--  ==========  -->
                    <div class=""share-item"">
                        <div class=""pull-right social-networks"">
                            <!-- AddThis Button BEGIN -->
                            <div class=""addthis_toolbox addthis_default_style "">
                                <a class=""addthis_button_facebook_like"" fb:like:layout=""button_count""></a>
                                <a class=""addthis_button_tweet""></a>
                                <a class=""addthis_button_pinterest_pinit""></a>
                                <a class=""addthis_counter addthis_pill_style""></a>
                            </div>
                            <script type=""text/javascript"" src=""//s7.addthis.com/js/300/addthis_widget.js#pubid=xa-517459541beb3977""></script>
                            <!-- AddThis Button END -->
                        ");
            WriteLiteral(@"</div>
                        با دوستان خود به اشتراک بگذارید :
                    </div>

                </div>
            </div>
        </div>
    </div>

    <!--  ==========  -->
    <!--  = Tabs with more info =  -->
    <!--  ==========  -->
    <div class=""row"">
        <div class=""span12"">
            <ul id=""myTab"" class=""nav nav-tabs"">
                <li class=""active"">
                    <a href=""#tab-1"" data-toggle=""tab"">جزئیات</a>
                </li>
                <li>
                    <a href=""#tab-3"" data-toggle=""tab"">نظرات</a>
                </li>
                <li>
                    <a href=""#tab-4"" data-toggle=""tab"">جزئیات ارسال</a>
                </li>
            </ul>
            <div class=""tab-content"">
                <div class=""fade in tab-pane active"" id=""tab-1"">
                    <h3>توضیحات محصول</h3>
                    ");
#nullable restore
#line 179 "E:\asp.net projects\MyMarket\Market.EndPoint\Views\Product\ShowProduct.cshtml"
               Write(Html.Raw(Model.Description));

#line default
#line hidden
#nullable disable
            WriteLiteral("\r\n                    <h3>ویژگی های محصول</h3>\r\n                    <ul dir=\"rtl\">\r\n");
#nullable restore
#line 182 "E:\asp.net projects\MyMarket\Market.EndPoint\Views\Product\ShowProduct.cshtml"
                         foreach (var item in Model.Features)
                        {

#line default
#line hidden
#nullable disable
            WriteLiteral("                            <li dir=\"rtl\">\r\n                                ");
#nullable restore
#line 185 "E:\asp.net projects\MyMarket\Market.EndPoint\Views\Product\ShowProduct.cshtml"
                           Write(item.Display);

#line default
#line hidden
#nullable disable
            WriteLiteral(" : ");
#nullable restore
#line 185 "E:\asp.net projects\MyMarket\Market.EndPoint\Views\Product\ShowProduct.cshtml"
                                           Write(item.FeatureValue);

#line default
#line hidden
#nullable disable
            WriteLiteral("\r\n                            </li>\r\n");
#nullable restore
#line 187 "E:\asp.net projects\MyMarket\Market.EndPoint\Views\Product\ShowProduct.cshtml"
                        }

#line default
#line hidden
#nullable disable
            WriteLiteral("                    </ul>\r\n                </div>\r\n                <div class=\"fade tab-pane\" id=\"tab-3\">\r\n                    ");
#nullable restore
#line 191 "E:\asp.net projects\MyMarket\Market.EndPoint\Views\Product\ShowProduct.cshtml"
               Write(await Component.InvokeAsync("Comment" , new {pageId = Model.Id , categoryType = Common.Enums.Enums.CategoryType.Product }));

#line default
#line hidden
#nullable disable
            WriteLiteral(@"
                </div>
                <div class=""fade tab-pane"" id=""tab-4"">
                    <p>
                        لورم ایپسوم متنی است که ساختگی برای طراحی و چاپ آن مورد است. صنعت چاپ زمانی لازم بود شرایطی شما باید فکر ثبت نام و طراحی، لازمه خروج می باشد. در ضمن قاعده همفکری ها جوابگوی سئوالات زیاد شاید باشد، آنچنان که لازم بود طراحی گرافیکی خوب بود. کتابهای زیادی شرایط سخت ، دشوار و کمی در سالهای دور لازم است. هدف از این نسخه فرهنگ پس از آن و دستاوردهای خوب شاید باشد. حروفچینی لازم در شرایط فعلی لازمه تکنولوژی بود که گذشته، حال و آینده را شامل گردد. سی و پنج درصد از طراحان در قرن پانزدهم میبایست پرینتر در ستون و سطر حروف لازم است، بلکه شناخت این ابزار گاه اساسا بدون هدف بود و سئوالهای زیادی در گذشته بوجود می آید، تنها لازمه آن بود...
                    </p>
                </div>
            </div>
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
#line 225 "E:\asp.net projects\MyMarket\Market.EndPoint\Views\Product\ShowProduct.cshtml"
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
                    url: ""/Product/CreateComment"",
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
            WriteLiteral("\r\n\r\n");
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
        public global::Microsoft.AspNetCore.Mvc.Rendering.IHtmlHelper<GetProductByIdDto> Html { get; private set; }
    }
}
#pragma warning restore 1591
