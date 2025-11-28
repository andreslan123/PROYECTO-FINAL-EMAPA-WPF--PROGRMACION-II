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
    /// Lógica de interacción para PRODUCTO.xaml
    /// </summary>
    public partial class PRODUCTO : Window
    {
        public ObservableCollection<Producto> lstProducto { get; set; } = new ObservableCollection<Producto>();
        private string rutaArchivoTxt = "C:\\Users\\Alumno\\Escritorio\\Proyecto_Final_Porgramacion II\\PROYECTO-FINAL-EMAPA-WPF--PROGRMACION-II\\WpfApp5\\Lista_Productos\\lstProductos.txt";
        public PRODUCTO()
        {
            InitializeComponent();

            dgProducto.ItemsSource = lstProducto;
        }
        private int idProd = 1000;

        private void btnAgregarProducto_Click_1(object sender, RoutedEventArgs e)
        {
            if (string.IsNullOrWhiteSpace(txtnProductoIngresado.Text))
            {
                MessageBox.Show("Debe ingresar el nombre de un Producto para agregarlo.");
                return;
            }

            int cantidad = 0;
            double precio = 0.0;
            string fecha = "";
            Producto pro = new Producto(idProd, txtnProductoIngresado.Text, cantidad, precio, fecha);

            idProd++;
            lstProducto.Add(pro);

            txtnProductoIngresado.Clear();
        }
    }
}
