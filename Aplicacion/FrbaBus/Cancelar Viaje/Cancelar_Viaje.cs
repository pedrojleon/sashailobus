using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using System.Data.SqlClient;

namespace FrbaBus.Cancelar_Viaje
{
    public partial class Cancelar_Viaje : Form
    {
        public Cancelar_Viaje()
        {
            InitializeComponent();
        }

        private void compra_KeyPress(object sender, KeyPressEventArgs e)
        {
            Funciones func = new Funciones();
            func.soloNumeros(e);
        }

        private void pasaje_KeyPress(object sender, KeyPressEventArgs e)
        {
            Funciones func = new Funciones();
            func.soloNumeros(e);
        }

        private void encomienda_KeyPress(object sender, KeyPressEventArgs e)
        {
            Funciones func = new Funciones();
            func.soloNumeros(e);
        }

        private void b_guardar_Click(object sender, EventArgs e)
        {
            string str_error = "";
            if (compra.Text.Trim().Equals("") || compra.Text.Trim().Equals(""))
                str_error = str_error + "Debe ingresar el Código de Compra.\n";
            if (!pasaje.Text.Trim().Equals("") && !encomienda.Text.Trim().Equals(""))
                str_error = str_error + "No puede cancelar dos cosas a la vez. \nBorre el Código de Pasaje o el de Encomienda.\n";

            if (!str_error.Equals(""))
            {
                MessageBox.Show(str_error, "Error", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                return;
            }

            Conexion conn = new Conexion();
            SqlCommand sp;

            Funciones func = new Funciones();

            sp = new SqlCommand("SASHAILO.sp_devolver_compra", conn.miConexion); // Lo inicializo
            sp.CommandType = CommandType.StoredProcedure; // Defino que tipo de comando es
            SqlParameter ID_COMPRA = sp.Parameters.Add("@p_id_compra", SqlDbType.Int);
            SqlParameter ID_PASAJE = sp.Parameters.Add("@p_id_pasaje", SqlDbType.BigInt);
            SqlParameter ID_ENCOMIENDA = sp.Parameters.Add("@p_id_encomienda", SqlDbType.BigInt);
            SqlParameter F_DEVOLUCION = sp.Parameters.Add("@p_f_devolucion", SqlDbType.DateTime);
            SqlParameter MOTIVO = sp.Parameters.Add("@p_motivo", SqlDbType.VarChar, 255);
            SqlParameter HAY_ERROR_USER = sp.Parameters.Add("@hayErr", SqlDbType.Int);
            SqlParameter ERRORES_USER = sp.Parameters.Add("@errores", SqlDbType.VarChar, 200);

            ID_COMPRA.Value = compra.Text.Trim();
            if (!pasaje.Text.Trim().Equals(""))
            {
                ID_PASAJE.Value = pasaje.Text.Trim();
            }
            else {
                ID_PASAJE.Value = DBNull.Value;
            }
            if (!encomienda.Text.Trim().Equals(""))
            {
                ID_ENCOMIENDA.Value = encomienda.Text.Trim();
            }
            else
            {
                ID_ENCOMIENDA.Value = DBNull.Value;
            }
            F_DEVOLUCION.Value = func.getFechaActual();
            MOTIVO.Value = motivo.Text.Trim();
            HAY_ERROR_USER.Direction = ParameterDirection.Output;
            ERRORES_USER.Direction = ParameterDirection.Output;

            try
            {
                sp.ExecuteNonQuery();

                int hayError = Convert.ToInt16(sp.Parameters["@hayErr"].Value.ToString());
                if (hayError == 1)
                {
                    string errores = sp.Parameters["@errores"].Value.ToString();
                    MessageBox.Show(errores, null, MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                    conn.desconectar();
                    return;
                }
                if (!pasaje.Text.Trim().Equals(""))
                    MessageBox.Show("El Pasaje ha sido cancelado", null, MessageBoxButtons.OK);
                if (!encomienda.Text.Trim().Equals(""))
                    MessageBox.Show("La Encomienda ha sido cancelada", null, MessageBoxButtons.OK);
                else
                    MessageBox.Show("La Compra ha sido cancelada", null, MessageBoxButtons.OK);
            }
            catch (Exception error)
            {
                MessageBox.Show("Error en la base de datos. Error: " + error.ToString(), null, MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                conn.desconectar();
                return;
            }

            //Cancelar_Viaje.ActiveForm.Close();
        }

        private void label2_Click(object sender, EventArgs e)
        {

        }
    }
}
