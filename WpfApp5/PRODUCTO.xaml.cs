using System;
using System.Collections.Generic;
using System.Windows;
using System.Windows.Controls;

namespace WpfApp5
{
    public partial class PRODUCTO : Window
    {
        private List<Producto> listaProductos = new List<Producto>();
        private int contadorID = 1;
        private Producto seleccionado = null;

        public PRODUCTO()
        {
            InitializeComponent();
            dpFecha.SelectedDate = DateTime.Now;
            ActualizarGrid();
        }

        private void ActualizarGrid()
        {
            dgProducto.ItemsSource = null;
            dgProducto.ItemsSource = listaProductos;
        }

        private void LimpiarCampos()
        {
            txtNombreProducto.Clear();
            txtCantidad.Clear();
            txtPrecio.Clear();
            dpFecha.SelectedDate = DateTime.Now;
            seleccionado = null;
            dgProducto.SelectedItem = null;
        }

        private void btnAgregarProducto_Click(object sender, RoutedEventArgs e)
        {
            if (!ValidarCampos()) return;

            Producto nuevo = new Producto(contadorID, txtNombreProducto.Text, int.Parse(txtCantidad.Text), double.Parse(txtPrecio.Text), dpFecha.SelectedDate.Value.ToShortDateString());
            contadorID++;
            listaProductos.Add(nuevo);
            ActualizarGrid();
            LimpiarCampos();
            MessageBox.Show("Producto agregado correctamente.", "Éxito", MessageBoxButton.OK, MessageBoxImage.Information);
        }

        private void btnEditarProducto_Click(object sender, RoutedEventArgs e)
        {
            if (seleccionado == null)
            {
                MessageBox.Show("Seleccione un producto para editar.", "Error", MessageBoxButton.OK, MessageBoxImage.Warning);
                return;
            }

            if (!ValidarCampos()) return;

            seleccionado.Nombre = txtNombreProducto.Text;
            seleccionado.Cantidad = int.Parse(txtCantidad.Text);
            seleccionado.Precio = double.Parse(txtPrecio.Text);
            seleccionado.Fecha = dpFecha.SelectedDate.Value.ToShortDateString();

            ActualizarGrid();
            LimpiarCampos();
            MessageBox.Show("Producto editado correctamente.", "Éxito", MessageBoxButton.OK, MessageBoxImage.Information);
        }

        private void btnEliminarProducto_Click(object sender, RoutedEventArgs e)
        {
            if (seleccionado == null)
            {
                MessageBox.Show("Seleccione un producto para eliminar.", "Error", MessageBoxButton.OK, MessageBoxImage.Warning);
                return;
            }

            listaProductos.Remove(seleccionado);
            ActualizarGrid();
            LimpiarCampos();
            MessageBox.Show("Producto eliminado correctamente.", "Éxito", MessageBoxButton.OK, MessageBoxImage.Information);
        }

        private void dgProducto_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            seleccionado = (Producto)dgProducto.SelectedItem;
            if (seleccionado != null)
            {
                txtNombreProducto.Text = seleccionado.Nombre;
                txtCantidad.Text = seleccionado.Cantidad.ToString();
                txtPrecio.Text = seleccionado.Precio.ToString();
                dpFecha.SelectedDate = DateTime.Parse(seleccionado.Fecha);
            }
        }

        private void btnVolver_Click(object sender, RoutedEventArgs e)
        {
            this.Close();
        }

        private void btnSalir_Click(object sender, RoutedEventArgs e)
        {
            Application.Current.Shutdown();
        }

        private bool ValidarCampos()
        {
            if (string.IsNullOrWhiteSpace(txtNombreProducto.Text))
            {
                MessageBox.Show("Ingrese un nombre válido.", "Error", MessageBoxButton.OK, MessageBoxImage.Warning);
                return false;
            }

            if (!int.TryParse(txtCantidad.Text, out int cantidad) || cantidad < 1)
            {
                MessageBox.Show("Ingrese una cantidad válida.", "Error", MessageBoxButton.OK, MessageBoxImage.Warning);
                return false;
            }

            if (!double.TryParse(txtPrecio.Text, out double precio) || precio < 0)
            {
                MessageBox.Show("Ingrese un precio válido.", "Error", MessageBoxButton.OK, MessageBoxImage.Warning);
                return false;
            }

            if (dpFecha.SelectedDate == null)
            {
                MessageBox.Show("Seleccione una fecha válida.", "Error", MessageBoxButton.OK, MessageBoxImage.Warning);
                return false;
            }

            return true;
        }
    }
}
