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
    public class UsuarioRepositorio : Repository<Usuario>, IUsuarioRepositorio
    {

        public UsuarioRepositorio(MeuContexto dbContext) : base(dbContext)
        {

        }

        public async Task<IEnumerable<Usuario>> GetAll()
        {
            return await Db.Usuarios.AsNoTracking().ToListAsync();
        }

        public async Task<Usuario> GetById(Guid usuarioId)
        {
            return await Db.Usuarios.FirstAsync(x => x.Id == usuarioId);
        }

        public async Task<Usuario> GetByIdentityId(Guid identityId)
        {
            return await Db.Usuarios.FirstAsync(x => x.IdentityId == identityId);
        }

        public async Task<Usuario> GetByNameAndEmail(string email)
        {
            return await Db.Usuarios.FirstAsync(x => x.Email == email);
        }
    }
}
