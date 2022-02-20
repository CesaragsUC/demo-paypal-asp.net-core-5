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
    public class  UsuarioMapping : IEntityTypeConfiguration<Usuario>
    {
        public void Configure(EntityTypeBuilder<Usuario> builder)
        {
            builder.HasKey(x => x.Id);

            builder.Property(p => p.Nome)
            .IsRequired()
            .HasColumnType("varchar(100)");

            builder.Property(p => p.Email)
            .IsRequired()
            .HasColumnType("varchar(100)");


            builder.ToTable("Usuarios");
        }
    }
}
