namespace FrbaBus.Registrar_LLegada_Micro
{
    partial class Registro_Llegada
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(Registro_Llegada));
            this.label2 = new System.Windows.Forms.Label();
            this.label1 = new System.Windows.Forms.Label();
            this.destino = new System.Windows.Forms.ComboBox();
            this.origen = new System.Windows.Forms.ComboBox();
            this.f_llegada = new System.Windows.Forms.GroupBox();
            this.patente = new System.Windows.Forms.TextBox();
            this.label4 = new System.Windows.Forms.Label();
            this.button1 = new System.Windows.Forms.Button();
            this.label7 = new System.Windows.Forms.Label();
            this.f_llegada_real = new System.Windows.Forms.DateTimePicker();
            this.label3 = new System.Windows.Forms.Label();
            this.h_llegada = new System.Windows.Forms.DateTimePicker();
            this.f_llegada.SuspendLayout();
            this.SuspendLayout();
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(24, 149);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(88, 13);
            this.label2.TabIndex = 7;
            this.label2.Text = "Ciudad de Arribo:";
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(24, 112);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(90, 13);
            this.label1.TabIndex = 6;
            this.label1.Text = "Ciudad de Salida:";
            // 
            // destino
            // 
            this.destino.FormattingEnabled = true;
            this.destino.Location = new System.Drawing.Point(126, 146);
            this.destino.Name = "destino";
            this.destino.Size = new System.Drawing.Size(146, 21);
            this.destino.TabIndex = 4;
            // 
            // origen
            // 
            this.origen.FormattingEnabled = true;
            this.origen.Location = new System.Drawing.Point(126, 109);
            this.origen.Name = "origen";
            this.origen.Size = new System.Drawing.Size(146, 21);
            this.origen.TabIndex = 3;
            // 
            // f_llegada
            // 
            this.f_llegada.Controls.Add(this.h_llegada);
            this.f_llegada.Controls.Add(this.f_llegada_real);
            this.f_llegada.Controls.Add(this.label3);
            this.f_llegada.Controls.Add(this.label7);
            this.f_llegada.Controls.Add(this.button1);
            this.f_llegada.Controls.Add(this.patente);
            this.f_llegada.Controls.Add(this.label4);
            this.f_llegada.Controls.Add(this.label1);
            this.f_llegada.Controls.Add(this.label2);
            this.f_llegada.Controls.Add(this.origen);
            this.f_llegada.Controls.Add(this.destino);
            this.f_llegada.Location = new System.Drawing.Point(32, 24);
            this.f_llegada.Name = "f_llegada";
            this.f_llegada.Size = new System.Drawing.Size(348, 250);
            this.f_llegada.TabIndex = 8;
            this.f_llegada.TabStop = false;
            this.f_llegada.Text = "Datos del Viaje";
            // 
            // patente
            // 
            this.patente.AcceptsReturn = true;
            this.patente.Location = new System.Drawing.Point(126, 36);
            this.patente.Name = "patente";
            this.patente.Size = new System.Drawing.Size(64, 20);
            this.patente.TabIndex = 0;
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(24, 39);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(93, 13);
            this.label4.TabIndex = 8;
            this.label4.Text = "Patente del Micro:";
            // 
            // button1
            // 
            this.button1.Location = new System.Drawing.Point(139, 201);
            this.button1.Name = "button1";
            this.button1.Size = new System.Drawing.Size(75, 23);
            this.button1.TabIndex = 5;
            this.button1.Text = "Guardar";
            this.button1.UseVisualStyleBackColor = true;
            this.button1.Click += new System.EventHandler(this.button1_Click);
            // 
            // label7
            // 
            this.label7.AutoSize = true;
            this.label7.ForeColor = System.Drawing.SystemColors.ControlDark;
            this.label7.Location = new System.Drawing.Point(196, 39);
            this.label7.Name = "label7";
            this.label7.Size = new System.Drawing.Size(69, 13);
            this.label7.TabIndex = 32;
            this.label7.Text = "Ej: WSR-097";
            // 
            // f_llegada_real
            // 
            this.f_llegada_real.Location = new System.Drawing.Point(126, 73);
            this.f_llegada_real.Name = "f_llegada_real";
            this.f_llegada_real.Size = new System.Drawing.Size(146, 20);
            this.f_llegada_real.TabIndex = 1;
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(24, 76);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(100, 13);
            this.label3.TabIndex = 55;
            this.label3.Text = "Fecha de LLegada:";
            // 
            // h_llegada
            // 
            this.h_llegada.Location = new System.Drawing.Point(278, 73);
            this.h_llegada.Name = "h_llegada";
            this.h_llegada.Size = new System.Drawing.Size(49, 20);
            this.h_llegada.TabIndex = 2;
            // 
            // Registro_Llegada
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(422, 307);
            this.Controls.Add(this.f_llegada);
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.Name = "Registro_Llegada";
            this.Text = "Registro de Llegada a Destino";
            this.f_llegada.ResumeLayout(false);
            this.f_llegada.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.ComboBox destino;
        private System.Windows.Forms.ComboBox origen;
        private System.Windows.Forms.GroupBox f_llegada;
        private System.Windows.Forms.TextBox patente;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.Button button1;
        private System.Windows.Forms.Label label7;
        private System.Windows.Forms.DateTimePicker f_llegada_real;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.DateTimePicker h_llegada;
    }
}