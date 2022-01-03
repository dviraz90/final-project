namespace Virtual_wifi
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(Form1));
            this.pictureBox1 = new System.Windows.Forms.PictureBox();
            this.Play_Stop_button = new System.Windows.Forms.Button();
            this.Process_progressBar = new System.Windows.Forms.ProgressBar();
            this.label3 = new System.Windows.Forms.Label();
            this.button_panel = new System.Windows.Forms.Panel();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).BeginInit();
            this.button_panel.SuspendLayout();
            this.SuspendLayout();
            // 
            // pictureBox1
            // 
            this.pictureBox1.Image = ((System.Drawing.Image)(resources.GetObject("pictureBox1.Image")));
            this.pictureBox1.Location = new System.Drawing.Point(17, 1);
            this.pictureBox1.Name = "pictureBox1";
            this.pictureBox1.Size = new System.Drawing.Size(100, 118);
            this.pictureBox1.TabIndex = 0;
            this.pictureBox1.TabStop = false;
            // 
            // Play_Stop_button
            // 
            this.Play_Stop_button.Font = new System.Drawing.Font("Microsoft Sans Serif", 15F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.Play_Stop_button.Location = new System.Drawing.Point(25, 125);
            this.Play_Stop_button.Name = "Play_Stop_button";
            this.Play_Stop_button.Size = new System.Drawing.Size(88, 43);
            this.Play_Stop_button.TabIndex = 1;
            this.Play_Stop_button.Text = "Start";
            this.Play_Stop_button.UseVisualStyleBackColor = true;
            this.Play_Stop_button.Click += new System.EventHandler(this.button1_Click);
            // 
            // Process_progressBar
            // 
            this.Process_progressBar.Location = new System.Drawing.Point(20, 37);
            this.Process_progressBar.Name = "Process_progressBar";
            this.Process_progressBar.Size = new System.Drawing.Size(104, 45);
            this.Process_progressBar.TabIndex = 5;
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Font = new System.Drawing.Font("Microsoft Sans Serif", 15F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label3.Location = new System.Drawing.Point(27, 9);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(97, 25);
            this.label3.TabIndex = 6;
            this.label3.Text = "Loading...";
            this.label3.Click += new System.EventHandler(this.label3_Click);
            // 
            // button_panel
            // 
            this.button_panel.Controls.Add(this.Play_Stop_button);
            this.button_panel.Controls.Add(this.pictureBox1);
            this.button_panel.Location = new System.Drawing.Point(7, 3);
            this.button_panel.Name = "button_panel";
            this.button_panel.Size = new System.Drawing.Size(134, 177);
            this.button_panel.TabIndex = 4;
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(154, 187);
            this.Controls.Add(this.button_panel);
            this.Controls.Add(this.Process_progressBar);
            this.Controls.Add(this.label3);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle;
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.Name = "Form1";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Virtual Wifi";
            this.Load += new System.EventHandler(this.Form1_Load);
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).EndInit();
            this.button_panel.ResumeLayout(false);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.PictureBox pictureBox1;
        private System.Windows.Forms.Button Play_Stop_button;
        private System.Windows.Forms.ProgressBar Process_progressBar;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Panel button_panel;
    }
}

