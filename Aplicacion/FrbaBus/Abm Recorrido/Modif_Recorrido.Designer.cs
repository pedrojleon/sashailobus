namespace FrbaBus.Abm_Recorrido
{
    partial class Modif_Recorrido
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(Modif_Recorrido));
            this.label6 = new System.Windows.Forms.Label();
            this.edit_base_kg = new System.Windows.Forms.PictureBox();
            this.edit_base_pasaje = new System.Windows.Forms.PictureBox();
            this.button1 = new System.Windows.Forms.Button();
            this.label5 = new System.Windows.Forms.Label();
            this.base_kg = new System.Windows.Forms.TextBox();
            this.tipo_servicio = new System.Windows.Forms.ComboBox();
            this.base_pasaje = new System.Windows.Forms.TextBox();
            this.label3 = new System.Windows.Forms.Label();
            this.label4 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.label1 = new System.Windows.Forms.Label();
            this.destino = new System.Windows.Forms.ComboBox();
            this.origen = new System.Windows.Forms.ComboBox();
            ((System.ComponentModel.ISupportInitialize)(this.edit_base_kg)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.edit_base_pasaje)).BeginInit();
            this.SuspendLayout();
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Italic, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label6.ForeColor = System.Drawing.SystemColors.ControlDarkDark;
            this.label6.Location = new System.Drawing.Point(19, 167);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(627, 13);
            this.label6.TabIndex = 27;
            this.label6.Text = "Los precios base que ingrese se impactarán en todos los registros cuyas ciudades " +
                "origen y destino coincidan con las seleccionadas";
            // 
            // edit_base_kg
            // 
            this.edit_base_kg.Image = ((System.Drawing.Image)(resources.GetObject("edit_base_kg.Image")));
            this.edit_base_kg.InitialImage = ((System.Drawing.Image)(resources.GetObject("edit_base_kg.InitialImage")));
            this.edit_base_kg.Location = new System.Drawing.Point(508, 113);
            this.edit_base_kg.Name = "edit_base_kg";
            this.edit_base_kg.Size = new System.Drawing.Size(22, 21);
            this.edit_base_kg.TabIndex = 26;
            this.edit_base_kg.TabStop = false;
            this.edit_base_kg.Visible = false;
            // 
            // edit_base_pasaje
            // 
            this.edit_base_pasaje.Image = ((System.Drawing.Image)(resources.GetObject("edit_base_pasaje.Image")));
            this.edit_base_pasaje.InitialImage = ((System.Drawing.Image)(resources.GetObject("edit_base_pasaje.InitialImage")));
            this.edit_base_pasaje.Location = new System.Drawing.Point(508, 76);
            this.edit_base_pasaje.Name = "edit_base_pasaje";
            this.edit_base_pasaje.Size = new System.Drawing.Size(22, 21);
            this.edit_base_pasaje.TabIndex = 25;
            this.edit_base_pasaje.TabStop = false;
            this.edit_base_pasaje.Visible = false;
            // 
            // button1
            // 
            this.button1.Location = new System.Drawing.Point(181, 111);
            this.button1.Name = "button1";
            this.button1.Size = new System.Drawing.Size(75, 23);
            this.button1.TabIndex = 24;
            this.button1.Text = "Guardar";
            this.button1.UseVisualStyleBackColor = true;
            this.button1.Click += new System.EventHandler(this.button1_Click);
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Location = new System.Drawing.Point(334, 115);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(85, 13);
            this.label5.TabIndex = 23;
            this.label5.Text = "Precio Base KG:";
            // 
            // base_kg
            // 
            this.base_kg.AcceptsReturn = true;
            this.base_kg.Location = new System.Drawing.Point(436, 113);
            this.base_kg.Name = "base_kg";
            this.base_kg.Size = new System.Drawing.Size(64, 20);
            this.base_kg.TabIndex = 22;
            this.base_kg.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.base_kg_KeyPress);
            // 
            // tipo_servicio
            // 
            this.tipo_servicio.FormattingEnabled = true;
            this.tipo_servicio.Location = new System.Drawing.Point(161, 76);
            this.tipo_servicio.Name = "tipo_servicio";
            this.tipo_servicio.Size = new System.Drawing.Size(151, 21);
            this.tipo_servicio.TabIndex = 19;
            // 
            // base_pasaje
            // 
            this.base_pasaje.AcceptsReturn = true;
            this.base_pasaje.Location = new System.Drawing.Point(436, 76);
            this.base_pasaje.Name = "base_pasaje";
            this.base_pasaje.Size = new System.Drawing.Size(64, 20);
            this.base_pasaje.TabIndex = 21;
            this.base_pasaje.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.base_pasaje_KeyPress);
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(68, 79);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(87, 13);
            this.label3.TabIndex = 18;
            this.label3.Text = "Tipo de Servicio:";
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(334, 79);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(102, 13);
            this.label4.TabIndex = 20;
            this.label4.Text = "Precio Base Pasaje:";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(334, 39);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(82, 13);
            this.label2.TabIndex = 17;
            this.label2.Text = "Ciudad Destino:";
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(69, 39);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(77, 13);
            this.label1.TabIndex = 16;
            this.label1.Text = "Ciudad Origen:";
            // 
            // destino
            // 
            this.destino.FormattingEnabled = true;
            this.destino.Location = new System.Drawing.Point(436, 36);
            this.destino.Name = "destino";
            this.destino.Size = new System.Drawing.Size(151, 21);
            this.destino.TabIndex = 15;
            // 
            // origen
            // 
            this.origen.FormattingEnabled = true;
            this.origen.Location = new System.Drawing.Point(161, 36);
            this.origen.Name = "origen";
            this.origen.Size = new System.Drawing.Size(151, 21);
            this.origen.TabIndex = 14;
            // 
            // Modif_Recorrido
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(671, 192);
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
            this.Name = "Modif_Recorrido";
            this.Text = "Modificación de Recorrido";
            ((System.ComponentModel.ISupportInitialize)(this.edit_base_kg)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.edit_base_pasaje)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label label6;
        private System.Windows.Forms.PictureBox edit_base_kg;
        private System.Windows.Forms.PictureBox edit_base_pasaje;
        private System.Windows.Forms.Button button1;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.TextBox base_kg;
        private System.Windows.Forms.ComboBox tipo_servicio;
        private System.Windows.Forms.TextBox base_pasaje;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.ComboBox destino;
        private System.Windows.Forms.ComboBox origen;
    }
}