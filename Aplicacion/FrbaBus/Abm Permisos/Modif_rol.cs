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

        public Modif_rol()
        {
            InitializeComponent();
        }

        public void cargarDatos(string rol) // Carga las funcionalidades que tiene un rol a la hora de hacer una modificacion
        {
            
            Conexion conn = new Conexion(); // Creo un nuevo objeto Conexion a la hora de conectarme

            SqlDataReader habilitado = conn.consultar("select HABILITADO from SASHAILO.Rol where NOMBRE = '" + rol + "'");
            habilitado.Read();
            string estaHabilitado = habilitado.GetString(0);
            if (estaHabilitado == "S")
                Habilitado.Checked = true;
            else
                Habilitado.Checked = false;

            habilitado.Close();

            NombreRol.Text = rol;
            nombreRolAModificar = NombreRol.Text;

            SqlDataReader resultado = conn.consultar("select F.DESCRIPCION from SASHAILO.Rol R, SASHAILO.FuncionxRol FR, SASHAILO.Funcion F where R.NOMBRE = '" + rol + "' AND FR.ID_ROL = R.ID_ROL AND F.ID_FUNCION = FR.ID_FUNCION");

            // La consulta me devuelve la descripcion de las funcionalidades que tiene ese Rol
            
            while (resultado.Read())
            {
                // Para que cuando se realice una modificacion, ya aparezcan tildados las funcionalidades que tiene
                string funcion = resultado.GetString(0);

                switch (funcion)
                {
                    case "ABM de Rol": ABMRol.Checked = true;
                        break;
                    case "ABM de Ciudad": ABMCiudad.Checked = true;
                        break;
                    case "ABM de Recorrido": ABMRecorrido.Checked = true;
                        break;
                    case "ABM de Micro": ABMMicro.Checked = true;
                        break;
                    case "Generación de Viaje": GeneracionViaje.Checked = true;
                        break;
                    case "Registro de llegada a Destino": RegistroLlegada.Checked = true;
                        break;
                    case "Compra de Pasaje/Encomienda": CompraPasaje.Checked = true;
                        break;
                    case "Devolución/Cancelación de pasaje y/o encomienda": Devolucion.Checked = true;
                        break;
                    case "Consulta de puntos de pasajero frecuente": ConsultaPuntos.Checked = true;
                        break;
                    case "Listado Estadístico": ListadoEstadistico.Checked = true;
                        break;
                }               
            }
                    conn.desconectar();
        }

        private void botonCancelar_Click(object sender, EventArgs e)
        {
            Modif_rol.ActiveForm.Close();
        }

        private void Modif_rol_Load(object sender, EventArgs e)
        {

        }     


        private bool verificarDatos()
        {
            if (NombreRol.Text == "" || NombreRol.Text.Length > 20) // Verifica si el nombre supera los 20 char o si esta vacio
            {
                MessageBox.Show("Por favor, inserte un nombre valido", "Error");
                return false;
            }

            Conexion cn = new Conexion();

            {   // Verifico si ya existe otro Rol con ese nombre

                SqlDataReader consulta = cn.consultar("SELECT NOMBRE FROM SASHAILO.ROL WHERE NOMBRE ='" + NombreRol.Text + "' and ELIMINADO = 'N' ");
                if (consulta.Read()) // Si existe un rol en la DB con ese nombre.. ERROR
                {
                    if (consulta.GetString(0) == nombreRolAModificar) return true;
                    else
                    {
                        cn.desconectar();
                        MessageBox.Show("El rol " + NombreRol.Text + " ya se encuentra en el sistema", "Error");
                        return false;
                    }             
                  
                }

                return true;
            }
        }

        private string si_no(CheckBox chbox)
        {
            if (chbox.Checked == false)
                return "N";
            else
                return "S";
        }

        private void guardarDatos()
        {
            Conexion conn2 = new Conexion();
                        
            // Aca hago las modificaciones en la DB

            conn2.consultar("UPDATE SASHAILO.Rol SET NOMBRE = '" + NombreRol.Text + "', HABILITADO = '" + si_no(Habilitado) + "', ELIMINADO = 'N' where NOMBRE = '" + nombreRolAModificar + "'");
            conn2.desconectar();

            execSP();

            // Aca deberia ejecutar el trigger que si deshabilita el rol, tiene que deshabilitar a todos los usuarios que tengan ese rol

            MessageBox.Show("Rol modificado correctamente", "Modificación de Rol");

            
        }

        private void execSP()
        {
            Conexion conn = new Conexion();
            SqlCommand sp_rol;

                sp_rol = new SqlCommand("SASHAILO.rol_modificacion", conn.miConexion);
                sp_rol.CommandType = CommandType.StoredProcedure;
                SqlParameter nombreRol = sp_rol.Parameters.Add("@nombreRol", SqlDbType.VarChar, 20);
                SqlParameter FuncionABMRol = sp_rol.Parameters.Add("@FuncionABMRol", SqlDbType.Int);
                SqlParameter FuncionABMCiudad = sp_rol.Parameters.Add("@FuncionABMCiudad", SqlDbType.Int);
                SqlParameter FuncionABMRecorrido = sp_rol.Parameters.Add("@FuncionABMRecorrido", SqlDbType.Int);
                SqlParameter FuncionABMMicro = sp_rol.Parameters.Add("@FuncionABMMicro", SqlDbType.Int);
                SqlParameter FuncionGeneracionViaje = sp_rol.Parameters.Add("@FuncionGeneracionViaje", SqlDbType.Int);
                SqlParameter FuncionRegistroLlegada = sp_rol.Parameters.Add("@FuncionRegistroLlegada", SqlDbType.Int);
                SqlParameter FuncionCompraPasaje = sp_rol.Parameters.Add("@FuncionCompraPasaje", SqlDbType.Int);
                SqlParameter FuncionDevolucion = sp_rol.Parameters.Add("@FuncionDevolucion", SqlDbType.Int);
                SqlParameter FuncionConsultaPuntos = sp_rol.Parameters.Add("@FuncionConsultaPuntos", SqlDbType.Int);
                SqlParameter FuncionListadoEstadistico = sp_rol.Parameters.Add("@FuncionListadoEstadistico", SqlDbType.Int);

                nombreRol.Value = NombreRol.Text;
                FuncionABMRol.Value = Convert.ToByte(ABMRol.Checked);
                FuncionABMCiudad.Value = Convert.ToByte(ABMCiudad.Checked);
                FuncionABMRecorrido.Value = Convert.ToByte(ABMRecorrido.Checked);
                FuncionABMMicro.Value = Convert.ToByte(ABMMicro.Checked);
                FuncionGeneracionViaje.Value = Convert.ToByte(GeneracionViaje.Checked);
                FuncionRegistroLlegada.Value = Convert.ToByte(RegistroLlegada.Checked);
                FuncionCompraPasaje.Value = Convert.ToByte(CompraPasaje.Checked);
                FuncionDevolucion.Value = Convert.ToByte(Devolucion.Checked);
                FuncionConsultaPuntos.Value = Convert.ToByte(ConsultaPuntos.Checked);
                FuncionListadoEstadistico.Value = Convert.ToByte(ListadoEstadistico.Checked);

                try
                {
                    sp_rol.ExecuteNonQuery();
                }
                catch (Exception error)
                {
                    MessageBox.Show("Error en la inserción del rol, consulte a un administrador " + error.ToString());
                    conn.desconectar();
                    return;
                }
                conn.desconectar();
            }
        
            

        private void botonGuardar_Click(object sender, EventArgs e)
        {
            if (verificarDatos())
            {
                guardarDatos();
                botonGuardar.Enabled = false;
                botonGuardar.Text = "Guardado";
                Modif_rol.ActiveForm.Close();
                
            }
        }

    }
}