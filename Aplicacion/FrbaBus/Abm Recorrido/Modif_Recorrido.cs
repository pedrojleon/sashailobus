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
    public partial class Modif_Recorrido : Form
    {
        Int32 id_recorrido;

        public Modif_Recorrido()
        {
            InitializeComponent();
            cargarCombosCiudad();
            cargarComboTipoServicio();
        }

        public void cargarCombosCiudad() {

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

        public void cargarComboTipoServicio()
        {

            Conexion cn = new Conexion();

            SqlDataReader consulta = cn.consultar("SELECT ID_TIPO_SERVICIO, DESCRIPCION FROM SASHAILO.Tipo_Servicio order by 2");
            while (consulta.Read())
            {
                int id = consulta.GetInt32(0);
                string descripcion = consulta.GetString(1);

                ComboboxItem item = new ComboboxItem();
                item.Text = descripcion;
                item.Value = id;

                tipo_servicio.Items.Add(item);

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

        public void cargarDatos(Int32 id_recorrido){

            this.id_recorrido = id_recorrido;

            Conexion cn = new Conexion();

            SqlDataReader consulta = cn.consultar("select rc.ID_CIUDAD_ORIGEN, rc.ID_CIUDAD_DESTINO, rc.PRECIO_BASE_KG, rc.PRECIO_BASE_PASAJE, re.ID_TIPO_SERVICIO "
                                                + "from SASHAILO.Recorrido re " 
                                                + "join SASHAILO.Recorrido_Ciudades rc on rc.ID_RECORRIDO_CIUDADES = re.ID_RECORRIDO_CIUDADES "
                                                + "where re.ID_RECORRIDO=" + id_recorrido + "");
            if (consulta.Read())
            {
                int id_ciudad_o = consulta.GetInt32(0);
                int id_ciudad_d = consulta.GetInt32(1);
                decimal precio_base_kg = consulta.GetDecimal(2);
                decimal precio_base_pasaje = consulta.GetDecimal(3);
                int id_tipo_servicio = consulta.GetInt32(4);

                Funciones func = new Funciones();
                seleccionarEnCombo(origen, id_ciudad_o);
                seleccionarEnCombo(destino, id_ciudad_d);
                seleccionarEnCombo(tipo_servicio, id_tipo_servicio);

                base_kg.Text = precio_base_kg.ToString();
                base_pasaje.Text = precio_base_pasaje.ToString();
            }
            cn.desconectar();
        }

        public void seleccionarEnCombo(ComboBox combo, int value)
        {
            int items = combo.Items.Count;
            for (int i = 0; i < items; i++)
            {
                ComboboxItem item = (ComboboxItem)combo.Items[i];
                if (item.Value == value)
                {
                    combo.SelectedIndex = i;
                    return;
                }
            }

        }

        private void button1_Click(object sender, EventArgs e)
        {
            string str_error = "";
            if (((ComboboxItem)origen.SelectedItem) == null || ((ComboboxItem)destino.SelectedItem) == null)
                str_error = "Debe seleccionar las ciudades Origen y Destino.\n";
            if (((ComboboxItem)origen.SelectedItem) != null && ((ComboboxItem)destino.SelectedItem) != null && ((ComboboxItem)origen.SelectedItem).Value == ((ComboboxItem)destino.SelectedItem).Value)
                str_error = "Las Ciudades Origen y Destino no pueden ser la misma.\n";
            if (((ComboboxItem)tipo_servicio.SelectedItem) == null)
                str_error = str_error + "Debe seleccionar el Tipo de Servicio.\n";
            if (base_kg.Text.Trim().Equals("") || base_pasaje.Text.Trim().Equals(""))
                str_error = str_error + "Debe seleccionar los precios base (Pasaje y Kg).\n";
            if (yaExisteRecorrido())
                str_error = str_error + "Ya existe un recorrido como el ingresado.\n";

            if (!str_error.Equals(""))
            {
                MessageBox.Show(str_error, "Error", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                return;
            }

            Conexion conn = new Conexion();
            SqlCommand sp_recorrido_modif;

            sp_recorrido_modif = new SqlCommand("SASHAILO.sp_modif_recorrido", conn.miConexion); // Lo inicializo
            sp_recorrido_modif.CommandType = CommandType.StoredProcedure; // Defino que tipo de comando es
            SqlParameter ID_RECORRIDO = sp_recorrido_modif.Parameters.Add("@p_id_recorrido", SqlDbType.BigInt);
            SqlParameter ID_CIUDAD_ORIGEN = sp_recorrido_modif.Parameters.Add("@p_id_ciudad_origen", SqlDbType.Int);
            SqlParameter ID_CIUDAD_DESTINO = sp_recorrido_modif.Parameters.Add("@p_id_ciudad_destino", SqlDbType.Int);
            SqlParameter PRECIO_KG = sp_recorrido_modif.Parameters.Add("@p_base_kg", SqlDbType.Decimal);
            SqlParameter PRECIO_PASAJE = sp_recorrido_modif.Parameters.Add("@p_base_pasaje", SqlDbType.Decimal);
            SqlParameter ID_TIPO_SERVICIO = sp_recorrido_modif.Parameters.Add("@p_id_tipo_servicio", SqlDbType.Int);
            SqlParameter HAY_ERROR_USER = sp_recorrido_modif.Parameters.Add("@hayErr", SqlDbType.Int);
            SqlParameter ERRORES_USER = sp_recorrido_modif.Parameters.Add("@errores", SqlDbType.VarChar, 200);

            ID_RECORRIDO.Value = this.id_recorrido;
            ID_CIUDAD_ORIGEN.Value = ((ComboboxItem)origen.SelectedItem).Value;
            ID_CIUDAD_DESTINO.Value = ((ComboboxItem)destino.SelectedItem).Value;
            PRECIO_KG.Value = Convert.ToDecimal(base_kg.Text.Trim().Replace('.', ','));
            PRECIO_PASAJE.Value = Convert.ToDecimal(base_pasaje.Text.Trim().Replace('.', ','));
            ID_TIPO_SERVICIO.Value = ((ComboboxItem)tipo_servicio.SelectedItem).Value;
            HAY_ERROR_USER.Direction = ParameterDirection.Output;
            ERRORES_USER.Direction = ParameterDirection.Output;

            try
            {
                sp_recorrido_modif.ExecuteNonQuery();

                int hayError = Convert.ToInt16(sp_recorrido_modif.Parameters["@hayErr"].Value.ToString());
                if (hayError == 1)
                {
                    string errores = sp_recorrido_modif.Parameters["@errores"].Value.ToString();
                    MessageBox.Show("Error: \n" + errores, null, MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                    conn.desconectar();
                    return;
                }
                MessageBox.Show("El recorrido ha sido modificado", "", MessageBoxButtons.OK);
            }
            catch (Exception error)
            {
                MessageBox.Show("Error en la modificación del recorrido. Error: " + error.ToString(), null, MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                conn.desconectar();
                return;
            }

            Modif_Recorrido.ActiveForm.Close();

        }

        private void base_pasaje_KeyPress(object sender, KeyPressEventArgs e)
        {
            Funciones func = new Funciones();
            func.soloNumerosPuntosyComas(e);
        }

        private Boolean yaExisteRecorrido(){

            if (((ComboboxItem)origen.SelectedItem) == null || ((ComboboxItem)destino.SelectedItem) == null || ((ComboboxItem)tipo_servicio.SelectedItem) == null)
                return false;
            
            int id_c_o = ((ComboboxItem)origen.SelectedItem).Value;
            int id_c_d = ((ComboboxItem)destino.SelectedItem).Value;
            int id_t_s = ((ComboboxItem)tipo_servicio.SelectedItem).Value;

            Conexion cn = new Conexion();

            SqlDataReader consulta = cn.consultar("SELECT 1 FROM SASHAILO.Recorrido re "
                                                + "JOIN SASHAILO.Recorrido_Ciudades rc on rc.ID_RECORRIDO_CIUDADES = re.ID_RECORRIDO_CIUDADES "
                                                + "where rc.ID_CIUDAD_ORIGEN=" + id_c_o + " and rc.ID_CIUDAD_DESTINO=" + id_c_d + " and re.ID_TIPO_SERVICIO=" + id_t_s + " and re.ID_RECORRIDO<>" + this.id_recorrido + "");
            if (consulta.Read())
            {
                cn.desconectar();
                return true;
            }
            cn.desconectar();
            return false;
        }

        private void base_kg_KeyPress(object sender, KeyPressEventArgs e)
        {
            Funciones func = new Funciones();
            func.soloNumerosPuntosyComas(e);
        }
    }
}
