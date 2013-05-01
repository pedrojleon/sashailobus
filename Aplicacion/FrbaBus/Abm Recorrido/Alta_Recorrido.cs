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
    public partial class Alta_Recorrido : Form
    {
        public Alta_Recorrido()
        {
            InitializeComponent();
            cargarCombosCiudad();
            tipo_servicio.Enabled = false;
            base_pasaje.Enabled = false;
            base_kg.Enabled = false;
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

        private void origen_SelectedIndexChanged(object sender, EventArgs e)
        {
            evaluarCombosCiudad();
        }

        private void evaluarCombosCiudad()
        {
            tipo_servicio.Items.Clear();
            tipo_servicio.Text = "";
            edit_base_pasaje.Visible = false;
            edit_base_kg.Visible = false;

            if (((ComboboxItem)origen.SelectedItem) == null || ((ComboboxItem)destino.SelectedItem) == null)
            {
                return;
            }

            int id_ciudad_origen = ((ComboboxItem)origen.SelectedItem).Value;
            int id_ciudad_destino = ((ComboboxItem)destino.SelectedItem).Value;

            Conexion cn = new Conexion();
            SqlDataReader consulta = cn.consultar("select ID_TIPO_SERVICIO, DESCRIPCION " +
                                                 " from SASHAILO.Tipo_Servicio " +
                                                 " where ID_TIPO_SERVICIO not in (select ID_TIPO_SERVICIO " + 
							                                                    " from SASHAILO.Recorrido " +
							                                                    " where ID_CIUDAD_ORIGEN = "+id_ciudad_origen+" " +
						                                                    " and ID_CIUDAD_DESTINO = "+id_ciudad_destino+") order by 1");
            //cargo el combo de tipo de servicio
            while (consulta.Read())
            {
                int id_tipo_servicio = consulta.GetInt32(0);
                string d_servicio = consulta.GetString(1);

                ComboboxItem item = new ComboboxItem();
                item.Text = d_servicio;
                item.Value = id_tipo_servicio;

                tipo_servicio.Items.Add(item);
                
            }
            cn.desconectar();
            tipo_servicio.Enabled = true;

            //evaluo los precios base
            cn = new Conexion();
            consulta = cn.consultar("select top 1 PRECIO_BASE_KG, PRECIO_BASE_PASAJE from SASHAILO.Recorrido "+ 
                                    "where ID_CIUDAD_ORIGEN = "+id_ciudad_origen+" and ID_CIUDAD_DESTINO = "+id_ciudad_destino+"");

            if (consulta.Read())  //hay precios cargados
            {
                decimal precio_base_kg = consulta.GetDecimal(0);
                decimal precio_base_pasaje = consulta.GetDecimal(1);
                base_pasaje.Text = precio_base_pasaje.ToString();
                base_kg.Text = precio_base_kg.ToString();
                base_pasaje.Enabled = false;
                base_kg.Enabled = false;
                edit_base_pasaje.Visible = true;
                edit_base_kg.Visible = true;
            }
            else {
                base_pasaje.Text = "";
                base_kg.Text = "";
                edit_base_pasaje.Visible = false;
                edit_base_kg.Visible = false;
                base_pasaje.Enabled = true;
                base_kg.Enabled = true;
            }
            cn.desconectar();
            tipo_servicio.Enabled = true;
        }

        private void destino_SelectedIndexChanged(object sender, EventArgs e)
        {
            evaluarCombosCiudad();
        }

        private void edit_base_pasaje_Click(object sender, EventArgs e)
        {
            base_pasaje.Enabled = !base_pasaje.Enabled;
        }

        private void edit_base_kg_Click(object sender, EventArgs e)
        {
            base_kg.Enabled = !base_kg.Enabled;
        }

        private void button1_Click(object sender, EventArgs e)
        {
            string str_error = "";
            if (((ComboboxItem)origen.SelectedItem) == null || ((ComboboxItem)destino.SelectedItem) == null)
                str_error = "Debe seleccionar las ciudades Origen y Destino.\n";
            if (((ComboboxItem)tipo_servicio.SelectedItem) == null)
                str_error = str_error + "Debe seleccionar el Tipo de Servicio.\n";
            if (base_kg.Text.Trim().Equals("") || base_pasaje.Text.Trim().Equals(""))
                str_error = str_error + "Debe seleccionar los precios base (Pasaje y Kg).\n";

            if (!str_error.Equals("")){
                MessageBox.Show(str_error, "Error", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                return;
            }

            Conexion conn = new Conexion();
            SqlCommand sp_recorrido_alta;

            sp_recorrido_alta = new SqlCommand("SASHAILO.sp_alta_recorrido", conn.miConexion); // Lo inicializo
            sp_recorrido_alta.CommandType = CommandType.StoredProcedure; // Defino que tipo de comando es
            SqlParameter ID_CIUDAD_ORIGEN = sp_recorrido_alta.Parameters.Add("@p_id_ciudad_origen", SqlDbType.Int);
            SqlParameter ID_CIUDAD_DESTINO = sp_recorrido_alta.Parameters.Add("@p_id_ciudad_destino", SqlDbType.Int);
            SqlParameter PRECIO_KG = sp_recorrido_alta.Parameters.Add("@p_base_kg", SqlDbType.Decimal);
            SqlParameter PRECIO_PASAJE = sp_recorrido_alta.Parameters.Add("@p_base_pasaje", SqlDbType.Decimal);
            SqlParameter ID_TIPO_SERVICIO = sp_recorrido_alta.Parameters.Add("@p_id_tipo_servicio", SqlDbType.Int);
            SqlParameter HAY_ERROR_USER = sp_recorrido_alta.Parameters.Add("@hayErr", SqlDbType.Int);
            SqlParameter ERRORES_USER = sp_recorrido_alta.Parameters.Add("@errores", SqlDbType.VarChar, 200);

            ID_CIUDAD_ORIGEN.Value = ((ComboboxItem)origen.SelectedItem).Value;
            ID_CIUDAD_DESTINO.Value = ((ComboboxItem)destino.SelectedItem).Value;
            PRECIO_KG.Value = Convert.ToDecimal(base_kg.Text.Trim());
            PRECIO_PASAJE.Value = Convert.ToDecimal(base_pasaje.Text.Trim());
            ID_TIPO_SERVICIO.Value = ((ComboboxItem)tipo_servicio.SelectedItem).Value;
            HAY_ERROR_USER.Direction = ParameterDirection.Output;
            ERRORES_USER.Direction = ParameterDirection.Output;

            try
            {
                sp_recorrido_alta.ExecuteNonQuery();

                int hayError = Convert.ToInt16(sp_recorrido_alta.Parameters["@hayErr"].Value.ToString());
                if (hayError == 1)
                {
                    string errores = sp_recorrido_alta.Parameters["@errores"].Value.ToString();
                    MessageBox.Show("Error: \n" + errores, null, MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                    conn.desconectar();
                    return;
                }
                MessageBox.Show("El recorrido ha sido dado de alta", null, MessageBoxButtons.OK);
            }
            catch (Exception error)
            {
                MessageBox.Show("Error en la creación del recorrido. Error: " + error.ToString(), null, MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                conn.desconectar();
                return;
            }
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
