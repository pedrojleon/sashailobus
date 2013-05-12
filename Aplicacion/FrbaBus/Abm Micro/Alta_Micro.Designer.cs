namespace FrbaBus.Abm_Micro
{
    partial class Alta_Micro
    {
        /// <summary>
        /// Variable del diseñador requerida.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Limpiar los recursos que se estén utilizando.
        /// </summary>
        /// <param name="disposing">true si los recursos administrados se deben eliminar; false en caso contrario, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Código generado por el Diseñador de Windows Forms

        /// <summary>
        /// Método necesario para admitir el Diseñador. No se puede modificar
        /// el contenido del método con el editor de código.
        /// </summary>
        private void InitializeComponent()
        {
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(Alta_Micro));
            this.button1 = new System.Windows.Forms.Button();
            this.label5 = new System.Windows.Forms.Label();
            this.modelo = new System.Windows.Forms.TextBox();
            this.label_f_actual = new System.Windows.Forms.Label();
            this.label4 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.label1 = new System.Windows.Forms.Label();
            this.combo_marca = new System.Windows.Forms.ComboBox();
            this.combo_servicio = new System.Windows.Forms.ComboBox();
            this.label_nro_micro = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.fuera_servicio = new System.Windows.Forms.CheckBox();
            this.patente = new System.Windows.Forms.TextBox();
            this.label6 = new System.Windows.Forms.Label();
            this.label7 = new System.Windows.Forms.Label();
            this.label11 = new System.Windows.Forms.Label();
            this.combo_pisos = new System.Windows.Forms.ComboBox();
            this.cant_kg = new System.Windows.Forms.TextBox();
            this.label16 = new System.Windows.Forms.Label();
            this.flowLayoutPanel1 = new System.Windows.Forms.FlowLayoutPanel();
            this.SuspendLayout();
            // 
            // button1
            // 
            this.button1.Location = new System.Drawing.Point(53, 344);
            this.button1.Name = "button1";
            this.button1.Size = new System.Drawing.Size(75, 23);
            this.button1.TabIndex = 23;
            this.button1.Text = "Guardar";
            this.button1.UseVisualStyleBackColor = true;
            this.button1.Click += new System.EventHandler(this.button1_Click);
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Location = new System.Drawing.Point(239, 37);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(56, 13);
            this.label5.TabIndex = 22;
            this.label5.Text = "Nro Micro:";
            // 
            // modelo
            // 
            this.modelo.AcceptsReturn = true;
            this.modelo.Location = new System.Drawing.Point(101, 141);
            this.modelo.Name = "modelo";
            this.modelo.Size = new System.Drawing.Size(94, 20);
            this.modelo.TabIndex = 21;
            // 
            // label_f_actual
            // 
            this.label_f_actual.AutoSize = true;
            this.label_f_actual.ForeColor = System.Drawing.SystemColors.ControlDark;
            this.label_f_actual.Location = new System.Drawing.Point(129, 37);
            this.label_f_actual.Name = "label_f_actual";
            this.label_f_actual.Size = new System.Drawing.Size(69, 13);
            this.label_f_actual.TabIndex = 17;
            this.label_f_actual.Text = "dd/mm/aaaa";
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(50, 144);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(45, 13);
            this.label4.TabIndex = 19;
            this.label4.Text = "Modelo:";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(50, 178);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(87, 13);
            this.label2.TabIndex = 16;
            this.label2.Text = "Tipo de Servicio:";
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(47, 37);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(76, 13);
            this.label1.TabIndex = 15;
            this.label1.Text = "Fecha de Alta:";
            // 
            // combo_marca
            // 
            this.combo_marca.FormattingEnabled = true;
            this.combo_marca.Location = new System.Drawing.Point(101, 108);
            this.combo_marca.Name = "combo_marca";
            this.combo_marca.Size = new System.Drawing.Size(86, 21);
            this.combo_marca.TabIndex = 14;
            // 
            // combo_servicio
            // 
            this.combo_servicio.FormattingEnabled = true;
            this.combo_servicio.Location = new System.Drawing.Point(149, 175);
            this.combo_servicio.Name = "combo_servicio";
            this.combo_servicio.Size = new System.Drawing.Size(94, 21);
            this.combo_servicio.TabIndex = 13;
            // 
            // label_nro_micro
            // 
            this.label_nro_micro.AutoSize = true;
            this.label_nro_micro.ForeColor = System.Drawing.SystemColors.ControlDark;
            this.label_nro_micro.Location = new System.Drawing.Point(301, 37);
            this.label_nro_micro.Name = "label_nro_micro";
            this.label_nro_micro.Size = new System.Drawing.Size(10, 13);
            this.label_nro_micro.TabIndex = 26;
            this.label_nro_micro.Text = "-";
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(50, 111);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(40, 13);
            this.label3.TabIndex = 27;
            this.label3.Text = "Marca:";
            // 
            // fuera_servicio
            // 
            this.fuera_servicio.AutoSize = true;
            this.fuera_servicio.Location = new System.Drawing.Point(53, 292);
            this.fuera_servicio.Name = "fuera_servicio";
            this.fuera_servicio.Size = new System.Drawing.Size(109, 17);
            this.fuera_servicio.TabIndex = 28;
            this.fuera_servicio.Text = "Fuera de Servicio";
            this.fuera_servicio.UseVisualStyleBackColor = true;
            // 
            // patente
            // 
            this.patente.AcceptsReturn = true;
            this.patente.Location = new System.Drawing.Point(101, 71);
            this.patente.Name = "patente";
            this.patente.Size = new System.Drawing.Size(86, 20);
            this.patente.TabIndex = 30;
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.Location = new System.Drawing.Point(50, 74);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(47, 13);
            this.label6.TabIndex = 29;
            this.label6.Text = "Patente:";
            // 
            // label7
            // 
            this.label7.AutoSize = true;
            this.label7.ForeColor = System.Drawing.SystemColors.ControlDark;
            this.label7.Location = new System.Drawing.Point(194, 74);
            this.label7.Name = "label7";
            this.label7.Size = new System.Drawing.Size(69, 13);
            this.label7.TabIndex = 31;
            this.label7.Text = "Ej: WSR-097";
            // 
            // label11
            // 
            this.label11.AutoSize = true;
            this.label11.Location = new System.Drawing.Point(50, 213);
            this.label11.Name = "label11";
            this.label11.Size = new System.Drawing.Size(35, 13);
            this.label11.TabIndex = 38;
            this.label11.Text = "Pisos:";
            // 
            // combo_pisos
            // 
            this.combo_pisos.FormattingEnabled = true;
            this.combo_pisos.Location = new System.Drawing.Point(101, 210);
            this.combo_pisos.Name = "combo_pisos";
            this.combo_pisos.Size = new System.Drawing.Size(60, 21);
            this.combo_pisos.TabIndex = 39;
            // 
            // cant_kg
            // 
            this.cant_kg.AcceptsReturn = true;
            this.cant_kg.Location = new System.Drawing.Point(101, 247);
            this.cant_kg.Name = "cant_kg";
            this.cant_kg.Size = new System.Drawing.Size(60, 20);
            this.cant_kg.TabIndex = 43;
            this.cant_kg.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.cant_kg_KeyPress);
            // 
            // label16
            // 
            this.label16.AutoSize = true;
            this.label16.ForeColor = System.Drawing.SystemColors.ActiveCaptionText;
            this.label16.Location = new System.Drawing.Point(50, 250);
            this.label16.Name = "label16";
            this.label16.Size = new System.Drawing.Size(50, 13);
            this.label16.TabIndex = 42;
            this.label16.Text = "Cant KG:";
            // 
            // flowLayoutPanel1
            // 
            this.flowLayoutPanel1.AutoScroll = true;
            this.flowLayoutPanel1.BackColor = System.Drawing.SystemColors.ButtonFace;
            this.flowLayoutPanel1.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.flowLayoutPanel1.Location = new System.Drawing.Point(304, 74);
            this.flowLayoutPanel1.Name = "flowLayoutPanel1";
            this.flowLayoutPanel1.Size = new System.Drawing.Size(359, 330);
            this.flowLayoutPanel1.TabIndex = 46;
            // 
            // Alta_Micro
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(720, 438);
            this.Controls.Add(this.flowLayoutPanel1);
            this.Controls.Add(this.cant_kg);
            this.Controls.Add(this.label16);
            this.Controls.Add(this.combo_pisos);
            this.Controls.Add(this.label11);
            this.Controls.Add(this.label7);
            this.Controls.Add(this.patente);
            this.Controls.Add(this.label6);
            this.Controls.Add(this.fuera_servicio);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.label_nro_micro);
            this.Controls.Add(this.button1);
            this.Controls.Add(this.label5);
            this.Controls.Add(this.modelo);
            this.Controls.Add(this.label_f_actual);
            this.Controls.Add(this.label4);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.combo_marca);
            this.Controls.Add(this.combo_servicio);
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.Name = "Alta_Micro";
            this.Text = "Alta de Micro";
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Button button1;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.TextBox modelo;
        private System.Windows.Forms.Label label_f_actual;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.ComboBox combo_marca;
        private System.Windows.Forms.ComboBox combo_servicio;
        private System.Windows.Forms.Label label_nro_micro;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.CheckBox fuera_servicio;
        private System.Windows.Forms.TextBox patente;
        private System.Windows.Forms.Label label6;
        private System.Windows.Forms.Label label7;
        private System.Windows.Forms.Label label11;
        private System.Windows.Forms.ComboBox combo_pisos;
        private System.Windows.Forms.TextBox cant_kg;
        private System.Windows.Forms.Label label16;
        private System.Windows.Forms.FlowLayoutPanel flowLayoutPanel1;
    }
}