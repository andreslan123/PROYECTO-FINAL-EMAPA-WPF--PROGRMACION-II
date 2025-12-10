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
using System.Windows.Navigation;
using System.Windows.Shapes;
using System.Text.RegularExpressions;
using System.IO;

namespace WpfApp5
{
    /// <summary>
    /// Lógica de interacción para MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        private readonly string rutaYnombreArch = @"C:\Users\Alumno\Escritorio\proyecto program II\PROYECTO-FINAL-EMAPA-WPF--PROGRMACION-II\WpfApp5\DatosUsuario\datos.txt";
        public MainWindow()
        {
            InitializeComponent();
        }
        private void txtCuenta_PreviewTextInput(object sender, TextCompositionEventArgs e)
        {
            
        }
        private void btnCrear_Click_2(object sender, RoutedEventArgs e)
        {
            Sign_UP Signup = new Sign_UP();
            Signup.Show();
            this.Close();
        }

        private void btnIngresar_Click_1(object sender, RoutedEventArgs e)
        {
            if (string.IsNullOrWhiteSpace(txtUsuario.Text) || string.IsNullOrWhiteSpace(PwContraseña.Password))
            {
                MessageBox.Show("Deben completar TODOS los datos", "Error", MessageBoxButton.OK, MessageBoxImage.Error);
                return;
            }

            try
            {
                string correo = txtUsuario.Text;
                string contra = PwContraseña.Password;

                if (!File.Exists(rutaYnombreArch))
                {
                    MessageBox.Show("La ruta o nombre del archivo no existe", "Error", MessageBoxButton.OK, MessageBoxImage.Error);
                    return;
                }

                var lineas = File.ReadAllLines(rutaYnombreArch);
                bool encontrado = false;

                foreach (var unaLinea in lineas)
                {
                    var partes = unaLinea.Split(',');
                    if (correo.Equals(partes[1]) && contra.Equals(partes[3]))
                    {
                        encontrado = true;
                        break;
                    }
                }

                if (encontrado)
                {
                    MessageBox.Show("BIENVENIDO", "Éxito", MessageBoxButton.OK, MessageBoxImage.Information);
                }
                else
                {
                    MessageBox.Show("Usuario denegado", "Error", MessageBoxButton.OK, MessageBoxImage.Warning);
                    txtUsuario.Clear();
                    PwContraseña.Clear();
                }
                AccesoATodo acce = new AccesoATodo();
                acce.Show();
                this.Close();
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error al procesar el archivo: " + ex.Message, "Error", MessageBoxButton.OK, MessageBoxImage.Error);
            }

        }

        private void txtUsuario_TextChanged(object sender, TextCompositionEventArgs e)
        {
            Regex regexEmail = new Regex("^[a-zA-Z0-9@.]$");
            e.Handled = !regexEmail.IsMatch(e.Text);
        }
    }
}

