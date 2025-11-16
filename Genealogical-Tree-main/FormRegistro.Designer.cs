namespace MapaTest
{
    partial class FormRegistro
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
            this.labelNombre = new System.Windows.Forms.Label();
            this.groupBoxDatosPersona = new System.Windows.Forms.GroupBox();
            this.pictureFoto = new System.Windows.Forms.PictureBox();
            this.buttonBuscarFoto = new System.Windows.Forms.Button();
            this.comboBoxParentezco = new System.Windows.Forms.ComboBox();
            this.buttonAgregarFamiliar = new System.Windows.Forms.Button();
            this.dtpNacimiento = new System.Windows.Forms.DateTimePicker();
            this.buttonVerMapa = new System.Windows.Forms.Button();
            this.textBoxRutaFoto = new System.Windows.Forms.TextBox();
            this.labelFoto = new System.Windows.Forms.Label();
            this.groupBoxUbicacion = new System.Windows.Forms.GroupBox();
            this.textBoxLongitud = new System.Windows.Forms.TextBox();
            this.textBoxLatitud = new System.Windows.Forms.TextBox();
            this.labelLongitud = new System.Windows.Forms.Label();
            this.labelLatitud = new System.Windows.Forms.Label();
            this.textBoxEdad = new System.Windows.Forms.TextBox();
            this.textBoxCedula = new System.Windows.Forms.TextBox();
            this.textBoxNombre = new System.Windows.Forms.TextBox();
            this.labelCedula = new System.Windows.Forms.Label();
            this.labelFechaNaci = new System.Windows.Forms.Label();
            this.labelEdad = new System.Windows.Forms.Label();
            this.groupBoxArbol = new System.Windows.Forms.GroupBox();
            this.panelArbol = new System.Windows.Forms.Panel();
            this.groupBoxDatosPersona.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.pictureFoto)).BeginInit();
            this.groupBoxUbicacion.SuspendLayout();
            this.groupBoxArbol.SuspendLayout();
            this.SuspendLayout();
            // 
            // labelNombre
            // 
            this.labelNombre.AutoSize = true;
            this.labelNombre.Location = new System.Drawing.Point(17, 25);
            this.labelNombre.Name = "labelNombre";
            this.labelNombre.Size = new System.Drawing.Size(47, 13);
            this.labelNombre.TabIndex = 0;
            this.labelNombre.Text = "Nombre:";
            // 
            // groupBoxDatosPersona
            // 
            this.groupBoxDatosPersona.Controls.Add(this.pictureFoto);
            this.groupBoxDatosPersona.Controls.Add(this.buttonBuscarFoto);
            this.groupBoxDatosPersona.Controls.Add(this.comboBoxParentezco);
            this.groupBoxDatosPersona.Controls.Add(this.buttonAgregarFamiliar);
            this.groupBoxDatosPersona.Controls.Add(this.dtpNacimiento);
            this.groupBoxDatosPersona.Controls.Add(this.buttonVerMapa);
            this.groupBoxDatosPersona.Controls.Add(this.textBoxRutaFoto);
            this.groupBoxDatosPersona.Controls.Add(this.labelFoto);
            this.groupBoxDatosPersona.Controls.Add(this.groupBoxUbicacion);
            this.groupBoxDatosPersona.Controls.Add(this.textBoxEdad);
            this.groupBoxDatosPersona.Controls.Add(this.textBoxCedula);
            this.groupBoxDatosPersona.Controls.Add(this.textBoxNombre);
            this.groupBoxDatosPersona.Controls.Add(this.labelCedula);
            this.groupBoxDatosPersona.Controls.Add(this.labelNombre);
            this.groupBoxDatosPersona.Controls.Add(this.labelFechaNaci);
            this.groupBoxDatosPersona.Controls.Add(this.labelEdad);
            this.groupBoxDatosPersona.Location = new System.Drawing.Point(12, 12);
            this.groupBoxDatosPersona.Name = "groupBoxDatosPersona";
            this.groupBoxDatosPersona.Size = new System.Drawing.Size(324, 563);
            this.groupBoxDatosPersona.TabIndex = 1;
            this.groupBoxDatosPersona.TabStop = false;
            this.groupBoxDatosPersona.Text = "Datos personales";
            this.groupBoxDatosPersona.Enter += new System.EventHandler(this.groupBoxDatosPersona_Enter);
            // 
            // pictureFoto
            // 
            this.pictureFoto.Location = new System.Drawing.Point(204, 348);
            this.pictureFoto.Name = "pictureFoto";
            this.pictureFoto.Size = new System.Drawing.Size(100, 59);
            this.pictureFoto.TabIndex = 22;
            this.pictureFoto.TabStop = false;
            // 
            // buttonBuscarFoto
            // 
            this.buttonBuscarFoto.Location = new System.Drawing.Point(109, 360);
            this.buttonBuscarFoto.Name = "buttonBuscarFoto";
            this.buttonBuscarFoto.Size = new System.Drawing.Size(75, 23);
            this.buttonBuscarFoto.TabIndex = 21;
            this.buttonBuscarFoto.Text = "Buscar Foto";
            this.buttonBuscarFoto.UseVisualStyleBackColor = true;
            this.buttonBuscarFoto.Click += new System.EventHandler(this.buttonBuscarFoto_Click);
            // 
            // comboBoxParentezco
            // 
            this.comboBoxParentezco.FormattingEnabled = true;
            this.comboBoxParentezco.Location = new System.Drawing.Point(158, 520);
            this.comboBoxParentezco.Name = "comboBoxParentezco";
            this.comboBoxParentezco.Size = new System.Drawing.Size(121, 21);
            this.comboBoxParentezco.TabIndex = 20;
            // 
            // buttonAgregarFamiliar
            // 
            this.buttonAgregarFamiliar.Location = new System.Drawing.Point(98, 430);
            this.buttonAgregarFamiliar.Name = "buttonAgregarFamiliar";
            this.buttonAgregarFamiliar.Size = new System.Drawing.Size(120, 23);
            this.buttonAgregarFamiliar.TabIndex = 14;
            this.buttonAgregarFamiliar.Text = "Agregar familiar";
            this.buttonAgregarFamiliar.UseVisualStyleBackColor = true;
            this.buttonAgregarFamiliar.Click += new System.EventHandler(this.buttonAgregarFamiliar_Click);
            // 
            // dtpNacimiento
            // 
            this.dtpNacimiento.CustomFormat = "dd/MM/yyyy";
            this.dtpNacimiento.Format = System.Windows.Forms.DateTimePickerFormat.Custom;
            this.dtpNacimiento.Location = new System.Drawing.Point(132, 104);
            this.dtpNacimiento.Name = "dtpNacimiento";
            this.dtpNacimiento.Size = new System.Drawing.Size(172, 20);
            this.dtpNacimiento.TabIndex = 19;
            this.dtpNacimiento.ValueChanged += new System.EventHandler(this.dtpNacimiento_ValueChanged);
            // 
            // buttonVerMapa
            // 
            this.buttonVerMapa.Location = new System.Drawing.Point(171, 512);
            this.buttonVerMapa.Margin = new System.Windows.Forms.Padding(2);
            this.buttonVerMapa.Name = "buttonVerMapa";
            this.buttonVerMapa.Size = new System.Drawing.Size(124, 23);
            this.buttonVerMapa.TabIndex = 18;
            this.buttonVerMapa.Text = "Ver mapa";
            this.buttonVerMapa.UseVisualStyleBackColor = true;
            this.buttonVerMapa.Click += new System.EventHandler(this.buttonVerMapa_Click);
            // 
            // textBoxRutaFoto
            // 
            this.textBoxRutaFoto.Location = new System.Drawing.Point(6, 311);
            this.textBoxRutaFoto.Name = "textBoxRutaFoto";
            this.textBoxRutaFoto.ReadOnly = true;
            this.textBoxRutaFoto.Size = new System.Drawing.Size(302, 20);
            this.textBoxRutaFoto.TabIndex = 17;
            // 
            // labelFoto
            // 
            this.labelFoto.AutoSize = true;
            this.labelFoto.Location = new System.Drawing.Point(115, 295);
            this.labelFoto.Name = "labelFoto";
            this.labelFoto.Size = new System.Drawing.Size(69, 13);
            this.labelFoto.TabIndex = 16;
            this.labelFoto.Text = "Ruta de foto:";
            // 
            // groupBoxUbicacion
            // 
            this.groupBoxUbicacion.Controls.Add(this.textBoxLongitud);
            this.groupBoxUbicacion.Controls.Add(this.textBoxLatitud);
            this.groupBoxUbicacion.Controls.Add(this.labelLongitud);
            this.groupBoxUbicacion.Controls.Add(this.labelLatitud);
            this.groupBoxUbicacion.Location = new System.Drawing.Point(12, 173);
            this.groupBoxUbicacion.Name = "groupBoxUbicacion";
            this.groupBoxUbicacion.Size = new System.Drawing.Size(284, 110);
            this.groupBoxUbicacion.TabIndex = 15;
            this.groupBoxUbicacion.TabStop = false;
            this.groupBoxUbicacion.Text = "Ubicación";
            this.groupBoxUbicacion.Enter += new System.EventHandler(this.groupBoxUbicacion_Enter);
            // 
            // textBoxLongitud
            // 
            this.textBoxLongitud.Location = new System.Drawing.Point(67, 70);
            this.textBoxLongitud.Name = "textBoxLongitud";
            this.textBoxLongitud.Size = new System.Drawing.Size(205, 20);
            this.textBoxLongitud.TabIndex = 3;
            // 
            // textBoxLatitud
            // 
            this.textBoxLatitud.Location = new System.Drawing.Point(67, 29);
            this.textBoxLatitud.Name = "textBoxLatitud";
            this.textBoxLatitud.Size = new System.Drawing.Size(205, 20);
            this.textBoxLatitud.TabIndex = 2;
            // 
            // labelLongitud
            // 
            this.labelLongitud.AutoSize = true;
            this.labelLongitud.Location = new System.Drawing.Point(10, 73);
            this.labelLongitud.Name = "labelLongitud";
            this.labelLongitud.Size = new System.Drawing.Size(51, 13);
            this.labelLongitud.TabIndex = 1;
            this.labelLongitud.Text = "Longitud:";
            // 
            // labelLatitud
            // 
            this.labelLatitud.AutoSize = true;
            this.labelLatitud.Location = new System.Drawing.Point(10, 36);
            this.labelLatitud.Name = "labelLatitud";
            this.labelLatitud.Size = new System.Drawing.Size(42, 13);
            this.labelLatitud.TabIndex = 0;
            this.labelLatitud.Text = "Latitud:";
            // 
            // textBoxEdad
            // 
            this.textBoxEdad.Location = new System.Drawing.Point(98, 133);
            this.textBoxEdad.Name = "textBoxEdad";
            this.textBoxEdad.ReadOnly = true;
            this.textBoxEdad.Size = new System.Drawing.Size(206, 20);
            this.textBoxEdad.TabIndex = 10;
            // 
            // textBoxCedula
            // 
            this.textBoxCedula.Location = new System.Drawing.Point(87, 59);
            this.textBoxCedula.Name = "textBoxCedula";
            this.textBoxCedula.Size = new System.Drawing.Size(209, 20);
            this.textBoxCedula.TabIndex = 7;
            // 
            // textBoxNombre
            // 
            this.textBoxNombre.Location = new System.Drawing.Point(87, 22);
            this.textBoxNombre.Name = "textBoxNombre";
            this.textBoxNombre.Size = new System.Drawing.Size(209, 20);
            this.textBoxNombre.TabIndex = 6;
            // 
            // labelCedula
            // 
            this.labelCedula.AutoSize = true;
            this.labelCedula.Location = new System.Drawing.Point(17, 62);
            this.labelCedula.Name = "labelCedula";
            this.labelCedula.Size = new System.Drawing.Size(43, 13);
            this.labelCedula.TabIndex = 1;
            this.labelCedula.Text = "Cédula:";
            // 
            // labelFechaNaci
            // 
            this.labelFechaNaci.AutoSize = true;
            this.labelFechaNaci.Location = new System.Drawing.Point(17, 104);
            this.labelFechaNaci.Name = "labelFechaNaci";
            this.labelFechaNaci.Size = new System.Drawing.Size(109, 13);
            this.labelFechaNaci.TabIndex = 3;
            this.labelFechaNaci.Text = "Fecha de nacimiento:";
            // 
            // labelEdad
            // 
            this.labelEdad.AutoSize = true;
            this.labelEdad.Location = new System.Drawing.Point(17, 136);
            this.labelEdad.Name = "labelEdad";
            this.labelEdad.Size = new System.Drawing.Size(67, 13);
            this.labelEdad.TabIndex = 4;
            this.labelEdad.Text = "Edad actual:";
            this.labelEdad.Click += new System.EventHandler(this.labelEdad_Click);
            // 
            // groupBoxArbol
            // 
            this.groupBoxArbol.Controls.Add(this.panelArbol);
            this.groupBoxArbol.Location = new System.Drawing.Point(338, 12);
            this.groupBoxArbol.Name = "groupBoxArbol";
            this.groupBoxArbol.Size = new System.Drawing.Size(679, 563);
            this.groupBoxArbol.TabIndex = 17;
            this.groupBoxArbol.TabStop = false;
            this.groupBoxArbol.Text = "Arbol genealógico";
            // 
            // panelArbol
            // 
            this.panelArbol.AutoScroll = true;
            this.panelArbol.BackColor = System.Drawing.Color.White;
            this.panelArbol.Dock = System.Windows.Forms.DockStyle.Fill;
            this.panelArbol.Location = new System.Drawing.Point(3, 16);
            this.panelArbol.Margin = new System.Windows.Forms.Padding(2);
            this.panelArbol.Name = "panelArbol";
            this.panelArbol.Size = new System.Drawing.Size(673, 544);
            this.panelArbol.TabIndex = 0;
            // 
            // FormRegistro
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(913, 487);
            this.Controls.Add(this.groupBoxArbol);
            this.Controls.Add(this.groupBoxDatosPersona);
            this.Name = "FormRegistro";
            this.Text = "Registro de datos";
            this.Load += new System.EventHandler(this.FormRegistro_Load);
            this.groupBoxDatosPersona.ResumeLayout(false);
            this.groupBoxDatosPersona.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.pictureFoto)).EndInit();
            this.groupBoxUbicacion.ResumeLayout(false);
            this.groupBoxUbicacion.PerformLayout();
            this.groupBoxArbol.ResumeLayout(false);
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Label labelNombre;
        private System.Windows.Forms.GroupBox groupBoxDatosPersona;
        private System.Windows.Forms.Label labelCedula;
        private System.Windows.Forms.Label labelEdad;
        private System.Windows.Forms.Label labelFechaNaci;
        private System.Windows.Forms.TextBox textBoxEdad;
        private System.Windows.Forms.TextBox textBoxCedula;
        private System.Windows.Forms.TextBox textBoxNombre;
        private System.Windows.Forms.GroupBox groupBoxArbol;
        private System.Windows.Forms.GroupBox groupBoxUbicacion;
        private System.Windows.Forms.TextBox textBoxLongitud;
        private System.Windows.Forms.TextBox textBoxLatitud;
        private System.Windows.Forms.Label labelLongitud;
        private System.Windows.Forms.Label labelLatitud;
        private System.Windows.Forms.TextBox textBoxRutaFoto;
        private System.Windows.Forms.Label labelFoto;
        private System.Windows.Forms.Button buttonVerMapa;
        private System.Windows.Forms.Panel panelArbol;
        private System.Windows.Forms.DateTimePicker dtpNacimiento;
        private System.Windows.Forms.Button buttonAgregarFamiliar;
        private System.Windows.Forms.ComboBox comboBoxParentezco;
        private System.Windows.Forms.PictureBox pictureFoto;
        private System.Windows.Forms.Button buttonBuscarFoto;
    }
}