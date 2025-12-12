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
using System.IO;

namespace WpfApp5
{
    public partial class Empleado : Window
    {
        private readonly string rutaYnombreArch = @"C:\Users\Santivañez\Desktop\PROYECTITO PROGRAM II\PROYECTO-FINAL-EMAPA-WPF--PROGRMACION-II\WpfApp5\EmpOperario\datos.txt";
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
                MessageBox.Show("Ingrese el nombre del empleado.", "Error");
                return false;
            }

            if (string.IsNullOrWhiteSpace(txtnProductoIngresado.Text))
            {
                MessageBox.Show("Ingrese el apellido paterno.", "Error");
                return false;
            }

            if (string.IsNullOrWhiteSpace(txtCantidad.Text))
            {
                MessageBox.Show("Ingrese el apellido materno.", "Error");
                return false;
            }

            if (!long.TryParse(txtPrecio.Text, out _))
            {
                MessageBox.Show("Ingrese un teléfono válido.", "Error");
                return false;
            }

            if (!DateTime.TryParse(txtFechaNaci.Text, out _))
            {
                MessageBox.Show("Fecha de nacimiento inválida.", "Error");
                return false;
            }

            if (string.IsNullOrWhiteSpace(txtTurno.Text))
            {
                MessageBox.Show("Ingrese el turno.", "Error");
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

            MessageBox.Show("Empleado agregado correctamente.", "Éxito");
        }
        private void btnGuardar_Click(object sender, RoutedEventArgs e)
        {
            try
            {
                using (StreamWriter sw = new StreamWriter(rutaYnombreArch, false))
                {
                    foreach (var emp in listaEmpleados)
                    {
                        sw.WriteLine($"{emp.Id}|{emp.Nombre}|{emp.ApePaterno}|{emp.ApeMaterno}|{emp.Telefono}|{emp.FechaNacimiento}|{emp.Turno}");
                    }
                }

                MessageBox.Show("Datos guardados correctamente.", "Éxito");
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error al guardar archivo: " + ex.Message);
            }
        }
        private void CargarDesdeArchivo()
        {
            if (!File.Exists(rutaYnombreArch)) return;

            try
            {
                listaEmpleados.Clear();

                foreach (var linea in File.ReadAllLines(rutaYnombreArch))
                {
                    var data = linea.Split('|');

                    listaEmpleados.Add(new EmpleadoOperario
                    {
                        Id = int.Parse(data[0]),
                        Nombre = data[1],
                        ApePaterno = data[2],
                        ApeMaterno = data[3],
                        Telefono = data[4],
                        FechaNacimiento = DateTime.Parse(data[5]),
                        Turno = data[6]
                    });
                }

                contadorEmpleado = listaEmpleados.Count > 0 ? listaEmpleados.Max(e => e.Id) + 1 : 1;
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error al cargar archivo: " + ex.Message);
            }
        }
        private void btnEliminar_Click(object sender, RoutedEventArgs e)
        {
            if (dgProducto.SelectedItem == null)
            {
                MessageBox.Show("Seleccione un empleado para eliminar.", "Error");
                return;
            }

            var seleccionado = dgProducto.SelectedItem as EmpleadoOperario;

            listaEmpleados.Remove(seleccionado);
            ActualizarGrid();

            MessageBox.Show("Empleado eliminado.", "Éxito");
        }
        private void btnVolver_Click(object sender, RoutedEventArgs e)
        {
            AccesoATodo acc = new AccesoATodo();
            acc.Show();
            this.Close();
        }
        private void btnSalir_Click(object sender, RoutedEventArgs e)
        {
            Application.Current.Shutdown();
        }

        private void btnSalir_Click_1(object sender, RoutedEventArgs e)
        {

        }
    }
}
