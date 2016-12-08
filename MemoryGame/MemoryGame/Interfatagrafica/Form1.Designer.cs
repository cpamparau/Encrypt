namespace Interfatagrafica
{
    partial  class Form1
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
            this.components = new System.ComponentModel.Container();
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(Form1));
            this.Button2 = new System.Windows.Forms.Button();
            this.Button3 = new System.Windows.Forms.Button();
            this.Button4 = new System.Windows.Forms.Button();
            this.Button5 = new System.Windows.Forms.Button();
            this.Minion = new System.Windows.Forms.ImageList(this.components);
            this.PictureBox1 = new System.Windows.Forms.PictureBox();
            this.Button1 = new System.Windows.Forms.Button();
            this.Geometry = new System.Windows.Forms.ImageList(this.components);
            this.Easter = new System.Windows.Forms.ImageList(this.components);
            Form1.Timer1 = new System.Windows.Forms.Timer(this.components);
            ((System.ComponentModel.ISupportInitialize)(this.PictureBox1)).BeginInit();
            this.SuspendLayout();
            // 
            // Button2
            // 
            this.Button2.BackgroundImage = global::Interfatagrafica.Properties.Resources.easter1;
            this.Button2.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.Button2.Cursor = System.Windows.Forms.Cursors.Hand;
            this.Button2.Font = new System.Drawing.Font("Monotype Corsiva", 15.75F, ((System.Drawing.FontStyle)((System.Drawing.FontStyle.Bold | System.Drawing.FontStyle.Italic))));
            this.Button2.Location = new System.Drawing.Point(329, 148);
            this.Button2.Name = "Button2";
            this.Button2.Size = new System.Drawing.Size(144, 81);
            this.Button2.TabIndex = 2;
            this.Button2.Text = "Easter Match";
            this.Button2.UseVisualStyleBackColor = true;
            this.Button2.Click += new System.EventHandler(this.Button2_Click);
            // 
            // Button3
            // 
            this.Button3.BackgroundImage = global::Interfatagrafica.Properties.Resources.geometry;
            this.Button3.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.Button3.Cursor = System.Windows.Forms.Cursors.Hand;
            this.Button3.Font = new System.Drawing.Font("Monotype Corsiva", 15.75F, ((System.Drawing.FontStyle)((System.Drawing.FontStyle.Bold | System.Drawing.FontStyle.Italic))));
            this.Button3.Location = new System.Drawing.Point(329, 250);
            this.Button3.Name = "Button3";
            this.Button3.Size = new System.Drawing.Size(144, 80);
            this.Button3.TabIndex = 3;
            this.Button3.Text = "Geometric Shape Match";
            this.Button3.UseVisualStyleBackColor = true;
            this.Button3.Click += new System.EventHandler(this.Button3_Click);
            // 
            // Button4
            // 
            this.Button4.BackColor = System.Drawing.Color.SpringGreen;
            this.Button4.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Center;
            this.Button4.Cursor = System.Windows.Forms.Cursors.Hand;
            this.Button4.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.Button4.Font = new System.Drawing.Font("Monotype Corsiva", 15.75F, ((System.Drawing.FontStyle)((System.Drawing.FontStyle.Bold | System.Drawing.FontStyle.Italic))), System.Drawing.GraphicsUnit.Point, ((byte)(238)));
            this.Button4.Location = new System.Drawing.Point(329, 359);
            this.Button4.Name = "Button4";
            this.Button4.Size = new System.Drawing.Size(144, 80);
            this.Button4.TabIndex = 5;
            this.Button4.Text = "Quit";
            this.Button4.UseVisualStyleBackColor = true;
            this.Button4.Click += new System.EventHandler(this.Button4_Click);
            // 
            // Button5
            // 
            this.Button5.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(0)))), ((int)(((byte)(244)))));
            this.Button5.Font = new System.Drawing.Font("Monotype Corsiva", 15.75F, ((System.Drawing.FontStyle)((System.Drawing.FontStyle.Bold | System.Drawing.FontStyle.Italic))), System.Drawing.GraphicsUnit.Point, ((byte)(238)));
            this.Button5.Location = new System.Drawing.Point(329, 469);
            this.Button5.Name = "Button5";
            this.Button5.Size = new System.Drawing.Size(144, 80);
            this.Button5.TabIndex = 6;
            this.Button5.Text = "Istoric";
            this.Button5.UseVisualStyleBackColor = false;
            this.Button5.Click += new System.EventHandler(this.Button5_Click);
            // 
            // Minion
            // 
            this.Minion.ImageStream = ((System.Windows.Forms.ImageListStreamer)(resources.GetObject("Minion.ImageStream")));
            this.Minion.TransparentColor = System.Drawing.Color.Transparent;
            this.Minion.Images.SetKeyName(0, "minion0.png");
            this.Minion.Images.SetKeyName(1, "minion1.png");
            this.Minion.Images.SetKeyName(2, "minion2.png");
            this.Minion.Images.SetKeyName(3, "minion3.png");
            this.Minion.Images.SetKeyName(4, "minion4.png");
            this.Minion.Images.SetKeyName(5, "minion5.png");
            this.Minion.Images.SetKeyName(6, "minion6.png");
            this.Minion.Images.SetKeyName(7, "minion7.png");
            this.Minion.Images.SetKeyName(8, "minion8.png");
            this.Minion.Images.SetKeyName(9, "minion9.png");
            this.Minion.Images.SetKeyName(10, "minion10.png");
            this.Minion.Images.SetKeyName(11, "minion11.png");
            this.Minion.Images.SetKeyName(12, "minion12.png");
            this.Minion.Images.SetKeyName(13, "minion13.png");
            this.Minion.Images.SetKeyName(14, "ask.png");
            // 
            // PictureBox1
            // 
            this.PictureBox1.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.PictureBox1.Image = ((System.Drawing.Image)(resources.GetObject("PictureBox1.Image")));
            this.PictureBox1.Location = new System.Drawing.Point(0, 469);
            this.PictureBox1.Name = "PictureBox1";
            this.PictureBox1.Size = new System.Drawing.Size(125, 95);
            this.PictureBox1.TabIndex = 7;
            this.PictureBox1.TabStop = false;
            // 
            // Button1
            // 
            this.Button1.BackColor = System.Drawing.Color.AliceBlue;
            this.Button1.BackgroundImage = global::Interfatagrafica.Properties.Resources.matchMinion11;
            this.Button1.Cursor = System.Windows.Forms.Cursors.Hand;
            this.Button1.Font = new System.Drawing.Font("Monotype Corsiva", 15.75F, ((System.Drawing.FontStyle)((System.Drawing.FontStyle.Bold | System.Drawing.FontStyle.Italic))));
            this.Button1.ForeColor = System.Drawing.SystemColors.MenuText;
            this.Button1.Location = new System.Drawing.Point(329, 46);
            this.Button1.Name = "Button1";
            this.Button1.Size = new System.Drawing.Size(144, 83);
            this.Button1.TabIndex = 1;
            this.Button1.Text = "Match Minion";
            this.Button1.UseVisualStyleBackColor = true;
            this.Button1.Click += new System.EventHandler(this.Button1_Click);
            // 
            // Geometry
            // 
            this.Geometry.ImageStream = ((System.Windows.Forms.ImageListStreamer)(resources.GetObject("Geometry.ImageStream")));
            this.Geometry.TransparentColor = System.Drawing.Color.Transparent;
            this.Geometry.Images.SetKeyName(0, "cerc.png");
            this.Geometry.Images.SetKeyName(1, "hexagon.png");
            this.Geometry.Images.SetKeyName(2, "nonagon.png");
            this.Geometry.Images.SetKeyName(3, "octagon.png");
            this.Geometry.Images.SetKeyName(4, "pentagon.png");
            this.Geometry.Images.SetKeyName(5, "rectangle.png");
            this.Geometry.Images.SetKeyName(6, "romb.png");
            this.Geometry.Images.SetKeyName(7, "triangle.png");
            this.Geometry.Images.SetKeyName(8, "square.png");
            this.Geometry.Images.SetKeyName(9, "septagon.png");
            this.Geometry.Images.SetKeyName(10, "cub.png");
            this.Geometry.Images.SetKeyName(11, "box.png");
            this.Geometry.Images.SetKeyName(12, "decagon.png");
            this.Geometry.Images.SetKeyName(13, "sphere.png");
            this.Geometry.Images.SetKeyName(14, "ask.png");
            // 
            // Easter
            // 
            this.Easter.ImageStream = ((System.Windows.Forms.ImageListStreamer)(resources.GetObject("Easter.ImageStream")));
            this.Easter.TransparentColor = System.Drawing.Color.Transparent;
            this.Easter.Images.SetKeyName(0, "egg0.png");
            this.Easter.Images.SetKeyName(1, "egg1.png");
            this.Easter.Images.SetKeyName(2, "egg2.png");
            this.Easter.Images.SetKeyName(3, "egg3.png");
            this.Easter.Images.SetKeyName(4, "egg4.png");
            this.Easter.Images.SetKeyName(5, "egg5.png");
            this.Easter.Images.SetKeyName(6, "egg6.png");
            this.Easter.Images.SetKeyName(7, "egg7.png");
            this.Easter.Images.SetKeyName(8, "egg8.png");
            this.Easter.Images.SetKeyName(9, "egg9.png");
            this.Easter.Images.SetKeyName(10, "egg10.png");
            this.Easter.Images.SetKeyName(11, "egg11.png");
            this.Easter.Images.SetKeyName(12, "egg12.png");
            this.Easter.Images.SetKeyName(13, "egg13.png");
            this.Easter.Images.SetKeyName(14, "ask.png");
            // 
            // Timer1
            // 
            Form1.Timer1.Enabled = true;
            Form1.Timer1.Interval = 1000;
            Form1.Timer1.Tick += new System.EventHandler(this.Timer1_Tick);
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.AutoSize = true;
            this.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(10)))), ((int)(((byte)(152)))), ((int)(((byte)(102)))));
            this.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.ClientSize = new System.Drawing.Size(984, 562);
            this.Controls.Add(this.PictureBox1);
            this.Controls.Add(this.Button5);
            this.Controls.Add(this.Button4);
            this.Controls.Add(this.Button3);
            this.Controls.Add(this.Button2);
            this.Controls.Add(this.Button1);
            this.DoubleBuffered = true;
            this.MaximizeBox = false;
            this.Name = "Form1";
            this.Text = "Joc de Memorie";
            this.Load += new System.EventHandler(this.Form1_Load);
            ((System.ComponentModel.ISupportInitialize)(this.PictureBox1)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Button Button1;
        private System.Windows.Forms.Button Button2;
        private System.Windows.Forms.Button Button3;
        private System.Windows.Forms.Button Button4;
        internal System.Windows.Forms.Button Button5;
        internal System.Windows.Forms.PictureBox PictureBox1;
        public System.Windows.Forms.ImageList Minion;
        public System.Windows.Forms.ImageList Geometry;
        public System.Windows.Forms.ImageList Easter;
        static internal System.Windows.Forms.Timer Timer1;
    }
}

