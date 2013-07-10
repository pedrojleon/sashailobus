namespace FrbaBus.Consulta_Puntos_Adquiridos
{
    partial class Consulta_Puntos
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(Consulta_Puntos));
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.b_buscar = new System.Windows.Forms.Button();
            this.listado_puntos = new System.Windows.Forms.DataGridView();
            this.dni = new System.Windows.Forms.TextBox();
            this.label1 = new System.Windows.Forms.Label();
            this.l_puntos = new System.Windows.Forms.Label();
            this.label_puntos = new System.Windows.Forms.Label();
            this.puntos = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.fecha = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.detalle = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.groupBox1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.listado_puntos)).BeginInit();
            this.SuspendLayout();
            // 
            // groupBox1
            // 
            this.groupBox1.Controls.Add(this.l_puntos);
            this.groupBox1.Controls.Add(this.label_puntos);
            this.groupBox1.Controls.Add(this.dni);
            this.groupBox1.Controls.Add(this.label1);
            this.groupBox1.Controls.Add(this.b_buscar);
            this.groupBox1.Location = new System.Drawing.Point(22, 14);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size(490, 54);
            this.groupBox1.TabIndex = 6;
            this.groupBox1.TabStop = false;
            this.groupBox1.Text = "Cliente";
            // 
            // b_buscar
            // 
            this.b_buscar.Location = new System.Drawing.Point(204, 20);
            this.b_buscar.Name = "b_buscar";
            this.b_buscar.Size = new System.Drawing.Size(75, 23);
            this.b_buscar.TabIndex = 1;
            this.b_buscar.Text = "Consultar";
            this.b_buscar.UseVisualStyleBackColor = true;
            this.b_buscar.Click += new System.EventHandler(this.b_buscar_Click);
            // 
            // listado_puntos
            // 
            this.listado_puntos.AllowUserToAddRows = false;
            this.listado_puntos.AllowUserToDeleteRows = false;
            this.listado_puntos.ColumnHeadersHeight = 20;
            this.listado_puntos.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.puntos,
            this.fecha,
            this.detalle});
            this.listado_puntos.Location = new System.Drawing.Point(22, 86);
            this.listado_puntos.MultiSelect = false;
            this.listado_puntos.Name = "listado_puntos";
            this.listado_puntos.ReadOnly = true;
            this.listado_puntos.RowHeadersWidth = 30;
            this.listado_puntos.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.listado_puntos.Size = new System.Drawing.Size(490, 259);
            this.listado_puntos.TabIndex = 5;
            // 
            // dni
            // 
            this.dni.Location = new System.Drawing.Point(107, 22);
            this.dni.Name = "dni";
            this.dni.Size = new System.Drawing.Size(75, 20);
            this.dni.TabIndex = 0;
            this.dni.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.dni_KeyPress);
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(20, 25);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(81, 13);
            this.label1.TabIndex = 67;
            this.label1.Text = "DNI del Cliente:";
            // 
            // l_puntos
            // 
            this.l_puntos.AutoSize = true;
            this.l_puntos.ForeColor = System.Drawing.Color.Green;
            this.l_puntos.Location = new System.Drawing.Point(385, 25);
            this.l_puntos.Name = "l_puntos";
            this.l_puntos.Size = new System.Drawing.Size(10, 13);
            this.l_puntos.TabIndex = 69;
            this.l_puntos.Text = "-";
            this.l_puntos.Visible = false;
            // 
            // label_puntos
            // 
            this.label_puntos.AutoSize = true;
            this.label_puntos.ForeColor = System.Drawing.Color.Green;
            this.label_puntos.Location = new System.Drawing.Point(301, 25);
            this.label_puntos.Name = "label_puntos";
            this.label_puntos.Size = new System.Drawing.Size(81, 13);
            this.label_puntos.TabIndex = 68;
            this.label_puntos.Text = "Puntos Totales:";
            this.label_puntos.Visible = false;
            // 
            // puntos
            // 
            this.puntos.HeaderText = "Puntos";
            this.puntos.Name = "puntos";
            this.puntos.ReadOnly = true;
            this.puntos.Width = 80;
            // 
            // fecha
            // 
            this.fecha.HeaderText = "Fecha";
            this.fecha.Name = "fecha";
            this.fecha.ReadOnly = true;
            this.fecha.Width = 160;
            // 
            // detalle
            // 
            this.detalle.HeaderText = "Detalle";
            this.detalle.Name = "detalle";
            this.detalle.ReadOnly = true;
            this.detalle.Width = 200;
            // 
            // Consulta_Puntos
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(536, 369);
            this.Controls.Add(this.groupBox1);
            this.Controls.Add(this.listado_puntos);
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.Name = "Consulta_Puntos";
            this.Text = "Consulta de Puntos";
            this.groupBox1.ResumeLayout(false);
            this.groupBox1.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.listado_puntos)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.GroupBox groupBox1;
        private System.Windows.Forms.Button b_buscar;
        private System.Windows.Forms.DataGridView listado_puntos;
        private System.Windows.Forms.TextBox dni;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label l_puntos;
        private System.Windows.Forms.Label label_puntos;
        private System.Windows.Forms.DataGridViewTextBoxColumn puntos;
        private System.Windows.Forms.DataGridViewTextBoxColumn fecha;
        private System.Windows.Forms.DataGridViewTextBoxColumn detalle;
    }
}