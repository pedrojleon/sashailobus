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
            SqlParameter HABILITADO = sp_listado.Parameters.Add("@p_m_habilitado", SqlDbType.Char, 1);

            if (((ComboboxItem)combo_origen.SelectedItem) == null)
                ID_CIUDAD_ORIGEN.Value = DBNull.Value;
            else
                ID_CIUDAD_ORIGEN.Value = ((ComboboxItem)combo_origen.SelectedItem).Value;

            if (((ComboboxItem)combo_destino.SelectedItem) == null)
                ID_CIUDAD_DESTINO.Value = DBNull.Value;
            else
                ID_CIUDAD_DESTINO.Value = ((ComboboxItem)combo_destino.SelectedItem).Value;

            HABILITADO.Value = DBNull.Value;

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
                    String habilitado = DR[6].ToString();
                    listado_recorridos.Rows[i].Cells["habilitado"].Value = habilitado.Trim();

                    DataGridViewImageCell iconColumn = (DataGridViewImageCell)listado_recorridos.Rows[i].Cells["acciones"];
                    if (habilitado.Trim().Equals("N"))
                        iconColumn.Value = FrbaBus.Properties.Resources.accept_ico;
                    else
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

        public class ComboboxItem
        {
            public string Text { get; set; }
            public int Value { get; set; }

            public override string ToString()
            {
                return Text;
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



        private void b_nuevo_Click(object sender, EventArgs e)
        {
            Alta_Recorrido alta = new Alta_Recorrido();
            alta.Tag = this; //guardo en Tag una referencia a mi formulario
            alta.ShowDialog();
            b_buscar_Click(null, null);
        }

        private void listado_recorridos_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
            if (e.ColumnIndex == 7)
            {
                Int32 id_recorrido = Convert.ToInt32(listado_recorridos.Rows[e.RowIndex].Cells["id_recorrido"].Value.ToString());
                String habilitado = (listado_recorridos.Rows[e.RowIndex].Cells["habilitado"].Value.ToString().Trim().Equals("N")) ? "S" : "N";
                Conexion conn = new Conexion();
                SqlDataReader resultado = conn.consultar("UPDATE SASHAILO.Recorrido SET HABILITADO = '"+habilitado+"' WHERE ID_RECORRIDO = " + id_recorrido + "");
                resultado.Dispose(); // Aca hago el borrado logico
                if(habilitado.Equals("N"))
                    MessageBox.Show("El recorrido ha sido deshabilitado", "");
                else
                    MessageBox.Show("El recorrido ha sido habilitado", "");
                conn.desconectar();
                b_buscar_Click(null, null);

            }

            if (e.ColumnIndex == 8)
            {
                Modif_Recorrido modificacion = new Modif_Recorrido();
                Int32 id_recorrido = Convert.ToInt32(listado_recorridos.Rows[e.RowIndex].Cells["id_recorrido"].Value.ToString());
                modificacion.cargarDatos(id_recorrido);
                modificacion.Text = "Modificacion de Recorrido";
                modificacion.Tag = this;
                modificacion.ShowDialog();
                b_buscar_Click(null, null);
            }
        }

        private void groupBox1_Enter(object sender, EventArgs e)
        {

        }
    }
}
