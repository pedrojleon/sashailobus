using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using System.Security.Cryptography;

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
    }
}
