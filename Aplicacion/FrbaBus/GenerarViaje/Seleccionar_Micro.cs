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
    public partial class Seleccionar_Micro : Form
    {
        public int id_tipo_servicio;
        public DateTime f_salida;
        public DateTime f_llegada_estim;
        public Micro micro;

        public Seleccionar_Micro(int id_tipo_servicio, DateTime f_salida, DateTime f_llegada_estim)
        {
            this.id_tipo_servicio = id_tipo_servicio;
            this.f_salida = f_salida;
            this.f_llegada_estim = f_llegada_estim;

            InitializeComponent();
            cargarComboMarcas();
            button1_Click(null, null);
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

        public class Micro
        {
            public int id { get; set; }
            public string patente { get; set; }
            public string marca { get; set; }
            public string modelo { get; set; }
            public string servicio { get; set; }
            public int cant_butacas { get; set; }
            public decimal cant_kg { get; set; }

            public override string ToString()
            {
                return "Patente: " + patente + " Marca: " + marca + " Modelo: " + modelo + " Servicio: " + servicio + " Butacas: " + cant_butacas.ToString() + " KG: " + cant_kg.ToString();
            }

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

        private void button1_Click(object sender, EventArgs e)
        {
            listado_micros.Rows.Clear();
            Conexion conn = new Conexion();
            SqlCommand sp_listado = new SqlCommand("SASHAILO.get_micros_para_viaje", conn.miConexion); // Lo inicializo
            sp_listado.CommandType = CommandType.StoredProcedure; // Defino que tipo de comando es
            SqlParameter ID_TIPO_SERVICIO = sp_listado.Parameters.Add("@p_id_tipo_servicio", SqlDbType.Int);
            SqlParameter ID_MARCA = sp_listado.Parameters.Add("@p_id_marca", SqlDbType.Int);
            SqlParameter F_SALIDA = sp_listado.Parameters.Add("@p_f_salida", SqlDbType.DateTime);
            SqlParameter F_LLEGADA_ESTIM = sp_listado.Parameters.Add("@p_f_llegada_estimada", SqlDbType.DateTime);

            ID_TIPO_SERVICIO.Value = this.id_tipo_servicio;

            if (((ComboboxItem)combo_marca.SelectedItem) == null)
                ID_MARCA.Value = DBNull.Value;
            else
                ID_MARCA.Value = ((ComboboxItem)combo_marca.SelectedItem).Value;

            F_SALIDA.Value = this.f_salida;
            F_LLEGADA_ESTIM.Value = this.f_llegada_estim;

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

                    DataGridViewImageCell iconColumn = (DataGridViewImageCell)listado_micros.Rows[i].Cells["acciones"];
                    iconColumn.Value = FrbaBus.Properties.Resources.accept_ico;
                    iconColumn.ToolTipText = "Seleccionar Micro";

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

        private void listado_micros_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {

            if (e.ColumnIndex == 7)
            {
                Int32 id_micro = Convert.ToInt32(listado_micros.Rows[e.RowIndex].Cells["id_micro"].Value.ToString());
                String query = "select mi.ID_MICRO, mi.PATENTE, mi.MODELO, mi.CANT_BUTACAS, mi.CANT_KG, ma.DESCRIPCION, ts.DESCRIPCION " +
                               "from SASHAILO.Micro mi " +
                               "join SASHAILO.Marca_Micro ma on ma.ID_MARCA = mi.ID_MARCA " +
                               "join SASHAILO.Tipo_Servicio ts on ts.ID_TIPO_SERVICIO = mi.ID_TIPO_SERVICIO " +
                               "where mi.ID_MICRO = " + id_micro + "";
                Conexion cn = new Conexion();
                SqlDataReader consulta = cn.consultar(query);
                if (consulta.Read())
                {
                    string patente = consulta.GetString(1);
                    string modelo = consulta.GetString(2);
                    int cant_butacas = consulta.GetInt32(3);
                    decimal cant_kg = consulta.GetDecimal(4);
                    string marca = consulta.GetString(5);
                    string tipo_serv = consulta.GetString(6);

                    Micro mic = new Micro();
                    mic.id = id_micro;
                    mic.patente = patente;
                    mic.marca = marca;
                    mic.modelo = modelo;
                    mic.servicio = tipo_serv;
                    mic.cant_kg = cant_kg;
                    mic.cant_butacas = cant_butacas;

                    this.micro = mic;

                }
                cn.desconectar();

                Seleccionar_Micro.ActiveForm.Close();

            }
        }
    }
}
