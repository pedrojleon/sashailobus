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
    public partial class Nuevo_Pasaje : Form
    {

        public Compra_Pasaje.Viaje viaje;
        public Butaca butaca;
        public Cliente cliente;
        public Pasaje pasaje;
        public bool yaExisteDiscapacitado;

        public Nuevo_Pasaje(Compra_Pasaje.Viaje viaje, bool hay_discapacitado)
        {
            this.viaje = viaje;
            this.pasaje = null;
            this.yaExisteDiscapacitado = hay_discapacitado;
            InitializeComponent();
            cargarCombosSexo();
            listado_butacas.ColumnHeadersDefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter;
            cargarTablaButacas();
        }

        public class Butaca
        {
            public int id_butaca { get; set; }
            public int nro_butaca { get; set; }
            public int piso_butaca { get; set; }
            public String tipo_butaca { get; set; }

            public override string ToString()
            {
                return "Número: " + nro_butaca + "   -   Tipo: " + tipo_butaca + "   -   Piso: " + piso_butaca;
            }

        }

        public class Cliente
        {
            public int id_cliente { get; set; }
            public String nombre { get; set; }
            public String apellido { get; set; }
            public String sexo { get; set; }
            public int dni { get; set; }
            public String direccion { get; set; }
            public decimal telefono { get; set; }
            public String email { get; set; }
            public DateTime f_nacimiento { get; set; }

            public override string ToString()
            {
                return nombre + " " + apellido;
            }

        }

        public class Pasaje
        {
            public Compra_Pasaje.Viaje viaje { get; set; }
            public Cliente cliente { get; set; }
            public Butaca butaca { get; set; }
            public int id_provisorio { get; set; }
            public Boolean pas_discapacitado { get; set; }
            public decimal precio { get; set; }
            public int id_pasaje_gen { get; set; }

            public override string ToString()
            {
                return "PASAJE";
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

        private void cargarCombosSexo()
        {

            int c_sexo_m = 0;
            string d_sexo_m = "M";
            int c_sexo_f = 1;
            string d_sexo_f = "F";

            ComboboxItem item_m = new ComboboxItem();
            item_m.Text = d_sexo_m;
            item_m.Value = c_sexo_m;
            ComboboxItem item_f = new ComboboxItem();
            item_f.Text = d_sexo_f;
            item_f.Value = c_sexo_f;

            combo_sexo.Items.Add(item_m);
            combo_sexo.Items.Add(item_f);

        }

        public void cargarTablaButacas() {

            Conexion conn = new Conexion();
            SqlCommand sp_listado = new SqlCommand("SASHAILO.get_butacas_disponibles", conn.miConexion); // Lo inicializo
            sp_listado.CommandType = CommandType.StoredProcedure; // Defino que tipo de comando es
            SqlParameter ID_VIAJE = sp_listado.Parameters.Add("@p_id_viaje", SqlDbType.Int);
            SqlParameter ID_MICRO = sp_listado.Parameters.Add("@p_id_micro", SqlDbType.Int);

            ID_VIAJE.Value = this.viaje.id_viaje;
            ID_MICRO.Value = this.viaje.id_micro;
           
            listado_butacas.Rows.Clear();
            listado_butacas.Columns["Micro"].DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter;
            listado_butacas.Columns["Numero"].DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter;
            listado_butacas.Columns["Tipo"].DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter;
            listado_butacas.Columns["Piso"].DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter;

            try
            {
                SqlDataReader DR = sp_listado.ExecuteReader();
                int i = 0;

                while (DR.Read())
                {
                    listado_butacas.Rows.Add();

                    listado_butacas.Rows[i].Cells["id_butaca"].Value = DR[0].ToString();
                    listado_butacas.Rows[i].Cells["Micro"].Value = DR[5].ToString();
                    listado_butacas.Rows[i].Cells["Numero"].Value = DR[1].ToString();
                    listado_butacas.Rows[i].Cells["Tipo"].Value = DR[3].ToString();
                    listado_butacas.Rows[i].Cells["Piso"].Value = DR[4].ToString();

                    DataGridViewImageCell iconColumn = (DataGridViewImageCell)listado_butacas.Rows[i].Cells["acciones"];
                    iconColumn.Value = FrbaBus.Properties.Resources.accept_ico;
                    iconColumn.ToolTipText = "Seleccionar Butaca";

                   // listado_butacas.Rows[i].Height = 17;

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

        private void listado_butacas_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {

            if (this.butaca != null)
            {
                MessageBox.Show("Ya existe una butaca seleccionada. Para seleccionar otra debe borrar la selección actual", "Error", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                return;
            }

            if (e.ColumnIndex == 5)
            {
                Int32 id_butaca = Convert.ToInt32(listado_butacas.Rows[e.RowIndex].Cells["id_butaca"].Value.ToString());
                StringBuilder sb = new StringBuilder();
                sb.Append("SELECT bu.ID_BUTACA, bu.NRO_BUTACA, tb.DESCRIPCION, bu.NRO_PISO ");
                sb.Append("FROM SASHAILO.Butaca bu ");
                sb.Append("JOIN SASHAILO.Tipo_Butaca tb on tb.ID_TIPO_BUTACA = bu.ID_TIPO_BUTACA ");
                sb.Append("WHERE bu.ID_BUTACA = " + id_butaca);
                Conexion cn = new Conexion();
                SqlDataReader consulta = cn.consultar(sb.ToString());
                if (consulta.Read())
                {
                    int nro = consulta.GetInt32(1);
                    String tipo = consulta.GetString(2);
                    int piso = consulta.GetInt16(3);
                   
                    Butaca bu = new Butaca();
                    bu.id_butaca = id_butaca;
                    bu.nro_butaca = nro;
                    bu.tipo_butaca = tipo;
                    bu.piso_butaca = piso;

                    this.butaca = bu;
                    label_butaca.Text = this.butaca.ToString();
                    icono_cruz.Visible = true;

                }
                cn.desconectar();
            }
        }

        private void icono_cruz_Click(object sender, EventArgs e)
        {
            this.butaca = null;
            label_butaca.Text = "";
            icono_cruz.Visible = false;
            cargarTablaButacas();
        }

        private void dni_KeyPress(object sender, KeyPressEventArgs e)
        {
            Funciones func = new Funciones();
            func.soloNumeros(e);
        }

        private void telefono_KeyPress(object sender, KeyPressEventArgs e)
        {
            Funciones func = new Funciones();
            func.soloNumeros(e);
        }

        private void dni_Leave(object sender, EventArgs e)
        {
            if (dni.Text.Trim().Equals(""))
                return;

            int n_doc = Convert.ToInt32(dni.Text.Trim());
            StringBuilder sb = new StringBuilder();
            sb.Append("SELECT ID_CLIENTE, SEXO, NOMBRE, APELLIDO, DNI, DIRECCION, TELEFONO, MAIL, F_NACIMIENTO ");
            sb.Append("FROM SASHAILO.Cliente cli ");
            sb.Append("WHERE cli.DNI = " + n_doc);
            Conexion cn = new Conexion();
            SqlDataReader consulta = cn.consultar(sb.ToString());

            if (consulta.Read()) //existe el cliente ingresado
            {
                int v_id_cliente = consulta.GetInt32(0);
                String v_sexo = (consulta.IsDBNull(1)) ? null : consulta.GetString(1);
                String v_nombre = consulta.GetString(2);
                String v_apellido = consulta.GetString(3);
                String v_direccion = (consulta.IsDBNull(5)) ? null : consulta.GetString(5);
                decimal v_telefono = (consulta.IsDBNull(6)) ? -1 : consulta.GetDecimal(6);
                String v_mail = (consulta.IsDBNull(7)) ? null : consulta.GetString(7);
                DateTime v_f_nac = consulta.GetDateTime(8);

                Cliente cli = new Cliente();
                cli.id_cliente = v_id_cliente;
                cli.email = v_mail;
                cli.sexo = v_sexo;
                cli.nombre = v_nombre;
                cli.apellido = v_apellido;
                cli.direccion = v_direccion;
                cli.telefono = v_telefono;
                cli.f_nacimiento = v_f_nac;

                this.cliente = cli;

                //lleno datos en la pantalla
                nombre.Text = v_nombre;
                apellido.Text = v_apellido;
                email.Text = v_mail;
                direccion.Text = v_direccion;
                telefono.Text = (v_telefono == -1) ? "" : v_telefono.ToString();
                f_nac.Value = v_f_nac;
                if (v_sexo != null)
                {
                    if (v_sexo.Trim().Equals("M"))
                        seleccionarEnCombo(combo_sexo, 0);
                    else
                        seleccionarEnCombo(combo_sexo, 1);
                }
                else
                    combo_sexo.SelectedIndex = -1;

            }
            else { //no existe el cliente ingresado
                this.cliente = null;
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

        private void b_guardar_Click(object sender, EventArgs e)
        {
            String err = "";
            if (this.butaca == null)
                err = err + "Debe seleccionar una butaca \n";
            if (dni.Text.Trim().Equals(""))
                err = err + "Debe ingresar el DNI del pasajero \n";
            if(nombre.Text.Trim().Equals(""))
                err = err + "Debe ingresar el nombre del pasajero \n";
            if (apellido.Text.Trim().Equals(""))
                err = err + "Debe ingresar el apellido del pasajero \n";
            if (((ComboboxItem)combo_sexo.SelectedItem) == null)
                err = err + "Debe seleccionar el sexo del pasajero \n";
            if (fechaNacimientoMayorActual())
                err = err + "La fecha de nacimiento no puede ser posterior a la fecha actual \n";
            if (discapacidad.Checked && this.yaExisteDiscapacitado)
                err = err + "Ya se ha ingresado un pasajero con discapacidad. Solo puede haber uno por compra. \n";

            String err_cliente = evaluaClienteEnViaje();
            err = (err_cliente.Trim().Equals("")) ? err : err + err_cliente + " \n";

            if (!err.Equals(""))
            {
                MessageBox.Show(err, "Error", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                return;
            }

            int id_cliente_generado = grabaCliente();
            int id_pasaje_provisorio = guardaButacaProvisoria(this.butaca.id_butaca, id_cliente_generado, this.viaje.id_viaje);

            Pasaje pas = new Pasaje();
            pas.viaje = this.viaje;
            pas.cliente = this.cliente;
            pas.butaca = this.butaca;
            pas.id_provisorio = id_pasaje_provisorio;
            pas.pas_discapacitado = discapacidad.Checked;

            this.pasaje = pas;

            Nuevo_Pasaje.ActiveForm.Close();

        }

        public String evaluaClienteEnViaje() {

            if (this.cliente == null)
                return "";

            int id_cliente = this.cliente.id_cliente;
            int id_viaje = this.viaje.id_viaje;

            Conexion conn = new Conexion();
            SqlCommand sp_evalua;
            String errores = "";

            sp_evalua = new SqlCommand("SASHAILO.sp_evalua_cliente_en_viaje", conn.miConexion); // Lo inicializo
            sp_evalua.CommandType = CommandType.StoredProcedure; // Defino que tipo de comando es
            SqlParameter ID_CLIENTE = sp_evalua.Parameters.Add("@p_id_cliente", SqlDbType.Int);
            SqlParameter ID_VIAJE = sp_evalua.Parameters.Add("@p_id_viaje", SqlDbType.Int);
            SqlParameter HAY_ERROR_USER = sp_evalua.Parameters.Add("@hayError", SqlDbType.Int);
            SqlParameter ERRORES_USER = sp_evalua.Parameters.Add("@errores", SqlDbType.VarChar, 255);

            ID_CLIENTE.Value = id_cliente;
            ID_VIAJE.Value = id_viaje;
            HAY_ERROR_USER.Direction = ParameterDirection.Output;
            ERRORES_USER.Direction = ParameterDirection.Output;

            try
            {
                sp_evalua.ExecuteNonQuery();
                int hayError = Convert.ToInt16(sp_evalua.Parameters["@hayError"].Value.ToString());
                if (hayError == 1)
                {
                    errores = sp_evalua.Parameters["@errores"].Value.ToString();
                }
            }catch (Exception error){}

            conn.desconectar();

            return errores;

        }

        public int grabaCliente() {

            Conexion conn = new Conexion();
            SqlCommand sp_alta;
            int id_cliente_generado;

            sp_alta = new SqlCommand("SASHAILO.sp_cliente_am", conn.miConexion); // Lo inicializo
            sp_alta.CommandType = CommandType.StoredProcedure; // Defino que tipo de comando es
            SqlParameter ID_CLIENTE = sp_alta.Parameters.Add("@p_id_cliente", SqlDbType.Int);
            SqlParameter NOMBRE = sp_alta.Parameters.Add("@p_nombre", SqlDbType.VarChar, 255);
            SqlParameter APELLIDO = sp_alta.Parameters.Add("@p_apellido", SqlDbType.VarChar, 255);
            SqlParameter DNI = sp_alta.Parameters.Add("@p_dni", SqlDbType.BigInt);
            SqlParameter DIRECCION = sp_alta.Parameters.Add("@p_direccion", SqlDbType.VarChar, 255);
            SqlParameter TELEFONO = sp_alta.Parameters.Add("@p_telefono", SqlDbType.BigInt);
            SqlParameter MAIL = sp_alta.Parameters.Add("@p_mail", SqlDbType.VarChar, 255);
            SqlParameter F_NACIMIENTO = sp_alta.Parameters.Add("@p_f_nacimiento", SqlDbType.DateTime);
            SqlParameter SEXO = sp_alta.Parameters.Add("@p_sexo", SqlDbType.Char, 1);
            SqlParameter ID_CLIENTE_GEN = sp_alta.Parameters.Add("@p_id_cliente_gen", SqlDbType.Int);
            SqlParameter HAY_ERROR_USER = sp_alta.Parameters.Add("@hayErr", SqlDbType.Int);
            SqlParameter ERRORES_USER = sp_alta.Parameters.Add("@errores", SqlDbType.VarChar, 200);

            if (this.cliente == null)
                ID_CLIENTE.Value = DBNull.Value;
            else
                ID_CLIENTE.Value = this.cliente.id_cliente;

            NOMBRE.Value = nombre.Text.Trim();
            APELLIDO.Value = apellido.Text.Trim();

            if(dni.Text.Trim().Equals(""))
                DNI.Value = DBNull.Value;
            else
                DNI.Value = dni.Text.Trim();

            if (direccion.Text.Trim().Equals(""))
                DIRECCION.Value = DBNull.Value;
            else
                DIRECCION.Value = direccion.Text.Trim();

            if (telefono.Text.Trim().Equals(""))
                TELEFONO.Value = DBNull.Value;
            else
                TELEFONO.Value = telefono.Text.Trim();

            if (email.Text.Trim().Equals(""))
                MAIL.Value = DBNull.Value;
            else
                MAIL.Value = email.Text.Trim();

            F_NACIMIENTO.Value = getFechaNacimiento();
            if (((ComboboxItem)combo_sexo.SelectedItem).Value == 0)
                SEXO.Value = "M";
            else
                SEXO.Value = "F";

            ID_CLIENTE_GEN.Direction = ParameterDirection.Output;
            HAY_ERROR_USER.Direction = ParameterDirection.Output;
            ERRORES_USER.Direction = ParameterDirection.Output;

            try
            {
                sp_alta.ExecuteNonQuery();

                id_cliente_generado = Convert.ToInt32(sp_alta.Parameters["@p_id_cliente_gen"].Value.ToString());
                int hayError = Convert.ToInt16(sp_alta.Parameters["@hayErr"].Value.ToString());
                if (hayError == 1)
                {
                    string errores = sp_alta.Parameters["@errores"].Value.ToString();
                    conn.desconectar();
                    return -1;
                }
            }
            catch (Exception error)
            {
                conn.desconectar();
                return -1;
            }
            conn.desconectar();

            //me guardo el objeto cliente
            Cliente cli = new Cliente();
            cli.id_cliente = id_cliente_generado;
            cli.email = email.Text.Trim();
            cli.sexo = (((ComboboxItem)combo_sexo.SelectedItem).Value == 0) ? "M" : "F";
            cli.nombre = nombre.Text.Trim();
            cli.dni = Convert.ToInt32(dni.Text.Trim());
            cli.apellido = apellido.Text.Trim();
            cli.direccion = direccion.Text.Trim();
            if (!telefono.Text.Trim().Equals(""))
                cli.telefono = Convert.ToDecimal(telefono.Text.Trim());
            else
                cli.telefono = -1;
            cli.f_nacimiento = getFechaNacimiento();
            this.cliente = cli;

            return id_cliente_generado;
        
        }

        public int guardaButacaProvisoria(int butaca, int cliente, int viaje)
        {

            Conexion conn = new Conexion();
            SqlCommand sp_alta;
            int id_generado = -1;

            sp_alta = new SqlCommand("SASHAILO.sp_alta_butaca_provisoria", conn.miConexion); // Lo inicializo
            sp_alta.CommandType = CommandType.StoredProcedure; // Defino que tipo de comando es
            SqlParameter ID_VIAJE = sp_alta.Parameters.Add("@p_id_viaje", SqlDbType.Int);
            SqlParameter ID_BUTACA = sp_alta.Parameters.Add("@p_id_butaca", SqlDbType.Int);
            SqlParameter ID_CLIENTE = sp_alta.Parameters.Add("@p_id_cliente", SqlDbType.Int);
            SqlParameter ID_GENERADO = sp_alta.Parameters.Add("@p_id_generado", SqlDbType.Int);

            ID_VIAJE.Value = viaje;
            ID_BUTACA.Value = butaca;
            ID_CLIENTE.Value = cliente;
            ID_GENERADO.Direction = ParameterDirection.Output;

            try
            {
                sp_alta.ExecuteNonQuery();
                id_generado = Convert.ToInt32(sp_alta.Parameters["@p_id_generado"].Value.ToString());
            }
            catch (Exception error)
            {
                conn.desconectar();
            }
            conn.desconectar();

            return id_generado;

        }

        public DateTime getFechaNacimiento()
        {

            DateTime fechaNacimiento = f_nac.Value;

            fechaNacimiento = fechaNacimiento.AddHours(-fechaNacimiento.Hour);
            fechaNacimiento = fechaNacimiento.AddMinutes(-fechaNacimiento.Minute);
            fechaNacimiento = fechaNacimiento.AddSeconds(-fechaNacimiento.Second);
            fechaNacimiento = fechaNacimiento.AddMilliseconds(-fechaNacimiento.Millisecond);

            return fechaNacimiento;

        }

        public Boolean fechaNacimientoMayorActual()
        {

            DateTime fecha_actual = Convert.ToDateTime(ConfigurationSettings.AppSettings["fechaActual"]);

            DateTime v_f_nac = f_nac.Value;
            v_f_nac = v_f_nac.AddHours(-v_f_nac.Hour);
            v_f_nac = v_f_nac.AddMinutes(-v_f_nac.Minute);
            v_f_nac = v_f_nac.AddSeconds(-v_f_nac.Second);
            v_f_nac = v_f_nac.AddMilliseconds(-v_f_nac.Millisecond);

            if (v_f_nac >= fecha_actual)
                return true;

            return false;

        }
    }
}