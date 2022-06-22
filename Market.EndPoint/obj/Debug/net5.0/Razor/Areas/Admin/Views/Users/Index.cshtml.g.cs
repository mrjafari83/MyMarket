#pragma checksum "C:\Users\Kar1\Desktop\MyMarket\Market.EndPoint\Areas\Admin\Views\Users\Index.cshtml" "{ff1816ec-aa5e-4d10-87f7-6f4963833460}" "0962b97f7b7de3ed146861f5331f4c92b04728f6"
// <auto-generated/>
#pragma warning disable 1591
[assembly: global::Microsoft.AspNetCore.Razor.Hosting.RazorCompiledItemAttribute(typeof(AspNetCore.Areas_Admin_Views_Users_Index), @"mvc.1.0.view", @"/Areas/Admin/Views/Users/Index.cshtml")]
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
#line 1 "C:\Users\Kar1\Desktop\MyMarket\Market.EndPoint\Areas\Admin\Views\Users\Index.cshtml"
using Common.ViewModels;

#line default
#line hidden
#nullable disable
    [global::Microsoft.AspNetCore.Razor.Hosting.RazorSourceChecksumAttribute(@"SHA1", @"0962b97f7b7de3ed146861f5331f4c92b04728f6", @"/Areas/Admin/Views/Users/Index.cshtml")]
    public class Areas_Admin_Views_Users_Index : global::Microsoft.AspNetCore.Mvc.Razor.RazorPage<List<UserViewModel>>
    {
        #pragma warning disable 1998
        public async override global::System.Threading.Tasks.Task ExecuteAsync()
        {
#nullable restore
#line 3 "C:\Users\Kar1\Desktop\MyMarket\Market.EndPoint\Areas\Admin\Views\Users\Index.cshtml"
  
    ViewData["Title"] = "Index";
    Layout = "~/Areas/Admin/Views/Shared/_AdminLayout.cshtml";

#line default
#line hidden
#nullable disable
            WriteLiteral(@"
<table>
    <thead>
        <tr>
            <a class=""waves-effect waves-light btn modal-trigger green"" href=""#modal1"" id=""btnCreateUser"">افزودن</a>
        </tr>
        <tr>
            <th>نام کاربری</th>
            <th>ایمیل</th>
            <th>مقام</th>
            <th></th>
        </tr>
    </thead>
    <tbody>
");
#nullable restore
#line 21 "C:\Users\Kar1\Desktop\MyMarket\Market.EndPoint\Areas\Admin\Views\Users\Index.cshtml"
         foreach (var item in Model)
        {

#line default
#line hidden
#nullable disable
            WriteLiteral("            <tr>\r\n                <td>");
#nullable restore
#line 24 "C:\Users\Kar1\Desktop\MyMarket\Market.EndPoint\Areas\Admin\Views\Users\Index.cshtml"
               Write(item.UserName);

#line default
#line hidden
#nullable disable
            WriteLiteral("</td>\r\n                <td>");
#nullable restore
#line 25 "C:\Users\Kar1\Desktop\MyMarket\Market.EndPoint\Areas\Admin\Views\Users\Index.cshtml"
               Write(item.Email);

#line default
#line hidden
#nullable disable
            WriteLiteral("</td>\r\n");
#nullable restore
#line 26 "C:\Users\Kar1\Desktop\MyMarket\Market.EndPoint\Areas\Admin\Views\Users\Index.cshtml"
                 switch (item.RoleName)
                {
                    case "Owner":
                        {

#line default
#line hidden
#nullable disable
            WriteLiteral("                            <td>مدیریت</td>\r\n");
#nullable restore
#line 31 "C:\Users\Kar1\Desktop\MyMarket\Market.EndPoint\Areas\Admin\Views\Users\Index.cshtml"
                            break;
                        }
                    case "Admin":
                        {

#line default
#line hidden
#nullable disable
            WriteLiteral("                            <td>ادمین</td>\r\n");
#nullable restore
#line 36 "C:\Users\Kar1\Desktop\MyMarket\Market.EndPoint\Areas\Admin\Views\Users\Index.cshtml"
                            break;
                        }
                    default:
                        {

#line default
#line hidden
#nullable disable
            WriteLiteral("                            <td>مشتری</td>\r\n");
#nullable restore
#line 41 "C:\Users\Kar1\Desktop\MyMarket\Market.EndPoint\Areas\Admin\Views\Users\Index.cshtml"
                            break;
                        }
                }

#line default
#line hidden
#nullable disable
            WriteLiteral("                <td>\r\n                    <a class=\"waves-effect waves-light btn modal-trigger blue btnAddRole\" href=\"#modal1\"");
            BeginWriteAttribute("userName", " userName=\"", 1351, "\"", 1376, 1);
#nullable restore
#line 45 "C:\Users\Kar1\Desktop\MyMarket\Market.EndPoint\Areas\Admin\Views\Users\Index.cshtml"
WriteAttributeValue("", 1362, item.UserName, 1362, 14, false);

#line default
#line hidden
#nullable disable
            EndWriteAttribute();
            WriteLiteral(">ویرایش مقام</a>\r\n                    <a class=\"waves-effect waves-light btn modal-trigger blue btnGetUserCartPayings\" href=\"#modal1\"");
            BeginWriteAttribute("userName", " userName=\"", 1510, "\"", 1535, 1);
#nullable restore
#line 46 "C:\Users\Kar1\Desktop\MyMarket\Market.EndPoint\Areas\Admin\Views\Users\Index.cshtml"
WriteAttributeValue("", 1521, item.UserName, 1521, 14, false);

#line default
#line hidden
#nullable disable
            EndWriteAttribute();
            WriteLiteral(">سبد های خرید</a>\r\n                    <a class=\"waves-effect waves-light btn modal-trigger red btnDelete\" href=\"#modal1\"");
            BeginWriteAttribute("userName", " userName=\"", 1657, "\"", 1682, 1);
#nullable restore
#line 47 "C:\Users\Kar1\Desktop\MyMarket\Market.EndPoint\Areas\Admin\Views\Users\Index.cshtml"
WriteAttributeValue("", 1668, item.UserName, 1668, 14, false);

#line default
#line hidden
#nullable disable
            EndWriteAttribute();
            WriteLiteral(">حذف</a>\r\n                </td>\r\n            </tr>\r\n");
#nullable restore
#line 50 "C:\Users\Kar1\Desktop\MyMarket\Market.EndPoint\Areas\Admin\Views\Users\Index.cshtml"
        }

#line default
#line hidden
#nullable disable
            WriteLiteral("    </tbody>\r\n</table>\r\n\r\n<!-- Modal Structure -->\r\n<div id=\"modal1\" class=\"modal\">\r\n    <div class=\"modal-content\">\r\n        <h4 id=\"title\">Modal Header</h4>\r\n        <p id=\"body\">A bunch of text</p>\r\n    </div>\r\n</div>\r\n\r\n");
            DefineSection("scripts", async() => {
                WriteLiteral(@"
    <script>
        $(""#btnCreateUser"").click(function () {

            $.get(""/Admin/Users/Create"", function (result) {

                $(""#title"").html(""افزودن  کاربر جدید"");
                $(""#body"").html(result);
            });

        });

        $("".btnDelete"").click(function (e) {
            var userName = this.getAttribute(""userName"");
            $.get(""/Admin/Users/Delete?userName="" + userName, function (result) {

                $(""#title"").html(""حذف  کاربر "");
                $(""#body"").html(result);
            });
        });

        $("".btnAddRole"").click(function (e) {
            var userName = this.getAttribute(""userName"");
            $.get(""/Admin/Users/EditUserRoles?userName="" + userName, function (result) {

                $(""#title"").html(""تغییر مقام کاربر"");
                $(""#body"").html(result);
            });
        });

        $("".btnGetUserCartPayings"").click(function (e) {
            var userName = this.getAttribute(""userName"");
  ");
                WriteLiteral("          $.get(\"/Admin/Users/GetUserCartPayings?userName=\" + userName, function (result) {\r\n\r\n                $(\"#title\").html(\"سبد خرید های کاربر\");\r\n                $(\"#body\").html(result);\r\n            });\r\n        });\r\n    </script>\r\n");
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
        public global::Microsoft.AspNetCore.Mvc.Rendering.IHtmlHelper<List<UserViewModel>> Html { get; private set; }
    }
}
#pragma warning restore 1591
