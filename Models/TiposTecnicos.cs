using System.ComponentModel.DataAnnotations;

namespace RegistroTecnicos.Models
{
	public class TiposTecnicos
	{
		[Key]
		public int TiposTecnicosId { get; set; }

		[Required(ErrorMessage = "Campo Obligatorio.")]
		[RegularExpression(@"^[a-zA-Z\s]+$", ErrorMessage = "Solo letras.")]
		public string? Descripcion { get; set; }
	}
}
