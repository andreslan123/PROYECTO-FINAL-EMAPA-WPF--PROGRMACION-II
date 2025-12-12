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
            btnEditarProveedor.Click += btnEditarProveedor_Click;

            ActualizarGrid();
        }

        private void ActualizarGrid()
        {
            dgProveedores.ItemsSource = null;
            dgProveedores.ItemsSource = listaProveedores;
        }

        private void btnAgregarProveedor_Click(object sender, RoutedEventArgs e)
        {
            if (!ValidarCampos(out int ci))
                return;

            // Validar CI único
            if (listaProveedores.Any(p => p.CiProv == ci))
            {
                MessageBox.Show("Ya existe un proveedor con este CI.", "Error", MessageBoxButton.OK, MessageBoxImage.Warning);
                return;
            }

            // Crear nuevo proveedor y agregar
            Proveedor nuevo = new Proveedor(contadorID, txtNombre.Text.Trim(), ci);
            contadorID++;

            listaProveedores.Add(nuevo);
            ActualizarGrid();
            LimpiarCampos();

            MessageBox.Show("Proveedor agregado correctamente.", "Éxito", MessageBoxButton.OK, MessageBoxImage.Information);
        }

        private void btnEditarProveedor_Click(object sender, RoutedEventArgs e)
        {
            if (dgProveedores.SelectedItem == null)
            {
                MessageBox.Show("Seleccione un proveedor para modificar.", "Atención", MessageBoxButton.OK, MessageBoxImage.Information);
                return;
            }

            if (!ValidarCampos(out int ci))
                return;

            Proveedor seleccionado = (Proveedor)dgProveedores.SelectedItem;

            // Validar CI único, excepto el actual
            if (listaProveedores.Any(p => p.CiProv == ci && p.IdProv != seleccionado.IdProv))
            {
                MessageBox.Show("Ya existe otro proveedor con este CI.", "Error", MessageBoxButton.OK, MessageBoxImage.Warning);
                return;
            }

            // Modificar datos
            seleccionado.NomProv = txtNombre.Text.Trim();
            seleccionado.CiProv = ci;

            ActualizarGrid();
            LimpiarCampos();

            MessageBox.Show("Proveedor modificado correctamente.", "Éxito", MessageBoxButton.OK, MessageBoxImage.Information);
        }

        private void btnEliminarProveedor_Click(object sender, RoutedEventArgs e)
        {
            if (dgProveedores.SelectedItem == null)
            {
                MessageBox.Show("Seleccione un proveedor para eliminar.", "Atención", MessageBoxButton.OK, MessageBoxImage.Information);
                return;
            }

            Proveedor seleccionado = (Proveedor)dgProveedores.SelectedItem;

            var resultado = MessageBox.Show($"¿Seguro que desea eliminar al proveedor '{seleccionado.NomProv}'?", "Confirmar eliminación", MessageBoxButton.YesNo, MessageBoxImage.Question);
            if (resultado == MessageBoxResult.Yes)
            {
                listaProveedores.Remove(seleccionado);
                ActualizarGrid();
                LimpiarCampos();
            }
        }

        private void dgProveedores_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            if (dgProveedores.SelectedItem == null)
            {
                LimpiarCampos();
                return;
            }

            Proveedor seleccionado = (Proveedor)dgProveedores.SelectedItem;

            txtNombre.Text = seleccionado.NomProv;
            txtCI.Text = seleccionado.CiProv.ToString();
        }

        private bool ValidarCampos(out int ci)
        {
            ci = 0;

            string nombre = txtNombre.Text.Trim();

            if (string.IsNullOrWhiteSpace(nombre) || nombre.Length < 3)
            {
                MessageBox.Show("Ingrese un nombre válido (mínimo 3 caracteres).", "Error", MessageBoxButton.OK, MessageBoxImage.Warning);
                return false;
            }

            if (!int.TryParse(txtCI.Text.Trim(), out ci) || ci <= 0)
            {
                MessageBox.Show("CI debe ser un número mayor que 0.", "Error", MessageBoxButton.OK, MessageBoxImage.Warning);
                return false;
            }

            return true;
        }

        private void LimpiarCampos()
        {
            txtNombre.Clear();
            txtCI.Clear();
            dgProveedores.SelectedItem = null;
        }
    }
}
