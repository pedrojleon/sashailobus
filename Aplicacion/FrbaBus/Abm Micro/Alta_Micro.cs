using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using System.Data.SqlClient;

namespace FrbaBus.Abm_Micro
{
    public partial class Alta_Micro : Form
    {
        public Alta_Micro()
        {
            InitializeComponent();
            setearFechaActual();
            llenarComboPisos(combo_pisos);
            llenarComboTipoServicio(combo_servicio);
            llenarComboMarca();
        }

        private void setearFechaActual(){
            DateTime ahora = DateTime.Now;
            string fecha = ahora.Day.ToString() + "/" + ahora.Month.ToString() + "/" + ahora.Year.ToString();
            label_f_actual.Text = fecha;
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

        private void button1_Click(object sender, EventArgs e)
        {
            //TODO VALIDACIONES

            Conexion conn = new Conexion();
            SqlCommand sp_alta;

            Label lbl = new Label();
            lbl.Text = "Nro Butaca:";
            TextBox nro_butaca = new TextBox();
            nro_butaca.Name = "butaca_1";

            Label lbl2 = new Label();
            lbl2.Text = "Tipo:";
            ComboBox cb = new ComboBox();
            cb.Name = "tipo_servicio_1";
            llenarComboTipoServicio(cb);

            Label lbl3 = new Label();
            lbl3.Text = "Piso:";
            ComboBox cb2 = new ComboBox();
            cb2.Name = "piso_1";
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
            flowLayoutPanel1.Controls.Add(lbl);
            flowLayoutPanel1.Controls.Add(nro_butaca);
            flowLayoutPanel1.Controls.Add(lbl2);
            flowLayoutPanel1.Controls.Add(cb);
            flowLayoutPanel1.Controls.Add(lbl3);
            flowLayoutPanel1.Controls.Add(cb2);

            
            //nro_butaca2.Location = new Point(30, 5);
            

            /*foreach(Control ctrl in piso1.Controls)
            {
                if(ctrl is TextBox)
                {
                    string id = ((TextBox)ctrl).Name;
                }
            }*/

            /*sp_alta = new SqlCommand("SASHAILO.alta_micro", conn.miConexion); // Lo inicializo
            sp_alta.CommandType = CommandType.StoredProcedure; // Defino que tipo de comando es
            SqlParameter PATENTE = sp_alta.Parameters.Add("@p_patente", SqlDbType.VarChar, 7);
            SqlParameter ID_MARCA = sp_alta.Parameters.Add("@p_id_marca", SqlDbType.Int);
            SqlParameter PRECIO_KG = sp_alta.Parameters.Add("@p_modelo", SqlDbType.VarChar, 25);
            SqlParameter PRECIO_PASAJE = sp_alta.Parameters.Add("@p_id_tipo_servicio", SqlDbType.Int);
            SqlParameter ID_TIPO_SERVICIO = sp_alta.Parameters.Add("@p_m_fuera_servicio", SqlDbType.Char, 1);
            SqlParameter ID_TIPO_SERVICIO = sp_alta.Parameters.Add("@p_cant_pisos", SqlDbType.Int);
            SqlParameter ID_TIPO_SERVICIO = sp_alta.Parameters.Add("@p_cant_kg", SqlDbType.Int);
            SqlParameter ID_TIPO_SERVICIO = sp_alta.Parameters.Add("@p_cant_vent_piso1", SqlDbType.Int);
            SqlParameter ID_TIPO_SERVICIO = sp_alta.Parameters.Add("@p_cant_pasi_piso1", SqlDbType.Int);
            SqlParameter ID_TIPO_SERVICIO = sp_alta.Parameters.Add("@p_cant_vent_piso2", SqlDbType.Int);
            SqlParameter ID_TIPO_SERVICIO = sp_alta.Parameters.Add("@p_cant_pasi_piso2", SqlDbType.Int);
            SqlParameter HAY_ERROR_USER = sp_alta.Parameters.Add("@hayErr", SqlDbType.Int);
            SqlParameter ERRORES_USER = sp_alta.Parameters.Add("@errores", SqlDbType.VarChar, 200);

            ID_CIUDAD_ORIGEN.Value = ((ComboboxItem)origen.SelectedItem).Value;
            ID_CIUDAD_DESTINO.Value = ((ComboboxItem)destino.SelectedItem).Value;
            PRECIO_KG.Value = Convert.ToDecimal(base_kg.Text.Trim());
            PRECIO_PASAJE.Value = Convert.ToDecimal(base_pasaje.Text.Trim());
            ID_TIPO_SERVICIO.Value = ((ComboboxItem)tipo_servicio.SelectedItem).Value;
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
                MessageBox.Show("El micro ha sido dado de alta", null, MessageBoxButtons.OK);
            }
            catch (Exception error)
            {
                MessageBox.Show("Error en la creación del micro. Error: " + error.ToString(), null, MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                conn.desconectar();
                return;
            }*/
        }
    }
}
