#pragma checksum "F:\German Interview\hahnsoftwareentwicklung\Hahn.ApplicatonProcess.Application\Hahn.ApplicatonProcess.December2020.Web\Views\ApplicantModels\Create.cshtml" "{ff1816ec-aa5e-4d10-87f7-6f4963833460}" "7830ceee0f9610327dc4cc5cafb3044208b2d50f"
// <auto-generated/>
#pragma warning disable 1591
[assembly: global::Microsoft.AspNetCore.Razor.Hosting.RazorCompiledItemAttribute(typeof(AspNetCore.Views_ApplicantModels_Create), @"mvc.1.0.view", @"/Views/ApplicantModels/Create.cshtml")]
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
    [global::Microsoft.AspNetCore.Razor.Hosting.RazorSourceChecksumAttribute(@"SHA1", @"7830ceee0f9610327dc4cc5cafb3044208b2d50f", @"/Views/ApplicantModels/Create.cshtml")]
    public class Views_ApplicantModels_Create : global::Microsoft.AspNetCore.Mvc.Razor.RazorPage<Hahn.ApplicatonProcess.December2020.Domain.Model.ApplicantModel>
    {
        #pragma warning disable 1998
        public async override global::System.Threading.Tasks.Task ExecuteAsync()
        {
            WriteLiteral("\r\n");
#nullable restore
#line 3 "F:\German Interview\hahnsoftwareentwicklung\Hahn.ApplicatonProcess.Application\Hahn.ApplicatonProcess.December2020.Web\Views\ApplicantModels\Create.cshtml"
  
    ViewData["Title"] = "Create";

#line default
#line hidden
#nullable disable
            WriteLiteral(@"
<h1>Create</h1>

<h4>ApplicantModel</h4>
<hr />
<div class=""row"">
    <div class=""col-md-4"">
        <form asp-action=""Create"">
            <div asp-validation-summary=""ModelOnly"" class=""text-danger""></div>
            <div class=""form-group"">
                <label asp-for=""Name"" class=""control-label""></label>
                <input asp-for=""Name"" class=""form-control"" />
                <span asp-validation-for=""Name"" class=""text-danger""></span>
            </div>
            <div class=""form-group"">
                <label asp-for=""FamilyName"" class=""control-label""></label>
                <input asp-for=""FamilyName"" class=""form-control"" />
                <span asp-validation-for=""FamilyName"" class=""text-danger""></span>
            </div>
            <div class=""form-group"">
                <label asp-for=""Address"" class=""control-label""></label>
                <input asp-for=""Address"" class=""form-control"" />
                <span asp-validation-for=""Address"" class=""text-danger""></spa");
            WriteLiteral(@"n>
            </div>
            <div class=""form-group"">
                <label asp-for=""CountryofOrigin"" class=""control-label""></label>
                <input asp-for=""CountryofOrigin"" class=""form-control"" />
                <span asp-validation-for=""CountryofOrigin"" class=""text-danger""></span>
            </div>
            <div class=""form-group"">
                <label asp-for=""EMailAddress"" class=""control-label""></label>
                <input asp-for=""EMailAddress"" class=""form-control"" />
                <span asp-validation-for=""EMailAddress"" class=""text-danger""></span>
            </div>
            <div class=""form-group"">
                <label asp-for=""Age"" class=""control-label""></label>
                <input asp-for=""Age"" class=""form-control"" />
                <span asp-validation-for=""Age"" class=""text-danger""></span>
            </div>
            <div class=""form-group form-check"">
                <label class=""form-check-label"">
                    <input class=""form-chec");
            WriteLiteral("k-input\" asp-for=\"Hired\" /> ");
#nullable restore
#line 47 "F:\German Interview\hahnsoftwareentwicklung\Hahn.ApplicatonProcess.Application\Hahn.ApplicatonProcess.December2020.Web\Views\ApplicantModels\Create.cshtml"
                                                                  Write(Html.DisplayNameFor(model => model.Hired));

#line default
#line hidden
#nullable disable
            WriteLiteral(@"
                </label>
            </div>
            <div class=""form-group"">
                <input type=""submit"" value=""Create"" class=""btn btn-primary"" />
            </div>
        </form>
    </div>
</div>

<div>
    <a asp-action=""Index"">Back to List</a>
</div>

");
            DefineSection("Scripts", async() => {
                WriteLiteral("\r\n");
#nullable restore
#line 62 "F:\German Interview\hahnsoftwareentwicklung\Hahn.ApplicatonProcess.Application\Hahn.ApplicatonProcess.December2020.Web\Views\ApplicantModels\Create.cshtml"
      await Html.RenderPartialAsync("_ValidationScriptsPartial");

#line default
#line hidden
#nullable disable
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
        public global::Microsoft.AspNetCore.Mvc.Rendering.IHtmlHelper<Hahn.ApplicatonProcess.December2020.Domain.Model.ApplicantModel> Html { get; private set; }
    }
}
#pragma warning restore 1591