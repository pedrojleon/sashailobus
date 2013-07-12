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
            this.mp_abms = new System.Windows.Forms.ToolStripMenuItem();
            this.mnu_abm_rol = new System.Windows.Forms.ToolStripMenuItem();
            this.mnu_abm_ciudad = new System.Windows.Forms.ToolStripMenuItem();
            this.mnu_abm_reco = new System.Windows.Forms.ToolStripMenuItem();
            this.mnu_abm_micro = new System.Windows.Forms.ToolStripMenuItem();
            this.mp_viajes = new System.Windows.Forms.ToolStripMenuItem();
            this.mnu_gen_viaje = new System.Windows.Forms.ToolStripMenuItem();
            this.mnu_reg_llega = new System.Windows.Forms.ToolStripMenuItem();
            this.mp_pasajes = new System.Windows.Forms.ToolStripMenuItem();
            this.mnu_compra_pas = new System.Windows.Forms.ToolStripMenuItem();
            this.mnu_dev_pas = new System.Windows.Forms.ToolStripMenuItem();
            this.mp_pasajeros = new System.Windows.Forms.ToolStripMenuItem();
            this.mnu_consul_puntos = new System.Windows.Forms.ToolStripMenuItem();
            this.mp_estadisticas = new System.Windows.Forms.ToolStripMenuItem();
            this.mnu_listado_est = new System.Windows.Forms.ToolStripMenuItem();
            this.MenuIngresar = new System.Windows.Forms.ToolStripMenuItem();
            this.MenuSalir = new System.Windows.Forms.ToolStripMenuItem();
            this.CuadroLogin = new System.Windows.Forms.GroupBox();
            this.mnu_canje_puntos = new System.Windows.Forms.ToolStripMenuItem();
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
            this.mp_abms,
            this.mp_viajes,
            this.mp_pasajes,
            this.mp_pasajeros,
            this.mp_estadisticas,
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
            // mp_abms
            // 
            this.mp_abms.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.mnu_abm_rol,
            this.mnu_abm_ciudad,
            this.mnu_abm_reco,
            this.mnu_abm_micro});
            this.mp_abms.Name = "mp_abms";
            this.mp_abms.Size = new System.Drawing.Size(54, 20);
            this.mp_abms.Text = "ABM\'S";
            this.mp_abms.Visible = false;
            // 
            // mnu_abm_rol
            // 
            this.mnu_abm_rol.Name = "mnu_abm_rol";
            this.mnu_abm_rol.Size = new System.Drawing.Size(170, 22);
            this.mnu_abm_rol.Text = "ABM de Rol";
            this.mnu_abm_rol.Click += new System.EventHandler(this.aBMDeRolToolStripMenuItem_Click);
            // 
            // mnu_abm_ciudad
            // 
            this.mnu_abm_ciudad.Name = "mnu_abm_ciudad";
            this.mnu_abm_ciudad.Size = new System.Drawing.Size(170, 22);
            this.mnu_abm_ciudad.Text = "ABM de Ciudad";
            this.mnu_abm_ciudad.Click += new System.EventHandler(this.aBMDeCiudadToolStripMenuItem_Click);
            // 
            // mnu_abm_reco
            // 
            this.mnu_abm_reco.Name = "mnu_abm_reco";
            this.mnu_abm_reco.Size = new System.Drawing.Size(170, 22);
            this.mnu_abm_reco.Text = "ABM de Recorrido";
            this.mnu_abm_reco.Click += new System.EventHandler(this.aBMDeRecorridoToolStripMenuItem_Click);
            // 
            // mnu_abm_micro
            // 
            this.mnu_abm_micro.Name = "mnu_abm_micro";
            this.mnu_abm_micro.Size = new System.Drawing.Size(170, 22);
            this.mnu_abm_micro.Text = "ABM de Micro";
            this.mnu_abm_micro.Click += new System.EventHandler(this.aBMDeMicroToolStripMenuItem_Click);
            // 
            // mp_viajes
            // 
            this.mp_viajes.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.mnu_gen_viaje,
            this.mnu_reg_llega});
            this.mp_viajes.Name = "mp_viajes";
            this.mp_viajes.Size = new System.Drawing.Size(49, 20);
            this.mp_viajes.Text = "Viajes";
            this.mp_viajes.Visible = false;
            // 
            // mnu_gen_viaje
            // 
            this.mnu_gen_viaje.Name = "mnu_gen_viaje";
            this.mnu_gen_viaje.Size = new System.Drawing.Size(226, 22);
            this.mnu_gen_viaje.Text = "Generación de Viaje";
            this.mnu_gen_viaje.Click += new System.EventHandler(this.generaciónDeViajeToolStripMenuItem_Click);
            // 
            // mnu_reg_llega
            // 
            this.mnu_reg_llega.Name = "mnu_reg_llega";
            this.mnu_reg_llega.Size = new System.Drawing.Size(226, 22);
            this.mnu_reg_llega.Text = "Registro de llegada a Destino";
            this.mnu_reg_llega.Click += new System.EventHandler(this.registroDeLlegadaADestinoToolStripMenuItem_Click);
            // 
            // mp_pasajes
            // 
            this.mp_pasajes.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.mnu_compra_pas,
            this.mnu_dev_pas});
            this.mp_pasajes.Name = "mp_pasajes";
            this.mp_pasajes.Size = new System.Drawing.Size(57, 20);
            this.mp_pasajes.Text = "Pasajes";
            // 
            // mnu_compra_pas
            // 
            this.mnu_compra_pas.Name = "mnu_compra_pas";
            this.mnu_compra_pas.Size = new System.Drawing.Size(337, 22);
            this.mnu_compra_pas.Text = "Compra de Pasajes/Encomiendas";
            this.mnu_compra_pas.Click += new System.EventHandler(this.compraDePasajesEncomiendasToolStripMenuItem_Click);
            // 
            // mnu_dev_pas
            // 
            this.mnu_dev_pas.Name = "mnu_dev_pas";
            this.mnu_dev_pas.Size = new System.Drawing.Size(337, 22);
            this.mnu_dev_pas.Text = "Devolución/Cancelación de pasajes/Encomiendas";
            this.mnu_dev_pas.Click += new System.EventHandler(this.devoluciónCancelaciónDePasajesEncomiendasToolStripMenuItem_Click);
            // 
            // mp_pasajeros
            // 
            this.mp_pasajeros.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.mnu_consul_puntos,
            this.mnu_canje_puntos});
            this.mp_pasajeros.Name = "mp_pasajeros";
            this.mp_pasajeros.Size = new System.Drawing.Size(68, 20);
            this.mp_pasajeros.Text = "Pasajeros";
            // 
            // mnu_consul_puntos
            // 
            this.mnu_consul_puntos.Name = "mnu_consul_puntos";
            this.mnu_consul_puntos.Size = new System.Drawing.Size(177, 22);
            this.mnu_consul_puntos.Text = "Consulta de Puntos";
            this.mnu_consul_puntos.Click += new System.EventHandler(this.consultaDePuntosToolStripMenuItem_Click);
            // 
            // mp_estadisticas
            // 
            this.mp_estadisticas.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.mnu_listado_est});
            this.mp_estadisticas.Name = "mp_estadisticas";
            this.mp_estadisticas.Size = new System.Drawing.Size(79, 20);
            this.mp_estadisticas.Text = "Estadísticas";
            this.mp_estadisticas.Visible = false;
            // 
            // mnu_listado_est
            // 
            this.mnu_listado_est.Name = "mnu_listado_est";
            this.mnu_listado_est.Size = new System.Drawing.Size(171, 22);
            this.mnu_listado_est.Text = "Listado Estadístico";
            this.mnu_listado_est.Click += new System.EventHandler(this.listadoEstadísticoToolStripMenuItem_Click);
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
            // mnu_canje_puntos
            // 
            this.mnu_canje_puntos.Name = "mnu_canje_puntos";
            this.mnu_canje_puntos.Size = new System.Drawing.Size(177, 22);
            this.mnu_canje_puntos.Text = "Canje de Puntos";
            this.mnu_canje_puntos.Click += new System.EventHandler(this.canjeDePuntosToolStripMenuItem_Click);
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
        private System.Windows.Forms.ToolStripMenuItem mp_abms;
        private System.Windows.Forms.ToolStripMenuItem mnu_abm_rol;
        private System.Windows.Forms.ToolStripMenuItem mnu_abm_ciudad;
        private System.Windows.Forms.ToolStripMenuItem mnu_abm_reco;
        private System.Windows.Forms.ToolStripMenuItem mnu_abm_micro;
        private System.Windows.Forms.ToolStripMenuItem mp_viajes;
        private System.Windows.Forms.ToolStripMenuItem mnu_gen_viaje;
        private System.Windows.Forms.ToolStripMenuItem mnu_reg_llega;
        private System.Windows.Forms.ToolStripMenuItem mp_pasajes;
        private System.Windows.Forms.ToolStripMenuItem mnu_compra_pas;
        private System.Windows.Forms.ToolStripMenuItem mnu_dev_pas;
        private System.Windows.Forms.ToolStripMenuItem mp_pasajeros;
        private System.Windows.Forms.ToolStripMenuItem mnu_consul_puntos;
        private System.Windows.Forms.ToolStripMenuItem mp_estadisticas;
        private System.Windows.Forms.ToolStripMenuItem mnu_listado_est;
        private System.Windows.Forms.GroupBox CuadroLogin;
        private System.Windows.Forms.ToolStripMenuItem MenuSalir;
        private System.Windows.Forms.ToolStripMenuItem MenuIngresar;
        private System.Windows.Forms.ToolStripMenuItem mnu_canje_puntos;
    }
}