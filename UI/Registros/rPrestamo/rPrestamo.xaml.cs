using EstudiantePrestamoReportes.Entidades;
using System;
using System.Collections.Generic;
using System.Text;
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

        }

        private void NuevoButton_Click(object sender, RoutedEventArgs e)
        {

        }

        private void GuardarButton_Click(object sender, RoutedEventArgs e)
        {

        }

        private void EliminarButton_Click(object sender, RoutedEventArgs e)
        {

        }

        private void ConceptoTextBox_TextChanged(object sender, TextChangedEventArgs e)
        {
            if (ConceptoTextBox.LineCount > previousLineCount)
            {
                previousLineCount = ConceptoTextBox.LineCount;
            }
        }
    }
}
