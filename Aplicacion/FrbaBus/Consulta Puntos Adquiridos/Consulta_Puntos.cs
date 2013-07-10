using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using System.Data.SqlClient;

namespace FrbaBus.Consulta_Puntos_Adquiridos
{
    public partial class Consulta_Puntos : Form
    {
        public Consulta_Puntos()
        {
            InitializeComponent();
            listado_puntos.ColumnHeadersDefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter;
        }

        private void dni_KeyPress(object sender, KeyPressEventArgs e)
        {
            Funciones func = new Funciones();
            func.soloNumeros(e);
        }

        private void puntosTotales()
        {
            if (dni.Text.Trim().Equals(""))
                return;

            Conexion cn = new Conexion();

            SqlDataReader consulta = cn.consultar("select PUNTOS from SASHAILO.Cliente WHERE DNI = " + dni.Text.Trim());
            if (consulta.Read())
            {
                int puntos = consulta.GetInt32(0);
                l_puntos.Text = puntos.ToString();
                l_puntos.Visible = true;
                label_puntos.Visible = true;
            }
            cn.desconectar();
        }

        private int getIdCliente()
        {
            int id_cliente = -1;

            if (dni.Text.Trim().Equals(""))
                id_cliente = - 1;

            Conexion cn = new Conexion();

            SqlDataReader consulta = cn.consultar("select ID_CLIENTE from SASHAILO.Cliente WHERE DNI = " + dni.Text.Trim());
            if (consulta.Read())
            {
                id_cliente = consulta.GetInt32(0);
            }
            cn.desconectar();

            return id_cliente;
        }

        private void b_buscar_Click(object sender, EventArgs e)
        {
            string str_error = "";
            if (dni.Text.Trim().Equals(""))
                str_error = str_error + "Ingrese el DNI del Cliente.\n";
            if (!dni.Text.Trim().Equals("") && !existeCliente())
                str_error = str_error + "El Cliente ingresado no existe.\n";

            if (!str_error.Equals(""))
            {
                MessageBox.Show(str_error, "Error", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                return;
            }

            listado_puntos.Rows.Clear();
            listado_puntos.Columns["puntos"].DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter;
            listado_puntos.Columns["fecha"].DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter;
            listado_puntos.Columns["detalle"].DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter;

            Conexion conn = new Conexion();
            SqlCommand sp_listado = new SqlCommand("SASHAILO.puntos_cliente", conn.miConexion); // Lo inicializo
            sp_listado.CommandType = CommandType.StoredProcedure; // Defino que tipo de comando es
            SqlParameter ID_CLIENTE = sp_listado.Parameters.Add("@p_id_cliente", SqlDbType.Int);

            ID_CLIENTE.Value = getIdCliente();
            

            try
            {
                SqlDataReader DR = sp_listado.ExecuteReader();
                int i = 0;

                while (DR.Read())
                {
                    listado_puntos.Rows.Add();

                    listado_puntos.Rows[i].Cells["puntos"].Value = DR[3].ToString();
                    int puntos = Convert.ToInt32(DR[3].ToString());
                    if(puntos > 0)
                        listado_puntos.Rows[i].Cells["puntos"].Style.ForeColor = Color.Green;
                    else
                        listado_puntos.Rows[i].Cells["puntos"].Style.ForeColor = Color.Red;

                    listado_puntos.Rows[i].Cells["fecha"].Value = DR[4].ToString();

                    string tipo = "Encomienda";
                    if (DR.IsDBNull(2))
                        tipo = "Pasaje";
                        
                    if(DR.IsDBNull(5)) //es viaje
                        listado_puntos.Rows[i].Cells["detalle"].Value = tipo + ": " + DR[6].ToString();
                    else //es canje
                        listado_puntos.Rows[i].Cells["detalle"].Value = DR[5].ToString();

                    i++;
                }
                DR.Close();

            }
            catch (Exception error)
            {
                MessageBox.Show("Error: " + error.ToString(), null, MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                conn.desconectar();
                return;
            }

            puntosTotales();

        }

        public bool existeCliente()
        {
            if (dni.Text.Trim().Equals(""))
                return false;

            Conexion cn = new Conexion();

            SqlDataReader consulta = cn.consultar("select ID_CLIENTE from SASHAILO.Cliente WHERE DNI = " + dni.Text.Trim() + " ");
            if (consulta.Read())
            {
                return true;
            }
            cn.desconectar();
            return false;
        }
    }
}
