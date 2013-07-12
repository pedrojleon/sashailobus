using System;
using System.Collections.Generic;
using System.Linq;
using System.Windows.Forms;

namespace FrbaBus
{
    static class Program
    {
        /// <summary>
        /// The main entry point for the application.
        /// </summary>
        [STAThread]
        static void Main()
        {

            Application.EnableVisualStyles();
            Application.SetCompatibleTextRenderingDefault(false);

            Application.Run(new Login.Login());
            //Application.Run(new Abm_Permisos.ABMRol());
            //Application.Run(new GenerarViaje.Generar_Viaje());
            //Application.Run(new Compra_de_Pasajes.Compra_Pasaje());
            //Application.Run(new Registrar_LLegada_Micro.Registro_Llegada());
            //Application.Run(new Abm_Recorrido.ABM_Recorrido());
            //Application.Run(new GenerarViaje.Seleccionar_Recorrido());
            //Application.Run(new GenerarViaje.Generar_Viaje());
            //Application.Run(new Compra_de_Pasajes.Compra_Pasaje());
            //Application.Run(new Abm_Micro.ABM_Micro());
            //Application.Run(new Compra_de_Pasajes.Finalizar_Compra(null, null, null));
            //Application.Run(new Abm_Ciudad.Abm_Ciudad());
        }
    }
}
