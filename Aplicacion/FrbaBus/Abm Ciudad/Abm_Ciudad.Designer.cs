namespace FrbaBus.Abm_Ciudad
{
    partial class Abm_Ciudad
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(Abm_Ciudad));
            this.DGVCiudad = new System.Windows.Forms.DataGridView();
            this.id_ciudad = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.NombreDeCiudad = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Habilitada = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.acciones = new System.Windows.Forms.DataGridViewImageColumn();
            this.modificacion = new System.Windows.Forms.DataGridViewImageColumn();
            this.label1 = new System.Windows.Forms.Label();
            this.nueva_ciudad = new System.Windows.Forms.TextBox();
            this.button1 = new System.Windows.Forms.Button();
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            ((System.ComponentModel.ISupportInitialize)(this.DGVCiudad)).BeginInit();
            this.groupBox1.SuspendLayout();
            this.SuspendLayout();
            // 
            // DGVCiudad
            // 
            this.DGVCiudad.AllowUserToAddRows = false;
            this.DGVCiudad.AllowUserToDeleteRows = false;
            this.DGVCiudad.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.DGVCiudad.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.id_ciudad,
            this.NombreDeCiudad,
            this.Habilitada,
            this.acciones,
            this.modificacion});
            this.DGVCiudad.Location = new System.Drawing.Point(28, 25);
            this.DGVCiudad.MultiSelect = false;
            this.DGVCiudad.Name = "DGVCiudad";
            this.DGVCiudad.ReadOnly = true;
            this.DGVCiudad.RowHeadersWidth = 30;
            this.DGVCiudad.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.DGVCiudad.Size = new System.Drawing.Size(464, 240);
            this.DGVCiudad.TabIndex = 2;
            this.DGVCiudad.CellContentClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.DGVCiudad_CellContentClick);
            // 
            // id_ciudad
            // 
            this.id_ciudad.HeaderText = "id_ciudad";
            this.id_ciudad.MinimumWidth = 100;
            this.id_ciudad.Name = "id_ciudad";
            this.id_ciudad.ReadOnly = true;
            this.id_ciudad.Visible = false;
            // 
            // NombreDeCiudad
            // 
            this.NombreDeCiudad.HeaderText = "Nombre de la Ciudad";
            this.NombreDeCiudad.Name = "NombreDeCiudad";
            this.NombreDeCiudad.ReadOnly = true;
            this.NombreDeCiudad.Width = 200;
            // 
            // Habilitada
            // 
            this.Habilitada.HeaderText = "Habilitada";
            this.Habilitada.Name = "Habilitada";
            this.Habilitada.ReadOnly = true;
            this.Habilitada.Width = 150;
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
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(6, 38);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(47, 13);
            this.label1.TabIndex = 6;
            this.label1.Text = "Nombre:";
            // 
            // nueva_ciudad
            // 
            this.nueva_ciudad.Location = new System.Drawing.Point(59, 35);
            this.nueva_ciudad.Name = "nueva_ciudad";
            this.nueva_ciudad.Size = new System.Drawing.Size(159, 20);
            this.nueva_ciudad.TabIndex = 5;
            // 
            // button1
            // 
            this.button1.Location = new System.Drawing.Point(246, 33);
            this.button1.Name = "button1";
            this.button1.Size = new System.Drawing.Size(75, 23);
            this.button1.TabIndex = 6;
            this.button1.Text = "Crear";
            this.button1.UseVisualStyleBackColor = true;
            this.button1.Click += new System.EventHandler(this.button1_Click);
            // 
            // groupBox1
            // 
            this.groupBox1.Controls.Add(this.label1);
            this.groupBox1.Controls.Add(this.button1);
            this.groupBox1.Controls.Add(this.nueva_ciudad);
            this.groupBox1.Location = new System.Drawing.Point(28, 290);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size(464, 82);
            this.groupBox1.TabIndex = 7;
            this.groupBox1.TabStop = false;
            this.groupBox1.Text = "Crear Nueva Ciudad";
            // 
            // Abm_Ciudad
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(524, 391);
            this.Controls.Add(this.groupBox1);
            this.Controls.Add(this.DGVCiudad);
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.Name = "Abm_Ciudad";
            this.Text = "ABM de Ciudad";
            this.Load += new System.EventHandler(this.Abm_Ciudad_Load);
            ((System.ComponentModel.ISupportInitialize)(this.DGVCiudad)).EndInit();
            this.groupBox1.ResumeLayout(false);
            this.groupBox1.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.DataGridView DGVCiudad;
        private System.Windows.Forms.DataGridViewTextBoxColumn id_ciudad;
        private System.Windows.Forms.DataGridViewTextBoxColumn NombreDeCiudad;
        private System.Windows.Forms.DataGridViewTextBoxColumn Habilitada;
        private System.Windows.Forms.DataGridViewImageColumn acciones;
        private System.Windows.Forms.DataGridViewImageColumn modificacion;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.TextBox nueva_ciudad;
        private System.Windows.Forms.Button button1;
        private System.Windows.Forms.GroupBox groupBox1;
    }
}