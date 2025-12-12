using System;
using System.Collections.Generic;
using System.Windows;
using System.Windows.Controls;
using System.IO;
using System.Collections.ObjectModel;

namespace WpfApp5
{
    public partial class TRAMITE : Window
    {
        private readonly string rutaArchivo = @"C:\Users\Santivañez\Desktop\PROYECTITO PROGRAM II\PROYECTO-FINAL-EMAPA-WPF--PROGRMACION-II\WpfApp5\Tramite\datos.txt";
        private ObservableCollection<Tramite> listaTramites = new ObservableCollection<Tramite>();
        private int contadorID = 1;

        public TRAMITE()
        {
            InitializeComponent();
            dgTramites.ItemsSource = listaTramites;
            CargarDatos();
        }

        private void btnAgregarTramite_Click_1(object sender, RoutedEventArgs e)
        {
            if (string.IsNullOrWhiteSpace(txtDescripcion.Text) || dpFecha.SelectedDate == null || string.IsNullOrWhiteSpace(txtResponsable.Text))
            {
                MessageBox.Show("Complete todos los campos.", "Error", MessageBoxButton.OK, MessageBoxImage.Warning);
                return;
            }

            Tramite nuevo = new Tramite()
            {
                IdTramite = contadorID++,
                Descripcion = txtDescripcion.Text,
                Fecha = dpFecha.SelectedDate.Value,
                Responsable = txtResponsable.Text
            };

            listaTramites.Add(nuevo);
            LimpiarCampos();
        }

        private void btnEditarTramite_Click_1(object sender, RoutedEventArgs e)
        {
            if (dgTramites.SelectedItem is Tramite seleccionado)
            {
                if (string.IsNullOrWhiteSpace(txtDescripcion.Text) || dpFecha.SelectedDate == null || string.IsNullOrWhiteSpace(txtResponsable.Text))
                {
                    MessageBox.Show("Complete todos los campos.", "Error", MessageBoxButton.OK, MessageBoxImage.Warning);
                    return;
                }

                seleccionado.Descripcion = txtDescripcion.Text;
                seleccionado.Fecha = dpFecha.SelectedDate.Value;
                seleccionado.Responsable = txtResponsable.Text;

                dgTramites.Items.Refresh();
                LimpiarCampos();
            }
            else
            {
                MessageBox.Show("Seleccione un trámite para modificar.", "Aviso", MessageBoxButton.OK, MessageBoxImage.Information);
            }
        }

        private void btnEliminarTramite_Click_1(object sender, RoutedEventArgs e)
        {
            if (dgTramites.SelectedItem is Tramite seleccionado)
            {
                listaTramites.Remove(seleccionado);
            }
            else
            {
                MessageBox.Show("Seleccione un trámite para eliminar.", "Aviso", MessageBoxButton.OK, MessageBoxImage.Information);
            }
        }
        private void GuardarDatos()
        {
            try
            {
                using (StreamWriter sw = new StreamWriter(rutaArchivo, false))
                {
                    foreach (var t in listaTramites)
                    {
                        sw.WriteLine($"{t.IdTramite}|{t.Descripcion}|{t.Fecha:yyyy-MM-dd}|{t.Responsable}");
                    }
                }
                MessageBox.Show("Datos guardados correctamente.", "Éxito", MessageBoxButton.OK, MessageBoxImage.Information);
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error al guardar los datos: " + ex.Message, "Error", MessageBoxButton.OK, MessageBoxImage.Error);
            }
        }

        private void CargarDatos()
        {
            if (!File.Exists(rutaArchivo)) return;

            try
            {
                string[] lineas = File.ReadAllLines(rutaArchivo);
                foreach (var linea in lineas)
                {
                    var partes = linea.Split('|');
                    if (partes.Length == 4)
                    {
                        Tramite t = new Tramite
                        {
                            IdTramite = int.Parse(partes[0]),
                            Descripcion = partes[1],
                            Fecha = DateTime.Parse(partes[2]),
                            Responsable = partes[3]
                        };
                        listaTramites.Add(t);
                        contadorID = Math.Max(contadorID, t.IdTramite + 1);
                    }
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error al cargar los datos: " + ex.Message);
            }
        }

        private void LimpiarCampos()
        {
            txtDescripcion.Text = "";
            dpFecha.SelectedDate = null;
            txtResponsable.Text = "";
        }

        private void Window_Closing(object sender, System.ComponentModel.CancelEventArgs e)
        {
            GuardarDatos();
        }

        private void btnVolver_Click(object sender, RoutedEventArgs e)
        {
            AccesoATodo acc = new AccesoATodo();
            acc.Show();
            this.Close();
        }
    }
}
