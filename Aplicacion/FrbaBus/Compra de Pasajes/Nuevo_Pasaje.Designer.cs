namespace FrbaBus.Compra_de_Pasajes
{
    partial class Nuevo_Pasaje
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(Nuevo_Pasaje));
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.listado_butacas = new System.Windows.Forms.DataGridView();
            this.label_butaca = new System.Windows.Forms.Label();
            this.label8 = new System.Windows.Forms.Label();
            this.id_butaca = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Micro = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Numero = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Tipo = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Piso = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.acciones = new System.Windows.Forms.DataGridViewImageColumn();
            this.icono_cruz = new System.Windows.Forms.PictureBox();
            this.groupBox2 = new System.Windows.Forms.GroupBox();
            this.label1 = new System.Windows.Forms.Label();
            this.nombre = new System.Windows.Forms.TextBox();
            this.apellido = new System.Windows.Forms.TextBox();
            this.label2 = new System.Windows.Forms.Label();
            this.dni = new System.Windows.Forms.TextBox();
            this.label3 = new System.Windows.Forms.Label();
            this.telefono = new System.Windows.Forms.TextBox();
            this.label4 = new System.Windows.Forms.Label();
            this.direccion = new System.Windows.Forms.TextBox();
            this.label5 = new System.Windows.Forms.Label();
            this.label6 = new System.Windows.Forms.Label();
            this.email = new System.Windows.Forms.TextBox();
            this.label7 = new System.Windows.Forms.Label();
            this.f_nac = new System.Windows.Forms.DateTimePicker();
            this.label9 = new System.Windows.Forms.Label();
            this.combo_sexo = new System.Windows.Forms.ComboBox();
            this.b_guardar = new System.Windows.Forms.Button();
            this.groupBox1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.listado_butacas)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.icono_cruz)).BeginInit();
            this.groupBox2.SuspendLayout();
            this.SuspendLayout();
            // 
            // groupBox1
            // 
            this.groupBox1.Controls.Add(this.listado_butacas);
            this.groupBox1.Location = new System.Drawing.Point(25, 21);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size(371, 430);
            this.groupBox1.TabIndex = 0;
            this.groupBox1.TabStop = false;
            this.groupBox1.Text = "Selección de Butaca";
            // 
            // listado_butacas
            // 
            this.listado_butacas.AllowUserToAddRows = false;
            this.listado_butacas.AllowUserToDeleteRows = false;
            this.listado_butacas.ColumnHeadersHeight = 20;
            this.listado_butacas.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.id_butaca,
            this.Micro,
            this.Numero,
            this.Tipo,
            this.Piso,
            this.acciones});
            this.listado_butacas.Location = new System.Drawing.Point(24, 30);
            this.listado_butacas.MultiSelect = false;
            this.listado_butacas.Name = "listado_butacas";
            this.listado_butacas.ReadOnly = true;
            this.listado_butacas.RowHeadersWidth = 30;
            this.listado_butacas.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.listado_butacas.Size = new System.Drawing.Size(323, 380);
            this.listado_butacas.TabIndex = 10;
            this.listado_butacas.CellContentClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.listado_butacas_CellContentClick);
            // 
            // label_butaca
            // 
            this.label_butaca.AutoSize = true;
            this.label_butaca.ForeColor = System.Drawing.Color.Green;
            this.label_butaca.Location = new System.Drawing.Point(424, 73);
            this.label_butaca.Name = "label_butaca";
            this.label_butaca.Size = new System.Drawing.Size(10, 13);
            this.label_butaca.TabIndex = 65;
            this.label_butaca.Text = "-";
            // 
            // label8
            // 
            this.label8.AutoSize = true;
            this.label8.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label8.Location = new System.Drawing.Point(424, 51);
            this.label8.Name = "label8";
            this.label8.Size = new System.Drawing.Size(132, 13);
            this.label8.TabIndex = 64;
            this.label8.Text = "Butaca Seleccionada:";
            // 
            // id_butaca
            // 
            this.id_butaca.HeaderText = "id_butaca";
            this.id_butaca.MinimumWidth = 100;
            this.id_butaca.Name = "id_butaca";
            this.id_butaca.ReadOnly = true;
            this.id_butaca.Visible = false;
            // 
            // Micro
            // 
            this.Micro.HeaderText = "Micro";
            this.Micro.Name = "Micro";
            this.Micro.ReadOnly = true;
            this.Micro.Width = 70;
            // 
            // Numero
            // 
            this.Numero.HeaderText = "Número";
            this.Numero.Name = "Numero";
            this.Numero.ReadOnly = true;
            this.Numero.Width = 50;
            // 
            // Tipo
            // 
            this.Tipo.HeaderText = "Tipo";
            this.Tipo.Name = "Tipo";
            this.Tipo.ReadOnly = true;
            this.Tipo.Width = 70;
            // 
            // Piso
            // 
            this.Piso.HeaderText = "Piso";
            this.Piso.Name = "Piso";
            this.Piso.ReadOnly = true;
            this.Piso.Width = 50;
            // 
            // acciones
            // 
            this.acciones.HeaderText = "";
            this.acciones.MinimumWidth = 32;
            this.acciones.Name = "acciones";
            this.acciones.ReadOnly = true;
            this.acciones.Width = 32;
            // 
            // icono_cruz
            // 
            this.icono_cruz.Cursor = System.Windows.Forms.Cursors.Hand;
            this.icono_cruz.Image = ((System.Drawing.Image)(resources.GetObject("icono_cruz.Image")));
            this.icono_cruz.Location = new System.Drawing.Point(632, 73);
            this.icono_cruz.Name = "icono_cruz";
            this.icono_cruz.Size = new System.Drawing.Size(16, 23);
            this.icono_cruz.TabIndex = 66;
            this.icono_cruz.TabStop = false;
            this.icono_cruz.Visible = false;
            this.icono_cruz.Click += new System.EventHandler(this.icono_cruz_Click);
            // 
            // groupBox2
            // 
            this.groupBox2.Controls.Add(this.combo_sexo);
            this.groupBox2.Controls.Add(this.label9);
            this.groupBox2.Controls.Add(this.f_nac);
            this.groupBox2.Controls.Add(this.label6);
            this.groupBox2.Controls.Add(this.email);
            this.groupBox2.Controls.Add(this.label7);
            this.groupBox2.Controls.Add(this.telefono);
            this.groupBox2.Controls.Add(this.label4);
            this.groupBox2.Controls.Add(this.direccion);
            this.groupBox2.Controls.Add(this.label5);
            this.groupBox2.Controls.Add(this.dni);
            this.groupBox2.Controls.Add(this.label3);
            this.groupBox2.Controls.Add(this.apellido);
            this.groupBox2.Controls.Add(this.label2);
            this.groupBox2.Controls.Add(this.nombre);
            this.groupBox2.Controls.Add(this.label1);
            this.groupBox2.Location = new System.Drawing.Point(427, 178);
            this.groupBox2.Name = "groupBox2";
            this.groupBox2.Size = new System.Drawing.Size(347, 188);
            this.groupBox2.TabIndex = 1;
            this.groupBox2.TabStop = false;
            this.groupBox2.Text = "Datos del Pasajero";
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(26, 77);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(47, 13);
            this.label1.TabIndex = 0;
            this.label1.Text = "Nombre:";
            // 
            // nombre
            // 
            this.nombre.Location = new System.Drawing.Point(81, 74);
            this.nombre.Name = "nombre";
            this.nombre.Size = new System.Drawing.Size(83, 20);
            this.nombre.TabIndex = 1;
            // 
            // apellido
            // 
            this.apellido.Location = new System.Drawing.Point(239, 74);
            this.apellido.Name = "apellido";
            this.apellido.Size = new System.Drawing.Size(83, 20);
            this.apellido.TabIndex = 3;
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(186, 77);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(47, 13);
            this.label2.TabIndex = 2;
            this.label2.Text = "Apellido:";
            // 
            // dni
            // 
            this.dni.Location = new System.Drawing.Point(81, 36);
            this.dni.Name = "dni";
            this.dni.Size = new System.Drawing.Size(83, 20);
            this.dni.TabIndex = 5;
            this.dni.Leave += new System.EventHandler(this.dni_Leave);
            this.dni.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.dni_KeyPress);
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(26, 39);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(29, 13);
            this.label3.TabIndex = 4;
            this.label3.Text = "DNI:";
            // 
            // telefono
            // 
            this.telefono.Location = new System.Drawing.Point(239, 112);
            this.telefono.Name = "telefono";
            this.telefono.Size = new System.Drawing.Size(83, 20);
            this.telefono.TabIndex = 9;
            this.telefono.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.telefono_KeyPress);
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(186, 115);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(52, 13);
            this.label4.TabIndex = 8;
            this.label4.Text = "Teléfono:";
            // 
            // direccion
            // 
            this.direccion.Location = new System.Drawing.Point(81, 112);
            this.direccion.Name = "direccion";
            this.direccion.Size = new System.Drawing.Size(83, 20);
            this.direccion.TabIndex = 7;
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Location = new System.Drawing.Point(26, 115);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(55, 13);
            this.label5.TabIndex = 6;
            this.label5.Text = "Dirección:";
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.Location = new System.Drawing.Point(186, 151);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(39, 13);
            this.label6.TabIndex = 12;
            this.label6.Text = "F.Nac:";
            // 
            // email
            // 
            this.email.Location = new System.Drawing.Point(81, 148);
            this.email.Name = "email";
            this.email.Size = new System.Drawing.Size(83, 20);
            this.email.TabIndex = 11;
            // 
            // label7
            // 
            this.label7.AutoSize = true;
            this.label7.Location = new System.Drawing.Point(26, 151);
            this.label7.Name = "label7";
            this.label7.Size = new System.Drawing.Size(35, 13);
            this.label7.TabIndex = 10;
            this.label7.Text = "Email:";
            // 
            // f_nac
            // 
            this.f_nac.Location = new System.Drawing.Point(239, 148);
            this.f_nac.Name = "f_nac";
            this.f_nac.Size = new System.Drawing.Size(83, 20);
            this.f_nac.TabIndex = 14;
            // 
            // label9
            // 
            this.label9.AutoSize = true;
            this.label9.Location = new System.Drawing.Point(186, 39);
            this.label9.Name = "label9";
            this.label9.Size = new System.Drawing.Size(34, 13);
            this.label9.TabIndex = 15;
            this.label9.Text = "Sexo:";
            // 
            // combo_sexo
            // 
            this.combo_sexo.FormattingEnabled = true;
            this.combo_sexo.Location = new System.Drawing.Point(239, 36);
            this.combo_sexo.Name = "combo_sexo";
            this.combo_sexo.Size = new System.Drawing.Size(42, 21);
            this.combo_sexo.TabIndex = 16;
            // 
            // b_guardar
            // 
            this.b_guardar.Location = new System.Drawing.Point(558, 408);
            this.b_guardar.Name = "b_guardar";
            this.b_guardar.Size = new System.Drawing.Size(75, 23);
            this.b_guardar.TabIndex = 67;
            this.b_guardar.Text = "Guardar";
            this.b_guardar.UseVisualStyleBackColor = true;
            this.b_guardar.Click += new System.EventHandler(this.b_guardar_Click);
            // 
            // Nuevo_Pasaje
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(802, 477);
            this.Controls.Add(this.b_guardar);
            this.Controls.Add(this.icono_cruz);
            this.Controls.Add(this.groupBox2);
            this.Controls.Add(this.label_butaca);
            this.Controls.Add(this.groupBox1);
            this.Controls.Add(this.label8);
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.Name = "Nuevo_Pasaje";
            this.Text = "Nuevo Pasaje";
            this.groupBox1.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.listado_butacas)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.icono_cruz)).EndInit();
            this.groupBox2.ResumeLayout(false);
            this.groupBox2.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.GroupBox groupBox1;
        private System.Windows.Forms.DataGridView listado_butacas;
        private System.Windows.Forms.Label label_butaca;
        private System.Windows.Forms.Label label8;
        private System.Windows.Forms.DataGridViewTextBoxColumn id_butaca;
        private System.Windows.Forms.DataGridViewTextBoxColumn Micro;
        private System.Windows.Forms.DataGridViewTextBoxColumn Numero;
        private System.Windows.Forms.DataGridViewTextBoxColumn Tipo;
        private System.Windows.Forms.DataGridViewTextBoxColumn Piso;
        private System.Windows.Forms.DataGridViewImageColumn acciones;
        private System.Windows.Forms.PictureBox icono_cruz;
        private System.Windows.Forms.GroupBox groupBox2;
        private System.Windows.Forms.Label label6;
        private System.Windows.Forms.TextBox email;
        private System.Windows.Forms.Label label7;
        private System.Windows.Forms.TextBox telefono;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.TextBox direccion;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.TextBox dni;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.TextBox apellido;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.TextBox nombre;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.DateTimePicker f_nac;
        private System.Windows.Forms.ComboBox combo_sexo;
        private System.Windows.Forms.Label label9;
        private System.Windows.Forms.Button b_guardar;

    }
}