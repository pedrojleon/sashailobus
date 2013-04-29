using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using System.Data.SqlClient;

namespace FrbaBus.Login
{
    public partial class Login : Form
    {
        public Login()
        {
            InitializeComponent();
        }

        private void inToolStripMenuItem_Click(object sender, EventArgs e)
        {
            CuadroLogin.Visible = !CuadroLogin.Visible;
            usuario.Focus();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            if (usuario.Text.Trim().CompareTo("") == 0 || password.Text.Trim().CompareTo("") == 0) {
                MessageBox.Show("Debe ingresar Usuario y Contraseña", "Error", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                return;
            }

            Funciones funciones = new Funciones();

            Conexion conn = new Conexion();
            SqlCommand sp_login;

            sp_login = new SqlCommand("SASHAILO.login", conn.miConexion); // Lo inicializo
            sp_login.CommandType = CommandType.StoredProcedure; // Defino que tipo de comando es
            SqlParameter USERNAME = sp_login.Parameters.Add("@p_usuario", SqlDbType.VarChar, 15);
            SqlParameter PASSWORD = sp_login.Parameters.Add("@p_password", SqlDbType.VarChar, 64);
            SqlParameter HAY_ERROR = sp_login.Parameters.Add("@hayErr", SqlDbType.Int);
            SqlParameter ERRORES = sp_login.Parameters.Add("@errores", SqlDbType.VarChar, 200);

            USERNAME.Value = usuario.Text.Trim();
            PASSWORD.Value = funciones.encriptarClave(password.Text.Trim());
            HAY_ERROR.Direction = ParameterDirection.Output;
            ERRORES.Direction = ParameterDirection.Output;

            try
            {
                sp_login.ExecuteNonQuery();
                int hayError = Convert.ToInt16(sp_login.Parameters["@hayErr"].Value.ToString());
                if (hayError == 1)
                {
                    string errores = sp_login.Parameters["@errores"].Value.ToString();
                    MessageBox.Show(errores, null, MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                    conn.desconectar();
                    return;
                }

            }
            catch (Exception error)
            {
                MessageBox.Show(error.ToString(), null, MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                conn.desconectar();
                return;
            }

            //se logueó correctamente, muestro las entradas de menu de los administradores
            MenuABMS.Visible = true;
            MenuEstadisticas.Visible = true;
            MenuViajes.Visible = true;
            MenuIngresar.Visible = false;
            MenuSalir.Visible = true;
            CuadroLogin.Visible = false;

        }

        private void MenuSalir_Click(object sender, EventArgs e)
        {
            MenuABMS.Visible = false;
            MenuEstadisticas.Visible = false;
            MenuViajes.Visible = false;
            MenuIngresar.Visible = true;
            MenuSalir.Visible = false;
            usuario.Text = "";
            password.Text = "";
            CuadroLogin.Visible = true;
        }

        private void aBMDeRolToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Abm_Permisos.ABMRol abm_rol = new Abm_Permisos.ABMRol();
            abm_rol.Tag = this; //guardo en Tag una referencia a mi formulario
            abm_rol.ShowDialog();
        }

        private void aBMDeCiudadToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Abm_Ciudad.Abm_Ciudad abm_ciudad = new Abm_Ciudad.Abm_Ciudad();
            abm_ciudad.Tag = this; //guardo en Tag una referencia a mi formulario
            abm_ciudad.ShowDialog();
        }
    }
}
