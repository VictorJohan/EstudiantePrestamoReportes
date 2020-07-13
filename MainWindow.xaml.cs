using EstudiantePrestamoReportes.UI.Registros.rEstudiante;
using EstudiantePrestamoReportes.UI.Registros.rPrestamo;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;

namespace EstudiantePrestamoReportes
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        public MainWindow()
        {
            InitializeComponent();
        }

        private void EstudianteMenu_Click(object sender, RoutedEventArgs e)
        {
            rEstudiante rEstudiante = new rEstudiante();
            rEstudiante.Show();
        }

        private void PrestamoMenu_Click(object sender, RoutedEventArgs e)
        {
            rPrestamo rPrestamo = new rPrestamo();
            rPrestamo.Show();
        }
    }
}
