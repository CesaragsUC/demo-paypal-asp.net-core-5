using Application.Interfaces.IRepositorio;
using Domain.Entidades;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Business.Interfaces.IRepositorio
{
    public interface IUsuarioRepositorio : IRepository<Usuario>
    {
        Task<IEnumerable<Usuario>> GetAll();
        Task<Usuario> GetById(Guid usuarioId);
        Task<Usuario> GetByIdentityId(Guid identityId);
        Task<Usuario> GetByNameAndEmail(string email);
        
    }
}
