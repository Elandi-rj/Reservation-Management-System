#pragma checksum "C:\Users\danie\source\Workspaces\T1RMS\T1RMSSolution\T1RMSWS\Areas\Management\Views\Home\Index.cshtml" "{ff1816ec-aa5e-4d10-87f7-6f4963833460}" "b16b2bb4aaaddd248944aada88c867465fa10bd6"
// <auto-generated/>
#pragma warning disable 1591
[assembly: global::Microsoft.AspNetCore.Razor.Hosting.RazorCompiledItemAttribute(typeof(AspNetCore.Areas_Management_Views_Home_Index), @"mvc.1.0.view", @"/Areas/Management/Views/Home/Index.cshtml")]
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
#line 1 "C:\Users\danie\source\Workspaces\T1RMS\T1RMSSolution\T1RMSWS\Areas\Management\Views\_ViewImports.cshtml"
using T1RMSWS;

#line default
#line hidden
#nullable disable
#nullable restore
#line 2 "C:\Users\danie\source\Workspaces\T1RMS\T1RMSSolution\T1RMSWS\Areas\Management\Views\_ViewImports.cshtml"
using T1RMSWS.Models;

#line default
#line hidden
#nullable disable
    [global::Microsoft.AspNetCore.Razor.Hosting.RazorSourceChecksumAttribute(@"SHA1", @"b16b2bb4aaaddd248944aada88c867465fa10bd6", @"/Areas/Management/Views/Home/Index.cshtml")]
    [global::Microsoft.AspNetCore.Razor.Hosting.RazorSourceChecksumAttribute(@"SHA1", @"01cb7dd9e79a6ce1497316e25f1f7376a52ded1f", @"/Areas/Management/Views/_ViewImports.cshtml")]
    public class Areas_Management_Views_Home_Index : global::Microsoft.AspNetCore.Mvc.Razor.RazorPage<IEnumerable<T1RMSWS.Data.Reservation>>
    {
        private static readonly global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute __tagHelperAttribute_0 = new global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute("src", new global::Microsoft.AspNetCore.Html.HtmlString("~/js/bstable.js"), global::Microsoft.AspNetCore.Razor.TagHelpers.HtmlAttributeValueStyle.DoubleQuotes);
        private static readonly global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute __tagHelperAttribute_1 = new global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute("src", new global::Microsoft.AspNetCore.Html.HtmlString("~/js/management.home.index.js"), global::Microsoft.AspNetCore.Razor.TagHelpers.HtmlAttributeValueStyle.DoubleQuotes);
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
        private global::Microsoft.AspNetCore.Mvc.Razor.TagHelpers.UrlResolutionTagHelper __Microsoft_AspNetCore_Mvc_Razor_TagHelpers_UrlResolutionTagHelper;
        #pragma warning disable 1998
        public async override global::System.Threading.Tasks.Task ExecuteAsync()
        {
            WriteLiteral("\r\n");
            DefineSection("styles", async() => {
                WriteLiteral("\r\n    <link href=\"https://stackpath.bootstrapcdn.com/font-awesome/4.7.0/css/font-awesome.min.css\" rel=\"stylesheet\" integrity=\"sha384-wvfXpqpZZVQGK6TAh5PVlGOfQNHSoD2xbE+QkPxCAFlNEevoEH3Sl0sibVcOQVnN\" crossorigin=\"anonymous\">\r\n");
            }
            );
            WriteLiteral(@"
<h1>Management - Home - Index</h1>
<button id=""new-row-button"" class=""btn btn-dark"">
    New Row
</button>
<table class=""table table-striped table-bordered"" id=""example"">
    <thead class=""thead-dark"">
        <tr>
            <th scope=""col"">#</th>
            <th scope=""col"">");
#nullable restore
#line 15 "C:\Users\danie\source\Workspaces\T1RMS\T1RMSSolution\T1RMSWS\Areas\Management\Views\Home\Index.cshtml"
                       Write(Html.DisplayNameFor(model => model.Customer.FirstName));

#line default
#line hidden
#nullable disable
            WriteLiteral("</th>\r\n            <th scope=\"col\">");
#nullable restore
#line 16 "C:\Users\danie\source\Workspaces\T1RMS\T1RMSSolution\T1RMSWS\Areas\Management\Views\Home\Index.cshtml"
                       Write(Html.DisplayNameFor(model => model.Customer.LastName));

#line default
#line hidden
#nullable disable
            WriteLiteral("</th>\r\n            <th scope=\"col\">");
#nullable restore
#line 17 "C:\Users\danie\source\Workspaces\T1RMS\T1RMSSolution\T1RMSWS\Areas\Management\Views\Home\Index.cshtml"
                       Write(Html.DisplayNameFor(model => model.Sitting.SittingType));

#line default
#line hidden
#nullable disable
            WriteLiteral("</th>\r\n            <th scope=\"col\">");
#nullable restore
#line 18 "C:\Users\danie\source\Workspaces\T1RMS\T1RMSSolution\T1RMSWS\Areas\Management\Views\Home\Index.cshtml"
                       Write(Html.DisplayNameFor(model => model.Guests));

#line default
#line hidden
#nullable disable
            WriteLiteral("</th>\r\n            <th scope=\"col\">");
#nullable restore
#line 19 "C:\Users\danie\source\Workspaces\T1RMS\T1RMSSolution\T1RMSWS\Areas\Management\Views\Home\Index.cshtml"
                       Write(Html.DisplayNameFor(model => model.Duration));

#line default
#line hidden
#nullable disable
            WriteLiteral("</th>\r\n            <th scope=\"col\">");
#nullable restore
#line 20 "C:\Users\danie\source\Workspaces\T1RMS\T1RMSSolution\T1RMSWS\Areas\Management\Views\Home\Index.cshtml"
                       Write(Html.DisplayNameFor(model => model.ReservationType.Description));

#line default
#line hidden
#nullable disable
            WriteLiteral("</th>\r\n            <th scope=\"col\">");
#nullable restore
#line 21 "C:\Users\danie\source\Workspaces\T1RMS\T1RMSSolution\T1RMSWS\Areas\Management\Views\Home\Index.cshtml"
                       Write(Html.DisplayNameFor(model => model.ReservationStatus.Description));

#line default
#line hidden
#nullable disable
            WriteLiteral("</th>\r\n            <th scope=\"col\">");
#nullable restore
#line 22 "C:\Users\danie\source\Workspaces\T1RMS\T1RMSSolution\T1RMSWS\Areas\Management\Views\Home\Index.cshtml"
                       Write(Html.DisplayNameFor(model => model.StartTime));

#line default
#line hidden
#nullable disable
            WriteLiteral("</th>\r\n\r\n        </tr>\r\n    </thead>\r\n\r\n    <tbody>\r\n\r\n");
#nullable restore
#line 29 "C:\Users\danie\source\Workspaces\T1RMS\T1RMSSolution\T1RMSWS\Areas\Management\Views\Home\Index.cshtml"
         foreach (var item in Model)
        {

#line default
#line hidden
#nullable disable
            WriteLiteral("    <tr");
            BeginWriteAttribute("id", " id=\"", 1366, "\"", 1379, 1);
#nullable restore
#line 31 "C:\Users\danie\source\Workspaces\T1RMS\T1RMSSolution\T1RMSWS\Areas\Management\Views\Home\Index.cshtml"
WriteAttributeValue("", 1371, item.Id, 1371, 8, false);

#line default
#line hidden
#nullable disable
            EndWriteAttribute();
            WriteLiteral(">\r\n        <th scope=\"row\">##</th>\r\n        <td id=\"si\">");
#nullable restore
#line 33 "C:\Users\danie\source\Workspaces\T1RMS\T1RMSSolution\T1RMSWS\Areas\Management\Views\Home\Index.cshtml"
               Write(item.SittingId);

#line default
#line hidden
#nullable disable
            WriteLiteral("</td>\r\n        <td>");
#nullable restore
#line 34 "C:\Users\danie\source\Workspaces\T1RMS\T1RMSSolution\T1RMSWS\Areas\Management\Views\Home\Index.cshtml"
       Write(item.CustomerId);

#line default
#line hidden
#nullable disable
            WriteLiteral("</td>\r\n        <td>");
#nullable restore
#line 35 "C:\Users\danie\source\Workspaces\T1RMS\T1RMSSolution\T1RMSWS\Areas\Management\Views\Home\Index.cshtml"
       Write(item.ReservationTypeId);

#line default
#line hidden
#nullable disable
            WriteLiteral("</td>\r\n        <td>");
#nullable restore
#line 36 "C:\Users\danie\source\Workspaces\T1RMS\T1RMSSolution\T1RMSWS\Areas\Management\Views\Home\Index.cshtml"
       Write(item.Guests);

#line default
#line hidden
#nullable disable
            WriteLiteral("</td>\r\n        <td>");
#nullable restore
#line 37 "C:\Users\danie\source\Workspaces\T1RMS\T1RMSSolution\T1RMSWS\Areas\Management\Views\Home\Index.cshtml"
       Write(item.Duration);

#line default
#line hidden
#nullable disable
            WriteLiteral("</td>\r\n        <td>");
#nullable restore
#line 38 "C:\Users\danie\source\Workspaces\T1RMS\T1RMSSolution\T1RMSWS\Areas\Management\Views\Home\Index.cshtml"
       Write(item.Note);

#line default
#line hidden
#nullable disable
            WriteLiteral("</td>\r\n        <td>");
#nullable restore
#line 39 "C:\Users\danie\source\Workspaces\T1RMS\T1RMSSolution\T1RMSWS\Areas\Management\Views\Home\Index.cshtml"
       Write(item.ReservationStatusId);

#line default
#line hidden
#nullable disable
            WriteLiteral("</td>\r\n        <td>");
#nullable restore
#line 40 "C:\Users\danie\source\Workspaces\T1RMS\T1RMSSolution\T1RMSWS\Areas\Management\Views\Home\Index.cshtml"
       Write(item.StartTime);

#line default
#line hidden
#nullable disable
            WriteLiteral("</td>\r\n\r\n    </tr>\r\n");
#nullable restore
#line 43 "C:\Users\danie\source\Workspaces\T1RMS\T1RMSSolution\T1RMSWS\Areas\Management\Views\Home\Index.cshtml"

        }

#line default
#line hidden
#nullable disable
            WriteLiteral("    </tbody>\r\n</table>\r\n\r\n");
            DefineSection("scripts", async() => {
                WriteLiteral("\r\n    ");
                __tagHelperExecutionContext = __tagHelperScopeManager.Begin("script", global::Microsoft.AspNetCore.Razor.TagHelpers.TagMode.StartTagAndEndTag, "b16b2bb4aaaddd248944aada88c867465fa10bd610632", async() => {
                }
                );
                __Microsoft_AspNetCore_Mvc_Razor_TagHelpers_UrlResolutionTagHelper = CreateTagHelper<global::Microsoft.AspNetCore.Mvc.Razor.TagHelpers.UrlResolutionTagHelper>();
                __tagHelperExecutionContext.Add(__Microsoft_AspNetCore_Mvc_Razor_TagHelpers_UrlResolutionTagHelper);
                __tagHelperExecutionContext.AddHtmlAttribute(__tagHelperAttribute_0);
                await __tagHelperRunner.RunAsync(__tagHelperExecutionContext);
                if (!__tagHelperExecutionContext.Output.IsContentModified)
                {
                    await __tagHelperExecutionContext.SetOutputContentAsync();
                }
                Write(__tagHelperExecutionContext.Output);
                __tagHelperExecutionContext = __tagHelperScopeManager.End();
                WriteLiteral("\r\n\r\n    ");
                __tagHelperExecutionContext = __tagHelperScopeManager.Begin("script", global::Microsoft.AspNetCore.Razor.TagHelpers.TagMode.StartTagAndEndTag, "b16b2bb4aaaddd248944aada88c867465fa10bd611736", async() => {
                }
                );
                __Microsoft_AspNetCore_Mvc_Razor_TagHelpers_UrlResolutionTagHelper = CreateTagHelper<global::Microsoft.AspNetCore.Mvc.Razor.TagHelpers.UrlResolutionTagHelper>();
                __tagHelperExecutionContext.Add(__Microsoft_AspNetCore_Mvc_Razor_TagHelpers_UrlResolutionTagHelper);
                __tagHelperExecutionContext.AddHtmlAttribute(__tagHelperAttribute_1);
                await __tagHelperRunner.RunAsync(__tagHelperExecutionContext);
                if (!__tagHelperExecutionContext.Output.IsContentModified)
                {
                    await __tagHelperExecutionContext.SetOutputContentAsync();
                }
                Write(__tagHelperExecutionContext.Output);
                __tagHelperExecutionContext = __tagHelperScopeManager.End();
                WriteLiteral("\r\n\r\n");
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
        public global::Microsoft.AspNetCore.Mvc.Rendering.IHtmlHelper<IEnumerable<T1RMSWS.Data.Reservation>> Html { get; private set; }
    }
}
#pragma warning restore 1591
