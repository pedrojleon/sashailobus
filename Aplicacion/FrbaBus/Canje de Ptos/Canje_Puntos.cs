using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using System.Data.SqlClient;

namespace FrbaBus.Canje_de_Ptos
{
    public partial class Canje_Puntos : Form
    {
        public int id_cliente;

        public Canje_Puntos()
        {
            InitializeComponent();
            llenaComboProducto();
        }

        public class ComboboxItem
        {
            public string Text { get; set; }
            public int Value { get; set; }
            public int Puntos { get; set; }

            public override string ToString()
            {
                return "  "+Text + " - ("+Puntos+" puntos)  ";
            }

        }

        public void llenaComboProducto(){
            Conexion cn = new Conexion();
            producto.Items.Clear();
            SqlDataReader consulta = cn.consultar("select ID_PRODUCTO, DESCRIPCION, PUNTOS_NECESARIOS from SASHAILO.Producto WHERE STOCK > 0 ORDER BY 3 desc");
            while (consulta.Read())
            {
                int id_producto = consulta.GetInt32(0);
                string desc = consulta.GetString(1);
                int puntos_necesarios = consulta.GetInt32(2);

                ComboboxItem item = new ComboboxItem();
                item.Text = desc;
                item.Value = id_producto;
                item.Puntos = puntos_necesarios;

                producto.Items.Add(item);
            }
            cn.desconectar();
            producto.Text = "";
        }

        private void groupBox1_Enter(object sender, EventArgs e)
        {

        }

        private void pasaje_Leave(object sender, EventArgs e)
        {
            if (dni.Text.Trim().Equals(""))
                return;
            Conexion cn = new Conexion();

            SqlDataReader consulta = cn.consultar("select PUNTOS from SASHAILO.Cliente WHERE DNI = " + dni.Text.Trim());
            if(consulta.Read())
            {
                int puntos_necesarios = consulta.GetInt32(0);
                puntos.Text = puntos_necesarios.ToString();
                puntos.Visible = true;
                label_puntos.Visible = true;
            }
            cn.desconectar();
        }

        public bool existeCliente()
        {
            if (dni.Text.Trim().Equals(""))
                return false;

            Conexion cn = new Conexion();

            SqlDataReader consulta = cn.consultar("select ID_CLIENTE from SASHAILO.Cliente WHERE DNI = " + dni.Text.Trim() + " ");
            if(consulta.Read())
            {
                this.id_cliente = consulta.GetInt32(0);
                return true;
            }
            cn.desconectar();
            return false;
        }

        private void dni_KeyPress(object sender, KeyPressEventArgs e)
        {
            Funciones func = new Funciones();
            func.soloNumeros(e);
        }

        private void textBox1_KeyPress(object sender, KeyPressEventArgs e)
        {
            Funciones func = new Funciones();
            func.soloNumeros(e);
        }

        private void canjear_Click(object sender, EventArgs e)
        {
            string str_error = "";
            if (dni.Text.Trim().Equals(""))
                str_error = str_error + "El DNI ingresado no es válido.\n";
            if (!dni.Text.Trim().Equals("") && !existeCliente())
                str_error = str_error + "El DNI ingresado no es válido.\n";
            if (((ComboboxItem)producto.SelectedItem) == null)
                str_error = str_error + "Debe seleccionar el producto.\n";
            if (cantidad.Text.Trim().Equals(""))
                str_error = str_error + "La cantidad ingresada no es válida.\n";

            if (!str_error.Equals(""))
            {
                MessageBox.Show(str_error, "Error", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                return;
            }

            Conexion conn = new Conexion();
            SqlCommand sp_recorrido_alta;
            Funciones func = new Funciones();

            sp_recorrido_alta = new SqlCommand("SASHAILO.sp_canjear_producto", conn.miConexion); // Lo inicializo
            sp_recorrido_alta.CommandType = CommandType.StoredProcedure; // Defino que tipo de comando es
            SqlParameter ID_CLIENTE = sp_recorrido_alta.Parameters.Add("@p_id_cliente", SqlDbType.Int);
            SqlParameter ID_PRODUCTO = sp_recorrido_alta.Parameters.Add("@p_id_producto", SqlDbType.Int);
            SqlParameter CANTIDAD = sp_recorrido_alta.Parameters.Add("@p_cantidad", SqlDbType.Int);
            SqlParameter FECHA = sp_recorrido_alta.Parameters.Add("@p_fecha", SqlDbType.DateTime);
            SqlParameter HAY_ERROR_USER = sp_recorrido_alta.Parameters.Add("@hayErr", SqlDbType.Int);
            SqlParameter ERRORES_USER = sp_recorrido_alta.Parameters.Add("@errores", SqlDbType.VarChar, 200);

            ID_CLIENTE.Value = this.id_cliente;
            ID_PRODUCTO.Value = ((ComboboxItem)producto.SelectedItem).Value;
            CANTIDAD.Value = cantidad.Text.Trim();
            FECHA.Value = func.getFechaActual();
            HAY_ERROR_USER.Direction = ParameterDirection.Output;
            ERRORES_USER.Direction = ParameterDirection.Output;

            try
            {
                sp_recorrido_alta.ExecuteNonQuery();

                int hayError = Convert.ToInt16(sp_recorrido_alta.Parameters["@hayErr"].Value.ToString());
                if (hayError == 1)
                {
                    string errores = sp_recorrido_alta.Parameters["@errores"].Value.ToString();
                    MessageBox.Show(errores, null, MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                    conn.desconectar();
                    return;
                }
                MessageBox.Show("El canje ha sido realizado", "", MessageBoxButtons.OK);
            }
            catch (Exception error)
            {
                MessageBox.Show("Error en el canje. Error: " + error.ToString(), null, MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                conn.desconectar();
                return;
            }

            pasaje_Leave(null, null);
            llenaComboProducto();
            cantidad.Text = "";
        }

    }
}
