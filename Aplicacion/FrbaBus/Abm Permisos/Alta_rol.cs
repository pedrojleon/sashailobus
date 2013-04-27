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

        private int verificarDatos()
        {
            if (NombreRol.Text == "" || NombreRol.Text.Length > 20) // Verifica si el nombre supera los 20 char o si esta vacio
            {
                MessageBox.Show("Por favor, inserte un nombre valido", "Error");
                return 1;
            }

            Conexion cn = new Conexion();

            {   // Verifico que no exista otro rol con el mismo nombre en la DB
                
                SqlDataReader consulta2 = cn.consultar("SELECT NOMBRE, ELIMINADO FROM SASHAILO.Rol WHERE NOMBRE ='" + NombreRol.Text + "'");
                if (consulta2.Read())
                {
                    if (consulta2.GetString(1) == "S") // Solo hago un update
                        return 2;
                    else
                        MessageBox.Show("El rol " + NombreRol.Text + " ya se encuentra en el sistema", "Error");
                        return 3;
                }
                    
                cn.desconectar();
                
                return 4;
                    
            }
        }
        

        public void guardarDatos(int modo)
        {
            Conexion conn = new Conexion();
            if (modo == 4)
            {   
                // Creo la entrada en la tabla Rol
                conn.consultar("INSERT INTO SASHAILO.Rol (NOMBRE, HABILITADO) VALUES ('" + NombreRol.Text + "', '" + si_no(Habilitado) + "')");
                conn.desconectar();

                execSP(4);
                
                MessageBox.Show("Rol creado correctamente", "Alta de Rol");
                
            }
            else if (modo == 2)
            {
                conn.consultar("UPDATE SASHAILO.Rol SET HABILITADO = '" + si_no(Habilitado) + "', ELIMINADO = 'N' where NOMBRE = '" + NombreRol.Text + "'");

                execSP(2);

                MessageBox.Show("Rol creado correctamente", "Alta de Rol");
            }

            conn.desconectar();
        }

        private void execSP(int mode)
        {
            Conexion conn = new Conexion();
            SqlCommand sp_rol;

            // Creo las entradas en la tabla FuncionxRol
            if (mode == 4)
            {
                sp_rol = new SqlCommand("SASHAILO.rol_alta", conn.miConexion);
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
                FuncionListadoEstadistico.Value = Convert.ToByte(ConsultaPuntos.Checked);

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

            }
            else if (mode == 2)
            {
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
                FuncionListadoEstadistico.Value = Convert.ToByte(ConsultaPuntos.Checked);

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

            }
            conn.desconectar();
        }


        private string si_no(CheckBox chbox)
        {
            if (chbox.Checked == false)
                return "N";
            else
                return "S";
        }

        private void botonCancelar_Click(object sender, EventArgs e)
        {
            Alta_rol.ActiveForm.Close();
        }

        private void botonGuardar_Click(object sender, EventArgs e)
        {
            int verif = verificarDatos();
            if (verif == 1 || verif == 3)
                return;
            guardarDatos(verif);
            botonGuardar.Enabled = false;
            botonGuardar.Text = "Guardado";
            Alta_rol.ActiveForm.Close();                              
        }



    }
}
