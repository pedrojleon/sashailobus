using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using System.Data.SqlClient;

namespace FrbaBus.Registrar_LLegada_Micro
{
    public partial class Registro_Llegada : Form
    {
        public Registro_Llegada()
        {
            InitializeComponent();
            cargarCombosCiudad();
            h_llegada.Format = DateTimePickerFormat.Time;
            h_llegada.ShowUpDown = true;
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

        private void button1_Click(object sender, EventArgs e)
        {
            string str_error = "";
            
            if (patente.Text.Trim().Equals("") || patente.Text.Trim().Equals(""))
                str_error = str_error + "Debe ingresar la Patente del micro.\n";

            if (((ComboboxItem)origen.SelectedItem) == null || ((ComboboxItem)destino.SelectedItem) == null)
                str_error = "Debe seleccionar las ciudades Origen y Destino.\n";

            if (!str_error.Equals(""))
            {
                MessageBox.Show(str_error, "Error", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                return;
            }

            DateTime f_llegada = f_llegada_real.Value.Date;
            f_llegada = f_llegada.AddHours(h_llegada.Value.Hour);
            f_llegada = f_llegada.AddMinutes(h_llegada.Value.Minute);

            Conexion conn = new Conexion();
            SqlCommand sp_recorrido_alta;

            sp_recorrido_alta = new SqlCommand("SASHAILO.sp_registro_llegada", conn.miConexion); // Lo inicializo
            sp_recorrido_alta.CommandType = CommandType.StoredProcedure; // Defino que tipo de comando es
            SqlParameter PATENTE = sp_recorrido_alta.Parameters.Add("@p_patente", SqlDbType.VarChar, 7);
            SqlParameter F_LLEGADA = sp_recorrido_alta.Parameters.Add("@p_f_llegada", SqlDbType.DateTime);
            SqlParameter ID_CIUDAD_ORIGEN = sp_recorrido_alta.Parameters.Add("@p_id_origen", SqlDbType.Int);
            SqlParameter ID_CIUDAD_DESTINO = sp_recorrido_alta.Parameters.Add("@p_id_destino", SqlDbType.Int);
            SqlParameter HAY_ERROR_USER = sp_recorrido_alta.Parameters.Add("@hayErr", SqlDbType.Int);
            SqlParameter ERRORES_USER = sp_recorrido_alta.Parameters.Add("@errores", SqlDbType.VarChar, 200);

            PATENTE.Value = patente.Text.Trim();
            F_LLEGADA.Value = f_llegada;
            ID_CIUDAD_ORIGEN.Value = ((ComboboxItem)origen.SelectedItem).Value;
            ID_CIUDAD_DESTINO.Value = ((ComboboxItem)destino.SelectedItem).Value;
            HAY_ERROR_USER.Direction = ParameterDirection.Output;
            ERRORES_USER.Direction = ParameterDirection.Output;

            try
            {
                sp_recorrido_alta.ExecuteNonQuery();

                int hayError = Convert.ToInt16(sp_recorrido_alta.Parameters["@hayErr"].Value.ToString());
                string errores = sp_recorrido_alta.Parameters["@errores"].Value.ToString();
                if (hayError == 1)
                {
                    MessageBox.Show(errores, null, MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                    conn.desconectar();
                    return;
                }
                MessageBox.Show(errores, "", MessageBoxButtons.OK);
            }
            catch (Exception error)
            {
                MessageBox.Show("Errores. Error: " + error.ToString(), null, MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                conn.desconectar();
                return;
            }

            Registro_Llegada.ActiveForm.Close();
        }
    }
}
