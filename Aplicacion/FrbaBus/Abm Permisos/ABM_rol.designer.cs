namespace FrbaBus.Abm_Permisos
{
    partial class ABMRol
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(ABMRol));
            this.DGVRol = new System.Windows.Forms.DataGridView();
            this.CrearRol = new System.Windows.Forms.Button();
            this.NombreDelRol = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Habilitado = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.acciones = new System.Windows.Forms.DataGridViewImageColumn();
            this.modificacion = new System.Windows.Forms.DataGridViewImageColumn();
            ((System.ComponentModel.ISupportInitialize)(this.DGVRol)).BeginInit();
            this.SuspendLayout();
            // 
            // DGVRol
            // 
            this.DGVRol.AllowUserToAddRows = false;
            this.DGVRol.AllowUserToDeleteRows = false;
            this.DGVRol.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.DGVRol.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.NombreDelRol,
            this.Habilitado,
            this.acciones,
            this.modificacion});
            this.DGVRol.Location = new System.Drawing.Point(62, 28);
            this.DGVRol.MultiSelect = false;
            this.DGVRol.Name = "DGVRol";
            this.DGVRol.ReadOnly = true;
            this.DGVRol.RowHeadersWidth = 30;
            this.DGVRol.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.DGVRol.Size = new System.Drawing.Size(396, 180);
            this.DGVRol.TabIndex = 0;
            this.DGVRol.CellContentClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.DGVRol_CellContentClick);
            // 
            // CrearRol
            // 
            this.CrearRol.Location = new System.Drawing.Point(383, 225);
            this.CrearRol.Name = "CrearRol";
            this.CrearRol.Size = new System.Drawing.Size(75, 23);
            this.CrearRol.TabIndex = 1;
            this.CrearRol.Text = "Crear nuevo";
            this.CrearRol.UseVisualStyleBackColor = true;
            this.CrearRol.Click += new System.EventHandler(this.CrearRol_Click);
            // 
            // NombreDelRol
            // 
            this.NombreDelRol.HeaderText = "Nombre del Rol";
            this.NombreDelRol.Name = "NombreDelRol";
            this.NombreDelRol.ReadOnly = true;
            this.NombreDelRol.Width = 150;
            // 
            // Habilitado
            // 
            this.Habilitado.HeaderText = "Habilitado";
            this.Habilitado.Name = "Habilitado";
            this.Habilitado.ReadOnly = true;
            this.Habilitado.Width = 150;
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
            // ABMRol
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(521, 281);
            this.Controls.Add(this.CrearRol);
            this.Controls.Add(this.DGVRol);
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.Name = "ABMRol";
            this.Text = "ABM de Rol";
            this.Load += new System.EventHandler(this.ABMRol_Load);
            ((System.ComponentModel.ISupportInitialize)(this.DGVRol)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.DataGridView DGVRol;
        private System.Windows.Forms.Button CrearRol;
        private System.Windows.Forms.DataGridViewTextBoxColumn NombreDelRol;
        private System.Windows.Forms.DataGridViewTextBoxColumn Habilitado;
        private System.Windows.Forms.DataGridViewImageColumn acciones;
        private System.Windows.Forms.DataGridViewImageColumn modificacion;

    }
}