using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using System.Data.SqlClient;

namespace FrbaBus.Estadisticas
{
    public partial class Listado_Estadistico : Form
    {
        public Listado_Estadistico()
        {
            InitializeComponent();
            cargarComboListados();
            cargarSemestres();
            listado_destinos_mas_pasajes.ColumnHeadersDefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter;
            listado_mas_micros_vacios.ColumnHeadersDefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter;
            listado_top_puntos.ColumnHeadersDefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter;
            listado_mas_cancelados.ColumnHeadersDefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter;
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

        public class ComboboxItemSemestre
        {
            public string Text { get; set; }
            public string Value { get; set; }

            public override string ToString()
            {
                return Text;
            }

        }

        private void cargarComboListados()
        {

            int nro_listado = 1;
            string d_listado = "Destinos con más pasajes comprados";
            ComboboxItem item = new ComboboxItem();
            item.Text = d_listado;
            item.Value = nro_listado;
            combo_listados.Items.Add(item);

            nro_listado = 2;
            d_listado = "Destinos con micros más vacíos";
            item = new ComboboxItem();
            item.Text = d_listado;
            item.Value = nro_listado;
            combo_listados.Items.Add(item);

            nro_listado = 3;
            d_listado = "Clientes con más puntos acumulados a la fecha";
            item = new ComboboxItem();
            item.Text = d_listado;
            item.Value = nro_listado;
            combo_listados.Items.Add(item);

            nro_listado = 4;
            d_listado = "Destinos con pasajes cancelados";
            item = new ComboboxItem();
            item.Text = d_listado;
            item.Value = nro_listado;
            combo_listados.Items.Add(item);

            nro_listado = 5;
            d_listado = "Micros con mayor cantidad de días fuera de servicio";
            item = new ComboboxItem();
            item.Text = d_listado;
            item.Value = nro_listado;
            combo_listados.Items.Add(item);

        }

        private void cargarSemestres()
        {

            string nro_listado = "22013";
            string d_listado = "2do 2013";
            ComboboxItemSemestre item = new ComboboxItemSemestre();
            item.Text = d_listado;
            item.Value = nro_listado;
            combo_semestre.Items.Add(item);

            nro_listado = "12013";
            d_listado = "1ero 2013";
            item = new ComboboxItemSemestre();
            item.Text = d_listado;
            item.Value = nro_listado;
            combo_semestre.Items.Add(item);

            nro_listado = "22012";
            d_listado = "2do 2012";
            item = new ComboboxItemSemestre();
            item.Text = d_listado;
            item.Value = nro_listado;
            combo_semestre.Items.Add(item);

            nro_listado = "12012";
            d_listado = "1ero 2012";
            item = new ComboboxItemSemestre();
            item.Text = d_listado;
            item.Value = nro_listado;
            combo_semestre.Items.Add(item);

        }

        private void b_buscar_Click(object sender, EventArgs e)
        {
            string str_error = "";
            if (((ComboboxItem)combo_listados.SelectedItem) == null)
                str_error = "Debe seleccionar el Listado que desea ver.\n";
            if (((ComboboxItemSemestre)combo_semestre.SelectedItem) == null && ((ComboboxItem)combo_listados.SelectedItem).Value != 3)
                str_error = str_error + "Debe seleccionar el Semestre.\n";

            if (!str_error.Equals(""))
            {
                MessageBox.Show(str_error, "Error", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                return;
            }

            if (((ComboboxItem)combo_listados.SelectedItem).Value == 1)
                destinosConMasPasajes();
            else if (((ComboboxItem)combo_listados.SelectedItem).Value == 2)
                destinosConMasMicrosVacios();
            else if (((ComboboxItem)combo_listados.SelectedItem).Value == 3)
                topClientesPuntos();
            else if (((ComboboxItem)combo_listados.SelectedItem).Value == 4)
                destinosConMasPasajesCancelados();
            else if (((ComboboxItem)combo_listados.SelectedItem).Value == 5)
                MessageBox.Show("No Implementado", "Error", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
        }

        private void destinosConMasPasajes() {

            Conexion conn = new Conexion();
            SqlCommand sp_listado = new SqlCommand("SASHAILO.top_destinos_mas_pasajes", conn.miConexion); // Lo inicializo
            sp_listado.CommandType = CommandType.StoredProcedure; // Defino que tipo de comando es
            SqlParameter F_DESDE = sp_listado.Parameters.Add("@p_f_desde", SqlDbType.DateTime);
            SqlParameter F_HASTA = sp_listado.Parameters.Add("@p_f_hasta", SqlDbType.DateTime);

            F_DESDE.Value = getFechaDesde();
            F_HASTA.Value = getFechaHasta();

            listado_destinos_mas_pasajes.Columns["destino"].DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter;
            listado_destinos_mas_pasajes.Columns["cantidad"].DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter;

            listado_destinos_mas_pasajes.Rows.Clear();

            try
            {
                SqlDataReader DR = sp_listado.ExecuteReader();
                int i = 0;

                while (DR.Read())
                {
                    listado_destinos_mas_pasajes.Rows.Add();

                    listado_destinos_mas_pasajes.Rows[i].Cells["destino"].Value = DR[1].ToString();
                    listado_destinos_mas_pasajes.Rows[i].Cells["cantidad"].Value = DR[2].ToString();

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

            listado_destinos_mas_pasajes.Location = new Point(29, 129);
            listado_destinos_mas_pasajes.Visible = true;
            listado_destinos_mas_pasajes.Height = 133;
            

            listado_mas_micros_vacios.Visible = false;
            listado_top_puntos.Visible = false;
            listado_mas_cancelados.Visible = false;
        
        }

        private void destinosConMasMicrosVacios()
        {

            Conexion conn = new Conexion();
            SqlCommand sp_listado = new SqlCommand("SASHAILO.top_destinos_micros_vacios", conn.miConexion); // Lo inicializo
            sp_listado.CommandType = CommandType.StoredProcedure; // Defino que tipo de comando es
            SqlParameter F_DESDE = sp_listado.Parameters.Add("@p_f_desde", SqlDbType.DateTime);
            SqlParameter F_HASTA = sp_listado.Parameters.Add("@p_f_hasta", SqlDbType.DateTime);

            F_DESDE.Value = getFechaDesde();
            F_HASTA.Value = getFechaHasta();

            listado_mas_micros_vacios.Columns["l2_destino"].DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter;
            listado_mas_micros_vacios.Columns["cantidad_m_vacios"].DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter;

            listado_mas_micros_vacios.Rows.Clear();

            try
            {
                SqlDataReader DR = sp_listado.ExecuteReader();
                int i = 0;

                while (DR.Read())
                {
                    listado_mas_micros_vacios.Rows.Add();

                    listado_mas_micros_vacios.Rows[i].Cells["l2_destino"].Value = DR[1].ToString();
                    listado_mas_micros_vacios.Rows[i].Cells["cantidad_m_vacios"].Value = DR[2].ToString();

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

            listado_mas_micros_vacios.Location = new Point(29, 129);
            listado_mas_micros_vacios.Visible = true;
            listado_mas_micros_vacios.Height = 133;

            listado_destinos_mas_pasajes.Visible = false;
            listado_top_puntos.Visible = false;
            listado_mas_cancelados.Visible = false;

        }

        private void topClientesPuntos()
        {

            Conexion conn = new Conexion();
            SqlCommand sp_listado = new SqlCommand("SASHAILO.top_clientes_puntos", conn.miConexion); // Lo inicializo
            sp_listado.CommandType = CommandType.StoredProcedure; // Defino que tipo de comando

            listado_top_puntos.Columns["cliente"].DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter;
            listado_top_puntos.Columns["puntos"].DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter;

            listado_top_puntos.Rows.Clear();

            try
            {
                SqlDataReader DR = sp_listado.ExecuteReader();
                int i = 0;

                while (DR.Read())
                {
                    listado_top_puntos.Rows.Add();

                    listado_top_puntos.Rows[i].Cells["cliente"].Value = DR[0].ToString() + " " + DR[1].ToString() + " (" + DR[2].ToString() + ")";
                    listado_top_puntos.Rows[i].Cells["puntos"].Value = DR[4].ToString();

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

            listado_top_puntos.Location = new Point(29, 129);
            listado_top_puntos.Height = 133;
            listado_top_puntos.Visible = true;

            listado_mas_micros_vacios.Visible = false;
            listado_destinos_mas_pasajes.Visible = false;
            listado_mas_cancelados.Visible = false;

        }

        private void destinosConMasPasajesCancelados()
        {

            Conexion conn = new Conexion();
            SqlCommand sp_listado = new SqlCommand("SASHAILO.top_destinos_devueltos", conn.miConexion); // Lo inicializo
            sp_listado.CommandType = CommandType.StoredProcedure; // Defino que tipo de comando es
            SqlParameter F_DESDE = sp_listado.Parameters.Add("@p_f_desde", SqlDbType.DateTime);
            SqlParameter F_HASTA = sp_listado.Parameters.Add("@p_f_hasta", SqlDbType.DateTime);

            F_DESDE.Value = getFechaDesde();
            F_HASTA.Value = getFechaHasta();

            listado_mas_cancelados.Columns["l4_destino"].DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter;
            listado_mas_cancelados.Columns["l4_cantidad"].DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter;

            listado_mas_cancelados.Rows.Clear();

            try
            {
                SqlDataReader DR = sp_listado.ExecuteReader();
                int i = 0;

                while (DR.Read())
                {
                    listado_mas_cancelados.Rows.Add();

                    listado_mas_cancelados.Rows[i].Cells["l4_destino"].Value = DR[1].ToString();
                    listado_mas_cancelados.Rows[i].Cells["l4_cantidad"].Value = DR[2].ToString();

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

            listado_mas_cancelados.Location = new Point(29, 129);
            listado_mas_cancelados.Visible = true;
            listado_mas_cancelados.Height = 133;

            listado_mas_micros_vacios.Visible = false;
            listado_top_puntos.Visible = false;
            listado_destinos_mas_pasajes.Visible = false;

        }

        private DateTime getFechaDesde() {

            string sem = ((ComboboxItemSemestre)combo_semestre.SelectedItem).Value;
            DateTime f_desde = Convert.ToDateTime("31/12/2010");

            if (sem.Equals("22013"))
                f_desde = Convert.ToDateTime("01/07/2013");
            else if (sem.Equals("12013"))
                f_desde = Convert.ToDateTime("01/01/2013");
            else if (sem.Equals("22012"))
                f_desde = Convert.ToDateTime("01/07/2012");
            else if (sem.Equals("12012"))
                f_desde = Convert.ToDateTime("01/01/2012");

            return f_desde;
        
        }

        private DateTime getFechaHasta()
        {

            string sem = ((ComboboxItemSemestre)combo_semestre.SelectedItem).Value;
            DateTime f_hasta = Convert.ToDateTime("31/12/2015");

            if (sem.Equals("22013"))
                f_hasta = Convert.ToDateTime("31/12/2013");
            else if (sem.Equals("12013"))
                f_hasta = Convert.ToDateTime("30/06/2013");
            else if (sem.Equals("22012"))
                f_hasta = Convert.ToDateTime("31/12/2012");
            else if (sem.Equals("12012"))
                f_hasta = Convert.ToDateTime("30/06/2012");

            return f_hasta;

        }
    }
}
