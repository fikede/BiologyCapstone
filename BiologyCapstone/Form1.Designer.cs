namespace BiologyCapstone
{
    partial class Form1
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
            this.pictureBox1 = new System.Windows.Forms.PictureBox();
            this.LoadImage = new System.Windows.Forms.Button();
            this.ZoomSlider = new System.Windows.Forms.TrackBar();
            this.brightnessControl = new System.Windows.Forms.TrackBar();
            this.EditedImage = new System.Windows.Forms.PictureBox();
            this.Count = new System.Windows.Forms.Button();
            this.minimumRadius = new System.Windows.Forms.TrackBar();
            this.maximumRadius = new System.Windows.Forms.TrackBar();
            this.MaxRadius = new System.Windows.Forms.Label();
            this.MinRadius = new System.Windows.Forms.Label();
            this.Zoom = new System.Windows.Forms.Label();
            this.Brightness = new System.Windows.Forms.Label();
            this.countByRadius = new System.Windows.Forms.Label();
            this.minimumSize = new System.Windows.Forms.PictureBox();
            this.maximumSize = new System.Windows.Forms.PictureBox();
            this.displayText = new System.Windows.Forms.CheckBox();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.ZoomSlider)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.brightnessControl)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.EditedImage)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.minimumRadius)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.maximumRadius)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.minimumSize)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.maximumSize)).BeginInit();
            this.SuspendLayout();
            // 
            // pictureBox1
            // 
            this.pictureBox1.Location = new System.Drawing.Point(12, 12);
            this.pictureBox1.Name = "pictureBox1";
            this.pictureBox1.Size = new System.Drawing.Size(413, 315);
            this.pictureBox1.TabIndex = 0;
            this.pictureBox1.TabStop = false;
            // 
            // LoadImage
            // 
            this.LoadImage.Location = new System.Drawing.Point(12, 343);
            this.LoadImage.Name = "LoadImage";
            this.LoadImage.Size = new System.Drawing.Size(99, 39);
            this.LoadImage.TabIndex = 1;
            this.LoadImage.Text = "LoadImage";
            this.LoadImage.UseVisualStyleBackColor = true;
            this.LoadImage.Click += new System.EventHandler(this.LoadImage_Click);
            // 
            // ZoomSlider
            // 
            this.ZoomSlider.Location = new System.Drawing.Point(642, 374);
            this.ZoomSlider.Name = "ZoomSlider";
            this.ZoomSlider.Size = new System.Drawing.Size(250, 45);
            this.ZoomSlider.TabIndex = 2;
            this.ZoomSlider.Scroll += new System.EventHandler(this.ZoomSlider_Scroll);
            // 
            // brightnessControl
            // 
            this.brightnessControl.Location = new System.Drawing.Point(642, 446);
            this.brightnessControl.Name = "brightnessControl";
            this.brightnessControl.Size = new System.Drawing.Size(250, 45);
            this.brightnessControl.TabIndex = 3;
            this.brightnessControl.Scroll += new System.EventHandler(this.brightnessControl_Scroll);
            // 
            // EditedImage
            // 
            this.EditedImage.Anchor = System.Windows.Forms.AnchorStyles.None;
            this.EditedImage.Location = new System.Drawing.Point(513, 12);
            this.EditedImage.Name = "EditedImage";
            this.EditedImage.Size = new System.Drawing.Size(445, 315);
            this.EditedImage.TabIndex = 4;
            this.EditedImage.TabStop = false;
            this.EditedImage.Click += new System.EventHandler(this.EditedImage_Click);
            // 
            // Count
            // 
            this.Count.Location = new System.Drawing.Point(461, 405);
            this.Count.Name = "Count";
            this.Count.Size = new System.Drawing.Size(110, 23);
            this.Count.TabIndex = 7;
            this.Count.Text = "Count";
            this.Count.UseVisualStyleBackColor = true;
            this.Count.Click += new System.EventHandler(this.Count_Click);
            // 
            // minimumRadius
            // 
            this.minimumRadius.Location = new System.Drawing.Point(149, 439);
            this.minimumRadius.Name = "minimumRadius";
            this.minimumRadius.Size = new System.Drawing.Size(224, 45);
            this.minimumRadius.TabIndex = 5;
            this.minimumRadius.Scroll += new System.EventHandler(this.minimumRadius_Scroll);
            // 
            // maximumRadius
            // 
            this.maximumRadius.Location = new System.Drawing.Point(149, 383);
            this.maximumRadius.Name = "maximumRadius";
            this.maximumRadius.Size = new System.Drawing.Size(235, 45);
            this.maximumRadius.TabIndex = 8;
            this.maximumRadius.Scroll += new System.EventHandler(this.radiusControl_Scroll);
            // 
            // MaxRadius
            // 
            this.MaxRadius.AutoSize = true;
            this.MaxRadius.Location = new System.Drawing.Point(390, 388);
            this.MaxRadius.Name = "MaxRadius";
            this.MaxRadius.Size = new System.Drawing.Size(50, 13);
            this.MaxRadius.TabIndex = 9;
            this.MaxRadius.Text = "Max Size";
            // 
            // MinRadius
            // 
            this.MinRadius.AutoSize = true;
            this.MinRadius.Location = new System.Drawing.Point(393, 446);
            this.MinRadius.Name = "MinRadius";
            this.MinRadius.Size = new System.Drawing.Size(47, 13);
            this.MinRadius.TabIndex = 10;
            this.MinRadius.Text = "Min Size";
            // 
            // Zoom
            // 
            this.Zoom.AutoSize = true;
            this.Zoom.Location = new System.Drawing.Point(599, 390);
            this.Zoom.Name = "Zoom";
            this.Zoom.Size = new System.Drawing.Size(34, 13);
            this.Zoom.TabIndex = 11;
            this.Zoom.Text = "Zoom";
            // 
            // Brightness
            // 
            this.Brightness.AutoSize = true;
            this.Brightness.Location = new System.Drawing.Point(577, 455);
            this.Brightness.Name = "Brightness";
            this.Brightness.Size = new System.Drawing.Size(56, 13);
            this.Brightness.TabIndex = 12;
            this.Brightness.Text = "Brightness";
            // 
            // countByRadius
            // 
            this.countByRadius.AutoSize = true;
            this.countByRadius.Location = new System.Drawing.Point(460, 383);
            this.countByRadius.Name = "countByRadius";
            this.countByRadius.Size = new System.Drawing.Size(79, 13);
            this.countByRadius.TabIndex = 16;
            this.countByRadius.Text = "countByRadius";
            // 
            // minimumSize
            // 
            this.minimumSize.Location = new System.Drawing.Point(12, 441);
            this.minimumSize.Name = "minimumSize";
            this.minimumSize.Size = new System.Drawing.Size(100, 50);
            this.minimumSize.TabIndex = 17;
            this.minimumSize.TabStop = false;
            // 
            // maximumSize
            // 
            this.maximumSize.Location = new System.Drawing.Point(12, 383);
            this.maximumSize.Name = "maximumSize";
            this.maximumSize.Size = new System.Drawing.Size(100, 50);
            this.maximumSize.TabIndex = 18;
            this.maximumSize.TabStop = false;
            // 
            // displayText
            // 
            this.displayText.AutoSize = true;
            this.displayText.Checked = true;
            this.displayText.CheckState = System.Windows.Forms.CheckState.Checked;
            this.displayText.Location = new System.Drawing.Point(672, 343);
            this.displayText.Name = "displayText";
            this.displayText.Size = new System.Drawing.Size(84, 17);
            this.displayText.TabIndex = 19;
            this.displayText.Text = "Display Text";
            this.displayText.UseVisualStyleBackColor = true;
            this.displayText.CheckedChanged += new System.EventHandler(this.displayText_CheckedChanged);
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.AutoScroll = true;
            this.AutoSize = true;
            this.ClientSize = new System.Drawing.Size(970, 502);
            this.Controls.Add(this.displayText);
            this.Controls.Add(this.maximumSize);
            this.Controls.Add(this.minimumSize);
            this.Controls.Add(this.countByRadius);
            this.Controls.Add(this.Brightness);
            this.Controls.Add(this.Zoom);
            this.Controls.Add(this.MinRadius);
            this.Controls.Add(this.MaxRadius);
            this.Controls.Add(this.maximumRadius);
            this.Controls.Add(this.Count);
            this.Controls.Add(this.minimumRadius);
            this.Controls.Add(this.EditedImage);
            this.Controls.Add(this.brightnessControl);
            this.Controls.Add(this.ZoomSlider);
            this.Controls.Add(this.LoadImage);
            this.Controls.Add(this.pictureBox1);
            this.Name = "Form1";
            this.Text = "Form1";
            this.Load += new System.EventHandler(this.Form1_Load);
            this.SizeChanged += new System.EventHandler(this.Form1_SizeChanged);
            this.Resize += new System.EventHandler(this.Form1_Resize_1);
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.ZoomSlider)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.brightnessControl)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.EditedImage)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.minimumRadius)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.maximumRadius)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.minimumSize)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.maximumSize)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.PictureBox pictureBox1;
        private System.Windows.Forms.Button LoadImage;
        private System.Windows.Forms.TrackBar ZoomSlider;
        private System.Windows.Forms.TrackBar brightnessControl;
        private System.Windows.Forms.PictureBox EditedImage;
        private System.Windows.Forms.Button Count;
        private System.Windows.Forms.TrackBar minimumRadius;
        private System.Windows.Forms.TrackBar maximumRadius;
        private System.Windows.Forms.Label MaxRadius;
        private System.Windows.Forms.Label MinRadius;
        private System.Windows.Forms.Label Zoom;
        private System.Windows.Forms.Label Brightness;
        private System.Windows.Forms.Label countByRadius;
        private System.Windows.Forms.PictureBox minimumSize;
        private System.Windows.Forms.PictureBox maximumSize;
        private System.Windows.Forms.CheckBox displayText;
    }
}

