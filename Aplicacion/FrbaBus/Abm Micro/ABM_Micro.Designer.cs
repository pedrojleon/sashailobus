namespace FrbaBus.Abm_Micro
{
    partial class ABM_Micro
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(ABM_Micro));
            this.b_nuevo = new System.Windows.Forms.Button();
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.tb_patente = new System.Windows.Forms.TextBox();
            this.label3 = new System.Windows.Forms.Label();
            this.b_buscar = new System.Windows.Forms.Button();
            this.combo_servicio = new System.Windows.Forms.ComboBox();
            this.label2 = new System.Windows.Forms.Label();
            this.combo_marca = new System.Windows.Forms.ComboBox();
            this.label1 = new System.Windows.Forms.Label();
            this.listado_micros = new System.Windows.Forms.DataGridView();
            this.id_micro = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.fin_vida_util = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Patente = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Marca = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Modelo = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.TipoServicio = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.NButacas = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.KG = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.FueraServicio = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.FinVidaUtil = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.modificacion = new System.Windows.Forms.DataGridViewImageColumn();
            this.groupBox1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.listado_micros)).BeginInit();
            this.SuspendLayout();
            // 
            // b_nuevo
            // 
            this.b_nuevo.Location = new System.Drawing.Point(600, 340);
            this.b_nuevo.Name = "b_nuevo";
            this.b_nuevo.Size = new System.Drawing.Size(96, 23);
            this.b_nuevo.TabIndex = 8;
            this.b_nuevo.Text = "Nuevo Micro";
            this.b_nuevo.UseVisualStyleBackColor = true;
            this.b_nuevo.Click += new System.EventHandler(this.b_nuevo_Click);
            // 
            // groupBox1
            // 
            this.groupBox1.Controls.Add(this.tb_patente);
            this.groupBox1.Controls.Add(this.label3);
            this.groupBox1.Controls.Add(this.b_buscar);
            this.groupBox1.Controls.Add(this.combo_servicio);
            this.groupBox1.Controls.Add(this.label2);
            this.groupBox1.Controls.Add(this.combo_marca);
            this.groupBox1.Controls.Add(this.label1);
            this.groupBox1.Location = new System.Drawing.Point(35, 13);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size(661, 54);
            this.groupBox1.TabIndex = 7;
            this.groupBox1.TabStop = false;
            this.groupBox1.Text = "Filtros de Búsqueda";
            // 
            // tb_patente
            // 
            this.tb_patente.Location = new System.Drawing.Point(459, 22);
            this.tb_patente.Name = "tb_patente";
            this.tb_patente.Size = new System.Drawing.Size(63, 20);
            this.tb_patente.TabIndex = 6;
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(406, 25);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(47, 13);
            this.label3.TabIndex = 5;
            this.label3.Text = "Patente:";
            // 
            // b_buscar
            // 
            this.b_buscar.Location = new System.Drawing.Point(559, 19);
            this.b_buscar.Name = "b_buscar";
            this.b_buscar.Size = new System.Drawing.Size(75, 23);
            this.b_buscar.TabIndex = 7;
            this.b_buscar.Text = "Buscar";
            this.b_buscar.UseVisualStyleBackColor = true;
            this.b_buscar.Click += new System.EventHandler(this.b_buscar_Click);
            // 
            // combo_servicio
            // 
            this.combo_servicio.FormattingEnabled = true;
            this.combo_servicio.Location = new System.Drawing.Point(279, 22);
            this.combo_servicio.Name = "combo_servicio";
            this.combo_servicio.Size = new System.Drawing.Size(104, 21);
            this.combo_servicio.TabIndex = 3;
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(186, 25);
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
            this.combo_marca.Size = new System.Drawing.Size(95, 21);
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
            // listado_micros
            // 
            this.listado_micros.AllowUserToAddRows = false;
            this.listado_micros.AllowUserToDeleteRows = false;
            this.listado_micros.ColumnHeadersHeight = 20;
            this.listado_micros.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.id_micro,
            this.fin_vida_util,
            this.Patente,
            this.Marca,
            this.Modelo,
            this.TipoServicio,
            this.NButacas,
            this.KG,
            this.FueraServicio,
            this.FinVidaUtil,
            this.modificacion});
            this.listado_micros.Location = new System.Drawing.Point(35, 78);
            this.listado_micros.MultiSelect = false;
            this.listado_micros.Name = "listado_micros";
            this.listado_micros.ReadOnly = true;
            this.listado_micros.RowHeadersWidth = 30;
            this.listado_micros.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.listado_micros.Size = new System.Drawing.Size(661, 240);
            this.listado_micros.TabIndex = 6;
            this.listado_micros.CellContentClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.listado_micros_CellContentClick);
            // 
            // id_micro
            // 
            this.id_micro.HeaderText = "id_micro";
            this.id_micro.MinimumWidth = 100;
            this.id_micro.Name = "id_micro";
            this.id_micro.ReadOnly = true;
            this.id_micro.Visible = false;
            // 
            // fin_vida_util
            // 
            this.fin_vida_util.HeaderText = "fin_vida_util";
            this.fin_vida_util.Name = "fin_vida_util";
            this.fin_vida_util.ReadOnly = true;
            this.fin_vida_util.Visible = false;
            // 
            // Patente
            // 
            this.Patente.HeaderText = "Patente";
            this.Patente.Name = "Patente";
            this.Patente.ReadOnly = true;
            this.Patente.Width = 80;
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
            // TipoServicio
            // 
            this.TipoServicio.HeaderText = "Servicio";
            this.TipoServicio.Name = "TipoServicio";
            this.TipoServicio.ReadOnly = true;
            // 
            // NButacas
            // 
            this.NButacas.HeaderText = "Butacas";
            this.NButacas.Name = "NButacas";
            this.NButacas.ReadOnly = true;
            this.NButacas.Width = 50;
            // 
            // KG
            // 
            this.KG.HeaderText = "KG";
            this.KG.Name = "KG";
            this.KG.ReadOnly = true;
            this.KG.Width = 50;
            // 
            // FueraServicio
            // 
            this.FueraServicio.HeaderText = "Fuera de Servicio";
            this.FueraServicio.Name = "FueraServicio";
            this.FueraServicio.ReadOnly = true;
            this.FueraServicio.Width = 50;
            // 
            // FinVidaUtil
            // 
            this.FinVidaUtil.HeaderText = "Fin Vida Util";
            this.FinVidaUtil.Name = "FinVidaUtil";
            this.FinVidaUtil.ReadOnly = true;
            this.FinVidaUtil.Width = 50;
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
            this.ClientSize = new System.Drawing.Size(729, 375);
            this.Controls.Add(this.b_nuevo);
            this.Controls.Add(this.groupBox1);
            this.Controls.Add(this.listado_micros);
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.Name = "ABM_Micro";
            this.Text = "ABM de Micro";
            this.groupBox1.ResumeLayout(false);
            this.groupBox1.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.listado_micros)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Button b_nuevo;
        private System.Windows.Forms.GroupBox groupBox1;
        private System.Windows.Forms.Button b_buscar;
        private System.Windows.Forms.ComboBox combo_servicio;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.ComboBox combo_marca;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.DataGridView listado_micros;
        private System.Windows.Forms.TextBox tb_patente;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.DataGridViewTextBoxColumn id_micro;
        private System.Windows.Forms.DataGridViewTextBoxColumn fin_vida_util;
        private System.Windows.Forms.DataGridViewTextBoxColumn Patente;
        private System.Windows.Forms.DataGridViewTextBoxColumn Marca;
        private System.Windows.Forms.DataGridViewTextBoxColumn Modelo;
        private System.Windows.Forms.DataGridViewTextBoxColumn TipoServicio;
        private System.Windows.Forms.DataGridViewTextBoxColumn NButacas;
        private System.Windows.Forms.DataGridViewTextBoxColumn KG;
        private System.Windows.Forms.DataGridViewTextBoxColumn FueraServicio;
        private System.Windows.Forms.DataGridViewTextBoxColumn FinVidaUtil;
        private System.Windows.Forms.DataGridViewImageColumn modificacion;
    }
}