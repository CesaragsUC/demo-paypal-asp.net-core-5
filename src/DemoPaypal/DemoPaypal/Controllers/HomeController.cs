using AutoMapper;
using Business.Interfaces.IRepositorio;
using Business.Interfaces.IService;
using DemoPaypal.Model;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace DemoPaypal.Controllers
{
    public class HomeController : Controller
    {
        private readonly IProdutoRepositorio _produtoRepositorio;
        private readonly IMapper _mapper;
        public HomeController(IProdutoRepositorio produtoRepositorio, IMapper mapper)
        {
            _produtoRepositorio = produtoRepositorio;
            _mapper = mapper;
        }
        public async Task<IActionResult> Index()
        {

            var produtos = _mapper.Map<IEnumerable<ProdutoViewModel>>(await _produtoRepositorio.GetAll());

            return View(produtos);
        }
    }
}
