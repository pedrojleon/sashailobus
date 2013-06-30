using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using System.Data.SqlClient;
using System.Text.RegularExpressions;
using System.Configuration;

namespace FrbaBus.Abm_Micro
{
    public partial class Modif_Micro : Form
    {

        int id_micro;

        public Modif_Micro()
        {
            InitializeComponent();
        }

        public void cargarDatos(int id_micro) {

            this.id_micro = id_micro;
            label_nro_micro.Text = id_micro.ToString();
            llenarComboTipoServicio(combo_servicio);
            llenarComboMarca();

            Conexion cn = new Conexion();
            SqlDataReader consulta = cn.consultar("select PATENTE, ID_MARCA, MODELO, ID_TIPO_SERVICIO, F_ALTA, CANT_KG, " +
                                                         "CASE SASHAILO.F_GET_ESTADO_MICRO(" + this.id_micro + ") WHEN 2 THEN 'S' ELSE 'N' END FUERA_DE_SERVICIO, " +
                                                         "CASE SASHAILO.F_GET_ESTADO_MICRO(" + this.id_micro + ") WHEN 2 THEN (select top 1 FECHA_REINICIO from SASHAILO.Log_Estado_Micro where id_micro = " + this.id_micro + " order by id_log desc) " +
										                                                     "ELSE NULL END F_REINICIO_SERVICIO, " +
                                                         "CASE SASHAILO.F_GET_ESTADO_MICRO(" + this.id_micro + ") WHEN 3 THEN 'S' ELSE 'N' END FIN_VIDA_UTIL " +
                                                   "from SASHAILO.Micro " +
                                                   "WHERE ID_MICRO = " + this.id_micro);
            while (consulta.Read())
            {
                string v_patente = consulta.GetString(0);
                int id_marca = consulta.GetInt32(1);
                string v_modelo = consulta.GetString(2);
                int id_tipo_servicio = consulta.GetInt32(3);
                string f_alta = consulta.GetDateTime(4).ToString();
                f_alta = f_alta.Substring(0, 10);
                decimal v_cant_kg = consulta.GetDecimal(5);
                string m_fuera_servicio = consulta.GetString(6);
                string fin_vida_util = consulta.GetString(8);
                if (m_fuera_servicio.Equals("S")){
                    string f_reinicio = consulta.GetDateTime(7).ToString();
                    f_reinicio = f_reinicio.Substring(0, 10);
                    string[] arr_f_reinicio = f_reinicio.Split('/');
                    string d_f_reinicio = arr_f_reinicio[0];
                    string m_f_reinicio = arr_f_reinicio[1];
                    string a_f_reinicio = arr_f_reinicio[2];
                    d_f_r_servivio.Text = d_f_reinicio.Trim();
                    m_f_r_servivio.Text = m_f_reinicio.Trim();
                    a_f_r_servivio.Text = a_f_reinicio.Trim();
                }

                patente.Text = v_patente.Trim();
                modelo.Text = v_modelo.Trim();
                label_f_actual.Text = f_alta.Trim();
                cant_kg.Text = v_cant_kg.ToString().Trim();
                seleccionarEnCombo(combo_marca, id_marca);
                seleccionarEnCombo(combo_servicio, id_tipo_servicio);
                fuera_servicio.Checked = (m_fuera_servicio.Trim().Equals("S"));
                baja_definitiva.Checked = (fin_vida_util.Trim().Equals("S"));


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

        private void llenarComboTipoServicio(ComboBox cb)
        {

            Conexion cn = new Conexion();

            SqlDataReader consulta = cn.consultar("select ID_TIPO_SERVICIO, DESCRIPCION from SASHAILO.Tipo_Servicio order by 2");
            while (consulta.Read())
            {
                int id_tipo_servicio = consulta.GetInt32(0);
                string d_servicio = consulta.GetString(1);

                ComboboxItem item = new ComboboxItem();
                item.Text = d_servicio;
                item.Value = id_tipo_servicio;

                cb.Items.Add(item);

            }
            cn.desconectar();

        }

        private void llenarComboMarca()
        {

            Conexion cn = new Conexion();

            SqlDataReader consulta = cn.consultar("select ID_MARCA, DESCRIPCION from SASHAILO.Marca_Micro order by 2");
            while (consulta.Read())
            {
                int id = consulta.GetInt32(0);
                string descripcion = consulta.GetString(1);

                ComboboxItem item = new ComboboxItem();
                item.Text = descripcion;
                item.Value = id;

                combo_marca.Items.Add(item);

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

        private Boolean validarPatente()
        {
            string pat = patente.Text.Trim();
            string[] numeros = { "0", "1", "2", "3", "4", "5", "6", "7", "8", "9" };

            if (pat.Length != 7)
                return false;
            string value = pat;
            string pattern = @"\b\w{3}-\d{3}\b";
            if (!Regex.IsMatch(value, pattern))
                return false;
            if (numeros.Contains(pat.Substring(0, 1)) || numeros.Contains(pat.Substring(1, 1)) || numeros.Contains(pat.Substring(2, 1)))
                return false;

            return true;
        }

        private Boolean patenteDuplicada()
        {
            Conexion cn = new Conexion();
            SqlDataReader consulta = cn.consultar("select 1 from SASHAILO.Micro where PATENTE='" + patente.Text.Trim().ToUpper() + "' and ID_MICRO<>"+this.id_micro+"");
            if (consulta.Read())
            {
                cn.desconectar();
                return true;
            }
            cn.desconectar();
            return false;
        }

        private void b_guardar_Click(object sender, EventArgs e)
        {
            string str_errores = "";
            if (!validarPatente())
                str_errores = "La patente debe tener el formato ABC-123\n";
            if (patenteDuplicada())
                str_errores = "La patente ingresada ya existe en el sistema\n";
            if (((ComboboxItem)combo_marca.SelectedItem) == null)
                str_errores = str_errores + "Debe seleccionar una marca\n";
            if (modelo.Text.Trim().Equals(""))
                str_errores = str_errores + "Debe ingresar un modelo\n";
            if (((ComboboxItem)combo_servicio.SelectedItem) == null)
                str_errores = str_errores + "Debe seleccionar un tipo de servicio\n";
            if (cant_kg.Text.Trim().Equals(""))
                str_errores = str_errores + "Debe ingresar la cantidad de kg\n";
            if (fuera_servicio.Checked && !fechaReinicioServicioValida())
                str_errores = str_errores + "La fecha de reinicio de servivio no es válida\n";

            if (!str_errores.Equals(""))
            {
                MessageBox.Show(str_errores, "Error", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                return;
            }

            Conexion conn = new Conexion();
            SqlCommand sp_modif;
            Funciones func = new Funciones();

            sp_modif = new SqlCommand("SASHAILO.modif_micro", conn.miConexion); // Lo inicializo
            sp_modif.CommandType = CommandType.StoredProcedure; // Defino que tipo de comando es
            SqlParameter ID_MICRO = sp_modif.Parameters.Add("@p_id_micro", SqlDbType.Int);
            SqlParameter PATENTE = sp_modif.Parameters.Add("@p_patente", SqlDbType.VarChar, 7);
            SqlParameter ID_MARCA = sp_modif.Parameters.Add("@p_id_marca", SqlDbType.Int);
            SqlParameter MODELO = sp_modif.Parameters.Add("@p_modelo", SqlDbType.VarChar, 25);
            SqlParameter ID_TIPO_SERVICIO = sp_modif.Parameters.Add("@p_id_tipo_servicio", SqlDbType.Int);
            SqlParameter M_FUERA_SERVICIO = sp_modif.Parameters.Add("@p_m_fuera_servicio", SqlDbType.Char, 1);
            SqlParameter F_FUERA_SERVICIO = sp_modif.Parameters.Add("@p_f_fuera_servicio", SqlDbType.DateTime);
            SqlParameter FECHA = sp_modif.Parameters.Add("@p_fecha", SqlDbType.DateTime);
            SqlParameter F_REINICIO_SERVICIO = sp_modif.Parameters.Add("@p_f_reinicio_servicio", SqlDbType.DateTime);
            SqlParameter M_BAJA_DEFINITIVA = sp_modif.Parameters.Add("@p_m_baja_definitiva", SqlDbType.Char, 1);
            SqlParameter F_BAJA_DEFINITIVA = sp_modif.Parameters.Add("@p_f_baja_definitiva", SqlDbType.DateTime);
            SqlParameter CANT_KG = sp_modif.Parameters.Add("@p_cant_kg", SqlDbType.BigInt);
            SqlParameter HAY_ERROR_USER = sp_modif.Parameters.Add("@hayErr", SqlDbType.Int);
            SqlParameter ERRORES_USER = sp_modif.Parameters.Add("@errores", SqlDbType.VarChar, 200);

            ID_MICRO.Value = this.id_micro;
            PATENTE.Value = patente.Text.Trim().ToUpper();
            ID_MARCA.Value = ((ComboboxItem)combo_marca.SelectedItem).Value;
            MODELO.Value = modelo.Text.Trim();
            ID_TIPO_SERVICIO.Value = ((ComboboxItem)combo_servicio.SelectedItem).Value;
            M_FUERA_SERVICIO.Value = (fuera_servicio.Checked) ? 'S' : 'N';
            FECHA.Value = func.getFechaActual();
            if (fuera_servicio.Checked){
                F_FUERA_SERVICIO.Value = Convert.ToDateTime(ConfigurationSettings.AppSettings["fechaActual"]);
                F_REINICIO_SERVICIO.Value = Convert.ToDateTime(d_f_r_servivio.Text.Trim() + "/" + m_f_r_servivio.Text.Trim() + "/" + a_f_r_servivio.Text.Trim());
            }else{
                F_FUERA_SERVICIO.Value = DBNull.Value;
                F_REINICIO_SERVICIO.Value = DBNull.Value;
            }
            M_BAJA_DEFINITIVA.Value = (baja_definitiva.Checked) ? 'S' : 'N';
            if (baja_definitiva.Checked){
                F_BAJA_DEFINITIVA.Value = Convert.ToDateTime(ConfigurationSettings.AppSettings["fechaActual"]);
            }else{
                F_BAJA_DEFINITIVA.Value = DBNull.Value;
            }
            CANT_KG.Value = cant_kg.Text.Trim();
            HAY_ERROR_USER.Direction = ParameterDirection.Output;
            ERRORES_USER.Direction = ParameterDirection.Output;

            try
            {
                sp_modif.ExecuteNonQuery();

                int hayError = Convert.ToInt16(sp_modif.Parameters["@hayErr"].Value.ToString());
                if (hayError == 1)
                {
                    string errores = sp_modif.Parameters["@errores"].Value.ToString();
                    MessageBox.Show("Error: \n" + errores, null, MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                    conn.desconectar();
                    return;
                }
                
                MessageBox.Show("Los datos del Micro han sido modificados", null, MessageBoxButtons.OK);
                conn.desconectar();
            }
            catch (Exception error)
            {
                MessageBox.Show("Error en la creación del micro. Error: " + error.ToString(), null, MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                conn.desconectar();
                return;
            }

            Modif_Micro.ActiveForm.Close();

        }

        private Boolean fechaReinicioServicioValida() {
            Boolean rtado = true;

            if (d_f_r_servivio.Text.Trim().Length != 2 || d_f_r_servivio.Text.Trim().Length != 2 || a_f_r_servivio.Text.Trim().Length != 4)
                return false;

            int dia = Convert.ToInt32(d_f_r_servivio.Text.Trim());
            int mes = Convert.ToInt32(m_f_r_servivio.Text.Trim());
            int anio = Convert.ToInt32(a_f_r_servivio.Text.Trim());

            if (dia > 31 || mes > 12)
                return false;

            DateTime f_actual = Convert.ToDateTime(ConfigurationSettings.AppSettings["fechaActual"]);
            DateTime f_reinicio = Convert.ToDateTime(d_f_r_servivio.Text.Trim() + "/" + m_f_r_servivio.Text.Trim() + "/" + a_f_r_servivio.Text.Trim());
            if (f_reinicio <= f_actual)
                return false;

            return rtado;
        }

        private void d_f_f_servivio_KeyPress(object sender, KeyPressEventArgs e)
        {
            Funciones func = new Funciones();
            func.soloNumeros(e);
        }

        private void m_f_f_servivio_KeyPress(object sender, KeyPressEventArgs e)
        {
            Funciones func = new Funciones();
            func.soloNumeros(e);
        }

        private void a_f_f_servivio_KeyPress(object sender, KeyPressEventArgs e)
        {
            Funciones func = new Funciones();
            func.soloNumeros(e);
        }

        private void d_f_r_servivio_KeyPress(object sender, KeyPressEventArgs e)
        {
            Funciones func = new Funciones();
            func.soloNumeros(e);
        }

        private void m_f_r_servivio_KeyPress(object sender, KeyPressEventArgs e)
        {
            Funciones func = new Funciones();
            func.soloNumeros(e);
        }

        private void a_f_r_servivio_KeyPress(object sender, KeyPressEventArgs e)
        {
            Funciones func = new Funciones();
            func.soloNumeros(e);
        }

        private void d_f_b_definitiva_KeyPress(object sender, KeyPressEventArgs e)
        {
            Funciones func = new Funciones();
            func.soloNumeros(e);
        }

        private void m_f_b_definitiva_KeyPress(object sender, KeyPressEventArgs e)
        {
            Funciones func = new Funciones();
            func.soloNumeros(e);
        }

        private void a_f_b_definitiva_KeyPress(object sender, KeyPressEventArgs e)
        {
            Funciones func = new Funciones();
            func.soloNumeros(e);
        }

    }
}
