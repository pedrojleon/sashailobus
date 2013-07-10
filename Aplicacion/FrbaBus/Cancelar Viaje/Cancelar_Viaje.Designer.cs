namespace FrbaBus.Cancelar_Viaje
{
    partial class Cancelar_Viaje
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(Cancelar_Viaje));
            this.b_guardar = new System.Windows.Forms.Button();
            this.groupBox2 = new System.Windows.Forms.GroupBox();
            this.encomienda = new System.Windows.Forms.TextBox();
            this.label5 = new System.Windows.Forms.Label();
            this.compra = new System.Windows.Forms.TextBox();
            this.label3 = new System.Windows.Forms.Label();
            this.pasaje = new System.Windows.Forms.TextBox();
            this.label1 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.motivo = new System.Windows.Forms.RichTextBox();
            this.label4 = new System.Windows.Forms.Label();
            this.groupBox2.SuspendLayout();
            this.SuspendLayout();
            // 
            // b_guardar
            // 
            this.b_guardar.Location = new System.Drawing.Point(152, 202);
            this.b_guardar.Name = "b_guardar";
            this.b_guardar.Size = new System.Drawing.Size(75, 23);
            this.b_guardar.TabIndex = 4;
            this.b_guardar.Text = "Guardar";
            this.b_guardar.UseVisualStyleBackColor = true;
            this.b_guardar.Click += new System.EventHandler(this.b_guardar_Click);
            // 
            // groupBox2
            // 
            this.groupBox2.Controls.Add(this.label4);
            this.groupBox2.Controls.Add(this.motivo);
            this.groupBox2.Controls.Add(this.label2);
            this.groupBox2.Controls.Add(this.b_guardar);
            this.groupBox2.Controls.Add(this.encomienda);
            this.groupBox2.Controls.Add(this.label5);
            this.groupBox2.Controls.Add(this.compra);
            this.groupBox2.Controls.Add(this.label3);
            this.groupBox2.Controls.Add(this.pasaje);
            this.groupBox2.Controls.Add(this.label1);
            this.groupBox2.Location = new System.Drawing.Point(26, 23);
            this.groupBox2.Name = "groupBox2";
            this.groupBox2.Size = new System.Drawing.Size(421, 256);
            this.groupBox2.TabIndex = 2;
            this.groupBox2.TabStop = false;
            this.groupBox2.Text = "Datos de la Cancelación";
            // 
            // encomienda
            // 
            this.encomienda.Location = new System.Drawing.Point(152, 83);
            this.encomienda.Name = "encomienda";
            this.encomienda.Size = new System.Drawing.Size(83, 20);
            this.encomienda.TabIndex = 2;
            this.encomienda.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.encomienda_KeyPress);
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Location = new System.Drawing.Point(26, 86);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(120, 13);
            this.label5.TabIndex = 6;
            this.label5.Text = "Código de Encomienda:";
            // 
            // compra
            // 
            this.compra.Location = new System.Drawing.Point(152, 31);
            this.compra.Name = "compra";
            this.compra.Size = new System.Drawing.Size(83, 20);
            this.compra.TabIndex = 0;
            this.compra.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.compra_KeyPress);
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.ForeColor = System.Drawing.Color.Green;
            this.label3.Location = new System.Drawing.Point(26, 34);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(97, 13);
            this.label3.TabIndex = 4;
            this.label3.Text = "Código de Compra:";
            // 
            // pasaje
            // 
            this.pasaje.Location = new System.Drawing.Point(152, 56);
            this.pasaje.Name = "pasaje";
            this.pasaje.Size = new System.Drawing.Size(83, 20);
            this.pasaje.TabIndex = 1;
            this.pasaje.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.pasaje_KeyPress);
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(26, 59);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(93, 13);
            this.label1.TabIndex = 0;
            this.label1.Text = "Código de Pasaje:";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.ForeColor = System.Drawing.Color.Red;
            this.label2.Location = new System.Drawing.Point(239, 36);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(11, 13);
            this.label2.TabIndex = 7;
            this.label2.Text = "*";
            this.label2.Click += new System.EventHandler(this.label2_Click);
            // 
            // motivo
            // 
            this.motivo.Location = new System.Drawing.Point(152, 109);
            this.motivo.Name = "motivo";
            this.motivo.Size = new System.Drawing.Size(242, 71);
            this.motivo.TabIndex = 3;
            this.motivo.Text = "";
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(26, 140);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(42, 13);
            this.label4.TabIndex = 9;
            this.label4.Text = "Motivo:";
            // 
            // Cancelar_Viaje
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(482, 319);
            this.Controls.Add(this.groupBox2);
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.Name = "Cancelar_Viaje";
            this.groupBox2.ResumeLayout(false);
            this.groupBox2.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Button b_guardar;
        private System.Windows.Forms.GroupBox groupBox2;
        private System.Windows.Forms.TextBox encomienda;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.TextBox compra;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.TextBox pasaje;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.RichTextBox motivo;
    }
}