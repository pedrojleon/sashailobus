using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Data.SqlClient; // Necesario para trabajar con SQL SERVER DB
using System.Windows.Forms;

namespace FrbaBus
{
    class Conexion
    {
        public SqlConnection miConexion = new SqlConnection(); // Creo los objetos para la conexion con la DB
        public String cadenaDeConexion = "Server=.\\SQLSERVER2008; Initial Catalog=GD1C2013; User Id=gd; Password=gd2013";

        public Conexion()
        {
            conectar();
        }

        private bool conectar()
        {
            try // Se conecta a la DB
            {
                miConexion.ConnectionString = cadenaDeConexion;
                miConexion.Open();
                return true;
            }
            catch (SqlException exception) // Si no se pudo conectar, muestra un mensaje de error
            {
                MessageBox.Show("Error" + Convert.ToString(exception), "Error");
                return false;
            }
        }

        public void desconectar()
        {
            miConexion.Close();
        }

        public SqlDataReader consultar(String cadenaDeConsulta)
        {
            SqlCommand consulta = new SqlCommand(cadenaDeConsulta, miConexion); // Creo el objeto consulta
            SqlDataReader ejecuta = consulta.ExecuteReader(); // Se ejecuta la consulta y se guarda el valor de retorno en "ejecuta"
            return ejecuta;
        }


    }
}
