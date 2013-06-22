using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using System.Data.SqlClient;
using System.Configuration;

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
                    string fin_vidautil = DR[8].ToString().Trim();
                    listado_micros.Rows[i].Cells["fin_vida_util"].Value = fin_vidautil;

                    DataGridViewImageCell iconColumn = (DataGridViewImageCell)listado_micros.Rows[i].Cells["acciones"];
                    if (fin_vidautil.Equals("N")){
                        iconColumn.Value = FrbaBus.Properties.Resources.deny_ico;
                        iconColumn.ToolTipText = "Marcar como Fin de vida útil";
                    }else {
                        iconColumn.Value = FrbaBus.Properties.Resources.accept_ico;
                        iconColumn.ToolTipText = "Marcar como útil";
                    }

                    iconColumn = (DataGridViewImageCell)listado_micros.Rows[i].Cells["modificacion"];
                    iconColumn.Value = FrbaBus.Properties.Resources.edit_ico;
                    iconColumn.ToolTipText = "Editar";

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

        private void b_nuevo_Click(object sender, EventArgs e)
        {
            Alta_Micro alta = new Alta_Micro();
            alta.Tag = this; //guardo en Tag una referencia a mi formulario
            alta.ShowDialog();
        }

        private void listado_micros_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
            if (e.ColumnIndex == 10)
            {
                Int32 id_micro = Convert.ToInt32(listado_micros.Rows[e.RowIndex].Cells["id_micro"].Value.ToString());
                String fin_vida_util = (listado_micros.Rows[e.RowIndex].Cells["fin_vida_util"].Value.ToString().Equals("N")) ? "S" : "N";
                Conexion conn = new Conexion();
                SqlCommand sp;
                sp = new SqlCommand("SASHAILO.fin_vida_util_micro", conn.miConexion); // Lo inicializo
                sp.CommandType = CommandType.StoredProcedure; // Defino que tipo de comando es
                SqlParameter ID_MICRO = sp.Parameters.Add("@p_id_micro", SqlDbType.Int);
                SqlParameter M_BAJA_DEFINITIVA = sp.Parameters.Add("@p_m_baja_definitiva", SqlDbType.Char, 1);
                SqlParameter F_BAJA_DEFINITIVA = sp.Parameters.Add("@p_f_baja_definitiva", SqlDbType.DateTime);
                SqlParameter HAY_ERROR = sp.Parameters.Add("@hayErr", SqlDbType.Int);
                SqlParameter ERRORES = sp.Parameters.Add("@errores", SqlDbType.VarChar, 200);

                ID_MICRO.Value = id_micro;
                M_BAJA_DEFINITIVA.Value = fin_vida_util;
                if (fin_vida_util.Equals("S"))
                    F_BAJA_DEFINITIVA.Value = Convert.ToDateTime(ConfigurationSettings.AppSettings["fechaActual"]);
                else
                    F_BAJA_DEFINITIVA.Value = DBNull.Value;

                HAY_ERROR.Direction = ParameterDirection.Output;
                ERRORES.Direction = ParameterDirection.Output;

                try
                {
                    sp.ExecuteNonQuery();

                    int hayError = Convert.ToInt16(sp.Parameters["@hayErr"].Value.ToString());
                    if (hayError == 1)
                    {
                        string errores = sp.Parameters["@errores"].Value.ToString();
                        MessageBox.Show("Error: \n" + errores, null, MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                        conn.desconectar();
                        return;
                    }
                    if(fin_vida_util.Equals("S"))
                        MessageBox.Show("El fin de la vida útil del Micro ha sido registrado", null, MessageBoxButtons.OK);
                    else
                        MessageBox.Show("El micro aún posee vida útil", null, MessageBoxButtons.OK);
                    conn.desconectar();
                }
                catch (Exception error)
                {
                    MessageBox.Show("Error al guardar los datos: " + error.ToString(), null, MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                    conn.desconectar();
                    return;
                }
                
                b_buscar_Click(null, null);

            }

            if (e.ColumnIndex == 11)
            {
                Modif_Micro modificacion = new Modif_Micro();
                Int32 id_micro = Convert.ToInt32(listado_micros.Rows[e.RowIndex].Cells["id_micro"].Value.ToString());
                modificacion.cargarDatos(id_micro);
                modificacion.Text = "Modificacion de Micro";
                modificacion.Tag = this;
                modificacion.ShowDialog();
                b_buscar_Click(null, null);
            }
        }
    }
}
