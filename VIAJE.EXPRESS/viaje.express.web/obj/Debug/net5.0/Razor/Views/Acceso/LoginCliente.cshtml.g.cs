#pragma checksum "C:\Users\Eduardo\Source\Repos\DemoViajeExpress01\VIAJE.EXPRESS\viaje.express.web\Views\Acceso\LoginCliente.cshtml" "{ff1816ec-aa5e-4d10-87f7-6f4963833460}" "b1116c06156faa63e021f96ecb550c9c98fa5619"
// <auto-generated/>
#pragma warning disable 1591
[assembly: global::Microsoft.AspNetCore.Razor.Hosting.RazorCompiledItemAttribute(typeof(AspNetCore.Views_Acceso_LoginCliente), @"mvc.1.0.view", @"/Views/Acceso/LoginCliente.cshtml")]
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
#line 1 "C:\Users\Eduardo\Source\Repos\DemoViajeExpress01\VIAJE.EXPRESS\viaje.express.web\Views\_ViewImports.cshtml"
using viaje.express.web;

#line default
#line hidden
#nullable disable
#nullable restore
#line 2 "C:\Users\Eduardo\Source\Repos\DemoViajeExpress01\VIAJE.EXPRESS\viaje.express.web\Views\_ViewImports.cshtml"
using viaje.express.web.Models;

#line default
#line hidden
#nullable disable
    [global::Microsoft.AspNetCore.Razor.Hosting.RazorSourceChecksumAttribute(@"SHA1", @"b1116c06156faa63e021f96ecb550c9c98fa5619", @"/Views/Acceso/LoginCliente.cshtml")]
    [global::Microsoft.AspNetCore.Razor.Hosting.RazorSourceChecksumAttribute(@"SHA1", @"8a3a712e40331e5f11ccaaa476e32ec2d54c83a5", @"/Views/_ViewImports.cshtml")]
    public class Views_Acceso_LoginCliente : global::Microsoft.AspNetCore.Mvc.Razor.RazorPage<dynamic>
    {
        private static readonly global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute __tagHelperAttribute_0 = new global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute("src", new global::Microsoft.AspNetCore.Html.HtmlString("~/images/logo-taxi.jpg"), global::Microsoft.AspNetCore.Razor.TagHelpers.HtmlAttributeValueStyle.DoubleQuotes);
        private static readonly global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute __tagHelperAttribute_1 = new global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute("style", new global::Microsoft.AspNetCore.Html.HtmlString("width:200px; height:200px"), global::Microsoft.AspNetCore.Razor.TagHelpers.HtmlAttributeValueStyle.DoubleQuotes);
        private static readonly global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute __tagHelperAttribute_2 = new global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute("type", new global::Microsoft.AspNetCore.Html.HtmlString("module"), global::Microsoft.AspNetCore.Razor.TagHelpers.HtmlAttributeValueStyle.DoubleQuotes);
        private static readonly global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute __tagHelperAttribute_3 = new global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute("src", new global::Microsoft.AspNetCore.Html.HtmlString("~/assets/js/expressJS/login.js"), global::Microsoft.AspNetCore.Razor.TagHelpers.HtmlAttributeValueStyle.DoubleQuotes);
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
#nullable restore
#line 2 "C:\Users\Eduardo\Source\Repos\DemoViajeExpress01\VIAJE.EXPRESS\viaje.express.web\Views\Acceso\LoginCliente.cshtml"
  
    ViewData["Title"] = "LoginCliente";
    Layout = "~/Views/Shared/_LayoutLogin.cshtml";

#line default
#line hidden
#nullable disable
            WriteLiteral(@"<div aria-live=""polite"" aria-atomic=""true"">
    <div class=""toast-container position-absolute bottom-0 end-0 p-3"" id=""toast-container"">
        <!-- toasts are created dynamically -->
    </div>
</div>
<!-- Pre-loader start -->
<div class=""theme-loader"">
    <div class=""loader-track"">
        <div class=""preloader-wrapper"">
            <div class=""spinner-layer spinner-blue"">
                <div class=""circle-clipper left"">
                    <div class=""circle""></div>
                </div>
                <div class=""gap-patch"">
                    <div class=""circle""></div>
                </div>
                <div class=""circle-clipper right"">
                    <div class=""circle""></div>
                </div>
            </div>
            <div class=""spinner-layer spinner-red"">
                <div class=""circle-clipper left"">
                    <div class=""circle""></div>
                </div>
                <div class=""gap-patch"">
                    <div class=""circle");
            WriteLiteral(@"""></div>
                </div>
                <div class=""circle-clipper right"">
                    <div class=""circle""></div>
                </div>
            </div>

            <div class=""spinner-layer spinner-yellow"">
                <div class=""circle-clipper left"">
                    <div class=""circle""></div>
                </div>
                <div class=""gap-patch"">
                    <div class=""circle""></div>
                </div>
                <div class=""circle-clipper right"">
                    <div class=""circle""></div>
                </div>
            </div>

            <div class=""spinner-layer spinner-green"">
                <div class=""circle-clipper left"">
                    <div class=""circle""></div>
                </div>
                <div class=""gap-patch"">
                    <div class=""circle""></div>
                </div>
                <div class=""circle-clipper right"">
                    <div class=""circle""></div>
               ");
            WriteLiteral(@" </div>
            </div>
        </div>
    </div>
</div>

<!-- Pre-loader end -->
<section class=""login-block"">
    <!-- Container-fluid starts -->
    <div class=""container-fluid"">
        <div class=""row"">
            <div class=""col-sm-12"">
                <!-- Authentication card start -->
                <div class=""auth-box card"">
                    <div class=""card-block"">
                        <div class=""row m-b-20"">
                            <div class=""col-md-12"">
                                <h3 class=""text-center txt-primary"">Iniciar Sesión</h3>
                            </div>
                        </div>
                        <div class=""text-center"">
                            ");
            __tagHelperExecutionContext = __tagHelperScopeManager.Begin("img", global::Microsoft.AspNetCore.Razor.TagHelpers.TagMode.SelfClosing, "b1116c06156faa63e021f96ecb550c9c98fa56197931", async() => {
            }
            );
            __Microsoft_AspNetCore_Mvc_Razor_TagHelpers_UrlResolutionTagHelper = CreateTagHelper<global::Microsoft.AspNetCore.Mvc.Razor.TagHelpers.UrlResolutionTagHelper>();
            __tagHelperExecutionContext.Add(__Microsoft_AspNetCore_Mvc_Razor_TagHelpers_UrlResolutionTagHelper);
            __tagHelperExecutionContext.AddHtmlAttribute(__tagHelperAttribute_0);
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
                        <br />
                        <div class=""form-group form-primary"">
                            <label class=""float-label"">Correo</label>
                            <input type=""text"" name=""correo"" id=""correo"" class=""form-control""");
            BeginWriteAttribute("required", " required=\"", 3254, "\"", 3265, 0);
            EndWriteAttribute();
            WriteLiteral(@">
                            <span class=""form-bar""></span>
                        </div>
                        <div class=""form-group form-primary"">
                            <label class=""float-label"">Contraseña</label>
                            <input type=""password"" name=""clave"" id=""clave"" class=""form-control""");
            BeginWriteAttribute("required", " required=\"", 3594, "\"", 3605, 0);
            EndWriteAttribute();
            WriteLiteral(@">
                            <span class=""form-bar""></span>
                        </div>
                        <div class=""row m-t-25 text-left"">
                            <div class=""col-12"">
                                <div class=""checkbox-fade fade-in-primary"">
                                    <label>
                                        <input type=""checkbox""");
            BeginWriteAttribute("value", " value=\"", 3995, "\"", 4003, 0);
            EndWriteAttribute();
            WriteLiteral(@">
                                        <span class=""cr"">
                                            <i class=""cr-icon icofont icofont-ui-check txt-primary""></i>
                                        </span>
                                        <span class=""text-inverse"">Recordarme</span>
                                    </label>
                                </div>
                                <div class=""forgot-phone text-right float-right"">
                                    <a href=""auth-reset-password.html"" class=""text-right f-w-600"">
                                        Olvidaste tu contraseña?
                                    </a>
                                </div>
                            </div>
                        </div>
                        <div class=""row m-t-30"">
                            <div class=""col-md-12"">
                                <button type=""submit"" id=""loginCliente""
                                        class=""btn btn-prima");
            WriteLiteral(@"ry btn-md btn-block waves-effect text-center m-b-20"">
                                    INGRESAR
                                </button>

                            </div>
                        </div>
                    </div>
                </div>
                <!-- end of form -->
            </div>
            <!-- Authentication card end -->
        </div>
        <!-- end of col-sm-12 -->
    </div>
</section>
");
            DefineSection("Scripts", async() => {
                WriteLiteral("\r\n    ");
                __tagHelperExecutionContext = __tagHelperScopeManager.Begin("script", global::Microsoft.AspNetCore.Razor.TagHelpers.TagMode.StartTagAndEndTag, "b1116c06156faa63e021f96ecb550c9c98fa561912149", async() => {
                }
                );
                __Microsoft_AspNetCore_Mvc_Razor_TagHelpers_UrlResolutionTagHelper = CreateTagHelper<global::Microsoft.AspNetCore.Mvc.Razor.TagHelpers.UrlResolutionTagHelper>();
                __tagHelperExecutionContext.Add(__Microsoft_AspNetCore_Mvc_Razor_TagHelpers_UrlResolutionTagHelper);
                __tagHelperExecutionContext.AddHtmlAttribute(__tagHelperAttribute_2);
                __tagHelperExecutionContext.AddHtmlAttribute(__tagHelperAttribute_3);
                await __tagHelperRunner.RunAsync(__tagHelperExecutionContext);
                if (!__tagHelperExecutionContext.Output.IsContentModified)
                {
                    await __tagHelperExecutionContext.SetOutputContentAsync();
                }
                Write(__tagHelperExecutionContext.Output);
                __tagHelperExecutionContext = __tagHelperScopeManager.End();
                WriteLiteral("\r\n");
            }
            );
            WriteLiteral("\r\n\r\n");
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
