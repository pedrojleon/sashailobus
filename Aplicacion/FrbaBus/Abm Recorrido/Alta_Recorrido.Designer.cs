namespace FrbaBus.Abm_Recorrido
{
    partial class Alta_Recorrido
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(Alta_Recorrido));
            this.origen = new System.Windows.Forms.ComboBox();
            this.destino = new System.Windows.Forms.ComboBox();
            this.label1 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.tipo_servicio = new System.Windows.Forms.ComboBox();
            this.label4 = new System.Windows.Forms.Label();
            this.base_pasaje = new System.Windows.Forms.TextBox();
            this.base_kg = new System.Windows.Forms.TextBox();
            this.label5 = new System.Windows.Forms.Label();
            this.button1 = new System.Windows.Forms.Button();
            this.edit_base_pasaje = new System.Windows.Forms.PictureBox();
            this.edit_base_kg = new System.Windows.Forms.PictureBox();
            this.label6 = new System.Windows.Forms.Label();
            ((System.ComponentModel.ISupportInitialize)(this.edit_base_pasaje)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.edit_base_kg)).BeginInit();
            this.SuspendLayout();
            // 
            // origen
            // 
            this.origen.FormattingEnabled = true;
            this.origen.Location = new System.Drawing.Point(154, 31);
            this.origen.Name = "origen";
            this.origen.Size = new System.Drawing.Size(151, 21);
            this.origen.TabIndex = 0;
            this.origen.SelectedIndexChanged += new System.EventHandler(this.origen_SelectedIndexChanged);
            // 
            // destino
            // 
            this.destino.FormattingEnabled = true;
            this.destino.Location = new System.Drawing.Point(429, 31);
            this.destino.Name = "destino";
            this.destino.Size = new System.Drawing.Size(151, 21);
            this.destino.TabIndex = 1;
            this.destino.SelectedIndexChanged += new System.EventHandler(this.destino_SelectedIndexChanged);
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(62, 34);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(77, 13);
            this.label1.TabIndex = 2;
            this.label1.Text = "Ciudad Origen:";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(327, 34);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(82, 13);
            this.label2.TabIndex = 3;
            this.label2.Text = "Ciudad Destino:";
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(61, 74);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(87, 13);
            this.label3.TabIndex = 4;
            this.label3.Text = "Tipo de Servicio:";
            // 
            // tipo_servicio
            // 
            this.tipo_servicio.FormattingEnabled = true;
            this.tipo_servicio.Location = new System.Drawing.Point(154, 71);
            this.tipo_servicio.Name = "tipo_servicio";
            this.tipo_servicio.Size = new System.Drawing.Size(151, 21);
            this.tipo_servicio.TabIndex = 5;
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(327, 74);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(102, 13);
            this.label4.TabIndex = 6;
            this.label4.Text = "Precio Base Pasaje:";
            // 
            // base_pasaje
            // 
            this.base_pasaje.AcceptsReturn = true;
            this.base_pasaje.Location = new System.Drawing.Point(429, 71);
            this.base_pasaje.Name = "base_pasaje";
            this.base_pasaje.Size = new System.Drawing.Size(64, 20);
            this.base_pasaje.TabIndex = 7;
            // 
            // base_kg
            // 
            this.base_kg.AcceptsReturn = true;
            this.base_kg.Location = new System.Drawing.Point(429, 108);
            this.base_kg.Name = "base_kg";
            this.base_kg.Size = new System.Drawing.Size(64, 20);
            this.base_kg.TabIndex = 8;
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Location = new System.Drawing.Point(327, 110);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(85, 13);
            this.label5.TabIndex = 9;
            this.label5.Text = "Precio Base KG:";
            // 
            // button1
            // 
            this.button1.Location = new System.Drawing.Point(174, 106);
            this.button1.Name = "button1";
            this.button1.Size = new System.Drawing.Size(75, 23);
            this.button1.TabIndex = 10;
            this.button1.Text = "Guardar";
            this.button1.UseVisualStyleBackColor = true;
            this.button1.Click += new System.EventHandler(this.button1_Click);
            // 
            // edit_base_pasaje
            // 
            this.edit_base_pasaje.Image = ((System.Drawing.Image)(resources.GetObject("edit_base_pasaje.Image")));
            this.edit_base_pasaje.InitialImage = ((System.Drawing.Image)(resources.GetObject("edit_base_pasaje.InitialImage")));
            this.edit_base_pasaje.Location = new System.Drawing.Point(506, 76);
            this.edit_base_pasaje.Name = "edit_base_pasaje";
            this.edit_base_pasaje.Size = new System.Drawing.Size(15, 13);
            this.edit_base_pasaje.TabIndex = 11;
            this.edit_base_pasaje.TabStop = false;
            this.edit_base_pasaje.Visible = false;
            this.edit_base_pasaje.Click += new System.EventHandler(this.edit_base_pasaje_Click);
            // 
            // edit_base_kg
            // 
            this.edit_base_kg.Image = ((System.Drawing.Image)(resources.GetObject("edit_base_kg.Image")));
            this.edit_base_kg.InitialImage = ((System.Drawing.Image)(resources.GetObject("edit_base_kg.InitialImage")));
            this.edit_base_kg.Location = new System.Drawing.Point(506, 112);
            this.edit_base_kg.Name = "edit_base_kg";
            this.edit_base_kg.Size = new System.Drawing.Size(15, 13);
            this.edit_base_kg.TabIndex = 12;
            this.edit_base_kg.TabStop = false;
            this.edit_base_kg.Visible = false;
            this.edit_base_kg.Click += new System.EventHandler(this.edit_base_kg_Click);
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Italic, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label6.ForeColor = System.Drawing.SystemColors.ControlDarkDark;
            this.label6.Location = new System.Drawing.Point(12, 162);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(627, 13);
            this.label6.TabIndex = 13;
            this.label6.Text = "Los precios base que ingrese se impactarán en todos los registros cuyas ciudades " +
                "origen y destino coincidan con las seleccionadas";
            // 
            // Alta_Recorrido
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(658, 192);
            this.Controls.Add(this.label6);
            this.Controls.Add(this.edit_base_kg);
            this.Controls.Add(this.edit_base_pasaje);
            this.Controls.Add(this.button1);
            this.Controls.Add(this.label5);
            this.Controls.Add(this.base_kg);
            this.Controls.Add(this.tipo_servicio);
            this.Controls.Add(this.base_pasaje);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.label4);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.destino);
            this.Controls.Add(this.origen);
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.Name = "Alta_Recorrido";
            this.Text = "Alta de Recorrido";
            ((System.ComponentModel.ISupportInitialize)(this.edit_base_pasaje)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.edit_base_kg)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.ComboBox origen;
        private System.Windows.Forms.ComboBox destino;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.ComboBox tipo_servicio;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.TextBox base_kg;
        private System.Windows.Forms.TextBox base_pasaje;
        private System.Windows.Forms.Button button1;
        private System.Windows.Forms.PictureBox edit_base_pasaje;
        private System.Windows.Forms.PictureBox edit_base_kg;
        private System.Windows.Forms.Label label6;
    }
}