using System;
using System.Collections.Generic;
using System.Windows;
using System.Windows.Controls;

namespace WpfApp5
{
    public partial class TRAMITE : Window
    {
        private List<Tramite> listaTramites = new List<Tramite>();
        private int contadorID = 1;

        public TRAMITE()
        {
            InitializeComponent();

            // Inicializar fecha con hoy
            dpFecha.SelectedDate = DateTime.Now;

            // Eventos
            btnAgregarTramite.Click += btnAgregarTramite_Click;
            btnEditarTramite.Click += btnEditarTramite_Click;
            btnEliminarTramite.Click += btnEliminarTramite_Click;
            dgTramites.SelectionChanged += dgTramites_SelectionChanged;

            ActualizarGrid();
        }

        private void ActualizarGrid()
        {
            dgTramites.ItemsSource = null;
            dgTramites.ItemsSource = listaTramites;
        }

        private void btnAgregarTramite_Click(object sender, RoutedEventArgs e)
        {
            if (!ValidarCampos(out string desc, out DateTime fecha, out string resp))
                return;

            Tramite nuevo = new Tramite(contadorID, desc, fecha, resp);
            contadorID++;

            listaTramites.Add(nuevo);
            ActualizarGrid();
            LimpiarCampos();

            MessageBox.Show("Trámite agregado correctamente.", "Éxito", MessageBoxButton.OK, MessageBoxImage.Information);
        }

        private void btnEditarTramite_Click(object sender, RoutedEventArgs e)
        {
            if (dgTramites.SelectedItem == null)
            {
                MessageBox.Show("Seleccione un trámite para modificar.", "Atención", MessageBoxButton.OK, MessageBoxImage.Information);
                return;
            }

            if (!ValidarCampos(out string desc, out DateTime fecha, out string resp))
                return;

            Tramite seleccionado = (Tramite)dgTramites.SelectedItem;
            seleccionado.Descripcion = desc;
            seleccionado.Fecha = fecha;
            seleccionado.Responsable = resp;

            ActualizarGrid();
            LimpiarCampos();

            MessageBox.Show("Trámite modificado correctamente.", "Éxito", MessageBoxButton.OK, MessageBoxImage.Information);
        }

        private void btnEliminarTramite_Click(object sender, RoutedEventArgs e)
        {
            if (dgTramites.SelectedItem == null)
            {
                MessageBox.Show("Seleccione un trámite para eliminar.", "Atención", MessageBoxButton.OK, MessageBoxImage.Information);
                return;
            }

            Tramite seleccionado = (Tramite)dgTramites.SelectedItem;

            var resultado = MessageBox.Show($"¿Desea eliminar el trámite '{seleccionado.Descripcion}'?", "Confirmar eliminación", MessageBoxButton.YesNo, MessageBoxImage.Question);
            if (resultado == MessageBoxResult.Yes)
            {
                listaTramites.Remove(seleccionado);
                ActualizarGrid();
                LimpiarCampos();
            }
        }

        private void dgTramites_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            if (dgTramites.SelectedItem == null)
            {
                LimpiarCampos();
                return;
            }

            Tramite seleccionado = (Tramite)dgTramites.SelectedItem;
            txtDescripcion.Text = seleccionado.Descripcion;
            dpFecha.SelectedDate = seleccionado.Fecha;
            txtResponsable.Text = seleccionado.Responsable;
        }

        private bool ValidarCampos(out string descripcion, out DateTime fecha, out string responsable)
        {
            descripcion = txtDescripcion.Text.Trim();
            responsable = txtResponsable.Text.Trim();
            fecha = dpFecha.SelectedDate ?? DateTime.Now;

            if (string.IsNullOrWhiteSpace(descripcion) || descripcion.Length < 3)
            {
                MessageBox.Show("Ingrese una descripción válida (mínimo 3 caracteres).", "Error", MessageBoxButton.OK, MessageBoxImage.Warning);
                return false;
            }

            if (string.IsNullOrWhiteSpace(responsable) || responsable.Length < 3)
            {
                MessageBox.Show("Ingrese un responsable válido (mínimo 3 caracteres).", "Error", MessageBoxButton.OK, MessageBoxImage.Warning);
                return false;
            }

            if (fecha > DateTime.Now.AddYears(1) || fecha < DateTime.Now.AddYears(-1))
            {
                MessageBox.Show("Ingrese una fecha válida (dentro de un año de diferencia).", "Error", MessageBoxButton.OK, MessageBoxImage.Warning);
                return false;
            }

            return true;
        }

        private void LimpiarCampos()
        {
            txtDescripcion.Clear();
            txtResponsable.Clear();
            dpFecha.SelectedDate = DateTime.Now;
            dgTramites.SelectedItem = null;
        }
    }
}
