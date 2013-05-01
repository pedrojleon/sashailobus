namespace FrbaBus.Abm_Micro
{
    partial class ABM_Micro
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(ABM_Micro));
            this.b_nuevo = new System.Windows.Forms.Button();
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.b_buscar = new System.Windows.Forms.Button();
            this.combo_tipo_servicio = new System.Windows.Forms.ComboBox();
            this.label2 = new System.Windows.Forms.Label();
            this.combo_marca = new System.Windows.Forms.ComboBox();
            this.label1 = new System.Windows.Forms.Label();
            this.listado_recorridos = new System.Windows.Forms.DataGridView();
            this.id_micro = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Patente = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Marca = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Modelo = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Servicio = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Butacas = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.KG = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Habilitado = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.acciones = new System.Windows.Forms.DataGridViewImageColumn();
            this.modificacion = new System.Windows.Forms.DataGridViewImageColumn();
            this.groupBox1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.listado_recorridos)).BeginInit();
            this.SuspendLayout();
            // 
            // b_nuevo
            // 
            this.b_nuevo.Location = new System.Drawing.Point(591, 338);
            this.b_nuevo.Name = "b_nuevo";
            this.b_nuevo.Size = new System.Drawing.Size(96, 23);
            this.b_nuevo.TabIndex = 8;
            this.b_nuevo.Text = "Nuevo Recorrido";
            this.b_nuevo.UseVisualStyleBackColor = true;
            // 
            // groupBox1
            // 
            this.groupBox1.Controls.Add(this.b_buscar);
            this.groupBox1.Controls.Add(this.combo_tipo_servicio);
            this.groupBox1.Controls.Add(this.label2);
            this.groupBox1.Controls.Add(this.combo_marca);
            this.groupBox1.Controls.Add(this.label1);
            this.groupBox1.Location = new System.Drawing.Point(24, 16);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size(663, 54);
            this.groupBox1.TabIndex = 7;
            this.groupBox1.TabStop = false;
            this.groupBox1.Text = "Filtros de Búsqueda";
            // 
            // b_buscar
            // 
            this.b_buscar.Location = new System.Drawing.Point(567, 20);
            this.b_buscar.Name = "b_buscar";
            this.b_buscar.Size = new System.Drawing.Size(75, 23);
            this.b_buscar.TabIndex = 4;
            this.b_buscar.Text = "Buscar";
            this.b_buscar.UseVisualStyleBackColor = true;
            // 
            // combo_tipo_servicio
            // 
            this.combo_tipo_servicio.FormattingEnabled = true;
            this.combo_tipo_servicio.Location = new System.Drawing.Point(341, 22);
            this.combo_tipo_servicio.Name = "combo_tipo_servicio";
            this.combo_tipo_servicio.Size = new System.Drawing.Size(153, 21);
            this.combo_tipo_servicio.TabIndex = 3;
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(248, 25);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(87, 13);
            this.label2.TabIndex = 2;
            this.label2.Text = "Tipo de Servicio:";
            // 
            // combo_marca
            // 
            this.combo_marca.FormattingEnabled = true;
            this.combo_marca.Location = new System.Drawing.Point(76, 22);
            this.combo_marca.Name = "combo_marca";
            this.combo_marca.Size = new System.Drawing.Size(153, 21);
            this.combo_marca.TabIndex = 1;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(29, 25);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(40, 13);
            this.label1.TabIndex = 0;
            this.label1.Text = "Marca:";
            // 
            // listado_recorridos
            // 
            this.listado_recorridos.AllowUserToAddRows = false;
            this.listado_recorridos.AllowUserToDeleteRows = false;
            this.listado_recorridos.ColumnHeadersHeight = 20;
            this.listado_recorridos.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.id_micro,
            this.Patente,
            this.Marca,
            this.Modelo,
            this.Servicio,
            this.Butacas,
            this.KG,
            this.Habilitado,
            this.acciones,
            this.modificacion});
            this.listado_recorridos.Location = new System.Drawing.Point(24, 81);
            this.listado_recorridos.MultiSelect = false;
            this.listado_recorridos.Name = "listado_recorridos";
            this.listado_recorridos.ReadOnly = true;
            this.listado_recorridos.RowHeadersWidth = 30;
            this.listado_recorridos.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.listado_recorridos.Size = new System.Drawing.Size(663, 240);
            this.listado_recorridos.TabIndex = 6;
            // 
            // id_micro
            // 
            this.id_micro.HeaderText = "id_micro";
            this.id_micro.MinimumWidth = 100;
            this.id_micro.Name = "id_micro";
            this.id_micro.ReadOnly = true;
            this.id_micro.Visible = false;
            // 
            // Patente
            // 
            this.Patente.HeaderText = "Patente";
            this.Patente.Name = "Patente";
            this.Patente.ReadOnly = true;
            this.Patente.Width = 60;
            // 
            // Marca
            // 
            this.Marca.HeaderText = "Marca";
            this.Marca.Name = "Marca";
            this.Marca.ReadOnly = true;
            // 
            // Modelo
            // 
            this.Modelo.HeaderText = "Modelo";
            this.Modelo.Name = "Modelo";
            this.Modelo.ReadOnly = true;
            // 
            // Servicio
            // 
            this.Servicio.HeaderText = "Servicio";
            this.Servicio.Name = "Servicio";
            this.Servicio.ReadOnly = true;
            // 
            // Butacas
            // 
            this.Butacas.HeaderText = "Nº Butacas";
            this.Butacas.Name = "Butacas";
            this.Butacas.ReadOnly = true;
            this.Butacas.Width = 65;
            // 
            // KG
            // 
            this.KG.HeaderText = "KG";
            this.KG.Name = "KG";
            this.KG.ReadOnly = true;
            this.KG.Width = 65;
            // 
            // Habilitado
            // 
            this.Habilitado.HeaderText = "Habilitado";
            this.Habilitado.Name = "Habilitado";
            this.Habilitado.ReadOnly = true;
            this.Habilitado.Width = 65;
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
            // ABM_Micro
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(711, 378);
            this.Controls.Add(this.b_nuevo);
            this.Controls.Add(this.groupBox1);
            this.Controls.Add(this.listado_recorridos);
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.Name = "ABM_Micro";
            this.Text = "ABM de Micro";
            this.groupBox1.ResumeLayout(false);
            this.groupBox1.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.listado_recorridos)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Button b_nuevo;
        private System.Windows.Forms.GroupBox groupBox1;
        private System.Windows.Forms.Button b_buscar;
        private System.Windows.Forms.ComboBox combo_tipo_servicio;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.ComboBox combo_marca;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.DataGridView listado_recorridos;
        private System.Windows.Forms.DataGridViewTextBoxColumn id_micro;
        private System.Windows.Forms.DataGridViewTextBoxColumn Patente;
        private System.Windows.Forms.DataGridViewTextBoxColumn Marca;
        private System.Windows.Forms.DataGridViewTextBoxColumn Modelo;
        private System.Windows.Forms.DataGridViewTextBoxColumn Servicio;
        private System.Windows.Forms.DataGridViewTextBoxColumn Butacas;
        private System.Windows.Forms.DataGridViewTextBoxColumn KG;
        private System.Windows.Forms.DataGridViewTextBoxColumn Habilitado;
        private System.Windows.Forms.DataGridViewImageColumn acciones;
        private System.Windows.Forms.DataGridViewImageColumn modificacion;
    }
}