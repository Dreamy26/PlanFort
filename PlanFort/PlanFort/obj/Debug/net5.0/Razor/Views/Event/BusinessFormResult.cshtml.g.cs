#pragma checksum "C:\Users\there\Downloads\Grand Circus\PlanFort\PlanFort\PlanFort\Views\Event\BusinessFormResult.cshtml" "{ff1816ec-aa5e-4d10-87f7-6f4963833460}" "3d895bdd3f019c12139512ce0e4cfd6d9667719e"
// <auto-generated/>
#pragma warning disable 1591
[assembly: global::Microsoft.AspNetCore.Razor.Hosting.RazorCompiledItemAttribute(typeof(AspNetCore.Views_Event_BusinessFormResult), @"mvc.1.0.view", @"/Views/Event/BusinessFormResult.cshtml")]
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
#line 1 "C:\Users\there\Downloads\Grand Circus\PlanFort\PlanFort\PlanFort\Views\_ViewImports.cshtml"
using PlanFort;

#line default
#line hidden
#nullable disable
#nullable restore
#line 2 "C:\Users\there\Downloads\Grand Circus\PlanFort\PlanFort\PlanFort\Views\_ViewImports.cshtml"
using PlanFort.Models;

#line default
#line hidden
#nullable disable
    [global::Microsoft.AspNetCore.Razor.Hosting.RazorSourceChecksumAttribute(@"SHA1", @"3d895bdd3f019c12139512ce0e4cfd6d9667719e", @"/Views/Event/BusinessFormResult.cshtml")]
    [global::Microsoft.AspNetCore.Razor.Hosting.RazorSourceChecksumAttribute(@"SHA1", @"4e84f49a00425413fed038082a0e26c6f9a83070", @"/Views/_ViewImports.cshtml")]
    public class Views_Event_BusinessFormResult : global::Microsoft.AspNetCore.Mvc.Razor.RazorPage<PlanFort.Models.ViewModels.BusinessFormResultVM>
    {
        #pragma warning disable 1998
        public async override global::System.Threading.Tasks.Task ExecuteAsync()
        {
            WriteLiteral("\r\n\r\n");
            WriteLiteral("\r\n<ul>\r\n");
#nullable restore
#line 6 "C:\Users\there\Downloads\Grand Circus\PlanFort\PlanFort\PlanFort\Views\Event\BusinessFormResult.cshtml"
     foreach (var business in Model.Businesses)
    {

#line default
#line hidden
#nullable disable
            WriteLiteral("        <li>");
#nullable restore
#line 8 "C:\Users\there\Downloads\Grand Circus\PlanFort\PlanFort\PlanFort\Views\Event\BusinessFormResult.cshtml"
       Write(business.Name);

#line default
#line hidden
#nullable disable
            WriteLiteral("</li>\r\n");
#nullable restore
#line 9 "C:\Users\there\Downloads\Grand Circus\PlanFort\PlanFort\PlanFort\Views\Event\BusinessFormResult.cshtml"

    }

#line default
#line hidden
#nullable disable
            WriteLiteral("</ul>");
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
        public global::Microsoft.AspNetCore.Mvc.Rendering.IHtmlHelper<PlanFort.Models.ViewModels.BusinessFormResultVM> Html { get; private set; }
    }
}
#pragma warning restore 1591