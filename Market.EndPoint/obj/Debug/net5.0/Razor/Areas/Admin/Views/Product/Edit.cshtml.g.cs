#pragma checksum "E:\asp.net projects\MyMarket\Market.EndPoint\Areas\Admin\Views\Product\Edit.cshtml" "{ff1816ec-aa5e-4d10-87f7-6f4963833460}" "1cb4bd85950fdc0148393b441407c6c6c36b689c"
// <auto-generated/>
#pragma warning disable 1591
[assembly: global::Microsoft.AspNetCore.Razor.Hosting.RazorCompiledItemAttribute(typeof(AspNetCore.Areas_Admin_Views_Product_Edit), @"mvc.1.0.view", @"/Areas/Admin/Views/Product/Edit.cshtml")]
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
#line 1 "E:\asp.net projects\MyMarket\Market.EndPoint\Areas\Admin\Views\Product\Edit.cshtml"
using Application.Services.Admin.Products.Queries.GetProductById;

#line default
#line hidden
#nullable disable
    [global::Microsoft.AspNetCore.Razor.Hosting.RazorSourceChecksumAttribute(@"SHA1", @"1cb4bd85950fdc0148393b441407c6c6c36b689c", @"/Areas/Admin/Views/Product/Edit.cshtml")]
    public class Areas_Admin_Views_Product_Edit : global::Microsoft.AspNetCore.Mvc.Razor.RazorPage<GetProductByIdDto>
    {
        private static readonly global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute __tagHelperAttribute_0 = new global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute("id", new global::Microsoft.AspNetCore.Html.HtmlString("categoryId"), global::Microsoft.AspNetCore.Razor.TagHelpers.HtmlAttributeValueStyle.DoubleQuotes);
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
        private global::Microsoft.AspNetCore.Mvc.TagHelpers.SelectTagHelper __Microsoft_AspNetCore_Mvc_TagHelpers_SelectTagHelper;
        private global::Microsoft.AspNetCore.Mvc.TagHelpers.OptionTagHelper __Microsoft_AspNetCore_Mvc_TagHelpers_OptionTagHelper;
        #pragma warning disable 1998
        public async override global::System.Threading.Tasks.Task ExecuteAsync()
        {
#nullable restore
#line 4 "E:\asp.net projects\MyMarket\Market.EndPoint\Areas\Admin\Views\Product\Edit.cshtml"
  
    ViewData["Title"] = "Edit";
    Layout = "~/Areas/Admin/Views/Shared/_AdminLayout.cshtml";

#line default
#line hidden
#nullable disable
            WriteLiteral("\r\n<div class=\"card\">\r\n    <div class=\"card-content\">\r\n        <div class=\"class=\" input-field\">\r\n            ");
            __tagHelperExecutionContext = __tagHelperScopeManager.Begin("select", global::Microsoft.AspNetCore.Razor.TagHelpers.TagMode.StartTagAndEndTag, "1cb4bd85950fdc0148393b441407c6c6c36b689c3696", async() => {
                WriteLiteral("\r\n                ");
                __tagHelperExecutionContext = __tagHelperScopeManager.Begin("option", global::Microsoft.AspNetCore.Razor.TagHelpers.TagMode.StartTagAndEndTag, "1cb4bd85950fdc0148393b441407c6c6c36b689c3972", async() => {
                    WriteLiteral("یک دسته بندی را انتخاب کنید");
                }
                );
                __Microsoft_AspNetCore_Mvc_TagHelpers_OptionTagHelper = CreateTagHelper<global::Microsoft.AspNetCore.Mvc.TagHelpers.OptionTagHelper>();
                __tagHelperExecutionContext.Add(__Microsoft_AspNetCore_Mvc_TagHelpers_OptionTagHelper);
                BeginWriteTagHelperAttribute();
                __tagHelperStringValueBuffer = EndWriteTagHelperAttribute();
                __tagHelperExecutionContext.AddHtmlAttribute("disabled", Html.Raw(__tagHelperStringValueBuffer), global::Microsoft.AspNetCore.Razor.TagHelpers.HtmlAttributeValueStyle.Minimized);
                BeginWriteTagHelperAttribute();
                __tagHelperStringValueBuffer = EndWriteTagHelperAttribute();
                __tagHelperExecutionContext.AddHtmlAttribute("selected", Html.Raw(__tagHelperStringValueBuffer), global::Microsoft.AspNetCore.Razor.TagHelpers.HtmlAttributeValueStyle.Minimized);
                await __tagHelperRunner.RunAsync(__tagHelperExecutionContext);
                if (!__tagHelperExecutionContext.Output.IsContentModified)
                {
                    await __tagHelperExecutionContext.SetOutputContentAsync();
                }
                Write(__tagHelperExecutionContext.Output);
                __tagHelperExecutionContext = __tagHelperScopeManager.End();
                WriteLiteral("\r\n            ");
            }
            );
            __Microsoft_AspNetCore_Mvc_TagHelpers_SelectTagHelper = CreateTagHelper<global::Microsoft.AspNetCore.Mvc.TagHelpers.SelectTagHelper>();
            __tagHelperExecutionContext.Add(__Microsoft_AspNetCore_Mvc_TagHelpers_SelectTagHelper);
            __tagHelperExecutionContext.AddHtmlAttribute(__tagHelperAttribute_0);
#nullable restore
#line 12 "E:\asp.net projects\MyMarket\Market.EndPoint\Areas\Admin\Views\Product\Edit.cshtml"
__Microsoft_AspNetCore_Mvc_TagHelpers_SelectTagHelper.Items = ViewBag.Categories;

#line default
#line hidden
#nullable disable
            __tagHelperExecutionContext.AddTagHelperAttribute("asp-items", __Microsoft_AspNetCore_Mvc_TagHelpers_SelectTagHelper.Items, global::Microsoft.AspNetCore.Razor.TagHelpers.HtmlAttributeValueStyle.DoubleQuotes);
            await __tagHelperRunner.RunAsync(__tagHelperExecutionContext);
            if (!__tagHelperExecutionContext.Output.IsContentModified)
            {
                await __tagHelperExecutionContext.SetOutputContentAsync();
            }
            Write(__tagHelperExecutionContext.Output);
            __tagHelperExecutionContext = __tagHelperScopeManager.End();
            WriteLiteral("\r\n            <label>دسته بندی ها</label>\r\n        </div>\r\n\r\n        <div class=\"row\">\r\n            <div class=\"input-field col s6\">\r\n                <input type=\"text\" class=\"validate\" id=\"name\"");
            BeginWriteAttribute("value", " value=\"", 714, "\"", 733, 1);
#nullable restore
#line 20 "E:\asp.net projects\MyMarket\Market.EndPoint\Areas\Admin\Views\Product\Edit.cshtml"
WriteAttributeValue("", 722, Model.Name, 722, 11, false);

#line default
#line hidden
#nullable disable
            EndWriteAttribute();
            WriteLiteral(">\r\n                <label class=\"active\">نام کالا : </label>\r\n            </div>\r\n        </div>\r\n        <div class=\"row\">\r\n            <div class=\"input-field col s6\">\r\n                <input id=\"brand\" type=\"text\" class=\"validate\"");
            BeginWriteAttribute("value", " value=\"", 967, "\"", 987, 1);
#nullable restore
#line 26 "E:\asp.net projects\MyMarket\Market.EndPoint\Areas\Admin\Views\Product\Edit.cshtml"
WriteAttributeValue("", 975, Model.Brand, 975, 12, false);

#line default
#line hidden
#nullable disable
            EndWriteAttribute();
            WriteLiteral(">\r\n                <label class=\"active\">برند : </label>\r\n            </div>\r\n        </div>\r\n        <div class=\"row\">\r\n            <div class=\"input-field col s6\">\r\n                <input id=\"shortDescription\" type=\"text\" class=\"validate\"");
            BeginWriteAttribute("value", " value=\"", 1228, "\"", 1259, 1);
#nullable restore
#line 32 "E:\asp.net projects\MyMarket\Market.EndPoint\Areas\Admin\Views\Product\Edit.cshtml"
WriteAttributeValue("", 1236, Model.ShortDescription, 1236, 23, false);

#line default
#line hidden
#nullable disable
            EndWriteAttribute();
            WriteLiteral(@">
                <label class=""active"">توضیحات مختصر : </label>
            </div>
        </div>
        <div class=""row"">
            <div class=""input-field col s12"">
                <textarea id=""description"" class=""validate""></textarea>
            </div>
        </div>
        <div class=""row"">
            <div class=""input-field col s12"">
                <input type=""number"" id=""price"" class=""materialize-textarea""");
            BeginWriteAttribute("value", " value=\"", 1696, "\"", 1716, 1);
#nullable restore
#line 43 "E:\asp.net projects\MyMarket\Market.EndPoint\Areas\Admin\Views\Product\Edit.cshtml"
WriteAttributeValue("", 1704, Model.Price, 1704, 12, false);

#line default
#line hidden
#nullable disable
            EndWriteAttribute();
            WriteLiteral(">\r\n                <label for=\"textarea1\">قیمت : </label>\r\n            </div>\r\n        </div>\r\n        <div class=\"row\">\r\n            <div class=\"input-field col s12\">\r\n                <input type=\"number\" id=\"inventory\" class=\"materialize-textarea\"");
            BeginWriteAttribute("value", " value=\"", 1966, "\"", 1990, 1);
#nullable restore
#line 49 "E:\asp.net projects\MyMarket\Market.EndPoint\Areas\Admin\Views\Product\Edit.cshtml"
WriteAttributeValue("", 1974, Model.Inventory, 1974, 16, false);

#line default
#line hidden
#nullable disable
            EndWriteAttribute();
            WriteLiteral(@">
                <label for=""textarea1"">تعداد موجود : </label>
            </div>
        </div>
        <div class=""row"">
            <div class=""col s12"">
                <div class=""file-field input-field"">
                    <div class=""btn cyan"">
                        <span>تصاویر</span>
                        <input type=""file"" id=""images"" multiple accept=""image/*"">
                    </div>
                    <div class=""file-path-wrapper"">
                        <input class=""file-path validate"" type=""text"">
                    </div>
                </div>
            </div>
        </div>
    </div>
</div>

<div class=""row"" style=""margin:10px 0px"">
    <div class=""col s12"">
        <div class=""card"">
            <div class=""card-content"">
                <div class=""input-field"">
                    <input type=""text"" id=""keywordValue"" class=""validate"" />
                    <label class=""active"">کلمه کلیدی : </label>
                    <button class=""btn green wa");
            WriteLiteral(@"ves-effect waves-light right"" id=""btnCreateKeyword"">
                        افزودن
                    </button>
                </div>

                <br />
                <table class=""highlight"">
                    <thead>
                        <tr>
                            <th>کلمه کلیدی</th>
                        </tr>
                    </thead>
                    <tbody id=""keywordTable"">
");
#nullable restore
#line 89 "E:\asp.net projects\MyMarket\Market.EndPoint\Areas\Admin\Views\Product\Edit.cshtml"
                         if (Model.Keywords != null)
                        {
                            foreach (var item in Model.Keywords)
                            {

#line default
#line hidden
#nullable disable
            WriteLiteral("                                <tr>\r\n                                    <td>");
#nullable restore
#line 94 "E:\asp.net projects\MyMarket\Market.EndPoint\Areas\Admin\Views\Product\Edit.cshtml"
                                   Write(item.KeywordValue);

#line default
#line hidden
#nullable disable
            WriteLiteral("</td>\r\n                                    <td><button class=\"idFeatures btn red waves-effect waves-light right\">حذف</button></td>\r\n                                </tr>\r\n");
#nullable restore
#line 97 "E:\asp.net projects\MyMarket\Market.EndPoint\Areas\Admin\Views\Product\Edit.cshtml"
                            }
                        }

#line default
#line hidden
#nullable disable
            WriteLiteral(@"                    </tbody>
                </table>
            </div>
        </div>
    </div>
</div>

<div class=""row"">
    <div class=""col s12"">
        <div class=""card"">
            <div class=""card-content"">
                <div class=""input-field"">
                    <input type=""text"" id=""colorValue"" class=""validate"" />
                    <label class=""active"">رنگ :</label>
                    <button class=""btn green waves-effect waves-light right"" id=""btnCreateColor"">
                        افزودن
                    </button>
                </div>

                <div class=""input-field"">
                    ");
#nullable restore
#line 119 "E:\asp.net projects\MyMarket\Market.EndPoint\Areas\Admin\Views\Product\Edit.cshtml"
               Write(await Component.InvokeAsync("ColorsInSelectList"));

#line default
#line hidden
#nullable disable
            WriteLiteral(@"
                    <button class=""btn green waves-effect waves-light right"" id=""btnCreateColorByList"">
                        افزودن
                    </button>
                </div>

                <br />
                <table class=""highlight"">
                    <thead>
                        <tr>
                            <th>رنگ</th>
                        </tr>
                    </thead>
                    <tbody id=""colorTable"">
");
#nullable restore
#line 133 "E:\asp.net projects\MyMarket\Market.EndPoint\Areas\Admin\Views\Product\Edit.cshtml"
                         if (Model.Colors != null)
                            foreach (var item in Model.Colors)
                            {

#line default
#line hidden
#nullable disable
            WriteLiteral("                                <tr>\r\n                                    <td>");
#nullable restore
#line 137 "E:\asp.net projects\MyMarket\Market.EndPoint\Areas\Admin\Views\Product\Edit.cshtml"
                                   Write(item.Name);

#line default
#line hidden
#nullable disable
            WriteLiteral("</td>\r\n                                    <td><button class=\"idFeatures btn red waves-effect waves-light right\">حذف</button></td>\r\n                                </tr>\r\n");
#nullable restore
#line 140 "E:\asp.net projects\MyMarket\Market.EndPoint\Areas\Admin\Views\Product\Edit.cshtml"
                            }

#line default
#line hidden
#nullable disable
            WriteLiteral(@"                    </tbody>
                </table>
            </div>
        </div>
    </div>
</div>

<div class=""row"">
    <div class=""col s12"">
        <div class=""card"">
            <div class=""card-content"">
                <div class=""input-field"">
                    <input type=""text"" id=""sizeValue"" class=""validate"" />
                    <label class=""active"">سایز : </label>
                    <button class=""btn green waves-effect waves-light right"" id=""btnCreateSize"">
                        افزودن
                    </button>
                </div>

                <div class=""input-field"">
                    ");
#nullable restore
#line 161 "E:\asp.net projects\MyMarket\Market.EndPoint\Areas\Admin\Views\Product\Edit.cshtml"
               Write(await Component.InvokeAsync("SizesInSelectList"));

#line default
#line hidden
#nullable disable
            WriteLiteral(@"
                    <button class=""btn green waves-effect waves-light right"" id=""btnCreateSizeByList"">
                        افزودن
                    </button>
                </div>

                <br />
                <table class=""highlight"">
                    <thead>
                        <tr>
                            <th>سایز</th>
                        </tr>
                    </thead>
                    <tbody id=""sizeTable"">
");
#nullable restore
#line 175 "E:\asp.net projects\MyMarket\Market.EndPoint\Areas\Admin\Views\Product\Edit.cshtml"
                         if (Model.Sizes != null)
                            foreach (var item in Model.Sizes)
                            {

#line default
#line hidden
#nullable disable
            WriteLiteral("                                <tr>\r\n                                    <td>");
#nullable restore
#line 179 "E:\asp.net projects\MyMarket\Market.EndPoint\Areas\Admin\Views\Product\Edit.cshtml"
                                   Write(item.SizeValue);

#line default
#line hidden
#nullable disable
            WriteLiteral("</td>\r\n                                    <td><button class=\"idFeatures btn red waves-effect waves-light right\">حذف</button></td>\r\n                                </tr>\r\n");
#nullable restore
#line 182 "E:\asp.net projects\MyMarket\Market.EndPoint\Areas\Admin\Views\Product\Edit.cshtml"
                            }

#line default
#line hidden
#nullable disable
            WriteLiteral(@"                    </tbody>
                </table>
            </div>
        </div>
    </div>
</div>

<div class=""row"">
    <div class=""col s12"">
        <div class=""card"">
            <div class=""card-content"">
                <div class=""input-field"">
                    <input type=""text"" id=""featureDisplay"" class=""validate"" />
                    <label class=""active"">نام ویژگی :</label>
                </div>
                <div class=""input-field"">
                    <input type=""text"" id=""featureValue"" class=""validate"" />
                    <label class=""active"">مقدار ویژگی :</label>
                    <button class=""btn green waves-effect waves-light right"" id=""btnCreateFeature"">
                        افزودن
                    </button>
                </div>

                <br />
                <table class=""highlight"">
                    <thead>
                        <tr>
                            <th>نام ویژگی</th>
                            <th>مقدا");
            WriteLiteral("ر ویژگی</th>\r\n                        </tr>\r\n                    </thead>\r\n                    <tbody id=\"featureTable\">\r\n");
#nullable restore
#line 215 "E:\asp.net projects\MyMarket\Market.EndPoint\Areas\Admin\Views\Product\Edit.cshtml"
                         if (Model.Features != null)
                            foreach (var item in Model.Features)
                            {

#line default
#line hidden
#nullable disable
            WriteLiteral("                                <tr>\r\n                                    <td>");
#nullable restore
#line 219 "E:\asp.net projects\MyMarket\Market.EndPoint\Areas\Admin\Views\Product\Edit.cshtml"
                                   Write(item.Display);

#line default
#line hidden
#nullable disable
            WriteLiteral("</td>\r\n                                    <td>");
#nullable restore
#line 220 "E:\asp.net projects\MyMarket\Market.EndPoint\Areas\Admin\Views\Product\Edit.cshtml"
                                   Write(item.FeatureValue);

#line default
#line hidden
#nullable disable
            WriteLiteral("</td>\r\n                                    <td><button class=\"idFeatures btn red waves-effect waves-light right\">حذف</button></td>\r\n                                </tr>\r\n");
#nullable restore
#line 223 "E:\asp.net projects\MyMarket\Market.EndPoint\Areas\Admin\Views\Product\Edit.cshtml"
                            }

#line default
#line hidden
#nullable disable
            WriteLiteral(@"                    </tbody>
                </table>
            </div>
        </div>
    </div>
</div>

<div class=""row"">
    <div class=""input-field col s12"">
        <input type=""submit"" value=""ویرایش"" class=""btn green waves-effect waves-light right"" id=""btnSend"">
    </div>
</div>
<br />
<br />
<br />


");
            DefineSection("scripts", async() => {
                WriteLiteral(@"
    <script src=""/ckeditor/ckeditor.js""></script>
    <script src=""/ckeditor/adapters/jquery.js""></script>
    <script>
        $(document).ready(function () {
            $(""#btnSend"").click(function (e) {

                var formdata = new FormData();
                formdata.append(""Id"", """);
#nullable restore
#line 250 "E:\asp.net projects\MyMarket\Market.EndPoint\Areas\Admin\Views\Product\Edit.cshtml"
                                  Write(Model.Id);

#line default
#line hidden
#nullable disable
                WriteLiteral(@""");
                formdata.append(""Name"", $(""#name"").val());
                formdata.append(""Brand"", $(""#brand"").val());
                formdata.append(""ShortDescription"", $(""#shortDescription"").val());
                formdata.append(""Description"", $(""#description"").val());
                formdata.append(""Inventory"", $(""#inventory"").val());
                formdata.append(""Price"", $(""#price"").val());
                formdata.append(""CategoryId"", $(""#categoryId"").find(""option:selected"").val());

                var productImages = document.getElementById(""images"");
                if (productImages.files.length > 0) {
                    for (var i = 0; i < productImages.files.length; i++) {
                        formdata.append('Images', productImages.files[i]);
                    }
                }

                var Keywords = $('#keywordTable tr').map(function () {
                    return {
                        KeywordValue: $(this.cells[0]).text(),
                    ");
                WriteLiteral(@"};
                }).get();
                $.each(Keywords, function (i, val) {
                    formdata.append('[' + i + '].KeywordValue', val.KeywordValue);
                });

                var colors = $('#colorTable tr').map(function () {
                    return {
                        Name: $(this.cells[0]).text(),
                    };
                }).get();
                $.each(colors, function (i, val) {
                    formdata.append('[' + i + '].Name', val.Name);
                });

                var sizes = $('#sizeTable tr').map(function () {
                    return {
                        SizeValue: $(this.cells[0]).text(),
                    };
                }).get();
                $.each(sizes, function (i, val) {
                    formdata.append('[' + i + '].SizeValue', val.SizeValue);
                });

                var features = $('#featureTable tr').map(function () {
                    return {
                      ");
                WriteLiteral(@"  Display: $(this.cells[0]).text(),
                        FeatureValue: $(this.cells[1]).text(),
                    };
                }).get();
                $.each(features, function (i, val) {
                    formdata.append('[' + i + '].Display', val.Display);
                    formdata.append('[' + i + '].FeatureValue', val.FeatureValue);
                });

                $.ajax({
                    type: ""POST"",
                    processData: false,
                    contentType: false,
                    cache: false,
                    enctype: ""multipart/form-data"",
                    url: ""/Admin/Product/Edit"",
                    data: formdata,
                    success: function (response) {
                        window.location.href = ""/Admin/Product"";
                    }
                });
            });

            //کنترل جدول کلمات کلیدی برای اضافه و حذف نمودن خط به جدول
            $(""#btnCreateKeyword"").click(function (e) {
          ");
                WriteLiteral(@"      var table = document.getElementById(""keywordTable"");
                var keyValue = document.getElementById(""keywordValue"").value;

                if (keyValue !== """") {
                    CreateRow(table, [keyValue], true);
                }

                $(""#keywordValue"").val("""");
            });

            $(""#keywordTable"").on('click', '.idFeatures', function () {
                $(this).closest('tr').remove();
            });

            //کنترل جدول رنگ ها برای افزودن و حذف نمودن خط به جدول
            $(""#btnCreateColor"").click(function (e) {
                var table = document.getElementById(""colorTable"");
                var keyValue = document.getElementById(""colorValue"").value;

                if (keyValue !== """") {
                    CreateRow(table, [keyValue], true);
                }

                $(""#colorValue"").val("""");
            });

            $(""#colorTable"").on('click', '.idFeatures', function () {
                $(this).closest('tr').r");
                WriteLiteral(@"emove();
            });

            //کنترل جدول سایز ها برای افزودن و حذف نمودن خط به جدول
            $(""#btnCreateSize"").click(function (e) {
                var table = document.getElementById(""sizeTable"");
                var keyValue = document.getElementById(""sizeValue"").value;

                if (keyValue !== """") {
                    CreateRow(table, [keyValue], true);
                }

                $(""#sizeValue"").val("""");
            });

            $(""#sizeTable"").on('click', '.idFeatures', function () {
                $(this).closest('tr').remove();
            });

            //کنترل جدول ویژگی ها برای افزودن و حذف نمودن خط به جدول
            $(""#btnCreateFeature"").click(function (e) {
                debugger;
                var table = document.getElementById(""featureTable"");
                var display = document.getElementById(""featureDisplay"").value;
                var value = document.getElementById(""featureValue"").value;

                if (value !=");
                WriteLiteral(@"= """" && display !== """") {
                    CreateRow(table, [display, value], true);
                }

                $(""#featureDisplay"").val("""");
                $(""#featureValue"").val("""");
            });

            $(""#featureTable"").on('click', '.idFeatures', function () {
                $(this).closest('tr').remove();
            });

            //افزودن رنگ با لیست
            $(""#btnCreateColorByList"").click(function (e) {
                var colors = document.getElementById(""ColorsList"").options;
                var table = document.getElementById(""colorTable"");
                debugger;
                for (var i = 0; i < colors.length; i++) {
                    if (colors[i].selected && !colors[i].disabled) {
                        CreateRow(table, [colors[i].value], true);
                    }
                };
            });

            //افزودن سایر با لیست
            $(""#btnCreateSizeByList"").click(function (e) {
                var sizes = document.get");
                WriteLiteral(@"ElementById(""SizesList"").options;
                var table = document.getElementById(""sizeTable"");
                debugger;
                for (var i = 0; i < sizes.length; i++) {
                    if (sizes[i].selected && !sizes[i].disabled) {
                        CreateRow(table, [sizes[i].value], true);
                    }
                };
            });

            //متد افزودن خط
            function CreateRow(table, values, withDeleteKey) {
                debugger;
                var newRow = ""<tr>"";
                for (var i = 0; i < values.length; i++) {
                    newRow += ""<td>"" + values[i] + ""</td>"";
                }

                if (withDeleteKey === true) {
                    newRow += '<td><button class=""idFeatures btn red waves-effect waves-light right"" >حذف</button></td>';
                }

                newRow += ""</tr>"";
                table.innerHTML += newRow;
            }

            $(function () {
                $('#desc");
                WriteLiteral("ription\').ckeditor();\r\n            });\r\n        });\r\n    </script>\r\n");
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
        public global::Microsoft.AspNetCore.Mvc.Rendering.IHtmlHelper<GetProductByIdDto> Html { get; private set; }
    }
}
#pragma warning restore 1591
