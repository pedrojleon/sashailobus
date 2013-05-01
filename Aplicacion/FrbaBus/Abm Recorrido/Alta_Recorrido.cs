using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using System.Data.SqlClient;

namespace FrbaBus.Abm_Recorrido
{
    public partial class Alta_Recorrido : Form
    {
        public Alta_Recorrido()
        {
            InitializeComponent();
            cargarCombosCiudad();
            tipo_servicio.Enabled = false;
            base_pasaje.Enabled = false;
            base_kg.Enabled = false;
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

        private void origen_SelectedIndexChanged(object sender, EventArgs e)
        {
            evaluarCombosCiudad();
        }

        private void evaluarCombosCiudad()
        {
            tipo_servicio.Items.Clear();
            tipo_servicio.Text = "";
            edit_base_pasaje.Visible = false;
            edit_base_kg.Visible = false;

            if (((ComboboxItem)origen.SelectedItem) == null || ((ComboboxItem)destino.SelectedItem) == null)
            {
                return;
            }

            int id_ciudad_origen = ((ComboboxItem)origen.SelectedItem).Value;
            int id_ciudad_destino = ((ComboboxItem)destino.SelectedItem).Value;

            Conexion cn = new Conexion();
            SqlDataReader consulta = cn.consultar("select ID_TIPO_SERVICIO, DESCRIPCION " +
                                                 " from SASHAILO.Tipo_Servicio " +
                                                 " where ID_TIPO_SERVICIO not in (select ID_TIPO_SERVICIO " + 
							                                                    " from SASHAILO.Recorrido " +
							                                                    " where ID_CIUDAD_ORIGEN = "+id_ciudad_origen+" " +
						                                                    " and ID_CIUDAD_DESTINO = "+id_ciudad_destino+") order by 1");
            //cargo el combo de tipo de servicio
            while (consulta.Read())
            {
                int id_tipo_servicio = consulta.GetInt32(0);
                string d_servicio = consulta.GetString(1);

                ComboboxItem item = new ComboboxItem();
                item.Text = d_servicio;
                item.Value = id_tipo_servicio;

                tipo_servicio.Items.Add(item);
                
            }
            cn.desconectar();
            tipo_servicio.Enabled = true;

            //evaluo los precios base
            cn = new Conexion();
            consulta = cn.consultar("select top 1 PRECIO_BASE_KG, PRECIO_BASE_PASAJE from SASHAILO.Recorrido "+ 
                                    "where ID_CIUDAD_ORIGEN = "+id_ciudad_origen+" and ID_CIUDAD_DESTINO = "+id_ciudad_destino+"");

            if (consulta.Read())  //hay precios cargados
            {
                decimal precio_base_kg = consulta.GetDecimal(0);
                decimal precio_base_pasaje = consulta.GetDecimal(1);
                base_pasaje.Text = precio_base_pasaje.ToString();
                base_kg.Text = precio_base_kg.ToString();
                base_pasaje.Enabled = false;
                base_kg.Enabled = false;
                edit_base_pasaje.Visible = true;
                edit_base_kg.Visible = true;
            }
            else {
                base_pasaje.Text = "";
                base_kg.Text = "";
                edit_base_pasaje.Visible = false;
                edit_base_kg.Visible = false;
                base_pasaje.Enabled = true;
                base_kg.Enabled = true;
            }
            cn.desconectar();
            tipo_servicio.Enabled = true;
        }

        private void destino_SelectedIndexChanged(object sender, EventArgs e)
        {
            evaluarCombosCiudad();
        }

        private void edit_base_pasaje_Click(object sender, EventArgs e)
        {
            base_pasaje.Enabled = !base_pasaje.Enabled;
        }

        private void edit_base_kg_Click(object sender, EventArgs e)
        {
            base_kg.Enabled = !base_kg.Enabled;
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
}
