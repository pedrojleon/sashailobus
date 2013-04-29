using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using System.Data.SqlClient;

namespace FrbaBus.Abm_Ciudad
{
    public partial class Abm_Ciudad : Form
    {
        public Abm_Ciudad()
        {
            InitializeComponent();
        }

        public void inicializarTabla()
        {
            DGVCiudad.Rows.Clear();

            Conexion conn = new Conexion();
            SqlDataReader resultado = conn.consultar("select ID_CIUDAD, NOMBRE_CIUDAD, HABILITADA from SASHAILO.Ciudad order by NOMBRE_CIUDAD");

            int renglon;
            while (resultado.Read())
            {
                renglon = DGVCiudad.Rows.Add();
                DGVCiudad.Rows[renglon].Cells["id_ciudad"].Value = resultado.GetInt16(0);
                DGVCiudad.Rows[renglon].Cells["NombreDeCiudad"].Value = resultado.GetString(1);
                DGVCiudad.Rows[renglon].Cells["Habilitada"].Value = resultado.GetString(2);

                DataGridViewImageCell iconColumn = (DataGridViewImageCell)DGVCiudad.Rows[renglon].Cells["acciones"];
                iconColumn.Value = FrbaBus.Properties.Resources.deny_ico;

                iconColumn = (DataGridViewImageCell)DGVCiudad.Rows[renglon].Cells["modificacion"];
                iconColumn.Value = FrbaBus.Properties.Resources.edit_ico;
            }
            conn.desconectar();
        }

        private void Abm_Ciudad_Load(object sender, EventArgs e)
        {
            inicializarTabla();
        }

        private void DGVCiudad_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
            if (e.ColumnIndex == 3)
            {
                string ciudad = DGVCiudad.Rows[e.RowIndex].Cells["id_ciudad"].Value.ToString();
                int id_ciudad = Convert.ToInt16(ciudad);
                Conexion conn = new Conexion();
                SqlDataReader resultado = conn.consultar("UPDATE SASHAILO.Ciudad SET HABILITADA = 'N' WHERE ID_CIUDAD = " + id_ciudad + "");
                resultado.Dispose(); // Aca hago el borrado logico
                MessageBox.Show("La Ciudad ha sido dada de baja", "");
                conn.desconectar();
                inicializarTabla();

            }

            if (e.ColumnIndex == 4)
            {
                Modif_Ciudad modificacion = new Modif_Ciudad();
                string ciudad = DGVCiudad.Rows[e.RowIndex].Cells["id_ciudad"].Value.ToString();
                int id_ciudad = Convert.ToInt16(ciudad);
                modificacion.cargarDatos(id_ciudad);
                modificacion.Text = "Modificación de Ciudad";
                modificacion.Tag = this;
                modificacion.ShowDialog();
                inicializarTabla();
            }
        }

        private void button1_Click(object sender, EventArgs e)
        {
            string nombre_ciudad = nueva_ciudad.Text.Trim();
            if(nombre_ciudad.CompareTo("") == 0){
                MessageBox.Show("Debe ingresar el Nombre de la Ciudad", "", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                return;
            }

            //valido que la ciudad no exista aun
            Conexion conn = new Conexion();
            SqlDataReader resultado = conn.consultar("select 1 from SASHAILO.Ciudad where upper(NOMBRE_CIUDAD)=upper('" + nombre_ciudad + "')");
            if (resultado.Read())
            {
                MessageBox.Show("La Ciudad ingresada ya existe en el sistema", "", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                nueva_ciudad.Focus();
                conn.desconectar();
                return;
            }
            conn.desconectar();
            conn = new Conexion();
            resultado = conn.consultar("INSERT INTO SASHAILO.Ciudad(NOMBRE_CIUDAD) values ('"+nombre_ciudad+"')");
            resultado.Dispose(); // Aca hago el borrado logico
            MessageBox.Show("La Ciudad ha sido dada de alta", "");
            conn.desconectar();
            inicializarTabla();

        }
    }
}
