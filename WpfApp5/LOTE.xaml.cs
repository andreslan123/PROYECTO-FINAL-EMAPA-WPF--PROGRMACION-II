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
using System.IO;


namespace WpfApp5
{
    /// <summary>
    /// Lógica de interacción para LOTE.xaml
    /// </summary>
    public partial class LOTE : Window
    {
        string ruta = @"C:\Users\Alumno\Escritorio\proyecto program II\PROYECTO-FINAL-EMAPA-WPF--PROGRMACION-II\WpfApp5\LOTES\lotex.txt";
        List<lote> listaLotes = new List<lote>();
        public LOTE()
        {
            InitializeComponent();
        }

        private void btnvolver_Click(object sender, RoutedEventArgs e)
        {
            AccesoATodo acce = new AccesoATodo();
            acce.Show();
            this.Close();
        }
        // ==============================
        // CARGAR DATOS DEL ARCHIVO
        // ==============================
        private void CargarArchivo()
        {
            if (!File.Exists(ruta))
                return;

            listaLotes.Clear();

            foreach (var linea in File.ReadAllLines(ruta))
            {
                var data = linea.Split('|');
                listaLotes.Add(new lote
                {
                    IdProducto = data[0],
                    IdLote = data[1],
                    CantidadTotal = int.Parse(data[2]),
                    CantidadDisponible = int.Parse(data[3]),
                    FechaIngreso = DateTime.Parse(data[4]),
                    FechaVencimiento = DateTime.Parse(data[5]),
                    IdProveedor = data[6],
                    Estado = data[7]
                });
            }

            dgInventario.ItemsSource = null;
            dgInventario.ItemsSource = listaLotes;
        }

        // ==============================
        // GUARDAR DATOS
        // ==============================
        private void btnGuardarDatos_Click(object sender, RoutedEventArgs e)
        {
            try
            {
                lote lote = new lote
                {
                    IdProducto = txtFKProducto.Text,
                    IdLote = txtPKLote.Text,
                    CantidadTotal = int.Parse(txtCantidadTotal.Text),
                    CantidadDisponible = int.Parse(txtCantidadDisponible.Text),
                    FechaIngreso = dpFechaIngreso.SelectedDate.Value,
                    FechaVencimiento = dpFechaVencimiento.SelectedDate.Value,
                    IdProveedor = txtFKProveedor.Text,
                    Estado = ((ComboBoxItem)cbEstado.SelectedItem).Content.ToString()
                };

                listaLotes.Add(lote);

                GuardarArchivo();
                CargarArchivo();
                LimpiarCampos();

                MessageBox.Show("Datos guardados correctamente.");
            }
            catch
            {
                MessageBox.Show("Revise que todos los campos estén completos.");
            }
        }

        private void GuardarArchivo()
        {
            List<string> lineas = new List<string>();

            foreach (var item in listaLotes)
            {
                lineas.Add($"{item.IdProducto}|{item.IdLote}|{item.CantidadTotal}|{item.CantidadDisponible}|{item.FechaIngreso}|{item.FechaVencimiento}|{item.IdProveedor}|{item.Estado}");
            }

            File.WriteAllLines(ruta, lineas);
        }


        private void dgInventario_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            if (dgInventario.SelectedItem is lote lote)
            {
                txtFKProducto.Text = lote.IdProducto;
                txtPKLote.Text = lote.IdLote;
                txtCantidadTotal.Text = lote.CantidadTotal.ToString();
                txtCantidadDisponible.Text = lote.CantidadDisponible.ToString();
                dpFechaIngreso.SelectedDate = lote.FechaIngreso;
                dpFechaVencimiento.SelectedDate = lote.FechaVencimiento;
                txtFKProveedor.Text = lote.IdProveedor;
                cbEstado.Text = lote.Estado;
            }
        }
        private void btnBorrar_Click(object sender, RoutedEventArgs e)
        {
            if (dgInventario.SelectedItem is lote lote)
            {
                listaLotes.Remove(lote);
                GuardarArchivo();
                CargarArchivo();
                LimpiarCampos();
            }
        }

        private void btnEditar_Click(object sender, RoutedEventArgs e)
        {
            if (dgInventario.SelectedItem is lote seleccion)
            {
                seleccion.IdProducto = txtFKProducto.Text;
                seleccion.IdLote = txtPKLote.Text;
                seleccion.CantidadTotal = int.Parse(txtCantidadTotal.Text);
                seleccion.CantidadDisponible = int.Parse(txtCantidadDisponible.Text);
                seleccion.FechaIngreso = dpFechaIngreso.SelectedDate.Value;
                seleccion.FechaVencimiento = dpFechaVencimiento.SelectedDate.Value;
                seleccion.IdProveedor = txtFKProveedor.Text;
                seleccion.Estado = cbEstado.Text;

                GuardarArchivo();
                CargarArchivo();

                MessageBox.Show("Registro editado.");
            }
        }
        private void LimpiarCampos()
        {
            txtFKProducto.Text = "";
            txtPKLote.Text = "";
            txtCantidadTotal.Text = "";
            txtCantidadDisponible.Text = "";
            dpFechaIngreso.SelectedDate = null;
            dpFechaVencimiento.SelectedDate = null;
            txtFKProveedor.Text = "";
            cbEstado.SelectedIndex = -1;
        }
    }


}

