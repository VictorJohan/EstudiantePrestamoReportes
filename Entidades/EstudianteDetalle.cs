using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text;

namespace EstudiantePrestamoReportes.Entidades
{
    public class EstudianteDetalle
    {
        [Key]
        public int Id { get; set; }
        public float Calificacion { get; set; }
        public string TipoEvaluacion { get; set; }
        public DateTime FechaEvaluacion { get; set; }
        public string Observacion { get; set; }

    }
}
