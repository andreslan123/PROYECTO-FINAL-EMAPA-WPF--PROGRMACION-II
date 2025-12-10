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
using System.Windows.Shapes;
using System.Collections.ObjectModel;

namespace WpfApp5
{
    /// <summary>
    /// Lógica de interacción para Empleado.xaml
    /// </summary>
    public partial class Empleado : Window
    {
        public ObservableCollection<EmpleadoOperario> lstEmpleado { get; set; } = new ObservableCollection<EmpleadoOperario>();
        private string rutaArchivoTxt = @"C:\Users\Alumno\Escritorio\Proyecto_Final_Porgramacion II\PROYECTO-FINAL-EMAPA-WPF--PROGRMACION-II\WpfApp5\DatosUsuario\datos.txt";
        public Empleado()
        {   
            InitializeComponent();
        }
        private int codEmpleOpe = 1000;

        private void btnAgregarProducto_Click(object sender, RoutedEventArgs e)
        {
            
        }

        private void btnSalir_Click(object sender, RoutedEventArgs e)
        {
            this.Close();
        }

        private void btnVolver_Click(object sender, RoutedEventArgs e)
        {
            AccesoATodo acc = new AccesoATodo();
            acc.Show();
            this.Close();
        }
    }
}
