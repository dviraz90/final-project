namespace AttenderDesktopApp
{
    partial class MainPage
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(MainPage));
            this.Welcome = new System.Windows.Forms.Label();
            this.LessonsList = new System.Windows.Forms.Label();
            this.select = new System.Windows.Forms.Button();
            this.ListCurrentStudents = new System.Windows.Forms.ListBox();
            this.Current = new System.Windows.Forms.Label();
            this.Attended = new System.Windows.Forms.ListBox();
            this.label2 = new System.Windows.Forms.Label();
            this.AddManualy = new System.Windows.Forms.Button();
            this.proccess_bar = new System.Windows.Forms.ProgressBar();
            this.label3 = new System.Windows.Forms.Label();
            this.Play_Stop_button = new System.Windows.Forms.Button();
            this.pictureBox1 = new System.Windows.Forms.PictureBox();
            this.button_panel = new System.Windows.Forms.Panel();
            this.Disconnect = new System.Windows.Forms.Button();
            this.ContinueLecturer = new System.Windows.Forms.Button();
            this.courseList = new System.Windows.Forms.ListBox();
            this.label1 = new System.Windows.Forms.Label();
            this.details = new System.Windows.Forms.TabControl();
            this.tabPage1 = new System.Windows.Forms.TabPage();
            this.tabPage2 = new System.Windows.Forms.TabPage();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).BeginInit();
            this.button_panel.SuspendLayout();
            this.details.SuspendLayout();
            this.tabPage1.SuspendLayout();
            this.tabPage2.SuspendLayout();
            this.SuspendLayout();
            // 
            // Welcome
            // 
            this.Welcome.AutoSize = true;
            this.Welcome.Font = new System.Drawing.Font("Arial", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(177)));
            this.Welcome.Location = new System.Drawing.Point(21, 32);
            this.Welcome.Name = "Welcome";
            this.Welcome.Size = new System.Drawing.Size(51, 14);
            this.Welcome.TabIndex = 0;
            this.Welcome.Text = "Welcome";
            // 
            // LessonsList
            // 
            this.LessonsList.AutoSize = true;
            this.LessonsList.Location = new System.Drawing.Point(6, 20);
            this.LessonsList.Name = "LessonsList";
            this.LessonsList.Size = new System.Drawing.Size(73, 13);
            this.LessonsList.TabIndex = 2;
            this.LessonsList.Text = "Your Courses:";
            this.LessonsList.Click += new System.EventHandler(this.LessonsList_Click);
            // 
            // select
            // 
            this.select.Location = new System.Drawing.Point(57, 229);
            this.select.Margin = new System.Windows.Forms.Padding(2);
            this.select.Name = "select";
            this.select.Size = new System.Drawing.Size(92, 50);
            this.select.TabIndex = 4;
            this.select.Text = "Add manualy to a course";
            this.select.UseVisualStyleBackColor = true;
            this.select.Click += new System.EventHandler(this.select_Click);
            // 
            // ListCurrentStudents
            // 
            this.ListCurrentStudents.FormattingEnabled = true;
            this.ListCurrentStudents.Location = new System.Drawing.Point(26, 28);
            this.ListCurrentStudents.Name = "ListCurrentStudents";
            this.ListCurrentStudents.ScrollAlwaysVisible = true;
            this.ListCurrentStudents.Size = new System.Drawing.Size(159, 95);
            this.ListCurrentStudents.TabIndex = 7;
            // 
            // Current
            // 
            this.Current.AutoSize = true;
            this.Current.BackColor = System.Drawing.Color.Transparent;
            this.Current.Font = new System.Drawing.Font("Microsoft Sans Serif", 10.25F);
            this.Current.Location = new System.Drawing.Point(21, 64);
            this.Current.Name = "Current";
            this.Current.Size = new System.Drawing.Size(108, 17);
            this.Current.TabIndex = 8;
            this.Current.Text = "Current Course:";
            this.Current.Click += new System.EventHandler(this.Current_Click);
            // 
            // Attended
            // 
            this.Attended.FormattingEnabled = true;
            this.Attended.Location = new System.Drawing.Point(26, 174);
            this.Attended.Name = "Attended";
            this.Attended.ScrollAlwaysVisible = true;
            this.Attended.Size = new System.Drawing.Size(159, 95);
            this.Attended.TabIndex = 9;
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(6, 141);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(95, 13);
            this.label2.TabIndex = 11;
            this.label2.Text = "Attended Students";
            // 
            // AddManualy
            // 
            this.AddManualy.Location = new System.Drawing.Point(58, 287);
            this.AddManualy.Name = "AddManualy";
            this.AddManualy.Size = new System.Drawing.Size(88, 45);
            this.AddManualy.TabIndex = 12;
            this.AddManualy.Text = "Add manualy to current course";
            this.AddManualy.UseVisualStyleBackColor = true;
            this.AddManualy.Click += new System.EventHandler(this.AddManualy_Click);
            // 
            // proccess_bar
            // 
            this.proccess_bar.Location = new System.Drawing.Point(349, 350);
            this.proccess_bar.Name = "proccess_bar";
            this.proccess_bar.Size = new System.Drawing.Size(104, 45);
            this.proccess_bar.TabIndex = 14;
            this.proccess_bar.Visible = false;
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Font = new System.Drawing.Font("Microsoft Sans Serif", 15F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label3.Location = new System.Drawing.Point(356, 312);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(97, 25);
            this.label3.TabIndex = 15;
            this.label3.Text = "Loading...";
            this.label3.Visible = false;
            // 
            // Play_Stop_button
            // 
            this.Play_Stop_button.Font = new System.Drawing.Font("Microsoft Sans Serif", 15F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.Play_Stop_button.Location = new System.Drawing.Point(21, 127);
            this.Play_Stop_button.Name = "Play_Stop_button";
            this.Play_Stop_button.Size = new System.Drawing.Size(88, 43);
            this.Play_Stop_button.TabIndex = 1;
            this.Play_Stop_button.Text = "Start";
            this.Play_Stop_button.UseVisualStyleBackColor = true;
            this.Play_Stop_button.Click += new System.EventHandler(this.Play_Stop_button_Click);
            // 
            // pictureBox1
            // 
            this.pictureBox1.Image = ((System.Drawing.Image)(resources.GetObject("pictureBox1.Image")));
            this.pictureBox1.Location = new System.Drawing.Point(5, 0);
            this.pictureBox1.Name = "pictureBox1";
            this.pictureBox1.Size = new System.Drawing.Size(100, 118);
            this.pictureBox1.TabIndex = 0;
            this.pictureBox1.TabStop = false;
            // 
            // button_panel
            // 
            this.button_panel.Controls.Add(this.pictureBox1);
            this.button_panel.Controls.Add(this.Play_Stop_button);
            this.button_panel.Location = new System.Drawing.Point(337, 292);
            this.button_panel.Name = "button_panel";
            this.button_panel.Size = new System.Drawing.Size(128, 177);
            this.button_panel.TabIndex = 13;
            // 
            // Disconnect
            // 
            this.Disconnect.BackColor = System.Drawing.Color.DarkCyan;
            this.Disconnect.Location = new System.Drawing.Point(372, 32);
            this.Disconnect.Name = "Disconnect";
            this.Disconnect.Size = new System.Drawing.Size(88, 39);
            this.Disconnect.TabIndex = 20;
            this.Disconnect.Text = "Disconnect";
            this.Disconnect.UseVisualStyleBackColor = false;
            this.Disconnect.Click += new System.EventHandler(this.Disconnect_Click);
            // 
            // ContinueLecturer
            // 
            this.ContinueLecturer.BackColor = System.Drawing.Color.DarkGoldenrod;
            this.ContinueLecturer.Location = new System.Drawing.Point(372, 100);
            this.ContinueLecturer.Name = "ContinueLecturer";
            this.ContinueLecturer.Size = new System.Drawing.Size(88, 40);
            this.ContinueLecturer.TabIndex = 35;
            this.ContinueLecturer.Text = "Back To Choice Menu";
            this.ContinueLecturer.UseVisualStyleBackColor = false;
            this.ContinueLecturer.Visible = false;
            this.ContinueLecturer.Click += new System.EventHandler(this.ContinueLecturer_Click);
            // 
            // courseList
            // 
            this.courseList.BackColor = System.Drawing.SystemColors.ButtonHighlight;
            this.courseList.FormattingEnabled = true;
            this.courseList.Location = new System.Drawing.Point(6, 49);
            this.courseList.Name = "courseList";
            this.courseList.Size = new System.Drawing.Size(206, 147);
            this.courseList.TabIndex = 36;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(11, 12);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(93, 13);
            this.label1.TabIndex = 10;
            this.label1.Text = "Potential Students";
            // 
            // details
            // 
            this.details.Controls.Add(this.tabPage1);
            this.details.Controls.Add(this.tabPage2);
            this.details.Location = new System.Drawing.Point(12, 100);
            this.details.Name = "details";
            this.details.SelectedIndex = 0;
            this.details.Size = new System.Drawing.Size(230, 374);
            this.details.TabIndex = 2;
            // 
            // tabPage1
            // 
            this.tabPage1.BackColor = System.Drawing.SystemColors.ButtonHighlight;
            this.tabPage1.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D;
            this.tabPage1.Controls.Add(this.courseList);
            this.tabPage1.Controls.Add(this.select);
            this.tabPage1.Controls.Add(this.LessonsList);
            this.tabPage1.Location = new System.Drawing.Point(4, 22);
            this.tabPage1.Name = "tabPage1";
            this.tabPage1.Padding = new System.Windows.Forms.Padding(3);
            this.tabPage1.Size = new System.Drawing.Size(222, 348);
            this.tabPage1.TabIndex = 0;
            this.tabPage1.Text = "my courses";
            // 
            // tabPage2
            // 
            this.tabPage2.BackColor = System.Drawing.SystemColors.ButtonHighlight;
            this.tabPage2.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D;
            this.tabPage2.Controls.Add(this.ListCurrentStudents);
            this.tabPage2.Controls.Add(this.label1);
            this.tabPage2.Controls.Add(this.Attended);
            this.tabPage2.Controls.Add(this.label2);
            this.tabPage2.Controls.Add(this.AddManualy);
            this.tabPage2.Location = new System.Drawing.Point(4, 22);
            this.tabPage2.Name = "tabPage2";
            this.tabPage2.Padding = new System.Windows.Forms.Padding(3);
            this.tabPage2.Size = new System.Drawing.Size(222, 348);
            this.tabPage2.TabIndex = 1;
            this.tabPage2.Text = "potential and attended students";
            // 
            // MainPage
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(497, 496);
            this.Controls.Add(this.details);
            this.Controls.Add(this.ContinueLecturer);
            this.Controls.Add(this.Disconnect);
            this.Controls.Add(this.proccess_bar);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.button_panel);
            this.Controls.Add(this.Current);
            this.Controls.Add(this.Welcome);
            this.Name = "MainPage";
            this.Text = "Attender";
            this.Load += new System.EventHandler(this.MainPage_Load);
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).EndInit();
            this.button_panel.ResumeLayout(false);
            this.details.ResumeLayout(false);
            this.tabPage1.ResumeLayout(false);
            this.tabPage1.PerformLayout();
            this.tabPage2.ResumeLayout(false);
            this.tabPage2.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label Welcome;
        private System.Windows.Forms.Label LessonsList;
        private System.Windows.Forms.Button select;
        private System.Windows.Forms.ListBox ListCurrentStudents;
        private System.Windows.Forms.Label Current;
        private System.Windows.Forms.ListBox Attended;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Button AddManualy;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.ProgressBar proccess_bar;
        private System.Windows.Forms.Button Play_Stop_button;
        private System.Windows.Forms.PictureBox pictureBox1;
        private System.Windows.Forms.Panel button_panel;
        private System.Windows.Forms.Button Disconnect;
        private System.Windows.Forms.Button ContinueLecturer;
        private System.Windows.Forms.ListBox courseList;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.TabControl details;
        private System.Windows.Forms.TabPage tabPage1;
        private System.Windows.Forms.TabPage tabPage2;
    }
}