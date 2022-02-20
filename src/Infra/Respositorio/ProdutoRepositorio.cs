using Business.Interfaces.IRepositorio;
using Business.Interfaces.IService;
using Domain.Entidades;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Infra.Respositorio
{
    public class ProdutoRepositorio : Repository<Produto>, IProdutoRepositorio
    {

        public ProdutoRepositorio(MeuContexto dbContext) : base(dbContext)
        {

        }

        public async Task<IEnumerable<Produto>> GetAll()
        {
            return await Db.Produtos.AsNoTracking().ToListAsync();
        }

        public async Task<Produto> GetById(Guid produtoId)
        {
            return await Db.Produtos.FirstAsync(x => x.Id == produtoId);
        }

    }
}
