#pragma checksum "C:\Users\William\OneDrive - Universidad Tecnica del Norte\Escritorio\Pfinal\VIAJE.EXPRESS\viaje.express.web\Views\Acceso\Login.cshtml" "{ff1816ec-aa5e-4d10-87f7-6f4963833460}" "4d3411b036f824477fd7bbc5d03433a463391849"
// <auto-generated/>
#pragma warning disable 1591
[assembly: global::Microsoft.AspNetCore.Razor.Hosting.RazorCompiledItemAttribute(typeof(AspNetCore.Views_Acceso_Login), @"mvc.1.0.view", @"/Views/Acceso/Login.cshtml")]
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
#line 1 "C:\Users\William\OneDrive - Universidad Tecnica del Norte\Escritorio\Pfinal\VIAJE.EXPRESS\viaje.express.web\Views\_ViewImports.cshtml"
using viaje.express.web;

#line default
#line hidden
#nullable disable
#nullable restore
#line 2 "C:\Users\William\OneDrive - Universidad Tecnica del Norte\Escritorio\Pfinal\VIAJE.EXPRESS\viaje.express.web\Views\_ViewImports.cshtml"
using viaje.express.web.Models;

#line default
#line hidden
#nullable disable
    [global::Microsoft.AspNetCore.Razor.Hosting.RazorSourceChecksumAttribute(@"SHA1", @"4d3411b036f824477fd7bbc5d03433a463391849", @"/Views/Acceso/Login.cshtml")]
    [global::Microsoft.AspNetCore.Razor.Hosting.RazorSourceChecksumAttribute(@"SHA1", @"8a3a712e40331e5f11ccaaa476e32ec2d54c83a5", @"/Views/_ViewImports.cshtml")]
    public class Views_Acceso_Login : global::Microsoft.AspNetCore.Mvc.Razor.RazorPage<viaje.express.model.Login>
    {
        private static readonly global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute __tagHelperAttribute_0 = new global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute("src", new global::Microsoft.AspNetCore.Html.HtmlString("~/assets/style_admin/assets/images/icono_taxi.jpg"), global::Microsoft.AspNetCore.Razor.TagHelpers.HtmlAttributeValueStyle.DoubleQuotes);
        private static readonly global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute __tagHelperAttribute_1 = new global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute("style", new global::Microsoft.AspNetCore.Html.HtmlString("width:200px; height:200px"), global::Microsoft.AspNetCore.Razor.TagHelpers.HtmlAttributeValueStyle.DoubleQuotes);
        private static readonly global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute __tagHelperAttribute_2 = new global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute("src", new global::Microsoft.AspNetCore.Html.HtmlString("~/assets/js/script_iniciarS.js"), global::Microsoft.AspNetCore.Razor.TagHelpers.HtmlAttributeValueStyle.DoubleQuotes);
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
#line 3 "C:\Users\William\OneDrive - Universidad Tecnica del Norte\Escritorio\Pfinal\VIAJE.EXPRESS\viaje.express.web\Views\Acceso\Login.cshtml"
  
    ViewBag.Title = "Login";
    Layout = "~/Views/Shared/_LayoutLogin.cshtml";

#line default
#line hidden
#nullable disable
            WriteLiteral(@"
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
                    <div class=""circle""></div>
                </div>
                <div class=""circle-clipper right"">
                    <div class=""circle""></div>
                </div>
            </div>

            <div class=""s");
            WriteLiteral(@"pinner-layer spinner-yellow"">
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
                </div>
            </div>
        </div>
    </div>
</div>

<!-- Pre-loader end -->
<section class=""login-block"">
    <!-- Container-fluid starts -->
    <div class=""container-fluid"">
        <d");
            WriteLiteral("iv class=\"row\">\r\n            <div class=\"danger\">\r\n                ");
#nullable restore
#line 68 "C:\Users\William\OneDrive - Universidad Tecnica del Norte\Escritorio\Pfinal\VIAJE.EXPRESS\viaje.express.web\Views\Acceso\Login.cshtml"
           Write(ViewBag.Error);

#line default
#line hidden
#nullable disable
            WriteLiteral(@"
            </div>
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
            __tagHelperExecutionContext = __tagHelperScopeManager.Begin("img", global::Microsoft.AspNetCore.Razor.TagHelpers.TagMode.SelfClosing, "4d3411b036f824477fd7bbc5d03433a4633918497831", async() => {
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
            BeginWriteAttribute("required", " required=\"", 3185, "\"", 3196, 0);
            EndWriteAttribute();
            WriteLiteral(@">
                            <span class=""form-bar""></span>
                        </div>
                        <div class=""form-group form-primary"">
                            <label class=""float-label"">Contraseña</label>
                            <input type=""password"" name=""clave"" id=""clave"" class=""form-control""");
            BeginWriteAttribute("required", " required=\"", 3525, "\"", 3536, 0);
            EndWriteAttribute();
            WriteLiteral(@">
                            <span class=""form-bar""></span>
                        </div>
                        <div class=""row m-t-25 text-left"">
                            <div class=""col-12"">
                                <div class=""checkbox-fade fade-in-primary"">
                                    <label>
                                        <input type=""checkbox""");
            BeginWriteAttribute("value", " value=\"", 3926, "\"", 3934, 0);
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
                                <button type=""submit"" onclick=""inciar_session()""
                                        class=""btn ");
            WriteLiteral(@"btn-primary btn-md btn-block waves-effect text-center m-b-20"">
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
                __tagHelperExecutionContext = __tagHelperScopeManager.Begin("script", global::Microsoft.AspNetCore.Razor.TagHelpers.TagMode.StartTagAndEndTag, "4d3411b036f824477fd7bbc5d03433a46339184912058", async() => {
                }
                );
                __Microsoft_AspNetCore_Mvc_Razor_TagHelpers_UrlResolutionTagHelper = CreateTagHelper<global::Microsoft.AspNetCore.Mvc.Razor.TagHelpers.UrlResolutionTagHelper>();
                __tagHelperExecutionContext.Add(__Microsoft_AspNetCore_Mvc_Razor_TagHelpers_UrlResolutionTagHelper);
                __tagHelperExecutionContext.AddHtmlAttribute(__tagHelperAttribute_2);
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
        public global::Microsoft.AspNetCore.Mvc.Rendering.IHtmlHelper<viaje.express.model.Login> Html { get; private set; }
    }
}
#pragma warning restore 1591
