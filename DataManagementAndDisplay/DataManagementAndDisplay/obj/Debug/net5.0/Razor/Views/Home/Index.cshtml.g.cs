#pragma checksum "C:\Users\Hristo Ivanov\Documents\GitHub\CustomDataDisplay\DataManagementAndDisplay\DataManagementAndDisplay\Views\Home\Index.cshtml" "{ff1816ec-aa5e-4d10-87f7-6f4963833460}" "4442150443b84068f473a97420a2d717d813baeb"
// <auto-generated/>
#pragma warning disable 1591
[assembly: global::Microsoft.AspNetCore.Razor.Hosting.RazorCompiledItemAttribute(typeof(AspNetCore.Views_Home_Index), @"mvc.1.0.view", @"/Views/Home/Index.cshtml")]
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
#line 1 "C:\Users\Hristo Ivanov\Documents\GitHub\CustomDataDisplay\DataManagementAndDisplay\DataManagementAndDisplay\Views\_ViewImports.cshtml"
using DataManagementAndDisplay;

#line default
#line hidden
#nullable disable
#nullable restore
#line 2 "C:\Users\Hristo Ivanov\Documents\GitHub\CustomDataDisplay\DataManagementAndDisplay\DataManagementAndDisplay\Views\_ViewImports.cshtml"
using DataManagementAndDisplay.Models;

#line default
#line hidden
#nullable disable
    [global::Microsoft.AspNetCore.Razor.Hosting.RazorSourceChecksumAttribute(@"SHA1", @"4442150443b84068f473a97420a2d717d813baeb", @"/Views/Home/Index.cshtml")]
    [global::Microsoft.AspNetCore.Razor.Hosting.RazorSourceChecksumAttribute(@"SHA1", @"617758f2e9ed99c6a6cdab1dec2e281b5c5defad", @"/Views/_ViewImports.cshtml")]
    public class Views_Home_Index : global::Microsoft.AspNetCore.Mvc.Razor.RazorPage<DataModel.Model>
    {
        private static readonly global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute __tagHelperAttribute_0 = new global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute("class", new global::Microsoft.AspNetCore.Html.HtmlString("text-danger"), global::Microsoft.AspNetCore.Razor.TagHelpers.HtmlAttributeValueStyle.DoubleQuotes);
        private static readonly global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute __tagHelperAttribute_1 = new global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute("id", new global::Microsoft.AspNetCore.Html.HtmlString("form"), global::Microsoft.AspNetCore.Razor.TagHelpers.HtmlAttributeValueStyle.DoubleQuotes);
        private static readonly global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute __tagHelperAttribute_2 = new global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute("id", new global::Microsoft.AspNetCore.Html.HtmlString("create-model-form"), global::Microsoft.AspNetCore.Razor.TagHelpers.HtmlAttributeValueStyle.DoubleQuotes);
        private static readonly global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute __tagHelperAttribute_3 = new global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute("class", new global::Microsoft.AspNetCore.Html.HtmlString("create-model-form"), global::Microsoft.AspNetCore.Razor.TagHelpers.HtmlAttributeValueStyle.DoubleQuotes);
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
        private global::Microsoft.AspNetCore.Mvc.TagHelpers.ValidationSummaryTagHelper __Microsoft_AspNetCore_Mvc_TagHelpers_ValidationSummaryTagHelper;
        private global::Microsoft.AspNetCore.Mvc.TagHelpers.OptionTagHelper __Microsoft_AspNetCore_Mvc_TagHelpers_OptionTagHelper;
        #pragma warning disable 1998
        public async override global::System.Threading.Tasks.Task ExecuteAsync()
        {
#nullable restore
#line 2 "C:\Users\Hristo Ivanov\Documents\GitHub\CustomDataDisplay\DataManagementAndDisplay\DataManagementAndDisplay\Views\Home\Index.cshtml"
  
    ViewData["Title"] = "Home Page";

#line default
#line hidden
#nullable disable
            WriteLiteral("\r\n<div class=\"main-div\">\r\n    <div class=\"view\" id=\"page1\">\r\n        <div class=\"custom-body\">\r\n            <div class=\"search\">\r\n                ");
            __tagHelperExecutionContext = __tagHelperScopeManager.Begin("form", global::Microsoft.AspNetCore.Razor.TagHelpers.TagMode.StartTagAndEndTag, "4442150443b84068f473a97420a2d717d813baeb5514", async() => {
                WriteLiteral("\r\n                    <div class=\"search-form-top-row\">\r\n                        <h2>Search</h2>\r\n                        <button class=\"clear-search-form-button\" type=\"reset\">Reset Search</button>\r\n                    </div>\r\n                    ");
                __tagHelperExecutionContext = __tagHelperScopeManager.Begin("div", global::Microsoft.AspNetCore.Razor.TagHelpers.TagMode.StartTagAndEndTag, "4442150443b84068f473a97420a2d717d813baeb6031", async() => {
                }
                );
                __Microsoft_AspNetCore_Mvc_TagHelpers_ValidationSummaryTagHelper = CreateTagHelper<global::Microsoft.AspNetCore.Mvc.TagHelpers.ValidationSummaryTagHelper>();
                __tagHelperExecutionContext.Add(__Microsoft_AspNetCore_Mvc_TagHelpers_ValidationSummaryTagHelper);
#nullable restore
#line 15 "C:\Users\Hristo Ivanov\Documents\GitHub\CustomDataDisplay\DataManagementAndDisplay\DataManagementAndDisplay\Views\Home\Index.cshtml"
__Microsoft_AspNetCore_Mvc_TagHelpers_ValidationSummaryTagHelper.ValidationSummary = global::Microsoft.AspNetCore.Mvc.Rendering.ValidationSummary.ModelOnly;

#line default
#line hidden
#nullable disable
                __tagHelperExecutionContext.AddTagHelperAttribute("asp-validation-summary", __Microsoft_AspNetCore_Mvc_TagHelpers_ValidationSummaryTagHelper.ValidationSummary, global::Microsoft.AspNetCore.Razor.TagHelpers.HtmlAttributeValueStyle.DoubleQuotes);
                __tagHelperExecutionContext.AddHtmlAttribute(__tagHelperAttribute_0);
                await __tagHelperRunner.RunAsync(__tagHelperExecutionContext);
                if (!__tagHelperExecutionContext.Output.IsContentModified)
                {
                    await __tagHelperExecutionContext.SetOutputContentAsync();
                }
                Write(__tagHelperExecutionContext.Output);
                __tagHelperExecutionContext = __tagHelperScopeManager.End();
                WriteLiteral("\r\n                    <div class=\"form-group\">\r\n                        ");
#nullable restore
#line 17 "C:\Users\Hristo Ivanov\Documents\GitHub\CustomDataDisplay\DataManagementAndDisplay\DataManagementAndDisplay\Views\Home\Index.cshtml"
                   Write(Model.timeField.DisplayName);

#line default
#line hidden
#nullable disable
                WriteLiteral("\r\n                        <select");
                BeginWriteAttribute("id", " id=\"", 677, "\"", 711, 1);
#nullable restore
#line 18 "C:\Users\Hristo Ivanov\Documents\GitHub\CustomDataDisplay\DataManagementAndDisplay\DataManagementAndDisplay\Views\Home\Index.cshtml"
WriteAttributeValue("", 682, Model.timeField.InternalName, 682, 29, false);

#line default
#line hidden
#nullable disable
                EndWriteAttribute();
                WriteLiteral(" class=\"form-control time-control\">\r\n                            ");
                __tagHelperExecutionContext = __tagHelperScopeManager.Begin("option", global::Microsoft.AspNetCore.Razor.TagHelpers.TagMode.StartTagAndEndTag, "4442150443b84068f473a97420a2d717d813baeb8668", async() => {
                }
                );
                __Microsoft_AspNetCore_Mvc_TagHelpers_OptionTagHelper = CreateTagHelper<global::Microsoft.AspNetCore.Mvc.TagHelpers.OptionTagHelper>();
                __tagHelperExecutionContext.Add(__Microsoft_AspNetCore_Mvc_TagHelpers_OptionTagHelper);
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
                WriteLiteral("\r\n");
#nullable restore
#line 20 "C:\Users\Hristo Ivanov\Documents\GitHub\CustomDataDisplay\DataManagementAndDisplay\DataManagementAndDisplay\Views\Home\Index.cshtml"
                             for (int i = 0; i < Model.timestamps.Count; i++)
                            {

#line default
#line hidden
#nullable disable
                WriteLiteral("                                ");
                __tagHelperExecutionContext = __tagHelperScopeManager.Begin("option", global::Microsoft.AspNetCore.Razor.TagHelpers.TagMode.StartTagAndEndTag, "4442150443b84068f473a97420a2d717d813baeb10350", async() => {
#nullable restore
#line 22 "C:\Users\Hristo Ivanov\Documents\GitHub\CustomDataDisplay\DataManagementAndDisplay\DataManagementAndDisplay\Views\Home\Index.cshtml"
                                                                             Write(Model.timestamps[i].DisplayName);

#line default
#line hidden
#nullable disable
                }
                );
                __Microsoft_AspNetCore_Mvc_TagHelpers_OptionTagHelper = CreateTagHelper<global::Microsoft.AspNetCore.Mvc.TagHelpers.OptionTagHelper>();
                __tagHelperExecutionContext.Add(__Microsoft_AspNetCore_Mvc_TagHelpers_OptionTagHelper);
                BeginWriteTagHelperAttribute();
#nullable restore
#line 22 "C:\Users\Hristo Ivanov\Documents\GitHub\CustomDataDisplay\DataManagementAndDisplay\DataManagementAndDisplay\Views\Home\Index.cshtml"
                                   WriteLiteral(Model.timestamps[i].InternalName);

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
#line 23 "C:\Users\Hristo Ivanov\Documents\GitHub\CustomDataDisplay\DataManagementAndDisplay\DataManagementAndDisplay\Views\Home\Index.cshtml"
                            }

#line default
#line hidden
#nullable disable
                WriteLiteral("                        </select>\r\n                    </div>\r\n");
#nullable restore
#line 26 "C:\Users\Hristo Ivanov\Documents\GitHub\CustomDataDisplay\DataManagementAndDisplay\DataManagementAndDisplay\Views\Home\Index.cshtml"
                     for (int i = 0; i < Model.Fields.Count; i++)
                    {
                        if (@Model.Fields[i].DisplayName != "Date")
                        {
                            if (@Model.Fields[i].PossibleValues.Count == 0)
                            {

#line default
#line hidden
#nullable disable
                WriteLiteral("                                <div class=\"form-group\">\r\n                                    <label class=\"control-label\">");
#nullable restore
#line 33 "C:\Users\Hristo Ivanov\Documents\GitHub\CustomDataDisplay\DataManagementAndDisplay\DataManagementAndDisplay\Views\Home\Index.cshtml"
                                                            Write(Model.Fields[i].DisplayName);

#line default
#line hidden
#nullable disable
                WriteLiteral("</label>\r\n                                    <input");
                BeginWriteAttribute("class", " class=\"", 1631, "\"", 1693, 3);
                WriteAttributeValue("", 1639, "form-control", 1639, 12, true);
                WriteAttributeValue(" ", 1651, "data-control", 1652, 13, true);
#nullable restore
#line 34 "C:\Users\Hristo Ivanov\Documents\GitHub\CustomDataDisplay\DataManagementAndDisplay\DataManagementAndDisplay\Views\Home\Index.cshtml"
WriteAttributeValue(" ", 1664, Model.Fields[i].DisplayName, 1665, 28, false);

#line default
#line hidden
#nullable disable
                EndWriteAttribute();
                BeginWriteAttribute("id", " id=\"", 1694, "\"", 1728, 1);
#nullable restore
#line 34 "C:\Users\Hristo Ivanov\Documents\GitHub\CustomDataDisplay\DataManagementAndDisplay\DataManagementAndDisplay\Views\Home\Index.cshtml"
WriteAttributeValue("", 1699, Model.Fields[i].InternalName, 1699, 29, false);

#line default
#line hidden
#nullable disable
                EndWriteAttribute();
                BeginWriteAttribute("value", " value=\"", 1729, "\"", 1759, 1);
#nullable restore
#line 34 "C:\Users\Hristo Ivanov\Documents\GitHub\CustomDataDisplay\DataManagementAndDisplay\DataManagementAndDisplay\Views\Home\Index.cshtml"
WriteAttributeValue("", 1737, Model.Fields[i].Value, 1737, 22, false);

#line default
#line hidden
#nullable disable
                EndWriteAttribute();
                WriteLiteral(" data-type=\"");
#nullable restore
#line 34 "C:\Users\Hristo Ivanov\Documents\GitHub\CustomDataDisplay\DataManagementAndDisplay\DataManagementAndDisplay\Views\Home\Index.cshtml"
                                                                                                                                                                                  Write(Model.Fields[i].FieldType.ToString());

#line default
#line hidden
#nullable disable
                WriteLiteral("\" />\r\n                                </div>\r\n");
#nullable restore
#line 36 "C:\Users\Hristo Ivanov\Documents\GitHub\CustomDataDisplay\DataManagementAndDisplay\DataManagementAndDisplay\Views\Home\Index.cshtml"
                            }
                            else
                            {

#line default
#line hidden
#nullable disable
                WriteLiteral("                                <div class=\"form-group\">\r\n                                    ");
#nullable restore
#line 40 "C:\Users\Hristo Ivanov\Documents\GitHub\CustomDataDisplay\DataManagementAndDisplay\DataManagementAndDisplay\Views\Home\Index.cshtml"
                               Write(Model.Fields[i].DisplayName);

#line default
#line hidden
#nullable disable
                WriteLiteral("\r\n                                    <select");
                BeginWriteAttribute("id", " id=\"", 2118, "\"", 2152, 1);
#nullable restore
#line 41 "C:\Users\Hristo Ivanov\Documents\GitHub\CustomDataDisplay\DataManagementAndDisplay\DataManagementAndDisplay\Views\Home\Index.cshtml"
WriteAttributeValue("", 2123, Model.Fields[i].InternalName, 2123, 29, false);

#line default
#line hidden
#nullable disable
                EndWriteAttribute();
                BeginWriteAttribute("class", " class=\"", 2153, "\"", 2215, 3);
                WriteAttributeValue("", 2161, "form-control", 2161, 12, true);
                WriteAttributeValue(" ", 2173, "data-control", 2174, 13, true);
#nullable restore
#line 41 "C:\Users\Hristo Ivanov\Documents\GitHub\CustomDataDisplay\DataManagementAndDisplay\DataManagementAndDisplay\Views\Home\Index.cshtml"
WriteAttributeValue(" ", 2186, Model.Fields[i].DisplayName, 2187, 28, false);

#line default
#line hidden
#nullable disable
                EndWriteAttribute();
                WriteLiteral(">\r\n                                        ");
                __tagHelperExecutionContext = __tagHelperScopeManager.Begin("option", global::Microsoft.AspNetCore.Razor.TagHelpers.TagMode.StartTagAndEndTag, "4442150443b84068f473a97420a2d717d813baeb17636", async() => {
                }
                );
                __Microsoft_AspNetCore_Mvc_TagHelpers_OptionTagHelper = CreateTagHelper<global::Microsoft.AspNetCore.Mvc.TagHelpers.OptionTagHelper>();
                __tagHelperExecutionContext.Add(__Microsoft_AspNetCore_Mvc_TagHelpers_OptionTagHelper);
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
                WriteLiteral("\r\n");
#nullable restore
#line 43 "C:\Users\Hristo Ivanov\Documents\GitHub\CustomDataDisplay\DataManagementAndDisplay\DataManagementAndDisplay\Views\Home\Index.cshtml"
                                         for (int j = 0; j < Model.Fields[i].PossibleValues.Count; j++)
                                        {

#line default
#line hidden
#nullable disable
                WriteLiteral("                                            ");
                __tagHelperExecutionContext = __tagHelperScopeManager.Begin("option", global::Microsoft.AspNetCore.Razor.TagHelpers.TagMode.StartTagAndEndTag, "4442150443b84068f473a97420a2d717d813baeb19369", async() => {
#nullable restore
#line 45 "C:\Users\Hristo Ivanov\Documents\GitHub\CustomDataDisplay\DataManagementAndDisplay\DataManagementAndDisplay\Views\Home\Index.cshtml"
                                                                                          Write(Model.Fields[i].PossibleValues[j]);

#line default
#line hidden
#nullable disable
                }
                );
                __Microsoft_AspNetCore_Mvc_TagHelpers_OptionTagHelper = CreateTagHelper<global::Microsoft.AspNetCore.Mvc.TagHelpers.OptionTagHelper>();
                __tagHelperExecutionContext.Add(__Microsoft_AspNetCore_Mvc_TagHelpers_OptionTagHelper);
                BeginWriteTagHelperAttribute();
#nullable restore
#line 45 "C:\Users\Hristo Ivanov\Documents\GitHub\CustomDataDisplay\DataManagementAndDisplay\DataManagementAndDisplay\Views\Home\Index.cshtml"
                                               WriteLiteral(Model.Fields[i].PossibleValues[j]);

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
#line 46 "C:\Users\Hristo Ivanov\Documents\GitHub\CustomDataDisplay\DataManagementAndDisplay\DataManagementAndDisplay\Views\Home\Index.cshtml"
                                        }

#line default
#line hidden
#nullable disable
                WriteLiteral("                                    </select>\r\n                                </div>\r\n");
#nullable restore
#line 49 "C:\Users\Hristo Ivanov\Documents\GitHub\CustomDataDisplay\DataManagementAndDisplay\DataManagementAndDisplay\Views\Home\Index.cshtml"
                            }
                        }
                    }

#line default
#line hidden
#nullable disable
                WriteLiteral("                    <div class=\"form-group\">\r\n                        <input style=\"width:318px;\" id=\"btnGet\" type=\"submit\" value=\"Search\" class=\"btn btn-primary\" />\r\n                    </div>\r\n                ");
            }
            );
            __Microsoft_AspNetCore_Mvc_TagHelpers_FormTagHelper = CreateTagHelper<global::Microsoft.AspNetCore.Mvc.TagHelpers.FormTagHelper>();
            __tagHelperExecutionContext.Add(__Microsoft_AspNetCore_Mvc_TagHelpers_FormTagHelper);
            __Microsoft_AspNetCore_Mvc_TagHelpers_RenderAtEndOfFormTagHelper = CreateTagHelper<global::Microsoft.AspNetCore.Mvc.TagHelpers.RenderAtEndOfFormTagHelper>();
            __tagHelperExecutionContext.Add(__Microsoft_AspNetCore_Mvc_TagHelpers_RenderAtEndOfFormTagHelper);
            __tagHelperExecutionContext.AddHtmlAttribute(__tagHelperAttribute_1);
            await __tagHelperRunner.RunAsync(__tagHelperExecutionContext);
            if (!__tagHelperExecutionContext.Output.IsContentModified)
            {
                await __tagHelperExecutionContext.SetOutputContentAsync();
            }
            Write(__tagHelperExecutionContext.Output);
            __tagHelperExecutionContext = __tagHelperScopeManager.End();
            WriteLiteral(@"
            </div>
            <div class=""loading"">
                <div></div>
                <div></div>
                <div></div>
                <div></div>
                <div></div>
            </div>
            <div class=""results"">
                <img class=""no-results message-to-be-hidden"" src=""/css/NoResultsImage.png"" />
                <table oncontextmenu=""return false;"" id=""table-result"" class=""justify-content-between table-to-be-hidden"">
                    <tr>
                        <th class=""custom-table-heading"">№</th>
");
#nullable restore
#line 69 "C:\Users\Hristo Ivanov\Documents\GitHub\CustomDataDisplay\DataManagementAndDisplay\DataManagementAndDisplay\Views\Home\Index.cshtml"
                         for (int i = 1; i < @Model.Fields.Count; i++)
                        {

#line default
#line hidden
#nullable disable
            WriteLiteral("                            <th class=\"custom-table-heading\">");
#nullable restore
#line 71 "C:\Users\Hristo Ivanov\Documents\GitHub\CustomDataDisplay\DataManagementAndDisplay\DataManagementAndDisplay\Views\Home\Index.cshtml"
                                                        Write(Model.Fields[i].DisplayName);

#line default
#line hidden
#nullable disable
            WriteLiteral("</th>\r\n");
#nullable restore
#line 72 "C:\Users\Hristo Ivanov\Documents\GitHub\CustomDataDisplay\DataManagementAndDisplay\DataManagementAndDisplay\Views\Home\Index.cshtml"
                        }

#line default
#line hidden
#nullable disable
            WriteLiteral("                        <th class=\"custom-table-heading\">");
#nullable restore
#line 73 "C:\Users\Hristo Ivanov\Documents\GitHub\CustomDataDisplay\DataManagementAndDisplay\DataManagementAndDisplay\Views\Home\Index.cshtml"
                                                    Write(Model.timeField.DisplayName);

#line default
#line hidden
#nullable disable
            WriteLiteral(@"</th>
                    </tr>
                </table>
            </div>
        </div>
    </div>
    <div class=""view hide"" id=""page2"">
        <div class=""create-model-view"">
            <div class=""model-list"">
                <div class=""add-model-button"">+ New Model</div>
                <div class=""all-models"">");
            WriteLiteral("</div>\r\n            </div>\r\n            ");
            __tagHelperExecutionContext = __tagHelperScopeManager.Begin("form", global::Microsoft.AspNetCore.Razor.TagHelpers.TagMode.StartTagAndEndTag, "4442150443b84068f473a97420a2d717d813baeb25864", async() => {
                WriteLiteral(@"
                <div class=""create-model-form-element-for-name-and-password"">
                    <input class=""new-model-name"" for=""new-model-name"" placeholder=""Name""/>
                    <input class=""new-model-description"" for=""new-model-description"" placeholder=""Description""/>
                </div>
                <div class=""create-model-form-element-for-custom-fields"">
                    <div class=""added-columns-list"">
");
                WriteLiteral("                    </div>\r\n                    <div class=\"add-new-text-column\" onclick=\"AddTextColumn()\">+ New text column</div>\r\n                    <input ");
                WriteLiteral(" type=\"submit\" name=\"Create Model\" />\r\n                </div>       \r\n            ");
            }
            );
            __Microsoft_AspNetCore_Mvc_TagHelpers_FormTagHelper = CreateTagHelper<global::Microsoft.AspNetCore.Mvc.TagHelpers.FormTagHelper>();
            __tagHelperExecutionContext.Add(__Microsoft_AspNetCore_Mvc_TagHelpers_FormTagHelper);
            __Microsoft_AspNetCore_Mvc_TagHelpers_RenderAtEndOfFormTagHelper = CreateTagHelper<global::Microsoft.AspNetCore.Mvc.TagHelpers.RenderAtEndOfFormTagHelper>();
            __tagHelperExecutionContext.Add(__Microsoft_AspNetCore_Mvc_TagHelpers_RenderAtEndOfFormTagHelper);
            __tagHelperExecutionContext.AddHtmlAttribute(__tagHelperAttribute_2);
            __tagHelperExecutionContext.AddHtmlAttribute(__tagHelperAttribute_3);
            await __tagHelperRunner.RunAsync(__tagHelperExecutionContext);
            if (!__tagHelperExecutionContext.Output.IsContentModified)
            {
                await __tagHelperExecutionContext.SetOutputContentAsync();
            }
            Write(__tagHelperExecutionContext.Output);
            __tagHelperExecutionContext = __tagHelperScopeManager.End();
            WriteLiteral("\r\n        </div>\r\n    </div>\r\n</div>\r\n");
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
        public global::Microsoft.AspNetCore.Mvc.Rendering.IHtmlHelper<DataModel.Model> Html { get; private set; }
    }
}
#pragma warning restore 1591
