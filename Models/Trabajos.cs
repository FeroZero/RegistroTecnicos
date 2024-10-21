using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Runtime.CompilerServices;

namespace RegistroTecnicos.Models
{
	public class Trabajos
	{
		[Key]
		public int TrabajoId { get; set; }
		[Required(ErrorMessage = "Campo Obligatorio")]
		public DateTime Fecha { get; set; } = DateTime.Now;
		[Required(ErrorMessage = "Campo Obligatorio")]
		[RegularExpression(@"^[a-zA-Z\s]+$", ErrorMessage = "Solo letras.")]
		public string? Descripcion { get; set; }
		[Required(ErrorMessage = "Campo Obligatorio")]
		[Range(1, float.MaxValue, ErrorMessage = "El sueldo debe ser mayor a 0.")]
		public decimal Monto { get; set; }

		[ForeignKey("Tecnicos")]
		public int TecnicoId { get; set; }
		public Tecnicos? Tecnicos { get; set; }

		[ForeignKey("Clientes")]
		public int ClienteId { get; set; }
		public Clientes? Clientes { get; set; }

		[ForeignKey("TrabajoId")]
		public virtual ICollection<TrabajosDetalle> TrabajosDetalle { get; set; } = new List<TrabajosDetalle>();
	}
}
