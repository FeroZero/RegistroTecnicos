﻿using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace RegistroTecnicos.Models
{
    public class TrabajosDetalle
    {
        [Key]
        public int DetalleId { get; set; }
        [ForeignKey("Trabajos")]
        public int TrabajoId { get; set; }
        public Trabajos? Trabajos { get; set; }

        [ForeignKey("Articulos")]
        public int ArticuloId { get; set; }
        public Articulos? Articulos { get; set; }

        public int Cantidad { get; set; }

        public decimal Precio { get; set; }

        public decimal Costo { get; set; }
    }
}
