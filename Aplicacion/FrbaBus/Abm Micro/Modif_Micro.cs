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
            SqlDataReader consulta = cn.consultar("select PATENTE, ID_MARCA, MODELO, ID_TIPO_SERVICIO, F_ALTA, CANT_KG " +
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

                patente.Text = v_patente.Trim();
                modelo.Text = v_modelo.Trim();
                label_f_actual.Text = f_alta.Trim();
                cant_kg.Text = v_cant_kg.ToString().Trim();
                seleccionarEnCombo(combo_marca, id_marca);
                seleccionarEnCombo(combo_servicio, id_tipo_servicio);

                evaluarFechasEstadoMicro(this.id_micro);

            }
            cn.desconectar();

        }

        public void evaluarFechasEstadoMicro(int id_micro)
        {

            Conexion cn = new Conexion();
            SqlDataReader consulta = cn.consultar("select top 1 ID_LOG, ID_ESTADO, FECHA_F_SERVICIO, FECHA_REINICIO, FECHA_BAJA_DEF " +
                                                  "from SASHAILO.Log_Estado_Micro " +
                                                  "WHERE ID_MICRO = " + this.id_micro +
                                                  " order by 1 desc");
            while (consulta.Read())
            {
                int id_estado = consulta.GetInt32(1);
                DateTime v_f_f_servicio;
                Boolean null_f_f_servicio = true;
                DateTime v_f_reinicio_servicio;
                Boolean null_f_reinicio_servicio = true;
                DateTime v_f_baja_def;
                Boolean null_f_baja_def = true;
                if (!consulta.IsDBNull(2)){
                    null_f_f_servicio = false;
                }
                if (!consulta.IsDBNull(3)){
                    null_f_reinicio_servicio = false;
                }
                if (!consulta.IsDBNull(4)){
                    null_f_baja_def = false;
                }

                if (!null_f_f_servicio) {
                    v_f_f_servicio = consulta.GetDateTime(2);
                    fuera_servicio.Checked = true;
                    label_fs_1.Visible = true;
                    label_fs_2.Visible = true;
                    f_fuera_servicio.Visible = true;
                    f_reinicio_servicio.Visible = true;
                    f_fuera_servicio.Value = v_f_f_servicio.Date;
                    f_reinicio_servicio.Value = v_f_f_servicio;
                }
                if (!null_f_reinicio_servicio)
                {
                    v_f_reinicio_servicio = consulta.GetDateTime(3);
                    f_reinicio_servicio.Value = v_f_reinicio_servicio.Date;
                }
                if (!null_f_baja_def)
                {
                    v_f_baja_def = consulta.GetDateTime(4);
                    baja_definitiva.Checked = true;
                    label_bd.Visible = true;
                    f_baja_def.Visible = true;
                    f_baja_def.Value = v_f_baja_def.Date;
                }

                if (id_estado == 1) {
                    label_estado_actual.Text = "Operativo";
                    label_estado_actual.ForeColor=System.Drawing.Color.Green;
                }
                if (id_estado == 2)
                {
                    label_estado_actual.Text = "Fuera de Servicio";
                    label_estado_actual.ForeColor = System.Drawing.Color.Red;
                }
                if (id_estado == 3)
                {
                    label_estado_actual.Text = "Dado de baja";
                    label_estado_actual.ForeColor = System.Drawing.Color.Blue;
                }

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
            string error_fechas = "";
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
            if (fuera_servicio.Checked){
                error_fechas = fechasFueraServicioValidas();
                str_errores = str_errores + error_fechas;
            }
            if (baja_definitiva.Checked){
                error_fechas = fechaBajaDefinitivaValida();
                str_errores = str_errores + error_fechas;
            }
            if (!str_errores.Equals(""))
            {
                MessageBox.Show(str_errores, "Error", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                return;
            }

            //no confirma el popup
            if ((baja_definitiva.Checked || fuera_servicio.Checked) && !evaluarMicroFServicio())
                return;

            Conexion conn = new Conexion();
            SqlCommand sp_modif;
            Funciones func = new Funciones();

            string msj = "";

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
                F_FUERA_SERVICIO.Value = f_fuera_servicio.Value.Date;
                F_REINICIO_SERVICIO.Value = f_reinicio_servicio.Value.Date;
            }else{
                F_FUERA_SERVICIO.Value = DBNull.Value;
                F_REINICIO_SERVICIO.Value = DBNull.Value;
            }
            M_BAJA_DEFINITIVA.Value = (baja_definitiva.Checked) ? 'S' : 'N';
            if (baja_definitiva.Checked){
                F_BAJA_DEFINITIVA.Value = f_baja_def.Value.Date;
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

                conn.desconectar();
            }
            catch (Exception error)
            {
                MessageBox.Show("Error en la modificacion del micro. Error: " + error.ToString(), null, MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                conn.desconectar();
                return;
            }


            if (!fuera_servicio.Checked && !baja_definitiva.Checked)
            {
                MessageBox.Show("Los datos del Micro han sido modificados", null, MessageBoxButtons.OK);
                Modif_Micro.ActiveForm.Close();
                return;
            }

            //cancelacion de viajes, pasajes y encomiendas
            Conexion conn2 = new Conexion();
            SqlCommand sp_modif2;

            sp_modif2 = new SqlCommand("SASHAILO.mic_fs_reemplazar_cancelar", conn2.miConexion); // Lo inicializo
            sp_modif2.CommandType = CommandType.StoredProcedure; // Defino que tipo de comando es
            SqlParameter ID_MICRO2 = sp_modif2.Parameters.Add("@p_id_micro", SqlDbType.Int);
            SqlParameter F_ACTUAL = sp_modif2.Parameters.Add("@p_f_actual", SqlDbType.DateTime);
            SqlParameter F_DESDE = sp_modif2.Parameters.Add("@p_f_desde", SqlDbType.DateTime);
            SqlParameter F_HASTA = sp_modif2.Parameters.Add("@p_f_hasta", SqlDbType.DateTime);
            SqlParameter VIAJES_CAN = sp_modif2.Parameters.Add("@viajesCancelados", SqlDbType.Int);
            SqlParameter PASAJES_CAN = sp_modif2.Parameters.Add("@pasajesCancelados", SqlDbType.Int);
            SqlParameter ENCO_CAN = sp_modif2.Parameters.Add("@encoCanceladas", SqlDbType.Int);

            ID_MICRO2.Value = this.id_micro;
            F_ACTUAL.Value = func.getFechaActual();
            if (fuera_servicio.Checked)
            {
                F_DESDE.Value = f_fuera_servicio.Value.Date;
                F_HASTA.Value = f_reinicio_servicio.Value.Date;
            }
            else if (baja_definitiva.Checked)
            {
                F_DESDE.Value = f_baja_def.Value.Date;
                F_HASTA.Value = Convert.ToDateTime("20/12/2100");
            }
            VIAJES_CAN.Direction = ParameterDirection.Output;
            PASAJES_CAN.Direction = ParameterDirection.Output;
            ENCO_CAN.Direction = ParameterDirection.Output;

            try
            {
                sp_modif2.ExecuteNonQuery();

                int viajesCan = Convert.ToInt16(sp_modif2.Parameters["@viajesCancelados"].Value.ToString());
                int pasajesCan = Convert.ToInt16(sp_modif2.Parameters["@pasajesCancelados"].Value.ToString());
                int encoCan = Convert.ToInt16(sp_modif2.Parameters["@encoCanceladas"].Value.ToString());
                if (viajesCan > 0)
                {
                    msj = "Los datos del micro han sido modificados.\n";
                    msj = msj + "Cantidad de viajes cancelados: " + viajesCan + ".\n";
                    msj = msj + "Cantidad de pasajes cancelados: " + pasajesCan + ".\n";
                    msj = msj + "Cantidad de encomiendas canceladas: " + encoCan + ".\n";
                    MessageBox.Show(msj, null, MessageBoxButtons.OK, MessageBoxIcon.Information);
                }
                conn2.desconectar();
            }
            catch (Exception error)
            {
                conn2.desconectar();
                return;
            }

            Modif_Micro.ActiveForm.Close();

        }

        public bool evaluarMicroFServicio() {
            bool rtado = false;

            Conexion conn = new Conexion();
            SqlCommand sp_modif;
            Funciones func = new Funciones();

            sp_modif = new SqlCommand("SASHAILO.evalua_mic_f_de_servicio", conn.miConexion); // Lo inicializo
            sp_modif.CommandType = CommandType.StoredProcedure; // Defino que tipo de comando es
            SqlParameter ID_MICRO = sp_modif.Parameters.Add("@p_id_micro", SqlDbType.Int);
            SqlParameter F_DESDE = sp_modif.Parameters.Add("@p_f_desde", SqlDbType.DateTime);
            SqlParameter F_HASTA = sp_modif.Parameters.Add("@p_f_hasta", SqlDbType.DateTime);
            SqlParameter TODOS_SE_REEMPLAZAN = sp_modif.Parameters.Add("@todosSeReemplazan", SqlDbType.Int);
            SqlParameter CANT_VIAJES = sp_modif.Parameters.Add("@cantViajes", SqlDbType.Int);
            SqlParameter CANT_SIN_MICRO = sp_modif.Parameters.Add("@cantViajesSinMicro", SqlDbType.Int);

            ID_MICRO.Value = this.id_micro;

            if (fuera_servicio.Checked)
            {
                F_DESDE.Value = f_fuera_servicio.Value.Date;
                F_HASTA.Value = f_reinicio_servicio.Value.Date;
            }
            else if (baja_definitiva.Checked)
            {
                F_DESDE.Value = f_baja_def.Value.Date;
                F_HASTA.Value = Convert.ToDateTime("20/12/2100");
            }
            TODOS_SE_REEMPLAZAN.Direction = ParameterDirection.Output;
            CANT_VIAJES.Direction = ParameterDirection.Output;
            CANT_SIN_MICRO.Direction = ParameterDirection.Output;

            try
            {
                sp_modif.ExecuteNonQuery();
                int todosSeReemplazan = Convert.ToInt16(sp_modif.Parameters["@todosSeReemplazan"].Value.ToString());
                int cantViajes = Convert.ToInt16(sp_modif.Parameters["@cantViajes"].Value.ToString());
                int cantViajesSinMicro = Convert.ToInt16(sp_modif.Parameters["@cantViajesSinMicro"].Value.ToString());

                if(todosSeReemplazan == 1)
                    return true;
                string palabraViaje = (cantViajes == 1) ? "viaje" : "viajes";
                string palabraProgram = (cantViajes == 1) ? "programado" : "programados";
                string mensaje = "El micro tiene "+cantViajes+" "+palabraViaje+" "+palabraProgram+" entre las fechas que va a estar fuera de servicio.\n";
                mensaje = mensaje + "La cantidad de viajes a los que no se les encontró un Micro suplente es: " + cantViajesSinMicro + ".\n";
                mensaje = mensaje + "¿Desea continuar y cancelar los pasajes respectivos?\n";
                DialogResult dialogResult = MessageBox.Show(mensaje, "Atención", MessageBoxButtons.YesNo);
                if (dialogResult == DialogResult.Yes)
                {
                    return true;
                }
                else if (dialogResult == DialogResult.No)
                {
                    return false;
                }

                conn.desconectar();
            }
            catch (Exception error)
            {
                conn.desconectar();
            }

            return rtado;
        
        }

        private string fechasFueraServicioValidas()
        {
            string rtado = "";
            DateTime f_actual = Convert.ToDateTime(ConfigurationSettings.AppSettings["fechaActual"]);
            DateTime f_fuera = f_fuera_servicio.Value.Date;
            DateTime f_reinicio = f_reinicio_servicio.Value.Date;

            if (f_fuera < f_actual)
                rtado = "La fecha de fuera de servicio no puede ser previa a la actual\n";
            if (f_reinicio <= f_fuera)
                rtado = "La fecha de reinicio de servicio no puede ser previa o igual a la de fuera de servicio\n";

            return rtado;
        }

        private string fechaBajaDefinitivaValida()
        {
            string rtado = "";
            DateTime f_actual = Convert.ToDateTime(ConfigurationSettings.AppSettings["fechaActual"]);
            DateTime f_baja = f_baja_def.Value.Date;

            if (f_baja < f_actual)
                rtado = "La fecha de baja definitiva no puede ser previa a la actual\n";

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

        private void fuera_servicio_CheckedChanged(object sender, EventArgs e)
        {
            if (fuera_servicio.Checked)
            {
                //deschequeo la baja definitiva
                baja_definitiva.Checked = false;
                f_baja_def.Visible = false;
                label_bd.Visible = false;
                //muestro los controles de fuera de servicio
                label_fs_1.Visible = true;
                label_fs_2.Visible = true;
                f_fuera_servicio.Visible = true;
                f_reinicio_servicio.Visible = true;
            }
            else {
                //oculto los controles de fuera de servicio
                label_fs_1.Visible = false;
                label_fs_2.Visible = false;
                f_fuera_servicio.Visible = false;
                f_reinicio_servicio.Visible = false;
            }
        }

        private void baja_definitiva_CheckedChanged(object sender, EventArgs e)
        {
            if (baja_definitiva.Checked)
            {
                //deschequeo la fuera de servicio
                fuera_servicio.Checked = false;
                f_fuera_servicio.Visible = false;
                f_reinicio_servicio.Visible = false;
                label_fs_1.Visible = false;
                label_fs_2.Visible = false;
                //muestro los controles de fuera de servicio
                label_bd.Visible = true;
                f_baja_def.Visible = true;
            }
            else
            {
                //oculto los controles de fuera de servicio
                label_bd.Visible = false;
                f_baja_def.Visible = false;
            }
        }

    }
}
