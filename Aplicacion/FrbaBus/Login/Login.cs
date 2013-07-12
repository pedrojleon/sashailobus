using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using System.Data.SqlClient;

namespace FrbaBus.Login
{
    public partial class Login : Form
    {
        string username;
        bool logueado;

        public Login()
        {
            InitializeComponent();
        }

        private void inToolStripMenuItem_Click(object sender, EventArgs e)
        {
            CuadroLogin.Visible = !CuadroLogin.Visible;
            this.logueado = false;
            usuario.Focus();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            if (usuario.Text.Trim().CompareTo("") == 0 || password.Text.Trim().CompareTo("") == 0) {
                MessageBox.Show("Debe ingresar Usuario y Contraseña", "Error", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                return;
            }

            Funciones funciones = new Funciones();

            Conexion conn = new Conexion();
            SqlCommand sp_login;

            sp_login = new SqlCommand("SASHAILO.login", conn.miConexion); // Lo inicializo
            sp_login.CommandType = CommandType.StoredProcedure; // Defino que tipo de comando es
            SqlParameter USERNAME = sp_login.Parameters.Add("@p_usuario", SqlDbType.VarChar, 15);
            SqlParameter PASSWORD = sp_login.Parameters.Add("@p_password", SqlDbType.VarChar, 64);
            SqlParameter HAY_ERROR = sp_login.Parameters.Add("@hayErr", SqlDbType.Int);
            SqlParameter ERRORES = sp_login.Parameters.Add("@errores", SqlDbType.VarChar, 200);

            USERNAME.Value = usuario.Text.Trim();
            PASSWORD.Value = funciones.encriptarClave(password.Text.Trim());
            HAY_ERROR.Direction = ParameterDirection.Output;
            ERRORES.Direction = ParameterDirection.Output;

            try
            {
                sp_login.ExecuteNonQuery();
                int hayError = Convert.ToInt16(sp_login.Parameters["@hayErr"].Value.ToString());
                if (hayError == 1)
                {
                    string errores = sp_login.Parameters["@errores"].Value.ToString();
                    MessageBox.Show(errores, null, MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                    conn.desconectar();
                    return;
                }

            }
            catch (Exception error)
            {
                MessageBox.Show(error.ToString(), null, MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                conn.desconectar();
                return;
            }

            //se logueó correctamente, muestro las entradas de menu de los administradores
            MenuIngresar.Visible = false;
            MenuSalir.Visible = true;
            CuadroLogin.Visible = false;

            loguear(usuario.Text.Trim());

        }

        private void loguear(string usuario)
        {

            this.username = usuario;
            this.logueado = true;


            /*Seguridad - Evaluo el acceso a los menues*/

            bool tiene_abm_rol = tieneFuncion(usuario, 1);
            bool tiene_abm_ciudad = tieneFuncion(usuario, 2);
            bool tiene_abm_reco = tieneFuncion(usuario, 3);
            bool tiene_abm_micro = tieneFuncion(usuario, 4);
            bool tiene_gen_viaje = tieneFuncion(usuario, 5);
            bool tiene_reg_llegada = tieneFuncion(usuario, 6);
            bool tiene_compra_pas = tieneFuncion(usuario, 7);
            bool tiene_devo_pas = tieneFuncion(usuario, 8);
            bool tiene_consul_ptos = tieneFuncion(usuario, 9);
            bool tiene_list_est = tieneFuncion(usuario, 10);
            bool tiene_canje_ptos = tieneFuncion(usuario, 11);


            mnu_abm_rol.Visible = tiene_abm_rol;
            mnu_abm_ciudad.Visible = tiene_abm_ciudad;
            mnu_abm_reco.Visible = tiene_abm_reco;
            mnu_abm_micro.Visible = tiene_abm_micro;

            mnu_gen_viaje.Visible = tiene_gen_viaje;
            mnu_reg_llega.Visible = tiene_reg_llegada;

            mnu_compra_pas.Visible = tiene_compra_pas;
            mnu_dev_pas.Visible = tiene_devo_pas;

            mnu_consul_puntos.Visible = tiene_consul_ptos;
            mnu_canje_puntos.Visible = tiene_canje_ptos;

            mnu_listado_est.Visible = tiene_list_est;


            mp_abms.Visible = (tiene_abm_rol || tiene_abm_ciudad || tiene_abm_reco || tiene_abm_micro);
            mp_viajes.Visible = (tiene_gen_viaje || tiene_reg_llegada);
            mp_pasajes.Visible = (tiene_compra_pas || tiene_devo_pas);
            mp_pasajeros.Visible = (tiene_consul_ptos || tiene_canje_ptos);
            mp_estadisticas.Visible = tiene_list_est;

        }

        public bool tieneFuncion(string usuario, int id_funcion)
        {

            bool tiene_funcion = false;
            Conexion cn = new Conexion();
            string sql = "select case when exists ( " +
                                      "select 1 from SASHAILO.Usuario us " +
                                      "join SASHAILO.RolxUsuario rxu on rxu.ID_USUARIO=us.ID_USUARIO " +
                                      "join SASHAILO.Rol r on rxu.ID_ROL=r.ID_ROL " +
                                      "join SASHAILO.FuncionxRol fr on r.ID_ROL=fr.ID_ROL " +
                                      "join SASHAILO.Funcion f on fr.ID_FUNCION=f.ID_FUNCION " +
                                      "where us.USUARIO='" + usuario.Trim() + "' and " +
                                      "f.ID_FUNCION=" + id_funcion + " ) " +
                                 "then 1 else 0 end 'TIENE FUNCION'";

            SqlDataReader consulta = cn.consultar(sql);
            if (consulta.Read())
            {
                tiene_funcion = (consulta.GetInt32(0) == 1) ? true : false;
            }
            cn.desconectar();

            return tiene_funcion;

        }

        private void MenuSalir_Click(object sender, EventArgs e)
        {
            mp_abms.Visible = false;
            mp_estadisticas.Visible = false;
            mp_viajes.Visible = false;
            MenuIngresar.Visible = true;
            MenuSalir.Visible = false;
            usuario.Text = "";
            password.Text = "";
            CuadroLogin.Visible = true;
            this.username = null;
            this.logueado = false;
        }

        private void aBMDeRolToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Abm_Permisos.ABMRol abm_rol = new Abm_Permisos.ABMRol();
            abm_rol.Tag = this; //guardo en Tag una referencia a mi formulario
            abm_rol.ShowDialog();
        }

        private void aBMDeCiudadToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Abm_Ciudad.Abm_Ciudad abm_ciudad = new Abm_Ciudad.Abm_Ciudad();
            abm_ciudad.Tag = this; //guardo en Tag una referencia a mi formulario
            abm_ciudad.ShowDialog();
        }

        private void aBMDeRecorridoToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Abm_Recorrido.ABM_Recorrido abm = new Abm_Recorrido.ABM_Recorrido();
            abm.Tag = this; //guardo en Tag una referencia a mi formulario
            abm.ShowDialog();
        }

        private void aBMDeMicroToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Abm_Micro.ABM_Micro abm = new Abm_Micro.ABM_Micro();
            abm.Tag = this; //guardo en Tag una referencia a mi formulario
            abm.ShowDialog();
        }

        private void generaciónDeViajeToolStripMenuItem_Click(object sender, EventArgs e)
        {
            GenerarViaje.Generar_Viaje abm = new GenerarViaje.Generar_Viaje();
            abm.Tag = this; //guardo en Tag una referencia a mi formulario
            abm.ShowDialog();
        }

        private void registroDeLlegadaADestinoToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Registrar_LLegada_Micro.Registro_Llegada abm = new Registrar_LLegada_Micro.Registro_Llegada();
            abm.Tag = this; //guardo en Tag una referencia a mi formulario
            abm.ShowDialog();
        }

        private void compraDePasajesEncomiendasToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Compra_de_Pasajes.Compra_Pasaje abm = new Compra_de_Pasajes.Compra_Pasaje(this.logueado);
            abm.Tag = this; //guardo en Tag una referencia a mi formulario
            abm.ShowDialog();
        }

        private void devoluciónCancelaciónDePasajesEncomiendasToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Cancelar_Viaje.Cancelar_Viaje abm = new Cancelar_Viaje.Cancelar_Viaje();
            abm.Tag = this; //guardo en Tag una referencia a mi formulario
            abm.ShowDialog();
        }

        private void consultaDePuntosToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Consulta_Puntos_Adquiridos.Consulta_Puntos abm = new Consulta_Puntos_Adquiridos.Consulta_Puntos();
            abm.Tag = this; //guardo en Tag una referencia a mi formulario
            abm.ShowDialog();
        }

        private void canjeDePuntosToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Canje_de_Ptos.Canje_Puntos abm = new Canje_de_Ptos.Canje_Puntos();
            abm.Tag = this; //guardo en Tag una referencia a mi formulario
            abm.ShowDialog();
        }

        private void listadoEstadísticoToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Estadisticas.Listado_Estadistico abm = new Estadisticas.Listado_Estadistico();
            abm.Tag = this; //guardo en Tag una referencia a mi formulario
            abm.ShowDialog();
        }
    }
}
