namespace FrbaBus.Canje_de_Ptos
{
    partial class Canje_Puntos
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(Canje_Puntos));
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.label3 = new System.Windows.Forms.Label();
            this.producto = new System.Windows.Forms.ComboBox();
            this.dni = new System.Windows.Forms.TextBox();
            this.label1 = new System.Windows.Forms.Label();
            this.cantidad = new System.Windows.Forms.TextBox();
            this.label2 = new System.Windows.Forms.Label();
            this.label_puntos = new System.Windows.Forms.Label();
            this.puntos = new System.Windows.Forms.Label();
            this.canjear = new System.Windows.Forms.Button();
            this.groupBox1.SuspendLayout();
            this.SuspendLayout();
            // 
            // groupBox1
            // 
            this.groupBox1.Controls.Add(this.canjear);
            this.groupBox1.Controls.Add(this.puntos);
            this.groupBox1.Controls.Add(this.label_puntos);
            this.groupBox1.Controls.Add(this.cantidad);
            this.groupBox1.Controls.Add(this.label2);
            this.groupBox1.Controls.Add(this.dni);
            this.groupBox1.Controls.Add(this.label1);
            this.groupBox1.Controls.Add(this.label3);
            this.groupBox1.Controls.Add(this.producto);
            this.groupBox1.Location = new System.Drawing.Point(35, 27);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size(348, 204);
            this.groupBox1.TabIndex = 0;
            this.groupBox1.TabStop = false;
            this.groupBox1.Text = "Canje";
            this.groupBox1.Enter += new System.EventHandler(this.groupBox1_Enter);
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(26, 64);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(53, 13);
            this.label3.TabIndex = 59;
            this.label3.Text = "Producto:";
            // 
            // producto
            // 
            this.producto.FormattingEnabled = true;
            this.producto.Location = new System.Drawing.Point(113, 61);
            this.producto.Name = "producto";
            this.producto.Size = new System.Drawing.Size(190, 21);
            this.producto.TabIndex = 1;
            // 
            // dni
            // 
            this.dni.Location = new System.Drawing.Point(113, 27);
            this.dni.Name = "dni";
            this.dni.Size = new System.Drawing.Size(75, 20);
            this.dni.TabIndex = 0;
            this.dni.Leave += new System.EventHandler(this.pasaje_Leave);
            this.dni.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.dni_KeyPress);
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(26, 30);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(81, 13);
            this.label1.TabIndex = 60;
            this.label1.Text = "DNI del Cliente:";
            // 
            // cantidad
            // 
            this.cantidad.Location = new System.Drawing.Point(113, 96);
            this.cantidad.MaxLength = 2;
            this.cantidad.Name = "cantidad";
            this.cantidad.Size = new System.Drawing.Size(32, 20);
            this.cantidad.TabIndex = 2;
            this.cantidad.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.textBox1_KeyPress);
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(26, 99);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(52, 13);
            this.label2.TabIndex = 62;
            this.label2.Text = "Cantidad:";
            // 
            // label_puntos
            // 
            this.label_puntos.AutoSize = true;
            this.label_puntos.ForeColor = System.Drawing.Color.Green;
            this.label_puntos.Location = new System.Drawing.Point(191, 30);
            this.label_puntos.Name = "label_puntos";
            this.label_puntos.Size = new System.Drawing.Size(86, 13);
            this.label_puntos.TabIndex = 64;
            this.label_puntos.Text = "Ptos disponibles:";
            this.label_puntos.Visible = false;
            // 
            // puntos
            // 
            this.puntos.AutoSize = true;
            this.puntos.ForeColor = System.Drawing.Color.Green;
            this.puntos.Location = new System.Drawing.Point(275, 30);
            this.puntos.Name = "puntos";
            this.puntos.Size = new System.Drawing.Size(10, 13);
            this.puntos.TabIndex = 65;
            this.puntos.Text = "-";
            this.puntos.Visible = false;
            // 
            // canjear
            // 
            this.canjear.Location = new System.Drawing.Point(113, 149);
            this.canjear.Name = "canjear";
            this.canjear.Size = new System.Drawing.Size(75, 23);
            this.canjear.TabIndex = 3;
            this.canjear.Text = "Canjear";
            this.canjear.UseVisualStyleBackColor = true;
            this.canjear.Click += new System.EventHandler(this.canjear_Click);
            // 
            // Canje_Puntos
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(418, 263);
            this.Controls.Add(this.groupBox1);
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.Name = "Canje_Puntos";
            this.Text = "Canje de Puntos";
            this.groupBox1.ResumeLayout(false);
            this.groupBox1.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.GroupBox groupBox1;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.ComboBox producto;
        private System.Windows.Forms.TextBox cantidad;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.TextBox dni;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label puntos;
        private System.Windows.Forms.Label label_puntos;
        private System.Windows.Forms.Button canjear;
    }
}