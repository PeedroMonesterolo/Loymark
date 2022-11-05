namespace Loymark.Core.Interfaces;

public interface IUnitOfWork
{
    IUsuarioRepository Usuarios { get; }
    IActividadRepository Actividades { get; }

    Task<int> SaveAsync();
}
