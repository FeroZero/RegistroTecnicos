using System.ComponentModel.DataAnnotations;

namespace RegistroTecnicos.Models;

public class Tecnicos
{
    [Key]
    public int TecnicoId { get; set; }
    [Required(ErrorMessage = "Campo Obligatorio")]
    [RegularExpression(@"^[a-zA-Z\s]+$", ErrorMessage = "Solo letras.")]
    public string? Nombres { get; set; }

    [Required(ErrorMessage = "Campo Obligatorio")]
    [Range(1, float.MaxValue, ErrorMessage = "El sueldo debe ser mayor a 0.")]
    public decimal SueldoHora { get; set;}
}
