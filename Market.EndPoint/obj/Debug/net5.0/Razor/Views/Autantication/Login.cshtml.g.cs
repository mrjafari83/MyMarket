#pragma checksum "C:\Users\Kar1\Desktop\MyMarket\Market.EndPoint\Views\Autantication\Login.cshtml" "{ff1816ec-aa5e-4d10-87f7-6f4963833460}" "2536e61925897b3b8c66a10f2c5794b2f65c9c2e"
// <auto-generated/>
#pragma warning disable 1591
[assembly: global::Microsoft.AspNetCore.Razor.Hosting.RazorCompiledItemAttribute(typeof(AspNetCore.Views_Autantication_Login), @"mvc.1.0.view", @"/Views/Autantication/Login.cshtml")]
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
    [global::Microsoft.AspNetCore.Razor.Hosting.RazorSourceChecksumAttribute(@"SHA1", @"2536e61925897b3b8c66a10f2c5794b2f65c9c2e", @"/Views/Autantication/Login.cshtml")]
    [global::Microsoft.AspNetCore.Razor.Hosting.RazorSourceChecksumAttribute(@"SHA1", @"2d7024c64dc247eca8debc4ecf94246dff276bcd", @"/Views/_ViewImports.cshtml")]
    public class Views_Autantication_Login : global::Microsoft.AspNetCore.Mvc.Razor.RazorPage<dynamic>
    {
        #pragma warning disable 1998
        public async override global::System.Threading.Tasks.Task ExecuteAsync()
        {
#nullable restore
#line 1 "C:\Users\Kar1\Desktop\MyMarket\Market.EndPoint\Views\Autantication\Login.cshtml"
  
    ViewData["Title"] = "Login";
    Layout = "~/Views/Shared/_Layout.cshtml";

#line default
#line hidden
#nullable disable
            WriteLiteral(@"<link href=""/Admin/assets/libs/sweetalert2/dist/sweetalert2.min.css"" rel=""stylesheet"" type=""text/css"">

<div style=""align-content: center; margin: 5% auto; width: 400px"">
    <div class=""modal-header"">
        <h3 id=""loginModalLabel""><span class=""light"">ورود</span> در وبمارکت</h3>
    </div>
    <div class=""modal-body"">
        <div>
            <div class=""control-group"">
                <label class=""control-label hidden shown-ie8"" for=""username"">نام کاربری</label>
                <div class=""controls"">
                    <input type=""text"" class=""input-block-level"" placeholder=""نام کاربری"" id=""userName"">
                </div>
            </div>
            <div class=""control-group"">
                <label class=""control-label hidden shown-ie8"" for=""password"">رمز عبور</label>
                <div class=""controls"">
                    <input type=""password"" class=""input-block-level"" placeholder=""کلمه عبور"" id=""Password"">
                </div>
            </div>
            <div class");
            WriteLiteral(@"=""control-group"">
                <div class=""controls"">
                    <label class=""checkbox"">
                        <input type=""checkbox"" id=""RememberMe"" name=""RememberMe"">
                        مرا به خاطر بسپار
                    </label>
                </div>
            </div>
            <button id=""btnSend"" class=""btn btn-primary input-block-level bold higher"">
                ورود
            </button>
        </div>
        <p class=""center-align push-down-0"">
            <a href=""#"" data-dismiss=""modal"">رمز عبورتان را فراموش کرده اید؟</a>
        </p>
    </div>
</div>

");
            DefineSection("scripts", async() => {
                WriteLiteral(@"
    <!-- ============================================================== -->
    <!-- All Required js -->
    <!-- ============================================================== -->
    <script src=""/Admin/assets/libs/jquery/dist/jquery.min.js""></script>
    <script src=""/Admin/dist/js/materialize.min.js""></script>
    <!-- ============================================================== -->
    <!-- This page plugin js -->
    <!-- ============================================================== -->
    <script src=""/Admin/assets/libs/sweetalert2/dist/sweetalert2.min.js""></script>

    <script>
        $(document).ready(function () {
            //Success Message
            $('#btnSend').click(function () {
                var data = new FormData();
                var rememberMe = false;
                if ($(""#RememberMe"").is("":checked"")){
                    rememberMe = true;
                }

                data.append(""UserName"", $(""#userName"").val());
                data.append(""");
                WriteLiteral(@"Password"", $(""#Password"").val());
                data.append(""RememberMe"", rememberMe);

                $.ajax({
                    type: ""POST"",
                    processData: false,
                    contentType: false,
                    cache: false,
                    enctype: ""multipart/form-data"",
                    url: ""/Login"",
                    data: data,
                    success: function (response) {
                        if (response == true) {
                            swal(""موفق"", ""خوش آمدید."", ""success"")
                                .then((value) => {
                                    window.location.href = '");
#nullable restore
#line 81 "C:\Users\Kar1\Desktop\MyMarket\Market.EndPoint\Views\Autantication\Login.cshtml"
                                                       Write(ViewBag.ReturnUrl);

#line default
#line hidden
#nullable disable
                WriteLiteral(@"';
                                });
                        }
                        else {
                            swal(""خطا"", ""خطایی رخ داده است. لطفا مجددا امتحان کنید."", ""warning"")
                                .then((value) => {
                                    location.reload();
                                }
                                )
                        }
                    }
                });
            });
        });
    </script>
");
            }
            );
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
