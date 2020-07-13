using EstudiantePrestamoReportes.BLL;
using EstudiantePrestamoReportes.Entidades;
using System;
using System.Collections.Generic;
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

namespace EstudiantePrestamoReportes.UI.Registros.rPrestamo
{
    /// <summary>
    /// Interaction logic for rPrestamo.xaml
    /// </summary>
    public partial class rPrestamo : Window
    {
        private Prestamos Prestamo = new Prestamos();
        private int previousLineCount = 0;
        public rPrestamo()
        {
            InitializeComponent();
            this.DataContext = Prestamo;
        }

        private void BuscarPrestamoButton_Click(object sender, RoutedEventArgs e)
        {
            var prestamo = PrestamosBLL.Buscar(int.Parse(PrestamoIdTextBox.Text));

            if (prestamo != null)
            {
                this.Prestamo = prestamo;
            }
            else
            {
                this.Prestamo = new Prestamos();
            }

            this.DataContext = Prestamo;
        }

        private void NuevoButton_Click(object sender, RoutedEventArgs e)
        {
            Limpiar();
        }

        private void GuardarButton_Click(object sender, RoutedEventArgs e)
        {
            if (!Validar())
            {
                return;
            }

            var ok = PrestamosBLL.Guardar(Prestamo);

            if (ok)
            {
                Limpiar();
                MessageBox.Show("Gardado", "Exito",
                    MessageBoxButton.OK, MessageBoxImage.Information);
            }
            else
            {
                MessageBox.Show("Algo salio mal", "Fallo",
                    MessageBoxButton.OK, MessageBoxImage.Error);
            }
        }

        private void EliminarButton_Click(object sender, RoutedEventArgs e)
        {
            if (PrestamosBLL.Eliminar(int.Parse(PrestamoIdTextBox.Text)))
            {
                Limpiar();
                MessageBox.Show("Eliminado", "Exito",
                    MessageBoxButton.OK, MessageBoxImage.Information);
            }
        }

        private void ConceptoTextBox_TextChanged(object sender, TextChangedEventArgs e)
        {
            if (ConceptoTextBox.LineCount > previousLineCount)
            {
                previousLineCount = ConceptoTextBox.LineCount;
            }
        }

        public void Limpiar()
        {
            Prestamo = new Prestamos();
            this.DataContext = Prestamo;
        }

        public bool Validar()
        {
            if (PrestamoIdTextBox.Text.Length == 0)
            {
                MessageBox.Show("El campo Id Prestamo esta vacio", "Todos los campos son obligatorios",
                   MessageBoxButton.OK, MessageBoxImage.Information);
                return false;
            }
            else if (ConceptoTextBox.Text.Length == 0)
            {
                MessageBox.Show("El campo Concepto Monto esta vacio", "Todos los campos son obligatorios",
                   MessageBoxButton.OK, MessageBoxImage.Information);
                return false;
            }

            if (!Regex.IsMatch(MontoTextBox.Text, @"^[0-9]+$"))
            {
                MessageBox.Show("Verifique que haya ingresado una cantidad valida", "En el campo Monto solo pueden ir caracteres numericos",
                   MessageBoxButton.OK, MessageBoxImage.Information);
                return false;
            }

            if (!Regex.IsMatch(PrestamoIdTextBox.Text, @"^[0-9]+$"))
            {
                MessageBox.Show("Id de prestamo no permitido", "Solo se aceptan caracteres numericos",
                   MessageBoxButton.OK, MessageBoxImage.Information);
                return false;
            }

            return true;
        }
    }
}
