using System.ComponentModel.DataAnnotations;

namespace Loymark.WEBAPI.Dtos
{
    public class UsuarioDto
    {
        public int Id { get; set; }
        public string Nombre { get; set; }
        public string Apellido { get; set; }
        public string Email { get; set; }
        public DateTime FechaNacimiento { get; set; }
        public int? Telefono { get; set; }
        public string CodPais { get; set; }
        public int RecibirInfo { get; set; }
    }
}
