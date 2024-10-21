using System.ComponentModel.DataAnnotations;

namespace RegistroTecnicos.Models
{
    public class Articulos
    {
        [Key]
        public int ArticuloId { get; set; }

        public string Descripcion { get; set; }

        public decimal Costo { get; set; }

        public decimal Precio { get; set; }

        public int Existencia { get; set; }
    }
}
