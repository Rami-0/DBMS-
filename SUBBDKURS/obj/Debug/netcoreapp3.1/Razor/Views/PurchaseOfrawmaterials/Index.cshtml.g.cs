#pragma checksum "F:\Junior Year 3#\Spring semester 2024\Ади. СУБД 1-2.Семестр\SUBBDKURS\SUBBDKURS\Views\PurchaseOfrawmaterials\Index.cshtml" "{8829d00f-11b8-4213-878b-770e8597ac16}" "83596894e690d55ed8cf2d342c534bbdd12d2b194ebc66acb6dc75a33a1f5f6d"
// <auto-generated/>
#pragma warning disable 1591
[assembly: global::Microsoft.AspNetCore.Razor.Hosting.RazorCompiledItemAttribute(typeof(AspNetCore.Views_PurchaseOfrawmaterials_Index), @"mvc.1.0.view", @"/Views/PurchaseOfrawmaterials/Index.cshtml")]
namespace AspNetCore
{
    #line hidden
    using global::System;
    using global::System.Collections.Generic;
    using global::System.Linq;
    using global::System.Threading.Tasks;
    using global::Microsoft.AspNetCore.Mvc;
    using global::Microsoft.AspNetCore.Mvc.Rendering;
    using global::Microsoft.AspNetCore.Mvc.ViewFeatures;
#nullable restore
#line 1 "F:\Junior Year 3#\Spring semester 2024\Ади. СУБД 1-2.Семестр\SUBBDKURS\SUBBDKURS\Views\_ViewImports.cshtml"
using SUBBDKURS;

#line default
#line hidden
#nullable disable
#nullable restore
#line 2 "F:\Junior Year 3#\Spring semester 2024\Ади. СУБД 1-2.Семестр\SUBBDKURS\SUBBDKURS\Views\_ViewImports.cshtml"
using SUBBDKURS.Models;

#line default
#line hidden
#nullable disable
    [global::Microsoft.AspNetCore.Razor.Hosting.RazorSourceChecksumAttribute(@"SHA256", @"83596894e690d55ed8cf2d342c534bbdd12d2b194ebc66acb6dc75a33a1f5f6d", @"/Views/PurchaseOfrawmaterials/Index.cshtml")]
    [global::Microsoft.AspNetCore.Razor.Hosting.RazorSourceChecksumAttribute(@"SHA256", @"d9a4e86c2eff56a79a5ca30ea3976c7909b099fe8e8516508588eb906ef96cd1", @"/Views/_ViewImports.cshtml")]
    #nullable restore
    public class Views_PurchaseOfrawmaterials_Index : global::Microsoft.AspNetCore.Mvc.Razor.RazorPage<IEnumerable<SUBBDKURS.Models.PurchaseOfrawmaterials>>
    #nullable disable
    {
        private static readonly global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute __tagHelperAttribute_0 = new global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute("asp-action", "Create", global::Microsoft.AspNetCore.Razor.TagHelpers.HtmlAttributeValueStyle.DoubleQuotes);
        private static readonly global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute __tagHelperAttribute_1 = new global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute("asp-action", "Delete", global::Microsoft.AspNetCore.Razor.TagHelpers.HtmlAttributeValueStyle.DoubleQuotes);
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
        private global::Microsoft.AspNetCore.Mvc.TagHelpers.AnchorTagHelper __Microsoft_AspNetCore_Mvc_TagHelpers_AnchorTagHelper;
        #pragma warning disable 1998
        public async override global::System.Threading.Tasks.Task ExecuteAsync()
        {
            WriteLiteral("\r\n");
#nullable restore
#line 3 "F:\Junior Year 3#\Spring semester 2024\Ади. СУБД 1-2.Семестр\SUBBDKURS\SUBBDKURS\Views\PurchaseOfrawmaterials\Index.cshtml"
  
    ViewData["Title"] = "Index";

#line default
#line hidden
#nullable disable
            WriteLiteral("\r\n<h1>Закупка</h1>\r\n\r\n<p>\r\n    ");
            __tagHelperExecutionContext = __tagHelperScopeManager.Begin("a", global::Microsoft.AspNetCore.Razor.TagHelpers.TagMode.StartTagAndEndTag, "83596894e690d55ed8cf2d342c534bbdd12d2b194ebc66acb6dc75a33a1f5f6d4366", async() => {
                WriteLiteral("Добавить");
            }
            );
            __Microsoft_AspNetCore_Mvc_TagHelpers_AnchorTagHelper = CreateTagHelper<global::Microsoft.AspNetCore.Mvc.TagHelpers.AnchorTagHelper>();
            __tagHelperExecutionContext.Add(__Microsoft_AspNetCore_Mvc_TagHelpers_AnchorTagHelper);
            __Microsoft_AspNetCore_Mvc_TagHelpers_AnchorTagHelper.Action = (string)__tagHelperAttribute_0.Value;
            __tagHelperExecutionContext.AddTagHelperAttribute(__tagHelperAttribute_0);
            await __tagHelperRunner.RunAsync(__tagHelperExecutionContext);
            if (!__tagHelperExecutionContext.Output.IsContentModified)
            {
                await __tagHelperExecutionContext.SetOutputContentAsync();
            }
            Write(__tagHelperExecutionContext.Output);
            __tagHelperExecutionContext = __tagHelperScopeManager.End();
            WriteLiteral("\r\n</p>\r\n<table class=\"table\">\r\n    <thead>\r\n        <tr>\r\n            <th>\r\n                ");
#nullable restore
#line 16 "F:\Junior Year 3#\Spring semester 2024\Ади. СУБД 1-2.Семестр\SUBBDKURS\SUBBDKURS\Views\PurchaseOfrawmaterials\Index.cshtml"
           Write(Html.DisplayName("Колво"));

#line default
#line hidden
#nullable disable
            WriteLiteral("\r\n            </th>\r\n            <th>\r\n                ");
#nullable restore
#line 19 "F:\Junior Year 3#\Spring semester 2024\Ади. СУБД 1-2.Семестр\SUBBDKURS\SUBBDKURS\Views\PurchaseOfrawmaterials\Index.cshtml"
           Write(Html.DisplayName("Сумма"));

#line default
#line hidden
#nullable disable
            WriteLiteral("\r\n            </th>\r\n            <th>\r\n                ");
#nullable restore
#line 22 "F:\Junior Year 3#\Spring semester 2024\Ади. СУБД 1-2.Семестр\SUBBDKURS\SUBBDKURS\Views\PurchaseOfrawmaterials\Index.cshtml"
           Write(Html.DisplayName("Дата"));

#line default
#line hidden
#nullable disable
            WriteLiteral("\r\n            </th>\r\n            <th>\r\n                ");
#nullable restore
#line 25 "F:\Junior Year 3#\Spring semester 2024\Ади. СУБД 1-2.Семестр\SUBBDKURS\SUBBDKURS\Views\PurchaseOfrawmaterials\Index.cshtml"
           Write(Html.DisplayName("Сотрудники"));

#line default
#line hidden
#nullable disable
            WriteLiteral("\r\n            </th>\r\n            <th>\r\n                ");
#nullable restore
#line 28 "F:\Junior Year 3#\Spring semester 2024\Ади. СУБД 1-2.Семестр\SUBBDKURS\SUBBDKURS\Views\PurchaseOfrawmaterials\Index.cshtml"
           Write(Html.DisplayName("Сырье"));

#line default
#line hidden
#nullable disable
            WriteLiteral("\r\n            </th>\r\n            <th></th>\r\n        </tr>\r\n    </thead>\r\n    <tbody>\r\n");
#nullable restore
#line 34 "F:\Junior Year 3#\Spring semester 2024\Ади. СУБД 1-2.Семестр\SUBBDKURS\SUBBDKURS\Views\PurchaseOfrawmaterials\Index.cshtml"
 foreach (var item in Model) {

#line default
#line hidden
#nullable disable
            WriteLiteral("        <tr>\r\n\r\n            <td>\r\n                ");
#nullable restore
#line 38 "F:\Junior Year 3#\Spring semester 2024\Ади. СУБД 1-2.Семестр\SUBBDKURS\SUBBDKURS\Views\PurchaseOfrawmaterials\Index.cshtml"
           Write(Html.DisplayFor(modelItem => item.CountPur));

#line default
#line hidden
#nullable disable
            WriteLiteral("\r\n            </td>\r\n            <td>\r\n                ");
#nullable restore
#line 41 "F:\Junior Year 3#\Spring semester 2024\Ади. СУБД 1-2.Семестр\SUBBDKURS\SUBBDKURS\Views\PurchaseOfrawmaterials\Index.cshtml"
           Write(Html.DisplayFor(modelItem => item.Sum));

#line default
#line hidden
#nullable disable
            WriteLiteral("\r\n            </td>\r\n            <td>\r\n                ");
#nullable restore
#line 44 "F:\Junior Year 3#\Spring semester 2024\Ади. СУБД 1-2.Семестр\SUBBDKURS\SUBBDKURS\Views\PurchaseOfrawmaterials\Index.cshtml"
           Write(Html.DisplayFor(modelItem => item.Date));

#line default
#line hidden
#nullable disable
            WriteLiteral("\r\n            </td>\r\n            <td>\r\n                ");
#nullable restore
#line 47 "F:\Junior Year 3#\Spring semester 2024\Ади. СУБД 1-2.Семестр\SUBBDKURS\SUBBDKURS\Views\PurchaseOfrawmaterials\Index.cshtml"
           Write(Html.DisplayFor(modelItem => item.EmployeeNavigation.Fullname));

#line default
#line hidden
#nullable disable
            WriteLiteral("\r\n            </td>\r\n            <td>\r\n                ");
#nullable restore
#line 50 "F:\Junior Year 3#\Spring semester 2024\Ади. СУБД 1-2.Семестр\SUBBDKURS\SUBBDKURS\Views\PurchaseOfrawmaterials\Index.cshtml"
           Write(Html.DisplayFor(modelItem => item.RawMaterialsNavigation.Name));

#line default
#line hidden
#nullable disable
            WriteLiteral("\r\n            </td>\r\n            <td>\r\n                   \r\n\r\n                    ");
            __tagHelperExecutionContext = __tagHelperScopeManager.Begin("a", global::Microsoft.AspNetCore.Razor.TagHelpers.TagMode.StartTagAndEndTag, "83596894e690d55ed8cf2d342c534bbdd12d2b194ebc66acb6dc75a33a1f5f6d9583", async() => {
                WriteLiteral("Удалить");
            }
            );
            __Microsoft_AspNetCore_Mvc_TagHelpers_AnchorTagHelper = CreateTagHelper<global::Microsoft.AspNetCore.Mvc.TagHelpers.AnchorTagHelper>();
            __tagHelperExecutionContext.Add(__Microsoft_AspNetCore_Mvc_TagHelpers_AnchorTagHelper);
            __Microsoft_AspNetCore_Mvc_TagHelpers_AnchorTagHelper.Action = (string)__tagHelperAttribute_1.Value;
            __tagHelperExecutionContext.AddTagHelperAttribute(__tagHelperAttribute_1);
            if (__Microsoft_AspNetCore_Mvc_TagHelpers_AnchorTagHelper.RouteValues == null)
            {
                throw new InvalidOperationException(InvalidTagHelperIndexerAssignment("asp-route-id", "Microsoft.AspNetCore.Mvc.TagHelpers.AnchorTagHelper", "RouteValues"));
            }
            BeginWriteTagHelperAttribute();
#nullable restore
#line 55 "F:\Junior Year 3#\Spring semester 2024\Ади. СУБД 1-2.Семестр\SUBBDKURS\SUBBDKURS\Views\PurchaseOfrawmaterials\Index.cshtml"
                                             WriteLiteral(item.Id);

#line default
#line hidden
#nullable disable
            __tagHelperStringValueBuffer = EndWriteTagHelperAttribute();
            __Microsoft_AspNetCore_Mvc_TagHelpers_AnchorTagHelper.RouteValues["id"] = __tagHelperStringValueBuffer;
            __tagHelperExecutionContext.AddTagHelperAttribute("asp-route-id", __Microsoft_AspNetCore_Mvc_TagHelpers_AnchorTagHelper.RouteValues["id"], global::Microsoft.AspNetCore.Razor.TagHelpers.HtmlAttributeValueStyle.DoubleQuotes);
            await __tagHelperRunner.RunAsync(__tagHelperExecutionContext);
            if (!__tagHelperExecutionContext.Output.IsContentModified)
            {
                await __tagHelperExecutionContext.SetOutputContentAsync();
            }
            Write(__tagHelperExecutionContext.Output);
            __tagHelperExecutionContext = __tagHelperScopeManager.End();
            WriteLiteral("\r\n                </td>\r\n        </tr>\r\n");
#nullable restore
#line 58 "F:\Junior Year 3#\Spring semester 2024\Ади. СУБД 1-2.Семестр\SUBBDKURS\SUBBDKURS\Views\PurchaseOfrawmaterials\Index.cshtml"
}

#line default
#line hidden
#nullable disable
            WriteLiteral("    </tbody>\r\n</table>\r\n");
        }
        #pragma warning restore 1998
        #nullable restore
        [global::Microsoft.AspNetCore.Mvc.Razor.Internal.RazorInjectAttribute]
        public global::Microsoft.AspNetCore.Mvc.ViewFeatures.IModelExpressionProvider ModelExpressionProvider { get; private set; } = default!;
        #nullable disable
        #nullable restore
        [global::Microsoft.AspNetCore.Mvc.Razor.Internal.RazorInjectAttribute]
        public global::Microsoft.AspNetCore.Mvc.IUrlHelper Url { get; private set; } = default!;
        #nullable disable
        #nullable restore
        [global::Microsoft.AspNetCore.Mvc.Razor.Internal.RazorInjectAttribute]
        public global::Microsoft.AspNetCore.Mvc.IViewComponentHelper Component { get; private set; } = default!;
        #nullable disable
        #nullable restore
        [global::Microsoft.AspNetCore.Mvc.Razor.Internal.RazorInjectAttribute]
        public global::Microsoft.AspNetCore.Mvc.Rendering.IJsonHelper Json { get; private set; } = default!;
        #nullable disable
        #nullable restore
        [global::Microsoft.AspNetCore.Mvc.Razor.Internal.RazorInjectAttribute]
        public global::Microsoft.AspNetCore.Mvc.Rendering.IHtmlHelper<IEnumerable<SUBBDKURS.Models.PurchaseOfrawmaterials>> Html { get; private set; } = default!;
        #nullable disable
    }
}
#pragma warning restore 1591
