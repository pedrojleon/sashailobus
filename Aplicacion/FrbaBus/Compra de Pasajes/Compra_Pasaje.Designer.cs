namespace FrbaBus.Compra_de_Pasajes
{
    partial class Compra_Pasaje
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(Compra_Pasaje));
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.f_salida = new System.Windows.Forms.DateTimePicker();
            this.label1 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.destino = new System.Windows.Forms.ComboBox();
            this.origen = new System.Windows.Forms.ComboBox();
            this.b_guardar = new System.Windows.Forms.Button();
            this.listado_de_viajes = new System.Windows.Forms.DataGridView();
            this.id_viaje = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Micro = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.TipoServicio = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Salida = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.LLegadaEstim = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.butacas = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.kg = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.acciones = new System.Windows.Forms.DataGridViewImageColumn();
            this.groupBox1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.listado_de_viajes)).BeginInit();
            this.SuspendLayout();
            // 
            // groupBox1
            // 
            this.groupBox1.Controls.Add(this.listado_de_viajes);
            this.groupBox1.Controls.Add(this.b_guardar);
            this.groupBox1.Controls.Add(this.label2);
            this.groupBox1.Controls.Add(this.label3);
            this.groupBox1.Controls.Add(this.destino);
            this.groupBox1.Controls.Add(this.origen);
            this.groupBox1.Controls.Add(this.f_salida);
            this.groupBox1.Controls.Add(this.label1);
            this.groupBox1.Location = new System.Drawing.Point(28, 23);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size(760, 364);
            this.groupBox1.TabIndex = 51;
            this.groupBox1.TabStop = false;
            this.groupBox1.Text = "Viaje";
            // 
            // f_salida
            // 
            this.f_salida.Location = new System.Drawing.Point(68, 30);
            this.f_salida.Name = "f_salida";
            this.f_salida.Size = new System.Drawing.Size(146, 20);
            this.f_salida.TabIndex = 54;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(24, 32);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(40, 13);
            this.label1.TabIndex = 53;
            this.label1.Text = "Fecha:";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(428, 32);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(46, 13);
            this.label2.TabIndex = 58;
            this.label2.Text = "Destino:";
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(237, 32);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(41, 13);
            this.label3.TabIndex = 57;
            this.label3.Text = "Origen:";
            // 
            // destino
            // 
            this.destino.FormattingEnabled = true;
            this.destino.Location = new System.Drawing.Point(480, 29);
            this.destino.Name = "destino";
            this.destino.Size = new System.Drawing.Size(101, 21);
            this.destino.TabIndex = 56;
            // 
            // origen
            // 
            this.origen.FormattingEnabled = true;
            this.origen.Location = new System.Drawing.Point(284, 29);
            this.origen.Name = "origen";
            this.origen.Size = new System.Drawing.Size(120, 21);
            this.origen.TabIndex = 55;
            // 
            // b_guardar
            // 
            this.b_guardar.Location = new System.Drawing.Point(607, 27);
            this.b_guardar.Name = "b_guardar";
            this.b_guardar.Size = new System.Drawing.Size(75, 23);
            this.b_guardar.TabIndex = 59;
            this.b_guardar.Text = "Buscar";
            this.b_guardar.UseVisualStyleBackColor = true;
            this.b_guardar.Click += new System.EventHandler(this.b_guardar_Click);
            // 
            // listado_de_viajes
            // 
            this.listado_de_viajes.AllowUserToAddRows = false;
            this.listado_de_viajes.AllowUserToDeleteRows = false;
            this.listado_de_viajes.ColumnHeadersHeight = 20;
            this.listado_de_viajes.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.id_viaje,
            this.Micro,
            this.TipoServicio,
            this.Salida,
            this.LLegadaEstim,
            this.butacas,
            this.kg,
            this.acciones});
            this.listado_de_viajes.Location = new System.Drawing.Point(29, 62);
            this.listado_de_viajes.MultiSelect = false;
            this.listado_de_viajes.Name = "listado_de_viajes";
            this.listado_de_viajes.ReadOnly = true;
            this.listado_de_viajes.RowHeadersWidth = 30;
            this.listado_de_viajes.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.listado_de_viajes.Size = new System.Drawing.Size(683, 240);
            this.listado_de_viajes.TabIndex = 60;
            // 
            // id_viaje
            // 
            this.id_viaje.HeaderText = "id_viaje";
            this.id_viaje.MinimumWidth = 100;
            this.id_viaje.Name = "id_viaje";
            this.id_viaje.ReadOnly = true;
            this.id_viaje.Visible = false;
            // 
            // Micro
            // 
            this.Micro.HeaderText = "Micro";
            this.Micro.Name = "Micro";
            this.Micro.ReadOnly = true;
            this.Micro.Width = 80;
            // 
            // TipoServicio
            // 
            this.TipoServicio.HeaderText = "Servicio";
            this.TipoServicio.Name = "TipoServicio";
            this.TipoServicio.ReadOnly = true;
            this.TipoServicio.Width = 90;
            // 
            // Salida
            // 
            this.Salida.HeaderText = "Salida";
            this.Salida.Name = "Salida";
            this.Salida.ReadOnly = true;
            this.Salida.Width = 110;
            // 
            // LLegadaEstim
            // 
            this.LLegadaEstim.HeaderText = "LLegada Estimada";
            this.LLegadaEstim.Name = "LLegadaEstim";
            this.LLegadaEstim.ReadOnly = true;
            this.LLegadaEstim.Width = 110;
            // 
            // butacas
            // 
            this.butacas.HeaderText = "Butacas Libres";
            this.butacas.Name = "butacas";
            this.butacas.ReadOnly = true;
            // 
            // kg
            // 
            this.kg.HeaderText = "KG Libres";
            this.kg.Name = "kg";
            this.kg.ReadOnly = true;
            // 
            // acciones
            // 
            this.acciones.HeaderText = "";
            this.acciones.Name = "acciones";
            this.acciones.ReadOnly = true;
            this.acciones.Resizable = System.Windows.Forms.DataGridViewTriState.True;
            this.acciones.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.Automatic;
            this.acciones.Width = 40;
            // 
            // Compra_Pasaje
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(814, 486);
            this.Controls.Add(this.groupBox1);
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.Name = "Compra_Pasaje";
            this.Text = "Compra de Pasaje o Encomienda";
            this.groupBox1.ResumeLayout(false);
            this.groupBox1.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.listado_de_viajes)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.GroupBox groupBox1;
        private System.Windows.Forms.DateTimePicker f_salida;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.ComboBox destino;
        private System.Windows.Forms.ComboBox origen;
        private System.Windows.Forms.Button b_guardar;
        private System.Windows.Forms.DataGridView listado_de_viajes;
        private System.Windows.Forms.DataGridViewTextBoxColumn id_viaje;
        private System.Windows.Forms.DataGridViewTextBoxColumn Micro;
        private System.Windows.Forms.DataGridViewTextBoxColumn TipoServicio;
        private System.Windows.Forms.DataGridViewTextBoxColumn Salida;
        private System.Windows.Forms.DataGridViewTextBoxColumn LLegadaEstim;
        private System.Windows.Forms.DataGridViewTextBoxColumn butacas;
        private System.Windows.Forms.DataGridViewTextBoxColumn kg;
        private System.Windows.Forms.DataGridViewImageColumn acciones;
    }
}