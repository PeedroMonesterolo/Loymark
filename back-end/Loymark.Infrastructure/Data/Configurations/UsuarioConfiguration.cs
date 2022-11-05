using Loymark.Core.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Loymark.Infrastructure.Data.Configurations
{
    public class UsuarioConfiguration : IEntityTypeConfiguration<Usuario>
    {
        public void Configure(EntityTypeBuilder<Usuario> entity)
        {
            entity.Property(e => e.Id).HasColumnName("id");

            entity.Property(e => e.Apellido)
                .HasMaxLength(35)
                .IsUnicode(false)
                .HasColumnName("apellido");

            entity.Property(e => e.CodPais)
                .HasMaxLength(3)
                .IsUnicode(false)
                .HasColumnName("cod_pais");

            entity.Property(e => e.Email)
                .HasMaxLength(50)
                .IsUnicode(false)
                .HasColumnName("email");

            entity.Property(e => e.FechaNacimiento)
                .HasColumnType("date")
                .HasColumnName("fecha_nacimiento");

            entity.Property(e => e.Nombre)
                .HasMaxLength(25)
                .IsUnicode(false)
                .HasColumnName("nombre");

            entity.Property(e => e.RecibirInfo).HasColumnName("recibir_info");

            entity.Property(e => e.Telefono)
                .HasColumnType("bigint")
                .HasMaxLength(10)
                .HasColumnName("telefono");
        }
    }
}
