using Business.Interfaces.IRepositorio;
using Business.Interfaces.IService;
using Domain.Entidades;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Business.Service
{
    public class ProdutoService : IProdutoService
    {
        private readonly IProdutoRepositorio _produtoRepositorio;
        public ProdutoService(IProdutoRepositorio produtoRepositorio)
        {
            _produtoRepositorio = produtoRepositorio;
        }

        public async Task Adicionar(Produto produto)
        {
            await _produtoRepositorio.Adicionar(produto);
        }

        public async Task Atualizar(Produto produto)
        {
            await _produtoRepositorio.Atualizar(produto);
        }

        public void Dispose()
        {
            _produtoRepositorio?.Dispose();
        }

        public async Task Remover(Guid id)
        {
            await _produtoRepositorio.Remover(id);
        }
    }
}
