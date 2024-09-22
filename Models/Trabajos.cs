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
		public DateTime Fecha { get; set; }
		[Required(ErrorMessage = "Campo Obligatorio")]
		[RegularExpression(@"^[a-zA-Z\s]+$", ErrorMessage = "Solo letras.")]
		public string Descripcion { get; set; }
		[Required(ErrorMessage = "Campo Obligatorio")]
		[Range(1, float.MaxValue, ErrorMessage = "El sueldo debe ser mayor a 0.")]
		public decimal Monto { get; set; }


		[ForeignKey("TecnicoId")]
		public int TecnicoId { get; set; }

		[Required(ErrorMessage = "Campo Obligatorio")]
		public Tecnicos Tecnicos { get; set; }

		[ForeignKey("ClienteId")]
		public int ClienteId {  get; set; }

		[Required(ErrorMessage = "Campo Obligatorio")]
		public Clientes Clientes { get; set; }

		[ForeignKey("PrioridadId")]
		public int PrioridadId { get; set; }

		[Required(ErrorMessage = "Campo Obligatorio")]
		public Prioridades Prioridades { get; set; }
	}
}
