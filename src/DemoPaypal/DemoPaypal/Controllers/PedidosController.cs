using AutoMapper;
using Business.Interfaces.IRepositorio;
using Business.Interfaces.IService;
using DemoPaypal.Model;
using DemoPaypal.PaypalHelper;
using Domain.Entidades;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using PayPalCheckoutSdk.Orders;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace DemoPaypal.Controllers
{
    public class PedidosController : Controller
    {
        private readonly IProdutoService _produtoService;
        private readonly IProdutoRepositorio _produtoRepositorio;
        private readonly IMapper _mapper;
        private readonly SignInManager<IdentityUser> _signInManager;
        private readonly UserManager<IdentityUser> _userManager;
        private readonly IUsuarioRepositorio _usuarioRepositorio;
        private readonly IUsuarioService _usuarioService;

        private readonly IPedidoRepositorio _pedidoRepositorio;
        private readonly IPedidoService _pedidoService;


        public PedidosController(IProdutoService produtoService, IMapper mapper,
            IProdutoRepositorio produtoRepositorio,
            IUsuarioService usuarioService,
            IUsuarioRepositorio usuarioRepositorio,
            SignInManager<IdentityUser> signInManager,
            UserManager<IdentityUser> userManager,
            IPedidoRepositorio pedidoRepositorio,
            IPedidoService pedidoService
            )
        {
            _produtoService = produtoService;
            _produtoRepositorio = produtoRepositorio;
            _usuarioRepositorio = usuarioRepositorio;
            _usuarioService = usuarioService;
            _mapper = mapper;
            _userManager = userManager;
            _signInManager = signInManager;
            _pedidoRepositorio = pedidoRepositorio;
            _pedidoService = pedidoService;
        }

        public IActionResult Index(string token,string PayerID)
        {
            //string final = "token:" + token + "payer:" + PayerID;

            ViewData["ORDER_ID"] = token;
            return View();
        }


        public async Task<IActionResult> CreatOrder(Guid produtoid)
        {

            var usuarioLogadoNome = User.Identity.Name;
            var usuarioLogado = await _userManager.FindByNameAsync(usuarioLogadoNome);

            var produto = await _produtoRepositorio.GetById(produtoid);
            var usuario = await _usuarioRepositorio.GetByIdentityId(Guid.Parse(usuarioLogado.Id));

            try
            {
                var createOrderResponse = CreateOrderPaypal.CreateOrder(produto, true).Result;
                var createOrderResult = createOrderResponse.Result<Order>();

                var captureOrderResponse = GetOrderPaypal.GetOrder(createOrderResult.Id, true).Result;
                var captureOrderResult = captureOrderResponse.Result<Order>();


                var linkSelfOrder = createOrderResult.Links.Where(x => x.Rel.Equals("self")).Select(x => x.Href)
                    .FirstOrDefault();

                var linkOrder = createOrderResult.Links.Where(x => x.Rel.Equals("approve")).Select(x => x.Href)
                    .FirstOrDefault();

                var pedidoModel = new PedidoViewModel
                {
                    OrderPaypalId = captureOrderResult.Id,
                    ProdutoNome = produto.Nome,
                    DataCriacao = DateTime.Parse(captureOrderResult.CreateTime),
                    Descricao = produto.Descricao,
                    Status = captureOrderResult.Status,
                    UsuarioId = usuario.Id,
                    ProdutoId = produto.Id,
                    NomeUsuario = usuario.Nome,
                    Preco = produto.Preco,
                    LinkOrder = linkOrder,
                    LinkSelfOrder = linkSelfOrder

                };

                await _pedidoService.Adicionar(_mapper.Map<Pedido>(pedidoModel));

                return Redirect(pedidoModel.LinkOrder);
            }
            catch (Exception ex)
            {
                throw ex;
            }

        }

  
        public async Task<JsonResult> UpdateOrder(string orderid)
        {
            bool IsOrderApproved = false;
            var captureOrderResult = new Order();

            if (string.IsNullOrEmpty(orderid))
                return Json("invalid data for update order");

            try
            {
                var getOrdeResponse = GetOrderPaypal.GetOrder(orderid, true).Result;
                var getOrderResult = getOrdeResponse.Result<Order>();

                if (getOrderResult.Status.ToUpper() == "APPROVED")
                    IsOrderApproved = true;

                if (IsOrderApproved)
                {
                    var captureOrderResponse = CaptureOrder.captureOrder(orderid).Result;
                    captureOrderResult = captureOrderResponse.Result<Order>();
                }


                var order = await _pedidoRepositorio.GetByOrderId(orderid);

                order.OrderPaypalId = order.OrderPaypalId;
                order.ProdutoNome = order.ProdutoNome;
                order.DataCriacao = order.DataCriacao;
                order.Descricao = order.Descricao;
                order.PayerEmail = captureOrderResult.Payer != null ? captureOrderResult.Payer.Email: "";
                order.PayerId = captureOrderResult.Payer != null ? captureOrderResult.Payer.PayerId : "";
                order.PayerName = captureOrderResult.Payer != null ? captureOrderResult.Payer.Name.GivenName: "";
                order.Status = captureOrderResult.Status != null ? captureOrderResult.Status : "";
                order.UsuarioId = order.UsuarioId; //user id from UserApp
                order.ProdutoId = order.ProdutoId;
                order.NomeUsuario = order.NomeUsuario;
                order.Preco = order.Preco;
                order.LinkOrder = order.LinkOrder;
                order.LinkSelfOrder = order.LinkSelfOrder;
                order.Pago = captureOrderResult.Status.ToUpper() == "COMPLETED" ? true : false;

                  await _pedidoService.Atualizar(order);

                if (captureOrderResult.Status.ToUpper() == "COMPLETED")
                {
                    var aprovado = new PagamentoAprovadoViewModel { UsuarioId = order.UsuarioId, Mensagem = "Aprovado" };

                    var data = new
                    {
                        usuaarioId = aprovado.UsuarioId,
                        msg = "aprovado",
                        url = Url.Action("PagamentoAprovado", "Pedidos")
                    };

                    return Json(data); 
                }
                else
                {
                    var recusado = new PagamentoRecusadoViewModel { UsuarioId = order.UsuarioId, Mensagem = "Recusado" };

                    var data = new
                    {
                        usuaarioId = recusado.UsuarioId,
                        msg = "recusado",
                        url = Url.Action("PagamentoRecusado", "Pedidos")
                    };

                    return Json(data);
                   
                }

            }
            catch (Exception ex)
            {
                var falhaServico = new PagamentoFalhaServicoViewModel { UsuarioId = Guid.Empty, Mensagem = "Falha" };

                var data = new
                {
                    usuaarioId = falhaServico.UsuarioId,
                    msg = "falha",
                    url = Url.Action("PagamentoFalhaServico", "Pedidos")
                };

                return Json(data);

            }


        }

        public async Task<ActionResult> MeusPedidos(string userid = "")
        {
            if (string.IsNullOrEmpty(userid))
            {
                var usuarioLogadoNome = User.Identity.Name;

                if (string.IsNullOrEmpty(usuarioLogadoNome)) return BadRequest("[x] Erro: Você precisa estar logado para acessar essa tela.");

                var usuarioLogado = await _userManager.FindByNameAsync(usuarioLogadoNome);
                var usuario = await _usuarioRepositorio.GetByIdentityId(Guid.Parse(usuarioLogado.Id));
               
                var pedidos = await _pedidoRepositorio.GetByUserId(usuario.Id);
                var pedidoLista = _mapper.Map<IEnumerable<PedidoViewModel>>(pedidos);

                return View(pedidoLista);
            }
            else
            {
                var pedidos = await _pedidoRepositorio.GetByUserId(Guid.Parse(userid));
                var pedidoLista = _mapper.Map<IEnumerable<PedidoViewModel>>(pedidos);

                return View(pedidoLista);
            }
        }


        public async Task<ActionResult> PagamentoAprovado()
        {
            return View();
        }
        public async Task<ActionResult> PagamentoRecusado()
        {
            return View();
        }

        public async Task<ActionResult> PagamentoFalhaServico()
        {
            return View();
        }
    }
}
