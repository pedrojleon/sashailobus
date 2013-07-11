using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using FrbaBus.GenerarViaje;
using System.Configuration;
using System.Data.SqlClient;

namespace FrbaBus.GenerarViaje
{
    public partial class Generar_Viaje : Form
    {

        public Seleccionar_Recorrido.Recorrido recorrido;
        public Seleccionar_Micro.Micro micro;
        public DateTime fecha_actual;

        public Generar_Viaje()
        {
            InitializeComponent();

            h_salida.Format = DateTimePickerFormat.Time;
            h_salida.ShowUpDown = true;
            h_llegada_estim.Format = DateTimePickerFormat.Time;
            h_llegada_estim.ShowUpDown = true;

        }

        private void icono_mas_MouseHover(object sender, EventArgs e)
        {
            ToolTip tt = new ToolTip();
            tt.SetToolTip(this.icono_mas, "Seleccionar Recorrido");
        }

        private void icono_mas_Click(object sender, EventArgs e)
        {
            Seleccionar_Recorrido selec_reco = new Seleccionar_Recorrido();
            selec_reco.Tag = this; //guardo en Tag una referencia a mi formulario
            selec_reco.ShowDialog();

            Seleccionar_Recorrido.Recorrido reco = selec_reco.recorrido;

            if (reco != null)
            {
                this.recorrido = reco;
                label_recorrido.Text = reco.ToString();
                icono_mas.Visible = false;
                icono_cruz.Visible = true;
            }

        }

        private void icono_cruz_MouseHover(object sender, EventArgs e)
        {
            ToolTip tt = new ToolTip();
            tt.SetToolTip(this.icono_cruz, "Eliminar Selección de Recorrido");
        }

        private void icono_cruz_Click(object sender, EventArgs e)
        {
            icono_mas.Visible = true;
            icono_cruz.Visible = false;
            label_recorrido.Text = "";
            this.recorrido = null;

            icono_mas_micro.Visible = true;
            icono_cruz_micro.Visible = false;
            patente.Text = "-";
            marca.Text = "-";
            modelo.Text = "-";
            servicio.Text = "-";
            cant_butacas.Text = "-";
            cant_kg.Text = "-";
            this.micro = null;

            //habilito las fechas
            f_salida.Enabled = true;
            h_salida.Enabled = true;
            f_llegada_estim.Enabled = true;
            h_llegada_estim.Enabled = true;

        }

        private void icono_mas_micro_MouseHover(object sender, EventArgs e)
        {
            ToolTip tt = new ToolTip();
            tt.SetToolTip(this.icono_mas_micro, "Seleccionar Micro");
        }

        private void icono_mas_micro_Click(object sender, EventArgs e)
        {
            String str_error = "";
            if (this.recorrido == null)
                str_error += "Debe seleccionar un recorrido\n";
            if (fechaSalidaMenorActual())
                str_error += "La fecha de salida no puede ser previa a la actual y en caso de ser la misma, debe tener una hora de diferencia\n";
            if (fechaLLegadaEstimMenorFechaSalida())
                str_error += "La fecha de llegada estimada no puede ser previa a la fecha de salida\n";
            if (fechaLLegadaEstimMayor24hs())
                str_error += "El tiempo estimado de viaje no puede ser mayor a 24 hs\n";

            if (!str_error.Equals(""))
            {
                MessageBox.Show(str_error, "Error", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                return;
            }

            DateTime v_f_salida = getFechaSalida();
            DateTime v_f_llegada_estim = getFechaLlegadaEstimada();

            Seleccionar_Micro selec_micro = new Seleccionar_Micro(this.recorrido.id_tipo_servicio, v_f_salida, v_f_llegada_estim);

            selec_micro.Tag = this; //guardo en Tag una referencia a mi formulario
            selec_micro.ShowDialog();

            Seleccionar_Micro.Micro micro = selec_micro.micro;

            if (micro != null)
            {
                this.micro = micro;
                patente.Text = micro.patente;
                marca.Text = micro.marca;
                modelo.Text = micro.modelo;
                servicio.Text = micro.servicio;
                cant_butacas.Text = micro.cant_butacas.ToString();
                cant_kg.Text = micro.cant_kg.ToString();

                icono_mas_micro.Visible = false;
                icono_cruz_micro.Visible = true;

                //deshabilito el cambio de fechas
                f_salida.Enabled = false;
                h_salida.Enabled = false;
                f_llegada_estim.Enabled = false;
                h_llegada_estim.Enabled = false;

            }

        }

        public DateTime getFechaSalida() {
            
            DateTime v_f_salida = f_salida.Value;
            v_f_salida = v_f_salida.AddHours(-v_f_salida.Hour);
            v_f_salida = v_f_salida.AddMinutes(-v_f_salida.Minute);
            v_f_salida = v_f_salida.AddSeconds(-v_f_salida.Second);
            v_f_salida = v_f_salida.AddMilliseconds(-v_f_salida.Millisecond);
            DateTime v_h_salida = h_salida.Value;
            int hora_salida = v_h_salida.Hour;
            int minutos_salida = v_h_salida.Minute;
            v_f_salida = v_f_salida.AddHours(hora_salida);
            v_f_salida = v_f_salida.AddMinutes(minutos_salida);

            return v_f_salida;

        }

        public DateTime getFechaLlegadaEstimada()
        {

            DateTime v_f_llegada_estim = f_llegada_estim.Value;
            v_f_llegada_estim = v_f_llegada_estim.AddHours(-v_f_llegada_estim.Hour);
            v_f_llegada_estim = v_f_llegada_estim.AddMinutes(-v_f_llegada_estim.Minute);
            v_f_llegada_estim = v_f_llegada_estim.AddSeconds(-v_f_llegada_estim.Second);
            v_f_llegada_estim = v_f_llegada_estim.AddMilliseconds(-v_f_llegada_estim.Millisecond);
            DateTime v_h_llegada_estim = h_llegada_estim.Value;
            int hora_llegada_estim = v_h_llegada_estim.Hour;
            int minutos_llegada_estim = v_h_llegada_estim.Minute;
            v_f_llegada_estim = v_f_llegada_estim.AddHours(hora_llegada_estim);
            v_f_llegada_estim = v_f_llegada_estim.AddMinutes(minutos_llegada_estim);

            return v_f_llegada_estim;

        }

        public Boolean fechaSalidaMenorActual() {

            //le sumo 1 para que programen viajes posteriores a una hora. Es decir, si
            //son las 18hs no puedo programar un viaje para las 18hs
            this.fecha_actual = Convert.ToDateTime(ConfigurationSettings.AppSettings["fechaActual"]);
            this.fecha_actual = this.fecha_actual.AddHours(DateTime.Now.Hour);
            this.fecha_actual = this.fecha_actual.AddHours(1);
            this.fecha_actual = this.fecha_actual.AddMinutes(DateTime.Now.Minute);

            DateTime v_f_salida = f_salida.Value;
            v_f_salida = v_f_salida.AddHours(-v_f_salida.Hour);
            v_f_salida = v_f_salida.AddMinutes(-v_f_salida.Minute);
            v_f_salida = v_f_salida.AddSeconds(-v_f_salida.Second);
            v_f_salida = v_f_salida.AddMilliseconds(-v_f_salida.Millisecond);
            DateTime v_h_salida = h_salida.Value;
            int hora_salida = v_h_salida.Hour;
            int minutos_salida = v_h_salida.Minute;
            v_f_salida = v_f_salida.AddHours(hora_salida);
            v_f_salida = v_f_salida.AddMinutes(minutos_salida);

            if (v_f_salida < this.fecha_actual)
                return true;

            return false;
        
        }

        public Boolean fechaLLegadaEstimMenorFechaSalida()
        {

            DateTime v_f_salida = f_salida.Value;
            v_f_salida = v_f_salida.AddHours(-v_f_salida.Hour);
            v_f_salida = v_f_salida.AddMinutes(-v_f_salida.Minute);
            v_f_salida = v_f_salida.AddSeconds(-v_f_salida.Second);
            v_f_salida = v_f_salida.AddMilliseconds(-v_f_salida.Millisecond);
            DateTime v_h_salida = h_salida.Value;
            int hora_salida = v_h_salida.Hour;
            int minutos_salida = v_h_salida.Minute;
            v_f_salida = v_f_salida.AddHours(hora_salida);
            v_f_salida = v_f_salida.AddMinutes(minutos_salida);

            DateTime v_f_llegada_estim = f_llegada_estim.Value;
            v_f_llegada_estim = v_f_llegada_estim.AddHours(-v_f_llegada_estim.Hour);
            v_f_llegada_estim = v_f_llegada_estim.AddMinutes(-v_f_llegada_estim.Minute);
            v_f_llegada_estim = v_f_llegada_estim.AddSeconds(-v_f_llegada_estim.Second);
            v_f_llegada_estim = v_f_llegada_estim.AddMilliseconds(-v_f_llegada_estim.Millisecond);
            DateTime v_h_llegada_estim = h_llegada_estim.Value;
            int hora_llegada_estim = v_h_llegada_estim.Hour;
            int minutos_llegada_estim = v_h_llegada_estim.Minute;
            v_f_llegada_estim = v_f_llegada_estim.AddHours(hora_llegada_estim);
            v_f_llegada_estim = v_f_llegada_estim.AddMinutes(minutos_llegada_estim);

            if (v_f_llegada_estim <= v_f_salida)
                return true;

            return false;

        }

        public Boolean fechaLLegadaEstimMayor24hs()
        {

            DateTime v_f_salida = f_salida.Value;
            v_f_salida = v_f_salida.AddHours(-v_f_salida.Hour);
            v_f_salida = v_f_salida.AddMinutes(-v_f_salida.Minute);
            v_f_salida = v_f_salida.AddSeconds(-v_f_salida.Second);
            v_f_salida = v_f_salida.AddMilliseconds(-v_f_salida.Millisecond);
            DateTime v_h_salida = h_salida.Value;
            int hora_salida = v_h_salida.Hour;
            int minutos_salida = v_h_salida.Minute;
            v_f_salida = v_f_salida.AddHours(hora_salida);
            v_f_salida = v_f_salida.AddMinutes(minutos_salida);

            v_f_salida = v_f_salida.AddHours(24);

            DateTime v_f_llegada_estim = f_llegada_estim.Value;
            v_f_llegada_estim = v_f_llegada_estim.AddHours(-v_f_llegada_estim.Hour);
            v_f_llegada_estim = v_f_llegada_estim.AddMinutes(-v_f_llegada_estim.Minute);
            v_f_llegada_estim = v_f_llegada_estim.AddSeconds(-v_f_llegada_estim.Second);
            v_f_llegada_estim = v_f_llegada_estim.AddMilliseconds(-v_f_llegada_estim.Millisecond);
            DateTime v_h_llegada_estim = h_llegada_estim.Value;
            int hora_llegada_estim = v_h_llegada_estim.Hour;
            int minutos_llegada_estim = v_h_llegada_estim.Minute;
            v_f_llegada_estim = v_f_llegada_estim.AddHours(hora_llegada_estim);
            v_f_llegada_estim = v_f_llegada_estim.AddMinutes(minutos_llegada_estim);

            if (v_f_llegada_estim >= v_f_salida)
                return true;

            return false;

        }

        private void icono_cruz_micro_MouseHover(object sender, EventArgs e)
        {
            ToolTip tt = new ToolTip();
            tt.SetToolTip(this.icono_cruz_micro, "Eliminar Selección de Micro");
        }

        private void icono_cruz_micro_Click(object sender, EventArgs e)
        {
            icono_mas_micro.Visible = true;
            icono_cruz_micro.Visible = false;
            patente.Text = "-";
            marca.Text = "-";
            modelo.Text = "-";
            servicio.Text = "-";
            cant_butacas.Text = "-";
            cant_kg.Text = "-";
            this.micro = null;

            //habilito las fechas
            f_salida.Enabled = true;
            h_salida.Enabled = true;
            f_llegada_estim.Enabled = true;
            h_llegada_estim.Enabled = true;
        }

        private void b_guardar_Click(object sender, EventArgs e)
        {
            String str_error = "";
            if (this.recorrido == null || this.micro == null)
                str_error += "Debe seleccionar un Recorrido, las Fechas del Viaje, y un Micro\n";

            if (!str_error.Equals(""))
            {
                MessageBox.Show(str_error, "Error", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                return;
            }

            DateTime v_f_salida = getFechaSalida();
            DateTime v_f_llegada_estim = getFechaLlegadaEstimada();

            Conexion conn = new Conexion();
            SqlCommand sp_alta;

            sp_alta = new SqlCommand("SASHAILO.sp_alta_viaje", conn.miConexion); // Lo inicializo
            sp_alta.CommandType = CommandType.StoredProcedure; // Defino que tipo de comando es
            SqlParameter ID_RECORRIDO = sp_alta.Parameters.Add("@p_id_recorrido", SqlDbType.BigInt);
            SqlParameter ID_MICRO = sp_alta.Parameters.Add("@p_id_micro", SqlDbType.Int);
            SqlParameter F_SALIDA = sp_alta.Parameters.Add("@p_f_salida", SqlDbType.DateTime);
            SqlParameter F_LLEGADA_ESTIM = sp_alta.Parameters.Add("@p_f_llegada_estim", SqlDbType.DateTime);
            SqlParameter F_LLEGADA = sp_alta.Parameters.Add("@p_f_llegada", SqlDbType.DateTime);
            SqlParameter HAY_ERROR = sp_alta.Parameters.Add("@hayErr", SqlDbType.Int);
            SqlParameter ERRORES = sp_alta.Parameters.Add("@errores", SqlDbType.VarChar, 200);

            ID_RECORRIDO.Value = this.recorrido.id;
            ID_MICRO.Value = this.micro.id;
            F_SALIDA.Value = v_f_salida;
            F_LLEGADA_ESTIM.Value = v_f_llegada_estim;
            F_LLEGADA.Value = DBNull.Value;
            HAY_ERROR.Direction = ParameterDirection.Output;
            ERRORES.Direction = ParameterDirection.Output;

            try
            {
                sp_alta.ExecuteNonQuery();

                int hayError = Convert.ToInt16(sp_alta.Parameters["@hayErr"].Value.ToString());
                if (hayError == 1)
                {
                    string errores = sp_alta.Parameters["@errores"].Value.ToString();
                    MessageBox.Show("Error: \n" + errores, null, MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                    conn.desconectar();
                    return;
                }
                MessageBox.Show("El Viaje ha sido dado de alta", "", MessageBoxButtons.OK);
            }
            catch (Exception error)
            {
                MessageBox.Show("Error en la creación del viaje. Error: " + error.ToString(), null, MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                conn.desconectar();
                return;
            }

            Generar_Viaje.ActiveForm.Close();

        }

    }
}
