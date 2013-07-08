namespace FrbaBus
{
    partial class Funciones
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
            this.label_a = new System.Windows.Forms.Label();
            this.label_cod_compra = new System.Windows.Forms.Label();
            this.label_b = new System.Windows.Forms.Label();
            this.label_fecha_compra = new System.Windows.Forms.Label();
            this.label_c = new System.Windows.Forms.Label();
            this.label_cli_compra = new System.Windows.Forms.Label();
            this.label_d = new System.Windows.Forms.Label();
            this.label_importe_compra = new System.Windows.Forms.Label();
            this.gb_detalle_compra = new System.Windows.Forms.GroupBox();
            this.panel_pasajes = new System.Windows.Forms.Panel();
            this.label_e = new System.Windows.Forms.Label();
            this.label_f = new System.Windows.Forms.Label();
            this.panel_encomiendas = new System.Windows.Forms.Panel();
            this.gb_detalle_compra.SuspendLayout();
            this.SuspendLayout();
            // 
            // label_a
            // 
            this.label_a.AutoSize = true;
            this.label_a.Location = new System.Drawing.Point(24, 27);
            this.label_a.Name = "label_a";
            this.label_a.Size = new System.Drawing.Size(97, 13);
            this.label_a.TabIndex = 4;
            this.label_a.Text = "Código de Compra:";
            // 
            // label_cod_compra
            // 
            this.label_cod_compra.AutoSize = true;
            this.label_cod_compra.ForeColor = System.Drawing.Color.Green;
            this.label_cod_compra.Location = new System.Drawing.Point(126, 27);
            this.label_cod_compra.Name = "label_cod_compra";
            this.label_cod_compra.Size = new System.Drawing.Size(10, 13);
            this.label_cod_compra.TabIndex = 5;
            this.label_cod_compra.Text = "-";
            // 
            // label_b
            // 
            this.label_b.AutoSize = true;
            this.label_b.Location = new System.Drawing.Point(265, 27);
            this.label_b.Name = "label_b";
            this.label_b.Size = new System.Drawing.Size(40, 13);
            this.label_b.TabIndex = 6;
            this.label_b.Text = "Fecha:";
            // 
            // label_fecha_compra
            // 
            this.label_fecha_compra.AutoSize = true;
            this.label_fecha_compra.ForeColor = System.Drawing.Color.Green;
            this.label_fecha_compra.Location = new System.Drawing.Point(308, 27);
            this.label_fecha_compra.Name = "label_fecha_compra";
            this.label_fecha_compra.Size = new System.Drawing.Size(10, 13);
            this.label_fecha_compra.TabIndex = 7;
            this.label_fecha_compra.Text = "-";
            // 
            // label_c
            // 
            this.label_c.AutoSize = true;
            this.label_c.Location = new System.Drawing.Point(412, 27);
            this.label_c.Name = "label_c";
            this.label_c.Size = new System.Drawing.Size(42, 13);
            this.label_c.TabIndex = 12;
            this.label_c.Text = "Cliente:";
            // 
            // label_cli_compra
            // 
            this.label_cli_compra.AutoSize = true;
            this.label_cli_compra.ForeColor = System.Drawing.Color.Green;
            this.label_cli_compra.Location = new System.Drawing.Point(460, 27);
            this.label_cli_compra.Name = "label_cli_compra";
            this.label_cli_compra.Size = new System.Drawing.Size(10, 13);
            this.label_cli_compra.TabIndex = 13;
            this.label_cli_compra.Text = "-";
            // 
            // label_d
            // 
            this.label_d.AutoSize = true;
            this.label_d.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label_d.Location = new System.Drawing.Point(24, 56);
            this.label_d.Name = "label_d";
            this.label_d.Size = new System.Drawing.Size(53, 13);
            this.label_d.TabIndex = 18;
            this.label_d.Text = "Importe:";
            // 
            // label_importe_compra
            // 
            this.label_importe_compra.AutoSize = true;
            this.label_importe_compra.ForeColor = System.Drawing.Color.Green;
            this.label_importe_compra.Location = new System.Drawing.Point(83, 56);
            this.label_importe_compra.Name = "label_importe_compra";
            this.label_importe_compra.Size = new System.Drawing.Size(10, 13);
            this.label_importe_compra.TabIndex = 19;
            this.label_importe_compra.Text = "-";
            // 
            // gb_detalle_compra
            // 
            this.gb_detalle_compra.Controls.Add(this.label_f);
            this.gb_detalle_compra.Controls.Add(this.panel_encomiendas);
            this.gb_detalle_compra.Controls.Add(this.label_e);
            this.gb_detalle_compra.Controls.Add(this.panel_pasajes);
            this.gb_detalle_compra.Controls.Add(this.label_importe_compra);
            this.gb_detalle_compra.Controls.Add(this.label_d);
            this.gb_detalle_compra.Controls.Add(this.label_cli_compra);
            this.gb_detalle_compra.Controls.Add(this.label_c);
            this.gb_detalle_compra.Controls.Add(this.label_fecha_compra);
            this.gb_detalle_compra.Controls.Add(this.label_b);
            this.gb_detalle_compra.Controls.Add(this.label_cod_compra);
            this.gb_detalle_compra.Controls.Add(this.label_a);
            this.gb_detalle_compra.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.gb_detalle_compra.ForeColor = System.Drawing.SystemColors.ControlDarkDark;
            this.gb_detalle_compra.Location = new System.Drawing.Point(24, 12);
            this.gb_detalle_compra.Name = "gb_detalle_compra";
            this.gb_detalle_compra.Size = new System.Drawing.Size(669, 443);
            this.gb_detalle_compra.TabIndex = 9;
            this.gb_detalle_compra.TabStop = false;
            this.gb_detalle_compra.Text = "Detalle de la Compra";
            // 
            // panel_pasajes
            // 
            this.panel_pasajes.Location = new System.Drawing.Point(27, 122);
            this.panel_pasajes.Name = "panel_pasajes";
            this.panel_pasajes.Size = new System.Drawing.Size(612, 133);
            this.panel_pasajes.TabIndex = 20;
            // 
            // label_e
            // 
            this.label_e.AutoSize = true;
            this.label_e.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label_e.ForeColor = System.Drawing.SystemColors.ActiveCaptionText;
            this.label_e.Location = new System.Drawing.Point(26, 102);
            this.label_e.Name = "label_e";
            this.label_e.Size = new System.Drawing.Size(51, 13);
            this.label_e.TabIndex = 21;
            this.label_e.Text = "Pasajes";
            // 
            // label_f
            // 
            this.label_f.AutoSize = true;
            this.label_f.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label_f.ForeColor = System.Drawing.SystemColors.ActiveCaptionText;
            this.label_f.Location = new System.Drawing.Point(26, 265);
            this.label_f.Name = "label_f";
            this.label_f.Size = new System.Drawing.Size(82, 13);
            this.label_f.TabIndex = 23;
            this.label_f.Text = "Encomiendas";
            // 
            // panel_encomiendas
            // 
            this.panel_encomiendas.Location = new System.Drawing.Point(27, 285);
            this.panel_encomiendas.Name = "panel_encomiendas";
            this.panel_encomiendas.Size = new System.Drawing.Size(612, 133);
            this.panel_encomiendas.TabIndex = 22;
            // 
            // Funciones
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(724, 517);
            this.Controls.Add(this.gb_detalle_compra);
            this.Name = "Funciones";
            this.Text = "Funciones";
            this.gb_detalle_compra.ResumeLayout(false);
            this.gb_detalle_compra.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Label label_a;
        private System.Windows.Forms.Label label_cod_compra;
        private System.Windows.Forms.Label label_b;
        private System.Windows.Forms.Label label_fecha_compra;
        private System.Windows.Forms.Label label_c;
        private System.Windows.Forms.Label label_cli_compra;
        private System.Windows.Forms.Label label_d;
        private System.Windows.Forms.Label label_importe_compra;
        private System.Windows.Forms.GroupBox gb_detalle_compra;
        private System.Windows.Forms.Label label_e;
        private System.Windows.Forms.Panel panel_pasajes;
        private System.Windows.Forms.Label label_f;
        private System.Windows.Forms.Panel panel_encomiendas;
    }
}