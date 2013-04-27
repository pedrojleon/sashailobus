using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using System.Data.SqlClient;

namespace FrbaBus.Abm_Permisos
{
    public partial class ABMRol : Form
    {

        public ABMRol()
        {
            InitializeComponent();
           
        }

        public void inicializarTabla()
        {
            DGVRol.Rows.Clear();

            Conexion conn = new Conexion();
            SqlDataReader resultado = conn.consultar("select NOMBRE, HABILITADO from SASHAILO.Rol where ELIMINADO = 'N' order by NOMBRE");

            int renglon;
            while (resultado.Read())
            {
                renglon = DGVRol.Rows.Add();
                DGVRol.Rows[renglon].Cells["NombreDelRol"].Value = resultado.GetString(0);
                DGVRol.Rows[renglon].Cells["Habilitado"].Value = resultado.GetString(1);

                DataGridViewImageCell iconColumn = (DataGridViewImageCell)DGVRol.Rows[renglon].Cells["acciones"];
                iconColumn.Value = FrbaBus.Properties.Resources.deny_ico;

                iconColumn = (DataGridViewImageCell)DGVRol.Rows[renglon].Cells["modificacion"];
                iconColumn.Value = FrbaBus.Properties.Resources.edit_ico;
            }
            conn.desconectar();
        }

        private void ABMRol_Load(object sender, EventArgs e)
        {
           inicializarTabla(); // Cuando se abre la pantalla del ABM de Rol, debe inicializar la tabla con todos los roles.
        }

        private string stringBooleana(bool booleano)
        {
            return booleano ? "S" : "N";
        }

        private void CrearRol_Click(object sender, EventArgs e)
        {
            Alta_rol alta = new Alta_rol();
            alta.Text = "Alta de Rol";
            alta.Tag = this; //guardo en Tag una referencia a mi formulario
            alta.ShowDialog();
            inicializarTabla();
        }

        private void EliminarRol_Click(object sender, EventArgs e)
        {
            if (DGVRol.SelectedCells.Count > 0)
            {
                Conexion conn = new Conexion();
                int i;
                for (i = 0; i < DGVRol.SelectedCells.Count; i++)
                {
                    SqlDataReader resultado = conn.consultar("UPDATE SASHAILO.Rol SET ELIMINADO = 'S' WHERE NOMBRE = '" + DGVRol.SelectedCells[i].Value.ToString() + "'");
                    resultado.Dispose(); // Aca hago el borrado logico
                    MessageBox.Show("Eliminado correctamente", "Baja de Rol");
                }
                conn.desconectar();
                inicializarTabla();
                
            }
        }

        private void ModificarRol_Click(object sender, EventArgs e)
        {
            Modif_rol modificacion = new Modif_rol();
            string rol = DGVRol.CurrentCell.Value.ToString(); // Aca guardo el rol seleccionado de la tabla
            modificacion.cargarDatos(rol);
            modificacion.Text = "Modificacion de Rol";
            modificacion.Tag = this;
            modificacion.ShowDialog();
            inicializarTabla();
                        
        }

        private void DGVRol_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
            if (e.ColumnIndex == 2)
            {
                string rol = DGVRol.Rows[e.RowIndex].Cells["NombreDelRol"].Value.ToString();
                Conexion conn = new Conexion();
                SqlDataReader resultado = conn.consultar("UPDATE SASHAILO.Rol SET ELIMINADO = 'S' WHERE NOMBRE = '" + rol + "'");
                resultado.Dispose(); // Aca hago el borrado logico
                MessageBox.Show("El rol '" + rol + "' ha sido eliminado", "");
                conn.desconectar();
                inicializarTabla();
                
            }

            if (e.ColumnIndex == 3)
            {
                Modif_rol modificacion = new Modif_rol();
                string rol = DGVRol.Rows[e.RowIndex].Cells["NombreDelRol"].Value.ToString();
                modificacion.cargarDatos(rol);
                modificacion.Text = "Modificacion de Rol";
                modificacion.Tag = this;
                modificacion.ShowDialog();
                inicializarTabla();
            }
        }  
    }
}
