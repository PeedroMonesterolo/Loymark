using Loymark.Core.Entities;

namespace Loymark.Core.Interfaces;

public interface IActividadRepository : IGenericRepository<Actividad> {
    Task<IEnumerable<Actividad>> GetActividadesPorUsuario(int idUsuario);
    Task<IEnumerable<Actividad>> GetActividades();
    Task<Actividad> GetByIdUsuarioAsync(int id);
}
