using Loymark.Core.Interfaces;
using Loymark.Infrastructure.Data;
using Loymark.Infrastructure.Repositories;

namespace Loymark.Infrastructure.UnitOfWork
{
    public class UnitOfWork : IUnitOfWork, IDisposable
    {
        private readonly LoymarkContext _context;
        private IUsuarioRepository _usuario;
        private IActividadRepository _actividad;
        public UnitOfWork(LoymarkContext context)
        {
            _context = context;
        }

        public IUsuarioRepository Usuarios
        {
            get
            {
                if (_usuario == null)
                {
                    _usuario = new UsuarioRepository(_context);
                }
                return _usuario;
            }
        }

        public IActividadRepository Actividades
        {
            get
            {
                if (_actividad == null)
                {
                    _actividad = new ActividadRepository(_context);
                }
                return _actividad;
            }
        }

        public void Dispose()
        {
            _context.Dispose();
        }

        public async Task<int> SaveAsync()
        {
            return await _context.SaveChangesAsync();
        }
    }
}
