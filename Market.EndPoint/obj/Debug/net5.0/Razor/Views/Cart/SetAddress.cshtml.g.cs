#pragma checksum "E:\asp.net projects\MyMarket\Market.EndPoint\Views\Cart\SetAddress.cshtml" "{ff1816ec-aa5e-4d10-87f7-6f4963833460}" "f084e7528b79e4cb01e7b6e29866f92ee6bdeb09"
// <auto-generated/>
#pragma warning disable 1591
[assembly: global::Microsoft.AspNetCore.Razor.Hosting.RazorCompiledItemAttribute(typeof(AspNetCore.Views_Cart_SetAddress), @"mvc.1.0.view", @"/Views/Cart/SetAddress.cshtml")]
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
    [global::Microsoft.AspNetCore.Razor.Hosting.RazorSourceChecksumAttribute(@"SHA1", @"f084e7528b79e4cb01e7b6e29866f92ee6bdeb09", @"/Views/Cart/SetAddress.cshtml")]
    [global::Microsoft.AspNetCore.Razor.Hosting.RazorSourceChecksumAttribute(@"SHA1", @"2d7024c64dc247eca8debc4ecf94246dff276bcd", @"/Views/_ViewImports.cshtml")]
    public class Views_Cart_SetAddress : global::Microsoft.AspNetCore.Mvc.Razor.RazorPage<dynamic>
    {
        private static readonly global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute __tagHelperAttribute_0 = new global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute("action", new global::Microsoft.AspNetCore.Html.HtmlString("/SetAddress"), global::Microsoft.AspNetCore.Razor.TagHelpers.HtmlAttributeValueStyle.DoubleQuotes);
        private static readonly global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute __tagHelperAttribute_1 = new global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute("method", "post", global::Microsoft.AspNetCore.Razor.TagHelpers.HtmlAttributeValueStyle.DoubleQuotes);
        private static readonly global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute __tagHelperAttribute_2 = new global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute("class", new global::Microsoft.AspNetCore.Html.HtmlString("form-horizontal form-checkout"), global::Microsoft.AspNetCore.Razor.TagHelpers.HtmlAttributeValueStyle.DoubleQuotes);
        private static readonly global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute __tagHelperAttribute_3 = new global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute("class", new global::Microsoft.AspNetCore.Html.HtmlString(" checkout-page"), global::Microsoft.AspNetCore.Razor.TagHelpers.HtmlAttributeValueStyle.DoubleQuotes);
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
        private global::Microsoft.AspNetCore.Mvc.Razor.TagHelpers.HeadTagHelper __Microsoft_AspNetCore_Mvc_Razor_TagHelpers_HeadTagHelper;
        private global::Microsoft.AspNetCore.Mvc.Razor.TagHelpers.BodyTagHelper __Microsoft_AspNetCore_Mvc_Razor_TagHelpers_BodyTagHelper;
        private global::Microsoft.AspNetCore.Mvc.TagHelpers.FormTagHelper __Microsoft_AspNetCore_Mvc_TagHelpers_FormTagHelper;
        private global::Microsoft.AspNetCore.Mvc.TagHelpers.RenderAtEndOfFormTagHelper __Microsoft_AspNetCore_Mvc_TagHelpers_RenderAtEndOfFormTagHelper;
        #pragma warning disable 1998
        public async override global::System.Threading.Tasks.Task ExecuteAsync()
        {
            WriteLiteral("\r\n");
#nullable restore
#line 2 "E:\asp.net projects\MyMarket\Market.EndPoint\Views\Cart\SetAddress.cshtml"
  
    Layout = null;

#line default
#line hidden
#nullable disable
            WriteLiteral("\r\n<!DOCTYPE html>\r\n\r\n<html class=\"js no-touch cssanimations csstransforms csstransforms3d csstransitions large-screen\"");
            BeginWriteAttribute("style", " style=\"", 147, "\"", 155, 0);
            EndWriteAttribute();
            WriteLiteral(">\r\n<!--<![endif]-->\r\n");
            __tagHelperExecutionContext = __tagHelperScopeManager.Begin("head", global::Microsoft.AspNetCore.Razor.TagHelpers.TagMode.StartTagAndEndTag, "f084e7528b79e4cb01e7b6e29866f92ee6bdeb095369", async() => {
                WriteLiteral("\r\n    <meta charset=\"utf-8\">\r\n    <title>Webmarket HTML Template - Checkout Step 2</title>\r\n    <meta name=\"viewport\" content=\"width=device-width, initial-scale=1.0\">\r\n    <meta name=\"description\"");
                BeginWriteAttribute("content", " content=\"", 379, "\"", 389, 0);
                EndWriteAttribute();
                WriteLiteral(@">
    <meta name=""author"" content=""ProteusThemes"">

    <!--  Google Fonts  -->
    <link href=""http://fonts.googleapis.com/css?family=Pacifico|Open+Sans:400,700,400italic,700italic&amp;subset=latin,latin-ext,greek"" rel=""stylesheet"" type=""text/css"">

    <!-- Twitter Bootstrap -->
    <link href=""/Market/stylesheets/bootstrap.css"" rel=""stylesheet"">
    <link href=""/Market/stylesheets/responsive.css"" rel=""stylesheet"">
    <!-- Slider Revolution -->
    <link rel=""stylesheet"" href=""/Market/js/rs-plugin/css/settings.css"" type=""text/css"">
    <!-- jQuery UI -->
    <link rel=""stylesheet"" href=""/Market/js/jquery-ui-1.10.3/css/smoothness/jquery-ui-1.10.3.custom.min.css"" type=""text/css"">
    <!-- PrettyPhoto -->
    <link rel=""stylesheet"" href=""/Market/js/prettyphoto/css/prettyPhoto.css"" type=""text/css"">
    <!-- main styles -->

    <link href=""/Market/stylesheets/main.css"" rel=""stylesheet"">



    <!-- Modernizr -->
    <script id=""facebook-jssdk"" src=""//connect.facebook.net/en_US/all.js#xfbm");
                WriteLiteral(@"l=1&amp;appId=126780447403102""></script>
    <script src=""js/modernizr.custom.56918.js""></script>

    <!-- Fav and touch icons -->
    <link rel=""apple-touch-icon-precomposed"" sizes=""144x144"" href=""/Market/images/apple-touch/144.png"">
    <link rel=""apple-touch-icon-precomposed"" sizes=""114x114"" href=""/Market/images/apple-touch/114.png"">
    <link rel=""apple-touch-icon-precomposed"" sizes=""72x72"" href=""/Market/images/apple-touch/72.png"">
    <link rel=""apple-touch-icon-precomposed"" href=""/Market/images/apple-touch/57.png"">
    <link rel=""shortcut icon"" href=""/Market/images/apple-touch/57.png"">
");
            }
            );
            __Microsoft_AspNetCore_Mvc_Razor_TagHelpers_HeadTagHelper = CreateTagHelper<global::Microsoft.AspNetCore.Mvc.Razor.TagHelpers.HeadTagHelper>();
            __tagHelperExecutionContext.Add(__Microsoft_AspNetCore_Mvc_Razor_TagHelpers_HeadTagHelper);
            await __tagHelperRunner.RunAsync(__tagHelperExecutionContext);
            if (!__tagHelperExecutionContext.Output.IsContentModified)
            {
                await __tagHelperExecutionContext.SetOutputContentAsync();
            }
            Write(__tagHelperExecutionContext.Output);
            __tagHelperExecutionContext = __tagHelperScopeManager.End();
            WriteLiteral("\r\n\r\n\r\n");
            __tagHelperExecutionContext = __tagHelperScopeManager.Begin("body", global::Microsoft.AspNetCore.Razor.TagHelpers.TagMode.StartTagAndEndTag, "f084e7528b79e4cb01e7b6e29866f92ee6bdeb098449", async() => {
                WriteLiteral(@"

    <div class=""master-wrapper"">



        <div class=""container"">
            <div class=""row"">

                <!--  ==========  -->
                <!--  = Main content =  -->
                <!--  ==========  -->
                <section class=""span12"">

                    <div class=""checkout-container"">
                        <div class=""row"">
                            <div class=""span10 offset1"">

                                <!--  ==========  -->
                                <!--  = Header =  -->
                                <!--  ==========  -->
                                <header>
                                    <div class=""row"">
                                        <div class=""span2"">
                                            <a href=""index.html""><img src=""/Market/images/logo-bw.png"" alt=""Webmarket Logo"" width=""48"" height=""48""></a>
                                        </div>
                                        <div class=""span6"">
     ");
                WriteLiteral(@"                                       <div class=""center-align"">
                                                <h1><span class=""light"">آدرس ارسال و</span> پرداخت</h1>
                                            </div>
                                        </div>
                                        <div class=""span2"">
                                            <div class=""right-align"">
                                                <img src=""/Market/images/buttons/security.jpg"" alt=""Security Sign"" width=""92"" height=""65"">
                                            </div>
                                        </div>
                                    </div>
                                </header>

                                <!--  ==========  -->
                                <!--  = Steps =  -->
                                <!--  ==========  -->
                                <div class=""checkout-steps"">
                                    <div class=""clearfix"">
     ");
                WriteLiteral(@"                                   <div class=""step done"">
                                            <div class=""step-badge""><i class=""icon-ok""></i></div>
                                            <a href=""checkout-step-1.html"">سبد خرید</a>
                                        </div>
                                        <div class=""step active"">
                                            <div class=""step-badge"">2</div>
                                            ارسال آدرس
                                        </div>
                                        <div class=""step"">
                                            <div class=""step-badge"">3</div>
                                            شیوه پرداخت
                                        </div>
                                        <div class=""step"">
                                            <div class=""step-badge"">4</div>
                                            تایید و پرداخت
                                        <");
                WriteLiteral(@"/div>
                                    </div>
                                </div> <!-- /steps -->
                                <!--  ==========  -->
                                <!--  = Shipping addr form =  -->
                                <!--  ==========  -->

                                ");
                __tagHelperExecutionContext = __tagHelperScopeManager.Begin("form", global::Microsoft.AspNetCore.Razor.TagHelpers.TagMode.StartTagAndEndTag, "f084e7528b79e4cb01e7b6e29866f92ee6bdeb0912272", async() => {
                    WriteLiteral(@"
                                    <div class=""control-group"">
                                        <label class=""control-label"" for=""firstName"">نام<span class=""red-clr bold"">*</span></label>
                                        <div class=""controls"">
                                            <input type=""text"" id=""firstName"" name=""Name"" class=""span4""");
                    BeginWriteAttribute("required", " required=\"", 5901, "\"", 5912, 0);
                    EndWriteAttribute();
                    WriteLiteral(@">
                                        </div>
                                    </div>
                                    <div class=""control-group"">
                                        <label class=""control-label"" for=""lastName"">نام خانوادگی<span class=""red-clr bold"">*</span></label>
                                        <div class=""controls"">
                                            <input type=""text"" id=""lastName"" name=""Family"" class=""span4""");
                    BeginWriteAttribute("required", " required=\"", 6382, "\"", 6393, 0);
                    EndWriteAttribute();
                    WriteLiteral(@">
                                        </div>
                                    </div>
                                    <div class=""control-group"">
                                        <label class=""control-label"" for=""telephone"">تلفن<span class=""red-clr bold"">*</span></label>
                                        <div class=""controls"">
                                            <input type=""tel"" id=""telephone"" name=""PhoneNumber"" class=""span4""");
                    BeginWriteAttribute("required", " required=\"", 6861, "\"", 6872, 0);
                    EndWriteAttribute();
                    WriteLiteral(@">
                                        </div>
                                    </div>
                                    <div class=""control-group"">
                                        <label class=""control-label"" for=""email"">ایمیل<span class=""red-clr bold"">*</span></label>
                                        <div class=""controls"">
                                            <input type=""email"" id=""email"" name=""Email"" class=""span4""");
                    BeginWriteAttribute("required", " required=\"", 7329, "\"", 7340, 0);
                    EndWriteAttribute();
                    WriteLiteral(@">
                                        </div>
                                    </div>
                                    <div class=""control-group"">
                                        <label class=""control-label"" for=""addr1"">ادرس<span class=""red-clr bold"">*</span></label>
                                        <div class=""controls"">
                                            <input type=""text"" id=""addr1"" name=""Address"" class=""span4""");
                    BeginWriteAttribute("required", " required=\"", 7797, "\"", 7808, 0);
                    EndWriteAttribute();
                    WriteLiteral(@">
                                        </div>
                                    </div>
                                    <div class=""control-group"">
                                        <label class=""control-label"" for=""zip"">کد پستی<span class=""red-clr bold"">*</span></label>
                                        <div class=""controls"">
                                            <input type=""text"" id=""zip"" name=""PostalCode"" class=""span4"">
                                        </div>
                                    </div>
                                    <hr>
                                    <p class=""right-align"">
                                        در مرحله بعدی شما شیوه پرداخت را انتخاب میکنید &nbsp; &nbsp;
                                        <input type=""submit"" value=""ادامه"" class=""btn btn-primary higher bold"">
                                    </p>

                                ");
                }
                );
                __Microsoft_AspNetCore_Mvc_TagHelpers_FormTagHelper = CreateTagHelper<global::Microsoft.AspNetCore.Mvc.TagHelpers.FormTagHelper>();
                __tagHelperExecutionContext.Add(__Microsoft_AspNetCore_Mvc_TagHelpers_FormTagHelper);
                __Microsoft_AspNetCore_Mvc_TagHelpers_RenderAtEndOfFormTagHelper = CreateTagHelper<global::Microsoft.AspNetCore.Mvc.TagHelpers.RenderAtEndOfFormTagHelper>();
                __tagHelperExecutionContext.Add(__Microsoft_AspNetCore_Mvc_TagHelpers_RenderAtEndOfFormTagHelper);
                __tagHelperExecutionContext.AddHtmlAttribute(__tagHelperAttribute_0);
                __Microsoft_AspNetCore_Mvc_TagHelpers_FormTagHelper.Method = (string)__tagHelperAttribute_1.Value;
                __tagHelperExecutionContext.AddTagHelperAttribute(__tagHelperAttribute_1);
                __tagHelperExecutionContext.AddHtmlAttribute(__tagHelperAttribute_2);
                await __tagHelperRunner.RunAsync(__tagHelperExecutionContext);
                if (!__tagHelperExecutionContext.Output.IsContentModified)
                {
                    await __tagHelperExecutionContext.SetOutputContentAsync();
                }
                Write(__tagHelperExecutionContext.Output);
                __tagHelperExecutionContext = __tagHelperScopeManager.End();
                WriteLiteral(@"
                            </div>
                        </div>
                    </div>


                </section> <!-- /main content -->

            </div>
        </div> <!-- /container -->




    </div> <!-- end of master-wrapper -->
    <!--  ==========  -->
    <!--  = JavaScript =  -->
    <!--  ==========  -->
    <!--  = FB =  -->

    <div id=""fb-root""></div>
    <script>
        (function (d, s, id) {
            var js, fjs = d.getElementsByTagName(s)[0];
            if (d.getElementById(id)) return;
            js = d.createElement(s); js.id = id;
            js.src = ""//connect.facebook.net/en_US/all.js#xfbml=1&appId=126780447403102"";
            fjs.parentNode.insertBefore(js, fjs);
        }(document, 'script', 'facebook-jssdk'));</script>


    <!--  = jQuery - CDN with local fallback =  -->
    <script type=""text/javascript"" src=""http://ajax.googleapis.com/ajax/libs/jquery/1.9.1/jquery.min.js""></script>
    <script type=""text/javascript"">
        if");
                WriteLiteral(@" (typeof jQuery == 'undefined') {
            document.write('<script src=""/Market/js/jquery.min.js""><\/script>');
        }
    </script>
    <script src=""/Market/js/jquery.min.js""></script>

    <!--  = _ =  -->
    <script src=""/Market/js/underscore/underscore-min.js"" type=""text/javascript""></script>

    <!--  = Bootstrap =  -->
    <script src=""/Market/js/bootstrap.min.js"" type=""text/javascript""></script>

    <!--  = Slider Revolution =  -->
    <script src=""/Market/js/rs-plugin/pluginsources/jquery.themepunch.plugins.min.js"" type=""text/javascript""></script>
    <script src=""/Market/js/rs-plugin/js/jquery.themepunch.revolution.min.js"" type=""text/javascript""></script>

    <!--  = CarouFredSel =  -->
    <script src=""/Market/js/jquery.carouFredSel-6.2.1-packed.js"" type=""text/javascript""></script>

    <!--  = jQuery UI =  -->
    <script src=""/Market/js/jquery-ui-1.10.3/js/jquery-ui-1.10.3.custom.min.js"" type=""text/javascript""></script>
    <script src=""/Market/js/jquery-ui-1.10.3/to");
                WriteLiteral(@"uch-fix.min.js"" type=""text/javascript""></script>

    <!--  = Isotope =  -->
    <script src=""/Market/js/isotope/jquery.isotope.min.js"" type=""text/javascript""></script>

    <!--  = Tour =  -->
    <script src=""/Market/js/bootstrap-tour/build/js/bootstrap-tour.min.js"" type=""text/javascript""></script>

    <!--  = PrettyPhoto =  -->
    <script src=""/Market/js/prettyphoto/js/jquery.prettyPhoto.js"" type=""text/javascript""></script>

    <!--  = Google Maps API =  -->
    <script type=""text/javascript"" src=""http://maps.google.com/maps/api/js?sensor=false""></script>
    <script type=""text/javascript"" src=""/Market/js/goMap/js/jquery.gomap-1.3.2.min.js""></script>

    <!--  = Custom JS =  -->
    <script src=""/Market/js/custom.js"" type=""text/javascript""></script>

");
            }
            );
            __Microsoft_AspNetCore_Mvc_Razor_TagHelpers_BodyTagHelper = CreateTagHelper<global::Microsoft.AspNetCore.Mvc.Razor.TagHelpers.BodyTagHelper>();
            __tagHelperExecutionContext.Add(__Microsoft_AspNetCore_Mvc_Razor_TagHelpers_BodyTagHelper);
            __tagHelperExecutionContext.AddHtmlAttribute(__tagHelperAttribute_3);
            await __tagHelperRunner.RunAsync(__tagHelperExecutionContext);
            if (!__tagHelperExecutionContext.Output.IsContentModified)
            {
                await __tagHelperExecutionContext.SetOutputContentAsync();
            }
            Write(__tagHelperExecutionContext.Output);
            __tagHelperExecutionContext = __tagHelperScopeManager.End();
            WriteLiteral("\r\n</html>\r\n");
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
