#pragma checksum "E:\asp.net projects\MyMarket\Market.EndPoint\Areas\Admin\Views\Slider\Replace.cshtml" "{ff1816ec-aa5e-4d10-87f7-6f4963833460}" "90c62869ac4c625eb7c7584d668b0a4c0b719b98"
// <auto-generated/>
#pragma warning disable 1591
[assembly: global::Microsoft.AspNetCore.Razor.Hosting.RazorCompiledItemAttribute(typeof(AspNetCore.Areas_Admin_Views_Slider_Replace), @"mvc.1.0.view", @"/Areas/Admin/Views/Slider/Replace.cshtml")]
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
    [global::Microsoft.AspNetCore.Razor.Hosting.RazorSourceChecksumAttribute(@"SHA1", @"90c62869ac4c625eb7c7584d668b0a4c0b719b98", @"/Areas/Admin/Views/Slider/Replace.cshtml")]
    public class Areas_Admin_Views_Slider_Replace : global::Microsoft.AspNetCore.Mvc.Razor.RazorPage<dynamic>
    {
        #pragma warning disable 1998
        public async override global::System.Threading.Tasks.Task ExecuteAsync()
        {
#nullable restore
#line 1 "E:\asp.net projects\MyMarket\Market.EndPoint\Areas\Admin\Views\Slider\Replace.cshtml"
  
    ViewData["Title"] = "Replace";
    Layout = "~/Areas/Admin/Views/Shared/_AdminLayout.cshtml";

#line default
#line hidden
#nullable disable
            WriteLiteral(@"
<div class=""row"">
    <div class=""col s12"">
        <div class=""card"">
            <div class=""card-content"">
                <form class=""formValidate"" id=""formValidate"" novalidate=""novalidate"">
                    <div class=""row"">
                        <div class=""input-field col s12"">
                            <label for=""url""");
            BeginWriteAttribute("class", " class=\"", 452, "\"", 460, 0);
            EndWriteAttribute();
            WriteLiteral(@">مسیر(url)*</label>
                            <input id=""url"" name=""url"" type=""text"" data-error="".errorTxt1"">
                            <div class=""errorTxt1""></div>
                        </div>
                        <div class=""input-field col s12 file-field"">
                            <div class=""btn cyan"">
                                <span>تصویر</span>
                                <input type=""file"" id=""image"" name=""image"" data-error="".errorTxt2"">
                            </div>
                            <div class=""file-path-wrapper"">
                                <input class=""file-path validate"" type=""text"">
                            </div>
                            <div class=""errorTxt2""></div>
                        </div>

                        <div class=""input-field col s12"">
                            <button class=""btn waves-effect waves-light right submit green"" type=""submit"" name=""action"">افزودن</button>
                        </div>
          ");
            WriteLiteral("          </div>\r\n                </form>\r\n            </div>\r\n        </div>\r\n    </div>\r\n</div>\r\n\r\n");
            DefineSection("scripts", async() => {
                WriteLiteral(@"
    <script src=""/Admin/assets/extra-libs/prism/prism.js""></script>
    <script src=""/Admin/dist/js/pages/forms/jquery.validate.min.js""></script>
    <script>
        $(document).ready(function () {
            $(""#formValidate"").validate({
                rules: {
                    url: {
                        required: true,
                    },
                    image: {
                        required: true,
                    },
                },
                //For custom messages
                messages: {
                    url: {
                        required: ""یک مسیر وارد کنید."",
                    },
                    image: {
                        required: ""یک تصویر انتخاب کنید"",
                    },
                },
                errorElement: 'div',
                errorPlacement: function (error, element) {
                    var placement = $(element).data('error');
                    if (placement) {
                        $(placem");
                WriteLiteral(@"ent).append(error)
                    } else {
                        error.insertAfter(element);
                    }
                },
                submitHandler: function () {
                    debugger;

                    var formdata = new FormData();
                    formdata.append(""url"", $(""#url"").val());
                    formdata.append(""sliderId"", ");
#nullable restore
#line 76 "E:\asp.net projects\MyMarket\Market.EndPoint\Areas\Admin\Views\Slider\Replace.cshtml"
                                           Write(ViewBag.SliderId);

#line default
#line hidden
#nullable disable
                WriteLiteral(@");
                    formdata.append(""image"", document.getElementById(""image"").files[0]);

                    $.ajax({
                        type: ""POST"",
                        processData: false,
                        contentType: false,
                        cache: false,
                        enctype: ""multipart/form-data"",
                        url: ""/Admin/Slider/Replace"",
                        data: formdata,
                        success: function (response) {
                            window.location.href = ""/Admin/Slider"";
                        }
                    });
                }
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
