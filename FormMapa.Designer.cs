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
            this.lblMinDist = new System.Windows.Forms.Label();
            this.lblMaxDist = new System.Windows.Forms.Label();
            this.labelStats = new System.Windows.Forms.Label();
            this.groupBoxStats.SuspendLayout();
            this.SuspendLayout();
            // 
            // gMapControl1
            // 
            this.gMapControl1.BackColor = System.Drawing.Color.Lavender;
            this.gMapControl1.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Zoom;
            this.gMapControl1.Bearing = 0F;
            this.gMapControl1.CanDragMap = true;
            this.gMapControl1.EmptyTileColor = System.Drawing.Color.Navy;
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
            this.gMapControl1.Size = new System.Drawing.Size(664, 522);
            this.gMapControl1.TabIndex = 0;
            this.gMapControl1.Zoom = 0D;
            this.gMapControl1.Load += new System.EventHandler(this.gMapControl1_Load_1);
            // 
            // groupBoxStats
            // 
            this.groupBoxStats.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.groupBoxStats.Controls.Add(this.labelStats);
            this.groupBoxStats.Controls.Add(this.lblMaxDist);
            this.groupBoxStats.Controls.Add(this.lblMinDist);
            this.groupBoxStats.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.groupBoxStats.Location = new System.Drawing.Point(12, 553);
            this.groupBoxStats.Name = "groupBoxStats";
            this.groupBoxStats.Size = new System.Drawing.Size(664, 154);
            this.groupBoxStats.TabIndex = 3;
            this.groupBoxStats.TabStop = false;
            this.groupBoxStats.Text = "Estadísticas";
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
            // lblMaxDist
            // 
            this.lblMaxDist.AutoSize = true;
            this.lblMaxDist.Location = new System.Drawing.Point(83, 113);
            this.lblMaxDist.Name = "lblMaxDist";
            this.lblMaxDist.Size = new System.Drawing.Size(54, 16);
            this.lblMaxDist.TabIndex = 3;
            this.lblMaxDist.Text = "Mayor:";
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
            // FormMapa
            // 
            this.BackColor = System.Drawing.Color.Lavender;
            this.ClientSize = new System.Drawing.Size(1102, 719);
            this.Controls.Add(this.groupBoxStats);
            this.Controls.Add(this.gMapControl1);
            this.Name = "FormMapa";
            this.Text = "Mapa Interactivo";
            this.groupBoxStats.ResumeLayout(false);
            this.groupBoxStats.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion

        private GMap.NET.WindowsForms.GMapControl gMapControl1;
        private System.Windows.Forms.GroupBox groupBoxStats;
        private System.Windows.Forms.Label lblMaxDist;
        private System.Windows.Forms.Label lblMinDist;
        private System.Windows.Forms.Label labelStats;
    }
}
