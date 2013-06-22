namespace FrbaBus.Abm_Recorrido
{
    partial class ABM_Recorrido
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(ABM_Recorrido));
            this.listado_recorridos = new System.Windows.Forms.DataGridView();
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.b_buscar = new System.Windows.Forms.Button();
            this.combo_destino = new System.Windows.Forms.ComboBox();
            this.label2 = new System.Windows.Forms.Label();
            this.combo_origen = new System.Windows.Forms.ComboBox();
            this.label1 = new System.Windows.Forms.Label();
            this.b_nuevo = new System.Windows.Forms.Button();
            this.id_recorrido = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.habilitado = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.CiudadOrigen = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.CiudadDestino = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.TipoServicio = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.PrecioBasePasaje = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.PrecioBaseKg = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.acciones = new System.Windows.Forms.DataGridViewImageColumn();
            this.modificacion = new System.Windows.Forms.DataGridViewImageColumn();
            ((System.ComponentModel.ISupportInitialize)(this.listado_recorridos)).BeginInit();
            this.groupBox1.SuspendLayout();
            this.SuspendLayout();
            // 
            // listado_recorridos
            // 
            this.listado_recorridos.AllowUserToAddRows = false;
            this.listado_recorridos.AllowUserToDeleteRows = false;
            this.listado_recorridos.ColumnHeadersHeight = 20;
            this.listado_recorridos.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.id_recorrido,
            this.habilitado,
            this.CiudadOrigen,
            this.CiudadDestino,
            this.TipoServicio,
            this.PrecioBasePasaje,
            this.PrecioBaseKg,
            this.acciones,
            this.modificacion});
            this.listado_recorridos.Location = new System.Drawing.Point(24, 80);
            this.listado_recorridos.MultiSelect = false;
            this.listado_recorridos.Name = "listado_recorridos";
            this.listado_recorridos.ReadOnly = true;
            this.listado_recorridos.RowHeadersWidth = 30;
            this.listado_recorridos.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.listado_recorridos.Size = new System.Drawing.Size(663, 240);
            this.listado_recorridos.TabIndex = 3;
            this.listado_recorridos.CellContentClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.listado_recorridos_CellContentClick);
            // 
            // groupBox1
            // 
            this.groupBox1.Controls.Add(this.b_buscar);
            this.groupBox1.Controls.Add(this.combo_destino);
            this.groupBox1.Controls.Add(this.label2);
            this.groupBox1.Controls.Add(this.combo_origen);
            this.groupBox1.Controls.Add(this.label1);
            this.groupBox1.Location = new System.Drawing.Point(24, 15);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size(663, 54);
            this.groupBox1.TabIndex = 4;
            this.groupBox1.TabStop = false;
            this.groupBox1.Text = "Filtros de Búsqueda";
            // 
            // b_buscar
            // 
            this.b_buscar.Location = new System.Drawing.Point(513, 20);
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
            this.combo_destino.Location = new System.Drawing.Point(300, 22);
            this.combo_destino.Name = "combo_destino";
            this.combo_destino.Size = new System.Drawing.Size(153, 21);
            this.combo_destino.TabIndex = 3;
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(248, 25);
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
            this.combo_origen.Size = new System.Drawing.Size(153, 21);
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
            // b_nuevo
            // 
            this.b_nuevo.Location = new System.Drawing.Point(591, 337);
            this.b_nuevo.Name = "b_nuevo";
            this.b_nuevo.Size = new System.Drawing.Size(96, 23);
            this.b_nuevo.TabIndex = 5;
            this.b_nuevo.Text = "Nuevo Recorrido";
            this.b_nuevo.UseVisualStyleBackColor = true;
            this.b_nuevo.Click += new System.EventHandler(this.b_nuevo_Click);
            // 
            // id_recorrido
            // 
            this.id_recorrido.HeaderText = "id_recorrido";
            this.id_recorrido.MinimumWidth = 100;
            this.id_recorrido.Name = "id_recorrido";
            this.id_recorrido.ReadOnly = true;
            this.id_recorrido.Visible = false;
            // 
            // habilitado
            // 
            this.habilitado.HeaderText = "habilitado";
            this.habilitado.Name = "habilitado";
            this.habilitado.ReadOnly = true;
            this.habilitado.Visible = false;
            // 
            // CiudadOrigen
            // 
            this.CiudadOrigen.HeaderText = "Ciudad Origen";
            this.CiudadOrigen.Name = "CiudadOrigen";
            this.CiudadOrigen.ReadOnly = true;
            this.CiudadOrigen.Width = 160;
            // 
            // CiudadDestino
            // 
            this.CiudadDestino.HeaderText = "Ciudad Destino";
            this.CiudadDestino.Name = "CiudadDestino";
            this.CiudadDestino.ReadOnly = true;
            this.CiudadDestino.Width = 160;
            // 
            // TipoServicio
            // 
            this.TipoServicio.HeaderText = "Servicio";
            this.TipoServicio.Name = "TipoServicio";
            this.TipoServicio.ReadOnly = true;
            this.TipoServicio.Width = 80;
            // 
            // PrecioBasePasaje
            // 
            this.PrecioBasePasaje.HeaderText = "$/Pasaje";
            this.PrecioBasePasaje.Name = "PrecioBasePasaje";
            this.PrecioBasePasaje.ReadOnly = true;
            this.PrecioBasePasaje.Width = 70;
            // 
            // PrecioBaseKg
            // 
            this.PrecioBaseKg.HeaderText = "$/KG";
            this.PrecioBaseKg.Name = "PrecioBaseKg";
            this.PrecioBaseKg.ReadOnly = true;
            this.PrecioBaseKg.Width = 80;
            // 
            // acciones
            // 
            this.acciones.HeaderText = "";
            this.acciones.MinimumWidth = 32;
            this.acciones.Name = "acciones";
            this.acciones.ReadOnly = true;
            this.acciones.Width = 32;
            // 
            // modificacion
            // 
            this.modificacion.HeaderText = "";
            this.modificacion.MinimumWidth = 32;
            this.modificacion.Name = "modificacion";
            this.modificacion.ReadOnly = true;
            this.modificacion.Width = 32;
            // 
            // ABM_Recorrido
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(709, 372);
            this.Controls.Add(this.b_nuevo);
            this.Controls.Add(this.groupBox1);
            this.Controls.Add(this.listado_recorridos);
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.Name = "ABM_Recorrido";
            this.Text = "ABM de Recorrido";
            ((System.ComponentModel.ISupportInitialize)(this.listado_recorridos)).EndInit();
            this.groupBox1.ResumeLayout(false);
            this.groupBox1.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.DataGridView listado_recorridos;
        private System.Windows.Forms.GroupBox groupBox1;
        private System.Windows.Forms.Button b_buscar;
        private System.Windows.Forms.ComboBox combo_destino;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.ComboBox combo_origen;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Button b_nuevo;
        private System.Windows.Forms.DataGridViewTextBoxColumn id_recorrido;
        private System.Windows.Forms.DataGridViewTextBoxColumn habilitado;
        private System.Windows.Forms.DataGridViewTextBoxColumn CiudadOrigen;
        private System.Windows.Forms.DataGridViewTextBoxColumn CiudadDestino;
        private System.Windows.Forms.DataGridViewTextBoxColumn TipoServicio;
        private System.Windows.Forms.DataGridViewTextBoxColumn PrecioBasePasaje;
        private System.Windows.Forms.DataGridViewTextBoxColumn PrecioBaseKg;
        private System.Windows.Forms.DataGridViewImageColumn acciones;
        private System.Windows.Forms.DataGridViewImageColumn modificacion;
    }
}