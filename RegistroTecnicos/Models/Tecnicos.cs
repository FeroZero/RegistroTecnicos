using System.ComponentModel.DataAnnotations;

namespace RegistroTecnicos.Models
{
	public class Tecnicos
	{
		[Key]
		public int TecnicoId { get; set; }
		[RegularExpression(@"^[a-zA-Z\s]+$", ErrorMessage = "solo se permiten letras.")]
		[Required(ErrorMessage = "Campo obligatorio.")]
		public string? Nombres { get; set; }
		[Range(1, float.MaxValue, ErrorMessage = "El sueldo no puede ser menor o igual que 0.")]
		[Required(ErrorMessage = "Campo obligatorio.")]
		public decimal SueldoHora { get; set; }

	}
}
