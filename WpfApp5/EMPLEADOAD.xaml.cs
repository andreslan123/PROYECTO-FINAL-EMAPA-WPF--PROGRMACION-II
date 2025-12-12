using System;
using System.Collections.Generic;
using System.Windows;
using System.Windows.Controls;
using System.Collections.ObjectModel;
using System.IO;


namespace WpfApp5
{
    public partial class EmpleadoAdministrativo : Window
    {
        private readonly string rutaYnombreArch = @"C:\Users\Santivañez\Desktop\PROYECTITO PROGRAM II\PROYECTO-FINAL-EMAPA-WPF--PROGRMACION-II\WpfApp5\empAdministrativo\datos.txt";
        ObservableCollection<EmpAdministrativo> listaEmpleados = new ObservableCollection<EmpAdministrativo>();
        int contadorID = 1;

        public EmpleadoAdministrativo()
        {
            InitializeComponent();
            dgProducto.ItemsSource = listaEmpleados;
        }
        private void btnAgregarProducto_Click(object sender, RoutedEventArgs e)
        {
            try
            {
                EmpAdministrativo emp = new EmpAdministrativo()
                {
                    Id = contadorID++,
                    Nombre = txtnNombreEmpleado.Text,
                    ApePaterno = txtnProductoIngresado.Text,
                    ApeMaterno = txtCantidad.Text,
                    FechaNacimiento = txtFechaNaci.Text,
                    Turno = txtTurno.Text,
                    Telefono = "N/A"
                };

                listaEmpleados.Add(emp);
                LimpiarCampos();
            }
            catch
            {
                MessageBox.Show("Error al agregar el empleado.");
            }
        }
        private void btnEliminar_Click(object sender, RoutedEventArgs e)
        {
            if (dgProducto.SelectedItem is EmpAdministrativo seleccionado)
            {
                listaEmpleados.Remove(seleccionado);
            }
            else
            {
                MessageBox.Show("Selecciona un empleado para eliminar.");
            }
        }
        private void btnGuardar_Click(object sender, RoutedEventArgs e)
        {
            try
            {
                using (StreamWriter writer = new StreamWriter(rutaYnombreArch, false))
                {
                    foreach (var emp in listaEmpleados)
                    {
                        writer.WriteLine(
                            $"{emp.Id};{emp.Nombre};{emp.ApePaterno};{emp.ApeMaterno};{emp.FechaNacimiento};{emp.Telefono};{emp.Turno}"
                        );
                    }
                }

                MessageBox.Show("Datos guardados correctamente en el archivo TXT.");
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error al guardar los datos: " + ex.Message);
            }
        }
        private void btnSalir_Click(object sender, RoutedEventArgs e)
        {
            Application.Current.Shutdown();
        }
        private void btnVolver_Click(object sender, RoutedEventArgs e)
        {
            AccesoATodo acc = new AccesoATodo();
            acc.Show();
            this.Close();
        }
        private void LimpiarCampos()
        {
            txtnNombreEmpleado.Text = "";
            txtnProductoIngresado.Text = "";
            txtCantidad.Text = "";
            txtFechaNaci.Text = "";
            txtTurno.Text = "";
        }
    }
}
