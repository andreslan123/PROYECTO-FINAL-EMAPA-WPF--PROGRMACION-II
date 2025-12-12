using System;
using System.Collections.Generic;
using System.Windows;
using System.Windows.Controls;

namespace WpfApp5
{
    public partial class Cliente : Window
    {
        private List<ClienteModelo> listaClientes = new List<ClienteModelo>();
        private int contadorID = 1;

        public Cliente()
        {
            InitializeComponent();
            ActualizarGrid();
        }

        private void ActualizarGrid()
        {
            dgClientes.ItemsSource = null;
            dgClientes.ItemsSource = listaClientes;
        }

        private void LimpiarCampos()
        {
            txtNombre.Clear();
            txtCI.Clear();
            txtDireccion.Clear();
            txtTelefono.Clear();
            txtCorreo.Clear();
        }

        private bool ValidarCampos()
        {
            if (string.IsNullOrWhiteSpace(txtNombre.Text))
            {
                MessageBox.Show("Ingrese el nombre del cliente.");
                return false;
            }

            if (string.IsNullOrWhiteSpace(txtCI.Text))
            {
                MessageBox.Show("Ingrese el CI del cliente.");
                return false;
            }

            if (string.IsNullOrWhiteSpace(txtTelefono.Text))
            {
                MessageBox.Show("Ingrese un teléfono válido.");
                return false;
            }

            if (string.IsNullOrWhiteSpace(txtCorreo.Text))
            {
                MessageBox.Show("Ingrese un correo electrónico.");
                return false;
            }

            return true;
        }

        private void btnAgregarCliente_Click(object sender, RoutedEventArgs e)
        {
            if (!ValidarCampos()) return;

            ClienteModelo nuevo = new ClienteModelo
            {
                Id = contadorID++,
                Nombre = txtNombre.Text,
                CI = txtCI.Text,
                Direccion = txtDireccion.Text,
                Telefono = txtTelefono.Text,
                Correo = txtCorreo.Text
            };

            listaClientes.Add(nuevo);
            ActualizarGrid();
            LimpiarCampos();

            MessageBox.Show("Cliente agregado correctamente.");
        }

        private void btnEliminarCliente_Click(object sender, RoutedEventArgs e)
        {
            if (dgClientes.SelectedItem == null)
            {
                MessageBox.Show("Seleccione un cliente para eliminar.");
                return;
            }

            ClienteModelo seleccionado = (ClienteModelo)dgClientes.SelectedItem;
            listaClientes.Remove(seleccionado);
            ActualizarGrid();
        }

        private void btnVolver_Click(object sender, RoutedEventArgs e)
        {
            this.Close();
        }

        private void btnSalir_Click(object sender, RoutedEventArgs e)
        {
            Application.Current.Shutdown();
        }

        private void dgClientes_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            // Opcional: rellenar los campos al seleccionar un cliente
        }
    }
}
