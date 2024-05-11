using System.ComponentModel.DataAnnotations;

namespace RegistroTecnicos.Models
{
	public class Tecnicos
	{
		[Key]
		public int TecnicoId { get; set; }
		[RegularExpression(@"^[a-zA-Z\s]+$", ErrorMessage = "Error: solo se permiten letras.")]
		[Required(ErrorMessage = "Nombre obligatorio.")]
		public string? Nombres { get; set; }
		[Range(1, float.MaxValue, ErrorMessage = "Error: El sueldo no puede ser menor o igual que 0.")]
		[Required(ErrorMessage = "Campo obligatorio.")]
		public decimal? SueldoHora { get; set; }
	}
}
