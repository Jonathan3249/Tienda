using System;
using System.Collections.Generic;
using System.Linq;
using System.Data.Sql;
using System.Data.SqlClient;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Data;

namespace ProyectoTienda
{
    class Conexion
    {
        public static SqlConnection conex = new SqlConnection(@"workstation id=TiendaPrueba.mssql.somee.com;packet size=4096;user id=Fonseca1998_SQLLogin_1;pwd=y2lp86ek6w;data source=TiendaPrueba.mssql.somee.com;persist security info=False;initial catalog=TiendaPrueba");
        

        public int Login(string usuario, string password)
        {
            try
            {
                conex.Open();

                SqlCommand comando = new SqlCommand("spLogin", conex);
                comando.CommandType = CommandType.StoredProcedure;

                comando.Parameters.AddWithValue("@Usuario", usuario);
                comando.Parameters.AddWithValue("@Password", password);

                SqlDataReader lector = comando.ExecuteReader();

                if(lector.Read())
                {
                    return lector.GetInt32(0);

                }

            }
            catch (Exception a )
            {
                MessageBox.Show(a.Message);
            }

            finally
            {
                conex.Close();
            }
            return 0;

        }
       
    }
}
