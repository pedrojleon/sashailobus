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
    public partial class Finalizar_Compra : Form
    {
        public Compra_Pasaje.Viaje viaje;
        public List<Nuevo_Pasaje.Pasaje> lista_pasajes;
        public List<Nueva_Encomienda.Encomienda> lista_encomiendas;
        public Cliente cliente;
        public int cant_discap;
        public int cant_jubilados;
        public int cant_kg_totales;
        public decimal precio_pasaje;
        public decimal precio_por_kg;
        public decimal precio_total;

        public Finalizar_Compra(Compra_Pasaje.Viaje via, List<Nuevo_Pasaje.Pasaje> l_pasajes, List<Nueva_Encomienda.Encomienda> l_encomiendas)
        {
            this.viaje = via;
            this.lista_pasajes = l_pasajes;
            this.lista_encomiendas = l_encomiendas;
            this.cliente = null;
            InitializeComponent();
            cargarDetallesCompra();
            cargarCombosSexo();
            cargarComboTipoPago();
            cargarComboVto();
            setearPreciosALosPasajes();
            setearPreciosALasEncomiendas();
            label_p_total.Text = getPrecioTotal();
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

        public class ComboboxItemVto
        {
            public string Text { get; set; }
            public string Value { get; set; }

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

        private void cargarComboTipoPago()
        {

            int c_tipo_m = 1;
            string d_tipo_m = "Efectivo";
            int c_tipo_f = 2;
            string d_tipo_f = "Tarjeta de Crédito";

            ComboboxItem item_m = new ComboboxItem();
            item_m.Text = d_tipo_m;
            item_m.Value = c_tipo_m;
            ComboboxItem item_f = new ComboboxItem();
            item_f.Text = d_tipo_f;
            item_f.Value = c_tipo_f;

            c_tipo_pago.Items.Add(item_m);
            c_tipo_pago.Items.Add(item_f);

        }

        private void cargarComboVto()
        {

            string c_vto_1 = "0913";
            string d_vto_1 = "09/2013";
            string c_vto_2 = "1013";
            string d_vto_2 = "10/2013";
            string c_vto_3 = "1113";
            string d_vto_3 = "11/2013";
            string c_vto_4 = "1213";
            string d_vto_4 = "12/2013";


            ComboboxItemVto item_1 = new ComboboxItemVto();
            item_1.Text = d_vto_1;
            item_1.Value = c_vto_1;
            ComboboxItemVto item_2 = new ComboboxItemVto();
            item_2.Text = d_vto_2;
            item_2.Value = c_vto_2;
            ComboboxItemVto item_3 = new ComboboxItemVto();
            item_3.Text = d_vto_3;
            item_3.Value = c_vto_3;
            ComboboxItemVto item_4 = new ComboboxItemVto();
            item_4.Text = d_vto_4;
            item_4.Value = c_vto_4;

            combo_vto.Items.Add(item_1);
            combo_vto.Items.Add(item_2);
            combo_vto.Items.Add(item_3);
            combo_vto.Items.Add(item_4);

        }

        public void cargarDetallesCompra() {

            label_cant_pasajes.Text = this.lista_pasajes.Count.ToString();
            label_cant_encom.Text = this.lista_encomiendas.Count.ToString();
            label_cant_kg_totales.Text = getCantKgTotales();
            label_pas_discap.Text = getCantDiscap();
            label_cant_jubilados.Text = getCantJubilados();
            label_p_pasaje.Text = getPrecioPasaje();
            label_p_kg.Text = getPrecioPorKg();
        
        }

        public string getCantKgTotales() {
            int cant = 0;
            foreach (Nueva_Encomienda.Encomienda enco in this.lista_encomiendas)
            {
                cant = cant + enco.cant_kg;
            }
            this.cant_kg_totales = cant;
            return cant.ToString();
        }

        public string getCantDiscap()
        {
            int cant = 0;
            foreach (Nuevo_Pasaje.Pasaje pas in this.lista_pasajes)
            {
                if(pas.pas_discapacitado)
                    cant = cant + 1;
            }
            this.cant_discap = cant;
            return cant.ToString();
        }

        public void setearPreciosALosPasajes()
        {
            if (this.lista_pasajes.Count <= 2 && this.cant_discap > 0)
            {
                foreach (Nuevo_Pasaje.Pasaje pas in this.lista_pasajes)
                {
                    pas.precio = 0;
                }
                return;
            }

            if (this.lista_pasajes.Count > 0 && this.cant_discap == 0)
            {
                Funciones func = new Funciones();
                foreach (Nuevo_Pasaje.Pasaje pas in this.lista_pasajes)
                {
                    DateTime f_nac = pas.cliente.f_nacimiento.Date;
                    int edad = func.getEdad(f_nac);
                    string sexo = pas.cliente.sexo;
                    bool esJubilado = false;
                    if (sexo.Equals("M") && edad >= 65 && !pas.pas_discapacitado)
                        esJubilado = true;
                    if (sexo.Equals("F") && edad >= 60 && !pas.pas_discapacitado)
                        esJubilado = true;

                    pas.precio = (esJubilado) ? (this.precio_pasaje / 2) : this.precio_pasaje;

                }
                return;
            }

            if (this.lista_pasajes.Count > 2 && this.cant_discap > 0)
            {
                Funciones func = new Funciones();
                bool puso_uno_en_cero = false;
                bool ultimoPasaje = false;
                int cant_pasajes = this.lista_pasajes.Count;
                int c = 0;
                foreach (Nuevo_Pasaje.Pasaje pas in this.lista_pasajes)
                {
                    c++;
                    if(c == cant_pasajes){
                        ultimoPasaje = true;
                    }

                    DateTime f_nac = pas.cliente.f_nacimiento.Date;
                    int edad = func.getEdad(f_nac);
                    string sexo = pas.cliente.sexo;
                    bool esJubilado = false;
                    if (sexo.Equals("M") && edad >= 65 && !pas.pas_discapacitado)
                        esJubilado = true;
                    if (sexo.Equals("F") && edad >= 60 && !pas.pas_discapacitado)
                        esJubilado = true;

                    if (pas.pas_discapacitado)
                        pas.precio = 0;
                    else if (!puso_uno_en_cero && !esJubilado) {
                        pas.precio = 0;
                        puso_uno_en_cero = true;
                    }
                    else if (!puso_uno_en_cero && esJubilado && ultimoPasaje) {
                        pas.precio = 0;
                        puso_uno_en_cero = true;
                    }
                    else {
                        pas.precio = (esJubilado) ? (this.precio_pasaje / 2) : this.precio_pasaje;
                    }

                }
                return;
            }

        }

        public void setearPreciosALasEncomiendas()
        {
            foreach (Nueva_Encomienda.Encomienda enco in this.lista_encomiendas)
            {
                enco.precio = enco.cant_kg * this.precio_por_kg;
            }
        }

        public string getCantJubilados()
        {
            int cant = 0;
            Funciones func = new Funciones();
            foreach (Nuevo_Pasaje.Pasaje pas in this.lista_pasajes)
            {
                DateTime f_nac = pas.cliente.f_nacimiento.Date;
                int edad = func.getEdad(f_nac);
                string sexo = pas.cliente.sexo;
                if (sexo.Equals("M") && edad >= 65 && !pas.pas_discapacitado)
                    cant = cant + 1;
                if (sexo.Equals("F") && edad >= 60 && !pas.pas_discapacitado)
                    cant = cant + 1;
            }
            this.cant_jubilados = cant;
            return cant.ToString();
        }

        public string getPrecioPasaje()
        {
            decimal v_precio_base_pasaje = 0;
            decimal v_adicional = 0;

            StringBuilder sb = new StringBuilder();
            sb.Append("select rc.PRECIO_BASE_PASAJE ");
            sb.Append("from SASHAILO.Recorrido re join SASHAILO.Recorrido_Ciudades rc on rc.ID_RECORRIDO_CIUDADES = re.ID_RECORRIDO_CIUDADES ");
            sb.Append("where re.ID_RECORRIDO = " + this.viaje.id_recorrido);
            Conexion cn = new Conexion();
            SqlDataReader consulta = cn.consultar(sb.ToString());
            if (consulta.Read()){
                v_precio_base_pasaje = consulta.GetDecimal(0);

            }
            cn.desconectar();

            StringBuilder sb2 = new StringBuilder();
            sb2.Append("select ts.ADICIONAL ");
            sb2.Append("from SASHAILO.Micro mi join SASHAILO.Tipo_Servicio ts on ts.ID_TIPO_SERVICIO = mi.ID_TIPO_SERVICIO ");
            sb2.Append("where mi.ID_MICRO = " + this.viaje.id_micro);
            Conexion cn2 = new Conexion();
            SqlDataReader consulta2 = cn2.consultar(sb2.ToString());
            if (consulta2.Read())
            {
                v_adicional = consulta2.GetDecimal(0);

            }
            cn2.desconectar();

            decimal precio = v_precio_base_pasaje * v_adicional;
            this.precio_pasaje = precio;

            return "$" + precio.ToString();

        }

        public string getPrecioPorKg()
        {
            decimal v_precio_base_kg = 0;

            StringBuilder sb = new StringBuilder();
            sb.Append("select rc.PRECIO_BASE_KG ");
            sb.Append("from SASHAILO.Recorrido re join SASHAILO.Recorrido_Ciudades rc on rc.ID_RECORRIDO_CIUDADES = re.ID_RECORRIDO_CIUDADES ");
            sb.Append("where re.ID_RECORRIDO = " + this.viaje.id_recorrido);
            Conexion cn = new Conexion();
            SqlDataReader consulta = cn.consultar(sb.ToString());
            if (consulta.Read())
            {
                v_precio_base_kg = consulta.GetDecimal(0);

            }
            cn.desconectar();

            this.precio_por_kg = v_precio_base_kg;

            return "$" + v_precio_base_kg.ToString();

        }

        public string getPrecioTotal()
        {

            decimal v_precio_encomiendas = this.cant_kg_totales * this.precio_por_kg;

            decimal v_precio_pasajes = 0;
            foreach (Nuevo_Pasaje.Pasaje pas in this.lista_pasajes)
            {
                v_precio_pasajes = v_precio_pasajes + pas.precio;
            }
            this.precio_total = v_precio_encomiendas + v_precio_pasajes;

            return "$" + this.precio_total.ToString();

        }

        private void c_tipo_pago_SelectedIndexChanged(object sender, EventArgs e)
        {
            int valor = ((ComboboxItem)c_tipo_pago.SelectedItem).Value;
            if (valor == 2)
            {
                n_tarjeta.Enabled = true;
                codigo_seguridad.Enabled = true;
                combo_vto.Enabled = true;
                c_cuotas.Enabled = true;
            }
            else {
                n_tarjeta.Enabled = false;
                codigo_seguridad.Enabled = false;
                combo_vto.Enabled = false;
                c_cuotas.Enabled = false;
            }
        }

        private void dni_KeyPress(object sender, KeyPressEventArgs e)
        {
            Funciones func = new Funciones();
            func.soloNumeros(e);
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
            else
            { //no existe el cliente ingresado
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

        private void telefono_KeyPress(object sender, KeyPressEventArgs e)
        {
            Funciones func = new Funciones();
            func.soloNumeros(e);
        }

        private void n_tarjeta_KeyPress(object sender, KeyPressEventArgs e)
        {
            Funciones func = new Funciones();
            func.soloNumeros(e);
        }

        private void codigo_seguridad_KeyPress(object sender, KeyPressEventArgs e)
        {
            Funciones func = new Funciones();
            func.soloNumeros(e);
        }

        private void n_tarjeta_Leave(object sender, EventArgs e)
        {
            StringBuilder sb = new StringBuilder();
            sb.Append("select tt.CUOTAS ");
            sb.Append("from SASHAILO.Tarjeta_Credito ta join SASHAILO.Tipo_Tarjeta tt on tt.ID_TIPO_TARJETA = ta.ID_TIPO_TARJETA ");
            sb.Append("where ta.NRO_TARJETA = '"+ n_tarjeta.Text.Trim() +"'");
            Conexion cn = new Conexion();
            SqlDataReader consulta = cn.consultar(sb.ToString());

            c_cuotas.Items.Clear();
            if (consulta.Read()) //existe el cliente ingresado
            {
                int v_cuotas = consulta.GetInt32(0);
                for (int i = 1; i <= v_cuotas; i++ )
                {
                    int c_cuota = i;
                    string d_cuota = i.ToString();
                    ComboboxItem item = new ComboboxItem();
                    item.Text = d_cuota;
                    item.Value = c_cuota;
                    c_cuotas.Items.Add(item);
                }
            }
            else
            {
                int c_cuota = 1;
                string d_cuota = "1";
                ComboboxItem item = new ComboboxItem();
                item.Text = d_cuota;
                item.Value = c_cuota;
                c_cuotas.Items.Add(item);
            }
            cn.desconectar();
        }

        private void b_guardar_Click(object sender, EventArgs e)
        {
            String err = "";
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
            if (((ComboboxItem)c_tipo_pago.SelectedItem) == null)
                err = err + "Debe seleccionar el medio de pago \n";
            if (n_tarjeta.Enabled && !tarjetaValida())
                err = err + "Los datos de la tarjeta ingresada no son correctos \n";
            if (n_tarjeta.Enabled && ((ComboboxItem)c_cuotas.SelectedItem) == null)
                err = err + "Debe seleccionar la cantidad de cuotas \n";

            if (!err.Equals(""))
            {
                MessageBox.Show(err, "Error", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                return;
            }

            int id_cliente_generado = grabaCliente();
            int id_compra_generada = grabaCompra(id_cliente_generado);

            //grabo los pasajes
            foreach (Nuevo_Pasaje.Pasaje pas in this.lista_pasajes)
            {
                int id_pasaje_generado = grabaPasaje(pas.cliente.id_cliente, id_compra_generada, pas.viaje.id_viaje, pas.butaca.id_butaca, pas.precio, pas.pas_discapacitado);
                pas.id_pasaje_gen = id_pasaje_generado;
            }

            //grabo las encomiendas
            foreach (Nueva_Encomienda.Encomienda enco in this.lista_encomiendas)
            {
                int id_encomienda_generada = grabaEncomienda(enco.cliente.id_cliente, id_compra_generada, enco.viaje.id_viaje, enco.cant_kg, enco.precio, enco.id_provisorio);
                enco.id_encomienda_gen = id_encomienda_generada;
            }


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

        public int grabaCompra(int id_cliente)
        {

            Conexion conn = new Conexion();
            SqlCommand sp_alta;
            int id_compra_generada;

            sp_alta = new SqlCommand("SASHAILO.sp_alta_compra", conn.miConexion); // Lo inicializo
            sp_alta.CommandType = CommandType.StoredProcedure; // Defino que tipo de comando es
            SqlParameter ID_CLIENTE = sp_alta.Parameters.Add("@p_id_cliente", SqlDbType.Int);
            SqlParameter F_COMPRA = sp_alta.Parameters.Add("@p_f_compra", SqlDbType.DateTime);
            SqlParameter IMPORTE = sp_alta.Parameters.Add("@p_importe", SqlDbType.Decimal);
            SqlParameter ID_MEDIO_PAGO = sp_alta.Parameters.Add("@p_id_medio_pago", SqlDbType.Int);
            SqlParameter NRO_TARJETA = sp_alta.Parameters.Add("@p_nro_tarjeta", SqlDbType.VarChar, 16);
            SqlParameter ID_COMPRA_GEN = sp_alta.Parameters.Add("@p_id_compra_gen", SqlDbType.Int);
            SqlParameter HAY_ERROR_USER = sp_alta.Parameters.Add("@hayErr", SqlDbType.Int);
            SqlParameter ERRORES_USER = sp_alta.Parameters.Add("@errores", SqlDbType.VarChar, 200);

            Funciones func = new Funciones();

            ID_CLIENTE.Value = id_cliente;
            F_COMPRA.Value = func.getFechaActual();
            IMPORTE.Value = this.precio_total;
            ID_MEDIO_PAGO.Value = ((ComboboxItem)c_tipo_pago.SelectedItem).Value;
            if (((ComboboxItem)c_tipo_pago.SelectedItem).Value == 1)
                NRO_TARJETA.Value = DBNull.Value;
            else
                NRO_TARJETA.Value = n_tarjeta.Text.Trim();

            ID_COMPRA_GEN.Direction = ParameterDirection.Output;
            HAY_ERROR_USER.Direction = ParameterDirection.Output;
            ERRORES_USER.Direction = ParameterDirection.Output;

            try
            {
                sp_alta.ExecuteNonQuery();
                int hayError = Convert.ToInt16(sp_alta.Parameters["@hayErr"].Value.ToString());
                if (hayError == 1)
                {
                    string errores = sp_alta.Parameters["@errores"].Value.ToString();
                    conn.desconectar();
                    return -1;
                }
                id_compra_generada = Convert.ToInt32(sp_alta.Parameters["@p_id_compra_gen"].Value.ToString());
            }
            catch (Exception error)
            {
                conn.desconectar();
                return -1;
            }
            conn.desconectar();

            return id_compra_generada;

        }

        public int grabaPasaje(int id_cliente, int id_compra, int id_viaje, int id_butaca, decimal precio, bool discapacidad)
        {

            Conexion conn = new Conexion();
            SqlCommand sp_alta;
            int id_pasaje_generado;

            sp_alta = new SqlCommand("SASHAILO.sp_alta_compra_pasaje", conn.miConexion); // Lo inicializo
            sp_alta.CommandType = CommandType.StoredProcedure; // Defino que tipo de comando es
            SqlParameter ID_CLIENTE = sp_alta.Parameters.Add("@p_id_cliente", SqlDbType.Int);
            SqlParameter ID_COMPRA = sp_alta.Parameters.Add("@p_id_compra", SqlDbType.Int);
            SqlParameter ID_VIAJE = sp_alta.Parameters.Add("@p_id_viaje", SqlDbType.Int);
            SqlParameter ID_BUTACA = sp_alta.Parameters.Add("@p_id_butaca", SqlDbType.Int);
            SqlParameter PRECIO = sp_alta.Parameters.Add("@p_precio", SqlDbType.Decimal);
            SqlParameter DISCAP = sp_alta.Parameters.Add("@p_discapacidad", SqlDbType.Char, 1);
            SqlParameter ID_PASAJE_GEN = sp_alta.Parameters.Add("@p_id_pasaje_gen", SqlDbType.Int);
            SqlParameter HAY_ERROR_USER = sp_alta.Parameters.Add("@hayErr", SqlDbType.Int);
            SqlParameter ERRORES_USER = sp_alta.Parameters.Add("@errores", SqlDbType.VarChar, 200);


            ID_CLIENTE.Value = id_cliente;
            ID_COMPRA.Value = id_compra;
            ID_VIAJE.Value = id_viaje;
            ID_BUTACA.Value = id_butaca;
            PRECIO.Value = precio;
            DISCAP.Value = (discapacidad) ? "S" : "N";
            ID_PASAJE_GEN.Direction = ParameterDirection.Output;
            HAY_ERROR_USER.Direction = ParameterDirection.Output;
            ERRORES_USER.Direction = ParameterDirection.Output;

            try
            {
                sp_alta.ExecuteNonQuery();
                int hayError = Convert.ToInt16(sp_alta.Parameters["@hayErr"].Value.ToString());
                if (hayError == 1)
                {
                    string errores = sp_alta.Parameters["@errores"].Value.ToString();
                    conn.desconectar();
                    return -1;
                }
                id_pasaje_generado = Convert.ToInt32(sp_alta.Parameters["@p_id_pasaje_gen"].Value.ToString());
            }
            catch (Exception error)
            {
                conn.desconectar();
                return -1;
            }
            conn.desconectar();

            return id_pasaje_generado;

        }

        public int grabaEncomienda(int id_cliente, int id_compra, int id_viaje, int kg, decimal precio, int id_provisorio)
        {

            Conexion conn = new Conexion();
            SqlCommand sp_alta;
            int id_encomienda_generada;

            sp_alta = new SqlCommand("SASHAILO.sp_alta_compra_encomienda", conn.miConexion); // Lo inicializo
            sp_alta.CommandType = CommandType.StoredProcedure; // Defino que tipo de comando es
            SqlParameter ID_CLIENTE = sp_alta.Parameters.Add("@p_id_cliente", SqlDbType.Int);
            SqlParameter ID_COMPRA = sp_alta.Parameters.Add("@p_id_compra", SqlDbType.Int);
            SqlParameter ID_VIAJE = sp_alta.Parameters.Add("@p_id_viaje", SqlDbType.Int);
            SqlParameter PRECIO = sp_alta.Parameters.Add("@p_precio", SqlDbType.Decimal);
            SqlParameter KG = sp_alta.Parameters.Add("@p_kg", SqlDbType.BigInt);
            SqlParameter ID_PROVISORIO = sp_alta.Parameters.Add("@p_id_provisorio", SqlDbType.Int);
            SqlParameter ID_ENCOMIENDA_GEN = sp_alta.Parameters.Add("@p_id_encomienda_gen", SqlDbType.Int);
            SqlParameter HAY_ERROR_USER = sp_alta.Parameters.Add("@hayErr", SqlDbType.Int);
            SqlParameter ERRORES_USER = sp_alta.Parameters.Add("@errores", SqlDbType.VarChar, 200);


            ID_CLIENTE.Value = id_cliente;
            ID_COMPRA.Value = id_compra;
            ID_VIAJE.Value = id_viaje;
            PRECIO.Value = precio;
            KG.Value = kg;
            ID_PROVISORIO.Value = id_provisorio;
            ID_ENCOMIENDA_GEN.Direction = ParameterDirection.Output;
            HAY_ERROR_USER.Direction = ParameterDirection.Output;
            ERRORES_USER.Direction = ParameterDirection.Output;

            try
            {
                sp_alta.ExecuteNonQuery();
                int hayError = Convert.ToInt16(sp_alta.Parameters["@hayErr"].Value.ToString());
                if (hayError == 1)
                {
                    string errores = sp_alta.Parameters["@errores"].Value.ToString();
                    conn.desconectar();
                    return -1;
                }
                id_encomienda_generada = Convert.ToInt32(sp_alta.Parameters["@p_id_encomienda_gen"].Value.ToString());
            }
            catch (Exception error)
            {
                conn.desconectar();
                return -1;
            }
            conn.desconectar();

            return id_encomienda_generada;

        }

        public Boolean fechaNacimientoMayorActual()
        {
            DateTime fecha_actual = Convert.ToDateTime(ConfigurationSettings.AppSettings["fechaActual"]);
            DateTime v_f_nac = f_nac.Value.Date;
            if (v_f_nac >= fecha_actual)
                return true;
            return false;
        }

        private bool tarjetaValida()
        {
            bool rtado = false;
            if (((ComboboxItemVto)combo_vto.SelectedItem) == null)
                return rtado;

            string vto = ((ComboboxItemVto)combo_vto.SelectedItem).Value;
            StringBuilder sb = new StringBuilder();
            sb.Append("select 1 from SASHAILO.Tarjeta_Credito ");
            sb.Append("where NRO_TARJETA = '"+n_tarjeta.Text.Trim()+"' and VENCIMIENTO = '"+vto+"' and CODIGO_SEGURIDAD = '"+codigo_seguridad.Text.Trim()+"'");
            Conexion cn = new Conexion();
            SqlDataReader consulta = cn.consultar(sb.ToString());

            if (consulta.Read()) //existe la tarjeta
            {
                rtado = true;
            }

            cn.desconectar();

            return rtado;
        }

    }
}
