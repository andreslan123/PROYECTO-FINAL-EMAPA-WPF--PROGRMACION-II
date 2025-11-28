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
        private string rutaArchivoTxt = "C:\\Users\\Alumno\\Escritorio\\WpfApp5\\WpfApp5\\listaProductos\\Productos.txt";
        public PRODUCTO()
        {
            InitializeComponent();

            dgProducto.ItemsSource = lstProducto;
        }
        private int idProd = 1000;

        private void btnAgregarProducto_Click(object sender, RoutedEventArgs e)
        {
            if (txtnProductoIngresado.Text == "")
            {
                MessageBox.Show("debe ingresar el nombre de un Producto para agregar lo..");
                return; 
            }

            Producto pro = new Producto(idProd, txtnProductoIngresado.Text);
            idProd++;
            lstProducto.Add(pro);
            txtnProductoIngresado.Clear();
        }



    }
}
