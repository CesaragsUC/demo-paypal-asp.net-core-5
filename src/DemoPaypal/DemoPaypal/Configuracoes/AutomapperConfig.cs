using AutoMapper;
using DemoPaypal.Model;
using Domain.Entidades;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace DemoPaypal.Configuracoes
{
    public class AutomapperConfig : Profile
    {
        public AutomapperConfig()
        {
            CreateMap<Produto, ProdutoViewModel>().ReverseMap();
            CreateMap<Pedido, PedidoViewModel>().ReverseMap();
            CreateMap<Usuario, UsuarioViewModel>().ReverseMap();

        }
    }
}
