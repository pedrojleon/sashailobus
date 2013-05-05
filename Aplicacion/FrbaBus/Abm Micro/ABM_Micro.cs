using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using System.Data.SqlClient;

namespace FrbaBus.Abm_Micro
{
    public partial class ABM_Micro : Form
    {
        public ABM_Micro()
        {
            InitializeComponent();
            cargarComboMarcas();
            cargarComboServicios();
        }

        private void cargarComboMarcas()
        {

            Conexion cn = new Conexion();

            SqlDataReader consulta = cn.consultar("SELECT ID_MARCA, DESCRIPCION FROM SASHAILO.Marca_Micro order by 2");
            while (consulta.Read())
            {
                int id_marca = consulta.GetInt32(0);
                string d_marca = consulta.GetString(1);

                ComboboxItem item = new ComboboxItem();
                item.Text = d_marca;
                item.Value = id_marca;

                combo_marca.Items.Add(item);
            }
            cn.desconectar();
        }

        private void cargarComboServicios()
        {

            Conexion cn = new Conexion();

            SqlDataReader consulta = cn.consultar("SELECT ID_TIPO_SERVICIO, DESCRIPCION FROM SASHAILO.Tipo_Servicio order by 2");
            while (consulta.Read())
            {
                int id_tipo_servicio = consulta.GetInt32(0);
                string d_tipo_servicio = consulta.GetString(1);

                ComboboxItem item = new ComboboxItem();
                item.Text = d_tipo_servicio;
                item.Value = id_tipo_servicio;

                combo_servicio.Items.Add(item);
            }
            cn.desconectar();
        }

        private void b_buscar_Click(object sender, EventArgs e)
        {
            listado_micros.Rows.Clear();

            Conexion conn = new Conexion();
            SqlCommand sp_listado = new SqlCommand("SASHAILO.listado_micros", conn.miConexion); // Lo inicializo
            sp_listado.CommandType = CommandType.StoredProcedure; // Defino que tipo de comando es
            SqlParameter ID_MARCA = sp_listado.Parameters.Add("@p_id_marca", SqlDbType.Int);
            SqlParameter ID_TIPO_SERVICIO = sp_listado.Parameters.Add("@p_id_tipo_servicio", SqlDbType.Int);
            SqlParameter PATENTE = sp_listado.Parameters.Add("@p_patente", SqlDbType.VarChar, 7);

            if (((ComboboxItem)combo_marca.SelectedItem) == null)
                ID_MARCA.Value = DBNull.Value;
            else
                ID_MARCA.Value = ((ComboboxItem)combo_marca.SelectedItem).Value;

            if (((ComboboxItem)combo_servicio.SelectedItem) == null)
                ID_TIPO_SERVICIO.Value = DBNull.Value;
            else
                ID_TIPO_SERVICIO.Value = ((ComboboxItem)combo_servicio.SelectedItem).Value;

            if (tb_patente.Text.Trim().Equals(""))
                PATENTE.Value = DBNull.Value;
            else
                PATENTE.Value = tb_patente.Text.Trim();

            try
            {
                SqlDataReader DR = sp_listado.ExecuteReader();
                int i = 0;

                while (DR.Read())
                {
                    listado_micros.Rows.Add();

                    listado_micros.Rows[i].Cells["id_micro"].Value = DR[0].ToString();
                    listado_micros.Rows[i].Cells["Patente"].Value = DR[1].ToString();
                    listado_micros.Rows[i].Cells["Marca"].Value = DR[2].ToString();
                    listado_micros.Rows[i].Cells["Modelo"].Value = DR[3].ToString();
                    listado_micros.Rows[i].Cells["TipoServicio"].Value = DR[4].ToString();
                    listado_micros.Rows[i].Cells["NButacas"].Value = DR[5].ToString();
                    listado_micros.Rows[i].Cells["KG"].Value = DR[6].ToString();
                    listado_micros.Rows[i].Cells["FueraServicio"].Value = DR[7].ToString();
                    listado_micros.Rows[i].Cells["FinVidaUtil"].Value = DR[8].ToString();

                    DataGridViewImageCell iconColumn = (DataGridViewImageCell)listado_micros.Rows[i].Cells["acciones"];
                    iconColumn.Value = FrbaBus.Properties.Resources.deny_ico;

                    iconColumn = (DataGridViewImageCell)listado_micros.Rows[i].Cells["modificacion"];
                    iconColumn.Value = FrbaBus.Properties.Resources.edit_ico;

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


        }

        public class ComboboxItem
        {
            public string Text { get; set; }
            public int Value { get; set; }

            public override string ToString()
            {
                return Text;
            }

        }
    }
}
