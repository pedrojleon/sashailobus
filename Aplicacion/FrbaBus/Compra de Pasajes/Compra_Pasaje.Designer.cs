﻿namespace FrbaBus.Compra_de_Pasajes
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
            this.icono_cruz = new System.Windows.Forms.PictureBox();
            this.label_viaje = new System.Windows.Forms.Label();
            this.label8 = new System.Windows.Forms.Label();
            this.listado_de_viajes = new System.Windows.Forms.DataGridView();
            this.id_viaje = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Micro = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.TipoServicio = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Salida = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.LLegadaEstim = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.butacas = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.kg = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.acciones = new System.Windows.Forms.DataGridViewImageColumn();
            this.b_guardar = new System.Windows.Forms.Button();
            this.label2 = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.destino = new System.Windows.Forms.ComboBox();
            this.origen = new System.Windows.Forms.ComboBox();
            this.f_salida = new System.Windows.Forms.DateTimePicker();
            this.label1 = new System.Windows.Forms.Label();
            this.groupBox2 = new System.Windows.Forms.GroupBox();
            this.label4 = new System.Windows.Forms.Label();
            this.icono_mas = new System.Windows.Forms.PictureBox();
            this.listado_pasajes = new System.Windows.Forms.DataGridView();
            this.id_butaca = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.id_pasaje_provisorio = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Pasajero = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Dni = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.nro_butaca = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.tipo_butaca = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.piso_butaca = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.eliminar_pasaje = new System.Windows.Forms.DataGridViewImageColumn();
            this.groupBox3 = new System.Windows.Forms.GroupBox();
            this.label5 = new System.Windows.Forms.Label();
            this.pictureBox1 = new System.Windows.Forms.PictureBox();
            this.listado_encomiendas = new System.Windows.Forms.DataGridView();
            this.id_encomienda_provisoria = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.encomendero = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.enco_dni = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.kilos = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.eliminar = new System.Windows.Forms.DataGridViewImageColumn();
            this.button1 = new System.Windows.Forms.Button();
            this.groupBox1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.icono_cruz)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.listado_de_viajes)).BeginInit();
            this.groupBox2.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.icono_mas)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.listado_pasajes)).BeginInit();
            this.groupBox3.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.listado_encomiendas)).BeginInit();
            this.SuspendLayout();
            // 
            // groupBox1
            // 
            this.groupBox1.Controls.Add(this.icono_cruz);
            this.groupBox1.Controls.Add(this.label_viaje);
            this.groupBox1.Controls.Add(this.label8);
            this.groupBox1.Controls.Add(this.listado_de_viajes);
            this.groupBox1.Controls.Add(this.b_guardar);
            this.groupBox1.Controls.Add(this.label2);
            this.groupBox1.Controls.Add(this.label3);
            this.groupBox1.Controls.Add(this.destino);
            this.groupBox1.Controls.Add(this.origen);
            this.groupBox1.Controls.Add(this.f_salida);
            this.groupBox1.Controls.Add(this.label1);
            this.groupBox1.Location = new System.Drawing.Point(19, 10);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size(743, 244);
            this.groupBox1.TabIndex = 51;
            this.groupBox1.TabStop = false;
            this.groupBox1.Text = "Viaje";
            // 
            // icono_cruz
            // 
            this.icono_cruz.Cursor = System.Windows.Forms.Cursors.Hand;
            this.icono_cruz.Image = ((System.Drawing.Image)(resources.GetObject("icono_cruz.Image")));
            this.icono_cruz.Location = new System.Drawing.Point(702, 216);
            this.icono_cruz.Name = "icono_cruz";
            this.icono_cruz.Size = new System.Drawing.Size(16, 23);
            this.icono_cruz.TabIndex = 64;
            this.icono_cruz.TabStop = false;
            this.icono_cruz.Visible = false;
            this.icono_cruz.Click += new System.EventHandler(this.icono_cruz_Click);
            // 
            // label_viaje
            // 
            this.label_viaje.AutoSize = true;
            this.label_viaje.ForeColor = System.Drawing.Color.Green;
            this.label_viaje.Location = new System.Drawing.Point(155, 216);
            this.label_viaje.Name = "label_viaje";
            this.label_viaje.Size = new System.Drawing.Size(10, 13);
            this.label_viaje.TabIndex = 63;
            this.label_viaje.Text = "-";
            // 
            // label8
            // 
            this.label8.AutoSize = true;
            this.label8.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label8.Location = new System.Drawing.Point(26, 216);
            this.label8.Name = "label8";
            this.label8.Size = new System.Drawing.Size(120, 13);
            this.label8.TabIndex = 62;
            this.label8.Text = "Viaje Seleccionado:";
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
            this.listado_de_viajes.Location = new System.Drawing.Point(25, 55);
            this.listado_de_viajes.MultiSelect = false;
            this.listado_de_viajes.Name = "listado_de_viajes";
            this.listado_de_viajes.ReadOnly = true;
            this.listado_de_viajes.RowHeadersWidth = 30;
            this.listado_de_viajes.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.listado_de_viajes.Size = new System.Drawing.Size(689, 146);
            this.listado_de_viajes.TabIndex = 60;
            this.listado_de_viajes.CellContentClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.listado_de_viajes_CellContentClick);
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
            this.Micro.Width = 70;
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
            this.Salida.Width = 120;
            // 
            // LLegadaEstim
            // 
            this.LLegadaEstim.HeaderText = "LLegada Estimada";
            this.LLegadaEstim.Name = "LLegadaEstim";
            this.LLegadaEstim.ReadOnly = true;
            this.LLegadaEstim.Width = 120;
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
            // b_guardar
            // 
            this.b_guardar.Location = new System.Drawing.Point(603, 20);
            this.b_guardar.Name = "b_guardar";
            this.b_guardar.Size = new System.Drawing.Size(75, 23);
            this.b_guardar.TabIndex = 59;
            this.b_guardar.Text = "Buscar";
            this.b_guardar.UseVisualStyleBackColor = true;
            this.b_guardar.Click += new System.EventHandler(this.b_guardar_Click);
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(424, 25);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(46, 13);
            this.label2.TabIndex = 58;
            this.label2.Text = "Destino:";
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(233, 25);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(41, 13);
            this.label3.TabIndex = 57;
            this.label3.Text = "Origen:";
            // 
            // destino
            // 
            this.destino.FormattingEnabled = true;
            this.destino.Location = new System.Drawing.Point(476, 22);
            this.destino.Name = "destino";
            this.destino.Size = new System.Drawing.Size(101, 21);
            this.destino.TabIndex = 56;
            // 
            // origen
            // 
            this.origen.FormattingEnabled = true;
            this.origen.Location = new System.Drawing.Point(280, 22);
            this.origen.Name = "origen";
            this.origen.Size = new System.Drawing.Size(120, 21);
            this.origen.TabIndex = 55;
            // 
            // f_salida
            // 
            this.f_salida.Location = new System.Drawing.Point(64, 23);
            this.f_salida.Name = "f_salida";
            this.f_salida.Size = new System.Drawing.Size(146, 20);
            this.f_salida.TabIndex = 54;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(20, 25);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(40, 13);
            this.label1.TabIndex = 53;
            this.label1.Text = "Fecha:";
            // 
            // groupBox2
            // 
            this.groupBox2.Controls.Add(this.label4);
            this.groupBox2.Controls.Add(this.icono_mas);
            this.groupBox2.Controls.Add(this.listado_pasajes);
            this.groupBox2.Location = new System.Drawing.Point(19, 272);
            this.groupBox2.Name = "groupBox2";
            this.groupBox2.Size = new System.Drawing.Size(743, 153);
            this.groupBox2.TabIndex = 52;
            this.groupBox2.TabStop = false;
            this.groupBox2.Text = "Pasajes";
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(518, 36);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(138, 13);
            this.label4.TabIndex = 63;
            this.label4.Text = "Agregar Pasaje a la Compra";
            // 
            // icono_mas
            // 
            this.icono_mas.Cursor = System.Windows.Forms.Cursors.Hand;
            this.icono_mas.Image = ((System.Drawing.Image)(resources.GetObject("icono_mas.Image")));
            this.icono_mas.Location = new System.Drawing.Point(686, 36);
            this.icono_mas.Name = "icono_mas";
            this.icono_mas.Size = new System.Drawing.Size(16, 23);
            this.icono_mas.TabIndex = 62;
            this.icono_mas.TabStop = false;
            this.icono_mas.Click += new System.EventHandler(this.icono_mas_Click);
            // 
            // listado_pasajes
            // 
            this.listado_pasajes.AllowUserToAddRows = false;
            this.listado_pasajes.AllowUserToDeleteRows = false;
            this.listado_pasajes.ColumnHeadersHeight = 20;
            this.listado_pasajes.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.id_butaca,
            this.id_pasaje_provisorio,
            this.Pasajero,
            this.Dni,
            this.nro_butaca,
            this.tipo_butaca,
            this.piso_butaca,
            this.eliminar_pasaje});
            this.listado_pasajes.Location = new System.Drawing.Point(19, 23);
            this.listado_pasajes.MultiSelect = false;
            this.listado_pasajes.Name = "listado_pasajes";
            this.listado_pasajes.ReadOnly = true;
            this.listado_pasajes.RowHeadersWidth = 30;
            this.listado_pasajes.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.listado_pasajes.Size = new System.Drawing.Size(445, 112);
            this.listado_pasajes.TabIndex = 61;
            this.listado_pasajes.CellContentClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.listado_pasajes_CellContentClick);
            // 
            // id_butaca
            // 
            this.id_butaca.HeaderText = "id_butaca";
            this.id_butaca.MinimumWidth = 100;
            this.id_butaca.Name = "id_butaca";
            this.id_butaca.ReadOnly = true;
            this.id_butaca.Visible = false;
            // 
            // id_pasaje_provisorio
            // 
            this.id_pasaje_provisorio.HeaderText = "id_pasaje_provisorio";
            this.id_pasaje_provisorio.Name = "id_pasaje_provisorio";
            this.id_pasaje_provisorio.ReadOnly = true;
            this.id_pasaje_provisorio.Visible = false;
            // 
            // Pasajero
            // 
            this.Pasajero.HeaderText = "Pasajero";
            this.Pasajero.Name = "Pasajero";
            this.Pasajero.ReadOnly = true;
            this.Pasajero.Width = 110;
            // 
            // Dni
            // 
            this.Dni.HeaderText = "DNI";
            this.Dni.Name = "Dni";
            this.Dni.ReadOnly = true;
            this.Dni.Width = 80;
            // 
            // nro_butaca
            // 
            this.nro_butaca.HeaderText = "Butaca";
            this.nro_butaca.Name = "nro_butaca";
            this.nro_butaca.ReadOnly = true;
            this.nro_butaca.Width = 45;
            // 
            // tipo_butaca
            // 
            this.tipo_butaca.HeaderText = "Tipo";
            this.tipo_butaca.Name = "tipo_butaca";
            this.tipo_butaca.ReadOnly = true;
            this.tipo_butaca.Width = 75;
            // 
            // piso_butaca
            // 
            this.piso_butaca.HeaderText = "Piso";
            this.piso_butaca.Name = "piso_butaca";
            this.piso_butaca.ReadOnly = true;
            this.piso_butaca.Width = 45;
            // 
            // eliminar_pasaje
            // 
            this.eliminar_pasaje.HeaderText = "";
            this.eliminar_pasaje.Name = "eliminar_pasaje";
            this.eliminar_pasaje.ReadOnly = true;
            this.eliminar_pasaje.Resizable = System.Windows.Forms.DataGridViewTriState.True;
            this.eliminar_pasaje.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.Automatic;
            this.eliminar_pasaje.Width = 40;
            // 
            // groupBox3
            // 
            this.groupBox3.Controls.Add(this.label5);
            this.groupBox3.Controls.Add(this.pictureBox1);
            this.groupBox3.Controls.Add(this.listado_encomiendas);
            this.groupBox3.Location = new System.Drawing.Point(19, 441);
            this.groupBox3.Name = "groupBox3";
            this.groupBox3.Size = new System.Drawing.Size(743, 157);
            this.groupBox3.TabIndex = 53;
            this.groupBox3.TabStop = false;
            this.groupBox3.Text = "Encomiendas";
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Location = new System.Drawing.Point(518, 39);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(165, 13);
            this.label5.TabIndex = 63;
            this.label5.Text = "Agregar Encomienda a la Compra";
            // 
            // pictureBox1
            // 
            this.pictureBox1.Cursor = System.Windows.Forms.Cursors.Hand;
            this.pictureBox1.Image = ((System.Drawing.Image)(resources.GetObject("pictureBox1.Image")));
            this.pictureBox1.Location = new System.Drawing.Point(687, 39);
            this.pictureBox1.Name = "pictureBox1";
            this.pictureBox1.Size = new System.Drawing.Size(16, 23);
            this.pictureBox1.TabIndex = 62;
            this.pictureBox1.TabStop = false;
            this.pictureBox1.Click += new System.EventHandler(this.pictureBox1_Click);
            // 
            // listado_encomiendas
            // 
            this.listado_encomiendas.AllowUserToAddRows = false;
            this.listado_encomiendas.AllowUserToDeleteRows = false;
            this.listado_encomiendas.ColumnHeadersHeight = 20;
            this.listado_encomiendas.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.id_encomienda_provisoria,
            this.encomendero,
            this.enco_dni,
            this.kilos,
            this.eliminar});
            this.listado_encomiendas.Location = new System.Drawing.Point(19, 26);
            this.listado_encomiendas.MultiSelect = false;
            this.listado_encomiendas.Name = "listado_encomiendas";
            this.listado_encomiendas.ReadOnly = true;
            this.listado_encomiendas.RowHeadersWidth = 30;
            this.listado_encomiendas.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.listado_encomiendas.Size = new System.Drawing.Size(327, 112);
            this.listado_encomiendas.TabIndex = 61;
            this.listado_encomiendas.CellContentClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.listado_encomiendas_CellContentClick);
            // 
            // id_encomienda_provisoria
            // 
            this.id_encomienda_provisoria.HeaderText = "id_encomienda_provisoria";
            this.id_encomienda_provisoria.Name = "id_encomienda_provisoria";
            this.id_encomienda_provisoria.ReadOnly = true;
            this.id_encomienda_provisoria.Visible = false;
            // 
            // encomendero
            // 
            this.encomendero.HeaderText = "Encomendero";
            this.encomendero.Name = "encomendero";
            this.encomendero.ReadOnly = true;
            this.encomendero.Width = 110;
            // 
            // enco_dni
            // 
            this.enco_dni.HeaderText = "DNI";
            this.enco_dni.Name = "enco_dni";
            this.enco_dni.ReadOnly = true;
            this.enco_dni.Width = 80;
            // 
            // kilos
            // 
            this.kilos.HeaderText = "Kilos";
            this.kilos.Name = "kilos";
            this.kilos.ReadOnly = true;
            this.kilos.Width = 45;
            // 
            // eliminar
            // 
            this.eliminar.HeaderText = "";
            this.eliminar.Name = "eliminar";
            this.eliminar.ReadOnly = true;
            this.eliminar.Resizable = System.Windows.Forms.DataGridViewTriState.True;
            this.eliminar.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.Automatic;
            this.eliminar.Width = 40;
            // 
            // button1
            // 
            this.button1.Location = new System.Drawing.Point(360, 619);
            this.button1.Name = "button1";
            this.button1.Size = new System.Drawing.Size(104, 23);
            this.button1.TabIndex = 60;
            this.button1.Text = "Finalizar Compra";
            this.button1.UseVisualStyleBackColor = true;
            this.button1.Click += new System.EventHandler(this.button1_Click);
            // 
            // Compra_Pasaje
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(782, 662);
            this.Controls.Add(this.button1);
            this.Controls.Add(this.groupBox3);
            this.Controls.Add(this.groupBox2);
            this.Controls.Add(this.groupBox1);
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.Name = "Compra_Pasaje";
            this.Text = "Compra de Pasaje o Encomienda";
            this.FormClosing += new System.Windows.Forms.FormClosingEventHandler(this.Compra_Pasaje_FormClosing);
            this.groupBox1.ResumeLayout(false);
            this.groupBox1.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.icono_cruz)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.listado_de_viajes)).EndInit();
            this.groupBox2.ResumeLayout(false);
            this.groupBox2.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.icono_mas)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.listado_pasajes)).EndInit();
            this.groupBox3.ResumeLayout(false);
            this.groupBox3.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.listado_encomiendas)).EndInit();
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
        private System.Windows.Forms.PictureBox icono_cruz;
        private System.Windows.Forms.Label label_viaje;
        private System.Windows.Forms.Label label8;
        private System.Windows.Forms.DataGridViewTextBoxColumn id_viaje;
        private System.Windows.Forms.DataGridViewTextBoxColumn Micro;
        private System.Windows.Forms.DataGridViewTextBoxColumn TipoServicio;
        private System.Windows.Forms.DataGridViewTextBoxColumn Salida;
        private System.Windows.Forms.DataGridViewTextBoxColumn LLegadaEstim;
        private System.Windows.Forms.DataGridViewTextBoxColumn butacas;
        private System.Windows.Forms.DataGridViewTextBoxColumn kg;
        private System.Windows.Forms.DataGridViewImageColumn acciones;
        private System.Windows.Forms.GroupBox groupBox2;
        private System.Windows.Forms.DataGridView listado_pasajes;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.PictureBox icono_mas;
        private System.Windows.Forms.DataGridViewTextBoxColumn id_butaca;
        private System.Windows.Forms.DataGridViewTextBoxColumn id_pasaje_provisorio;
        private System.Windows.Forms.DataGridViewTextBoxColumn Pasajero;
        private System.Windows.Forms.DataGridViewTextBoxColumn Dni;
        private System.Windows.Forms.DataGridViewTextBoxColumn nro_butaca;
        private System.Windows.Forms.DataGridViewTextBoxColumn tipo_butaca;
        private System.Windows.Forms.DataGridViewTextBoxColumn piso_butaca;
        private System.Windows.Forms.DataGridViewImageColumn eliminar_pasaje;
        private System.Windows.Forms.GroupBox groupBox3;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.PictureBox pictureBox1;
        private System.Windows.Forms.DataGridView listado_encomiendas;
        private System.Windows.Forms.DataGridViewTextBoxColumn id_encomienda_provisoria;
        private System.Windows.Forms.DataGridViewTextBoxColumn encomendero;
        private System.Windows.Forms.DataGridViewTextBoxColumn enco_dni;
        private System.Windows.Forms.DataGridViewTextBoxColumn kilos;
        private System.Windows.Forms.DataGridViewImageColumn eliminar;
        private System.Windows.Forms.Button button1;
    }
}