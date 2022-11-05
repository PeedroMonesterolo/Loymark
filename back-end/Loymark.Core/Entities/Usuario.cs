namespace Loymark.Core.Entities
{
    public class Usuario
    {
        public int Id { get; set; }
        public string Nombre { get; set; } = null!;
        public string Apellido { get; set; } = null!;
        public string Email { get; set; } = null!;
        public DateTime FechaNacimiento { get; set; }
        public long? Telefono { get; set; }
        public string CodPais { get; set; } = null!;
        public bool RecibirInfo { get; set; }
        public ICollection<Actividad> Actividad { get; set; }
    }
}
