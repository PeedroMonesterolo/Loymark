namespace Loymark.Core.Entities
{
    public class Actividad
    {
        public int IdActividad { get; set; }
        public DateTime CreateDate { get; set; }
        public int IdUsuario { get; set; }
        public string Actividad1 { get; set; } = null!;
        public Usuario Usuario { get; set; }
    }
}
