namespace FrbaBus.Estadisticas
{
    partial class Listado_Estadistico
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(Listado_Estadistico));
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.label1 = new System.Windows.Forms.Label();
            this.b_buscar = new System.Windows.Forms.Button();
            this.listado_destinos_mas_pasajes = new System.Windows.Forms.DataGridView();
            this.combo_listados = new System.Windows.Forms.ComboBox();
            this.combo_semestre = new System.Windows.Forms.ComboBox();
            this.label2 = new System.Windows.Forms.Label();
            this.destino = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.cantidad = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.listado_mas_micros_vacios = new System.Windows.Forms.DataGridView();
            this.l2_destino = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.cantidad_m_vacios = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.listado_top_puntos = new System.Windows.Forms.DataGridView();
            this.cliente = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.puntos = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.listado_mas_cancelados = new System.Windows.Forms.DataGridView();
            this.l4_destino = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.l4_cantidad = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.groupBox1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.listado_destinos_mas_pasajes)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.listado_mas_micros_vacios)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.listado_top_puntos)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.listado_mas_cancelados)).BeginInit();
            this.SuspendLayout();
            // 
            // groupBox1
            // 
            this.groupBox1.Controls.Add(this.combo_semestre);
            this.groupBox1.Controls.Add(this.label2);
            this.groupBox1.Controls.Add(this.combo_listados);
            this.groupBox1.Controls.Add(this.label1);
            this.groupBox1.Controls.Add(this.b_buscar);
            this.groupBox1.Location = new System.Drawing.Point(29, 23);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size(364, 84);
            this.groupBox1.TabIndex = 8;
            this.groupBox1.TabStop = false;
            this.groupBox1.Text = "Filtros de Selección";
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(20, 25);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(44, 13);
            this.label1.TabIndex = 67;
            this.label1.Text = "Listado:";
            // 
            // b_buscar
            // 
            this.b_buscar.Location = new System.Drawing.Point(178, 47);
            this.b_buscar.Name = "b_buscar";
            this.b_buscar.Size = new System.Drawing.Size(75, 23);
            this.b_buscar.TabIndex = 1;
            this.b_buscar.Text = "Consultar";
            this.b_buscar.UseVisualStyleBackColor = true;
            this.b_buscar.Click += new System.EventHandler(this.b_buscar_Click);
            // 
            // listado_destinos_mas_pasajes
            // 
            this.listado_destinos_mas_pasajes.AllowUserToAddRows = false;
            this.listado_destinos_mas_pasajes.AllowUserToDeleteRows = false;
            this.listado_destinos_mas_pasajes.ColumnHeadersHeight = 20;
            this.listado_destinos_mas_pasajes.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.destino,
            this.cantidad});
            this.listado_destinos_mas_pasajes.Location = new System.Drawing.Point(29, 129);
            this.listado_destinos_mas_pasajes.MultiSelect = false;
            this.listado_destinos_mas_pasajes.Name = "listado_destinos_mas_pasajes";
            this.listado_destinos_mas_pasajes.ReadOnly = true;
            this.listado_destinos_mas_pasajes.RowHeadersWidth = 30;
            this.listado_destinos_mas_pasajes.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.listado_destinos_mas_pasajes.Size = new System.Drawing.Size(364, 51);
            this.listado_destinos_mas_pasajes.TabIndex = 7;
            this.listado_destinos_mas_pasajes.Visible = false;
            // 
            // combo_listados
            // 
            this.combo_listados.FormattingEnabled = true;
            this.combo_listados.Location = new System.Drawing.Point(79, 22);
            this.combo_listados.Name = "combo_listados";
            this.combo_listados.Size = new System.Drawing.Size(258, 21);
            this.combo_listados.TabIndex = 68;
            // 
            // combo_semestre
            // 
            this.combo_semestre.FormattingEnabled = true;
            this.combo_semestre.Location = new System.Drawing.Point(79, 49);
            this.combo_semestre.Name = "combo_semestre";
            this.combo_semestre.Size = new System.Drawing.Size(74, 21);
            this.combo_semestre.TabIndex = 70;
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(20, 52);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(54, 13);
            this.label2.TabIndex = 69;
            this.label2.Text = "Semestre:";
            // 
            // destino
            // 
            this.destino.HeaderText = "Destino";
            this.destino.Name = "destino";
            this.destino.ReadOnly = true;
            this.destino.Width = 160;
            // 
            // cantidad
            // 
            this.cantidad.HeaderText = "Cantidad de Pasajes Vendidos";
            this.cantidad.Name = "cantidad";
            this.cantidad.ReadOnly = true;
            this.cantidad.Width = 170;
            // 
            // listado_mas_micros_vacios
            // 
            this.listado_mas_micros_vacios.AllowUserToAddRows = false;
            this.listado_mas_micros_vacios.AllowUserToDeleteRows = false;
            this.listado_mas_micros_vacios.ColumnHeadersHeight = 20;
            this.listado_mas_micros_vacios.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.l2_destino,
            this.cantidad_m_vacios});
            this.listado_mas_micros_vacios.Location = new System.Drawing.Point(29, 186);
            this.listado_mas_micros_vacios.MultiSelect = false;
            this.listado_mas_micros_vacios.Name = "listado_mas_micros_vacios";
            this.listado_mas_micros_vacios.ReadOnly = true;
            this.listado_mas_micros_vacios.RowHeadersWidth = 30;
            this.listado_mas_micros_vacios.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.listado_mas_micros_vacios.Size = new System.Drawing.Size(364, 42);
            this.listado_mas_micros_vacios.TabIndex = 9;
            this.listado_mas_micros_vacios.Visible = false;
            // 
            // l2_destino
            // 
            this.l2_destino.HeaderText = "Destino";
            this.l2_destino.Name = "l2_destino";
            this.l2_destino.ReadOnly = true;
            this.l2_destino.Width = 160;
            // 
            // cantidad_m_vacios
            // 
            this.cantidad_m_vacios.HeaderText = "Cantidad de Micros Vacíos";
            this.cantidad_m_vacios.Name = "cantidad_m_vacios";
            this.cantidad_m_vacios.ReadOnly = true;
            this.cantidad_m_vacios.Width = 170;
            // 
            // listado_top_puntos
            // 
            this.listado_top_puntos.AllowUserToAddRows = false;
            this.listado_top_puntos.AllowUserToDeleteRows = false;
            this.listado_top_puntos.ColumnHeadersHeight = 20;
            this.listado_top_puntos.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.cliente,
            this.puntos});
            this.listado_top_puntos.Location = new System.Drawing.Point(29, 234);
            this.listado_top_puntos.MultiSelect = false;
            this.listado_top_puntos.Name = "listado_top_puntos";
            this.listado_top_puntos.ReadOnly = true;
            this.listado_top_puntos.RowHeadersWidth = 30;
            this.listado_top_puntos.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.listado_top_puntos.Size = new System.Drawing.Size(364, 42);
            this.listado_top_puntos.TabIndex = 10;
            this.listado_top_puntos.Visible = false;
            // 
            // cliente
            // 
            this.cliente.HeaderText = "Cliente";
            this.cliente.Name = "cliente";
            this.cliente.ReadOnly = true;
            this.cliente.Width = 160;
            // 
            // puntos
            // 
            this.puntos.HeaderText = "Puntos";
            this.puntos.Name = "puntos";
            this.puntos.ReadOnly = true;
            this.puntos.Width = 170;
            // 
            // listado_mas_cancelados
            // 
            this.listado_mas_cancelados.AllowUserToAddRows = false;
            this.listado_mas_cancelados.AllowUserToDeleteRows = false;
            this.listado_mas_cancelados.ColumnHeadersHeight = 20;
            this.listado_mas_cancelados.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.l4_destino,
            this.l4_cantidad});
            this.listado_mas_cancelados.Location = new System.Drawing.Point(29, 282);
            this.listado_mas_cancelados.MultiSelect = false;
            this.listado_mas_cancelados.Name = "listado_mas_cancelados";
            this.listado_mas_cancelados.ReadOnly = true;
            this.listado_mas_cancelados.RowHeadersWidth = 30;
            this.listado_mas_cancelados.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.listado_mas_cancelados.Size = new System.Drawing.Size(364, 42);
            this.listado_mas_cancelados.TabIndex = 11;
            this.listado_mas_cancelados.Visible = false;
            // 
            // l4_destino
            // 
            this.l4_destino.HeaderText = "Destino";
            this.l4_destino.Name = "l4_destino";
            this.l4_destino.ReadOnly = true;
            this.l4_destino.Width = 160;
            // 
            // l4_cantidad
            // 
            this.l4_cantidad.HeaderText = "Cantidad de Pasajes Cancelados";
            this.l4_cantidad.Name = "l4_cantidad";
            this.l4_cantidad.ReadOnly = true;
            this.l4_cantidad.Width = 170;
            // 
            // Listado_Estadistico
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(422, 343);
            this.Controls.Add(this.listado_mas_cancelados);
            this.Controls.Add(this.listado_top_puntos);
            this.Controls.Add(this.listado_mas_micros_vacios);
            this.Controls.Add(this.groupBox1);
            this.Controls.Add(this.listado_destinos_mas_pasajes);
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.Name = "Listado_Estadistico";
            this.Text = "Listado Estadistico";
            this.groupBox1.ResumeLayout(false);
            this.groupBox1.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.listado_destinos_mas_pasajes)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.listado_mas_micros_vacios)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.listado_top_puntos)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.listado_mas_cancelados)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.GroupBox groupBox1;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Button b_buscar;
        private System.Windows.Forms.DataGridView listado_destinos_mas_pasajes;
        private System.Windows.Forms.ComboBox combo_listados;
        private System.Windows.Forms.ComboBox combo_semestre;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.DataGridViewTextBoxColumn destino;
        private System.Windows.Forms.DataGridViewTextBoxColumn cantidad;
        private System.Windows.Forms.DataGridView listado_mas_micros_vacios;
        private System.Windows.Forms.DataGridViewTextBoxColumn l2_destino;
        private System.Windows.Forms.DataGridViewTextBoxColumn cantidad_m_vacios;
        private System.Windows.Forms.DataGridView listado_top_puntos;
        private System.Windows.Forms.DataGridViewTextBoxColumn cliente;
        private System.Windows.Forms.DataGridViewTextBoxColumn puntos;
        private System.Windows.Forms.DataGridView listado_mas_cancelados;
        private System.Windows.Forms.DataGridViewTextBoxColumn l4_destino;
        private System.Windows.Forms.DataGridViewTextBoxColumn l4_cantidad;
    }
}