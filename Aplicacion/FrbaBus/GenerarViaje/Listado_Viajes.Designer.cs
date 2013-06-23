namespace FrbaBus.GenerarViaje
{
    partial class Listado_Viajes
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(Listado_Viajes));
            this.b_nuevo = new System.Windows.Forms.Button();
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.b_buscar = new System.Windows.Forms.Button();
            this.combo_destino = new System.Windows.Forms.ComboBox();
            this.label2 = new System.Windows.Forms.Label();
            this.combo_origen = new System.Windows.Forms.ComboBox();
            this.label1 = new System.Windows.Forms.Label();
            this.listado_de_viajes = new System.Windows.Forms.DataGridView();
            this.id_viaje = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Recorrido = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Micro = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.TipoServicio = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Salida = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.LLegadaEstim = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Llegada = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.groupBox1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.listado_de_viajes)).BeginInit();
            this.SuspendLayout();
            // 
            // b_nuevo
            // 
            this.b_nuevo.Location = new System.Drawing.Point(628, 338);
            this.b_nuevo.Name = "b_nuevo";
            this.b_nuevo.Size = new System.Drawing.Size(96, 23);
            this.b_nuevo.TabIndex = 8;
            this.b_nuevo.Text = "Generar Viaje";
            this.b_nuevo.UseVisualStyleBackColor = true;
            this.b_nuevo.Click += new System.EventHandler(this.b_nuevo_Click);
            // 
            // groupBox1
            // 
            this.groupBox1.Controls.Add(this.b_buscar);
            this.groupBox1.Controls.Add(this.combo_destino);
            this.groupBox1.Controls.Add(this.label2);
            this.groupBox1.Controls.Add(this.combo_origen);
            this.groupBox1.Controls.Add(this.label1);
            this.groupBox1.Location = new System.Drawing.Point(21, 12);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size(703, 54);
            this.groupBox1.TabIndex = 7;
            this.groupBox1.TabStop = false;
            this.groupBox1.Text = "Filtros de Búsqueda";
            // 
            // b_buscar
            // 
            this.b_buscar.Location = new System.Drawing.Point(347, 20);
            this.b_buscar.Name = "b_buscar";
            this.b_buscar.Size = new System.Drawing.Size(75, 23);
            this.b_buscar.TabIndex = 4;
            this.b_buscar.Text = "Buscar";
            this.b_buscar.UseVisualStyleBackColor = true;
            this.b_buscar.Click += new System.EventHandler(this.b_buscar_Click);
            // 
            // combo_destino
            // 
            this.combo_destino.FormattingEnabled = true;
            this.combo_destino.Location = new System.Drawing.Point(232, 22);
            this.combo_destino.Name = "combo_destino";
            this.combo_destino.Size = new System.Drawing.Size(87, 21);
            this.combo_destino.TabIndex = 3;
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(180, 25);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(46, 13);
            this.label2.TabIndex = 2;
            this.label2.Text = "Destino:";
            // 
            // combo_origen
            // 
            this.combo_origen.FormattingEnabled = true;
            this.combo_origen.Location = new System.Drawing.Point(76, 22);
            this.combo_origen.Name = "combo_origen";
            this.combo_origen.Size = new System.Drawing.Size(85, 21);
            this.combo_origen.TabIndex = 1;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(29, 25);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(41, 13);
            this.label1.TabIndex = 0;
            this.label1.Text = "Origen:";
            // 
            // listado_de_viajes
            // 
            this.listado_de_viajes.AllowUserToAddRows = false;
            this.listado_de_viajes.AllowUserToDeleteRows = false;
            this.listado_de_viajes.ColumnHeadersHeight = 20;
            this.listado_de_viajes.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.id_viaje,
            this.Recorrido,
            this.Micro,
            this.TipoServicio,
            this.Salida,
            this.LLegadaEstim,
            this.Llegada});
            this.listado_de_viajes.Location = new System.Drawing.Point(21, 75);
            this.listado_de_viajes.MultiSelect = false;
            this.listado_de_viajes.Name = "listado_de_viajes";
            this.listado_de_viajes.ReadOnly = true;
            this.listado_de_viajes.RowHeadersWidth = 30;
            this.listado_de_viajes.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.listado_de_viajes.Size = new System.Drawing.Size(703, 240);
            this.listado_de_viajes.TabIndex = 6;
            // 
            // id_viaje
            // 
            this.id_viaje.HeaderText = "id_viaje";
            this.id_viaje.MinimumWidth = 100;
            this.id_viaje.Name = "id_viaje";
            this.id_viaje.ReadOnly = true;
            this.id_viaje.Visible = false;
            // 
            // Recorrido
            // 
            this.Recorrido.HeaderText = "Recorrido";
            this.Recorrido.Name = "Recorrido";
            this.Recorrido.ReadOnly = true;
            this.Recorrido.Width = 160;
            // 
            // Micro
            // 
            this.Micro.HeaderText = "Micro";
            this.Micro.Name = "Micro";
            this.Micro.ReadOnly = true;
            this.Micro.Width = 160;
            // 
            // TipoServicio
            // 
            this.TipoServicio.HeaderText = "Servicio";
            this.TipoServicio.Name = "TipoServicio";
            this.TipoServicio.ReadOnly = true;
            this.TipoServicio.Width = 80;
            // 
            // Salida
            // 
            this.Salida.HeaderText = "Salida";
            this.Salida.Name = "Salida";
            this.Salida.ReadOnly = true;
            this.Salida.Width = 70;
            // 
            // LLegadaEstim
            // 
            this.LLegadaEstim.HeaderText = "LLegada Estimada";
            this.LLegadaEstim.Name = "LLegadaEstim";
            this.LLegadaEstim.ReadOnly = true;
            this.LLegadaEstim.Width = 80;
            // 
            // Llegada
            // 
            this.Llegada.HeaderText = "Llegada";
            this.Llegada.Name = "Llegada";
            this.Llegada.ReadOnly = true;
            // 
            // Listado_Viajes
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(745, 377);
            this.Controls.Add(this.b_nuevo);
            this.Controls.Add(this.groupBox1);
            this.Controls.Add(this.listado_de_viajes);
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.Name = "Listado_Viajes";
            this.Text = "Listado Viajes";
            this.groupBox1.ResumeLayout(false);
            this.groupBox1.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.listado_de_viajes)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Button b_nuevo;
        private System.Windows.Forms.GroupBox groupBox1;
        private System.Windows.Forms.Button b_buscar;
        private System.Windows.Forms.ComboBox combo_destino;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.ComboBox combo_origen;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.DataGridView listado_de_viajes;
        private System.Windows.Forms.DataGridViewTextBoxColumn id_viaje;
        private System.Windows.Forms.DataGridViewTextBoxColumn Recorrido;
        private System.Windows.Forms.DataGridViewTextBoxColumn Micro;
        private System.Windows.Forms.DataGridViewTextBoxColumn TipoServicio;
        private System.Windows.Forms.DataGridViewTextBoxColumn Salida;
        private System.Windows.Forms.DataGridViewTextBoxColumn LLegadaEstim;
        private System.Windows.Forms.DataGridViewTextBoxColumn Llegada;
    }
}