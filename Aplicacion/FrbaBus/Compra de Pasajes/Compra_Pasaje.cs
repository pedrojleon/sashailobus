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
    public partial class Compra_Pasaje : Form
    {

        public DateTime fecha_actual;

        public Viaje viaje;
        public List<Nuevo_Pasaje.Pasaje> lista_pasajes;
        public List<Nueva_Encomienda.Encomienda> lista_encomiendas;
        public bool hay_discapacitado;
        public bool hayLogueado;

        public Compra_Pasaje(bool hayLogueado)
        {
            InitializeComponent();
            this.lista_pasajes = new List<Nuevo_Pasaje.Pasaje>();
            this.lista_encomiendas = new List<Nueva_Encomienda.Encomienda>();
            this.hay_discapacitado = false;
            this.hayLogueado = hayLogueado;
            cargarCombosCiudad();
            listado_de_viajes.ColumnHeadersDefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter;
            listado_pasajes.ColumnHeadersDefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter;
            listado_encomiendas.ColumnHeadersDefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter;
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

        public class Viaje
        {
            public int id_viaje { get; set; }
            public decimal id_recorrido { get; set; }
            public int id_micro { get; set; }
            public String tipo_servicio { get; set; }
            public DateTime f_salida { get; set; }
            public DateTime f_llegada_estim { get; set; }

            public override string ToString()
            {
                return "Código: " + id_viaje + "   -   Servicio: " + tipo_servicio + "   -   Salida: " + f_salida.ToString() + "   -   Llegada Estimada: " + f_llegada_estim.ToString();
            }

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

        private void b_guardar_Click(object sender, EventArgs e)
        {
            string str_error = "";
            if (((ComboboxItem)origen.SelectedItem) == null || ((ComboboxItem)destino.SelectedItem) == null)
                str_error = "Debe seleccionar las ciudades Origen y Destino.\n";
            if (fechaSalidaMenorActual())
                str_error = str_error + "La fecha de salida no puede ser previa a la actual.\n";

            if (!str_error.Equals(""))
            {
                MessageBox.Show(str_error, "Error", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                return;
            }

            Conexion conn = new Conexion();
            SqlCommand sp_listado = new SqlCommand("SASHAILO.get_viajes_disponibles", conn.miConexion); // Lo inicializo
            sp_listado.CommandType = CommandType.StoredProcedure; // Defino que tipo de comando es
            SqlParameter F_SALIDA = sp_listado.Parameters.Add("@p_f_salida", SqlDbType.DateTime);
            SqlParameter ID_CIUDAD_ORIGEN = sp_listado.Parameters.Add("@p_id_ciudad_origen", SqlDbType.Int);
            SqlParameter ID_CIUDAD_DESTINO = sp_listado.Parameters.Add("@p_id_ciudad_destino", SqlDbType.Int);

            F_SALIDA.Value = getFechaSalida();
            ID_CIUDAD_ORIGEN.Value = ((ComboboxItem)origen.SelectedItem).Value;
            ID_CIUDAD_DESTINO.Value = ((ComboboxItem)destino.SelectedItem).Value;

            listado_de_viajes.Columns["Micro"].DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter;
            listado_de_viajes.Columns["TipoServicio"].DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter;
            listado_de_viajes.Columns["Salida"].DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter;
            listado_de_viajes.Columns["LlegadaEstim"].DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter;
            listado_de_viajes.Columns["butacas"].DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter;
            listado_de_viajes.Columns["kg"].DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter;

            listado_de_viajes.Rows.Clear();

            try
            {
                SqlDataReader DR = sp_listado.ExecuteReader();
                int i = 0;

                while (DR.Read())
                {
                    listado_de_viajes.Rows.Add();

                    listado_de_viajes.Rows[i].Cells["id_viaje"].Value = DR[0].ToString();
                    listado_de_viajes.Rows[i].Cells["Micro"].Value = DR[1].ToString();
                    listado_de_viajes.Rows[i].Cells["TipoServicio"].Value = DR[2].ToString();
                    listado_de_viajes.Rows[i].Cells["Salida"].Value = DR[3].ToString();
                    listado_de_viajes.Rows[i].Cells["LlegadaEstim"].Value = DR[4].ToString();

                    String butacas_micro = DR[5].ToString();
                    String butacas_disp = DR[6].ToString();
                    String kg_micro = DR[7].ToString();
                    String kg_disp = DR[8].ToString();

                    listado_de_viajes.Rows[i].Cells["butacas"].Value = butacas_disp + " de " + butacas_micro;
                    listado_de_viajes.Rows[i].Cells["kg"].Value = kg_disp + " de " + kg_micro;

                    DataGridViewImageCell iconColumn = (DataGridViewImageCell)listado_de_viajes.Rows[i].Cells["acciones"];
                    iconColumn.Value = FrbaBus.Properties.Resources.accept_ico;
                    iconColumn.ToolTipText = "Seleccionar Viaje";

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

        public Boolean fechaSalidaMenorActual()
        {

            this.fecha_actual = Convert.ToDateTime(ConfigurationSettings.AppSettings["fechaActual"]);

            DateTime v_f_salida = f_salida.Value;
            v_f_salida = v_f_salida.AddHours(-v_f_salida.Hour);
            v_f_salida = v_f_salida.AddMinutes(-v_f_salida.Minute);
            v_f_salida = v_f_salida.AddSeconds(-v_f_salida.Second);
            v_f_salida = v_f_salida.AddMilliseconds(-v_f_salida.Millisecond);

            if (v_f_salida < this.fecha_actual)
                return true;

            return false;

        }

        public DateTime getFechaSalida()
        {

            DateTime fechaSalida; 

            this.fecha_actual = Convert.ToDateTime(ConfigurationSettings.AppSettings["fechaActual"]);
            DateTime v_f_salida = f_salida.Value;

            if (this.fecha_actual.Year == v_f_salida.Year && this.fecha_actual.Month == v_f_salida.Month && this.fecha_actual.Day == v_f_salida.Day)
            {
                fechaSalida = v_f_salida;
            }
            else {
                v_f_salida = v_f_salida.AddHours(-v_f_salida.Hour);
                v_f_salida = v_f_salida.AddMinutes(-v_f_salida.Minute);
                v_f_salida = v_f_salida.AddSeconds(-v_f_salida.Second);
                v_f_salida = v_f_salida.AddMilliseconds(-v_f_salida.Millisecond);
                fechaSalida = v_f_salida;
            }

            return fechaSalida;

        }

        private void listado_de_viajes_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
            if(this.viaje != null){
                MessageBox.Show("Ya existe un viaje seleccionado. Para seleccionar otro debe borrar la selección actual", "Error", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                return;
            }

            if (e.ColumnIndex == 7)
            {
                Int32 id_viaje = Convert.ToInt32(listado_de_viajes.Rows[e.RowIndex].Cells["id_viaje"].Value.ToString());
                StringBuilder sb = new StringBuilder();
                sb.Append("select vi.ID_VIAJE, vi.ID_MICRO, re.ID_RECORRIDO, ts.DESCRIPCION, vi.F_SALIDA, vi.F_LLEGADA_ESTIMADA ");
                sb.Append("from SASHAILO.Viaje vi join SASHAILO.Recorrido re on re.ID_RECORRIDO=vi.ID_RECORRIDO ");
                sb.Append("join SASHAILO.Tipo_Servicio ts on ts.ID_TIPO_SERVICIO=re.ID_TIPO_SERVICIO ");
                sb.Append("where vi.ID_VIAJE = " + id_viaje);
                Conexion cn = new Conexion();
                SqlDataReader consulta = cn.consultar(sb.ToString());
                if (consulta.Read())
                {
                    int id_micro = consulta.GetInt32(1);
                    decimal id_recorrido = consulta.GetDecimal(2);
                    String ts = consulta.GetString(3);
                    DateTime f_salida = consulta.GetDateTime(4);
                    DateTime f_llegada_estim = consulta.GetDateTime(4);

                    Viaje vi = new Viaje();
                    vi.id_viaje = id_viaje;
                    vi.id_micro = id_micro;
                    vi.id_recorrido = id_recorrido;
                    vi.tipo_servicio = ts;
                    vi.f_salida = f_salida;
                    vi.f_llegada_estim = f_llegada_estim;

                    this.viaje = vi;
                    label_viaje.Text = this.viaje.ToString();
                    icono_cruz.Visible = true;
                    b_guardar.Enabled = false;

                }
                cn.desconectar();
            }

        }

        private void icono_cruz_Click(object sender, EventArgs e)
        {
            this.viaje = null;
            label_viaje.Text = "-";
            icono_cruz.Visible = false;
            b_guardar.Enabled = true;
            eliminarPasajes();
            eliminarEncomiendas();
        }

        private void icono_mas_Click(object sender, EventArgs e)
        {
            if(this.viaje == null){
                MessageBox.Show("Debe seleccionar un Viaje", "Error", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                return;
            }
            Nuevo_Pasaje nuevo_pasaje = new Nuevo_Pasaje(this.viaje, this.hay_discapacitado);
            nuevo_pasaje.Tag = this; //guardo en Tag una referencia a mi formulario
            nuevo_pasaje.ShowDialog();

            Nuevo_Pasaje.Pasaje pas = nuevo_pasaje.pasaje;

            if (pas != null)
            {
                agregarATablaPasajes(pas);
                this.lista_pasajes.Add(pas);
                if (pas.pas_discapacitado)
                    this.hay_discapacitado = true;
            }
        }

        private void agregarATablaPasajes(Nuevo_Pasaje.Pasaje pas)
        {

            listado_pasajes.Columns["Pasajero"].DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter;
            listado_pasajes.Columns["Dni"].DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter;
            listado_pasajes.Columns["nro_butaca"].DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter;
            listado_pasajes.Columns["tipo_butaca"].DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter;
            listado_pasajes.Columns["piso_butaca"].DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter;

            listado_pasajes.Rows.Add();

            int i = listado_pasajes.RowCount - 1;

            listado_pasajes.Rows[i].Cells["id_butaca"].Value = pas.butaca.id_butaca;
            listado_pasajes.Rows[i].Cells["id_pasaje_provisorio"].Value = pas.id_provisorio;
            listado_pasajes.Rows[i].Cells["Pasajero"].Value = pas.cliente.nombre + " " + pas.cliente.apellido;
            listado_pasajes.Rows[i].Cells["Dni"].Value = pas.cliente.dni;
            listado_pasajes.Rows[i].Cells["nro_butaca"].Value = pas.butaca.nro_butaca;
            listado_pasajes.Rows[i].Cells["tipo_butaca"].Value = pas.butaca.tipo_butaca;
            listado_pasajes.Rows[i].Cells["piso_butaca"].Value = pas.butaca.piso_butaca;

            DataGridViewImageCell iconColumn = (DataGridViewImageCell)listado_pasajes.Rows[i].Cells["eliminar_pasaje"];
            iconColumn.Value = FrbaBus.Properties.Resources.deny_ico;
            iconColumn.ToolTipText = "Eliminar Pasaje";

        }

        private void agregarATablaEncomiendas(Nueva_Encomienda.Encomienda enco)
        {

            listado_encomiendas.Columns["encomendero"].DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter;
            listado_encomiendas.Columns["enco_dni"].DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter;
            listado_encomiendas.Columns["kilos"].DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter;

            listado_encomiendas.Rows.Add();

            int i = listado_encomiendas.RowCount - 1;

            listado_encomiendas.Rows[i].Cells["id_encomienda_provisoria"].Value = enco.id_provisorio;
            listado_encomiendas.Rows[i].Cells["encomendero"].Value = enco.cliente.nombre + " " + enco.cliente.apellido;
            listado_encomiendas.Rows[i].Cells["enco_dni"].Value = enco.cliente.dni;
            listado_encomiendas.Rows[i].Cells["kilos"].Value = enco.cant_kg;

            DataGridViewImageCell iconColumn = (DataGridViewImageCell)listado_encomiendas.Rows[i].Cells["eliminar"];
            iconColumn.Value = FrbaBus.Properties.Resources.deny_ico;
            iconColumn.ToolTipText = "Eliminar Encomienda";

        }

        private void listado_pasajes_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
            if (e.ColumnIndex == 7)
            {
                int fila = e.RowIndex;
                Int32 id_provisorio = Convert.ToInt32(listado_pasajes.Rows[fila].Cells["id_pasaje_provisorio"].Value.ToString());

                //elimino la butaca temporal que tiene guardada
                bajaButacaoEncomiendaTemporal(id_provisorio);

                //saco la fila de la tabla
                listado_pasajes.Rows.RemoveAt(fila);

                //saco el pasaje de la lista
                sacarDeLaListaDePasajes(id_provisorio);
                
            }
        }

        public void bajaButacaoEncomiendaTemporal(int id_temporal)
        {

            Conexion conn = new Conexion();
            SqlCommand sp_baja;

            sp_baja = new SqlCommand("SASHAILO.sp_baja_butaca_encomienda_provisoria", conn.miConexion); // Lo inicializo
            sp_baja.CommandType = CommandType.StoredProcedure; // Defino que tipo de comando es
            SqlParameter ID = sp_baja.Parameters.Add("@p_id", SqlDbType.Int);

            ID.Value = id_temporal;

            try
            {
                sp_baja.ExecuteNonQuery();
            }
            catch (Exception error) { }

            conn.desconectar();
        }

        public void sacarDeLaListaDePasajes(int id_temporal) { 
            
            foreach(Nuevo_Pasaje.Pasaje pas in this.lista_pasajes){
                if (pas.id_provisorio == id_temporal)
                {
                    if (pas.pas_discapacitado)
                        this.hay_discapacitado = false;
                    this.lista_pasajes.Remove(pas);
                    break;
                }
            }
        
        }

        public void sacarDeLaListaDeEncomiendas(int id_temporal)
        {

            foreach (Nueva_Encomienda.Encomienda enco in this.lista_encomiendas)
            {
                if (enco.id_provisorio == id_temporal)
                {
                    this.lista_encomiendas.Remove(enco);
                    break;
                }
            }

        }

        public void eliminarPasajes()
        {
            //elimino las butacas que tenia temporalmente guardadas
            foreach (Nuevo_Pasaje.Pasaje pas in this.lista_pasajes){
                bajaButacaoEncomiendaTemporal(pas.id_provisorio);
            }

            //reseteo la lista de pasajes
            this.lista_pasajes.Clear();

            //vacio la tabla
            listado_pasajes.Rows.Clear();

            this.hay_discapacitado = false;

        }

        public void eliminarEncomiendas()
        {
            //elimino las encomiendas que tenia temporalmente guardadas
            foreach (Nueva_Encomienda.Encomienda enco in this.lista_encomiendas)
            {
                bajaButacaoEncomiendaTemporal(enco.id_provisorio);
            }

            //reseteo la lista de encomiendas
            this.lista_encomiendas.Clear();

            //vacio la tabla
            listado_encomiendas.Rows.Clear();


        }

        private void Compra_Pasaje_FormClosing(object sender, FormClosingEventArgs e)
        {
            //elimino las butacas temporales que tiene guardadas
            int cant_pasajes = listado_pasajes.RowCount;
            for (int fila = 0; fila < cant_pasajes; fila++) {
                Int32 id_provisorio = Convert.ToInt32(listado_pasajes.Rows[fila].Cells["id_pasaje_provisorio"].Value.ToString());
                bajaButacaoEncomiendaTemporal(id_provisorio);

            }

            //elimino las encomiendas temporales que tiene guardadas
            int cant_encomiendas = listado_encomiendas.RowCount;
            for (int fila = 0; fila < cant_encomiendas; fila++){
                Int32 id_provisorio = Convert.ToInt32(listado_encomiendas.Rows[fila].Cells["id_encomienda_provisoria"].Value.ToString());
                bajaButacaoEncomiendaTemporal(id_provisorio);
            }
         
        }

        private void pictureBox1_Click(object sender, EventArgs e)
        {
            if (this.viaje == null)
            {
                MessageBox.Show("Debe seleccionar un Viaje", "Error", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                return;
            }
            Nueva_Encomienda nueva_enco = new Nueva_Encomienda(this.viaje);
            nueva_enco.Tag = this; //guardo en Tag una referencia a mi formulario
            nueva_enco.ShowDialog();

            Nueva_Encomienda.Encomienda enco = nueva_enco.encomienda;

            if (enco != null)
            {
                agregarATablaEncomiendas(enco);
                this.lista_encomiendas.Add(enco);
            }
        }

        private void listado_encomiendas_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
            if (e.ColumnIndex == 4)
            {
                int fila = e.RowIndex;
                Int32 id_provisorio = Convert.ToInt32(listado_encomiendas.Rows[fila].Cells["id_encomienda_provisoria"].Value.ToString());

                //elimino la butaca temporal que tiene guardada
                bajaButacaoEncomiendaTemporal(id_provisorio);

                //saco la fila de la tabla
                listado_encomiendas.Rows.RemoveAt(fila);

                //saco la encomienda de la lista
                sacarDeLaListaDeEncomiendas(id_provisorio);

            }
        }

        private void button1_Click(object sender, EventArgs e)
        {
            if (this.viaje == null)
            {
                MessageBox.Show("Debe seleccionar un Viaje", "Error", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                return;
            }
            if (this.lista_pasajes.Count == 0 && this.lista_encomiendas.Count == 0)
            {
                MessageBox.Show("Debe seleccionar algún Pasaje o Encomienda", "Error", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                return;
            }
            
            Finalizar_Compra fin_compra = new Finalizar_Compra(this.viaje, this.lista_pasajes, this.lista_encomiendas, this.hayLogueado);
            fin_compra.Tag = this; //guardo en Tag una referencia a mi formulario
            fin_compra.ShowDialog();

            if(fin_compra.mostroComprobante)
                Compra_Pasaje.ActiveForm.Close();

        }
    }
}
