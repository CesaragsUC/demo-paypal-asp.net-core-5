#pragma checksum "F:\Projetos ASP.NET\demo-paypal-asp.net-core-5\src\DemoPaypal\DemoPaypal\Views\Pedidos\MeusPedidos.cshtml" "{ff1816ec-aa5e-4d10-87f7-6f4963833460}" "f1ab2be6cd2bb52c9fd1e731165de0e2b48e9d03"
// <auto-generated/>
#pragma warning disable 1591
[assembly: global::Microsoft.AspNetCore.Razor.Hosting.RazorCompiledItemAttribute(typeof(DemoPaypal.Pages.Pedidos.Views_Pedidos_MeusPedidos), @"mvc.1.0.view", @"/Views/Pedidos/MeusPedidos.cshtml")]
namespace DemoPaypal.Pages.Pedidos
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
#line 1 "F:\Projetos ASP.NET\demo-paypal-asp.net-core-5\src\DemoPaypal\DemoPaypal\Views\_ViewImports.cshtml"
using DemoPaypal;

#line default
#line hidden
#nullable disable
    [global::Microsoft.AspNetCore.Razor.Hosting.RazorSourceChecksumAttribute(@"SHA1", @"f1ab2be6cd2bb52c9fd1e731165de0e2b48e9d03", @"/Views/Pedidos/MeusPedidos.cshtml")]
    [global::Microsoft.AspNetCore.Razor.Hosting.RazorSourceChecksumAttribute(@"SHA1", @"183bc9d9c764751d1d55c2751c9d5f4aedb1203b", @"/Views/_ViewImports.cshtml")]
    public class Views_Pedidos_MeusPedidos : global::Microsoft.AspNetCore.Mvc.Razor.RazorPage<IEnumerable<DemoPaypal.Model.PedidoViewModel>>
    {
        #pragma warning disable 1998
        public async override global::System.Threading.Tasks.Task ExecuteAsync()
        {
            WriteLiteral(@"

<style>
    body {
        background: #eee
    }
</style>

<div class=""container mt-5"">
    <h1 style=""text-align:center"">Meus Pedidos</h1>

    <div class=""row"">

        <div class=""col-md-12 mx-auto"">
            <table class=""table bg-white rounded border"">
                <thead>
                    <tr>
                        <th scope=""col"">#</th>
                        <th scope=""col"">Usuario</th>
                        <th scope=""col"">Data Pedido</th>
                        <th scope=""col"">Data Pagamento</th>
                        <th scope=""col"">Status</th>
                        <th scope=""col"">R$</th>
                        <th scope=""col"">Produto</th>
                        <th scope=""col"">Numero Pedido</th>
                        <th scope=""col"">Pago?</th>
                    </tr>
                </thead>
                <tbody>
");
#nullable restore
#line 31 "F:\Projetos ASP.NET\demo-paypal-asp.net-core-5\src\DemoPaypal\DemoPaypal\Views\Pedidos\MeusPedidos.cshtml"
                      
                        int total = 0;
                        foreach (var pedido in Model)
                        {
                            total++;


#line default
#line hidden
#nullable disable
            WriteLiteral("                            <tr>\r\n                                <th scope=\"row\">");
#nullable restore
#line 38 "F:\Projetos ASP.NET\demo-paypal-asp.net-core-5\src\DemoPaypal\DemoPaypal\Views\Pedidos\MeusPedidos.cshtml"
                                           Write(total);

#line default
#line hidden
#nullable disable
            WriteLiteral("</th>\r\n                                <td>");
#nullable restore
#line 39 "F:\Projetos ASP.NET\demo-paypal-asp.net-core-5\src\DemoPaypal\DemoPaypal\Views\Pedidos\MeusPedidos.cshtml"
                               Write(pedido.NomeUsuario);

#line default
#line hidden
#nullable disable
            WriteLiteral("</td>\r\n                                <td>");
#nullable restore
#line 40 "F:\Projetos ASP.NET\demo-paypal-asp.net-core-5\src\DemoPaypal\DemoPaypal\Views\Pedidos\MeusPedidos.cshtml"
                               Write(pedido.DataCriacao);

#line default
#line hidden
#nullable disable
            WriteLiteral("</td>\r\n                                <td>");
#nullable restore
#line 41 "F:\Projetos ASP.NET\demo-paypal-asp.net-core-5\src\DemoPaypal\DemoPaypal\Views\Pedidos\MeusPedidos.cshtml"
                               Write(pedido.DataPagamento);

#line default
#line hidden
#nullable disable
            WriteLiteral("</td>\r\n                                <td>");
#nullable restore
#line 42 "F:\Projetos ASP.NET\demo-paypal-asp.net-core-5\src\DemoPaypal\DemoPaypal\Views\Pedidos\MeusPedidos.cshtml"
                               Write(pedido.Status);

#line default
#line hidden
#nullable disable
            WriteLiteral("</td>\r\n                                <td>");
#nullable restore
#line 43 "F:\Projetos ASP.NET\demo-paypal-asp.net-core-5\src\DemoPaypal\DemoPaypal\Views\Pedidos\MeusPedidos.cshtml"
                               Write(pedido.Preco);

#line default
#line hidden
#nullable disable
            WriteLiteral("</td>\r\n                                <td>");
#nullable restore
#line 44 "F:\Projetos ASP.NET\demo-paypal-asp.net-core-5\src\DemoPaypal\DemoPaypal\Views\Pedidos\MeusPedidos.cshtml"
                               Write(pedido.ProdutoNome);

#line default
#line hidden
#nullable disable
            WriteLiteral("</td>\r\n                                <td>");
#nullable restore
#line 45 "F:\Projetos ASP.NET\demo-paypal-asp.net-core-5\src\DemoPaypal\DemoPaypal\Views\Pedidos\MeusPedidos.cshtml"
                               Write(pedido.OrderPaypalId);

#line default
#line hidden
#nullable disable
            WriteLiteral("</td>\r\n                                <td>");
#nullable restore
#line 46 "F:\Projetos ASP.NET\demo-paypal-asp.net-core-5\src\DemoPaypal\DemoPaypal\Views\Pedidos\MeusPedidos.cshtml"
                                Write(pedido.Pago ? "Sim" : "Não");

#line default
#line hidden
#nullable disable
            WriteLiteral("</td>\r\n                            </tr>\r\n");
#nullable restore
#line 48 "F:\Projetos ASP.NET\demo-paypal-asp.net-core-5\src\DemoPaypal\DemoPaypal\Views\Pedidos\MeusPedidos.cshtml"
                        }

                    

#line default
#line hidden
#nullable disable
            WriteLiteral("\r\n\r\n                </tbody>\r\n            </table>\r\n        </div>\r\n    </div>\r\n</div>");
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
        public global::Microsoft.AspNetCore.Mvc.Rendering.IHtmlHelper<IEnumerable<DemoPaypal.Model.PedidoViewModel>> Html { get; private set; }
    }
}
#pragma warning restore 1591
