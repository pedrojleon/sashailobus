using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using System.Security.Cryptography;
using System.Data.SqlClient;
using System.Configuration;

namespace FrbaBus
{
    public partial class Funciones : Form
    {
        public Funciones()
        {
            InitializeComponent();
        }

        public string encriptarClave(string clave)
        {
            byte[] tmpSource;
            byte[] tmpHash;
            string claveEncriptada;
            tmpSource = ASCIIEncoding.ASCII.GetBytes(clave);
            SHA256 shaM = new SHA256Managed();
            tmpHash = shaM.ComputeHash(tmpSource);
            claveEncriptada = BitConverter.ToString(tmpHash);
            return claveEncriptada;
        }

        public void soloNumeros(KeyPressEventArgs e)
        {
            char ch = e.KeyChar;
            if (!Char.IsDigit(ch) && ch != 8)
            {
                e.Handled = true;
            }
        }

        public void soloNumerosPuntosyComas(KeyPressEventArgs e)
        {
            char ch = e.KeyChar;
            if (!Char.IsDigit(ch) && ch != 8 && ch != 44 && ch != 46)
            {
                e.Handled = true;
            }
        }

        public DateTime getFechaActual()
        {
            DateTime fecha_actual = Convert.ToDateTime(ConfigurationSettings.AppSettings["fechaActual"]);
            return fecha_actual;
        }

    }
}
