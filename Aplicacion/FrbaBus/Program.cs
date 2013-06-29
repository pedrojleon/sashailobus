﻿using System;
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
            //Application.Run(new Abm_Micro.ABM_Micro());
            //Application.Run(new Abm_Recorrido.ABM_Recorrido());
            //Application.Run(new GenerarViaje.Seleccionar_Recorrido());
            //Application.Run(new GenerarViaje.Generar_Viaje());
            Application.Run(new Compra_de_Pasajes.Compra_Pasaje());
            //Application.Run(new Abm_Ciudad.Abm_Ciudad());
        }
    }
}
