using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text;
using System.Windows.Controls;

namespace EstudiantePrestamoReportes.Entidades
{
    public class Estudiantes
    {
        [Key]
        public int Matricula { get; set; }
        public string Nombres { get; set; }
        public DateTime FechaNacimiento { get; set; } = DateTime.Now;
        public float CalifPromedio { get; set; }
        public float CalifMax { get; set; }
        public float CalifMin { get; set; }
        public float TotalPts { get; set; }
        
        [ForeignKey("Matricula")]
        public List<EstudianteDetalle> estudianteDetalles { get; set; } = new List<EstudianteDetalle>();
    }
}
