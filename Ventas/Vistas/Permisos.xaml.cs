using System;
using System.Collections.Generic;
using System.Linq;
using System.Data.Sql;
using System.Data.SqlClient;
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
using System.Data;
using System.Configuration;

namespace ProyectoTienda.Vistas
{
    /// <summary>
    /// Lógica de interacción para Permisos.xaml
    /// </summary>
    public partial class Permisos : Window
    {
        public Permisos()
        {
            InitializeComponent();
            cone();
        }

        public void cone()
        {

            SqlConnection conexion = new SqlConnection();
            conexion.ConnectionString = ConfigurationManager.ConnectionStrings["Conectar"].ToString();
            conexion.Open();
            SqlCommand comando = new SqlCommand();
            comando.CommandText = "Select * From [Permisos]";
            comando.Connection = conexion;
            SqlDataReader leer = comando.ExecuteReader();
            ventana.ItemsSource = leer;
        }
    }
}
