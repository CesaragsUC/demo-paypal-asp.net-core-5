using Business.Interfaces.IRepositorio;
using Domain.Entidades;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;

namespace Infra.Respositorio
{
    public class PedidoRepositorio : Repository<Pedido>, IPedidoRepositorio
    {

        public PedidoRepositorio(MeuContexto dbContext):base(dbContext)
        {

        }

        public async Task<IEnumerable<Pedido>> GetAll()
        {
            return await Db.Pedidos.AsNoTracking().ToListAsync();
        }

        public async Task<Pedido> GetById(Guid pedidoId)
        {
            return await Db.Pedidos.FirstAsync(x=>x.Id == pedidoId);
        }
        public async Task<Pedido> GetByOrderId(string orderId)
        {
            return await Db.Pedidos.FirstOrDefaultAsync(x => x.OrderPaypalId == orderId);
        }
        public async Task<IEnumerable<Pedido>> GetByUserId(Guid userId)
        {
            return await Db.Pedidos.Where(x => x.UsuarioId == userId).AsNoTracking().ToListAsync();
        }


        
    }
}
