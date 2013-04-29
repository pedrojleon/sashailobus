namespace FrbaBus.Login
{
    partial class Login
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(Login));
            this.button1 = new System.Windows.Forms.Button();
            this.password = new System.Windows.Forms.TextBox();
            this.label2 = new System.Windows.Forms.Label();
            this.label1 = new System.Windows.Forms.Label();
            this.usuario = new System.Windows.Forms.TextBox();
            this.menuStrip1 = new System.Windows.Forms.MenuStrip();
            this.toolStripMenuItem1 = new System.Windows.Forms.ToolStripMenuItem();
            this.MenuABMS = new System.Windows.Forms.ToolStripMenuItem();
            this.aBMDeRolToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.aBMDeCiudadToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.aBMDeRecorridoToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.aBMDeMicroToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.MenuViajes = new System.Windows.Forms.ToolStripMenuItem();
            this.generaciónDeViajeToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.registroDeLlegadaADestinoToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.pasajesToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.compraDePasajesEncomiendasToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.devoluciónCancelaciónDePasajesEncomiendasToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.pasajerosToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.consultaDePuntosToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.MenuEstadisticas = new System.Windows.Forms.ToolStripMenuItem();
            this.listadoEstadísticoToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.MenuIngresar = new System.Windows.Forms.ToolStripMenuItem();
            this.MenuSalir = new System.Windows.Forms.ToolStripMenuItem();
            this.CuadroLogin = new System.Windows.Forms.GroupBox();
            this.menuStrip1.SuspendLayout();
            this.CuadroLogin.SuspendLayout();
            this.SuspendLayout();
            // 
            // button1
            // 
            this.button1.Location = new System.Drawing.Point(101, 70);
            this.button1.Name = "button1";
            this.button1.Size = new System.Drawing.Size(53, 20);
            this.button1.TabIndex = 11;
            this.button1.Text = "Ingresar";
            this.button1.UseVisualStyleBackColor = true;
            this.button1.Click += new System.EventHandler(this.button1_Click);
            // 
            // password
            // 
            this.password.Location = new System.Drawing.Point(70, 44);
            this.password.Name = "password";
            this.password.Size = new System.Drawing.Size(84, 20);
            this.password.TabIndex = 9;
            this.password.UseSystemPasswordChar = true;
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.BackColor = System.Drawing.Color.Transparent;
            this.label2.Location = new System.Drawing.Point(3, 47);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(61, 13);
            this.label2.TabIndex = 8;
            this.label2.Text = "Contraseña";
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.BackColor = System.Drawing.Color.Transparent;
            this.label1.Location = new System.Drawing.Point(21, 21);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(43, 13);
            this.label1.TabIndex = 7;
            this.label1.Text = "Usuario";
            // 
            // usuario
            // 
            this.usuario.Location = new System.Drawing.Point(70, 18);
            this.usuario.Name = "usuario";
            this.usuario.Size = new System.Drawing.Size(84, 20);
            this.usuario.TabIndex = 6;
            // 
            // menuStrip1
            // 
            this.menuStrip1.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.toolStripMenuItem1,
            this.MenuABMS,
            this.MenuViajes,
            this.pasajesToolStripMenuItem,
            this.pasajerosToolStripMenuItem,
            this.MenuEstadisticas,
            this.MenuIngresar,
            this.MenuSalir});
            this.menuStrip1.Location = new System.Drawing.Point(0, 0);
            this.menuStrip1.Name = "menuStrip1";
            this.menuStrip1.Size = new System.Drawing.Size(487, 24);
            this.menuStrip1.TabIndex = 12;
            this.menuStrip1.Text = "menuStrip1";
            // 
            // toolStripMenuItem1
            // 
            this.toolStripMenuItem1.Name = "toolStripMenuItem1";
            this.toolStripMenuItem1.Size = new System.Drawing.Size(12, 20);
            // 
            // MenuABMS
            // 
            this.MenuABMS.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.aBMDeRolToolStripMenuItem,
            this.aBMDeCiudadToolStripMenuItem,
            this.aBMDeRecorridoToolStripMenuItem,
            this.aBMDeMicroToolStripMenuItem});
            this.MenuABMS.Name = "MenuABMS";
            this.MenuABMS.Size = new System.Drawing.Size(54, 20);
            this.MenuABMS.Text = "ABM\'S";
            this.MenuABMS.Visible = false;
            // 
            // aBMDeRolToolStripMenuItem
            // 
            this.aBMDeRolToolStripMenuItem.Name = "aBMDeRolToolStripMenuItem";
            this.aBMDeRolToolStripMenuItem.Size = new System.Drawing.Size(170, 22);
            this.aBMDeRolToolStripMenuItem.Text = "ABM de Rol";
            this.aBMDeRolToolStripMenuItem.Click += new System.EventHandler(this.aBMDeRolToolStripMenuItem_Click);
            // 
            // aBMDeCiudadToolStripMenuItem
            // 
            this.aBMDeCiudadToolStripMenuItem.Name = "aBMDeCiudadToolStripMenuItem";
            this.aBMDeCiudadToolStripMenuItem.Size = new System.Drawing.Size(170, 22);
            this.aBMDeCiudadToolStripMenuItem.Text = "ABM de Ciudad";
            this.aBMDeCiudadToolStripMenuItem.Click += new System.EventHandler(this.aBMDeCiudadToolStripMenuItem_Click);
            // 
            // aBMDeRecorridoToolStripMenuItem
            // 
            this.aBMDeRecorridoToolStripMenuItem.Name = "aBMDeRecorridoToolStripMenuItem";
            this.aBMDeRecorridoToolStripMenuItem.Size = new System.Drawing.Size(170, 22);
            this.aBMDeRecorridoToolStripMenuItem.Text = "ABM de Recorrido";
            // 
            // aBMDeMicroToolStripMenuItem
            // 
            this.aBMDeMicroToolStripMenuItem.Name = "aBMDeMicroToolStripMenuItem";
            this.aBMDeMicroToolStripMenuItem.Size = new System.Drawing.Size(170, 22);
            this.aBMDeMicroToolStripMenuItem.Text = "ABM de Micro";
            // 
            // MenuViajes
            // 
            this.MenuViajes.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.generaciónDeViajeToolStripMenuItem,
            this.registroDeLlegadaADestinoToolStripMenuItem});
            this.MenuViajes.Name = "MenuViajes";
            this.MenuViajes.Size = new System.Drawing.Size(49, 20);
            this.MenuViajes.Text = "Viajes";
            this.MenuViajes.Visible = false;
            // 
            // generaciónDeViajeToolStripMenuItem
            // 
            this.generaciónDeViajeToolStripMenuItem.Name = "generaciónDeViajeToolStripMenuItem";
            this.generaciónDeViajeToolStripMenuItem.Size = new System.Drawing.Size(226, 22);
            this.generaciónDeViajeToolStripMenuItem.Text = "Generación de Viaje";
            // 
            // registroDeLlegadaADestinoToolStripMenuItem
            // 
            this.registroDeLlegadaADestinoToolStripMenuItem.Name = "registroDeLlegadaADestinoToolStripMenuItem";
            this.registroDeLlegadaADestinoToolStripMenuItem.Size = new System.Drawing.Size(226, 22);
            this.registroDeLlegadaADestinoToolStripMenuItem.Text = "Registro de llegada a Destino";
            // 
            // pasajesToolStripMenuItem
            // 
            this.pasajesToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.compraDePasajesEncomiendasToolStripMenuItem,
            this.devoluciónCancelaciónDePasajesEncomiendasToolStripMenuItem});
            this.pasajesToolStripMenuItem.Name = "pasajesToolStripMenuItem";
            this.pasajesToolStripMenuItem.Size = new System.Drawing.Size(57, 20);
            this.pasajesToolStripMenuItem.Text = "Pasajes";
            // 
            // compraDePasajesEncomiendasToolStripMenuItem
            // 
            this.compraDePasajesEncomiendasToolStripMenuItem.Name = "compraDePasajesEncomiendasToolStripMenuItem";
            this.compraDePasajesEncomiendasToolStripMenuItem.Size = new System.Drawing.Size(337, 22);
            this.compraDePasajesEncomiendasToolStripMenuItem.Text = "Compra de Pasajes/Encomiendas";
            // 
            // devoluciónCancelaciónDePasajesEncomiendasToolStripMenuItem
            // 
            this.devoluciónCancelaciónDePasajesEncomiendasToolStripMenuItem.Name = "devoluciónCancelaciónDePasajesEncomiendasToolStripMenuItem";
            this.devoluciónCancelaciónDePasajesEncomiendasToolStripMenuItem.Size = new System.Drawing.Size(337, 22);
            this.devoluciónCancelaciónDePasajesEncomiendasToolStripMenuItem.Text = "Devolución/Cancelación de pasajes/Encomiendas";
            // 
            // pasajerosToolStripMenuItem
            // 
            this.pasajerosToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.consultaDePuntosToolStripMenuItem});
            this.pasajerosToolStripMenuItem.Name = "pasajerosToolStripMenuItem";
            this.pasajerosToolStripMenuItem.Size = new System.Drawing.Size(68, 20);
            this.pasajerosToolStripMenuItem.Text = "Pasajeros";
            // 
            // consultaDePuntosToolStripMenuItem
            // 
            this.consultaDePuntosToolStripMenuItem.Name = "consultaDePuntosToolStripMenuItem";
            this.consultaDePuntosToolStripMenuItem.Size = new System.Drawing.Size(177, 22);
            this.consultaDePuntosToolStripMenuItem.Text = "Consulta de Puntos";
            // 
            // MenuEstadisticas
            // 
            this.MenuEstadisticas.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.listadoEstadísticoToolStripMenuItem});
            this.MenuEstadisticas.Name = "MenuEstadisticas";
            this.MenuEstadisticas.Size = new System.Drawing.Size(79, 20);
            this.MenuEstadisticas.Text = "Estadísticas";
            this.MenuEstadisticas.Visible = false;
            // 
            // listadoEstadísticoToolStripMenuItem
            // 
            this.listadoEstadísticoToolStripMenuItem.Name = "listadoEstadísticoToolStripMenuItem";
            this.listadoEstadísticoToolStripMenuItem.Size = new System.Drawing.Size(171, 22);
            this.listadoEstadísticoToolStripMenuItem.Text = "Listado Estadístico";
            // 
            // MenuIngresar
            // 
            this.MenuIngresar.AutoSize = false;
            this.MenuIngresar.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(192)))), ((int)(((byte)(0)))));
            this.MenuIngresar.Name = "MenuIngresar";
            this.MenuIngresar.Size = new System.Drawing.Size(61, 20);
            this.MenuIngresar.Text = "Ingresar";
            this.MenuIngresar.Click += new System.EventHandler(this.inToolStripMenuItem_Click);
            // 
            // MenuSalir
            // 
            this.MenuSalir.ForeColor = System.Drawing.Color.Red;
            this.MenuSalir.Name = "MenuSalir";
            this.MenuSalir.Size = new System.Drawing.Size(41, 20);
            this.MenuSalir.Text = "Salir";
            this.MenuSalir.Visible = false;
            this.MenuSalir.Click += new System.EventHandler(this.MenuSalir_Click);
            // 
            // CuadroLogin
            // 
            this.CuadroLogin.Controls.Add(this.password);
            this.CuadroLogin.Controls.Add(this.button1);
            this.CuadroLogin.Controls.Add(this.usuario);
            this.CuadroLogin.Controls.Add(this.label1);
            this.CuadroLogin.Controls.Add(this.label2);
            this.CuadroLogin.Location = new System.Drawing.Point(313, 21);
            this.CuadroLogin.Name = "CuadroLogin";
            this.CuadroLogin.Size = new System.Drawing.Size(167, 100);
            this.CuadroLogin.TabIndex = 13;
            this.CuadroLogin.TabStop = false;
            this.CuadroLogin.Visible = false;
            // 
            // Login
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(487, 283);
            this.Controls.Add(this.CuadroLogin);
            this.Controls.Add(this.menuStrip1);
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.MainMenuStrip = this.menuStrip1;
            this.Name = "Login";
            this.Text = "Sashailo Bus";
            this.menuStrip1.ResumeLayout(false);
            this.menuStrip1.PerformLayout();
            this.CuadroLogin.ResumeLayout(false);
            this.CuadroLogin.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Button button1;
        private System.Windows.Forms.TextBox password;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.TextBox usuario;
        private System.Windows.Forms.MenuStrip menuStrip1;
        private System.Windows.Forms.ToolStripMenuItem toolStripMenuItem1;
        private System.Windows.Forms.ToolStripMenuItem MenuABMS;
        private System.Windows.Forms.ToolStripMenuItem aBMDeRolToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem aBMDeCiudadToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem aBMDeRecorridoToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem aBMDeMicroToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem MenuViajes;
        private System.Windows.Forms.ToolStripMenuItem generaciónDeViajeToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem registroDeLlegadaADestinoToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem pasajesToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem compraDePasajesEncomiendasToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem devoluciónCancelaciónDePasajesEncomiendasToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem pasajerosToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem consultaDePuntosToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem MenuEstadisticas;
        private System.Windows.Forms.ToolStripMenuItem listadoEstadísticoToolStripMenuItem;
        private System.Windows.Forms.GroupBox CuadroLogin;
        private System.Windows.Forms.ToolStripMenuItem MenuSalir;
        private System.Windows.Forms.ToolStripMenuItem MenuIngresar;
    }
}