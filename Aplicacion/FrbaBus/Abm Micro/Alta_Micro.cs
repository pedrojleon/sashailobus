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
    public partial class Alta_Micro : Form
    {
        int cantidad_butacas = 0;

        public Alta_Micro()
        {
            InitializeComponent();
            setearFechaActual();
            llenarComboTipoServicio(combo_servicio);
            llenarComboMarca();

        }

        private void setearFechaActual(){
            DateTime ahora = DateTime.Now;
            string f_actual = ConfigurationSettings.AppSettings["fechaActual"];
            label_f_actual.Text = f_actual;
        }

        private void llenarComboPisos(ComboBox cb){

            ComboboxItem item = new ComboboxItem();
            item.Text = "1";
            item.Value = 1;
            ComboboxItem item2 = new ComboboxItem();
            item2.Text = "2";
            item2.Value = 2;

            cb.Items.Add(item);
            cb.Items.Add(item2);
 
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

        private void llenarComboTipoButaca(ComboBox cb)
        {

            Conexion cn = new Conexion();

            SqlDataReader consulta = cn.consultar("SELECT ID_TIPO_BUTACA, DESCRIPCION FROM SASHAILO.Tipo_Butaca order by 2");
            while (consulta.Read())
            {
                int id = consulta.GetInt32(0);
                string desc = consulta.GetString(1);

                ComboboxItem item = new ComboboxItem();
                item.Text = desc;
                item.Value = id;

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

        public class Butaca
        {
            public int Numero { get; set; }
            public int Tipo { get; set; }
            public int Piso { get; set; }

            public override string ToString()
            {
                return "Nro: " + Numero.ToString() + " Tipo: " + Tipo.ToString() + " Piso: " + Piso.ToString();
            }

        }

        private void cant_kg_KeyPress(object sender, KeyPressEventArgs e)
        {
            Funciones func = new Funciones();
            func.soloNumeros(e);
        }

        private void cant_v_2_KeyPress(object sender, KeyPressEventArgs e)
        {
            Funciones func = new Funciones();
            func.soloNumeros(e);
        }

        private void cant_p_2_KeyPress(object sender, KeyPressEventArgs e)
        {
            Funciones func = new Funciones();
            func.soloNumeros(e);
        }

        private void cant_v_1_KeyPress(object sender, KeyPressEventArgs e)
        {
            Funciones func = new Funciones();
            func.soloNumeros(e);
        }

        private void cant_p_1_KeyPress(object sender, KeyPressEventArgs e)
        {
            Funciones func = new Funciones();
            func.soloNumeros(e);
        }

        private void nro_butaca_KeyPress(object sender, KeyPressEventArgs e)
        {
            Funciones func = new Funciones();
            func.soloNumeros(e);
        }

        private void button1_Click(object sender, EventArgs e)
        {
            //TODO VALIDACIONES
            string str_errores = "";
            if (!validarPatente())
                str_errores = "La patente debe tener el formato ABC-123\n";
            if (patenteDuplicada())
                str_errores = "La patente ingresada ya existe en el sistema\n";
            if (((ComboboxItem)combo_marca.SelectedItem) == null)
                str_errores = str_errores + "Debe seleccionar una marca\n";
            if(modelo.Text.Trim().Equals(""))
                str_errores = str_errores + "Debe ingresar un modelo\n";
            if (((ComboboxItem)combo_servicio.SelectedItem) == null)
                str_errores = str_errores + "Debe seleccionar un tipo de servicio\n";
            if (cant_kg.Text.Trim().Equals(""))
                str_errores = str_errores + "Debe ingresar la cantidad de kg\n";
            if (getButacas().Count == 0)
                str_errores = str_errores + "Debe agregar alguna butaca\n";
            if (!validarButacas())
                str_errores = str_errores + "Las butacas tienen campos incompletos. Por favor verifique.\n";
            if (butacasRepetidas())
                str_errores = str_errores + "Hay números de butacas repetidos.\n";

            if (!str_errores.Equals(""))
            {
                MessageBox.Show(str_errores, "Error", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                return;
            }

            /************   grabo el micro ***************/

            Conexion conn = new Conexion();
            SqlCommand sp_alta;
            int id_micro_generado;

            sp_alta = new SqlCommand("SASHAILO.alta_micro", conn.miConexion); // Lo inicializo
            sp_alta.CommandType = CommandType.StoredProcedure; // Defino que tipo de comando es
            SqlParameter PATENTE = sp_alta.Parameters.Add("@p_patente", SqlDbType.VarChar, 7);
            SqlParameter ID_MARCA = sp_alta.Parameters.Add("@p_id_marca", SqlDbType.Int);
            SqlParameter MODELO = sp_alta.Parameters.Add("@p_modelo", SqlDbType.VarChar, 25);
            SqlParameter ID_TIPO_SERVICIO = sp_alta.Parameters.Add("@p_id_tipo_servicio", SqlDbType.Int);
            SqlParameter M_FUERA_SERVICIO = sp_alta.Parameters.Add("@p_m_fuera_servicio", SqlDbType.Char, 1);
            SqlParameter CANT_KG = sp_alta.Parameters.Add("@p_cant_kg", SqlDbType.Int);
            SqlParameter CANT_BUTACAS = sp_alta.Parameters.Add("@p_cant_butacas", SqlDbType.Int);
            SqlParameter F_ALTA = sp_alta.Parameters.Add("@p_f_alta", SqlDbType.DateTime);
            SqlParameter ID_MICRO_GEN = sp_alta.Parameters.Add("@id_micro_generado", SqlDbType.Int);
            SqlParameter HAY_ERROR_USER = sp_alta.Parameters.Add("@hayErr", SqlDbType.Int);
            SqlParameter ERRORES_USER = sp_alta.Parameters.Add("@errores", SqlDbType.VarChar, 200);

            PATENTE.Value = patente.Text.Trim().ToUpper();
            ID_MARCA.Value = ((ComboboxItem)combo_marca.SelectedItem).Value;
            MODELO.Value = modelo.Text.Trim();
            ID_TIPO_SERVICIO.Value = ((ComboboxItem)combo_servicio.SelectedItem).Value;
            M_FUERA_SERVICIO.Value = (fuera_servicio.Checked) ? 'S' : 'N';
            CANT_KG.Value = cant_kg.Text.Trim();
            CANT_BUTACAS.Value = getButacas().Count;
            F_ALTA.Value = Convert.ToDateTime(ConfigurationSettings.AppSettings["fechaActual"]);
            ID_MICRO_GEN.Direction = ParameterDirection.Output;
            HAY_ERROR_USER.Direction = ParameterDirection.Output;
            ERRORES_USER.Direction = ParameterDirection.Output;

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
                id_micro_generado = Convert.ToInt32(sp_alta.Parameters["@id_micro_generado"].Value.ToString());
                label_nro_micro.Text = id_micro_generado.ToString();

                //MessageBox.Show("El micro ha sido dado de alta", null, MessageBoxButtons.OK);
                conn.desconectar();
            }
            catch (Exception error)
            {
                MessageBox.Show("Error en la creación del micro. Error: " + error.ToString(), null, MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                conn.desconectar();
                return;
            }


            /************   grabo las butacas ***************/
            List<Butaca> lista = getButacas();
            foreach (Butaca butaca in lista)
            {
                grabarButaca(id_micro_generado, butaca.Numero, butaca.Tipo, butaca.Piso);
            }

            b_guardar.Enabled = false;
            MessageBox.Show("El micro ha sido dado de alta", "", MessageBoxButtons.OK);

        }

        private void grabarButaca(int id_micro, int nro_butaca, int id_tipo, int nro_piso) {

            Conexion conn = new Conexion();
            SqlCommand sp_alta;

            sp_alta = new SqlCommand("SASHAILO.alta_butaca", conn.miConexion); // Lo inicializo
            sp_alta.CommandType = CommandType.StoredProcedure; // Defino que tipo de comando es
            SqlParameter ID_MICRO = sp_alta.Parameters.Add("@p_id_micro", SqlDbType.Int);
            SqlParameter NRO_BUTACA = sp_alta.Parameters.Add("@p_nro_butaca", SqlDbType.Int);
            SqlParameter ID_TIPO = sp_alta.Parameters.Add("@p_id_tipo_butaca", SqlDbType.Int);
            SqlParameter NRO_PISO = sp_alta.Parameters.Add("@p_nro_piso", SqlDbType.SmallInt);
            SqlParameter HAY_ERROR_USER = sp_alta.Parameters.Add("@hayErr", SqlDbType.Int);
            SqlParameter ERRORES_USER = sp_alta.Parameters.Add("@errores", SqlDbType.VarChar, 200);

            ID_MICRO.Value = id_micro;
            NRO_BUTACA.Value = nro_butaca;
            ID_TIPO.Value = id_tipo;
            NRO_PISO.Value = nro_piso;
            HAY_ERROR_USER.Direction = ParameterDirection.Output;
            ERRORES_USER.Direction = ParameterDirection.Output;

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
                conn.desconectar();
            }
            catch (Exception error)
            {
                MessageBox.Show("Error en la creación de unas de las butacas. Error: " + error.ToString(), null, MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                conn.desconectar();
                return;
            }
        }

        private Boolean validarPatente() {
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
            SqlDataReader consulta = cn.consultar("select 1 from SASHAILO.Micro where PATENTE='"+patente.Text.Trim().ToUpper()+"'");
            if(consulta.Read())
            {
                cn.desconectar();
                return true;
            }
            cn.desconectar();
            return false;
        }

        private Boolean validarButacas()
        {
            int nro_butaca = -1;
            int id_tipo_butaca = -1;

            foreach (Control ctrl in boxButacas.Controls)
            {

                if (ctrl is TextBox)
                {
                    if (((TextBox)ctrl).Text.Trim().Equals(""))
                        nro_butaca = -1;
                    else
                        nro_butaca = 1;
                }
                else if (ctrl is ComboBox)
                {
                    ComboBox cb = (ComboBox)ctrl;
                    string id = cb.Name;

                    if (id.Contains("tipo_butaca_"))
                    {
                        if (((ComboboxItem)cb.SelectedItem) == null)
                            id_tipo_butaca = -1;
                        else
                            id_tipo_butaca = 1;
                    }
                    else
                    {
                        int id_piso;
                        if (((ComboboxItem)cb.SelectedItem) == null)
                            id_piso = -1;
                        else
                            id_piso = 1;

                        if (id_piso == 1 || nro_butaca == 1 || id_tipo_butaca == 1)
                        {
                            if (id_piso == -1 || nro_butaca == -1 || id_tipo_butaca == -1)
                            {
                                return false;
                            }
                        }
                        

                    }
                }

            }

            return true;
        }

        private Boolean butacasRepetidas()
        {
            int[] nros_butacas = new int[200];
            for (int i = 0; i < 200; i++ ){
                nros_butacas[i] = -1;
            }
            int nro_butaca;
            Boolean rtado = false;
            int c = 0;

            foreach (Control ctrl in boxButacas.Controls)
            {

                if (ctrl is TextBox)
                {
                    nro_butaca = Convert.ToInt32(((TextBox)ctrl).Text.Trim());
                    if (nros_butacas.Contains(nro_butaca))
                        rtado = true;
                    else
                    {
                        nros_butacas[c] = nro_butaca;
                        c++;
                    }
                }
            }

            return rtado;
        }

        private List<Butaca> getButacas()
        {
            List<Butaca> listaButacas = new List<Butaca>();

            int nro_butaca = -1;
            int id_tipo_butaca = -1;

            foreach (Control ctrl in boxButacas.Controls)
            {

                if (ctrl is TextBox)
                {
                    if (((TextBox)ctrl).Text.Trim().Equals(""))
                        nro_butaca = -1;
                    else
                        nro_butaca = Convert.ToInt32(((TextBox)ctrl).Text.Trim());
                }
                else if (ctrl is ComboBox)
                {
                    ComboBox cb = (ComboBox)ctrl;
                    string id = cb.Name;

                    if (id.Contains("tipo_butaca_"))
                    {
                        if (((ComboboxItem)cb.SelectedItem) == null)
                            id_tipo_butaca = -1;
                        else
                            id_tipo_butaca = ((ComboboxItem)cb.SelectedItem).Value;
                    }
                    else {
                        
                        int id_piso;
                        if (((ComboboxItem)cb.SelectedItem) == null)
                            id_piso = -1;
                        else
                            id_piso = ((ComboboxItem)cb.SelectedItem).Value;

                        Butaca butaca = new Butaca();
                        butaca.Numero = nro_butaca;
                        butaca.Tipo = id_tipo_butaca;
                        butaca.Piso = id_piso;
                        if (nro_butaca != -1 && id_tipo_butaca != -1 && id_piso != -1)
                            listaButacas.Add(butaca);

                    }
                }

            }

            return listaButacas;
        }

        private void pictureBox1_Click(object sender, EventArgs e)
        {
            this.cantidad_butacas = this.cantidad_butacas + 1;

            Label lbl = new Label();
            lbl.Text = "Nro Butaca:";
            TextBox nro_butaca = new TextBox();
            nro_butaca.Name = "butaca_" + this.cantidad_butacas.ToString();
            nro_butaca.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.nro_butaca_KeyPress);

            Label lbl2 = new Label();
            lbl2.Text = "Tipo:";
            ComboBox cb = new ComboBox();
            cb.Name = "tipo_butaca_" + this.cantidad_butacas.ToString();
            llenarComboTipoButaca(cb);

            Label lbl3 = new Label();
            lbl3.Text = "Piso:";
            ComboBox cb2 = new ComboBox();
            cb2.Name = "piso_" + this.cantidad_butacas.ToString();
            llenarComboPisos(cb2);


            lbl.Width = 70;
            nro_butaca.Width = 40;
            lbl2.Width = 37;
            cb.Width = 90;
            lbl3.Width = 37;
            cb2.Width = 30;

            lbl.Margin = new Padding(10, 10, 0, 0);
            nro_butaca.Margin = new Padding(0, 8, 0, 0);
            lbl2.Margin = new Padding(15, 10, 0, 0);
            cb.Margin = new Padding(0, 8, 0, 0);
            lbl3.Margin = new Padding(15, 10, 0, 0);
            cb2.Margin = new Padding(0, 8, 0, 0);

            //btn.Name = btn.Text = string.Format("Button{0}", i + 1);

            //flowLayoutPanel1.Controls.Add(btn);
            boxButacas.Controls.Add(lbl);
            boxButacas.Controls.Add(nro_butaca);
            boxButacas.Controls.Add(lbl2);
            boxButacas.Controls.Add(cb);
            boxButacas.Controls.Add(lbl3);
            boxButacas.Controls.Add(cb2);
        }
    }
}
