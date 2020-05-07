using System;
using System.Collections.Generic;
using System.Linq;
using System.Data.Sql;
using System.Data.SqlClient;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Data;
using System.Windows.Input;
using System.Data;
using System.Configuration;
using ProyectoTienda.Vistas;
using System.Windows.Forms;



namespace ProyectoTienda.Vistas
{
    /// <summary>
    /// Lógica de interacción para Personas.xaml
    /// </summary>
    public partial class Personas : Window
    {
        public Personas()
        {
            InitializeComponent();
            Conexiones();
            
        }

        public void Conexiones()
        {
            try
            {
                SqlCommand cmd = new SqlCommand("spPersonas", Conexion.conex);
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.Parameters.AddWithValue("@Opcion", 2);
                DataTable tabla = new DataTable();
                Conexion.conex.Open();
                SqlDataAdapter puente = new SqlDataAdapter(cmd);
                puente.Fill(tabla);
                Conexion.conex.Close();
                ventana.DataContext = tabla;
                
            }
            catch(Exception asd)
            {
                asd.ToString();
                Conexion.conex.Close();
            }
            
        }

        private void mover(object sender, MouseButtonEventArgs e)
        {
            this.DragMove();
        }
        private void Button_Click(object sender, RoutedEventArgs e)
        {
            if (ventana.SelectedCells.Count > 0)
            {
                DataRowView vista = (DataRowView)ventana.SelectedItem;
                int id_persona = (int)(vista["Id_persona"]);
                String nombres = (vista["Nombre"]).ToString();
                String direcciones = (vista["Direccion"]).ToString();
                String telefonos = (vista["Telefono"]).ToString();
                String empresas = (vista["Empresa"]).ToString();

                AddPersonas abrir = new AddPersonas(2, id_persona, nombres, empresas, telefonos, direcciones);
                abrir.ShowDialog();
                abrir.Close();
                Conexiones();
            }
            else System.Windows.MessageBox.Show("Seleccione algun dato de la tabla.");

        }
        private void Button_Click_1(object sender, RoutedEventArgs e)
        {
            this.Close();
        }

     

        private void Button_Click_2(object sender, RoutedEventArgs e)
        {
            Conexiones();
        }

        private void Button_Click_3(object sender, RoutedEventArgs e)
            {
            DataRowView vista = (DataRowView)ventana.SelectedItem;
            int result = (int)(vista["Id_persona"]);

            if (ventana.SelectedCells.Count > 0)
            {
                try
                {
                    MessageBoxResult respuesta = System.Windows.MessageBox.Show("Esta seguro de eliminar?",
                                            "confirmar", MessageBoxButton.YesNo, MessageBoxImage.Question);
                    if (respuesta == MessageBoxResult.Yes)
                    {                        
                        SqlCommand cmd = new SqlCommand("spPersonas", Conexion.conex);                        
                        cmd.CommandType = CommandType.StoredProcedure;
                        cmd.Parameters.AddWithValue("@Opcion", 4);                        
                        cmd.Parameters.AddWithValue("@Id", result);                       
                        Conexion.conex.Open();                
                        cmd.ExecuteNonQuery();           
                        Conexion.conex.Close();
                        Conexiones();
                    }
                }
                catch (Exception ea)
                {
                    ea.ToString();
                    Conexion.conex.Close();
                }
            }
            else System.Windows.MessageBox.Show("Seleccione algun dato de la tabla");
        }

        private void Button_Click_4(object sender, RoutedEventArgs e)
        {
            AddPersonas mostrar = new AddPersonas(1);
            mostrar.ShowDialog();
            mostrar.Close();
            Conexiones();

        }
    }
}
