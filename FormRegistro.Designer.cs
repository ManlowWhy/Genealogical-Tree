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
            this.buttonVerMapa = new System.Windows.Forms.Button();
            this.textBoxRutaFoto = new System.Windows.Forms.TextBox();
            this.labelFoto = new System.Windows.Forms.Label();
            this.groupBoxUbicacion = new System.Windows.Forms.GroupBox();
            this.textBoxLongitud = new System.Windows.Forms.TextBox();
            this.textBoxLatitud = new System.Windows.Forms.TextBox();
            this.labelLongitud = new System.Windows.Forms.Label();
            this.labelLatitud = new System.Windows.Forms.Label();
            this.buttonAgregarFamiliar = new System.Windows.Forms.Button();
            this.groupBoxParentezco = new System.Windows.Forms.GroupBox();
            this.comboBoxParentezco = new System.Windows.Forms.ComboBox();
            this.textBoxEdad = new System.Windows.Forms.TextBox();
            this.textBoxCedula = new System.Windows.Forms.TextBox();
            this.textBoxNombre = new System.Windows.Forms.TextBox();
            this.textBoxFechaNaci = new System.Windows.Forms.TextBox();
            this.labelCedula = new System.Windows.Forms.Label();
            this.labelFechaNaci = new System.Windows.Forms.Label();
            this.labelEdad = new System.Windows.Forms.Label();
            this.groupBoxArbol = new System.Windows.Forms.GroupBox();
            this.panelArbol = new System.Windows.Forms.Panel();
            this.groupBoxDatosPersona.SuspendLayout();
            this.groupBoxUbicacion.SuspendLayout();
            this.groupBoxParentezco.SuspendLayout();
            this.groupBoxArbol.SuspendLayout();
            this.SuspendLayout();
            // 
            // labelNombre
            // 
            this.labelNombre.AutoSize = true;
            this.labelNombre.Location = new System.Drawing.Point(26, 69);
            this.labelNombre.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.labelNombre.Name = "labelNombre";
            this.labelNombre.Size = new System.Drawing.Size(69, 20);
            this.labelNombre.TabIndex = 0;
            this.labelNombre.Text = "Nombre:";
            // 
            // groupBoxDatosPersona
            // 
            this.groupBoxDatosPersona.Controls.Add(this.buttonVerMapa);
            this.groupBoxDatosPersona.Controls.Add(this.textBoxRutaFoto);
            this.groupBoxDatosPersona.Controls.Add(this.labelFoto);
            this.groupBoxDatosPersona.Controls.Add(this.groupBoxUbicacion);
            this.groupBoxDatosPersona.Controls.Add(this.buttonAgregarFamiliar);
            this.groupBoxDatosPersona.Controls.Add(this.groupBoxParentezco);
            this.groupBoxDatosPersona.Controls.Add(this.textBoxEdad);
            this.groupBoxDatosPersona.Controls.Add(this.textBoxCedula);
            this.groupBoxDatosPersona.Controls.Add(this.textBoxNombre);
            this.groupBoxDatosPersona.Controls.Add(this.textBoxFechaNaci);
            this.groupBoxDatosPersona.Controls.Add(this.labelCedula);
            this.groupBoxDatosPersona.Controls.Add(this.labelNombre);
            this.groupBoxDatosPersona.Controls.Add(this.labelFechaNaci);
            this.groupBoxDatosPersona.Controls.Add(this.labelEdad);
            this.groupBoxDatosPersona.Location = new System.Drawing.Point(18, 18);
            this.groupBoxDatosPersona.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.groupBoxDatosPersona.Name = "groupBoxDatosPersona";
            this.groupBoxDatosPersona.Padding = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.groupBoxDatosPersona.Size = new System.Drawing.Size(480, 866);
            this.groupBoxDatosPersona.TabIndex = 1;
            this.groupBoxDatosPersona.TabStop = false;
            this.groupBoxDatosPersona.Text = "Datos personales";
            // 
            // buttonVerMapa
            // 
            this.buttonVerMapa.Location = new System.Drawing.Point(256, 787);
            this.buttonVerMapa.Name = "buttonVerMapa";
            this.buttonVerMapa.Size = new System.Drawing.Size(186, 35);
            this.buttonVerMapa.TabIndex = 18;
            this.buttonVerMapa.Text = "Ver mapa";
            this.buttonVerMapa.UseVisualStyleBackColor = true;
            this.buttonVerMapa.Click += new System.EventHandler(this.buttonVerMapa_Click);
            // 
            // textBoxRutaFoto
            // 
            this.textBoxRutaFoto.Location = new System.Drawing.Point(9, 698);
            this.textBoxRutaFoto.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.textBoxRutaFoto.Name = "textBoxRutaFoto";
            this.textBoxRutaFoto.Size = new System.Drawing.Size(451, 26);
            this.textBoxRutaFoto.TabIndex = 17;
            // 
            // labelFoto
            // 
            this.labelFoto.AutoSize = true;
            this.labelFoto.Location = new System.Drawing.Point(174, 674);
            this.labelFoto.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.labelFoto.Name = "labelFoto";
            this.labelFoto.Size = new System.Drawing.Size(102, 20);
            this.labelFoto.TabIndex = 16;
            this.labelFoto.Text = "Ruta de foto:";
            // 
            // groupBoxUbicacion
            // 
            this.groupBoxUbicacion.Controls.Add(this.textBoxLongitud);
            this.groupBoxUbicacion.Controls.Add(this.textBoxLatitud);
            this.groupBoxUbicacion.Controls.Add(this.labelLongitud);
            this.groupBoxUbicacion.Controls.Add(this.labelLatitud);
            this.groupBoxUbicacion.Location = new System.Drawing.Point(18, 342);
            this.groupBoxUbicacion.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.groupBoxUbicacion.Name = "groupBoxUbicacion";
            this.groupBoxUbicacion.Padding = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.groupBoxUbicacion.Size = new System.Drawing.Size(426, 171);
            this.groupBoxUbicacion.TabIndex = 15;
            this.groupBoxUbicacion.TabStop = false;
            this.groupBoxUbicacion.Text = "Ubicación";
            // 
            // textBoxLongitud
            // 
            this.textBoxLongitud.Location = new System.Drawing.Point(100, 108);
            this.textBoxLongitud.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.textBoxLongitud.Name = "textBoxLongitud";
            this.textBoxLongitud.Size = new System.Drawing.Size(306, 26);
            this.textBoxLongitud.TabIndex = 3;
            // 
            // textBoxLatitud
            // 
            this.textBoxLatitud.Location = new System.Drawing.Point(100, 45);
            this.textBoxLatitud.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.textBoxLatitud.Name = "textBoxLatitud";
            this.textBoxLatitud.Size = new System.Drawing.Size(306, 26);
            this.textBoxLatitud.TabIndex = 2;
            // 
            // labelLongitud
            // 
            this.labelLongitud.AutoSize = true;
            this.labelLongitud.Location = new System.Drawing.Point(15, 112);
            this.labelLongitud.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.labelLongitud.Name = "labelLongitud";
            this.labelLongitud.Size = new System.Drawing.Size(75, 20);
            this.labelLongitud.TabIndex = 1;
            this.labelLongitud.Text = "Longitud:";
            // 
            // labelLatitud
            // 
            this.labelLatitud.AutoSize = true;
            this.labelLatitud.Location = new System.Drawing.Point(15, 55);
            this.labelLatitud.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.labelLatitud.Name = "labelLatitud";
            this.labelLatitud.Size = new System.Drawing.Size(62, 20);
            this.labelLatitud.TabIndex = 0;
            this.labelLatitud.Text = "Latitud:";
            // 
            // buttonAgregarFamiliar
            // 
            this.buttonAgregarFamiliar.Location = new System.Drawing.Point(30, 787);
            this.buttonAgregarFamiliar.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.buttonAgregarFamiliar.Name = "buttonAgregarFamiliar";
            this.buttonAgregarFamiliar.Size = new System.Drawing.Size(180, 35);
            this.buttonAgregarFamiliar.TabIndex = 14;
            this.buttonAgregarFamiliar.Text = "Agregar familiar";
            this.buttonAgregarFamiliar.UseVisualStyleBackColor = true;
            this.buttonAgregarFamiliar.Click += new System.EventHandler(this.buttonAgregarFamiliar_Click);
            // 
            // groupBoxParentezco
            // 
            this.groupBoxParentezco.Controls.Add(this.comboBoxParentezco);
            this.groupBoxParentezco.Location = new System.Drawing.Point(18, 538);
            this.groupBoxParentezco.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.groupBoxParentezco.Name = "groupBoxParentezco";
            this.groupBoxParentezco.Padding = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.groupBoxParentezco.Size = new System.Drawing.Size(426, 108);
            this.groupBoxParentezco.TabIndex = 13;
            this.groupBoxParentezco.TabStop = false;
            this.groupBoxParentezco.Text = "Parentezco:";
            // 
            // comboBoxParentezco
            // 
            this.comboBoxParentezco.FormattingEnabled = true;
            this.comboBoxParentezco.Items.AddRange(new object[] {
            "Abuela Materna",
            "Abuelo Materno",
            "Abuela Paterna",
            "Abuelo Paterno",
            "Madre",
            "Padre",
            "Hija",
            "Hijo"});
            this.comboBoxParentezco.Location = new System.Drawing.Point(108, 45);
            this.comboBoxParentezco.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.comboBoxParentezco.Name = "comboBoxParentezco";
            this.comboBoxParentezco.Size = new System.Drawing.Size(298, 28);
            this.comboBoxParentezco.TabIndex = 0;
            // 
            // textBoxEdad
            // 
            this.textBoxEdad.Location = new System.Drawing.Point(135, 265);
            this.textBoxEdad.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.textBoxEdad.Name = "textBoxEdad";
            this.textBoxEdad.Size = new System.Drawing.Size(307, 26);
            this.textBoxEdad.TabIndex = 10;
            // 
            // textBoxCedula
            // 
            this.textBoxCedula.Location = new System.Drawing.Point(130, 135);
            this.textBoxCedula.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.textBoxCedula.Name = "textBoxCedula";
            this.textBoxCedula.Size = new System.Drawing.Size(312, 26);
            this.textBoxCedula.TabIndex = 7;
            // 
            // textBoxNombre
            // 
            this.textBoxNombre.Location = new System.Drawing.Point(130, 65);
            this.textBoxNombre.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.textBoxNombre.Name = "textBoxNombre";
            this.textBoxNombre.Size = new System.Drawing.Size(312, 26);
            this.textBoxNombre.TabIndex = 6;
            // 
            // textBoxFechaNaci
            // 
            this.textBoxFechaNaci.Location = new System.Drawing.Point(200, 194);
            this.textBoxFechaNaci.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.textBoxFechaNaci.Name = "textBoxFechaNaci";
            this.textBoxFechaNaci.Size = new System.Drawing.Size(242, 26);
            this.textBoxFechaNaci.TabIndex = 9;
            this.textBoxFechaNaci.Text = "DD/MM/AAAA";
            // 
            // labelCedula
            // 
            this.labelCedula.AutoSize = true;
            this.labelCedula.Location = new System.Drawing.Point(26, 135);
            this.labelCedula.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.labelCedula.Name = "labelCedula";
            this.labelCedula.Size = new System.Drawing.Size(63, 20);
            this.labelCedula.TabIndex = 1;
            this.labelCedula.Text = "Cédula:";
            // 
            // labelFechaNaci
            // 
            this.labelFechaNaci.AutoSize = true;
            this.labelFechaNaci.Location = new System.Drawing.Point(26, 198);
            this.labelFechaNaci.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.labelFechaNaci.Name = "labelFechaNaci";
            this.labelFechaNaci.Size = new System.Drawing.Size(161, 20);
            this.labelFechaNaci.TabIndex = 3;
            this.labelFechaNaci.Text = "Fecha de nacimiento:";
            // 
            // labelEdad
            // 
            this.labelEdad.AutoSize = true;
            this.labelEdad.Location = new System.Drawing.Point(26, 269);
            this.labelEdad.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.labelEdad.Name = "labelEdad";
            this.labelEdad.Size = new System.Drawing.Size(98, 20);
            this.labelEdad.TabIndex = 4;
            this.labelEdad.Text = "Edad actual:";
            // 
            // groupBoxArbol
            // 
            this.groupBoxArbol.Controls.Add(this.panelArbol);
            this.groupBoxArbol.Location = new System.Drawing.Point(507, 18);
            this.groupBoxArbol.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.groupBoxArbol.Name = "groupBoxArbol";
            this.groupBoxArbol.Padding = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.groupBoxArbol.Size = new System.Drawing.Size(1018, 866);
            this.groupBoxArbol.TabIndex = 17;
            this.groupBoxArbol.TabStop = false;
            this.groupBoxArbol.Text = "Arbol genealógico";
            // 
            // panelArbol
            // 
            this.panelArbol.AutoScroll = true;
            this.panelArbol.BackColor = System.Drawing.Color.White;
            this.panelArbol.Dock = System.Windows.Forms.DockStyle.Fill;
            this.panelArbol.Location = new System.Drawing.Point(4, 24);
            this.panelArbol.Name = "panelArbol";
            this.panelArbol.Size = new System.Drawing.Size(1010, 837);
            this.panelArbol.TabIndex = 0;
            // 
            // FormRegistro
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(9F, 20F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1544, 903);
            this.Controls.Add(this.groupBoxArbol);
            this.Controls.Add(this.groupBoxDatosPersona);
            this.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.Name = "FormRegistro";
            this.Text = "Registro de datos";
            this.groupBoxDatosPersona.ResumeLayout(false);
            this.groupBoxDatosPersona.PerformLayout();
            this.groupBoxUbicacion.ResumeLayout(false);
            this.groupBoxUbicacion.PerformLayout();
            this.groupBoxParentezco.ResumeLayout(false);
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
        private System.Windows.Forms.TextBox textBoxFechaNaci;
        private System.Windows.Forms.TextBox textBoxCedula;
        private System.Windows.Forms.TextBox textBoxNombre;
        private System.Windows.Forms.GroupBox groupBoxParentezco;
        private System.Windows.Forms.ComboBox comboBoxParentezco;
        private System.Windows.Forms.GroupBox groupBoxArbol;
        private System.Windows.Forms.Button buttonAgregarFamiliar;
        private System.Windows.Forms.GroupBox groupBoxUbicacion;
        private System.Windows.Forms.TextBox textBoxLongitud;
        private System.Windows.Forms.TextBox textBoxLatitud;
        private System.Windows.Forms.Label labelLongitud;
        private System.Windows.Forms.Label labelLatitud;
        private System.Windows.Forms.TextBox textBoxRutaFoto;
        private System.Windows.Forms.Label labelFoto;
        private System.Windows.Forms.Button buttonVerMapa;
        private System.Windows.Forms.Panel panelArbol;
    }
}