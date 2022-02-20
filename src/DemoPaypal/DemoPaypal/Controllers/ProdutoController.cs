using AutoMapper;
using Business.Interfaces.IRepositorio;
using Business.Interfaces.IService;
using DemoPaypal.Model;
using Domain.Entidades;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Threading.Tasks;

namespace DemoPaypal.Controllers
{
    public class ProdutoController : Controller
    {
        private readonly IProdutoService _produtoService;
        private readonly IProdutoRepositorio _produtoRepositorio;
        private readonly IMapper _mapper;
        private readonly SignInManager<IdentityUser> _signInManager;
        private readonly UserManager<IdentityUser> _userManager;
        private readonly IUsuarioRepositorio _usuarioRepositorio;
        private readonly IUsuarioService _usuarioService;

        public ProdutoController(IProdutoService produtoService, IMapper mapper,
            IProdutoRepositorio produtoRepositorio,
            SignInManager<IdentityUser> signInManager,
            UserManager<IdentityUser> userManager,
            IUsuarioService usuarioService,
            IUsuarioRepositorio usuarioRepositorio)
        {
            _produtoService = produtoService;
            _produtoRepositorio = produtoRepositorio;
            _mapper = mapper;
            _userManager = userManager;
            _signInManager = signInManager;
            _usuarioRepositorio = usuarioRepositorio;
            _usuarioService = usuarioService;
        }
        public async Task<IActionResult> Index()
        {
            //verifica usuario logado no sistema
            var usuarioLogadoNome = User.Identity.Name;

            if (string.IsNullOrEmpty(usuarioLogadoNome)) return BadRequest("[x] Erro: Você precisa estar logado para acessar essa tela.");

            var usuarioLogado = await _userManager.FindByNameAsync(usuarioLogadoNome);
            var usuario = await _usuarioRepositorio.GetByIdentityId(Guid.Parse(usuarioLogado.Id));

            var produtos = _mapper.Map<IEnumerable<ProdutoViewModel>>(await _produtoRepositorio.GetAll());

            return View(produtos);
        }

        public async Task<IActionResult> Cadastrar()
        {

            //verifica usuario logado no sistema
            var usuarioLogadoNome = User.Identity.Name;

            if (string.IsNullOrEmpty(usuarioLogadoNome)) return BadRequest("[x] Erro: Você precisa estar logado para acessar essa tela.");

            var usuarioLogado = await _userManager.FindByNameAsync(usuarioLogadoNome);
            var usuario = await _usuarioRepositorio.GetByIdentityId(Guid.Parse(usuarioLogado.Id));

            return View();
        }

        [HttpPost]
        public async Task<IActionResult> Cadastrar(ProdutoViewModel model)
        {
            if (!ModelState.IsValid) return View(model);

            var imgagenprefixo = Guid.NewGuid() + "_";
            if (!await UploadFile(model.ImagemUpload, imgagenprefixo))
                return View(model);

            model.Imagem = imgagenprefixo + model.ImagemUpload.FileName;

            await _produtoService.Adicionar(_mapper.Map<Produto>(model));

            return RedirectToAction("Index","Home");
        }

        [HttpPost]
        public async Task<IActionResult> Remover(Guid Id)
        {
            if (Id == Guid.Empty) return BadRequest("Produto não encontrado.");

            await _produtoService.Remover(Id);

            return RedirectToAction("Index");
        }

        public async Task<IActionResult> Atualizar(ProdutoViewModel model)
        {
            //verifica usuario logado no sistema
            var usuarioLogadoNome = User.Identity.Name;
            if (string.IsNullOrEmpty(usuarioLogadoNome)) return BadRequest("[x] Erro: Você precisa estar logado para acessar essa tela.");

            var usuarioLogado = await _userManager.FindByNameAsync(usuarioLogadoNome);
            var usuario = await _usuarioRepositorio.GetByIdentityId(Guid.Parse(usuarioLogado.Id));

            if (!ModelState.IsValid) return View(model);

            await _produtoService.Atualizar(_mapper.Map<Produto>(model));

            return RedirectToAction("Index", "Produto");
        }

        protected async Task<bool> UploadFile(IFormFile file, string imgPrefix)
        {
            if (file.Length < 0) return false;

            var path = Path.Combine(Directory.GetCurrentDirectory(), "wwwroot/images", imgPrefix + file.FileName);

            if (System.IO.File.Exists(path))
            {
                ModelState.AddModelError(string.Empty, "Already exist a file with this name.");
                return false;
            }

            using (var stream = new FileStream(path, FileMode.Create))
            {
                await file.CopyToAsync(stream);
            }
            return true;
        }
    }
}
