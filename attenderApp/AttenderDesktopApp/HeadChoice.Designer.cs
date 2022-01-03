namespace AttenderDesktopApp
{
    partial class HeadChoice
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
            this.lecturer = new System.Windows.Forms.Button();
            this.admin = new System.Windows.Forms.Button();
            this.SuspendLayout();
            // 
            // lecturer
            // 
            this.lecturer.Location = new System.Drawing.Point(61, 70);
            this.lecturer.Name = "lecturer";
            this.lecturer.Size = new System.Drawing.Size(157, 45);
            this.lecturer.TabIndex = 0;
            this.lecturer.Text = "Continue as lecturer";
            this.lecturer.UseVisualStyleBackColor = true;
            this.lecturer.Click += new System.EventHandler(this.lecturer_Click);
            // 
            // admin
            // 
            this.admin.Location = new System.Drawing.Point(61, 137);
            this.admin.Name = "admin";
            this.admin.Size = new System.Drawing.Size(157, 44);
            this.admin.TabIndex = 1;
            this.admin.Text = "Continue as admin";
            this.admin.UseVisualStyleBackColor = true;
            this.admin.Click += new System.EventHandler(this.admin_Click);
            // 
            // HeadChoice
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(284, 261);
            this.Controls.Add(this.admin);
            this.Controls.Add(this.lecturer);
            this.Name = "HeadChoice";
            this.Text = "HeadChoice";
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Button lecturer;
        private System.Windows.Forms.Button admin;
    }
}