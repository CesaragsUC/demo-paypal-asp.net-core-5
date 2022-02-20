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
    public class ProdutoMapping : IEntityTypeConfiguration<Produto>
    {
        public void Configure(EntityTypeBuilder<Produto> builder)
        {
            builder.HasKey(x => x.Id);


            builder.Property(p => p.Nome)
            .IsRequired()
            .HasColumnType("varchar(100)");

            builder.Property(p => p.Descricao)
            .IsRequired()
            .HasColumnType("varchar(500)");


            builder.Property(p => p.Imagem)
            .IsRequired()
            .HasColumnType("varchar(max)");

            builder.Property(p => p.Preco)
            .IsRequired();

            builder.ToTable("Produtos");
        }
    }
}
