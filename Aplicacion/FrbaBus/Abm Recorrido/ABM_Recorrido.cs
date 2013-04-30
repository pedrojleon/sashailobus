using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using System.Data.SqlClient;

namespace FrbaBus.Abm_Recorrido
{
    public partial class ABM_Recorrido : Form
    {
        public ABM_Recorrido()
        {
            InitializeComponent();
            cargarCombosCiudad();
        }

        private void b_buscar_Click(object sender, EventArgs e)
        {
            listado_recorridos.Rows.Clear();

            Conexion conn = new Conexion();
            SqlCommand sp_listado = new SqlCommand("SASHAILO.listado_recorridos", conn.miConexion); // Lo inicializo
            sp_listado.CommandType = CommandType.StoredProcedure; // Defino que tipo de comando es
            SqlParameter ID_CIUDAD_ORIGEN = sp_listado.Parameters.Add("@p_id_ciudad_origen", SqlDbType.Int);
            SqlParameter ID_CIUDAD_DESTINO = sp_listado.Parameters.Add("@p_id_ciudad_destino", SqlDbType.Int);

            if (((ComboboxItem)combo_origen.SelectedItem) == null)
                ID_CIUDAD_ORIGEN.Value = DBNull.Value;
            else
                ID_CIUDAD_ORIGEN.Value = ((ComboboxItem)combo_origen.SelectedItem).Value;

            if (((ComboboxItem)combo_destino.SelectedItem) == null)
                ID_CIUDAD_DESTINO.Value = DBNull.Value;
            else
                ID_CIUDAD_DESTINO.Value = ((ComboboxItem)combo_destino.SelectedItem).Value;

            try
            {
                SqlDataReader DR = sp_listado.ExecuteReader();
                int i = 0;

                while (DR.Read())
                {
                    listado_recorridos.Rows.Add();

                    listado_recorridos.Rows[i].Cells["id_recorrido"].Value = DR[0].ToString();
                    listado_recorridos.Rows[i].Cells["CiudadOrigen"].Value = DR[1].ToString();
                    listado_recorridos.Rows[i].Cells["CiudadDestino"].Value = DR[2].ToString();
                    listado_recorridos.Rows[i].Cells["TipoServicio"].Value = DR[3].ToString();
                    listado_recorridos.Rows[i].Cells["PrecioBasePasaje"].Value = DR[4].ToString();
                    listado_recorridos.Rows[i].Cells["PrecioBaseKg"].Value = DR[5].ToString();

                    DataGridViewImageCell iconColumn = (DataGridViewImageCell)listado_recorridos.Rows[i].Cells["acciones"];
                    iconColumn.Value = FrbaBus.Properties.Resources.deny_ico;

                    iconColumn = (DataGridViewImageCell)listado_recorridos.Rows[i].Cells["modificacion"];
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

        private void cargarCombosCiudad()
        {

            Conexion cn = new Conexion();

            SqlDataReader consulta = cn.consultar("SELECT ID_CIUDAD, NOMBRE_CIUDAD FROM SASHAILO.Ciudad WHERE HABILITADA = 'S' order by 2");
            while (consulta.Read()){
                int id_ciudad = consulta.GetInt32(0);
                string d_ciudad = consulta.GetString(1);

                ComboboxItem item = new ComboboxItem();
                item.Text = d_ciudad;
                item.Value = id_ciudad;

                combo_origen.Items.Add(item);
                combo_destino.Items.Add(item);
            }
            cn.desconectar();
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
