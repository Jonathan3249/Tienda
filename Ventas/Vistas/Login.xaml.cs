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

namespace ProyectoTienda.Vistas
{
    /// <summary>
    /// Lógica de interacción para Login.xaml
    /// </summary>
    public partial class Login : Window
    {
        Conexion paso = new Conexion();
        public Login()
        {
            InitializeComponent();
        }

        private void Button_Click(object sender, RoutedEventArgs e)
        {
            Cerrar();
        }

        private void Window_Closing(object sender, System.ComponentModel.CancelEventArgs e)
        {
            e.Cancel = true;
            this.Hide();
        }
        public void Cerrar()
        {
            this.Closing -= Window_Closing;
            base.Close();
        }

        private void btnIniciar_Click(object sender, RoutedEventArgs e)
        {
            int probar = paso.Login(txt_usuario.Text, txt_contrasena.Password);

            if (probar == 1)
            {
                MainWindow abrir = new MainWindow();
                Cerrar();
                abrir.Show();

            }
            else MessageBox.Show("Usuario o password incorrectos");
        }
    }
}
