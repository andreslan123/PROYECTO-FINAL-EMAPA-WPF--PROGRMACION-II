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
            MainWindow main = new MainWindow();
            main.Show();
            this.Close();
        }

        private void btnProducto_Click(object sender, RoutedEventArgs e)
        {
            PRODUCTO pro = new PRODUCTO();
            pro.Show();
            this.Close();
        }

        private void btnLote_Click(object sender, RoutedEventArgs e)
        {
            LOTE lot = new LOTE();
            lot.Show();
            this.Close();
        }
    }
}
