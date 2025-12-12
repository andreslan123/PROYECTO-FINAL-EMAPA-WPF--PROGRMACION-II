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

namespace WpfApp5
{
    /// <summary>
    /// Lógica de interacción para AccesoATodo.xaml
    /// </summary>
    public partial class AccesoATodo : Window
    {
        public AccesoATodo()
        {
            InitializeComponent();
        }

        private void btnAtencion_Click(object sender, RoutedEventArgs e)
        {

        }

        private void btnCerrarPrincipal_Click(object sender, RoutedEventArgs e)
        {
            this.Close();
        }

        private void btnProducto_Click(object sender, RoutedEventArgs e)
        {
            PRODUCTO pro = new PRODUCTO();
            pro.Show();
            this.Close();
        }

        private void btnEmpleado_Click(object sender, RoutedEventArgs e)
        {
            Empleado emp = new Empleado();
            emp.Show();
            this.Close();
        }

        private void btnCliente_Click(object sender, RoutedEventArgs e)
        {
            
        }

        private void btnTramite_Click(object sender, RoutedEventArgs e)
        {
            TRAMITE prove = new TRAMITE();
            prove.Show();
            this.Close();
        }

        private void btnProveedor_Click(object sender, RoutedEventArgs e)
        {
            PROVEEDOR prove = new PROVEEDOR();
            prove.Show();
            this.Close();
        }

        private void btnRegistro_Click(object sender, RoutedEventArgs e)
        {

        }

        private void btnLote_Click(object sender, RoutedEventArgs e)
        {
            LOTE lot = new LOTE();
            lot.Show();
            this.Close();
        }

        private void btnEmpleadoAdmin_Click(object sender, RoutedEventArgs e)
        {

        }

        private void btnOperario_Click(object sender, RoutedEventArgs e)
        {

        }
    }
}
