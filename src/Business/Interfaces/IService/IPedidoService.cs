using Domain.Entidades;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Business.Interfaces.IService
{
    public interface IPedidoService : IDisposable
    {

        Task Adicionar(Pedido pedido);
        Task Atualizar(Pedido pedido);
        Task Remover(Guid id);
    }
}
