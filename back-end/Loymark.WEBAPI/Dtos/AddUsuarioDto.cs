using Loymark.Core.Entities;
using System.ComponentModel.DataAnnotations;

namespace Loymark.WEBAPI.Dtos;

public class AddUsuarioDto
{
    public int? Id { get; set; }
    [Required(ErrorMessage = "El nombre es requerido")]
    public string Nombre { get; set; }
    
    [Required(ErrorMessage = "El apellido es requerido")]
    public string Apellido { get; set; }
    
    [Required(ErrorMessage = "El email es requerido")]
    [EmailAddress(ErrorMessage = "Correo electronico con formato invalido")]
    public string Email { get; set; }
    
    [Required(ErrorMessage = "La fecha de nacimiento es requerida")]
    public DateTime FechaNacimiento { get; set; }

    [DataType(DataType.PhoneNumber)]
    public long? Telefono { get; set; }
    
    [Required(ErrorMessage = "El pais es requerido")]
    [MaxLength(3)]
    public string CodPais { get; set; }
    
    [Required(ErrorMessage = "Recibir Informacion es requerido")]
    public int RecibirInfo { get; set; }
}