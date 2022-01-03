namespace AttenderDesktopApp
{
    partial class admin
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
            this.Welcome = new System.Windows.Forms.Label();
            this.Add = new System.Windows.Forms.Button();
            this.studentList = new System.Windows.Forms.ListBox();
            this.Delete = new System.Windows.Forms.Button();
            this.label1 = new System.Windows.Forms.Label();
            this.Passport = new System.Windows.Forms.TextBox();
            this.First = new System.Windows.Forms.TextBox();
            this.Last = new System.Windows.Forms.TextBox();
            this.Pass = new System.Windows.Forms.TextBox();
            this.Phone = new System.Windows.Forms.TextBox();
            this.Doal = new System.Windows.Forms.TextBox();
            this.type = new System.Windows.Forms.TextBox();
            this.label2 = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.lecturerList = new System.Windows.Forms.ListBox();
            this.label4 = new System.Windows.Forms.Label();
            this.courseList = new System.Windows.Forms.ListBox();
            this.label5 = new System.Windows.Forms.Label();
            this.connect = new System.Windows.Forms.Button();
            this.Disconnect = new System.Windows.Forms.Button();
            this.ContinueLecturer = new System.Windows.Forms.Button();
            this.AddCourse = new System.Windows.Forms.Button();
            this.SuspendLayout();
            // 
            // Welcome
            // 
            this.Welcome.AutoSize = true;
            this.Welcome.Location = new System.Drawing.Point(129, 24);
            this.Welcome.Name = "Welcome";
            this.Welcome.Size = new System.Drawing.Size(157, 13);
            this.Welcome.TabIndex = 0;
            this.Welcome.Text = "Welcome to Admin presentation";
            // 
            // Add
            // 
            this.Add.BackColor = System.Drawing.SystemColors.ActiveCaption;
            this.Add.Location = new System.Drawing.Point(12, 183);
            this.Add.Name = "Add";
            this.Add.Size = new System.Drawing.Size(220, 31);
            this.Add.TabIndex = 1;
            this.Add.Text = "Add member";
            this.Add.UseVisualStyleBackColor = false;
            this.Add.Click += new System.EventHandler(this.Add_Click);
            // 
            // studentList
            // 
            this.studentList.FormattingEnabled = true;
            this.studentList.Location = new System.Drawing.Point(15, 333);
            this.studentList.Name = "studentList";
            this.studentList.ScrollAlwaysVisible = true;
            this.studentList.Size = new System.Drawing.Size(217, 95);
            this.studentList.TabIndex = 2;
            // 
            // Delete
            // 
            this.Delete.BackColor = System.Drawing.SystemColors.ControlDark;
            this.Delete.Location = new System.Drawing.Point(15, 445);
            this.Delete.Name = "Delete";
            this.Delete.Size = new System.Drawing.Size(137, 23);
            this.Delete.TabIndex = 3;
            this.Delete.Text = "Click to delete Student";
            this.Delete.UseVisualStyleBackColor = false;
            this.Delete.Click += new System.EventHandler(this.Delete_Student);
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(12, 307);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(78, 13);
            this.label1.TabIndex = 4;
            this.label1.Text = "List of students";
            // 
            // Passport
            // 
            this.Passport.BackColor = System.Drawing.SystemColors.ActiveCaption;
            this.Passport.Location = new System.Drawing.Point(12, 71);
            this.Passport.Name = "Passport";
            this.Passport.Size = new System.Drawing.Size(100, 20);
            this.Passport.TabIndex = 5;
            this.Passport.Text = "Passport Number";
            // 
            // First
            // 
            this.First.BackColor = System.Drawing.SystemColors.ActiveCaption;
            this.First.Location = new System.Drawing.Point(12, 106);
            this.First.Name = "First";
            this.First.Size = new System.Drawing.Size(100, 20);
            this.First.TabIndex = 6;
            this.First.Text = "First Name";
            // 
            // Last
            // 
            this.Last.BackColor = System.Drawing.SystemColors.ActiveCaption;
            this.Last.Location = new System.Drawing.Point(12, 141);
            this.Last.Name = "Last";
            this.Last.Size = new System.Drawing.Size(100, 20);
            this.Last.TabIndex = 7;
            this.Last.Text = "Last Name";
            // 
            // Pass
            // 
            this.Pass.BackColor = System.Drawing.SystemColors.ActiveCaption;
            this.Pass.Location = new System.Drawing.Point(132, 71);
            this.Pass.Name = "Pass";
            this.Pass.Size = new System.Drawing.Size(100, 20);
            this.Pass.TabIndex = 8;
            this.Pass.Text = "Password";
            // 
            // Phone
            // 
            this.Phone.BackColor = System.Drawing.SystemColors.ActiveCaption;
            this.Phone.Location = new System.Drawing.Point(132, 106);
            this.Phone.Name = "Phone";
            this.Phone.Size = new System.Drawing.Size(100, 20);
            this.Phone.TabIndex = 9;
            this.Phone.Text = "Phone Number";
            // 
            // Doal
            // 
            this.Doal.BackColor = System.Drawing.SystemColors.ActiveCaption;
            this.Doal.Location = new System.Drawing.Point(132, 141);
            this.Doal.Name = "Doal";
            this.Doal.Size = new System.Drawing.Size(100, 20);
            this.Doal.TabIndex = 10;
            this.Doal.Text = "Mail Address";
            // 
            // type
            // 
            this.type.BackColor = System.Drawing.SystemColors.ActiveCaption;
            this.type.Location = new System.Drawing.Point(252, 107);
            this.type.Name = "type";
            this.type.Size = new System.Drawing.Size(100, 20);
            this.type.TabIndex = 11;
            this.type.Text = "l / s";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(249, 78);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(90, 13);
            this.label2.TabIndex = 12;
            this.label2.Text = "Enter l for lecturer";
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(249, 91);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(77, 13);
            this.label3.TabIndex = 13;
            this.label3.Text = "or s for student";
            // 
            // lecturerList
            // 
            this.lecturerList.FormattingEnabled = true;
            this.lecturerList.Location = new System.Drawing.Point(289, 209);
            this.lecturerList.Name = "lecturerList";
            this.lecturerList.ScrollAlwaysVisible = true;
            this.lecturerList.SelectionMode = System.Windows.Forms.SelectionMode.None;
            this.lecturerList.Size = new System.Drawing.Size(217, 69);
            this.lecturerList.TabIndex = 14;
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(286, 183);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(78, 13);
            this.label4.TabIndex = 15;
            this.label4.Text = "List of lecturers";
            // 
            // courseList
            // 
            this.courseList.FormattingEnabled = true;
            this.courseList.Location = new System.Drawing.Point(289, 333);
            this.courseList.Name = "courseList";
            this.courseList.ScrollAlwaysVisible = true;
            this.courseList.Size = new System.Drawing.Size(217, 95);
            this.courseList.TabIndex = 16;
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Location = new System.Drawing.Point(286, 307);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(189, 13);
            this.label5.TabIndex = 17;
            this.label5.Text = "Select Student And Course to connect";
            // 
            // connect
            // 
            this.connect.BackColor = System.Drawing.SystemColors.ControlDark;
            this.connect.Location = new System.Drawing.Point(289, 445);
            this.connect.Name = "connect";
            this.connect.Size = new System.Drawing.Size(150, 23);
            this.connect.TabIndex = 18;
            this.connect.Text = "Connect Student-Course";
            this.connect.UseVisualStyleBackColor = false;
            this.connect.Click += new System.EventHandler(this.connect_Students_To_Course);
            // 
            // Disconnect
            // 
            this.Disconnect.BackColor = System.Drawing.Color.DarkCyan;
            this.Disconnect.Location = new System.Drawing.Point(460, 12);
            this.Disconnect.Name = "Disconnect";
            this.Disconnect.Size = new System.Drawing.Size(88, 36);
            this.Disconnect.TabIndex = 19;
            this.Disconnect.Text = "Disconnect";
            this.Disconnect.UseVisualStyleBackColor = false;
            this.Disconnect.Click += new System.EventHandler(this.ReConnect_Click);
            // 
            // ContinueLecturer
            // 
            this.ContinueLecturer.BackColor = System.Drawing.Color.DarkGoldenrod;
            this.ContinueLecturer.Location = new System.Drawing.Point(460, 54);
            this.ContinueLecturer.Name = "ContinueLecturer";
            this.ContinueLecturer.Size = new System.Drawing.Size(88, 37);
            this.ContinueLecturer.TabIndex = 20;
            this.ContinueLecturer.Text = "Back To Choice Menu";
            this.ContinueLecturer.UseVisualStyleBackColor = false;
            this.ContinueLecturer.Visible = false;
            this.ContinueLecturer.Click += new System.EventHandler(this.ContinueLecturer_Click);
            // 
            // AddCourse
            // 
            this.AddCourse.BackColor = System.Drawing.Color.DarkGreen;
            this.AddCourse.Location = new System.Drawing.Point(460, 98);
            this.AddCourse.Name = "AddCourse";
            this.AddCourse.Size = new System.Drawing.Size(88, 37);
            this.AddCourse.TabIndex = 21;
            this.AddCourse.Text = "Add a new course";
            this.AddCourse.UseVisualStyleBackColor = false;
            this.AddCourse.Click += new System.EventHandler(this.AddCourse_Click);
            // 
            // admin
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(560, 491);
            this.Controls.Add(this.AddCourse);
            this.Controls.Add(this.ContinueLecturer);
            this.Controls.Add(this.Disconnect);
            this.Controls.Add(this.connect);
            this.Controls.Add(this.label5);
            this.Controls.Add(this.courseList);
            this.Controls.Add(this.label4);
            this.Controls.Add(this.lecturerList);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.type);
            this.Controls.Add(this.Doal);
            this.Controls.Add(this.Phone);
            this.Controls.Add(this.Pass);
            this.Controls.Add(this.Last);
            this.Controls.Add(this.First);
            this.Controls.Add(this.Passport);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.Delete);
            this.Controls.Add(this.studentList);
            this.Controls.Add(this.Add);
            this.Controls.Add(this.Welcome);
            this.Name = "admin";
            this.Text = "admin";
            this.Load += new System.EventHandler(this.admin_Load);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label Welcome;
        private System.Windows.Forms.Button Add;
        private System.Windows.Forms.ListBox studentList;
        private System.Windows.Forms.Button Delete;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.TextBox Passport;
        private System.Windows.Forms.TextBox First;
        private System.Windows.Forms.TextBox Last;
        private System.Windows.Forms.TextBox Pass;
        private System.Windows.Forms.TextBox Phone;
        private System.Windows.Forms.TextBox Doal;
        private System.Windows.Forms.TextBox type;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.ListBox lecturerList;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.ListBox courseList;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.Button connect;
        private System.Windows.Forms.Button Disconnect;
        private System.Windows.Forms.Button ContinueLecturer;
        private System.Windows.Forms.Button AddCourse;
    }
}