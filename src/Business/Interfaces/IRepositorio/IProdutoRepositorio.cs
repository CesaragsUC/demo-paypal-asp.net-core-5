using Application.Interfaces.IRepositorio;
using Domain.Entidades;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace Business.Interfaces.IRepositorio
{
    public interface IProdutoRepositorio : IRepository<Produto>
    {
        Task<IEnumerable<Produto>> GetAll();
        Task<Produto> GetById(Guid produtoId);

    }
}
