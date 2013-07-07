using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using System.Data.SqlClient;

namespace FrbaBus.GenerarViaje
{
    public partial class Seleccionar_Recorrido : Form
    {

        public Recorrido recorrido;

        public Seleccionar_Recorrido()
        {
            InitializeComponent();
            cargarCombosCiudad();
            b_buscar_Click(null, null);
        }

        private void cargarCombosCiudad()
        {

            Conexion cn = new Conexion();

            SqlDataReader consulta = cn.consultar("SELECT ID_CIUDAD, NOMBRE_CIUDAD FROM SASHAILO.Ciudad WHERE HABILITADA = 'S' order by 2");
            while (consulta.Read())
            {
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

        public class Recorrido
        {
            public int id { get; set; }
            public string codigo { get; set; }
            public string ciudad_o { get; set; }
            public string ciudad_d { get; set; }
            public string precio_base_kg { get; set; }
            public string precio_base_pasaje { get; set; }
            public int id_tipo_servicio { get; set; }
            public string tipo_servicio { get; set; }

            public override string ToString()
            {
                return ciudad_o + "-" + ciudad_d + ", " + tipo_servicio;
            }

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

            HABILITADO.Value = "S";

            try
            {
                SqlDataReader DR = sp_listado.ExecuteReader();
                int i = 0;

                while (DR.Read())
                {
                    String habilitado = DR[6].ToString();
                    if (habilitado.Trim().Equals("S"))
                    {
                        listado_recorridos.Rows.Add();

                        listado_recorridos.Rows[i].Cells["id_recorrido"].Value = DR[0].ToString();
                        listado_recorridos.Rows[i].Cells["CiudadOrigen"].Value = DR[1].ToString();
                        listado_recorridos.Rows[i].Cells["CiudadDestino"].Value = DR[2].ToString();
                        listado_recorridos.Rows[i].Cells["TipoServicio"].Value = DR[3].ToString();
                        listado_recorridos.Rows[i].Cells["PrecioBasePasaje"].Value = DR[4].ToString();
                        listado_recorridos.Rows[i].Cells["PrecioBaseKg"].Value = DR[5].ToString();

                        DataGridViewImageCell iconColumn = (DataGridViewImageCell)listado_recorridos.Rows[i].Cells["acciones"];
                        iconColumn.Value = FrbaBus.Properties.Resources.accept_ico;
                        iconColumn.ToolTipText = "Seleccionar Recorrido";

                        i++;
                    }
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

        private void listado_recorridos_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
            if (e.ColumnIndex == 6)
            {
                Int32 id_recorrido = Convert.ToInt32(listado_recorridos.Rows[e.RowIndex].Cells["id_recorrido"].Value.ToString());
                String query = "select re.ID_RECORRIDO, re.CODIGO_RECORRIDO, ci_o.NOMBRE_CIUDAD, ci_d.NOMBRE_CIUDAD, ts.DESCRIPCION, ts.ID_TIPO_SERVICIO " +
                               "from SASHAILO.Recorrido re " +
                               "join SASHAILO.Recorrido_Ciudades rc on rc.ID_RECORRIDO_CIUDADES = re.ID_RECORRIDO_CIUDADES " +
                               "join SASHAILO.Ciudad ci_o on ci_o.ID_CIUDAD = rc.ID_CIUDAD_ORIGEN " +
                               "join SASHAILO.Ciudad ci_d on ci_d.ID_CIUDAD = rc.ID_CIUDAD_DESTINO " +
                               "join SASHAILO.Tipo_Servicio ts on ts.ID_TIPO_SERVICIO = re.ID_TIPO_SERVICIO " +
                               "where re.ID_RECORRIDO = "+id_recorrido+"";
                Conexion cn = new Conexion();
                SqlDataReader consulta = cn.consultar(query);
                if(consulta.Read())
                {
                    string codigo = consulta.GetString(1);
                    string ciudad_o = consulta.GetString(2);
                    string ciudad_d = consulta.GetString(3);
                    string tipo_serv = consulta.GetString(4);
                    int id_tipo_serv = consulta.GetInt32(5);

                    Recorrido reco = new Recorrido();
                    reco.id = id_recorrido;
                    reco.ciudad_o = ciudad_o;
                    reco.ciudad_d = ciudad_d;
                    reco.tipo_servicio = tipo_serv;
                    reco.id_tipo_servicio = id_tipo_serv;

                    this.recorrido = reco;

                }
                cn.desconectar();

                Seleccionar_Recorrido.ActiveForm.Close();

            }
        }
    }
}
