#pragma checksum "C:\Users\Kar1\Desktop\MyMarket\Market.EndPoint\Views\Autantication\Register.cshtml" "{ff1816ec-aa5e-4d10-87f7-6f4963833460}" "444c7f0ba234268a4c2e6f5eeae476b674c330db"
// <auto-generated/>
#pragma warning disable 1591
[assembly: global::Microsoft.AspNetCore.Razor.Hosting.RazorCompiledItemAttribute(typeof(AspNetCore.Views_Autantication_Register), @"mvc.1.0.view", @"/Views/Autantication/Register.cshtml")]
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
    [global::Microsoft.AspNetCore.Razor.Hosting.RazorSourceChecksumAttribute(@"SHA1", @"444c7f0ba234268a4c2e6f5eeae476b674c330db", @"/Views/Autantication/Register.cshtml")]
    [global::Microsoft.AspNetCore.Razor.Hosting.RazorSourceChecksumAttribute(@"SHA1", @"2d7024c64dc247eca8debc4ecf94246dff276bcd", @"/Views/_ViewImports.cshtml")]
    public class Views_Autantication_Register : global::Microsoft.AspNetCore.Mvc.Razor.RazorPage<dynamic>
    {
        #pragma warning disable 1998
        public async override global::System.Threading.Tasks.Task ExecuteAsync()
        {
            WriteLiteral("\r\n");
#nullable restore
#line 2 "C:\Users\Kar1\Desktop\MyMarket\Market.EndPoint\Views\Autantication\Register.cshtml"
  
    ViewData["Title"] = "Register";
    Layout = "~/Views/Shared/_Layout.cshtml";

#line default
#line hidden
#nullable disable
            WriteLiteral(@"<link href=""/Admin/assets/libs/sweetalert2/dist/sweetalert2.min.css"" rel=""stylesheet"" type=""text/css"">

<div style=""margin:5% auto; align-content:center;width:400px"">
    <div class=""modal-header"">
        <h3 id=""registerModalLabel""><span class=""light"">ثبت نام</span> در وبمارکت</h3>
    </div>
    <div class=""modal-body"">
        <div>
            <div class=""control-group"">
                <label class=""control-label hidden shown-ie8"" for=""userName"">نام کاربری</label>
                <div class=""controls"">
                    <input type=""text"" class=""input-block-level"" id=""userName"" placeholder=""نام کاربری"">
                </div>
            </div>
            <div class=""control-group"">
                <label class=""control-label hidden shown-ie8"" for=""email"">ایمیل</label>
                <div class=""controls"">
                    <input type=""email"" class=""input-block-level""  id=""email"" placeholder=""ایمیل"">
                </div>
            </div>
            <div class=""control-gro");
            WriteLiteral(@"up"">
                <label class=""control-label hidden shown-ie8"" for=""password"">رمز عبور</label>
                <div class=""controls"">
                    <input type=""password"" class=""input-block-level"" id=""password"" placeholder=""کلمه عبور"">
                </div>
            </div>
            <button id=""btnSend"" class=""btn btn-danger input-block-level bold higher"">
                ثبت نام
            </button>
        </div>
        <p class=""center-align push-down-0"">
            <a data-toggle=""modal"" role=""button""");
            BeginWriteAttribute("href", " href=\"", 1657, "\"", 1699, 2);
            WriteAttributeValue("", 1664, "/Login?returnUrl=", 1664, 17, true);
#nullable restore
#line 37 "C:\Users\Kar1\Desktop\MyMarket\Market.EndPoint\Views\Autantication\Register.cshtml"
WriteAttributeValue("", 1681, ViewBag.ReturnUrl, 1681, 18, false);

#line default
#line hidden
#nullable disable
            EndWriteAttribute();
            WriteLiteral(" data-dismiss=\"modal\">قبلا ثبت نام کرده اید؟</a>\r\n        </p>\r\n\r\n    </div>\r\n</div>\r\n\r\n");
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
                data.append(""UserName"", $(""#userName"").val());
                data.append(""Password"", $(""#password"").val());
                data.append(""Email"", $(""#email"").val());

                $.ajax({
                    type: ""POST"",
 ");
                WriteLiteral(@"                   processData: false,
                    contentType: false,
                    cache: false,
                    enctype: ""multipart/form-data"",
                    url: ""/Register"",
                    data: data,
                    success: function (response) {
                        if (response == true) {
                            swal(""موفق"", ""کاربر جدید،خوش آمدید."", ""success"")
                                .then((value) => {
                                    window.location.href = '");
#nullable restore
#line 76 "C:\Users\Kar1\Desktop\MyMarket\Market.EndPoint\Views\Autantication\Register.cshtml"
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
            WriteLiteral("\r\n");
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
