#pragma checksum "C:\Users\izabela.kuzma\source\repos\LinkAggregatorProject — kopia\LinkAggregatorProject\Views\Link\Index.cshtml" "{ff1816ec-aa5e-4d10-87f7-6f4963833460}" "84156d885ad1726e1afd9e0758c6483e711b99e7"
// <auto-generated/>
#pragma warning disable 1591
[assembly: global::Microsoft.AspNetCore.Razor.Hosting.RazorCompiledItemAttribute(typeof(AspNetCore.Views_Link_Index), @"mvc.1.0.view", @"/Views/Link/Index.cshtml")]
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
#line 1 "C:\Users\izabela.kuzma\source\repos\LinkAggregatorProject — kopia\LinkAggregatorProject\Views\_ViewImports.cshtml"
using LinkAggregatorProject;

#line default
#line hidden
#nullable disable
#nullable restore
#line 2 "C:\Users\izabela.kuzma\source\repos\LinkAggregatorProject — kopia\LinkAggregatorProject\Views\_ViewImports.cshtml"
using LinkAggregatorProject.Models;

#line default
#line hidden
#nullable disable
#nullable restore
#line 1 "C:\Users\izabela.kuzma\source\repos\LinkAggregatorProject — kopia\LinkAggregatorProject\Views\Link\Index.cshtml"
using Microsoft.AspNetCore.Http;

#line default
#line hidden
#nullable disable
    [global::Microsoft.AspNetCore.Razor.Hosting.RazorSourceChecksumAttribute(@"SHA1", @"84156d885ad1726e1afd9e0758c6483e711b99e7", @"/Views/Link/Index.cshtml")]
    [global::Microsoft.AspNetCore.Razor.Hosting.RazorSourceChecksumAttribute(@"SHA1", @"73abd333d0db0e5d559eb515f92a8c24e1b2f71a", @"/Views/_ViewImports.cshtml")]
    public class Views_Link_Index : global::Microsoft.AspNetCore.Mvc.Razor.RazorPage<cloudscribe.Pagination.Models.PagedResult<LinkRatingViewModel>>
    {
        private static readonly global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute __tagHelperAttribute_0 = new global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute("name", "_PaginationPartial", global::Microsoft.AspNetCore.Razor.TagHelpers.HtmlAttributeValueStyle.DoubleQuotes);
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
        private global::Microsoft.AspNetCore.Mvc.TagHelpers.PartialTagHelper __Microsoft_AspNetCore_Mvc_TagHelpers_PartialTagHelper;
        #pragma warning disable 1998
        public async override global::System.Threading.Tasks.Task ExecuteAsync()
        {
            WriteLiteral("\r\n");
#nullable restore
#line 5 "C:\Users\izabela.kuzma\source\repos\LinkAggregatorProject — kopia\LinkAggregatorProject\Views\Link\Index.cshtml"
  
    ViewData["Title"] = "Index";
    ViewData["Controller"] = "Link";
    ViewData["Action"] = "Index";  

#line default
#line hidden
#nullable disable
            WriteLiteral("\r\n<div class=\"jumbotron\">\r\n    <h1>Agregator linków</h1> \r\n</div>\r\n\r\n");
#nullable restore
#line 15 "C:\Users\izabela.kuzma\source\repos\LinkAggregatorProject — kopia\LinkAggregatorProject\Views\Link\Index.cshtml"
 foreach (var item in Model.Data)
{

#line default
#line hidden
#nullable disable
            WriteLiteral("<div class=\"row borders\">\r\n    <div class=\"col-md-10\">\r\n\r\n        <h3>\r\n            <strong>");
#nullable restore
#line 21 "C:\Users\izabela.kuzma\source\repos\LinkAggregatorProject — kopia\LinkAggregatorProject\Views\Link\Index.cshtml"
               Write(Html.DisplayFor(modelItem => item.Title));

#line default
#line hidden
#nullable disable
            WriteLiteral("</strong>\r\n        </h3>\r\n        <span class=\"lead\"><a");
            BeginWriteAttribute("href", " href=\"", 592, "\"", 646, 1);
#nullable restore
#line 23 "C:\Users\izabela.kuzma\source\repos\LinkAggregatorProject — kopia\LinkAggregatorProject\Views\Link\Index.cshtml"
WriteAttributeValue("", 599, Html.DisplayFor(modelItem => item.LinkAddress), 599, 47, false);

#line default
#line hidden
#nullable disable
            EndWriteAttribute();
            WriteLiteral(">");
#nullable restore
#line 23 "C:\Users\izabela.kuzma\source\repos\LinkAggregatorProject — kopia\LinkAggregatorProject\Views\Link\Index.cshtml"
                                                                                Write(Html.DisplayFor(modelItem => item.LinkAddress));

#line default
#line hidden
#nullable disable
            WriteLiteral("</a></span>\r\n\r\n        <p style=\"text-align:left\">Data dodania: ");
#nullable restore
#line 25 "C:\Users\izabela.kuzma\source\repos\LinkAggregatorProject — kopia\LinkAggregatorProject\Views\Link\Index.cshtml"
                                            Write(Html.DisplayFor(modelItem => item.AddingData));

#line default
#line hidden
#nullable disable
            WriteLiteral("</p>\r\n\r\n    </div>\r\n    <div class=\"col-md-2\">\r\n");
#nullable restore
#line 29 "C:\Users\izabela.kuzma\source\repos\LinkAggregatorProject — kopia\LinkAggregatorProject\Views\Link\Index.cshtml"
         if (Context.Session.GetString("UserID") != null && Context.Session.GetString("UserID") != item.UserId.ToString() && item.IsRate == 0)
        {         
                

#line default
#line hidden
#nullable disable
#nullable restore
#line 31 "C:\Users\izabela.kuzma\source\repos\LinkAggregatorProject — kopia\LinkAggregatorProject\Views\Link\Index.cshtml"
                 using (Html.BeginForm("RatingAdd", "Link"))
                {
                    

#line default
#line hidden
#nullable disable
#nullable restore
#line 33 "C:\Users\izabela.kuzma\source\repos\LinkAggregatorProject — kopia\LinkAggregatorProject\Views\Link\Index.cshtml"
               Write(Html.Hidden("LinkId", item.LinkId));

#line default
#line hidden
#nullable disable
            WriteLiteral("                    <span style=\"font-size:large\"> <strong>Ocena ");
#nullable restore
#line 34 "C:\Users\izabela.kuzma\source\repos\LinkAggregatorProject — kopia\LinkAggregatorProject\Views\Link\Index.cshtml"
                                                            Write(Html.DisplayFor(modelItem => item.Sum));

#line default
#line hidden
#nullable disable
            WriteLiteral(" </strong></span>\r\n                    <input class=\"btn btn-success\" type=\"submit\" value=\"+\" />\r\n");
#nullable restore
#line 36 "C:\Users\izabela.kuzma\source\repos\LinkAggregatorProject — kopia\LinkAggregatorProject\Views\Link\Index.cshtml"
                }

#line default
#line hidden
#nullable disable
#nullable restore
#line 36 "C:\Users\izabela.kuzma\source\repos\LinkAggregatorProject — kopia\LinkAggregatorProject\Views\Link\Index.cshtml"
                          
        }
        else if (Context.Session.GetString("UserID") != null && Context.Session.GetString("UserID") != item.UserId.ToString() && item.IsRate == 1)
        {  
        

#line default
#line hidden
#nullable disable
#nullable restore
#line 40 "C:\Users\izabela.kuzma\source\repos\LinkAggregatorProject — kopia\LinkAggregatorProject\Views\Link\Index.cshtml"
         using (Html.BeginForm("RatingRemove", "Link"))
        {
           
            

#line default
#line hidden
#nullable disable
#nullable restore
#line 43 "C:\Users\izabela.kuzma\source\repos\LinkAggregatorProject — kopia\LinkAggregatorProject\Views\Link\Index.cshtml"
       Write(Html.Hidden("RateId", item.RateId));

#line default
#line hidden
#nullable disable
            WriteLiteral("            <span style=\"font-size:large\"> <strong>Ocena ");
#nullable restore
#line 44 "C:\Users\izabela.kuzma\source\repos\LinkAggregatorProject — kopia\LinkAggregatorProject\Views\Link\Index.cshtml"
                                                    Write(Html.DisplayFor(modelItem => item.Sum));

#line default
#line hidden
#nullable disable
            WriteLiteral(" </strong></span>\r\n            <input class=\"btn btn-danger\" type=\"submit\" value=\"-\" />\r\n");
#nullable restore
#line 46 "C:\Users\izabela.kuzma\source\repos\LinkAggregatorProject — kopia\LinkAggregatorProject\Views\Link\Index.cshtml"
        }

#line default
#line hidden
#nullable disable
#nullable restore
#line 46 "C:\Users\izabela.kuzma\source\repos\LinkAggregatorProject — kopia\LinkAggregatorProject\Views\Link\Index.cshtml"
         
        }
        else if (Context.Session.GetString("UserID") != null && Context.Session.GetString("UserID") == item.UserId.ToString())
        {

#line default
#line hidden
#nullable disable
            WriteLiteral("            <span style=\"font-size:large\"> <strong>Ocena: ");
#nullable restore
#line 50 "C:\Users\izabela.kuzma\source\repos\LinkAggregatorProject — kopia\LinkAggregatorProject\Views\Link\Index.cshtml"
                                                     Write(Html.DisplayFor(modelItem => item.Sum));

#line default
#line hidden
#nullable disable
            WriteLiteral(" </strong></span>\r\n");
#nullable restore
#line 51 "C:\Users\izabela.kuzma\source\repos\LinkAggregatorProject — kopia\LinkAggregatorProject\Views\Link\Index.cshtml"
        }
        else
        { 

#line default
#line hidden
#nullable disable
            WriteLiteral("            <span style=\"font-size:large\"> <strong>Ocena: ");
#nullable restore
#line 54 "C:\Users\izabela.kuzma\source\repos\LinkAggregatorProject — kopia\LinkAggregatorProject\Views\Link\Index.cshtml"
                                                     Write(Html.DisplayFor(modelItem => item.Sum));

#line default
#line hidden
#nullable disable
            WriteLiteral(" </strong></span>    \r\n");
#nullable restore
#line 55 "C:\Users\izabela.kuzma\source\repos\LinkAggregatorProject — kopia\LinkAggregatorProject\Views\Link\Index.cshtml"
        }

#line default
#line hidden
#nullable disable
            WriteLiteral("    </div>\r\n    </div>\r\n");
#nullable restore
#line 58 "C:\Users\izabela.kuzma\source\repos\LinkAggregatorProject — kopia\LinkAggregatorProject\Views\Link\Index.cshtml"
    }

#line default
#line hidden
#nullable disable
            WriteLiteral("    ");
            __tagHelperExecutionContext = __tagHelperScopeManager.Begin("partial", global::Microsoft.AspNetCore.Razor.TagHelpers.TagMode.SelfClosing, "84156d885ad1726e1afd9e0758c6483e711b99e711431", async() => {
            }
            );
            __Microsoft_AspNetCore_Mvc_TagHelpers_PartialTagHelper = CreateTagHelper<global::Microsoft.AspNetCore.Mvc.TagHelpers.PartialTagHelper>();
            __tagHelperExecutionContext.Add(__Microsoft_AspNetCore_Mvc_TagHelpers_PartialTagHelper);
            __Microsoft_AspNetCore_Mvc_TagHelpers_PartialTagHelper.Name = (string)__tagHelperAttribute_0.Value;
            __tagHelperExecutionContext.AddTagHelperAttribute(__tagHelperAttribute_0);
#nullable restore
#line 59 "C:\Users\izabela.kuzma\source\repos\LinkAggregatorProject — kopia\LinkAggregatorProject\Views\Link\Index.cshtml"
__Microsoft_AspNetCore_Mvc_TagHelpers_PartialTagHelper.ViewData = ViewData;

#line default
#line hidden
#nullable disable
            __tagHelperExecutionContext.AddTagHelperAttribute("view-data", __Microsoft_AspNetCore_Mvc_TagHelpers_PartialTagHelper.ViewData, global::Microsoft.AspNetCore.Razor.TagHelpers.HtmlAttributeValueStyle.DoubleQuotes);
#nullable restore
#line 59 "C:\Users\izabela.kuzma\source\repos\LinkAggregatorProject — kopia\LinkAggregatorProject\Views\Link\Index.cshtml"
__Microsoft_AspNetCore_Mvc_TagHelpers_PartialTagHelper.Model = Model;

#line default
#line hidden
#nullable disable
            __tagHelperExecutionContext.AddTagHelperAttribute("model", __Microsoft_AspNetCore_Mvc_TagHelpers_PartialTagHelper.Model, global::Microsoft.AspNetCore.Razor.TagHelpers.HtmlAttributeValueStyle.DoubleQuotes);
            await __tagHelperRunner.RunAsync(__tagHelperExecutionContext);
            if (!__tagHelperExecutionContext.Output.IsContentModified)
            {
                await __tagHelperExecutionContext.SetOutputContentAsync();
            }
            Write(__tagHelperExecutionContext.Output);
            __tagHelperExecutionContext = __tagHelperScopeManager.End();
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
        public global::Microsoft.AspNetCore.Mvc.Rendering.IHtmlHelper<cloudscribe.Pagination.Models.PagedResult<LinkRatingViewModel>> Html { get; private set; }
    }
}
#pragma warning restore 1591
