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
    public partial class Empleado : Window
    {
        private List<EmpleadoOperario> listaEmpleados = new List<EmpleadoOperario>();
        private int contadorEmpleado = 1;

        public Empleado()
        {
            InitializeComponent();
            ActualizarGrid();
        }

        private void ActualizarGrid()
        {
            dgProducto.ItemsSource = null;
            dgProducto.ItemsSource = listaEmpleados;
        }

        private void LimpiarCampos()
        {
            txtnNombreEmpleado.Clear();
            txtnProductoIngresado.Clear();
            txtCantidad.Clear();
            txtPrecio.Clear();
            txtFechaNaci.Clear();
            txtTurno.Clear();
        }

        private bool ValidarCampos()
        {
            if (string.IsNullOrWhiteSpace(txtnNombreEmpleado.Text))
            {
                MessageBox.Show("Ingrese el nombre del empleado.", "Error", MessageBoxButton.OK, MessageBoxImage.Warning);
                return false;
            }

            if (string.IsNullOrWhiteSpace(txtnProductoIngresado.Text))
            {
                MessageBox.Show("Ingrese el apellido paterno.", "Error", MessageBoxButton.OK, MessageBoxImage.Warning);
                return false;
            }

            if (string.IsNullOrWhiteSpace(txtCantidad.Text))
            {
                MessageBox.Show("Ingrese el apellido materno.", "Error", MessageBoxButton.OK, MessageBoxImage.Warning);
                return false;
            }

            if (string.IsNullOrWhiteSpace(txtPrecio.Text) || !long.TryParse(txtPrecio.Text, out _))
            {
                MessageBox.Show("Ingrese un teléfono válido.", "Error", MessageBoxButton.OK, MessageBoxImage.Warning);
                return false;
            }

            if (!DateTime.TryParse(txtFechaNaci.Text, out _))
            {
                MessageBox.Show("Ingrese una fecha de nacimiento válida.", "Error", MessageBoxButton.OK, MessageBoxImage.Warning);
                return false;
            }

            if (string.IsNullOrWhiteSpace(txtTurno.Text))
            {
                MessageBox.Show("Ingrese el turno del empleado.", "Error", MessageBoxButton.OK, MessageBoxImage.Warning);
                return false;
            }

            return true;
        }

        private void btnAgregarProducto_Click(object sender, RoutedEventArgs e)
        {
            if (!ValidarCampos()) return;

            EmpleadoOperario nuevo = new EmpleadoOperario
            {
                Id = contadorEmpleado++,
                Nombre = txtnNombreEmpleado.Text,
                ApePaterno = txtnProductoIngresado.Text,
                ApeMaterno = txtCantidad.Text,
                Telefono = txtPrecio.Text,
                FechaNacimiento = DateTime.Parse(txtFechaNaci.Text),
                Turno = txtTurno.Text
            };

            listaEmpleados.Add(nuevo);
            ActualizarGrid();
            LimpiarCampos();

            MessageBox.Show("Empleado agregado correctamente.", "Éxito", MessageBoxButton.OK, MessageBoxImage.Information);
        }

        private void btnVolver_Click(object sender, RoutedEventArgs e)
        {
            this.Close();
        }

        private void btnSalir_Click(object sender, RoutedEventArgs e)
        {
            Application.Current.Shutdown();
        }
    }
}
