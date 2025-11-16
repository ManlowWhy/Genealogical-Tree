namespace MapaTest
{
    partial class FormPrincipal
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(FormPrincipal));
            this.labelPrincipal1 = new System.Windows.Forms.Label();
            this.pictureBoxImagenArbol = new System.Windows.Forms.PictureBox();
            this.groupBoxPrincipal = new System.Windows.Forms.GroupBox();
            this.richTextBoxPrincipal = new System.Windows.Forms.RichTextBox();
            this.buttonPrincipal = new System.Windows.Forms.Button();
            this.labelPrincipal = new System.Windows.Forms.Label();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBoxImagenArbol)).BeginInit();
            this.groupBoxPrincipal.SuspendLayout();
            this.SuspendLayout();
            // 
            // labelPrincipal1
            // 
            this.labelPrincipal1.AutoSize = true;
            this.labelPrincipal1.Font = new System.Drawing.Font("Arial Rounded MT Bold", 20.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.labelPrincipal1.Location = new System.Drawing.Point(463, 188);
            this.labelPrincipal1.Name = "labelPrincipal1";
            this.labelPrincipal1.Size = new System.Drawing.Size(0, 32);
            this.labelPrincipal1.TabIndex = 2;
            // 
            // pictureBoxImagenArbol
            // 
            this.pictureBoxImagenArbol.BackColor = System.Drawing.Color.Transparent;
            this.pictureBoxImagenArbol.BackgroundImage = global::WindowsFormsApp1.Properties.Resources.ImagenArbol;
            this.pictureBoxImagenArbol.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.pictureBoxImagenArbol.Location = new System.Drawing.Point(36, 53);
            this.pictureBoxImagenArbol.Name = "pictureBoxImagenArbol";
            this.pictureBoxImagenArbol.Size = new System.Drawing.Size(451, 364);
            this.pictureBoxImagenArbol.TabIndex = 7;
            this.pictureBoxImagenArbol.TabStop = false;
            // 
            // groupBoxPrincipal
            // 
            this.groupBoxPrincipal.Controls.Add(this.richTextBoxPrincipal);
            this.groupBoxPrincipal.Font = new System.Drawing.Font("Arial Rounded MT Bold", 14.25F, System.Drawing.FontStyle.Bold);
            this.groupBoxPrincipal.Location = new System.Drawing.Point(507, 113);
            this.groupBoxPrincipal.Name = "groupBoxPrincipal";
            this.groupBoxPrincipal.Size = new System.Drawing.Size(502, 222);
            this.groupBoxPrincipal.TabIndex = 8;
            this.groupBoxPrincipal.TabStop = false;
            this.groupBoxPrincipal.Text = "Instrucciones:";
            // 
            // richTextBoxPrincipal
            // 
            this.richTextBoxPrincipal.Font = new System.Drawing.Font("Arial Narrow", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.richTextBoxPrincipal.Location = new System.Drawing.Point(6, 28);
            this.richTextBoxPrincipal.Name = "richTextBoxPrincipal";
            this.richTextBoxPrincipal.ReadOnly = true;
            this.richTextBoxPrincipal.Size = new System.Drawing.Size(496, 172);
            this.richTextBoxPrincipal.TabIndex = 0;
            this.richTextBoxPrincipal.Text = resources.GetString("richTextBoxPrincipal.Text");
            // 
            // buttonPrincipal
            // 
            this.buttonPrincipal.Font = new System.Drawing.Font("Arial Rounded MT Bold", 8.25F);
            this.buttonPrincipal.Location = new System.Drawing.Point(721, 365);
            this.buttonPrincipal.Name = "buttonPrincipal";
            this.buttonPrincipal.Size = new System.Drawing.Size(75, 23);
            this.buttonPrincipal.TabIndex = 9;
            this.buttonPrincipal.Text = "Continuar";
            this.buttonPrincipal.UseVisualStyleBackColor = true;
            this.buttonPrincipal.Click += new System.EventHandler(this.buttonPrincipal_Click);
            // 
            // labelPrincipal
            // 
            this.labelPrincipal.AutoSize = true;
            this.labelPrincipal.Font = new System.Drawing.Font("Arial Rounded MT Bold", 20.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.labelPrincipal.Location = new System.Drawing.Point(121, 35);
            this.labelPrincipal.Name = "labelPrincipal";
            this.labelPrincipal.Size = new System.Drawing.Size(256, 32);
            this.labelPrincipal.TabIndex = 10;
            this.labelPrincipal.Text = "Árbol Genealógico";
            // 
            // FormPrincipal
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.Lavender;
            this.ClientSize = new System.Drawing.Size(1021, 450);
            this.Controls.Add(this.labelPrincipal);
            this.Controls.Add(this.buttonPrincipal);
            this.Controls.Add(this.groupBoxPrincipal);
            this.Controls.Add(this.pictureBoxImagenArbol);
            this.Controls.Add(this.labelPrincipal1);
            this.Name = "FormPrincipal";
            this.Text = "Árbol Genealógico";
            ((System.ComponentModel.ISupportInitialize)(this.pictureBoxImagenArbol)).EndInit();
            this.groupBoxPrincipal.ResumeLayout(false);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion
        private System.Windows.Forms.Label labelPrincipal1;
        private System.Windows.Forms.PictureBox pictureBoxImagenArbol;
        private System.Windows.Forms.GroupBox groupBoxPrincipal;
        private System.Windows.Forms.RichTextBox richTextBoxPrincipal;
        private System.Windows.Forms.Button buttonPrincipal;
        private System.Windows.Forms.Label labelPrincipal;
    }
}