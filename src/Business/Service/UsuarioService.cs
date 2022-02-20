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
    public class UsuarioService : IUsuarioService
    {
        private readonly IUsuarioRepositorio _usuarioRepositorio;
        public UsuarioService(IUsuarioRepositorio usuarioRepositorio)
        {
            _usuarioRepositorio = usuarioRepositorio;
        }
        public async Task Adicionar(Usuario usuario)
        {
            await _usuarioRepositorio.Adicionar(usuario);
        }

        public async Task Atualizar(Usuario usuario)
        {
            await _usuarioRepositorio.Atualizar(usuario);
        }

        public void Dispose()
        {
            _usuarioRepositorio?.Dispose();
        }

        public async Task Remover(Guid id)
        {
            await _usuarioRepositorio.Remover(id);
        }
    }
}
