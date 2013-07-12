namespace FrbaBus.Abm_Permisos
{
    partial class Alta_rol
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(Alta_rol));
            this.NombreRol = new System.Windows.Forms.TextBox();
            this.label1 = new System.Windows.Forms.Label();
            this.botonGuardar = new System.Windows.Forms.Button();
            this.ABMRol = new System.Windows.Forms.CheckBox();
            this.ABMCiudad = new System.Windows.Forms.CheckBox();
            this.ABMRecorrido = new System.Windows.Forms.CheckBox();
            this.ABMMicro = new System.Windows.Forms.CheckBox();
            this.GeneracionViaje = new System.Windows.Forms.CheckBox();
            this.RegistroLlegada = new System.Windows.Forms.CheckBox();
            this.CompraPasaje = new System.Windows.Forms.CheckBox();
            this.Devolucion = new System.Windows.Forms.CheckBox();
            this.ListadoEstadistico = new System.Windows.Forms.CheckBox();
            this.ConsultaPuntos = new System.Windows.Forms.CheckBox();
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.CanjePuntos = new System.Windows.Forms.CheckBox();
            this.groupBox1.SuspendLayout();
            this.SuspendLayout();
            // 
            // NombreRol
            // 
            this.NombreRol.Location = new System.Drawing.Point(114, 19);
            this.NombreRol.Name = "NombreRol";
            this.NombreRol.Size = new System.Drawing.Size(120, 20);
            this.NombreRol.TabIndex = 0;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(28, 22);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(80, 13);
            this.label1.TabIndex = 1;
            this.label1.Text = "Nombre del Rol";
            // 
            // botonGuardar
            // 
            this.botonGuardar.Location = new System.Drawing.Point(150, 250);
            this.botonGuardar.Name = "botonGuardar";
            this.botonGuardar.Size = new System.Drawing.Size(75, 23);
            this.botonGuardar.TabIndex = 4;
            this.botonGuardar.Text = "Guardar";
            this.botonGuardar.UseVisualStyleBackColor = true;
            this.botonGuardar.Click += new System.EventHandler(this.botonGuardar_Click);
            // 
            // ABMRol
            // 
            this.ABMRol.AutoSize = true;
            this.ABMRol.Location = new System.Drawing.Point(46, 77);
            this.ABMRol.Name = "ABMRol";
            this.ABMRol.Size = new System.Drawing.Size(83, 17);
            this.ABMRol.TabIndex = 6;
            this.ABMRol.Text = "ABM de Rol";
            this.ABMRol.UseVisualStyleBackColor = true;
            // 
            // ABMCiudad
            // 
            this.ABMCiudad.AutoSize = true;
            this.ABMCiudad.Location = new System.Drawing.Point(46, 100);
            this.ABMCiudad.Name = "ABMCiudad";
            this.ABMCiudad.Size = new System.Drawing.Size(100, 17);
            this.ABMCiudad.TabIndex = 7;
            this.ABMCiudad.Text = "ABM de Ciudad";
            this.ABMCiudad.UseVisualStyleBackColor = true;
            // 
            // ABMRecorrido
            // 
            this.ABMRecorrido.AutoSize = true;
            this.ABMRecorrido.Location = new System.Drawing.Point(46, 123);
            this.ABMRecorrido.Name = "ABMRecorrido";
            this.ABMRecorrido.Size = new System.Drawing.Size(113, 17);
            this.ABMRecorrido.TabIndex = 8;
            this.ABMRecorrido.Text = "ABM de Recorrido";
            this.ABMRecorrido.UseVisualStyleBackColor = true;
            // 
            // ABMMicro
            // 
            this.ABMMicro.AutoSize = true;
            this.ABMMicro.Location = new System.Drawing.Point(46, 147);
            this.ABMMicro.Name = "ABMMicro";
            this.ABMMicro.Size = new System.Drawing.Size(93, 17);
            this.ABMMicro.TabIndex = 9;
            this.ABMMicro.Text = "ABM de Micro";
            this.ABMMicro.UseVisualStyleBackColor = true;
            // 
            // GeneracionViaje
            // 
            this.GeneracionViaje.AutoSize = true;
            this.GeneracionViaje.Location = new System.Drawing.Point(46, 170);
            this.GeneracionViaje.Name = "GeneracionViaje";
            this.GeneracionViaje.Size = new System.Drawing.Size(122, 17);
            this.GeneracionViaje.TabIndex = 10;
            this.GeneracionViaje.Text = "Generación de Viaje";
            this.GeneracionViaje.UseVisualStyleBackColor = true;
            // 
            // RegistroLlegada
            // 
            this.RegistroLlegada.AutoSize = true;
            this.RegistroLlegada.Location = new System.Drawing.Point(179, 77);
            this.RegistroLlegada.Name = "RegistroLlegada";
            this.RegistroLlegada.Size = new System.Drawing.Size(121, 17);
            this.RegistroLlegada.TabIndex = 12;
            this.RegistroLlegada.Text = "Registro de Llegada";
            this.RegistroLlegada.UseVisualStyleBackColor = true;
            // 
            // CompraPasaje
            // 
            this.CompraPasaje.AutoSize = true;
            this.CompraPasaje.Location = new System.Drawing.Point(179, 100);
            this.CompraPasaje.Name = "CompraPasaje";
            this.CompraPasaje.Size = new System.Drawing.Size(176, 17);
            this.CompraPasaje.TabIndex = 13;
            this.CompraPasaje.Text = "Compra de Pasaje/Encomienda";
            this.CompraPasaje.TextAlign = System.Drawing.ContentAlignment.TopRight;
            this.CompraPasaje.UseVisualStyleBackColor = true;
            // 
            // Devolucion
            // 
            this.Devolucion.AutoSize = true;
            this.Devolucion.Location = new System.Drawing.Point(179, 123);
            this.Devolucion.Name = "Devolucion";
            this.Devolucion.Size = new System.Drawing.Size(144, 17);
            this.Devolucion.TabIndex = 14;
            this.Devolucion.Text = "Devolución/Cancelación";
            this.Devolucion.UseVisualStyleBackColor = true;
            // 
            // ListadoEstadistico
            // 
            this.ListadoEstadistico.AutoSize = true;
            this.ListadoEstadistico.Location = new System.Drawing.Point(179, 170);
            this.ListadoEstadistico.Name = "ListadoEstadistico";
            this.ListadoEstadistico.Size = new System.Drawing.Size(116, 17);
            this.ListadoEstadistico.TabIndex = 15;
            this.ListadoEstadistico.Text = "Listado Estadístico";
            this.ListadoEstadistico.UseVisualStyleBackColor = true;
            // 
            // ConsultaPuntos
            // 
            this.ConsultaPuntos.AutoSize = true;
            this.ConsultaPuntos.Location = new System.Drawing.Point(179, 147);
            this.ConsultaPuntos.Name = "ConsultaPuntos";
            this.ConsultaPuntos.Size = new System.Drawing.Size(118, 17);
            this.ConsultaPuntos.TabIndex = 16;
            this.ConsultaPuntos.Text = "Consulta de Puntos";
            this.ConsultaPuntos.UseVisualStyleBackColor = true;
            // 
            // groupBox1
            // 
            this.groupBox1.Controls.Add(this.CanjePuntos);
            this.groupBox1.Location = new System.Drawing.Point(31, 52);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size(326, 180);
            this.groupBox1.TabIndex = 17;
            this.groupBox1.TabStop = false;
            this.groupBox1.Text = "Funcionalidades";
            // 
            // CanjePuntos
            // 
            this.CanjePuntos.AutoSize = true;
            this.CanjePuntos.Location = new System.Drawing.Point(15, 141);
            this.CanjePuntos.Name = "CanjePuntos";
            this.CanjePuntos.Size = new System.Drawing.Size(104, 17);
            this.CanjePuntos.TabIndex = 16;
            this.CanjePuntos.Text = "Canje de Puntos";
            this.CanjePuntos.UseVisualStyleBackColor = true;
            // 
            // Alta_rol
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(389, 290);
            this.Controls.Add(this.ConsultaPuntos);
            this.Controls.Add(this.ListadoEstadistico);
            this.Controls.Add(this.Devolucion);
            this.Controls.Add(this.CompraPasaje);
            this.Controls.Add(this.RegistroLlegada);
            this.Controls.Add(this.GeneracionViaje);
            this.Controls.Add(this.ABMMicro);
            this.Controls.Add(this.ABMRecorrido);
            this.Controls.Add(this.ABMCiudad);
            this.Controls.Add(this.ABMRol);
            this.Controls.Add(this.botonGuardar);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.NombreRol);
            this.Controls.Add(this.groupBox1);
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.MaximizeBox = false;
            this.Name = "Alta_rol";
            this.Text = "Alta de Rol";
            this.groupBox1.ResumeLayout(false);
            this.groupBox1.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.TextBox NombreRol;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Button botonGuardar;
        private System.Windows.Forms.CheckBox ABMRol;
        private System.Windows.Forms.CheckBox ABMCiudad;
        private System.Windows.Forms.CheckBox ABMRecorrido;
        private System.Windows.Forms.CheckBox ABMMicro;
        private System.Windows.Forms.CheckBox GeneracionViaje;
        private System.Windows.Forms.CheckBox RegistroLlegada;
        private System.Windows.Forms.CheckBox CompraPasaje;
        private System.Windows.Forms.CheckBox Devolucion;
        private System.Windows.Forms.CheckBox ListadoEstadistico;
        private System.Windows.Forms.CheckBox ConsultaPuntos;
        private System.Windows.Forms.GroupBox groupBox1;
        private System.Windows.Forms.CheckBox CanjePuntos;
    }
}