using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text;

namespace EstudiantePrestamoReportes.Entidades
{
    public class Prestamos
    {
        [Key]
        public int IdPrestamo { get; set; }
        public int IdPersona { get; set; }
        public double Monto { get; set; }
        public string ConceptoPrestamo { get; set; }
        public DateTime FechaPrestamo { get; set; } = DateTime.Now;
    }
}
