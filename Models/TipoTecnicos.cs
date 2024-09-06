using System.ComponentModel.DataAnnotations;

namespace RegistroTecnicos.Models
{
	public class TipoTecnicos
	{
		[Key]
		public int TipoId { get; set; }

		[Required(ErrorMessage = "Campo Obligatorio.")]
		[RegularExpression(@"^[a-zA-Z\s]+$", ErrorMessage = "Solo letras.")]
		public string? Descripcion { get; set; }
	}
}
