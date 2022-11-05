using Loymark.Core.Entities;

namespace Loymark.Core.Interfaces;

public interface IUsuarioRepository : IGenericRepository<Usuario> {

    Task<IEnumerable<Usuario>> ExistingUser(string email);
}
