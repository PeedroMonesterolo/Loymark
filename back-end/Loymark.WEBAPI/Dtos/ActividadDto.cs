using Loymark.Core.Entities;

namespace Loymark.WEBAPI.Dtos;

public class ActividadDto
{
    public int IdActividad { get; set; }
    public DateTime CreateDate { get; set; }
    public int IdUsuario { get; set; }
    public string Actividad1 { get; set; } = null!;
    public string Usuario { get; set; }
}
