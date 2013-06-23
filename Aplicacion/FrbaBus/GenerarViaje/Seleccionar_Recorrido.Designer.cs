namespace FrbaBus.GenerarViaje
{
    partial class Seleccionar_Recorrido
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(Seleccionar_Recorrido));
            this.listado_recorridos = new System.Windows.Forms.DataGridView();
            this.b_buscar = new System.Windows.Forms.Button();
            this.combo_destino = new System.Windows.Forms.ComboBox();
            this.label2 = new System.Windows.Forms.Label();
            this.combo_origen = new System.Windows.Forms.ComboBox();
            this.label1 = new System.Windows.Forms.Label();
            this.id_recorrido = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.CiudadOrigen = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.CiudadDestino = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.TipoServicio = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.PrecioBasePasaje = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.PrecioBaseKg = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.acciones = new System.Windows.Forms.DataGridViewImageColumn();
            ((System.ComponentModel.ISupportInitialize)(this.listado_recorridos)).BeginInit();
            this.SuspendLayout();
            // 
            // listado_recorridos
            // 
            this.listado_recorridos.AllowUserToAddRows = false;
            this.listado_recorridos.AllowUserToDeleteRows = false;
            this.listado_recorridos.ColumnHeadersHeight = 20;
            this.listado_recorridos.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.id_recorrido,
            this.CiudadOrigen,
            this.CiudadDestino,
            this.TipoServicio,
            this.PrecioBasePasaje,
            this.PrecioBaseKg,
            this.acciones});
            this.listado_recorridos.Location = new System.Drawing.Point(34, 65);
            this.listado_recorridos.MultiSelect = false;
            this.listado_recorridos.Name = "listado_recorridos";
            this.listado_recorridos.ReadOnly = true;
            this.listado_recorridos.RowHeadersWidth = 30;
            this.listado_recorridos.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.listado_recorridos.Size = new System.Drawing.Size(442, 234);
            this.listado_recorridos.TabIndex = 5;
            this.listado_recorridos.CellContentClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.listado_recorridos_CellContentClick);
            // 
            // b_buscar
            // 
            this.b_buscar.Location = new System.Drawing.Point(366, 24);
            this.b_buscar.Name = "b_buscar";
            this.b_buscar.Size = new System.Drawing.Size(75, 23);
            this.b_buscar.TabIndex = 10;
            this.b_buscar.Text = "Buscar";
            this.b_buscar.UseVisualStyleBackColor = true;
            this.b_buscar.Click += new System.EventHandler(this.b_buscar_Click);
            // 
            // combo_destino
            // 
            this.combo_destino.FormattingEnabled = true;
            this.combo_destino.Location = new System.Drawing.Point(252, 26);
            this.combo_destino.Name = "combo_destino";
            this.combo_destino.Size = new System.Drawing.Size(92, 21);
            this.combo_destino.TabIndex = 9;
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(200, 29);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(46, 13);
            this.label2.TabIndex = 8;
            this.label2.Text = "Destino:";
            // 
            // combo_origen
            // 
            this.combo_origen.FormattingEnabled = true;
            this.combo_origen.Location = new System.Drawing.Point(78, 26);
            this.combo_origen.Name = "combo_origen";
            this.combo_origen.Size = new System.Drawing.Size(103, 21);
            this.combo_origen.TabIndex = 7;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(31, 29);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(41, 13);
            this.label1.TabIndex = 6;
            this.label1.Text = "Origen:";
            // 
            // id_recorrido
            // 
            this.id_recorrido.HeaderText = "id_recorrido";
            this.id_recorrido.MinimumWidth = 100;
            this.id_recorrido.Name = "id_recorrido";
            this.id_recorrido.ReadOnly = true;
            this.id_recorrido.Visible = false;
            // 
            // CiudadOrigen
            // 
            this.CiudadOrigen.HeaderText = "Ciudad Origen";
            this.CiudadOrigen.Name = "CiudadOrigen";
            this.CiudadOrigen.ReadOnly = true;
            // 
            // CiudadDestino
            // 
            this.CiudadDestino.HeaderText = "Ciudad Destino";
            this.CiudadDestino.Name = "CiudadDestino";
            this.CiudadDestino.ReadOnly = true;
            // 
            // TipoServicio
            // 
            this.TipoServicio.HeaderText = "Servicio";
            this.TipoServicio.Name = "TipoServicio";
            this.TipoServicio.ReadOnly = true;
            this.TipoServicio.Width = 60;
            // 
            // PrecioBasePasaje
            // 
            this.PrecioBasePasaje.HeaderText = "$/Pasaje";
            this.PrecioBasePasaje.Name = "PrecioBasePasaje";
            this.PrecioBasePasaje.ReadOnly = true;
            this.PrecioBasePasaje.Width = 50;
            // 
            // PrecioBaseKg
            // 
            this.PrecioBaseKg.HeaderText = "$/KG";
            this.PrecioBaseKg.Name = "PrecioBaseKg";
            this.PrecioBaseKg.ReadOnly = true;
            this.PrecioBaseKg.Width = 50;
            // 
            // acciones
            // 
            this.acciones.HeaderText = "";
            this.acciones.MinimumWidth = 32;
            this.acciones.Name = "acciones";
            this.acciones.ReadOnly = true;
            this.acciones.Width = 32;
            // 
            // Seleccionar_Recorrido
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(507, 321);
            this.Controls.Add(this.b_buscar);
            this.Controls.Add(this.combo_destino);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.combo_origen);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.listado_recorridos);
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.Name = "Seleccionar_Recorrido";
            this.Text = "Seleccionar Recorrido";
            ((System.ComponentModel.ISupportInitialize)(this.listado_recorridos)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.DataGridView listado_recorridos;
        private System.Windows.Forms.Button b_buscar;
        private System.Windows.Forms.ComboBox combo_destino;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.ComboBox combo_origen;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.DataGridViewTextBoxColumn id_recorrido;
        private System.Windows.Forms.DataGridViewTextBoxColumn CiudadOrigen;
        private System.Windows.Forms.DataGridViewTextBoxColumn CiudadDestino;
        private System.Windows.Forms.DataGridViewTextBoxColumn TipoServicio;
        private System.Windows.Forms.DataGridViewTextBoxColumn PrecioBasePasaje;
        private System.Windows.Forms.DataGridViewTextBoxColumn PrecioBaseKg;
        private System.Windows.Forms.DataGridViewImageColumn acciones;
    }
}