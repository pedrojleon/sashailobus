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

namespace FrbaBus.Compra_de_Pasajes
{
    public partial class Compra_Pasaje : Form
    {

        public DateTime fecha_actual;

        public Compra_Pasaje()
        {
            InitializeComponent();
            cargarCombosCiudad();
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

                origen.Items.Add(item);
                destino.Items.Add(item);
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

        private void b_guardar_Click(object sender, EventArgs e)
        {
            string str_error = "";
            if (((ComboboxItem)origen.SelectedItem) == null || ((ComboboxItem)destino.SelectedItem) == null)
                str_error = "Debe seleccionar las ciudades Origen y Destino.\n";
            if (fechaSalidaMenorActual())
                str_error = str_error + "La fecha de salida no puede ser previa a la actual.\n";

            if (!str_error.Equals(""))
            {
                MessageBox.Show(str_error, "Error", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                return;
            }

            Conexion conn = new Conexion();
            SqlCommand sp_listado = new SqlCommand("SASHAILO.get_viajes_disponibles", conn.miConexion); // Lo inicializo
            sp_listado.CommandType = CommandType.StoredProcedure; // Defino que tipo de comando es
            SqlParameter F_SALIDA = sp_listado.Parameters.Add("@p_f_salida", SqlDbType.DateTime);
            SqlParameter ID_CIUDAD_ORIGEN = sp_listado.Parameters.Add("@p_id_ciudad_origen", SqlDbType.Int);
            SqlParameter ID_CIUDAD_DESTINO = sp_listado.Parameters.Add("@p_id_ciudad_destino", SqlDbType.Int);

            F_SALIDA.Value = getFechaSalida();
            ID_CIUDAD_ORIGEN.Value = ((ComboboxItem)origen.SelectedItem).Value;
            ID_CIUDAD_DESTINO.Value = ((ComboboxItem)destino.SelectedItem).Value;

            try
            {
                SqlDataReader DR = sp_listado.ExecuteReader();
                int i = 0;

                while (DR.Read())
                {
                    listado_de_viajes.Rows.Add();

                    listado_de_viajes.Rows[i].Cells["id_viaje"].Value = DR[0].ToString();
                    listado_de_viajes.Rows[i].Cells["Micro"].Value = DR[1].ToString();
                    listado_de_viajes.Rows[i].Cells["TipoServicio"].Value = DR[2].ToString();
                    listado_de_viajes.Rows[i].Cells["Salida"].Value = DR[3].ToString();
                    listado_de_viajes.Rows[i].Cells["LlegadaEstim"].Value = DR[4].ToString();

                    String butacas_micro = DR[5].ToString();
                    String butacas_disp = DR[6].ToString();
                    String kg_micro = DR[7].ToString();
                    String kg_disp = DR[8].ToString();

                    listado_de_viajes.Rows[i].Cells["butacas"].Value = butacas_disp + " de " + butacas_micro;
                    listado_de_viajes.Rows[i].Cells["kg"].Value = kg_disp + " de " + kg_micro;

                    DataGridViewImageCell iconColumn = (DataGridViewImageCell)listado_de_viajes.Rows[i].Cells["acciones"];
                    iconColumn.Value = FrbaBus.Properties.Resources.accept_ico;
                    iconColumn.ToolTipText = "Seleccionar Viaje";

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

        public Boolean fechaSalidaMenorActual()
        {

            this.fecha_actual = Convert.ToDateTime(ConfigurationSettings.AppSettings["fechaActual"]);

            DateTime v_f_salida = f_salida.Value;
            v_f_salida = v_f_salida.AddHours(-v_f_salida.Hour);
            v_f_salida = v_f_salida.AddMinutes(-v_f_salida.Minute);
            v_f_salida = v_f_salida.AddSeconds(-v_f_salida.Second);
            v_f_salida = v_f_salida.AddMilliseconds(-v_f_salida.Millisecond);

            if (v_f_salida < this.fecha_actual)
                return true;

            return false;

        }

        public DateTime getFechaSalida()
        {

            DateTime fechaSalida; 

            this.fecha_actual = Convert.ToDateTime(ConfigurationSettings.AppSettings["fechaActual"]);
            DateTime v_f_salida = f_salida.Value;

            if (this.fecha_actual.Year == v_f_salida.Year && this.fecha_actual.Month == v_f_salida.Month && this.fecha_actual.Day == v_f_salida.Day)
            {
                fechaSalida = v_f_salida;
            }
            else {
                v_f_salida = v_f_salida.AddHours(-v_f_salida.Hour);
                v_f_salida = v_f_salida.AddMinutes(-v_f_salida.Minute);
                v_f_salida = v_f_salida.AddSeconds(-v_f_salida.Second);
                v_f_salida = v_f_salida.AddMilliseconds(-v_f_salida.Millisecond);
                fechaSalida = v_f_salida;
            }

            return fechaSalida;

        }
    }
}
