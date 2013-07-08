using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using System.Data.SqlClient;
using System.Configuration;

namespace FrbaBus.Compra_de_Pasajes
{
    public partial class Finalizar_Compra : Form
    {
        public Compra_Pasaje.Viaje viaje;
        public List<Nuevo_Pasaje.Pasaje> lista_pasajes;
        public List<Nueva_Encomienda.Encomienda> lista_encomiendas;
        public Cliente cliente;
        public int cant_discap;
        public int cant_jubilados;
        public int cant_kg_totales;
        public decimal precio_pasaje;
        public decimal precio_por_kg;
        public decimal precio_total;
        public int id_compra_generada;
        public bool mostroComprobante;

        public Finalizar_Compra(Compra_Pasaje.Viaje via, List<Nuevo_Pasaje.Pasaje> l_pasajes, List<Nueva_Encomienda.Encomienda> l_encomiendas)
        {

            InitializeComponent();
            //pruebaGroupbox();
            this.viaje = via;
            this.lista_pasajes = l_pasajes;
            this.lista_encomiendas = l_encomiendas;
            this.cliente = null;
            this.mostroComprobante = false;
            cargarDetallesCompra();
            cargarCombosSexo();
            cargarComboTipoPago();
            cargarComboVto();
            setearPreciosALosPasajes();
            setearPreciosALasEncomiendas();
            label_p_total.Text = getPrecioTotal();

        }

        public void mostrarComprobante()
        {

            gb_compra.Visible = false;
            gb_cliente.Visible = false;
            gb_pago.Visible = false;
            b_guardar.Text = "Aceptar";
            this.mostroComprobante = true;
            this.Text = "Comprobante de la Compra";


            Label label_a = new System.Windows.Forms.Label();
            Label label_cod_compra = new System.Windows.Forms.Label();
            Label label_b = new System.Windows.Forms.Label();
            Label label_fecha_compra = new System.Windows.Forms.Label();
            Label label_c = new System.Windows.Forms.Label();
            Label label_cli_compra = new System.Windows.Forms.Label();
            Label label_d = new System.Windows.Forms.Label();
            Label label_importe_compra = new System.Windows.Forms.Label();
            GroupBox gb_detalle_compra = new System.Windows.Forms.GroupBox();
            Panel panel_pasajes = new System.Windows.Forms.Panel();
            Label label_e = new System.Windows.Forms.Label();
            Label label_f = new System.Windows.Forms.Label();
            Panel panel_encomiendas = new System.Windows.Forms.Panel();
            panel_pasajes.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            panel_encomiendas.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            gb_detalle_compra.SuspendLayout();
            this.SuspendLayout();
            // 
            // label_a
            // 
            label_a.AutoSize = true;
            label_a.Location = new System.Drawing.Point(24, 27);
            label_a.Name = "label_a";
            label_a.Size = new System.Drawing.Size(97, 13);
            label_a.TabIndex = 4;
            label_a.Text = "Código de Compra:";
            // 
            // label_cod_compra
            // 
            label_cod_compra.AutoSize = true;
            label_cod_compra.ForeColor = System.Drawing.Color.Green;
            label_cod_compra.Location = new System.Drawing.Point(126, 27);
            label_cod_compra.Name = "label_cod_compra";
            label_cod_compra.Size = new System.Drawing.Size(10, 13);
            label_cod_compra.TabIndex = 5;
            label_cod_compra.Text = "-";
            // 
            // label_b
            // 
            label_b.AutoSize = true;
            label_b.Location = new System.Drawing.Point(265, 27);
            label_b.Name = "label_b";
            label_b.Size = new System.Drawing.Size(40, 13);
            label_b.TabIndex = 6;
            label_b.Text = "Fecha:";
            // 
            // label_fecha_compra
            // 
            label_fecha_compra.AutoSize = true;
            label_fecha_compra.ForeColor = System.Drawing.Color.Green;
            label_fecha_compra.Location = new System.Drawing.Point(308, 27);
            label_fecha_compra.Name = "label_fecha_compra";
            label_fecha_compra.Size = new System.Drawing.Size(10, 13);
            label_fecha_compra.TabIndex = 7;
            label_fecha_compra.Text = "-";
            // 
            // label_c
            // 
            label_c.AutoSize = true;
            label_c.Location = new System.Drawing.Point(412, 27);
            label_c.Name = "label_c";
            label_c.Size = new System.Drawing.Size(42, 13);
            label_c.TabIndex = 12;
            label_c.Text = "Cliente:";
            // 
            // label_cli_compra
            // 
            label_cli_compra.AutoSize = true;
            label_cli_compra.ForeColor = System.Drawing.Color.Green;
            label_cli_compra.Location = new System.Drawing.Point(460, 27);
            label_cli_compra.Name = "label_cli_compra";
            label_cli_compra.Size = new System.Drawing.Size(10, 13);
            label_cli_compra.TabIndex = 13;
            label_cli_compra.Text = "-";
            // 
            // label_d
            // 
            label_d.AutoSize = true;
            label_d.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            label_d.Location = new System.Drawing.Point(24, 56);
            label_d.Name = "label_d";
            label_d.Size = new System.Drawing.Size(53, 13);
            label_d.TabIndex = 18;
            label_d.Text = "Importe:";
            // 
            // label_importe_compra
            // 
            label_importe_compra.AutoSize = true;
            label_importe_compra.ForeColor = System.Drawing.Color.Green;
            label_importe_compra.Location = new System.Drawing.Point(83, 56);
            label_importe_compra.Name = "label_importe_compra";
            label_importe_compra.Size = new System.Drawing.Size(10, 13);
            label_importe_compra.TabIndex = 19;
            label_importe_compra.Text = "-";
            // 
            // gb_detalle_compra
            // 
            gb_detalle_compra.Controls.Add(label_f);
            gb_detalle_compra.Controls.Add(panel_encomiendas);
            gb_detalle_compra.Controls.Add(label_e);
            gb_detalle_compra.Controls.Add(panel_pasajes);
            gb_detalle_compra.Controls.Add(label_importe_compra);
            gb_detalle_compra.Controls.Add(label_d);
            gb_detalle_compra.Controls.Add(label_cli_compra);
            gb_detalle_compra.Controls.Add(label_c);
            gb_detalle_compra.Controls.Add(label_fecha_compra);
            gb_detalle_compra.Controls.Add(label_b);
            gb_detalle_compra.Controls.Add(label_cod_compra);
            gb_detalle_compra.Controls.Add(label_a);
            gb_detalle_compra.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            gb_detalle_compra.ForeColor = System.Drawing.SystemColors.ControlDarkDark;
            gb_detalle_compra.Location = new System.Drawing.Point(24, 12);
            gb_detalle_compra.Name = "gb_detalle_compra";
            gb_detalle_compra.Size = new System.Drawing.Size(669, 443);
            gb_detalle_compra.TabIndex = 9;
            gb_detalle_compra.TabStop = false;
            gb_detalle_compra.Text = "Detalle de la Compra";
            // 
            // panel_pasajes
            // 
            panel_pasajes.Location = new System.Drawing.Point(27, 122);
            panel_pasajes.Name = "panel_pasajes";
            panel_pasajes.Size = new System.Drawing.Size(612, 133);
            panel_pasajes.TabIndex = 20;
            // 
            // label_e
            // 
            label_e.AutoSize = true;
            label_e.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            label_e.ForeColor = System.Drawing.SystemColors.ActiveCaptionText;
            label_e.Location = new System.Drawing.Point(26, 102);
            label_e.Name = "label_e";
            label_e.Size = new System.Drawing.Size(51, 13);
            label_e.TabIndex = 21;
            label_e.Text = "Pasajes";
            // 
            // label_f
            // 
            label_f.AutoSize = true;
            label_f.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            label_f.ForeColor = System.Drawing.SystemColors.ActiveCaptionText;
            label_f.Location = new System.Drawing.Point(26, 265);
            label_f.Name = "label_f";
            label_f.Size = new System.Drawing.Size(82, 13);
            label_f.TabIndex = 23;
            label_f.Text = "Encomiendas";
            // 
            // panel_encomiendas
            // 
            panel_encomiendas.Location = new System.Drawing.Point(27, 285);
            panel_encomiendas.Name = "panel_encomiendas";
            panel_encomiendas.Size = new System.Drawing.Size(612, 133);
            panel_encomiendas.TabIndex = 22;
            // 
            // Funciones
            // 

            panel_pasajes.AutoScroll = true;
            panel_encomiendas.AutoScroll = true;


            /*inicio - pongo los datos en pantalla*/
            Funciones fun = new Funciones();
            label_cod_compra.Text = this.id_compra_generada.ToString(); ;
            label_fecha_compra.Text = fun.getFechaActual().Day.ToString() + "/" + fun.getFechaActual().Month.ToString() + "/" + fun.getFechaActual().Year.ToString();
            label_cli_compra.Text = this.cliente.nombre + " " + this.cliente.apellido + " (" + this.cliente.dni + ")";
            label_importe_compra.Text = "$" + this.precio_total.ToString();

            //cargo panel pasajes
            Label lab_head_cod = new System.Windows.Forms.Label();
            lab_head_cod.Location = new System.Drawing.Point(25, 1);
            lab_head_cod.Size = new System.Drawing.Size(46, 13);
            lab_head_cod.ForeColor = System.Drawing.Color.Indigo;
            lab_head_cod.Text = "Código";
            Label lab_head_pas = new System.Windows.Forms.Label();
            lab_head_pas.Location = new System.Drawing.Point(175, 1);
            lab_head_pas.Size = new System.Drawing.Size(50, 13);
            lab_head_pas.ForeColor = System.Drawing.Color.Indigo;
            lab_head_pas.Text = "Pasajero";
            Label lab_head_but = new System.Windows.Forms.Label();
            lab_head_but.Location = new System.Drawing.Point(400, 1);
            lab_head_but.Size = new System.Drawing.Size(50, 13);
            lab_head_but.ForeColor = System.Drawing.Color.Indigo;
            lab_head_but.Text = "Butaca";
            Label lab_head_precio = new System.Windows.Forms.Label();
            lab_head_precio.Location = new System.Drawing.Point(530, 1);
            lab_head_precio.Size = new System.Drawing.Size(50, 13);
            lab_head_precio.ForeColor = System.Drawing.Color.Indigo;
            lab_head_precio.Text = "Precio";

            panel_pasajes.Controls.Add(lab_head_cod);
            panel_pasajes.Controls.Add(lab_head_pas);
            panel_pasajes.Controls.Add(lab_head_but);
            panel_pasajes.Controls.Add(lab_head_precio);

            int heig = 20;
            foreach (Nuevo_Pasaje.Pasaje pas in this.lista_pasajes)
            {
                Label label_cod_pasaje = new System.Windows.Forms.Label();
                label_cod_pasaje.Location = new System.Drawing.Point(20, heig);
                label_cod_pasaje.Size = new System.Drawing.Size(55, 13);
                label_cod_pasaje.Text = pas.id_pasaje_gen.ToString();
                panel_pasajes.Controls.Add(label_cod_pasaje);

                Label label_pasajero_pasaje = new System.Windows.Forms.Label();
                label_pasajero_pasaje.Location = new System.Drawing.Point(115, heig);
                label_pasajero_pasaje.Size = new System.Drawing.Size(230, 13);
                label_pasajero_pasaje.Text = pas.cliente.nombre + " " + pas.cliente.apellido + " (" + pas.cliente.dni + ")";

                Label label_butaca_pasaje = new System.Windows.Forms.Label();
                label_butaca_pasaje.Location = new System.Drawing.Point(355, heig);
                label_butaca_pasaje.Name = "label_butaca_pasaje";
                label_butaca_pasaje.Size = new System.Drawing.Size(150, 13);
                label_butaca_pasaje.Text = "Nro: " + pas.butaca.nro_butaca + " - " + pas.butaca.tipo_butaca + " - Piso: " + pas.butaca.piso_butaca;

                Label label_precio_pasaje = new System.Windows.Forms.Label();
                label_precio_pasaje.Location = new System.Drawing.Point(528, heig);
                label_precio_pasaje.Size = new System.Drawing.Size(50, 13);
                label_precio_pasaje.Text = "$"+pas.precio.ToString();

                panel_pasajes.Controls.Add(label_cod_pasaje);
                panel_pasajes.Controls.Add(label_pasajero_pasaje);
                panel_pasajes.Controls.Add(label_butaca_pasaje);
                panel_pasajes.Controls.Add(label_precio_pasaje);

                heig = heig + 20;

            }

            //cargo panel encomiendas
            Label lab_head_cod_enco = new System.Windows.Forms.Label();
            lab_head_cod_enco.Location = new System.Drawing.Point(25, 1);
            lab_head_cod_enco.Size = new System.Drawing.Size(46, 13);
            lab_head_cod_enco.ForeColor = System.Drawing.Color.Indigo;
            lab_head_cod_enco.Text = "Código";
            Label lab_head_duenio = new System.Windows.Forms.Label();
            lab_head_duenio.Location = new System.Drawing.Point(175, 1);
            lab_head_duenio.Size = new System.Drawing.Size(75, 13);
            lab_head_duenio.ForeColor = System.Drawing.Color.Indigo;
            lab_head_duenio.Text = "Encomendero";
            Label lab_head_kg = new System.Windows.Forms.Label();
            lab_head_kg.Location = new System.Drawing.Point(400, 1);
            lab_head_kg.Size = new System.Drawing.Size(70, 13);
            lab_head_kg.ForeColor = System.Drawing.Color.Indigo;
            lab_head_kg.Text = "Cantidad Kg";
            Label lab_head_precio_enco = new System.Windows.Forms.Label();
            lab_head_precio_enco.Location = new System.Drawing.Point(530, 1);
            lab_head_precio_enco.Size = new System.Drawing.Size(50, 13);
            lab_head_precio_enco.ForeColor = System.Drawing.Color.Indigo;
            lab_head_precio_enco.Text = "Precio";

            panel_encomiendas.Controls.Add(lab_head_cod_enco);
            panel_encomiendas.Controls.Add(lab_head_duenio);
            panel_encomiendas.Controls.Add(lab_head_kg);
            panel_encomiendas.Controls.Add(lab_head_precio_enco);

            heig = 20;
            foreach (Nueva_Encomienda.Encomienda enco in this.lista_encomiendas)
            {
                Label label_cod_encomienda = new System.Windows.Forms.Label();
                label_cod_encomienda.Location = new System.Drawing.Point(20, heig);
                label_cod_encomienda.Size = new System.Drawing.Size(55, 13);
                label_cod_encomienda.Text = enco.id_encomienda_gen.ToString();

                Label label_pasajero_enco = new System.Windows.Forms.Label();
                label_pasajero_enco.Location = new System.Drawing.Point(115, heig);
                label_pasajero_enco.Size = new System.Drawing.Size(280, 13);
                label_pasajero_enco.Text = enco.cliente.nombre + " " + enco.cliente.apellido + " (" + enco.cliente.dni + ")";

                Label label_kg_enco = new System.Windows.Forms.Label();
                label_kg_enco.Location = new System.Drawing.Point(415, heig);
                label_kg_enco.Size = new System.Drawing.Size(50, 13);
                label_kg_enco.Text = enco.cant_kg.ToString();

                Label label_precio_enco = new System.Windows.Forms.Label();
                label_precio_enco.Location = new System.Drawing.Point(523, heig);
                label_precio_enco.Size = new System.Drawing.Size(50, 13);
                label_precio_enco.Text = "$"+enco.precio.ToString();

                panel_encomiendas.Controls.Add(label_cod_encomienda);
                panel_encomiendas.Controls.Add(label_pasajero_enco);
                panel_encomiendas.Controls.Add(label_kg_enco);
                panel_encomiendas.Controls.Add(label_precio_enco);

                heig = heig + 20;

            }

            /*fin - pongo los datos en pantalla*/

            this.Controls.Add(gb_detalle_compra);
            gb_detalle_compra.ResumeLayout(false);
            gb_detalle_compra.PerformLayout();
            this.ResumeLayout(false);


            MessageBox.Show("La Compra ha sido registrada", "", MessageBoxButtons.OK, MessageBoxIcon.Information);

        }

        public void pruebaGroupbox(){

            gb_compra.Visible = false;
            gb_cliente.Visible = false;
            gb_pago.Visible = false;

            Label label_a = new System.Windows.Forms.Label();
            Label label_cod_compra = new System.Windows.Forms.Label();
            Label label_b = new System.Windows.Forms.Label();
            Label label_fecha_compra = new System.Windows.Forms.Label();
            Label label_c = new System.Windows.Forms.Label();
            Label label_cli_compra = new System.Windows.Forms.Label();
            Label label_d = new System.Windows.Forms.Label();
            Label label_importe_compra = new System.Windows.Forms.Label();
            GroupBox gb_detalle_compra = new System.Windows.Forms.GroupBox();
            Panel panel_pasajes = new System.Windows.Forms.Panel();
            Label label_e = new System.Windows.Forms.Label();
            Label label_f = new System.Windows.Forms.Label();
            Panel panel_encomiendas = new System.Windows.Forms.Panel();
            panel_pasajes.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            panel_encomiendas.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            gb_detalle_compra.SuspendLayout();
            this.SuspendLayout();
            // 
            // label_a
            // 
            label_a.AutoSize = true;
            label_a.Location = new System.Drawing.Point(24, 27);
            label_a.Name = "label_a";
            label_a.Size = new System.Drawing.Size(97, 13);
            label_a.TabIndex = 4;
            label_a.Text = "Código de Compra:";
            // 
            // label_cod_compra
            // 
            label_cod_compra.AutoSize = true;
            label_cod_compra.ForeColor = System.Drawing.Color.Green;
            label_cod_compra.Location = new System.Drawing.Point(126, 27);
            label_cod_compra.Name = "label_cod_compra";
            label_cod_compra.Size = new System.Drawing.Size(10, 13);
            label_cod_compra.TabIndex = 5;
            label_cod_compra.Text = "-";
            // 
            // label_b
            // 
            label_b.AutoSize = true;
            label_b.Location = new System.Drawing.Point(265, 27);
            label_b.Name = "label_b";
            label_b.Size = new System.Drawing.Size(40, 13);
            label_b.TabIndex = 6;
            label_b.Text = "Fecha:";
            // 
            // label_fecha_compra
            // 
            label_fecha_compra.AutoSize = true;
            label_fecha_compra.ForeColor = System.Drawing.Color.Green;
            label_fecha_compra.Location = new System.Drawing.Point(308, 27);
            label_fecha_compra.Name = "label_fecha_compra";
            label_fecha_compra.Size = new System.Drawing.Size(10, 13);
            label_fecha_compra.TabIndex = 7;
            label_fecha_compra.Text = "-";
            // 
            // label_c
            // 
            label_c.AutoSize = true;
            label_c.Location = new System.Drawing.Point(412, 27);
            label_c.Name = "label_c";
            label_c.Size = new System.Drawing.Size(42, 13);
            label_c.TabIndex = 12;
            label_c.Text = "Cliente:";
            // 
            // label_cli_compra
            // 
            label_cli_compra.AutoSize = true;
            label_cli_compra.ForeColor = System.Drawing.Color.Green;
            label_cli_compra.Location = new System.Drawing.Point(460, 27);
            label_cli_compra.Name = "label_cli_compra";
            label_cli_compra.Size = new System.Drawing.Size(10, 13);
            label_cli_compra.TabIndex = 13;
            label_cli_compra.Text = "-";
            // 
            // label_d
            // 
            label_d.AutoSize = true;
            label_d.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            label_d.Location = new System.Drawing.Point(24, 56);
            label_d.Name = "label_d";
            label_d.Size = new System.Drawing.Size(53, 13);
            label_d.TabIndex = 18;
            label_d.Text = "Importe:";
            // 
            // label_importe_compra
            // 
            label_importe_compra.AutoSize = true;
            label_importe_compra.ForeColor = System.Drawing.Color.Green;
            label_importe_compra.Location = new System.Drawing.Point(83, 56);
            label_importe_compra.Name = "label_importe_compra";
            label_importe_compra.Size = new System.Drawing.Size(10, 13);
            label_importe_compra.TabIndex = 19;
            label_importe_compra.Text = "-";
            // 
            // gb_detalle_compra
            // 
            gb_detalle_compra.Controls.Add(label_f);
            gb_detalle_compra.Controls.Add(panel_encomiendas);
            gb_detalle_compra.Controls.Add(label_e);
            gb_detalle_compra.Controls.Add(panel_pasajes);
            gb_detalle_compra.Controls.Add(label_importe_compra);
            gb_detalle_compra.Controls.Add(label_d);
            gb_detalle_compra.Controls.Add(label_cli_compra);
            gb_detalle_compra.Controls.Add(label_c);
            gb_detalle_compra.Controls.Add(label_fecha_compra);
            gb_detalle_compra.Controls.Add(label_b);
            gb_detalle_compra.Controls.Add(label_cod_compra);
            gb_detalle_compra.Controls.Add(label_a);
            gb_detalle_compra.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            gb_detalle_compra.ForeColor = System.Drawing.SystemColors.ControlDarkDark;
            gb_detalle_compra.Location = new System.Drawing.Point(24, 12);
            gb_detalle_compra.Name = "gb_detalle_compra";
            gb_detalle_compra.Size = new System.Drawing.Size(669, 443);
            gb_detalle_compra.TabIndex = 9;
            gb_detalle_compra.TabStop = false;
            gb_detalle_compra.Text = "Detalle de la Compra";
            // 
            // panel_pasajes
            // 
            panel_pasajes.Location = new System.Drawing.Point(27, 122);
            panel_pasajes.Name = "panel_pasajes";
            panel_pasajes.Size = new System.Drawing.Size(612, 133);
            panel_pasajes.TabIndex = 20;
            // 
            // label_e
            // 
            label_e.AutoSize = true;
            label_e.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            label_e.ForeColor = System.Drawing.SystemColors.ActiveCaptionText;
            label_e.Location = new System.Drawing.Point(26, 102);
            label_e.Name = "label_e";
            label_e.Size = new System.Drawing.Size(51, 13);
            label_e.TabIndex = 21;
            label_e.Text = "Pasajes";
            // 
            // label_f
            // 
            label_f.AutoSize = true;
            label_f.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            label_f.ForeColor = System.Drawing.SystemColors.ActiveCaptionText;
            label_f.Location = new System.Drawing.Point(26, 265);
            label_f.Name = "label_f";
            label_f.Size = new System.Drawing.Size(82, 13);
            label_f.TabIndex = 23;
            label_f.Text = "Encomiendas";
            // 
            // panel_encomiendas
            // 
            panel_encomiendas.Location = new System.Drawing.Point(27, 285);
            panel_encomiendas.Name = "panel_encomiendas";
            panel_encomiendas.Size = new System.Drawing.Size(612, 133);
            panel_encomiendas.TabIndex = 22;
            // 
            // Funciones
            // 

            panel_pasajes.AutoScroll = true;
            panel_encomiendas.AutoScroll = true;


            /*inicio - pongo los datos en pantalla*/

            label_cod_compra.Text = "3048308509";
            label_fecha_compra.Text = "12/07/2013";
            label_cli_compra.Text = "Pedro León (35031643)";
            label_importe_compra.Text = "$1203.84";

            //cargo panel pasajes
            Label lab_head_cod = new System.Windows.Forms.Label();
            lab_head_cod.Location = new System.Drawing.Point(25, 1);
            lab_head_cod.Size = new System.Drawing.Size(46, 13);
            lab_head_cod.ForeColor = System.Drawing.Color.Indigo;
            lab_head_cod.Text = "Código";
            Label lab_head_pas = new System.Windows.Forms.Label();
            lab_head_pas.Location = new System.Drawing.Point(175, 1);
            lab_head_pas.Size = new System.Drawing.Size(50, 13);
            lab_head_pas.ForeColor = System.Drawing.Color.Indigo;
            lab_head_pas.Text = "Pasajero";
            Label lab_head_but = new System.Windows.Forms.Label();
            lab_head_but.Location = new System.Drawing.Point(400, 1);
            lab_head_but.Size = new System.Drawing.Size(50, 13);
            lab_head_but.ForeColor = System.Drawing.Color.Indigo;
            lab_head_but.Text = "Butaca";
            Label lab_head_precio = new System.Windows.Forms.Label();
            lab_head_precio.Location = new System.Drawing.Point(530, 1);
            lab_head_precio.Size = new System.Drawing.Size(50, 13);
            lab_head_precio.ForeColor = System.Drawing.Color.Indigo;
            lab_head_precio.Text = "Precio";

            panel_pasajes.Controls.Add(lab_head_cod);
            panel_pasajes.Controls.Add(lab_head_pas);
            panel_pasajes.Controls.Add(lab_head_but);
            panel_pasajes.Controls.Add(lab_head_precio);

            int heig = 20;
            for (int i = 0; i < 8; i++)
            {
                Label label_cod_pasaje = new System.Windows.Forms.Label();
                label_cod_pasaje.Location = new System.Drawing.Point(20, heig);
                label_cod_pasaje.Size = new System.Drawing.Size(55, 13);
                label_cod_pasaje.Text = "72583899";
                panel_pasajes.Controls.Add(label_cod_pasaje);

                Label label_pasajero_pasaje = new System.Windows.Forms.Label();
                label_pasajero_pasaje.Location = new System.Drawing.Point(110, heig);
                label_pasajero_pasaje.Size = new System.Drawing.Size(230, 13);
                label_pasajero_pasaje.Text = "Pedro Leon (35031643)";

                Label label_butaca_pasaje = new System.Windows.Forms.Label();
                label_butaca_pasaje.Location = new System.Drawing.Point(355, heig);
                label_butaca_pasaje.Size = new System.Drawing.Size(150, 13);
                label_butaca_pasaje.Text = "Nro: 10 - Ventanilla - Piso: 2";

                Label label_precio_pasaje = new System.Windows.Forms.Label();
                label_precio_pasaje.Location = new System.Drawing.Point(524, heig);
                label_precio_pasaje.Size = new System.Drawing.Size(50, 13);
                label_precio_pasaje.Text = "$1203.03";

                panel_pasajes.Controls.Add(label_cod_pasaje);
                panel_pasajes.Controls.Add(label_pasajero_pasaje);
                panel_pasajes.Controls.Add(label_butaca_pasaje);
                panel_pasajes.Controls.Add(label_precio_pasaje);

                heig = heig + 20;

            }

            //cargo panel encomiendas
            Label lab_head_cod_enco = new System.Windows.Forms.Label();
            lab_head_cod_enco.Location = new System.Drawing.Point(25, 1);
            lab_head_cod_enco.Size = new System.Drawing.Size(46, 13);
            lab_head_cod_enco.ForeColor = System.Drawing.Color.Indigo;
            lab_head_cod_enco.Text = "Código";
            Label lab_head_duenio = new System.Windows.Forms.Label();
            lab_head_duenio.Location = new System.Drawing.Point(175, 1);
            lab_head_duenio.Size = new System.Drawing.Size(75, 13);
            lab_head_duenio.ForeColor = System.Drawing.Color.Indigo;
            lab_head_duenio.Text = "Encomendero";
            Label lab_head_kg = new System.Windows.Forms.Label();
            lab_head_kg.Location = new System.Drawing.Point(400, 1);
            lab_head_kg.Size = new System.Drawing.Size(70, 13);
            lab_head_kg.ForeColor = System.Drawing.Color.Indigo;
            lab_head_kg.Text = "Cantidad Kg";
            Label lab_head_precio_enco = new System.Windows.Forms.Label();
            lab_head_precio_enco.Location = new System.Drawing.Point(530, 1);
            lab_head_precio_enco.Size = new System.Drawing.Size(50, 13);
            lab_head_precio_enco.ForeColor = System.Drawing.Color.Indigo;
            lab_head_precio_enco.Text = "Precio";

            panel_encomiendas.Controls.Add(lab_head_cod_enco);
            panel_encomiendas.Controls.Add(lab_head_duenio);
            panel_encomiendas.Controls.Add(lab_head_kg);
            panel_encomiendas.Controls.Add(lab_head_precio_enco);

            heig = 20;
            for (int i = 0; i < 8; i++)
            {
                Label label_cod_encomienda = new System.Windows.Forms.Label();
                label_cod_encomienda.Location = new System.Drawing.Point(20, heig);
                label_cod_encomienda.Size = new System.Drawing.Size(55, 13);
                label_cod_encomienda.Text = "72583899";

                Label label_pasajero_enco = new System.Windows.Forms.Label();
                label_pasajero_enco.Location = new System.Drawing.Point(110, heig);
                label_pasajero_enco.Size = new System.Drawing.Size(280, 13);
                label_pasajero_enco.Text = "DE LAS MERCEDES Valenzuela (35031643)";

                Label label_kg_enco = new System.Windows.Forms.Label();
                label_kg_enco.Location = new System.Drawing.Point(415, heig);
                label_kg_enco.Size = new System.Drawing.Size(50, 13);
                label_kg_enco.Text = "183";

                Label label_precio_enco = new System.Windows.Forms.Label();
                label_precio_enco.Location = new System.Drawing.Point(523, heig);
                label_precio_enco.Size = new System.Drawing.Size(50, 13);
                label_precio_enco.Text = "$1833.45";

                panel_encomiendas.Controls.Add(label_cod_encomienda);
                panel_encomiendas.Controls.Add(label_pasajero_enco);
                panel_encomiendas.Controls.Add(label_kg_enco);
                panel_encomiendas.Controls.Add(label_precio_enco);

                heig = heig + 20;

            }

            /*fin - pongo los datos en pantalla*/

            this.Controls.Add(gb_detalle_compra);
            gb_detalle_compra.ResumeLayout(false);
            gb_detalle_compra.PerformLayout();
            this.ResumeLayout(false);

        }

        public class ComboboxItem
        {
            public string Text { get; set; }
            public int Value { get; set; }

            public override string ToString()
            {
                return Text;
            }

        }

        public class ComboboxItemVto
        {
            public string Text { get; set; }
            public string Value { get; set; }

            public override string ToString()
            {
                return Text;
            }

        }

        private void cargarCombosSexo()
        {

            int c_sexo_m = 0;
            string d_sexo_m = "M";
            int c_sexo_f = 1;
            string d_sexo_f = "F";

            ComboboxItem item_m = new ComboboxItem();
            item_m.Text = d_sexo_m;
            item_m.Value = c_sexo_m;
            ComboboxItem item_f = new ComboboxItem();
            item_f.Text = d_sexo_f;
            item_f.Value = c_sexo_f;

            combo_sexo.Items.Add(item_m);
            combo_sexo.Items.Add(item_f);

        }

        private void cargarComboTipoPago()
        {

            int c_tipo_m = 1;
            string d_tipo_m = "Efectivo";
            int c_tipo_f = 2;
            string d_tipo_f = "Tarjeta de Crédito";

            ComboboxItem item_m = new ComboboxItem();
            item_m.Text = d_tipo_m;
            item_m.Value = c_tipo_m;
            ComboboxItem item_f = new ComboboxItem();
            item_f.Text = d_tipo_f;
            item_f.Value = c_tipo_f;

            c_tipo_pago.Items.Add(item_m);
            c_tipo_pago.Items.Add(item_f);

        }

        private void cargarComboVto()
        {

            string c_vto_1 = "0913";
            string d_vto_1 = "09/2013";
            string c_vto_2 = "1013";
            string d_vto_2 = "10/2013";
            string c_vto_3 = "1113";
            string d_vto_3 = "11/2013";
            string c_vto_4 = "1213";
            string d_vto_4 = "12/2013";


            ComboboxItemVto item_1 = new ComboboxItemVto();
            item_1.Text = d_vto_1;
            item_1.Value = c_vto_1;
            ComboboxItemVto item_2 = new ComboboxItemVto();
            item_2.Text = d_vto_2;
            item_2.Value = c_vto_2;
            ComboboxItemVto item_3 = new ComboboxItemVto();
            item_3.Text = d_vto_3;
            item_3.Value = c_vto_3;
            ComboboxItemVto item_4 = new ComboboxItemVto();
            item_4.Text = d_vto_4;
            item_4.Value = c_vto_4;

            combo_vto.Items.Add(item_1);
            combo_vto.Items.Add(item_2);
            combo_vto.Items.Add(item_3);
            combo_vto.Items.Add(item_4);

        }

        public void cargarDetallesCompra() {

            label_cant_pasajes.Text = this.lista_pasajes.Count.ToString();
            label_cant_encom.Text = this.lista_encomiendas.Count.ToString();
            label_cant_kg_totales.Text = getCantKgTotales();
            label_pas_discap.Text = getCantDiscap();
            label_cant_jubilados.Text = getCantJubilados();
            label_p_pasaje.Text = getPrecioPasaje();
            label_p_kg.Text = getPrecioPorKg();
        
        }

        public string getCantKgTotales() {
            int cant = 0;
            foreach (Nueva_Encomienda.Encomienda enco in this.lista_encomiendas)
            {
                cant = cant + enco.cant_kg;
            }
            this.cant_kg_totales = cant;
            return cant.ToString();
        }

        public string getCantDiscap()
        {
            int cant = 0;
            foreach (Nuevo_Pasaje.Pasaje pas in this.lista_pasajes)
            {
                if(pas.pas_discapacitado)
                    cant = cant + 1;
            }
            this.cant_discap = cant;
            return cant.ToString();
        }

        public void setearPreciosALosPasajes()
        {
            if (this.lista_pasajes.Count <= 2 && this.cant_discap > 0)
            {
                foreach (Nuevo_Pasaje.Pasaje pas in this.lista_pasajes)
                {
                    pas.precio = 0;
                }
                return;
            }

            if (this.lista_pasajes.Count > 0 && this.cant_discap == 0)
            {
                Funciones func = new Funciones();
                foreach (Nuevo_Pasaje.Pasaje pas in this.lista_pasajes)
                {
                    DateTime f_nac = pas.cliente.f_nacimiento.Date;
                    int edad = func.getEdad(f_nac);
                    string sexo = pas.cliente.sexo;
                    bool esJubilado = false;
                    if (sexo.Equals("M") && edad >= 65 && !pas.pas_discapacitado)
                        esJubilado = true;
                    if (sexo.Equals("F") && edad >= 60 && !pas.pas_discapacitado)
                        esJubilado = true;

                    pas.precio = (esJubilado) ? (this.precio_pasaje / 2) : this.precio_pasaje;

                }
                return;
            }

            if (this.lista_pasajes.Count > 2 && this.cant_discap > 0)
            {
                Funciones func = new Funciones();
                bool puso_uno_en_cero = false;
                bool ultimoPasaje = false;
                int cant_pasajes = this.lista_pasajes.Count;
                int c = 0;
                foreach (Nuevo_Pasaje.Pasaje pas in this.lista_pasajes)
                {
                    c++;
                    if(c == cant_pasajes){
                        ultimoPasaje = true;
                    }

                    DateTime f_nac = pas.cliente.f_nacimiento.Date;
                    int edad = func.getEdad(f_nac);
                    string sexo = pas.cliente.sexo;
                    bool esJubilado = false;
                    if (sexo.Equals("M") && edad >= 65 && !pas.pas_discapacitado)
                        esJubilado = true;
                    if (sexo.Equals("F") && edad >= 60 && !pas.pas_discapacitado)
                        esJubilado = true;

                    if (pas.pas_discapacitado)
                        pas.precio = 0;
                    else if (!puso_uno_en_cero && !esJubilado) {
                        pas.precio = 0;
                        puso_uno_en_cero = true;
                    }
                    else if (!puso_uno_en_cero && esJubilado && ultimoPasaje) {
                        pas.precio = 0;
                        puso_uno_en_cero = true;
                    }
                    else {
                        pas.precio = (esJubilado) ? (this.precio_pasaje / 2) : this.precio_pasaje;
                    }

                }
                return;
            }

        }

        public void setearPreciosALasEncomiendas()
        {
            foreach (Nueva_Encomienda.Encomienda enco in this.lista_encomiendas)
            {
                enco.precio = enco.cant_kg * this.precio_por_kg;
            }
        }

        public string getCantJubilados()
        {
            int cant = 0;
            Funciones func = new Funciones();
            foreach (Nuevo_Pasaje.Pasaje pas in this.lista_pasajes)
            {
                DateTime f_nac = pas.cliente.f_nacimiento.Date;
                int edad = func.getEdad(f_nac);
                string sexo = pas.cliente.sexo;
                if (sexo.Equals("M") && edad >= 65 && !pas.pas_discapacitado)
                    cant = cant + 1;
                if (sexo.Equals("F") && edad >= 60 && !pas.pas_discapacitado)
                    cant = cant + 1;
            }
            this.cant_jubilados = cant;
            return cant.ToString();
        }

        public string getPrecioPasaje()
        {
            decimal v_precio_base_pasaje = 0;
            decimal v_adicional = 0;

            StringBuilder sb = new StringBuilder();
            sb.Append("select rc.PRECIO_BASE_PASAJE ");
            sb.Append("from SASHAILO.Recorrido re join SASHAILO.Recorrido_Ciudades rc on rc.ID_RECORRIDO_CIUDADES = re.ID_RECORRIDO_CIUDADES ");
            sb.Append("where re.ID_RECORRIDO = " + this.viaje.id_recorrido);
            Conexion cn = new Conexion();
            SqlDataReader consulta = cn.consultar(sb.ToString());
            if (consulta.Read()){
                v_precio_base_pasaje = consulta.GetDecimal(0);

            }
            cn.desconectar();

            StringBuilder sb2 = new StringBuilder();
            sb2.Append("select ts.ADICIONAL ");
            sb2.Append("from SASHAILO.Micro mi join SASHAILO.Tipo_Servicio ts on ts.ID_TIPO_SERVICIO = mi.ID_TIPO_SERVICIO ");
            sb2.Append("where mi.ID_MICRO = " + this.viaje.id_micro);
            Conexion cn2 = new Conexion();
            SqlDataReader consulta2 = cn2.consultar(sb2.ToString());
            if (consulta2.Read())
            {
                v_adicional = consulta2.GetDecimal(0);

            }
            cn2.desconectar();

            decimal precio = v_precio_base_pasaje * v_adicional;
            this.precio_pasaje = precio;

            return "$" + precio.ToString();

        }

        public string getPrecioPorKg()
        {
            decimal v_precio_base_kg = 0;

            StringBuilder sb = new StringBuilder();
            sb.Append("select rc.PRECIO_BASE_KG ");
            sb.Append("from SASHAILO.Recorrido re join SASHAILO.Recorrido_Ciudades rc on rc.ID_RECORRIDO_CIUDADES = re.ID_RECORRIDO_CIUDADES ");
            sb.Append("where re.ID_RECORRIDO = " + this.viaje.id_recorrido);
            Conexion cn = new Conexion();
            SqlDataReader consulta = cn.consultar(sb.ToString());
            if (consulta.Read())
            {
                v_precio_base_kg = consulta.GetDecimal(0);

            }
            cn.desconectar();

            this.precio_por_kg = v_precio_base_kg;

            return "$" + v_precio_base_kg.ToString();

        }

        public string getPrecioTotal()
        {

            decimal v_precio_encomiendas = this.cant_kg_totales * this.precio_por_kg;

            decimal v_precio_pasajes = 0;
            foreach (Nuevo_Pasaje.Pasaje pas in this.lista_pasajes)
            {
                v_precio_pasajes = v_precio_pasajes + pas.precio;
            }
            this.precio_total = v_precio_encomiendas + v_precio_pasajes;

            return "$" + this.precio_total.ToString();

        }

        private void c_tipo_pago_SelectedIndexChanged(object sender, EventArgs e)
        {
            int valor = ((ComboboxItem)c_tipo_pago.SelectedItem).Value;
            if (valor == 2)
            {
                n_tarjeta.Enabled = true;
                codigo_seguridad.Enabled = true;
                combo_vto.Enabled = true;
                c_cuotas.Enabled = true;
            }
            else {
                n_tarjeta.Enabled = false;
                codigo_seguridad.Enabled = false;
                combo_vto.Enabled = false;
                c_cuotas.Enabled = false;
            }
        }

        private void dni_KeyPress(object sender, KeyPressEventArgs e)
        {
            Funciones func = new Funciones();
            func.soloNumeros(e);
        }

        public class Cliente
        {
            public int id_cliente { get; set; }
            public String nombre { get; set; }
            public String apellido { get; set; }
            public String sexo { get; set; }
            public int dni { get; set; }
            public String direccion { get; set; }
            public decimal telefono { get; set; }
            public String email { get; set; }
            public DateTime f_nacimiento { get; set; }

            public override string ToString()
            {
                return nombre + " " + apellido;
            }

        }

        private void dni_Leave(object sender, EventArgs e)
        {
            if (dni.Text.Trim().Equals(""))
                return;

            int n_doc = Convert.ToInt32(dni.Text.Trim());
            StringBuilder sb = new StringBuilder();
            sb.Append("SELECT ID_CLIENTE, SEXO, NOMBRE, APELLIDO, DNI, DIRECCION, TELEFONO, MAIL, F_NACIMIENTO ");
            sb.Append("FROM SASHAILO.Cliente cli ");
            sb.Append("WHERE cli.DNI = " + n_doc);
            Conexion cn = new Conexion();
            SqlDataReader consulta = cn.consultar(sb.ToString());

            if (consulta.Read()) //existe el cliente ingresado
            {
                int v_id_cliente = consulta.GetInt32(0);
                String v_sexo = (consulta.IsDBNull(1)) ? null : consulta.GetString(1);
                String v_nombre = consulta.GetString(2);
                String v_apellido = consulta.GetString(3);
                String v_direccion = (consulta.IsDBNull(5)) ? null : consulta.GetString(5);
                decimal v_telefono = (consulta.IsDBNull(6)) ? -1 : consulta.GetDecimal(6);
                String v_mail = (consulta.IsDBNull(7)) ? null : consulta.GetString(7);
                DateTime v_f_nac = consulta.GetDateTime(8);

                Cliente cli = new Cliente();
                cli.id_cliente = v_id_cliente;
                cli.email = v_mail;
                cli.sexo = v_sexo;
                cli.nombre = v_nombre;
                cli.apellido = v_apellido;
                cli.direccion = v_direccion;
                cli.telefono = v_telefono;
                cli.f_nacimiento = v_f_nac;

                this.cliente = cli;

                //lleno datos en la pantalla
                nombre.Text = v_nombre;
                apellido.Text = v_apellido;
                email.Text = v_mail;
                direccion.Text = v_direccion;
                telefono.Text = (v_telefono == -1) ? "" : v_telefono.ToString();
                f_nac.Value = v_f_nac;
                if (v_sexo != null)
                {
                    if (v_sexo.Trim().Equals("M"))
                        seleccionarEnCombo(combo_sexo, 0);
                    else
                        seleccionarEnCombo(combo_sexo, 1);
                }
                else
                    combo_sexo.SelectedIndex = -1;

            }
            else
            { //no existe el cliente ingresado
                this.cliente = null;
            }
            cn.desconectar();
        }

        public void seleccionarEnCombo(ComboBox combo, int value)
        {
            int items = combo.Items.Count;
            for (int i = 0; i < items; i++)
            {
                ComboboxItem item = (ComboboxItem)combo.Items[i];
                if (item.Value == value)
                {
                    combo.SelectedIndex = i;
                    return;
                }
            }

        }

        private void telefono_KeyPress(object sender, KeyPressEventArgs e)
        {
            Funciones func = new Funciones();
            func.soloNumeros(e);
        }

        private void n_tarjeta_KeyPress(object sender, KeyPressEventArgs e)
        {
            Funciones func = new Funciones();
            func.soloNumeros(e);
        }

        private void codigo_seguridad_KeyPress(object sender, KeyPressEventArgs e)
        {
            Funciones func = new Funciones();
            func.soloNumeros(e);
        }

        private void n_tarjeta_Leave(object sender, EventArgs e)
        {
            StringBuilder sb = new StringBuilder();
            sb.Append("select tt.CUOTAS ");
            sb.Append("from SASHAILO.Tarjeta_Credito ta join SASHAILO.Tipo_Tarjeta tt on tt.ID_TIPO_TARJETA = ta.ID_TIPO_TARJETA ");
            sb.Append("where ta.NRO_TARJETA = '"+ n_tarjeta.Text.Trim() +"'");
            Conexion cn = new Conexion();
            SqlDataReader consulta = cn.consultar(sb.ToString());

            c_cuotas.Items.Clear();
            if (consulta.Read()) //existe el cliente ingresado
            {
                int v_cuotas = consulta.GetInt32(0);
                for (int i = 1; i <= v_cuotas; i++ )
                {
                    int c_cuota = i;
                    string d_cuota = i.ToString();
                    ComboboxItem item = new ComboboxItem();
                    item.Text = d_cuota;
                    item.Value = c_cuota;
                    c_cuotas.Items.Add(item);
                }
            }
            else
            {
                int c_cuota = 1;
                string d_cuota = "1";
                ComboboxItem item = new ComboboxItem();
                item.Text = d_cuota;
                item.Value = c_cuota;
                c_cuotas.Items.Add(item);
            }
            cn.desconectar();
        }

        private void b_guardar_Click(object sender, EventArgs e)
        {
            if(this.mostroComprobante){
                Finalizar_Compra.ActiveForm.Close();
                return;
            }
            String err = "";
            if (dni.Text.Trim().Equals(""))
                err = err + "Debe ingresar el DNI del pasajero \n";
            if (nombre.Text.Trim().Equals(""))
                err = err + "Debe ingresar el nombre del pasajero \n";
            if (apellido.Text.Trim().Equals(""))
                err = err + "Debe ingresar el apellido del pasajero \n";
            if (((ComboboxItem)combo_sexo.SelectedItem) == null)
                err = err + "Debe seleccionar el sexo del pasajero \n";
            if (fechaNacimientoMayorActual())
                err = err + "La fecha de nacimiento no puede ser posterior a la fecha actual \n";
            if (((ComboboxItem)c_tipo_pago.SelectedItem) == null)
                err = err + "Debe seleccionar el medio de pago \n";
            if (n_tarjeta.Enabled && !tarjetaValida())
                err = err + "Los datos de la tarjeta ingresada no son correctos \n";
            if (n_tarjeta.Enabled && ((ComboboxItem)c_cuotas.SelectedItem) == null)
                err = err + "Debe seleccionar la cantidad de cuotas \n";

            if (!err.Equals(""))
            {
                MessageBox.Show(err, "Error", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                return;
            }

            int id_cliente_generado = grabaCliente();
            int id_compra_generada = grabaCompra(id_cliente_generado);
            this.id_compra_generada = id_compra_generada;

            //grabo los pasajes
            foreach (Nuevo_Pasaje.Pasaje pas in this.lista_pasajes)
            {
                int id_pasaje_generado = grabaPasaje(pas.cliente.id_cliente, id_compra_generada, pas.viaje.id_viaje, pas.butaca.id_butaca, pas.precio, pas.pas_discapacitado);
                pas.id_pasaje_gen = id_pasaje_generado;
            }

            //grabo las encomiendas
            foreach (Nueva_Encomienda.Encomienda enco in this.lista_encomiendas)
            {
                int id_encomienda_generada = grabaEncomienda(enco.cliente.id_cliente, id_compra_generada, enco.viaje.id_viaje, enco.cant_kg, enco.precio, enco.id_provisorio);
                enco.id_encomienda_gen = id_encomienda_generada;
            }

            mostrarComprobante();

        }

        public int grabaCliente()
        {

            Conexion conn = new Conexion();
            SqlCommand sp_alta;
            int id_cliente_generado;

            sp_alta = new SqlCommand("SASHAILO.sp_cliente_am", conn.miConexion); // Lo inicializo
            sp_alta.CommandType = CommandType.StoredProcedure; // Defino que tipo de comando es
            SqlParameter ID_CLIENTE = sp_alta.Parameters.Add("@p_id_cliente", SqlDbType.Int);
            SqlParameter NOMBRE = sp_alta.Parameters.Add("@p_nombre", SqlDbType.VarChar, 255);
            SqlParameter APELLIDO = sp_alta.Parameters.Add("@p_apellido", SqlDbType.VarChar, 255);
            SqlParameter DNI = sp_alta.Parameters.Add("@p_dni", SqlDbType.BigInt);
            SqlParameter DIRECCION = sp_alta.Parameters.Add("@p_direccion", SqlDbType.VarChar, 255);
            SqlParameter TELEFONO = sp_alta.Parameters.Add("@p_telefono", SqlDbType.BigInt);
            SqlParameter MAIL = sp_alta.Parameters.Add("@p_mail", SqlDbType.VarChar, 255);
            SqlParameter F_NACIMIENTO = sp_alta.Parameters.Add("@p_f_nacimiento", SqlDbType.DateTime);
            SqlParameter SEXO = sp_alta.Parameters.Add("@p_sexo", SqlDbType.Char, 1);
            SqlParameter ID_CLIENTE_GEN = sp_alta.Parameters.Add("@p_id_cliente_gen", SqlDbType.Int);
            SqlParameter HAY_ERROR_USER = sp_alta.Parameters.Add("@hayErr", SqlDbType.Int);
            SqlParameter ERRORES_USER = sp_alta.Parameters.Add("@errores", SqlDbType.VarChar, 200);

            if (this.cliente == null)
                ID_CLIENTE.Value = DBNull.Value;
            else
                ID_CLIENTE.Value = this.cliente.id_cliente;

            NOMBRE.Value = nombre.Text.Trim();
            APELLIDO.Value = apellido.Text.Trim();

            if (dni.Text.Trim().Equals(""))
                DNI.Value = DBNull.Value;
            else
                DNI.Value = dni.Text.Trim();

            if (direccion.Text.Trim().Equals(""))
                DIRECCION.Value = DBNull.Value;
            else
                DIRECCION.Value = direccion.Text.Trim();

            if (telefono.Text.Trim().Equals(""))
                TELEFONO.Value = DBNull.Value;
            else
                TELEFONO.Value = telefono.Text.Trim();

            if (email.Text.Trim().Equals(""))
                MAIL.Value = DBNull.Value;
            else
                MAIL.Value = email.Text.Trim();

            F_NACIMIENTO.Value = f_nac.Value.Date;
            if (((ComboboxItem)combo_sexo.SelectedItem).Value == 0)
                SEXO.Value = "M";
            else
                SEXO.Value = "F";

            ID_CLIENTE_GEN.Direction = ParameterDirection.Output;
            HAY_ERROR_USER.Direction = ParameterDirection.Output;
            ERRORES_USER.Direction = ParameterDirection.Output;

            try
            {
                sp_alta.ExecuteNonQuery();

                id_cliente_generado = Convert.ToInt32(sp_alta.Parameters["@p_id_cliente_gen"].Value.ToString());
                int hayError = Convert.ToInt16(sp_alta.Parameters["@hayErr"].Value.ToString());
                if (hayError == 1)
                {
                    string errores = sp_alta.Parameters["@errores"].Value.ToString();
                    conn.desconectar();
                    return -1;
                }
            }
            catch (Exception error)
            {
                conn.desconectar();
                return -1;
            }
            conn.desconectar();

            //me guardo el objeto cliente
            Cliente cli = new Cliente();
            cli.id_cliente = id_cliente_generado;
            cli.email = email.Text.Trim();
            cli.sexo = (((ComboboxItem)combo_sexo.SelectedItem).Value == 0) ? "M" : "F";
            cli.nombre = nombre.Text.Trim();
            cli.dni = Convert.ToInt32(dni.Text.Trim());
            cli.apellido = apellido.Text.Trim();
            cli.direccion = direccion.Text.Trim();
            if (!telefono.Text.Trim().Equals(""))
                cli.telefono = Convert.ToDecimal(telefono.Text.Trim());
            else
                cli.telefono = -1;
            cli.f_nacimiento = f_nac.Value.Date;
            this.cliente = cli;

            return id_cliente_generado;

        }

        public int grabaCompra(int id_cliente)
        {

            Conexion conn = new Conexion();
            SqlCommand sp_alta;
            int id_compra_generada;

            sp_alta = new SqlCommand("SASHAILO.sp_alta_compra", conn.miConexion); // Lo inicializo
            sp_alta.CommandType = CommandType.StoredProcedure; // Defino que tipo de comando es
            SqlParameter ID_CLIENTE = sp_alta.Parameters.Add("@p_id_cliente", SqlDbType.Int);
            SqlParameter F_COMPRA = sp_alta.Parameters.Add("@p_f_compra", SqlDbType.DateTime);
            SqlParameter IMPORTE = sp_alta.Parameters.Add("@p_importe", SqlDbType.Decimal);
            SqlParameter ID_MEDIO_PAGO = sp_alta.Parameters.Add("@p_id_medio_pago", SqlDbType.Int);
            SqlParameter NRO_TARJETA = sp_alta.Parameters.Add("@p_nro_tarjeta", SqlDbType.VarChar, 16);
            SqlParameter ID_COMPRA_GEN = sp_alta.Parameters.Add("@p_id_compra_gen", SqlDbType.Int);
            SqlParameter HAY_ERROR_USER = sp_alta.Parameters.Add("@hayErr", SqlDbType.Int);
            SqlParameter ERRORES_USER = sp_alta.Parameters.Add("@errores", SqlDbType.VarChar, 200);

            Funciones func = new Funciones();

            ID_CLIENTE.Value = id_cliente;
            F_COMPRA.Value = func.getFechaActual();
            IMPORTE.Value = this.precio_total;
            ID_MEDIO_PAGO.Value = ((ComboboxItem)c_tipo_pago.SelectedItem).Value;
            if (((ComboboxItem)c_tipo_pago.SelectedItem).Value == 1)
                NRO_TARJETA.Value = DBNull.Value;
            else
                NRO_TARJETA.Value = n_tarjeta.Text.Trim();

            ID_COMPRA_GEN.Direction = ParameterDirection.Output;
            HAY_ERROR_USER.Direction = ParameterDirection.Output;
            ERRORES_USER.Direction = ParameterDirection.Output;

            try
            {
                sp_alta.ExecuteNonQuery();
                int hayError = Convert.ToInt16(sp_alta.Parameters["@hayErr"].Value.ToString());
                if (hayError == 1)
                {
                    string errores = sp_alta.Parameters["@errores"].Value.ToString();
                    conn.desconectar();
                    return -1;
                }
                id_compra_generada = Convert.ToInt32(sp_alta.Parameters["@p_id_compra_gen"].Value.ToString());
            }
            catch (Exception error)
            {
                conn.desconectar();
                return -1;
            }
            conn.desconectar();

            return id_compra_generada;

        }

        public int grabaPasaje(int id_cliente, int id_compra, int id_viaje, int id_butaca, decimal precio, bool discapacidad)
        {

            Conexion conn = new Conexion();
            SqlCommand sp_alta;
            int id_pasaje_generado;

            sp_alta = new SqlCommand("SASHAILO.sp_alta_compra_pasaje", conn.miConexion); // Lo inicializo
            sp_alta.CommandType = CommandType.StoredProcedure; // Defino que tipo de comando es
            SqlParameter ID_CLIENTE = sp_alta.Parameters.Add("@p_id_cliente", SqlDbType.Int);
            SqlParameter ID_COMPRA = sp_alta.Parameters.Add("@p_id_compra", SqlDbType.Int);
            SqlParameter ID_VIAJE = sp_alta.Parameters.Add("@p_id_viaje", SqlDbType.Int);
            SqlParameter ID_BUTACA = sp_alta.Parameters.Add("@p_id_butaca", SqlDbType.Int);
            SqlParameter PRECIO = sp_alta.Parameters.Add("@p_precio", SqlDbType.Decimal);
            SqlParameter DISCAP = sp_alta.Parameters.Add("@p_discapacidad", SqlDbType.Char, 1);
            SqlParameter ID_PASAJE_GEN = sp_alta.Parameters.Add("@p_id_pasaje_gen", SqlDbType.Int);
            SqlParameter HAY_ERROR_USER = sp_alta.Parameters.Add("@hayErr", SqlDbType.Int);
            SqlParameter ERRORES_USER = sp_alta.Parameters.Add("@errores", SqlDbType.VarChar, 200);


            ID_CLIENTE.Value = id_cliente;
            ID_COMPRA.Value = id_compra;
            ID_VIAJE.Value = id_viaje;
            ID_BUTACA.Value = id_butaca;
            PRECIO.Value = precio;
            DISCAP.Value = (discapacidad) ? "S" : "N";
            ID_PASAJE_GEN.Direction = ParameterDirection.Output;
            HAY_ERROR_USER.Direction = ParameterDirection.Output;
            ERRORES_USER.Direction = ParameterDirection.Output;

            try
            {
                sp_alta.ExecuteNonQuery();
                int hayError = Convert.ToInt16(sp_alta.Parameters["@hayErr"].Value.ToString());
                if (hayError == 1)
                {
                    string errores = sp_alta.Parameters["@errores"].Value.ToString();
                    conn.desconectar();
                    return -1;
                }
                id_pasaje_generado = Convert.ToInt32(sp_alta.Parameters["@p_id_pasaje_gen"].Value.ToString());
            }
            catch (Exception error)
            {
                conn.desconectar();
                return -1;
            }
            conn.desconectar();

            return id_pasaje_generado;

        }

        public int grabaEncomienda(int id_cliente, int id_compra, int id_viaje, int kg, decimal precio, int id_provisorio)
        {

            Conexion conn = new Conexion();
            SqlCommand sp_alta;
            int id_encomienda_generada;

            sp_alta = new SqlCommand("SASHAILO.sp_alta_compra_encomienda", conn.miConexion); // Lo inicializo
            sp_alta.CommandType = CommandType.StoredProcedure; // Defino que tipo de comando es
            SqlParameter ID_CLIENTE = sp_alta.Parameters.Add("@p_id_cliente", SqlDbType.Int);
            SqlParameter ID_COMPRA = sp_alta.Parameters.Add("@p_id_compra", SqlDbType.Int);
            SqlParameter ID_VIAJE = sp_alta.Parameters.Add("@p_id_viaje", SqlDbType.Int);
            SqlParameter PRECIO = sp_alta.Parameters.Add("@p_precio", SqlDbType.Decimal);
            SqlParameter KG = sp_alta.Parameters.Add("@p_kg", SqlDbType.BigInt);
            SqlParameter ID_PROVISORIO = sp_alta.Parameters.Add("@p_id_provisorio", SqlDbType.Int);
            SqlParameter ID_ENCOMIENDA_GEN = sp_alta.Parameters.Add("@p_id_encomienda_gen", SqlDbType.Int);
            SqlParameter HAY_ERROR_USER = sp_alta.Parameters.Add("@hayErr", SqlDbType.Int);
            SqlParameter ERRORES_USER = sp_alta.Parameters.Add("@errores", SqlDbType.VarChar, 200);


            ID_CLIENTE.Value = id_cliente;
            ID_COMPRA.Value = id_compra;
            ID_VIAJE.Value = id_viaje;
            PRECIO.Value = precio;
            KG.Value = kg;
            ID_PROVISORIO.Value = id_provisorio;
            ID_ENCOMIENDA_GEN.Direction = ParameterDirection.Output;
            HAY_ERROR_USER.Direction = ParameterDirection.Output;
            ERRORES_USER.Direction = ParameterDirection.Output;

            try
            {
                sp_alta.ExecuteNonQuery();
                int hayError = Convert.ToInt16(sp_alta.Parameters["@hayErr"].Value.ToString());
                if (hayError == 1)
                {
                    string errores = sp_alta.Parameters["@errores"].Value.ToString();
                    conn.desconectar();
                    return -1;
                }
                id_encomienda_generada = Convert.ToInt32(sp_alta.Parameters["@p_id_encomienda_gen"].Value.ToString());
            }
            catch (Exception error)
            {
                conn.desconectar();
                return -1;
            }
            conn.desconectar();

            return id_encomienda_generada;

        }

        public Boolean fechaNacimientoMayorActual()
        {
            DateTime fecha_actual = Convert.ToDateTime(ConfigurationSettings.AppSettings["fechaActual"]);
            DateTime v_f_nac = f_nac.Value.Date;
            if (v_f_nac >= fecha_actual)
                return true;
            return false;
        }

        private bool tarjetaValida()
        {
            bool rtado = false;
            if (((ComboboxItemVto)combo_vto.SelectedItem) == null)
                return rtado;

            string vto = ((ComboboxItemVto)combo_vto.SelectedItem).Value;
            StringBuilder sb = new StringBuilder();
            sb.Append("select 1 from SASHAILO.Tarjeta_Credito ");
            sb.Append("where NRO_TARJETA = '"+n_tarjeta.Text.Trim()+"' and VENCIMIENTO = '"+vto+"' and CODIGO_SEGURIDAD = '"+codigo_seguridad.Text.Trim()+"'");
            Conexion cn = new Conexion();
            SqlDataReader consulta = cn.consultar(sb.ToString());

            if (consulta.Read()) //existe la tarjeta
            {
                rtado = true;
            }

            cn.desconectar();

            return rtado;
        }

    }
}
