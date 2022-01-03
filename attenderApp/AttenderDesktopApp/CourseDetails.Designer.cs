namespace AttenderDesktopApp
{
    partial class CourseDetails
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
            this.ListoflessonDates = new System.Windows.Forms.Label();
            this.InsertStudents = new System.Windows.Forms.Button();
            this.label1 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.LoadStudents = new System.Windows.Forms.Button();
            this.label3 = new System.Windows.Forms.Label();
            this.CourseList = new System.Windows.Forms.ListBox();
            this.ListCurrentStudents = new System.Windows.Forms.ListBox();
            this.Attended = new System.Windows.Forms.ListBox();
            this.SuspendLayout();
            // 
            // ListoflessonDates
            // 
            this.ListoflessonDates.AutoSize = true;
            this.ListoflessonDates.Location = new System.Drawing.Point(12, 29);
            this.ListoflessonDates.Name = "ListoflessonDates";
            this.ListoflessonDates.Size = new System.Drawing.Size(99, 13);
            this.ListoflessonDates.TabIndex = 0;
            this.ListoflessonDates.Text = "List of lesson Dates";
            this.ListoflessonDates.Click += new System.EventHandler(this.label1_Click);
            // 
            // InsertStudents
            // 
            this.InsertStudents.Location = new System.Drawing.Point(53, 271);
            this.InsertStudents.Name = "InsertStudents";
            this.InsertStudents.Size = new System.Drawing.Size(96, 23);
            this.InsertStudents.TabIndex = 2;
            this.InsertStudents.Text = "Insert Student";
            this.InsertStudents.UseVisualStyleBackColor = true;
            this.InsertStudents.Click += new System.EventHandler(this.InsertStudent);
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(12, 46);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(228, 13);
            this.label1.TabIndex = 3;
            this.label1.Text = "Select a course for entering a student manually";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(270, 46);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(172, 13);
            this.label2.TabIndex = 5;
            this.label2.Text = "Select student out of the list below:";
            // 
            // LoadStudents
            // 
            this.LoadStudents.Location = new System.Drawing.Point(53, 221);
            this.LoadStudents.Name = "LoadStudents";
            this.LoadStudents.Size = new System.Drawing.Size(96, 23);
            this.LoadStudents.TabIndex = 7;
            this.LoadStudents.Text = "Load Student";
            this.LoadStudents.UseVisualStyleBackColor = true;
            this.LoadStudents.Click += new System.EventHandler(this.LoadStudent);
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(259, 213);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(131, 13);
            this.label3.TabIndex = 10;
            this.label3.Text = "Students who\'ve attended";
            // 
            // CourseList
            // 
            this.CourseList.FormattingEnabled = true;
            this.CourseList.Location = new System.Drawing.Point(18, 72);
            this.CourseList.Name = "CourseList";
            this.CourseList.Size = new System.Drawing.Size(177, 121);
            this.CourseList.TabIndex = 11;
            // 
            // ListCurrentStudents
            // 
            this.ListCurrentStudents.FormattingEnabled = true;
            this.ListCurrentStudents.Location = new System.Drawing.Point(262, 73);
            this.ListCurrentStudents.Name = "ListCurrentStudents";
            this.ListCurrentStudents.Size = new System.Drawing.Size(191, 121);
            this.ListCurrentStudents.TabIndex = 12;
            // 
            // Attended
            // 
            this.Attended.FormattingEnabled = true;
            this.Attended.Location = new System.Drawing.Point(262, 229);
            this.Attended.Name = "Attended";
            this.Attended.Size = new System.Drawing.Size(180, 121);
            this.Attended.TabIndex = 13;
            // 
            // CourseDetails
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(528, 380);
            this.Controls.Add(this.Attended);
            this.Controls.Add(this.ListCurrentStudents);
            this.Controls.Add(this.CourseList);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.LoadStudents);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.InsertStudents);
            this.Controls.Add(this.ListoflessonDates);
            this.Name = "CourseDetails";
            this.Text = "Insert attending maunally";
            this.Load += new System.EventHandler(this.CourseDetails_Load);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label ListoflessonDates;
        private System.Windows.Forms.Button InsertStudents;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Button LoadStudents;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.ListBox CourseList;
        private System.Windows.Forms.ListBox ListCurrentStudents;
        private System.Windows.Forms.ListBox Attended;
    }
}