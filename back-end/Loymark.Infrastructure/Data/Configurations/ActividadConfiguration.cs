using Loymark.Core.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Loymark.Infrastructure.Data.Configurations
{
    public class ActividadConfiguration : IEntityTypeConfiguration<Actividad>
    {
        public void Configure(EntityTypeBuilder<Actividad> entity)
        {
            entity.HasKey(e => e.IdActividad)
                    .HasName("PK__Activida__DCD34883D444129D");

            entity.ToTable("Actividad");

            entity.Property(e => e.IdActividad).HasColumnName("id_actividad");

            entity.Property(e => e.Actividad1)
                .IsUnicode(false)
                .HasColumnName("actividad");

            entity.Property(e => e.CreateDate)
                .HasColumnType("datetime")
                .HasColumnName("create_date");

            entity.Property(e => e.IdUsuario).HasColumnName("id_usuario");

            entity.HasOne(p => p.Usuario)
                .WithMany(p => p.Actividad)
                .HasForeignKey(p => p.IdUsuario)
                .HasConstraintName("FK_id_usuario");
        }
    }
}
