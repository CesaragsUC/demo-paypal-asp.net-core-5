using Domain.Entidades;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Infra.Mapping
{
    public class PedidoMapping : IEntityTypeConfiguration<Pedido>
    {
        public void Configure(EntityTypeBuilder<Pedido> builder)
        {
            builder.HasKey(x => x.Id);

            builder.Property(p => p.UsuarioId)
            .IsRequired();

            builder.Property(p => p.ProdutoId)
            .IsRequired();

            builder.Property(p => p.ProdutoId)
            .HasColumnType("varchar(500)");


            builder.Property(p => p.ProdutoId)
            .HasColumnType("varchar(500)");


            builder.Property(p => p.LinkOrder)
            .IsRequired()
            .HasColumnType("varchar(500)");

            builder.Property(p => p.LinkSelfOrder)
            .IsRequired()
            .HasColumnType("varchar(500)");

            //// 1 : N => Ticket : TicketData
            builder.HasMany(p => p.Produtos);

            //1:1
            builder.HasOne(p => p.Usuario);

            builder.ToTable("Pedidos");
        }
    }
}
