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
using System.Text.RegularExpressions;
using System.IO;

namespace WpfApp5
{
    /// <summary>
    /// Lógica de interacción para Sign_UP.xaml
    /// </summary>
    public partial class Sign_UP : Window
    {
        private readonly string rutaYnombreArch = @"C:\\Users\\Santivañez\\Desktop\\Proyecto Final Program II\\PROYECTO-FINAL-EMAPA-WPF--PROGRMACION-II\\WpfApp5\\DatosUsuario\\datos.txt";
        public Sign_UP()
        {
            InitializeComponent();
        }
        private void btnLimpiar_Click(object sender, RoutedEventArgs e)
        {
            txtNombre.Text = "";
            txtApePaterno.Text = "";
            txtApeMaterno.Text = "";
            txtCorreo.Text = "";
            txtCelular.Text = "";
            txtFechaNacimiento.Text = "";
            PwContrasena.Password = "";
        }
        private void btnAceptar_Click(object sender, RoutedEventArgs e)
        {

            if (txtNombre.Text == "" || txtApePaterno.Text == "" || txtApeMaterno.Text == ""
                || txtCorreo.Text == "" || txtCelular.Text == ""
                || txtFechaNacimiento.Text == "" || PwContrasena.Password == "")
            {
                lblMensajes.Content = "Deben completar TODOS los datos";
                lblMensajes.Foreground = Brushes.Red;
            }
            else
            {
                try
                {
                    lblMensajes.Content = "BIENVENIDO";
                    lblMensajes.Foreground = Brushes.Green;

                    string datos = txtNombre.Text + "," +
                        txtCorreo.Text + "," +
                        txtCelular.Text + "," +
                        PwContrasena.Password + ","+ "\n";

                    File.AppendAllText(rutaYnombreArch, datos);
                    Bienvenida bien = new Bienvenida();
                    bien.Show();
                    this.Close();

                }
                catch (Exception ex)
                {

                    MessageBox.Show("Error al guardarel archivo" + ex.Message);
                }



            }
        }
        private void txtFechaNacimiento_TextChanged(object sender, TextChangedEventArgs e)
        {

        }

        private void txtCorreo_TextChanged(object sender, TextCompositionEventArgs e)
        {
            Regex regexEmail = new Regex("^[a-zA-Z0-9@.]$");
            e.Handled = !regexEmail.IsMatch(e.Text);
        }

        private void txtCelular_TextChanged(object sender, TextCompositionEventArgs e)
        {
            Regex regexEmail = new Regex("^[0-9]$");
            e.Handled = !regexEmail.IsMatch(e.Text);
        }

        private void txtNombre_TextChanged(object sender, TextCompositionEventArgs e)
        {
            Regex regexNombre = new Regex("^[a-zA-Z]$");
            e.Handled = !regexNombre.IsMatch(e.Text);
        }

        private void txtApePaterno_TextChanged(object sender, TextCompositionEventArgs e)
        {
            Regex rexApePat = new Regex("^[a-z-ñÑA-Z]$");
            e.Handled = !rexApePat.IsMatch(e.Text);
        }

        private void txtApeMaterno_TextChanged(object sender, TextCompositionEventArgs e)
        {
            Regex rexApeMat = new Regex("^[a-zA-Z]$");
            e.Handled = !rexApeMat.IsMatch(e.Text);
        }

       
    }
}
