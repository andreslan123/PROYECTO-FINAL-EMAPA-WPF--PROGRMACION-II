using System;
using System.Collections.Generic;
using System.Windows;
using System.Windows.Controls;

namespace WpfApp5
{
    public partial class LOTE : Window
    {
        private List<Lote> listaLotes = new List<Lote>();
        private int contadorLote = 1;
        private Lote seleccionado = null;

        public LOTE()
        {
            InitializeComponent();
            dpFechaIngreso.SelectedDate = DateTime.Now;
            dpFechaVencimiento.SelectedDate = DateTime.Now;
            ActualizarGrid();
        }

        private void ActualizarGrid()
        {
            dgInventario.ItemsSource = null;
            dgInventario.ItemsSource = listaLotes;
        }

        private void LimpiarCampos()
        {
            txtFKProducto.Clear();
            txtPKLote.Clear();
            txtCantidadTotal.Clear();
            txtCantidadDisponible.Clear();
            txtFKProveedor.Clear();
            cbEstado.SelectedIndex = -1;
            dpFechaIngreso.SelectedDate = DateTime.Now;
            dpFechaVencimiento.SelectedDate = DateTime.Now;
            seleccionado = null;
            dgInventario.SelectedItem = null;
        }

        private bool ValidarCampos()
        {
            if (string.IsNullOrWhiteSpace(txtFKProducto.Text) || !int.TryParse(txtFKProducto.Text, out _))
            {
                MessageBox.Show("Ingrese un ID de producto válido.", "Error", MessageBoxButton.OK, MessageBoxImage.Warning);
                return false;
            }

            if (string.IsNullOrWhiteSpace(txtCantidadTotal.Text) || !int.TryParse(txtCantidadTotal.Text, out int total) || total < 0)
            {
                MessageBox.Show("Ingrese una cantidad total válida.", "Error", MessageBoxButton.OK, MessageBoxImage.Warning);
                return false;
            }

            if (string.IsNullOrWhiteSpace(txtCantidadDisponible.Text) || !int.TryParse(txtCantidadDisponible.Text, out int disponible) || disponible < 0 || disponible > total)
            {
                MessageBox.Show("Ingrese una cantidad disponible válida.", "Error", MessageBoxButton.OK, MessageBoxImage.Warning);
                return false;
            }

            if (dpFechaIngreso.SelectedDate == null || dpFechaVencimiento.SelectedDate == null)
            {
                MessageBox.Show("Seleccione fechas válidas.", "Error", MessageBoxButton.OK, MessageBoxImage.Warning);
                return false;
            }

            if (dpFechaIngreso.SelectedDate > dpFechaVencimiento.SelectedDate)
            {
                MessageBox.Show("La fecha de ingreso no puede ser mayor que la de vencimiento.", "Error", MessageBoxButton.OK, MessageBoxImage.Warning);
                return false;
            }

            if (string.IsNullOrWhiteSpace(txtFKProveedor.Text) || !int.TryParse(txtFKProveedor.Text, out _))
            {
                MessageBox.Show("Ingrese un ID de proveedor válido.", "Error", MessageBoxButton.OK, MessageBoxImage.Warning);
                return false;
            }

            if (cbEstado.SelectedItem == null)
            {
                MessageBox.Show("Seleccione un estado.", "Error", MessageBoxButton.OK, MessageBoxImage.Warning);
                return false;
            }

            return true;
        }

        private void btnGuardarDatos_Click(object sender, RoutedEventArgs e)
        {
            if (!ValidarCampos()) return;

            if (seleccionado == null)
            {
                // Nuevo lote
                Lote nuevo = new Lote
                {
                    IdLote = contadorLote++,
                    IdProducto = int.Parse(txtFKProducto.Text),
                    CantidadTotal = int.Parse(txtCantidadTotal.Text),
                    CantidadDisponible = int.Parse(txtCantidadDisponible.Text),
                    FechaIngreso = dpFechaIngreso.SelectedDate.Value,
                    FechaVencimiento = dpFechaVencimiento.SelectedDate.Value,
                    IdProveedor = int.Parse(txtFKProveedor.Text),
                    Estado = (cbEstado.SelectedItem as ComboBoxItem).Content.ToString()
                };

                listaLotes.Add(nuevo);
                MessageBox.Show("Lote agregado correctamente.", "Éxito", MessageBoxButton.OK, MessageBoxImage.Information);
            }
            else
            {
                // Editar lote
                seleccionado.IdProducto = int.Parse(txtFKProducto.Text);
                seleccionado.CantidadTotal = int.Parse(txtCantidadTotal.Text);
                seleccionado.CantidadDisponible = int.Parse(txtCantidadDisponible.Text);
                seleccionado.FechaIngreso = dpFechaIngreso.SelectedDate.Value;
                seleccionado.FechaVencimiento = dpFechaVencimiento.SelectedDate.Value;
                seleccionado.IdProveedor = int.Parse(txtFKProveedor.Text);
                seleccionado.Estado = (cbEstado.SelectedItem as ComboBoxItem).Content.ToString();

                MessageBox.Show("Lote editado correctamente.", "Éxito", MessageBoxButton.OK, MessageBoxImage.Information);
            }

            ActualizarGrid();
            LimpiarCampos();
        }

        private void dgInventario_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            seleccionado = (Lote)dgInventario.SelectedItem;
            if (seleccionado != null)
            {
                txtFKProducto.Text = seleccionado.IdProducto.ToString();
                txtPKLote.Text = seleccionado.IdLote.ToString();
                txtCantidadTotal.Text = seleccionado.CantidadTotal.ToString();
                txtCantidadDisponible.Text = seleccionado.CantidadDisponible.ToString();
                txtFKProveedor.Text = seleccionado.IdProveedor.ToString();
                dpFechaIngreso.SelectedDate = seleccionado.FechaIngreso;
                dpFechaVencimiento.SelectedDate = seleccionado.FechaVencimiento;
                cbEstado.SelectedItem = null;
                foreach (ComboBoxItem item in cbEstado.Items)
                {
                    if (item.Content.ToString() == seleccionado.Estado)
                    {
                        cbEstado.SelectedItem = item;
                        break;
                    }
                }
            }
        }

        private void btnvolver_Click(object sender, RoutedEventArgs e)
        {
            this.Close();
        }

        // Botón borrar
        private void btnBorrar_Click(object sender, RoutedEventArgs e)
        {
            if (seleccionado == null)
            {
                MessageBox.Show("Seleccione un lote para borrar.", "Error", MessageBoxButton.OK, MessageBoxImage.Warning);
                return;
            }

            listaLotes.Remove(seleccionado);
            ActualizarGrid();
            LimpiarCampos();
            MessageBox.Show("Lote eliminado correctamente.", "Éxito", MessageBoxButton.OK, MessageBoxImage.Information);
        }
    }
}
