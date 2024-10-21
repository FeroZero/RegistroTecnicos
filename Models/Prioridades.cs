using System.ComponentModel.DataAnnotations;

namespace RegistroTecnicos.Models
{
	public class Prioridades
	{
		[Key]
		public int PrioridadId { get; set; }

		[Required(ErrorMessage = "Campo Obligatorio")]
		[RegularExpression(@"^[a-zA-Z\s]+$", ErrorMessage = "Solo letras.")]
		public string? Descripcion { get; set; }

		[Required(ErrorMessage = "Campo Obligatorio")]
		public DateTime Tiempo { get; set; } = DateTime.Now;
	}
}
