using System.ComponentModel.DataAnnotations;

namespace RegistroTecnicos.Models;

public class Clientes
{
	[Key]
	public int ClienteId { get; set; }

	[Required]
	[RegularExpression(@"^[a-zA-Z\s]+$", ErrorMessage =	"Solo letras.")]
	public string? Nombres { get; set; }

	[Required]
	[RegularExpression(@"\d{3}-\d{3}-\s{4}$", ErrorMessage = "Numero de telefono.")]
	public string? WhatsApp { get; set; }
}
