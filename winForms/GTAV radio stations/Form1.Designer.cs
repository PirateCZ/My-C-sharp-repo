namespace GTAV_radio_stations
{
    partial class mediaPlayer
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(mediaPlayer));
            this.radioLogo = new System.Windows.Forms.PictureBox();
            this.volumeSlider = new System.Windows.Forms.TrackBar();
            ((System.ComponentModel.ISupportInitialize)(this.radioLogo)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.volumeSlider)).BeginInit();
            this.SuspendLayout();
            // 
            // radioLogo
            // 
            this.radioLogo.Image = ((System.Drawing.Image)(resources.GetObject("radioLogo.Image")));
            this.radioLogo.Location = new System.Drawing.Point(12, 12);
            this.radioLogo.Name = "radioLogo";
            this.radioLogo.Size = new System.Drawing.Size(300, 300);
            this.radioLogo.TabIndex = 0;
            this.radioLogo.TabStop = false;
            // 
            // volumeSlider
            // 
            this.volumeSlider.Cursor = System.Windows.Forms.Cursors.SizeWE;
            this.volumeSlider.Location = new System.Drawing.Point(12, 318);
            this.volumeSlider.Maximum = 100;
            this.volumeSlider.Name = "volumeSlider";
            this.volumeSlider.Size = new System.Drawing.Size(300, 45);
            this.volumeSlider.TabIndex = 1;
            this.volumeSlider.Value = 10;
            this.volumeSlider.Scroll += new System.EventHandler(this.volumeSlider_Scroll);
            // 
            // mediaPlayer
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.AutoValidate = System.Windows.Forms.AutoValidate.EnablePreventFocusChange;
            this.BackColor = System.Drawing.SystemColors.Control;
            this.BackgroundImageLayout = System.Windows.Forms.ImageLayout.None;
            this.ClientSize = new System.Drawing.Size(324, 411);
            this.Controls.Add(this.volumeSlider);
            this.Controls.Add(this.radioLogo);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle;
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.ImeMode = System.Windows.Forms.ImeMode.NoControl;
            this.MaximizeBox = false;
            this.MaximumSize = new System.Drawing.Size(340, 450);
            this.MinimumSize = new System.Drawing.Size(340, 450);
            this.Name = "mediaPlayer";
            this.Text = "GTAV Radio Stations";
            ((System.ComponentModel.ISupportInitialize)(this.radioLogo)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.volumeSlider)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.PictureBox radioLogo;
        private System.Windows.Forms.TrackBar volumeSlider;
    }
}

