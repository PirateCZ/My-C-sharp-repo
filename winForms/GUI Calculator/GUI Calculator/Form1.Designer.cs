namespace GUI_Calculator
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
            this.lang = new System.Windows.Forms.ComboBox();
            this.confirmLang = new System.Windows.Forms.Button();
            this.label1 = new System.Windows.Forms.Label();
            this.remember = new System.Windows.Forms.CheckBox();
            this.SuspendLayout();
            // 
            // lang
            // 
            this.lang.FormattingEnabled = true;
            this.lang.Items.AddRange(new object[] {
            "cz",
            "en"});
            this.lang.Location = new System.Drawing.Point(182, 201);
            this.lang.Name = "lang";
            this.lang.Size = new System.Drawing.Size(100, 24);
            this.lang.TabIndex = 0;
            // 
            // confirmLang
            // 
            this.confirmLang.Location = new System.Drawing.Point(395, 418);
            this.confirmLang.Name = "confirmLang";
            this.confirmLang.Size = new System.Drawing.Size(75, 23);
            this.confirmLang.TabIndex = 1;
            this.confirmLang.Text = "Confirm";
            this.confirmLang.UseVisualStyleBackColor = true;
            this.confirmLang.Click += new System.EventHandler(this.confirmLang_Click);
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(182, 179);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(118, 16);
            this.label1.TabIndex = 2;
            this.label1.Text = "Choose Language";
            // 
            // remember
            // 
            this.remember.AutoSize = true;
            this.remember.Location = new System.Drawing.Point(292, 420);
            this.remember.Name = "remember";
            this.remember.Size = new System.Drawing.Size(97, 20);
            this.remember.TabIndex = 3;
            this.remember.Text = "Remember";
            this.remember.UseVisualStyleBackColor = true;
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(482, 453);
            this.Controls.Add(this.remember);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.confirmLang);
            this.Controls.Add(this.lang);
            this.Name = "Form1";
            this.Text = "Choose Language";
            this.Load += new System.EventHandler(this.Form1_Load);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.ComboBox lang;
        private System.Windows.Forms.Button confirmLang;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.CheckBox remember;
    }
}

