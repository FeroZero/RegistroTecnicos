using System.ComponentModel.DataAnnotations;

namespace RegistroTecnicos.Models
{
    public class TiposTecnicos
    {
        [Key]
        public int TipoId { get; set; }

        [RegularExpression(@"^[a-zA-Z\s]+$", ErrorMessage = "solo se permiten letras.")]
        [Required(ErrorMessage = "Campo obligatorio.")]
        public string? Descripcion { get; set; }
    }
}
