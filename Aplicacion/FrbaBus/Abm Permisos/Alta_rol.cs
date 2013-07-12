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
    public partial class Alta_rol : Form
    {
        public Alta_rol()
        {
            InitializeComponent();
        }     

        private int crearRol()
        {
            Conexion conn = new Conexion();
            SqlCommand sp_rol;

            sp_rol = new SqlCommand("SASHAILO.rol_alta", conn.miConexion);
            sp_rol.CommandType = CommandType.StoredProcedure;
            SqlParameter NOMBRE = sp_rol.Parameters.Add("@nombreRol", SqlDbType.VarChar, 20);
            SqlParameter ID = sp_rol.Parameters.Add("@id_rol", SqlDbType.Int);

            NOMBRE.Value = NombreRol.Text;
            ID.Direction = ParameterDirection.Output; ;
            int id_rol = -1;
            try
            {
                sp_rol.ExecuteNonQuery();
                id_rol = Convert.ToInt16(sp_rol.Parameters["@id_rol"].Value.ToString());
            }
            catch (Exception error)
            {
                MessageBox.Show("Error en la creacion del rol: " + error.ToString());
                conn.desconectar();
                return -1;
            }

            conn.desconectar();

            return id_rol;
        }

        private void insertarFunciones(int id_rol)
        {

            if(ABMRol.Checked)
                insertarFuncion(id_rol, 1);
            if(ABMCiudad.Checked)
                insertarFuncion(id_rol, 2);
            if(ABMRecorrido.Checked)
                insertarFuncion(id_rol, 3);
             if(ABMMicro.Checked)
                insertarFuncion(id_rol, 4);
             if(GeneracionViaje.Checked)
                insertarFuncion(id_rol, 5);
             if(RegistroLlegada.Checked)
                insertarFuncion(id_rol, 6);
             if(CompraPasaje.Checked)
                insertarFuncion(id_rol, 7);
             if(Devolucion.Checked)
                insertarFuncion(id_rol, 8);
             if(ConsultaPuntos.Checked)
                insertarFuncion(id_rol, 9);
             if(ListadoEstadistico.Checked)
                insertarFuncion(id_rol, 10);
             if(CanjePuntos.Checked)
                insertarFuncion(id_rol, 11);
            
        }

        public void insertarFuncion(int id_rol, int id_funcion){
            
            Conexion conn = new Conexion();
            conn.consultar("INSERT INTO SASHAILO.FuncionxRol (ID_FUNCION, ID_ROL) VALUES (" + id_funcion + ", " + id_rol + ")");
            conn.desconectar();
        }

        private void botonGuardar_Click(object sender, EventArgs e)
        {
            string str_errores = "";
            if (NombreRol.Text.Trim().Equals(""))
                str_errores = str_errores + "Ingrese un Nombre de Rol.\n";
            if (existeNombreRol())
                str_errores = str_errores + "El Rol ingresado ya existe.\n";

            if (!str_errores.Equals(""))
            {
                MessageBox.Show(str_errores, "Error", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                return;
            }

            int id_rol = crearRol();
            insertarFunciones(id_rol);

            Alta_rol.ActiveForm.Close();                              
        }

        private bool existeNombreRol() {

            if (NombreRol.Text.Trim().Equals(""))
                return false;

            Conexion cn = new Conexion();

            SqlDataReader consulta = cn.consultar("select 1 from SASHAILO.Rol WHERE upper(NOMBRE) = upper('" + NombreRol.Text.Trim() + "')");
            if (consulta.Read())
            {
                return true;
            }
            cn.desconectar();
            return false;
        
        }



    }
}
