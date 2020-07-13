using EstudiantePrestamoReportes.BLL;
using EstudiantePrestamoReportes.Entidades;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Shapes;

namespace EstudiantePrestamoReportes.UI.Registros.rEstudiante
{
    /// <summary>
    /// Interaction logic for rEstudiante.xaml
    /// </summary>
    public partial class rEstudiante : Window
    {
       
        private Estudiantes Estudiante = new Estudiantes();
        string[] evaluaciones = { "Primer Parcial", "Segundo Parcial", //array para inicializar el ComboBox
            "Examen Final", "Exposición", "Practicas", "Otros" };
        public rEstudiante()
        {
            InitializeComponent();

            this.DataContext = Estudiante;
            TipoEvaluacionComboBox.ItemsSource = evaluaciones;
        }

        private void BuscarButton_Click(object sender, RoutedEventArgs e)
        {
            var encontrado = EstudiantesBLL.Buscar(int.Parse(MatriculaTextBox.Text));

            if (encontrado != null)
            {
                Estudiante = encontrado;
                this.DataContext = Estudiante;
                Cargar();
            }
            else
            {
                MessageBox.Show("No se encontro el estudiante", "Error.", MessageBoxButton.OK, MessageBoxImage.Error);
            }
        }

        private void AgregarButton_Click(object sender, RoutedEventArgs e)
        {
            if (!ValidarAgregar())
                return;

            var detalle = new EstudianteDetalle(int.Parse(MatriculaTextBox.Text), float.Parse(CalificacionTextBox.Text), float.Parse(ValorTextBox.Text), 
                (string)TipoEvaluacionComboBox.SelectedItem, (DateTime)FechaNacimientoDatePicker.SelectedDate, ObservacionTextBox.Text);

            Estudiante.estudianteDetalles.Add(detalle);

            CalcularCalificaciones();
            Cargar();
            LimpiarDetalle();
        }

        private void RemoverButton_Click(object sender, RoutedEventArgs e)
        {
            Estudiante.estudianteDetalles.RemoveAt(DetalleDataGrid.SelectedIndex);
            Cargar();

            if (Estudiante.estudianteDetalles.Count != 0)//Si la lista esta vacia no hace calculos
            {
                CalcularCalificaciones();
            }
            else
            {
                MinimaTextBox.Clear();
                MaximaTextBox.Clear();
                PromedioTextBox.Clear();
                TotalPuntosTextBox.Clear();
            }

        }

        private void NuevoButton_Click(object sender, RoutedEventArgs e)
        {
            Limpiar();
        }

        private void GuardarButton_Click(object sender, RoutedEventArgs e)
        {
            if (!ValidarGuardar())
                return;

            if (EstudiantesBLL.Guardar(Estudiante))
            {
                Limpiar();
                MessageBox.Show("Guardado.", "Exito.", MessageBoxButton.OK, MessageBoxImage.Information);
            }
            else
            {
                MessageBox.Show("No se logro guardar.", "Error.", MessageBoxButton.OK, MessageBoxImage.Error);
            }
        }
        private void EliminarButton_Click(object sender, RoutedEventArgs e)
        {
            if (EstudiantesBLL.Eliminar(int.Parse(MatriculaTextBox.Text)))
            {
                Limpiar();
                MessageBox.Show("Eliminado.", "Exito.", MessageBoxButton.OK, MessageBoxImage.Information);
            }
            else
            {
                MessageBox.Show("No se logro eliminar.", "Error.", MessageBoxButton.OK, MessageBoxImage.Error);
            }
        }

        public void Cargar()
        {
            this.DataContext = null;
            this.DataContext = Estudiante;
        }

        public void CalcularCalificaciones()
        {
            float min = 30, max = 0, promedio, suma = 0;//Estas variables se utilizan para los calculos de la calificacion
            int i = 0;
            foreach (var calif in Estudiante.estudianteDetalles)
            {
                suma = suma + calif.Calificacion;
                if (calif.Calificacion > max)
                    max = calif.Calificacion;

                if (calif.Calificacion < min)
                    min = calif.Calificacion;
                i++;
            }

            promedio = suma / i;

            Estudiante.CalifMax = max;
            Estudiante.CalifMin = min;
            Estudiante.CalifPromedio = promedio;
            Estudiante.TotalPts = suma;
           
        }

        public void Limpiar()
        {
            Estudiante = new Estudiantes();
            this.DataContext = Estudiante;
        }

        public bool ValidarGuardar()
        {
            if (!Regex.IsMatch(MatriculaTextBox.Text, "^[1-9]+$"))
            {
                MessageBox.Show("Solo se permiten caracteres numericos.", "Campo Matricula.", MessageBoxButton.OK, MessageBoxImage.Error);
                return false;
            }

            if (NombresTextBox.Text.Length == 0)
            {
                MessageBox.Show("No pueden haber campos vacios.", "Campo Nombre y Apellido.", MessageBoxButton.OK, MessageBoxImage.Error);
                return false;
            }

            return true;
        }

        public bool ValidarAgregar()
        {
            if(!Regex.IsMatch(CalificacionTextBox.Text, @"(\d+(\.)?\d*)"))
            {
                MessageBox.Show("Solo se admiten caracteres numericos.", "Campo Calificación.", MessageBoxButton.OK, MessageBoxImage.Warning);
                return false;
            }

            if (!Regex.IsMatch(ValorTextBox.Text, @"(\d+(\.)?\d*)"))
            {
                MessageBox.Show("Solo se admiten caracteres numericos.", "Campo Valor.", MessageBoxButton.OK, MessageBoxImage.Warning);
                return false;
            }

            if (float.Parse(CalificacionTextBox.Text) > float.Parse(ValorTextBox.Text))
            {
                MessageBox.Show("La calificación no puede ser mayor que el valor de la evaluación.", "Campo Calificación.", MessageBoxButton.OK, MessageBoxImage.Warning);
                return false;
            }

            if (TipoEvaluacionComboBox.SelectedIndex == -1)
            {
                MessageBox.Show("Seleccione un tipo de evaluación.", "Campo Calificación.", MessageBoxButton.OK, MessageBoxImage.Warning);
                return false;
            }

            if (FechaEvaluacion.SelectedDate == null)
            {
                MessageBox.Show("Seleccione una fecha.", "Campo Fecha de Evaluación.", MessageBoxButton.OK, MessageBoxImage.Warning);
                return false;
            }

            return true;
        }

        public void LimpiarDetalle()
        {
            CalificacionTextBox.Clear();
            ValorTextBox.Clear();
            TipoEvaluacionComboBox.SelectedIndex = -1;
            FechaEvaluacion.SelectedDate = DateTime.Now;
            ObservacionTextBox.Clear();
            CalificacionTextBox.Focus();
        }
    }
}
