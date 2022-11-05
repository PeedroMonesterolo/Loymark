using Loymark.Core.Entities;
using Microsoft.EntityFrameworkCore;
using System.Reflection;

namespace Loymark.Infrastructure.Data
{
    public partial class LoymarkContext : DbContext
    {
        public LoymarkContext()
        {
        }

        public LoymarkContext(DbContextOptions<LoymarkContext> options)
            : base(options)
        {
        }

        public virtual DbSet<Actividad> Actividads { get; set; } = null!;
        public virtual DbSet<Usuario> Usuarios { get; set; } = null!;

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);
            modelBuilder.ApplyConfigurationsFromAssembly(Assembly.GetExecutingAssembly());
        }
    }
}
