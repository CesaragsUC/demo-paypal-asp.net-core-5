using Application.Interfaces.IRepositorio;
using Domain.Entidades;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Business.Interfaces.IRepositorio
{
    public interface IPedidoRepositorio : IRepository<Pedido>
    {
        Task<IEnumerable<Pedido>> GetAll();
        Task<Pedido> GetById(Guid pedido_id);
        Task<IEnumerable<Pedido>> GetByUserId(Guid userId);
        Task<Pedido> GetByOrderId(string orderId);

    }
}
