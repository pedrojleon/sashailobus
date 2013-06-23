using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using System.Data.SqlClient;

namespace FrbaBus.GenerarViaje
{
    public partial class Listado_Viajes : Form
    {
        public Listado_Viajes()
        {
            InitializeComponent();
            cargarCombosCiudad();
            //hardcodeo dos ciudades porque si no filtran la busqueda tarda mucho
            seleccionarEnCombo(combo_origen, 44);
            seleccionarEnCombo(combo_destino, 2);
            b_buscar_Click(null,null);
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

                combo_origen.Items.Add(item);
                combo_destino.Items.Add(item);
            }
            cn.desconectar();
        }

        private void b_buscar_Click(object sender, EventArgs e)
        {
            listado_de_viajes.Rows.Clear();

            if (((ComboboxItem)combo_origen.SelectedItem) == null || ((ComboboxItem)combo_destino.SelectedItem) == null)
            {
                //hardcodeo dos ciudades porque si no filtran la busqueda tarda mucho
                seleccionarEnCombo(combo_origen, 44);
                seleccionarEnCombo(combo_destino, 2);
            }

            Conexion conn = new Conexion();
            SqlCommand sp_listado = new SqlCommand("SASHAILO.listado_viajes", conn.miConexion); // Lo inicializo
            sp_listado.CommandType = CommandType.StoredProcedure; // Defino que tipo de comando es
            SqlParameter ID_CIUDAD_ORIGEN = sp_listado.Parameters.Add("@p_id_ciudad_origen", SqlDbType.Int);
            SqlParameter ID_CIUDAD_DESTINO = sp_listado.Parameters.Add("@p_id_ciudad_destino", SqlDbType.Int);

            if (((ComboboxItem)combo_origen.SelectedItem) == null)
                ID_CIUDAD_ORIGEN.Value = DBNull.Value;
            else
                ID_CIUDAD_ORIGEN.Value = ((ComboboxItem)combo_origen.SelectedItem).Value;

            if (((ComboboxItem)combo_destino.SelectedItem) == null)
                ID_CIUDAD_DESTINO.Value = DBNull.Value;
            else
                ID_CIUDAD_DESTINO.Value = ((ComboboxItem)combo_destino.SelectedItem).Value;

            try
            {
                SqlDataReader DR = sp_listado.ExecuteReader();
                int i = 0;

                while (DR.Read())
                {
                    listado_de_viajes.Rows.Add();

                    listado_de_viajes.Rows[i].Cells["Recorrido"].Value = DR[0].ToString() + " - " + DR[1].ToString();
                    listado_de_viajes.Rows[i].Cells["Micro"].Value = DR[2].ToString() + " [" + DR[3].ToString() + " Butacas, " + DR[4].ToString() + " KG]";
                    listado_de_viajes.Rows[i].Cells["TipoServicio"].Value = DR[5].ToString();
                    listado_de_viajes.Rows[i].Cells["Salida"].Value = DR[6].ToString();
                    listado_de_viajes.Rows[i].Cells["LlegadaEstim"].Value = DR[7].ToString();
                    if (!DR.IsDBNull(8))
                        listado_de_viajes.Rows[i].Cells["Llegada"].Value = DR[8].ToString();
                    else
                        listado_de_viajes.Rows[i].Cells["Llegada"].Value = "-";

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

        private void b_nuevo_Click(object sender, EventArgs e)
        {
            Generar_Viaje alta = new Generar_Viaje();
            alta.Tag = this; //guardo en Tag una referencia a mi formulario
            alta.ShowDialog();
            b_buscar_Click(null, null);
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
    }
}
