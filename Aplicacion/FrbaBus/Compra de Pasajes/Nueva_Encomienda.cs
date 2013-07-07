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
    public partial class Nueva_Encomienda : Form
    {
        public Compra_Pasaje.Viaje viaje;
        public Cliente cliente;
        public Encomienda encomienda;

        public Nueva_Encomienda(Compra_Pasaje.Viaje viaje)
        {
            this.viaje = viaje;
            InitializeComponent();
            cargarCombosSexo();
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

        public class Encomienda
        {
            public Compra_Pasaje.Viaje viaje { get; set; }
            public Cliente cliente { get; set; }
            public int cant_kg { get; set; }
            public int id_provisorio { get; set; }
            public int id_encomienda_gen { get; set; }
            public decimal precio { get; set; }

            public override string ToString()
            {
                return cant_kg.ToString() + " kg";
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

        private void telefono_KeyPress(object sender, KeyPressEventArgs e)
        {
            Funciones func = new Funciones();
            func.soloNumeros(e);
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

        private void cant_kg_KeyPress(object sender, KeyPressEventArgs e)
        {
            Funciones func = new Funciones();
            func.soloNumeros(e);
        }

        private void dni_KeyPress_1(object sender, KeyPressEventArgs e)
        {
            Funciones func = new Funciones();
            func.soloNumeros(e);
        }

        private void dni_Leave_1(object sender, EventArgs e)
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
            else
            { //no existe el cliente ingresado
                this.cliente = null;
            }
            cn.desconectar();
        }

        private void telefono_KeyPress_1(object sender, KeyPressEventArgs e)
        {
            Funciones func = new Funciones();
            func.soloNumeros(e);
        }

        private void b_guardar_Click(object sender, EventArgs e)
        {
            String err = "";
            if (cant_kg.Text.Trim().Equals(""))
                err = err + "Debe ingresar la cantidad de kilogramos \n";
            if (dni.Text.Trim().Equals(""))
                err = err + "Debe ingresar el DNI del pasajero \n";
            if (nombre.Text.Trim().Equals(""))
                err = err + "Debe ingresar el nombre del pasajero \n";
            if (apellido.Text.Trim().Equals(""))
                err = err + "Debe ingresar el apellido del pasajero \n";
            if (((ComboboxItem)combo_sexo.SelectedItem) == null)
                err = err + "Debe seleccionar el sexo del pasajero \n";
            if (fechaNacimientoMayorActual())
                err = err + "La fecha de nacimiento no puede ser posterior a la fecha actual \n";
            
            String exceso_kg = excesoKilos(cant_kg.Text.Trim());
            err = err + exceso_kg;

            if (!err.Equals(""))
            {
                MessageBox.Show(err, "Error", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                return;
            }

            int id_cliente_generado = grabaCliente();
            int id_encomienda_provisoria = guardaEncomiendaProvisoria(id_cliente_generado, this.viaje.id_viaje, Convert.ToInt32(cant_kg.Text.Trim()));

            Encomienda enco = new Encomienda();
            enco.viaje = this.viaje;
            enco.cliente = this.cliente;
            enco.cant_kg = Convert.ToInt32(cant_kg.Text.Trim());
            enco.id_provisorio = id_encomienda_provisoria;

            this.encomienda = enco;

            Nueva_Encomienda.ActiveForm.Close();

        }

        public String excesoKilos(string kilos) {

            String retorno = "";
            int cant_kg = Convert.ToInt32(kilos);
            int cant_kg_disp = 10000;

            Conexion conn = new Conexion();
            SqlCommand sp;

            sp = new SqlCommand("SASHAILO.sp_get_kg_disponibles_en_viaje", conn.miConexion); // Lo inicializo
            sp.CommandType = CommandType.StoredProcedure; // Defino que tipo de comando es
            SqlParameter ID_VIAJE = sp.Parameters.Add("@p_id_viaje", SqlDbType.Int);
            SqlParameter KG_DISP = sp.Parameters.Add("@p_kilos", SqlDbType.Int);

            ID_VIAJE.Value = this.viaje.id_viaje;
            KG_DISP.Direction = ParameterDirection.Output;

            try
            {
                sp.ExecuteNonQuery();
                cant_kg_disp = Convert.ToInt32(sp.Parameters["@p_kilos"].Value.ToString());
            }
            catch (Exception error)
            {
                conn.desconectar();
            }
            conn.desconectar();

            if (cant_kg > cant_kg_disp)
                retorno = "No es posible encomendar la cantidad de kilogramos ingresada\n";

            return retorno;
        
        }

        public int guardaEncomiendaProvisoria(int cliente, int viaje, int kg)
        {

            Conexion conn = new Conexion();
            SqlCommand sp_alta;
            int id_generado = -1;

            sp_alta = new SqlCommand("SASHAILO.sp_alta_encomienda_provisoria", conn.miConexion); // Lo inicializo
            sp_alta.CommandType = CommandType.StoredProcedure; // Defino que tipo de comando es
            SqlParameter ID_VIAJE = sp_alta.Parameters.Add("@p_id_viaje", SqlDbType.Int);
            SqlParameter ID_CLIENTE = sp_alta.Parameters.Add("@p_id_cliente", SqlDbType.Int);
            SqlParameter KILOS = sp_alta.Parameters.Add("@p_kilos", SqlDbType.Int);
            SqlParameter ID_GENERADO = sp_alta.Parameters.Add("@p_id_generado", SqlDbType.Int);

            ID_VIAJE.Value = viaje;
            ID_CLIENTE.Value = cliente;
            KILOS.Value = kg;
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

        public int grabaCliente()
        {

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

            if (dni.Text.Trim().Equals(""))
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

            F_NACIMIENTO.Value = f_nac.Value.Date;
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
            cli.f_nacimiento = f_nac.Value.Date;
            this.cliente = cli;

            return id_cliente_generado;

        }

        public Boolean fechaNacimientoMayorActual()
        {

            DateTime fecha_actual = Convert.ToDateTime(ConfigurationSettings.AppSettings["fechaActual"]);

            DateTime v_f_nac = f_nac.Value.Date;

            if (v_f_nac >= fecha_actual)
                return true;

            return false;

        }
    }
}
