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
    public partial class PROVEEDOR : Window
    {
        private List<Proveedor> listaProveedores = new List<Proveedor>();
        private int contadorID = 1;

        public PROVEEDOR()
        {
            InitializeComponent();

            btnAgregarProveedor.Click += btnAgregarProveedor_Click;
            btnEliminarProveedor.Click += btnEliminarProveedor_Click;

            ActualizarGrid();
        }
        private void ActualizarGrid()
        {
            dgClientes.ItemsSource = null;  // Resetear
            dgClientes.ItemsSource = listaProveedores; // Volver a cargar
        }

        private void btnAgregarProveedor_Click(object sender, RoutedEventArgs e)
        {

            if (txtNombre.Text == "")
            {
                MessageBox.Show("Ingrese un nombre");
                return;
            }

            int ci;
            if (!int.TryParse(txtCI.Text, out ci))
            {
                MessageBox.Show("CI debe ser un número");
                return;
            }


            Proveedor nuevo = new Proveedor(contadorID, txtNombre.Text, ci);

            contadorID++;

            listaProveedores.Add(nuevo);

            ActualizarGrid();

            txtNombre.Clear();
            txtCI.Clear();
        }

        private void btnEliminarProveedor_Click(object sender, RoutedEventArgs e)
        {

            if (dgClientes.SelectedItem == null)
            {
                MessageBox.Show("Seleccione un proveedor para eliminar");
                return;
            }

            Proveedor seleccionado = (Proveedor)dgClientes.SelectedItem;

            listaProveedores.Remove(seleccionado);

            ActualizarGrid();

        }

    }
}
