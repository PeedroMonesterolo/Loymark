using Loymark.Core.Entities;
using Loymark.Core.Interfaces;
using Loymark.Infrastructure.Data;
using Microsoft.EntityFrameworkCore;

namespace Loymark.Infrastructure.Repositories
{
    public class UsuarioRepository : GenericRepository<Usuario>, IUsuarioRepository
    {
        public UsuarioRepository(LoymarkContext context) : base(context)
        {
        }

        public async Task<IEnumerable<Usuario>> ExistingUser(string email) =>
            await _context.Usuarios.Where(p => p.Email == email).ToListAsync();
    }
}
