namespace MapaTest
{
    partial class FormMapa
    {
        /// <summary>
        /// Variable del diseñador necesaria.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Limpiar los recursos que se estén usando.
        /// </summary>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Código generado por el Diseñador de Windows Forms

        private void InitializeComponent()
        {
            this.gMapControl1 = new GMap.NET.WindowsForms.GMapControl();
            this.groupBoxStats = new System.Windows.Forms.GroupBox();
            this.lblPromDist = new System.Windows.Forms.Label();
            this.labelDistancia = new System.Windows.Forms.Label();
            this.labelStats = new System.Windows.Forms.Label();
            this.lblMaxDist = new System.Windows.Forms.Label();
            this.lblMinDist = new System.Windows.Forms.Label();
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.richTextBox1 = new System.Windows.Forms.RichTextBox();
            this.groupBox2 = new System.Windows.Forms.GroupBox();
            this.btnGenerarArbol = new System.Windows.Forms.Button();
            this.pictureBox1 = new System.Windows.Forms.PictureBox();
            this.groupBoxStats.SuspendLayout();
            this.groupBox1.SuspendLayout();
            this.groupBox2.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).BeginInit();
            this.SuspendLayout();
            // 
            // gMapControl1
            // 
            this.gMapControl1.BackColor = System.Drawing.Color.Lavender;
            this.gMapControl1.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Zoom;
            this.gMapControl1.Bearing = 0F;
            this.gMapControl1.CanDragMap = true;
            this.gMapControl1.EmptyTileColor = System.Drawing.Color.Black;
            this.gMapControl1.GrayScaleMode = false;
            this.gMapControl1.HelperLineOption = GMap.NET.WindowsForms.HelperLineOptions.DontShow;
            this.gMapControl1.LevelsKeepInMemory = 5;
            this.gMapControl1.Location = new System.Drawing.Point(12, 12);
            this.gMapControl1.MarkersEnabled = true;
            this.gMapControl1.MaxZoom = 2;
            this.gMapControl1.MinZoom = 2;
            this.gMapControl1.MouseWheelZoomEnabled = true;
            this.gMapControl1.MouseWheelZoomType = GMap.NET.MouseWheelZoomType.MousePositionAndCenter;
            this.gMapControl1.Name = "gMapControl1";
            this.gMapControl1.NegativeMode = false;
            this.gMapControl1.PolygonsEnabled = true;
            this.gMapControl1.RetryLoadTile = 0;
            this.gMapControl1.RoutesEnabled = true;
            this.gMapControl1.ScaleMode = GMap.NET.WindowsForms.ScaleModes.Integer;
            this.gMapControl1.SelectedAreaFillColor = System.Drawing.Color.FromArgb(((int)(((byte)(33)))), ((int)(((byte)(65)))), ((int)(((byte)(105)))), ((int)(((byte)(225)))));
            this.gMapControl1.ShowTileGridLines = false;
            this.gMapControl1.Size = new System.Drawing.Size(1011, 522);
            this.gMapControl1.TabIndex = 0;
            this.gMapControl1.Zoom = 0D;
            this.gMapControl1.Load += new System.EventHandler(this.gMapControl1_Load_1);
            // 
            // groupBoxStats
            // 
            this.groupBoxStats.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.groupBoxStats.BackColor = System.Drawing.Color.Black;
            this.groupBoxStats.Controls.Add(this.lblPromDist);
            this.groupBoxStats.Controls.Add(this.labelDistancia);
            this.groupBoxStats.Controls.Add(this.labelStats);
            this.groupBoxStats.Controls.Add(this.lblMaxDist);
            this.groupBoxStats.Controls.Add(this.lblMinDist);
            this.groupBoxStats.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.groupBoxStats.ForeColor = System.Drawing.Color.White;
            this.groupBoxStats.Location = new System.Drawing.Point(12, 553);
            this.groupBoxStats.Name = "groupBoxStats";
            this.groupBoxStats.Size = new System.Drawing.Size(1011, 154);
            this.groupBoxStats.TabIndex = 3;
            this.groupBoxStats.TabStop = false;
            this.groupBoxStats.Text = "Estadísticas";
            // 
            // lblPromDist
            // 
            this.lblPromDist.AutoSize = true;
            this.lblPromDist.Location = new System.Drawing.Point(522, 75);
            this.lblPromDist.Name = "lblPromDist";
            this.lblPromDist.Size = new System.Drawing.Size(78, 16);
            this.lblPromDist.TabIndex = 6;
            this.lblPromDist.Text = "Promedio:";
            // 
            // labelDistancia
            // 
            this.labelDistancia.AutoSize = true;
            this.labelDistancia.Location = new System.Drawing.Point(519, 44);
            this.labelDistancia.Name = "labelDistancia";
            this.labelDistancia.Size = new System.Drawing.Size(147, 16);
            this.labelDistancia.TabIndex = 5;
            this.labelDistancia.Text = "Distancia Promedio:";
            // 
            // labelStats
            // 
            this.labelStats.AutoSize = true;
            this.labelStats.Location = new System.Drawing.Point(19, 44);
            this.labelStats.Name = "labelStats";
            this.labelStats.Size = new System.Drawing.Size(212, 16);
            this.labelStats.TabIndex = 4;
            this.labelStats.Text = "Distancias en km entre pares:";
            // 
            // lblMaxDist
            // 
            this.lblMaxDist.AutoSize = true;
            this.lblMaxDist.Location = new System.Drawing.Point(83, 113);
            this.lblMaxDist.Name = "lblMaxDist";
            this.lblMaxDist.Size = new System.Drawing.Size(54, 16);
            this.lblMaxDist.TabIndex = 3;
            this.lblMaxDist.Text = "Mayor:";
            // 
            // lblMinDist
            // 
            this.lblMinDist.AutoSize = true;
            this.lblMinDist.Location = new System.Drawing.Point(83, 75);
            this.lblMinDist.Name = "lblMinDist";
            this.lblMinDist.Size = new System.Drawing.Size(54, 16);
            this.lblMinDist.TabIndex = 2;
            this.lblMinDist.Text = "Menor:";
            // 
            // groupBox1
            // 
            this.groupBox1.Controls.Add(this.richTextBox1);
            this.groupBox1.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.groupBox1.ForeColor = System.Drawing.Color.White;
            this.groupBox1.Location = new System.Drawing.Point(1053, 85);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size(287, 161);
            this.groupBox1.TabIndex = 6;
            this.groupBox1.TabStop = false;
            this.groupBox1.Text = "¡Relacionar a un familiar!";
            // 
            // richTextBox1
            // 
            this.richTextBox1.BackColor = System.Drawing.Color.Black;
            this.richTextBox1.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.richTextBox1.ForeColor = System.Drawing.Color.White;
            this.richTextBox1.Location = new System.Drawing.Point(16, 30);
            this.richTextBox1.Name = "richTextBox1";
            this.richTextBox1.Size = new System.Drawing.Size(254, 106);
            this.richTextBox1.TabIndex = 6;
            this.richTextBox1.Text = "Una vez registrados los familiares, presionar clic izquierdo sobre el miembro \"or" +
    "igen\". Luego, clic derecho sobre el miembro \"destino\" para asignar la relación.";
            // 
            // groupBox2
            // 
            this.groupBox2.Controls.Add(this.btnGenerarArbol);
            this.groupBox2.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.groupBox2.ForeColor = System.Drawing.Color.White;
            this.groupBox2.Location = new System.Drawing.Point(1053, 291);
            this.groupBox2.Name = "groupBox2";
            this.groupBox2.Size = new System.Drawing.Size(287, 95);
            this.groupBox2.TabIndex = 8;
            this.groupBox2.TabStop = false;
            this.groupBox2.Text = "Visualizar el árbol genealógico";
            // 
            // btnGenerarArbol
            // 
            this.btnGenerarArbol.ForeColor = System.Drawing.Color.Black;
            this.btnGenerarArbol.Location = new System.Drawing.Point(76, 45);
            this.btnGenerarArbol.Name = "btnGenerarArbol";
            this.btnGenerarArbol.Size = new System.Drawing.Size(120, 28);
            this.btnGenerarArbol.TabIndex = 10;
            this.btnGenerarArbol.Text = "Generar árbol";
            this.btnGenerarArbol.UseVisualStyleBackColor = true;
            this.btnGenerarArbol.Click += new System.EventHandler(this.btnGenerarArbol_Click_1);
            // 
            // pictureBox1
            // 
            this.pictureBox1.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.pictureBox1.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Center;
            this.pictureBox1.Image = global::WindowsFormsApp1.Properties.Resources.ImagenArbol;
            this.pictureBox1.Location = new System.Drawing.Point(1053, 417);
            this.pictureBox1.Name = "pictureBox1";
            this.pictureBox1.Size = new System.Drawing.Size(287, 290);
            this.pictureBox1.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage;
            this.pictureBox1.TabIndex = 9;
            this.pictureBox1.TabStop = false;
            this.pictureBox1.Click += new System.EventHandler(this.pictureBox1_Click);
            // 
            // FormMapa
            // 
            this.BackColor = System.Drawing.Color.Black;
            this.ClientSize = new System.Drawing.Size(1381, 719);
            this.Controls.Add(this.pictureBox1);
            this.Controls.Add(this.groupBox2);
            this.Controls.Add(this.groupBox1);
            this.Controls.Add(this.groupBoxStats);
            this.Controls.Add(this.gMapControl1);
            this.Name = "FormMapa";
            this.Text = "Mapa Interactivo";
            this.groupBoxStats.ResumeLayout(false);
            this.groupBoxStats.PerformLayout();
            this.groupBox1.ResumeLayout(false);
            this.groupBox2.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private GMap.NET.WindowsForms.GMapControl gMapControl1;
        private System.Windows.Forms.GroupBox groupBoxStats;
        private System.Windows.Forms.Label lblMaxDist;
        private System.Windows.Forms.Label lblMinDist;
        private System.Windows.Forms.Label labelStats;
        private System.Windows.Forms.Label lblPromDist;
        private System.Windows.Forms.Label labelDistancia;
        private System.Windows.Forms.GroupBox groupBox1;
        private System.Windows.Forms.RichTextBox richTextBox1;
        private System.Windows.Forms.GroupBox groupBox2;
        private System.Windows.Forms.Button btnGenerarArbol;
        private System.Windows.Forms.PictureBox pictureBox1;
    }
}
