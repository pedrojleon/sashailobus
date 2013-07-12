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
    public partial class Modif_rol : Form
    {
        
        public DataGridViewSelectedCellCollection celdaSeleccionada;
        private string nombreRolAModificar;
        private int id_rol;

        public Modif_rol()
        {
            InitializeComponent();
        }

        public void cargarDatos(string rol) // Carga las funcionalidades que tiene un rol a la hora de hacer una modificacion
        {
            
            this.id_rol = getIdRol(rol.Trim());

            Conexion conn = new Conexion(); // Creo un nuevo objeto Conexion a la hora de conectarme

            SqlDataReader habilitado = conn.consultar("select HABILITADO from SASHAILO.Rol where ID_ROL = " + this.id_rol + "");
            habilitado.Read();
            string estaHabilitado = habilitado.GetString(0);
            if (estaHabilitado == "S")
                Habilitado.Checked = true;
            else
                Habilitado.Checked = false;
            habilitado.Close();

            NombreRol.Text = rol;
            nombreRolAModificar = NombreRol.Text;

            SqlDataReader resultado = conn.consultar("select F.ID_FUNCION from SASHAILO.Rol R, SASHAILO.FuncionxRol FR, SASHAILO.Funcion F where R.ID_ROL = " + this.id_rol + " AND FR.ID_ROL = R.ID_ROL AND F.ID_FUNCION = FR.ID_FUNCION");

            // La consulta me devuelve la descripcion de las funcionalidades que tiene ese Rol
            
            while (resultado.Read())
            {
                // Para que cuando se realice una modificacion, ya aparezcan tildados las funcionalidades que tiene
                int id_funcion = resultado.GetInt32(0);

                switch (id_funcion)
                {
                    case 1: ABMRol.Checked = true;
                        break;
                    case 2: ABMCiudad.Checked = true;
                        break;
                    case 3: ABMRecorrido.Checked = true;
                        break;
                    case 4: ABMMicro.Checked = true;
                        break;
                    case 5: GeneracionViaje.Checked = true;
                        break;
                    case 6: RegistroLlegada.Checked = true;
                        break;
                    case 7: CompraPasaje.Checked = true;
                        break;
                    case 8: Devolucion.Checked = true;
                        break;
                    case 9: ConsultaPuntos.Checked = true;
                        break;
                    case 10: ListadoEstadistico.Checked = true;
                        break;
                    case 11: CanjePuntos.Checked = true;
                        break;
                }               
            }
            
            conn.desconectar();
        }

        private void modificarRol()
        {
            Conexion conn = new Conexion();
            SqlCommand sp_rol;

            sp_rol = new SqlCommand("SASHAILO.rol_modificacion", conn.miConexion);
            sp_rol.CommandType = CommandType.StoredProcedure;
            SqlParameter ID_ROL = sp_rol.Parameters.Add("@id_rol", SqlDbType.Int);
            SqlParameter nombreRol = sp_rol.Parameters.Add("@nombreRol", SqlDbType.VarChar, 20);
            SqlParameter habilitado = sp_rol.Parameters.Add("@habilitado", SqlDbType.Char, 1);

            ID_ROL.Value = this.id_rol;
            nombreRol.Value = NombreRol.Text;
            habilitado.Value = (Habilitado.Checked) ? "S" : "N";

            try
            {
                sp_rol.ExecuteNonQuery();
                MessageBox.Show("El rol ha sido modificado", "", MessageBoxButtons.OK);
            }
            catch (Exception error)
            {
                MessageBox.Show("Error en la modificacion del rol: " + error.ToString());
                conn.desconectar();
                return;
            }
            conn.desconectar();
        
        }

        private void modificarFunciones() {

            eliminarFunciones();
            insertarFunciones(this.id_rol);
        
        }

        private void insertarFunciones(int id_rol)
        {

            if (ABMRol.Checked)
                insertarFuncion(id_rol, 1);
            if (ABMCiudad.Checked)
                insertarFuncion(id_rol, 2);
            if (ABMRecorrido.Checked)
                insertarFuncion(id_rol, 3);
            if (ABMMicro.Checked)
                insertarFuncion(id_rol, 4);
            if (GeneracionViaje.Checked)
                insertarFuncion(id_rol, 5);
            if (RegistroLlegada.Checked)
                insertarFuncion(id_rol, 6);
            if (CompraPasaje.Checked)
                insertarFuncion(id_rol, 7);
            if (Devolucion.Checked)
                insertarFuncion(id_rol, 8);
            if (ConsultaPuntos.Checked)
                insertarFuncion(id_rol, 9);
            if (ListadoEstadistico.Checked)
                insertarFuncion(id_rol, 10);
            if (CanjePuntos.Checked)
                insertarFuncion(id_rol, 11);

        }

        public void insertarFuncion(int id_rol, int id_funcion)
        {

            Conexion conn = new Conexion();
            conn.consultar("INSERT INTO SASHAILO.FuncionxRol (ID_FUNCION, ID_ROL) VALUES (" + id_funcion + ", " + id_rol + ")");
            conn.desconectar();
        }

        private void eliminarFunciones()
        {

            Conexion conn = new Conexion();
            conn.consultar("DELETE FROM SASHAILO.FuncionxRol WHERE ID_ROL = " + this.id_rol + "");
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

            modificarRol();
            modificarFunciones();

            Modif_rol.ActiveForm.Close();

        }

        private bool existeNombreRol()
        {

            if (NombreRol.Text.Trim().Equals(""))
                return false;

            Conexion cn = new Conexion();

            SqlDataReader consulta = cn.consultar("select 1 from SASHAILO.Rol WHERE upper(NOMBRE) = upper('" + NombreRol.Text.Trim() + "') and ID_ROL <> "+ this.id_rol+ "");
            if (consulta.Read())
            {
                return true;
            }
            cn.desconectar();
            return false;

        }

        private int getIdRol(string nombre)
        {
            int id_rol = -1;

            Conexion cn = new Conexion();

            SqlDataReader consulta = cn.consultar("select ID_ROL from SASHAILO.Rol WHERE upper(NOMBRE) = upper('" + nombre + "')");
            if (consulta.Read())
            {
                id_rol = consulta.GetInt32(0);
            }
            cn.desconectar();
            return id_rol;

        }

    }
}