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
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.ZoomSlider)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.brightnessControl)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.EditedImage)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.minimumRadius)).BeginInit();
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
            this.ZoomSlider.Location = new System.Drawing.Point(595, 394);
            this.ZoomSlider.Name = "ZoomSlider";
            this.ZoomSlider.Size = new System.Drawing.Size(250, 45);
            this.ZoomSlider.TabIndex = 2;
            this.ZoomSlider.Scroll += new System.EventHandler(this.ZoomSlider_Scroll);
            // 
            // brightnessControl
            // 
            this.brightnessControl.Location = new System.Drawing.Point(12, 412);
            this.brightnessControl.Name = "brightnessControl";
            this.brightnessControl.Size = new System.Drawing.Size(250, 45);
            this.brightnessControl.TabIndex = 3;
            this.brightnessControl.Scroll += new System.EventHandler(this.brightnessControl_Scroll);
            // 
            // EditedImage
            // 
            this.EditedImage.Location = new System.Drawing.Point(451, 12);
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
            this.minimumRadius.Location = new System.Drawing.Point(621, 343);
            this.minimumRadius.Name = "minimumRadius";
            this.minimumRadius.Size = new System.Drawing.Size(224, 45);
            this.minimumRadius.TabIndex = 5;
            this.minimumRadius.Scroll += new System.EventHandler(this.minimumRadius_Scroll);
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.AutoScroll = true;
            this.AutoSize = true;
            this.ClientSize = new System.Drawing.Size(865, 463);
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
    }
}

