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
    public class PedidoService : IPedidoService
    {
        private readonly IPedidoRepositorio _pedidoRepositorio;
        public PedidoService(IPedidoRepositorio pedidoRepositorio)
        {
            _pedidoRepositorio = pedidoRepositorio;
        }
        public async Task Adicionar(Pedido pedido)
        {
            await _pedidoRepositorio.Adicionar(pedido);
        }

        public async Task Atualizar(Pedido pedido)
        {
            await _pedidoRepositorio.Atualizar(pedido);
        }

        public void Dispose()
        {
            _pedidoRepositorio?.Dispose();
        }

        public async Task Remover(Guid id)
        {
            await _pedidoRepositorio.Remover(id);
        }
    }
}
