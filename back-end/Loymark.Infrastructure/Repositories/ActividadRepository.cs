using Loymark.Core.Entities;
using Loymark.Core.Interfaces;
using Loymark.Infrastructure.Data;
using Microsoft.EntityFrameworkCore;

namespace Loymark.Infrastructure.Repositories
{
    public class ActividadRepository : GenericRepository<Actividad>, IActividadRepository
    {
        public ActividadRepository(LoymarkContext context) : base(context)
        {
        }

        public async Task<IEnumerable<Actividad>> GetActividades() =>
                    await _context.Actividads
                                .OrderByDescending(p => p.CreateDate)
                                .Include(p => p.Usuario)
                                .ToListAsync();

        public async Task<IEnumerable<Actividad>> GetActividadesPorUsuario(int idUsuario) =>
                    await _context.Actividads
                        .Where(o => o.IdUsuario == idUsuario).ToListAsync();

        public async Task<Actividad> GetByIdUsuarioAsync(int id) =>
                    await _context.Actividads.Where(u => u.Usuario.Id == id).Include(p => p.Usuario).FirstOrDefaultAsync();
    }
}
