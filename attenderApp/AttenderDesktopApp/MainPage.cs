using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.IO;
using System.Linq;
using System.Net.Http;
using System.Net.Http.Headers;
using System.Security.Principal;
using System.Threading;
using System.Windows.Forms;
using VirtualRouterHost;

namespace AttenderDesktopApp
{
    public partial class MainPage : Form
    {
        public string Token;
        public string Mail;
        public string Hello;
        public string Password;
        public DateTime time;
        public DateTime extime;
        public string dateOnly;
        public string hourOnly;
       

        public string HotSpotName = "Attender";
        public string HotSpotPassword = "11112222";
        Process newprocess = new Process();
        VirtualRouterHost.VirtualRouterHost virtualRouterHost;
        List<ConnectedPeer> connectedPeersList;
        Thread bgthread;

        public MainPage(string Hello, string Mail, string Password, string Token, DateTime time)
        {
            InitializeComponent();
            Welcome.Text = Hello + "Wellcome To attender App";
            this.Token = Token;
            this.Mail = Mail;
            this.Password = Password;
            this.time = time;
            this.Hello = Hello;
            this.extime = time;
            newprocess.StartInfo.UseShellExecute = false;
            newprocess.StartInfo.CreateNoWindow = true;
            newprocess.StartInfo.WindowStyle = ProcessWindowStyle.Hidden;
           
        }

        private async void MainPage_Load(object sender, EventArgs e)
        {
            var clientId = new HttpClient();
            HttpResponseMessage responseId = await clientId.GetAsync("http://localhost:43719/api/member/Iduser/" + Mail + "/Idpassword/" + Password);
            string stringId = await responseId.Content.ReadAsStringAsync();
            int lecturerId = int.Parse(stringId);

            string Lessons;
            List<string> LessonsList;

            var clientRole = new HttpClient();
            HttpResponseMessage responseRole = await clientRole.GetAsync("http://localhost:43719/api/memberRole/lecturerId/" + lecturerId);
            string strRole = await responseRole.Content.ReadAsStringAsync();
            string role = strRole.Substring(1, strRole.Length - 2);
            if (role == "h")
                ContinueLecturer.Visible = true;

            DateTime date = DateTime.Now;
            dateOnly = date.ToString();
            dateOnly = dateOnly.Substring(0, 10);
            dateOnly = dateOnly.Replace('/', '-');
            hourOnly = date.ToString();
            hourOnly = hourOnly.Substring(11);

            try
            {

                var clientcheck = new HttpClient();
                HttpResponseMessage responseCkeck = await clientcheck.GetAsync("http://localhost:43719/api/course/LectureId/" + lecturerId + "/dateOnly/" + dateOnly + "/hourOnly/" + hourOnly);
                string strCheck = await responseCkeck.Content.ReadAsStringAsync();
                int courseId = int.Parse(strCheck);

                if (courseId != 0)
                {
                    var clientCurrent = new HttpClient();
                    HttpResponseMessage responseCurrent = await clientCurrent.GetAsync("http://localhost:43719/api/course/courseId/" + courseId + "/id/" + lecturerId);
                    string strCurrent = await responseCurrent.Content.ReadAsStringAsync();

                    if (responseCurrent.IsSuccessStatusCode)
                        Current.Text = "Current Course is: " + strCurrent.Substring(1, strCurrent.Length - 2);



                    var clientCourseStudents = new HttpClient();
                    HttpResponseMessage responseCourseStudents = await clientCourseStudents.GetAsync("http://localhost:43719/api/courseStudent/courseId/" + courseId);
                    string strCourseStudents = await responseCourseStudents.Content.ReadAsStringAsync();

                    List<string> studentsIds = new List<string>();
                    studentsIds = ((strCourseStudents.Substring(1, strCourseStudents.Length - 2).Split(',')).ToList<string>());

                    foreach (var item in studentsIds)
                    {

                        string strStudentId = item.ToString().Substring(1, item.Length - 2);
                        int studentId = int.Parse(strStudentId);

                        var clientstudentDetails = new HttpClient();
                        HttpResponseMessage responsestudentDetails = await clientstudentDetails.GetAsync("http://localhost:43719/api/member/studentId/" + studentId);
                        string strStudentDetails = await responsestudentDetails.Content.ReadAsStringAsync();

                        string studentDetails = strStudentDetails.Substring(1, strStudentDetails.Length - 2);
                        ListCurrentStudents.Items.Add(studentDetails);
                    }

                    AttendedStudents();
                }





            var client = new HttpClient();

            client.DefaultRequestHeaders.Authorization = new AuthenticationHeaderValue("Bearer", Token);

            HttpResponseMessage response = await client.GetAsync(
                "http://localhost:43719/api/App/id/" + lecturerId);
            HttpContent responseContent = response.Content;

            using (var reader = new StreamReader(await responseContent.ReadAsStreamAsync()))
            {
                Lessons = (await reader.ReadToEndAsync());
                LessonsList = ((Lessons.Substring(1, Lessons.Length - 2).Split(',')).ToList<string>());

                foreach (var item in LessonsList)
                {
                    int index = item.IndexOf(' ');
                    string courseName = item.Substring(index, item.Length - 1 - index);
                    if (courseName == "") throw new Exception(); 
                    courseList.Items.Add(courseName);
                }
            }
        }

       catch
       {
         MessageBox.Show("You have no courses");
       }
   }

        public async void AttendedStudents()
        {
            Attended.Items.Clear();
            List<string> studentAttending = new List<string>();
            try
            {
                var clientLecId = new HttpClient();
                HttpResponseMessage responseLecId = await clientLecId.GetAsync("http://localhost:43719/api/member/Iduser/" + Mail + "/Idpassword/" + Password);
                string stringId = await responseLecId.Content.ReadAsStringAsync();
                int lecturerId = int.Parse(stringId);

                var clientId = new HttpClient();
                HttpResponseMessage responseId = await clientId.GetAsync("http://localhost:43719/api/lessonTime/date/" + dateOnly + "/hour/" + hourOnly + "/Lecture/" + lecturerId);
                string strId = await responseId.Content.ReadAsStringAsync();
                int lessonId = int.Parse(strId);

                var clientList = new HttpClient();
                HttpResponseMessage responseList = await clientList.GetAsync("http://localhost:43719/api/lessonAttending/lessonId/" + lessonId);
                string strList = await responseList.Content.ReadAsStringAsync();
                if (!strList.Contains("[]"))
                {
                    studentAttending = ((strList.Substring(1, strList.Length - 2).Split(',')).ToList<string>());
                    foreach (string studentId in studentAttending)
                    {
                        var clientInfo = new HttpClient();
                        HttpResponseMessage responseInfo = await clientInfo.GetAsync("http://localhost:43719/api/member/memberInfo/" + studentId);
                        string Info = await responseInfo.Content.ReadAsStringAsync();
                        Attended.Items.Add(Info.Substring(1,Info.Length-2));
                    }
                }
            }
            catch
            {
                /////
            }
            
        }
       
        public int CheckTokenValidation(int ExpireToken)
        {
            string hour = DateTime.Now.ToString().Substring(11);
            DateTime a = extime.AddMinutes(ExpireToken);
            string extimeperiod = a.ToString().Substring(11);
            return (TimeSpan.Compare(TimeSpan.Parse(extimeperiod), TimeSpan.Parse(hour)));
        }
        

       private async void select_Click(object sender, EventArgs e)
        {
            var clientToken = new HttpClient();
            HttpResponseMessage responseToken = await clientToken.GetAsync("http://localhost:43719/api/register/token");
            string strToken = await responseToken.Content.ReadAsStringAsync();

            int TokenResult = CheckTokenValidation(int.Parse(strToken));
            if (TokenResult > 0)
            {
                try
                {
                    string Selected = courseList.SelectedItem.ToString();
                    Selected = Selected.Substring(1);

                    var courseId = new HttpClient();
                    HttpResponseMessage responseId = await courseId.GetAsync("http://localhost:43719/api/member/courseId/" + Selected);
                    string strId = await responseId.Content.ReadAsStringAsync();


                    int id = int.Parse(strId);

                    List<string> list = new List<string>();
                    var allCourses = new HttpClient();
                    HttpResponseMessage responseAll = await allCourses.GetAsync("http://localhost:43719/api/member/allCourses/" + id);
                    string strAll = await responseAll.Content.ReadAsStringAsync();

                    list  = ((strAll.Substring(1, strAll.Length - 2).Split(',')).ToList<string>());

                    CourseDetails cd = new CourseDetails(list, Token, time);

                    DateTime date = DateTime.Now;
                    string today = date.ToString();

                    cd.ShowDialog();
                }
                catch
                {
                    MessageBox.Show("You must Select a course to add manualy to it");
                }
                
            }
            else
            {
                MessageBox.Show("The Token has EXPIRED - Please Reconnect");
            }
        }

        private async void AddManualy_Click(object sender, EventArgs e)
        {
            var clientToken = new HttpClient();
            HttpResponseMessage responseToken = await clientToken.GetAsync("http://localhost:43719/api/register/token");
            string strToken = await responseToken.Content.ReadAsStringAsync();

            int TokenResult = CheckTokenValidation(int.Parse(strToken));
            if (TokenResult > 0)
            {
                try
                {
                    var clientLecId = new HttpClient();
                    HttpResponseMessage responseLecId = await clientLecId.GetAsync("http://localhost:43719/api/member/Iduser/" + Mail + "/Idpassword/" + Password);
                    string stringId = await responseLecId.Content.ReadAsStringAsync();
                    int lectureId = int.Parse(stringId);

                    var clientLessonTimeId = new HttpClient();
                    HttpResponseMessage responseLessonTimeId = await clientLessonTimeId.GetAsync("http://localhost:43719/api/lessonTime/date/" + dateOnly + "/hour/" + hourOnly + "/Lecture/" + lectureId);
                    string strLessonTimeId = await responseLessonTimeId.Content.ReadAsStringAsync();
                    int lessonTimeId = int.Parse(strLessonTimeId);

                    var clientLessonTime = new HttpClient();
                    HttpResponseMessage responseLessonTime = await clientLessonTime.GetAsync("http://localhost:43719/api/lessonTime/GetLessonTime/" + lessonTimeId);
                    string strLessonTime = await responseLessonTime.Content.ReadAsStringAsync();
                    string lessonTime = strLessonTime;

                    if (lessonTime.Contains("\""))
                        lessonTime = lessonTime.Substring(1, lessonTime.Length - 2);

                    string SelectedItem = ListCurrentStudents.SelectedItem.ToString();
                    SelectedItem = SelectedItem.Substring(0,9);


                    var clientSpecifiedIde = new HttpClient();
                    HttpResponseMessage responseSpecifiedId = await clientSpecifiedIde.GetAsync("http://localhost:43719/api/member/specified/" + SelectedItem);
                    string strSpecifiedId = await responseSpecifiedId.Content.ReadAsStringAsync();
                    int SpecifiedId = int.Parse(strSpecifiedId);

                    string hour = DateTime.Now.ToString().Substring(11);


                    var client1 = new HttpClient();
                    client1.DefaultRequestHeaders.Authorization = new AuthenticationHeaderValue("Bearer", Token);
                    var requestContent1 = new FormUrlEncodedContent(new[] {
                                new KeyValuePair<string, string>("StudentId", SpecifiedId.ToString()),
                                new KeyValuePair<string, string>("LessonId", lessonTimeId.ToString()),
                                new KeyValuePair<string, string>("CheckTimeStart", TimeSpan.Parse(hour).ToString()),
                                new KeyValuePair<string, string>("CheckTimeEnd",lessonTime),
                                    });
                    HttpResponseMessage response1 = await client1.PostAsync(
                    "http://localhost:43719/api/lessonAttending",
                     requestContent1);
                    if (response1.IsSuccessStatusCode)
                        MessageBox.Show("Success");
                    else
                        MessageBox.Show("Failed");
                    AttendedStudents();
                }
                catch
                {
                    MessageBox.Show("You Must Select a student To Add");
                }
            }
            else
            {
                MessageBox.Show("The Token has EXPIRED - Please Reconnect");
            }
        }

        private void Current_Click(object sender, EventArgs e)
        {

        }
        public bool IsUserAdminstrator()
        {
            bool isAdmin;

            try
            {
                WindowsIdentity user = WindowsIdentity.GetCurrent();
                WindowsPrincipal principal = new WindowsPrincipal(user);
                isAdmin = principal.IsInRole(WindowsBuiltInRole.Administrator);
            }

            catch (UnauthorizedAccessException)
            {
                isAdmin = false;
            }

            catch (Exception)
            {
                isAdmin = false;
            }
            return isAdmin;
        }
        public void Process_start_1()
        {
            proccess_bar.Visible = true;
            proccess_bar.Increment(25);
            newprocess.StartInfo.FileName = "netsh";
            newprocess.StartInfo.Arguments = "wlan stop hostednetwork";
            try
            {
                using (Process execute = Process.Start(newprocess.StartInfo))
                {
                    execute.WaitForExit();
                    proccess_bar.Increment(25);
                    Process_start_2();
                }
            }
            catch
            {
                // nothing
            }
        }
        public void Process_start_2()
        {
            newprocess.StartInfo.FileName = "netsh";
            newprocess.StartInfo.Arguments = "wlan set hostednetwork mode=allow ssid=" + HotSpotName + " key=" + HotSpotPassword;
            try
            {
                using (Process execute = Process.Start(newprocess.StartInfo))
                {
                    execute.WaitForExit();
                    proccess_bar.Increment(25);
                    Process_start_3();
                }
            }
            catch
            {
                //nothing
            }
        }
        public void Process_start_3()
        {
            newprocess.StartInfo.FileName = "netsh";
            newprocess.StartInfo.Arguments = "wlan start hostednetwork";
            try
            {
                using (Process execute = Process.Start(newprocess.StartInfo))
                {
                    execute.WaitForExit();
                    int selectedIndex = 1;
                    var conn = virtualRouterHost.GetSharableConnections();
                    List<SharableConnection> listOfSharableConnections = conn.ToList();
                    virtualRouterHost.Start(listOfSharableConnections[selectedIndex]);
                    proccess_bar.Increment(25);
                    button_panel.Visible = true;
                    Play_Stop_button.Text = "Stop";
                    //SSID_textBox.Enabled = false;
                    //Password_textBox.Enabled = false;
                    //comboBox1.Enabled = false;
                    bgthread = new Thread(() => ConnectedPeersTracker());
                    bgthread.Start();
                }
            }
            catch
            {
                //nothing
            }
            proccess_bar.Visible = false;
            label3.Visible = false;
        }
        public void Process_stop()
        {
            newprocess.StartInfo.FileName = "netsh";
            newprocess.StartInfo.Arguments = "wlan stop hostednetwork";
            try
            {
                proccess_bar.Increment(50);
                using (Process execute = Process.Start(newprocess.StartInfo))
                {
                    execute.WaitForExit();
                    proccess_bar.Increment(50);
                    button_panel.Visible = true;
                    Play_Stop_button.Text = "Start";
                    //SSID_textBox.Enabled = true;
                    //Password_textBox.Enabled = true;
                    //comboBox1.Enabled = true;
                    bgthread.Abort();
                    AttendedStudents();
                }
            }
            catch
            {
                //nothing
            }
        }

        public async void ConnectedPeersTracker()
        {

            var clientCourseId = new HttpClient();
            HttpResponseMessage responseCourseId = await clientCourseId.GetAsync("http://localhost:43719/api/lessonTime/dateOnly/" + dateOnly + "/hourOnly/" + hourOnly);
            string strCourseId = await responseCourseId.Content.ReadAsStringAsync();
            int courseId = int.Parse(strCourseId);

            var peers = virtualRouterHost.GetConnectedPeers();
            while (true)
            {
                //label6.Text = "Peers Connected (" + peers.Count().ToString() + "):";
                foreach (var p in peers)
                {
                    if (courseId != -1)
                    {
                        var clientId = new HttpClient();
                        HttpResponseMessage responseId = await clientId.GetAsync("http://localhost:43719/api/member/Iduser/" + Mail + "/Idpassword/" + Password);
                        string stringId = await responseId.Content.ReadAsStringAsync();
                        int lecturerId = int.Parse(stringId);



                        var clientStudentId = new HttpClient();
                        HttpResponseMessage responseStudentId = await clientStudentId.GetAsync("http://localhost:43719/api/member/macAddress/" + p.MacAddress.ToString());
                        string strStudentId = await responseStudentId.Content.ReadAsStringAsync();
                        int studentId = int.Parse(strStudentId);

                        var clientExistStudent = new HttpClient();
                        HttpResponseMessage responseExistStudent = await clientExistStudent.GetAsync("http://localhost:43719/api/courseStudent/CheckIfExists/studentId/" + studentId + "/courseId/" + courseId) ;
                        string strExistStudent = await responseExistStudent.Content.ReadAsStringAsync();
                        bool existStudent = bool.Parse(strExistStudent);
                       
                            if (existStudent)
                        {
                            var clientLessonTimeId = new HttpClient();
                            HttpResponseMessage responseLessonTimeId = await clientLessonTimeId.GetAsync("http://localhost:43719/api/lessonTime/date/" + dateOnly + "/hour/" + hourOnly + "/Lecture/" + lecturerId);
                            string strLessonTimeId = await responseLessonTimeId.Content.ReadAsStringAsync();
                            int lessonTimeId = int.Parse(strLessonTimeId);

                            var clientLessonTime = new HttpClient();
                            HttpResponseMessage responseLessonTime = await clientLessonTime.GetAsync("http://localhost:43719/api/lessonTime/GetLessonTime/" + lessonTimeId);
                            string strLessonTime = await responseLessonTime.Content.ReadAsStringAsync();
                            string lessonTime = strLessonTime;
                            if(lessonTime.Contains("\""))
                                lessonTime = lessonTime.Substring(1, lessonTime.Length - 2);
                                
                                


                            var client1 = new HttpClient();
                            client1.DefaultRequestHeaders.Authorization = new AuthenticationHeaderValue("Bearer", Token);
                            var requestContent1 = new FormUrlEncodedContent(new[] {
                                new KeyValuePair<string, string>("StudentId", studentId.ToString()),
                                new KeyValuePair<string, string>("LessonId", lessonTimeId.ToString()),
                                new KeyValuePair<string, string>("CheckTimeStart", TimeSpan.Parse(hourOnly).ToString()),
                                new KeyValuePair<string, string>("CheckTimeEnd",lessonTime),
                                    });
                            HttpResponseMessage response1 = await client1.PostAsync(
                            "http://localhost:43719/api/lessonAttending",
                            requestContent1);
                        }

                    }
                }
                Thread.Sleep(200);
            }
        }

        private void Play_Stop_button_Click(object sender, EventArgs e)
        {
            virtualRouterHost = new VirtualRouterHost.VirtualRouterHost();
            connectedPeersList = new List<ConnectedPeer>();

            if (!IsUserAdminstrator())
            {
                MessageBox.Show("Run as Administrator", "Administrator Privilages Required", MessageBoxButtons.OK, MessageBoxIcon.Asterisk);
                System.Environment.Exit(0);
            }

            if (Play_Stop_button.Text == "Start")
            {
                button_panel.Visible = false;
                label3.Visible = true;
                Process_start_1();
            }
            else
            {
                button_panel.Visible = false;
                Process_stop();
            }
        }

        private void Disconnect_Click(object sender, EventArgs e)
        {
            Login lg = new Login();
            this.Hide();
            lg.ShowDialog();
        }

        private void ContinueLecturer_Click(object sender, EventArgs e)
        {
            HeadChoice hc = new HeadChoice(Hello, Mail, Password, Token, extime);
            this.Hide();
            hc.ShowDialog();
        }

        private void courseList_SelectedIndexChanged(object sender, EventArgs e)
        {

        }

        private void LessonsList_Click(object sender, EventArgs e)
        {

        }
    }
 }