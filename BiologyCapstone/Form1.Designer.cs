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
            this.numberOfSpots = new System.Windows.Forms.RichTextBox();
            this.Count = new System.Windows.Forms.Button();
            this.minimumRadius = new System.Windows.Forms.TrackBar();
            this.radiusControl = new System.Windows.Forms.TrackBar();
            this.Maximize = new System.Windows.Forms.Label();
            this.Minimize = new System.Windows.Forms.Label();
            this.Zoom = new System.Windows.Forms.Label();
            this.Brightness = new System.Windows.Forms.Label();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.ZoomSlider)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.brightnessControl)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.EditedImage)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.minimumRadius)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.radiusControl)).BeginInit();
            this.SuspendLayout();
            // 
            // pictureBox1
            // 
            this.pictureBox1.Location = new System.Drawing.Point(12, 12);
            this.pictureBox1.Name = "pictureBox1";
            this.pictureBox1.Size = new System.Drawing.Size(402, 315);
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
            this.EditedImage.Location = new System.Drawing.Point(490, 32);
            this.EditedImage.Name = "EditedImage";
            this.EditedImage.Size = new System.Drawing.Size(402, 315);
            this.EditedImage.TabIndex = 4;
            this.EditedImage.TabStop = false;
            this.EditedImage.Click += new System.EventHandler(this.EditedImage_Click);
            // 
            // numberOfSpots
            // 
            this.numberOfSpots.Location = new System.Drawing.Point(385, 358);
            this.numberOfSpots.Name = "numberOfSpots";
            this.numberOfSpots.Size = new System.Drawing.Size(113, 30);
            this.numberOfSpots.TabIndex = 6;
            this.numberOfSpots.Text = "";
            this.numberOfSpots.TextChanged += new System.EventHandler(this.numberOfSpots_TextChanged);
            // 
            // Count
            // 
            this.Count.Location = new System.Drawing.Point(400, 412);
            this.Count.Name = "Count";
            this.Count.Size = new System.Drawing.Size(75, 23);
            this.Count.TabIndex = 7;
            this.Count.Text = "Count";
            this.Count.UseVisualStyleBackColor = true;
            this.Count.Click += new System.EventHandler(this.Count_Click);
            // 
            // minimumRadius
            // 
            this.minimumRadius.Location = new System.Drawing.Point(12, 441);
            this.minimumRadius.Name = "minimumRadius";
            this.minimumRadius.Size = new System.Drawing.Size(224, 45);
            this.minimumRadius.TabIndex = 5;
            this.minimumRadius.Scroll += new System.EventHandler(this.minimumRadius_Scroll);
            // 
            // radiusControl
            // 
            this.radiusControl.Location = new System.Drawing.Point(12, 390);
            this.radiusControl.Name = "radiusControl";
            this.radiusControl.Size = new System.Drawing.Size(250, 45);
            this.radiusControl.TabIndex = 8;
            this.radiusControl.Scroll += new System.EventHandler(this.radiusControl_Scroll);
            // 
            // Maximize
            // 
            this.Maximize.AutoSize = true;
            this.Maximize.Location = new System.Drawing.Point(268, 390);
            this.Maximize.Name = "Maximize";
            this.Maximize.Size = new System.Drawing.Size(50, 13);
            this.Maximize.TabIndex = 9;
            this.Maximize.Text = "Maximize";
            // 
            // Minimize
            // 
            this.Minimize.AutoSize = true;
            this.Minimize.Location = new System.Drawing.Point(268, 446);
            this.Minimize.Name = "Minimize";
            this.Minimize.Size = new System.Drawing.Size(47, 13);
            this.Minimize.TabIndex = 10;
            this.Minimize.Text = "Minimize";
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
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.AutoScroll = true;
            this.AutoSize = true;
            this.ClientSize = new System.Drawing.Size(942, 503);
            this.Controls.Add(this.Brightness);
            this.Controls.Add(this.Zoom);
            this.Controls.Add(this.Minimize);
            this.Controls.Add(this.Maximize);
            this.Controls.Add(this.radiusControl);
            this.Controls.Add(this.Count);
            this.Controls.Add(this.numberOfSpots);
            this.Controls.Add(this.minimumRadius);
            this.Controls.Add(this.EditedImage);
            this.Controls.Add(this.brightnessControl);
            this.Controls.Add(this.ZoomSlider);
            this.Controls.Add(this.LoadImage);
            this.Controls.Add(this.pictureBox1);
            this.Name = "Form1";
            this.Text = "Form1";
            this.Load += new System.EventHandler(this.Form1_Load);
            this.Resize += new System.EventHandler(this.Form1_Resize_1);
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.ZoomSlider)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.brightnessControl)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.EditedImage)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.minimumRadius)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.radiusControl)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.PictureBox pictureBox1;
        private System.Windows.Forms.Button LoadImage;
        private System.Windows.Forms.TrackBar ZoomSlider;
        private System.Windows.Forms.TrackBar brightnessControl;
        private System.Windows.Forms.PictureBox EditedImage;
        private System.Windows.Forms.RichTextBox numberOfSpots;
        private System.Windows.Forms.Button Count;
        private System.Windows.Forms.TrackBar minimumRadius;
        private System.Windows.Forms.TrackBar radiusControl;
        private System.Windows.Forms.Label Maximize;
        private System.Windows.Forms.Label Minimize;
        private System.Windows.Forms.Label Zoom;
        private System.Windows.Forms.Label Brightness;
    }
}

