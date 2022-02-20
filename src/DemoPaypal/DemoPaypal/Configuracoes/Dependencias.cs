using Business.Interfaces.IRepositorio;
using Business.Interfaces.IService;
using Business.Service;
using Infra;
using Infra.Respositorio;
using Microsoft.AspNetCore.Http;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace DemoPaypal.Dependencia
{
    public static class Dependencias
    {
        public static IServiceCollection ResolveDependencias(this IServiceCollection services)
        {
            //repository
            services.AddScoped<DbContext, MeuContexto>();

            services.AddScoped<IProdutoRepositorio, ProdutoRepositorio>();
            services.AddScoped<IPedidoRepositorio, PedidoRepositorio>();
            services.AddScoped<IUsuarioRepositorio, UsuarioRepositorio>();

            //services
            services.AddScoped<IProdutoService, ProdutoService>();
            services.AddScoped<IPedidoService, PedidoService>();
            services.AddScoped<IUsuarioService, UsuarioService>();

            services.AddSingleton<IHttpContextAccessor, HttpContextAccessor>();

            return services;
        }
    }
}
