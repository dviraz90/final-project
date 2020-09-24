namespace AttenderDesktopApp
{
    partial class AddCourse
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
            this.lecturerList = new System.Windows.Forms.ListBox();
            this.CourseName = new System.Windows.Forms.TextBox();
            this.Code = new System.Windows.Forms.TextBox();
            this.dp = new System.Windows.Forms.ListBox();
            this.label1 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.addc = new System.Windows.Forms.Button();
            this.courseList = new System.Windows.Forms.ListBox();
            this.CDate = new System.Windows.Forms.TextBox();
            this.CStart = new System.Windows.Forms.TextBox();
            this.CEnd = new System.Windows.Forms.TextBox();
            this.CRoom = new System.Windows.Forms.TextBox();
            this.label3 = new System.Windows.Forms.Label();
            this.label4 = new System.Windows.Forms.Label();
            this.label5 = new System.Windows.Forms.Label();
            this.label6 = new System.Windows.Forms.Label();
            this.button1 = new System.Windows.Forms.Button();
            this.label7 = new System.Windows.Forms.Label();
            this.label8 = new System.Windows.Forms.Label();
            this.AddCurses = new System.Windows.Forms.TabControl();
            this.AddACourse = new System.Windows.Forms.TabPage();
            this.AddCourseTime = new System.Windows.Forms.TabPage();
            this.AddCurses.SuspendLayout();
            this.AddACourse.SuspendLayout();
            this.AddCourseTime.SuspendLayout();
            this.SuspendLayout();
            // 
            // lecturerList
            // 
            this.lecturerList.FormattingEnabled = true;
            this.lecturerList.Location = new System.Drawing.Point(42, 58);
            this.lecturerList.Name = "lecturerList";
            this.lecturerList.ScrollAlwaysVisible = true;
            this.lecturerList.Size = new System.Drawing.Size(166, 69);
            this.lecturerList.TabIndex = 15;
            // 
            // CourseName
            // 
            this.CourseName.Location = new System.Drawing.Point(298, 58);
            this.CourseName.Name = "CourseName";
            this.CourseName.Size = new System.Drawing.Size(100, 20);
            this.CourseName.TabIndex = 16;
            // 
            // Code
            // 
            this.Code.Location = new System.Drawing.Point(298, 97);
            this.Code.Name = "Code";
            this.Code.Size = new System.Drawing.Size(100, 20);
            this.Code.TabIndex = 17;
            // 
            // dp
            // 
            this.dp.FormattingEnabled = true;
            this.dp.Location = new System.Drawing.Point(42, 146);
            this.dp.Name = "dp";
            this.dp.ScrollAlwaysVisible = true;
            this.dp.Size = new System.Drawing.Size(166, 69);
            this.dp.TabIndex = 18;
            this.dp.SelectedIndexChanged += new System.EventHandler(this.dp_SelectedIndexChanged);
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(247, 61);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(38, 13);
            this.label1.TabIndex = 19;
            this.label1.Text = "Name:";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(250, 100);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(35, 13);
            this.label2.TabIndex = 20;
            this.label2.Text = "Code:";
            // 
            // addc
            // 
            this.addc.Location = new System.Drawing.Point(282, 162);
            this.addc.Name = "addc";
            this.addc.Size = new System.Drawing.Size(117, 53);
            this.addc.TabIndex = 21;
            this.addc.Text = "Add course";
            this.addc.UseVisualStyleBackColor = true;
            this.addc.Click += new System.EventHandler(this.add_Click);
            // 
            // courseList
            // 
            this.courseList.FormattingEnabled = true;
            this.courseList.Location = new System.Drawing.Point(17, 67);
            this.courseList.Name = "courseList";
            this.courseList.ScrollAlwaysVisible = true;
            this.courseList.Size = new System.Drawing.Size(166, 95);
            this.courseList.TabIndex = 22;
            // 
            // CDate
            // 
            this.CDate.Location = new System.Drawing.Point(284, 67);
            this.CDate.Name = "CDate";
            this.CDate.Size = new System.Drawing.Size(100, 20);
            this.CDate.TabIndex = 23;
            this.CDate.Text = "YYYY-MM-DD";
            this.CDate.TextChanged += new System.EventHandler(this.CDate_TextChanged);
            // 
            // CStart
            // 
            this.CStart.Location = new System.Drawing.Point(284, 103);
            this.CStart.Name = "CStart";
            this.CStart.Size = new System.Drawing.Size(100, 20);
            this.CStart.TabIndex = 24;
            this.CStart.Text = "HH:MM:SS";
            // 
            // CEnd
            // 
            this.CEnd.Location = new System.Drawing.Point(284, 142);
            this.CEnd.Name = "CEnd";
            this.CEnd.Size = new System.Drawing.Size(100, 20);
            this.CEnd.TabIndex = 25;
            this.CEnd.Text = "HH:MM:SS";
            // 
            // CRoom
            // 
            this.CRoom.Location = new System.Drawing.Point(284, 180);
            this.CRoom.Name = "CRoom";
            this.CRoom.Size = new System.Drawing.Size(100, 20);
            this.CRoom.TabIndex = 26;
            this.CRoom.Text = "00.00.00";
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(222, 74);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(33, 13);
            this.label3.TabIndex = 27;
            this.label3.Text = "Date:";
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(222, 110);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(58, 13);
            this.label4.TabIndex = 28;
            this.label4.Text = "Start Time:";
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Location = new System.Drawing.Point(225, 149);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(55, 13);
            this.label5.TabIndex = 29;
            this.label5.Text = "End Time:";
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.Location = new System.Drawing.Point(225, 187);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(58, 13);
            this.label6.TabIndex = 30;
            this.label6.Text = "Classroom:";
            // 
            // button1
            // 
            this.button1.Location = new System.Drawing.Point(267, 226);
            this.button1.Name = "button1";
            this.button1.Size = new System.Drawing.Size(117, 49);
            this.button1.TabIndex = 31;
            this.button1.Text = "Add Course Time";
            this.button1.UseVisualStyleBackColor = true;
            this.button1.Click += new System.EventHandler(this.button1_Click);
            // 
            // label7
            // 
            this.label7.AutoSize = true;
            this.label7.BackColor = System.Drawing.Color.DarkCyan;
            this.label7.Font = new System.Drawing.Font("Microsoft Sans Serif", 10.25F);
            this.label7.Location = new System.Drawing.Point(177, 22);
            this.label7.Name = "label7";
            this.label7.Size = new System.Drawing.Size(92, 17);
            this.label7.TabIndex = 32;
            this.label7.Text = "Add a course";
            // 
            // label8
            // 
            this.label8.AutoSize = true;
            this.label8.BackColor = System.Drawing.Color.DarkCyan;
            this.label8.Font = new System.Drawing.Font("Microsoft Sans Serif", 10.25F);
            this.label8.Location = new System.Drawing.Point(144, 32);
            this.label8.Name = "label8";
            this.label8.Size = new System.Drawing.Size(127, 17);
            this.label8.TabIndex = 33;
            this.label8.Text = "Add a course Time";
            // 
            // AddCurses
            // 
            this.AddCurses.Controls.Add(this.AddACourse);
            this.AddCurses.Controls.Add(this.AddCourseTime);
            this.AddCurses.Location = new System.Drawing.Point(12, 12);
            this.AddCurses.Name = "AddCurses";
            this.AddCurses.SelectedIndex = 0;
            this.AddCurses.Size = new System.Drawing.Size(420, 311);
            this.AddCurses.TabIndex = 34;
            // 
            // AddACourse
            // 
            this.AddACourse.Controls.Add(this.lecturerList);
            this.AddACourse.Controls.Add(this.CourseName);
            this.AddACourse.Controls.Add(this.label7);
            this.AddACourse.Controls.Add(this.Code);
            this.AddACourse.Controls.Add(this.dp);
            this.AddACourse.Controls.Add(this.label1);
            this.AddACourse.Controls.Add(this.label2);
            this.AddACourse.Controls.Add(this.addc);
            this.AddACourse.Location = new System.Drawing.Point(4, 22);
            this.AddACourse.Name = "AddACourse";
            this.AddACourse.Padding = new System.Windows.Forms.Padding(3);
            this.AddACourse.Size = new System.Drawing.Size(412, 285);
            this.AddACourse.TabIndex = 0;
            this.AddACourse.Text = "add a course";
            this.AddACourse.UseVisualStyleBackColor = true;
            // 
            // AddCourseTime
            // 
            this.AddCourseTime.Controls.Add(this.courseList);
            this.AddCourseTime.Controls.Add(this.label8);
            this.AddCourseTime.Controls.Add(this.CDate);
            this.AddCourseTime.Controls.Add(this.button1);
            this.AddCourseTime.Controls.Add(this.CStart);
            this.AddCourseTime.Controls.Add(this.label6);
            this.AddCourseTime.Controls.Add(this.CEnd);
            this.AddCourseTime.Controls.Add(this.label5);
            this.AddCourseTime.Controls.Add(this.CRoom);
            this.AddCourseTime.Controls.Add(this.label4);
            this.AddCourseTime.Controls.Add(this.label3);
            this.AddCourseTime.Location = new System.Drawing.Point(4, 22);
            this.AddCourseTime.Name = "AddCourseTime";
            this.AddCourseTime.Padding = new System.Windows.Forms.Padding(3);
            this.AddCourseTime.Size = new System.Drawing.Size(412, 285);
            this.AddCourseTime.TabIndex = 1;
            this.AddCourseTime.Text = "add a course time";
            this.AddCourseTime.UseVisualStyleBackColor = true;
            // 
            // AddCourse
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(433, 335);
            this.Controls.Add(this.AddCurses);
            this.Name = "AddCourse";
            this.Text = "Add a Course";
            this.Load += new System.EventHandler(this.AddCourse_Load);
            this.AddCurses.ResumeLayout(false);
            this.AddACourse.ResumeLayout(false);
            this.AddACourse.PerformLayout();
            this.AddCourseTime.ResumeLayout(false);
            this.AddCourseTime.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.ListBox lecturerList;
        private System.Windows.Forms.TextBox CourseName;
        private System.Windows.Forms.TextBox Code;
        private System.Windows.Forms.ListBox dp;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Button addc;
        private System.Windows.Forms.ListBox courseList;
        private System.Windows.Forms.TextBox CDate;
        private System.Windows.Forms.TextBox CStart;
        private System.Windows.Forms.TextBox CEnd;
        private System.Windows.Forms.TextBox CRoom;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.Label label6;
        private System.Windows.Forms.Button button1;
        private System.Windows.Forms.Label label7;
        private System.Windows.Forms.Label label8;
        private System.Windows.Forms.TabControl AddCurses;
        private System.Windows.Forms.TabPage AddACourse;
        private System.Windows.Forms.TabPage AddCourseTime;
    }
}