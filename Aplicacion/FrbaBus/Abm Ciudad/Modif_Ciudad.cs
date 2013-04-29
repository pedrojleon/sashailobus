using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using System.Data.SqlClient;

namespace FrbaBus.Abm_Ciudad
{
    public partial class Modif_Ciudad : Form
    {
        int id_ciudad;

        public Modif_Ciudad()
        {
            InitializeComponent();
        }

        public void cargarDatos( int id_ciudad){

            this.id_ciudad = id_ciudad;

            Conexion conn = new Conexion();
            SqlDataReader resultado = conn.consultar("select NOMBRE_CIUDAD, HABILITADA from SASHAILO.Ciudad where ID_CIUDAD="+id_ciudad+"");

            if (resultado.Read())
            {
                nombre_ciudad.Text = resultado.GetString(0);
                habilitada.Checked = resultado.GetString(1) == "S";
            }
            conn.desconectar();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            string nombre = nombre_ciudad.Text.Trim();
            if (nombre.CompareTo("") == 0)
            {
                MessageBox.Show("Debe ingresar el Nombre de la Ciudad", "", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                return;
            }
            string habilit = habilitada.Checked ? "S" : "N";
            Conexion conn = new Conexion();
            SqlDataReader resultado = conn.consultar("UPDATE SASHAILO.Ciudad SET NOMBRE_CIUDAD = '"+nombre+"', HABILITADA = '"+habilit+"' WHERE ID_CIUDAD = " + this.id_ciudad + "");
            MessageBox.Show("Los datos han sido guardados", "");
            conn.desconectar();
            Modif_Ciudad.ActiveForm.Close();
        }

    }
}
