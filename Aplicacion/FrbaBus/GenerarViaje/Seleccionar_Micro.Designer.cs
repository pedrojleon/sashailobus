namespace FrbaBus.GenerarViaje
{
    partial class Seleccionar_Micro
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(Seleccionar_Micro));
            this.listado_micros = new System.Windows.Forms.DataGridView();
            this.button1 = new System.Windows.Forms.Button();
            this.combo_marca = new System.Windows.Forms.ComboBox();
            this.label6 = new System.Windows.Forms.Label();
            this.id_micro = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Patente = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Marca = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Modelo = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.TipoServicio = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.NButacas = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.KG = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.acciones = new System.Windows.Forms.DataGridViewImageColumn();
            ((System.ComponentModel.ISupportInitialize)(this.listado_micros)).BeginInit();
            this.SuspendLayout();
            // 
            // listado_micros
            // 
            this.listado_micros.AllowUserToAddRows = false;
            this.listado_micros.AllowUserToDeleteRows = false;
            this.listado_micros.ColumnHeadersHeight = 20;
            this.listado_micros.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.id_micro,
            this.Patente,
            this.Marca,
            this.Modelo,
            this.TipoServicio,
            this.NButacas,
            this.KG,
            this.acciones});
            this.listado_micros.Location = new System.Drawing.Point(25, 62);
            this.listado_micros.MultiSelect = false;
            this.listado_micros.Name = "listado_micros";
            this.listado_micros.ReadOnly = true;
            this.listado_micros.RowHeadersWidth = 30;
            this.listado_micros.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.listado_micros.Size = new System.Drawing.Size(441, 194);
            this.listado_micros.TabIndex = 9;
            this.listado_micros.CellContentClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.listado_micros_CellContentClick);
            // 
            // button1
            // 
            this.button1.Location = new System.Drawing.Point(167, 20);
            this.button1.Name = "button1";
            this.button1.Size = new System.Drawing.Size(75, 23);
            this.button1.TabIndex = 18;
            this.button1.Text = "Buscar";
            this.button1.UseVisualStyleBackColor = true;
            this.button1.Click += new System.EventHandler(this.button1_Click);
            // 
            // combo_marca
            // 
            this.combo_marca.FormattingEnabled = true;
            this.combo_marca.Location = new System.Drawing.Point(69, 22);
            this.combo_marca.Name = "combo_marca";
            this.combo_marca.Size = new System.Drawing.Size(78, 21);
            this.combo_marca.TabIndex = 13;
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.Location = new System.Drawing.Point(22, 25);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(40, 13);
            this.label6.TabIndex = 12;
            this.label6.Text = "Marca:";
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
            this.Patente.Width = 50;
            // 
            // Marca
            // 
            this.Marca.HeaderText = "Marca";
            this.Marca.Name = "Marca";
            this.Marca.ReadOnly = true;
            this.Marca.Width = 70;
            // 
            // Modelo
            // 
            this.Modelo.HeaderText = "Modelo";
            this.Modelo.Name = "Modelo";
            this.Modelo.ReadOnly = true;
            this.Modelo.Width = 70;
            // 
            // TipoServicio
            // 
            this.TipoServicio.HeaderText = "Servicio";
            this.TipoServicio.Name = "TipoServicio";
            this.TipoServicio.ReadOnly = true;
            this.TipoServicio.Width = 70;
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
            // acciones
            // 
            this.acciones.HeaderText = "";
            this.acciones.MinimumWidth = 32;
            this.acciones.Name = "acciones";
            this.acciones.ReadOnly = true;
            this.acciones.Width = 32;
            // 
            // Seleccionar_Micro
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(494, 288);
            this.Controls.Add(this.button1);
            this.Controls.Add(this.combo_marca);
            this.Controls.Add(this.label6);
            this.Controls.Add(this.listado_micros);
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.Name = "Seleccionar_Micro";
            this.Text = "Seleccionar Micro";
            ((System.ComponentModel.ISupportInitialize)(this.listado_micros)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.DataGridView listado_micros;
        private System.Windows.Forms.Button button1;
        private System.Windows.Forms.ComboBox combo_marca;
        private System.Windows.Forms.Label label6;
        private System.Windows.Forms.DataGridViewTextBoxColumn id_micro;
        private System.Windows.Forms.DataGridViewTextBoxColumn Patente;
        private System.Windows.Forms.DataGridViewTextBoxColumn Marca;
        private System.Windows.Forms.DataGridViewTextBoxColumn Modelo;
        private System.Windows.Forms.DataGridViewTextBoxColumn TipoServicio;
        private System.Windows.Forms.DataGridViewTextBoxColumn NButacas;
        private System.Windows.Forms.DataGridViewTextBoxColumn KG;
        private System.Windows.Forms.DataGridViewImageColumn acciones;
    }
}