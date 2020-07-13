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
        public int Matricula { get; set; }
        public float Calificacion { get; set; }
        public float Valor { get; set; }
        public string TipoEvaluacion { get; set; }
        public DateTime FechaEvaluacion { get; set; }
        public string Observacion { get; set; }

        public EstudianteDetalle(int matricula, float calificacion, float valor, string tipoEvaluacion, DateTime fechaEvaluacion, string observacion)
        {
            Id = 0;
            Calificacion = calificacion;
            Valor = valor;
            TipoEvaluacion = tipoEvaluacion;
            FechaEvaluacion = fechaEvaluacion;
            Observacion = observacion;
        }

    }
}
