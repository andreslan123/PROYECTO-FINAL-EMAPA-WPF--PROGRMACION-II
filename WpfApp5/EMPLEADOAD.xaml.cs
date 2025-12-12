using System;
using System.Collections.Generic;
using System.Windows;
using System.Windows.Controls;

namespace WpfApp5
{
    public partial class EmpleadoAdministrativo : Window
    {
        private List<EmpleadoAdministrativo> listaEmpleados = new List<EmpleadoAdministrativo>();
        private int contadorId = 1;

        public EmpleadoAdministrativo()
        {
            InitializeComponent();
            dpFechaNacimiento.SelectedDate = DateTime.Now;
            cbTurno.SelectedIndex = 0;
            ActualizarGrid();
        }

        private void ActualizarGrid()
        {
            dgEmpleados.ItemsSource = null;
            dgEmpleados.ItemsSource = listaEmpleados;
        }

        private void btnAgregar_Click(object sender, RoutedEventArgs e)
        {
            if (string.IsNullOrWhiteSpace(txtNombre.Text) ||
                string.IsNullOrWhiteSpace(txtApePaterno.Text) ||
                string.IsNullOrWhiteSpace(txtApeMaterno.Text) ||
                string.IsNullOrWhiteSpace(txtTelefono.Text) ||
                !dpFechaNacimiento.SelectedDate.HasValue ||
                cbTurno.SelectedItem == null)
            {
                MessageBox.Show("Todos los campos son obligatorios.");
                return;
            }

            EmpleadoAdministrativo nuevoEmpleado = new EmpleadoAdministrativo
            {
                Id = contadorId++,
                Nombre = txtNombre.Text,
                ApePaterno = txtApePaterno.Text,
                ApeMaterno = txtApeMaterno.Text,
                Telefono = txtTelefono.Text,
                FechaNacimiento = dpFechaNacimiento.SelectedDate.Value,
                Turno = ((ComboBoxItem)cbTurno.SelectedItem).Content.ToString()
            };

            listaEmpleados.Add(nuevoEmpleado);
            ActualizarGrid();
            LimpiarCampos();
        }

        private void btnEliminar_Click(object sender, RoutedEventArgs e)
        {
            if (dgEmpleados.SelectedItem == null)
            {
                MessageBox.Show("Seleccione un empleado para eliminar.");
                return;
            }

            EmpleadoAdministrativo seleccionado = (EmpleadoAdministrativo)dgEmpleados.SelectedItem;
            listaEmpleados.Remove(seleccionado);
            ActualizarGrid();
        }

        private void btnSalir_Click(object sender, RoutedEventArgs e)
        {
            this.Close();
        }

        private void LimpiarCampos()
        {
            txtNombre.Clear();
            txtApePaterno.Clear();
            txtApeMaterno.Clear();
            txtTelefono.Clear();
            dpFechaNacimiento.SelectedDate = DateTime.Now;
            cbTurno.SelectedIndex = 0;
        }
    }
}
