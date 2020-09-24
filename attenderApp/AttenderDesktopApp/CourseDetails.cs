using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Net.Http.Headers;
using System.Windows.Forms;

namespace AttenderDesktopApp
{
    public partial class CourseDetails : Form
    {
        public string Token;
        public DateTime extime;
        List<string> list;

        public CourseDetails(List<string> list, string Token, DateTime time)
        {
            InitializeComponent();
            this.list = list;
            this.Token = Token;
            this.extime = time;
        }

        private void label1_Click(object sender, EventArgs e)
        {

        }

        private void checkedListBox1_SelectedIndexChanged(object sender, EventArgs e)
        {

        }

        private void CourseDetails_Load(object sender, EventArgs e)
        {
            foreach (string Item in list)
            {
                if (Item == "") break;
                CourseList.Items.Add(Item.Substring(1, Item.Length - 11));
            }
        }

        private async void InsertStudent(object sender, EventArgs e)
        {
            try
            {
                string SelectedItem = CourseList.SelectedItem.ToString();
                SelectedItem = SelectedItem.Substring(4);
                int index = SelectedItem.IndexOf(' ');
                SelectedItem = SelectedItem.Substring(0, index);

                string passport = ListCurrentStudents.SelectedItem.ToString();
                passport = passport.Substring(0, 9);

                var clientSpecifiedIde = new HttpClient();
                HttpResponseMessage responseSpecifiedId = await clientSpecifiedIde.GetAsync("http://localhost:43719/api/member/specified/" + passport);
                string strSpecifiedId = await responseSpecifiedId.Content.ReadAsStringAsync();
                int SpecifiedId = int.Parse(strSpecifiedId);

                // Checking if the time of adding attendance is valid
                DateTime date = DateTime.Now;
                string today = date.ToString();
                today = today.Substring(0, 10);
                string hour = DateTime.Now.ToString().Substring(11);

                var clientLessonDate = new HttpClient();
                HttpResponseMessage responseLessonDate = await clientLessonDate.GetAsync("http://localhost:43719/api/lessonTime/GetLessonDate/" + int.Parse(SelectedItem));
                string strLessonDate = await responseLessonDate.Content.ReadAsStringAsync();
                string lessonDate = strLessonDate;
                if (lessonDate.Contains("\""))
                    lessonDate = lessonDate.Substring(1, lessonDate.Length - 2);

                DateTime time = DateTime.Parse(today);
                DateTime EndTime = DateTime.Parse(lessonDate);

                int result = DateTime.Compare(DateTime.Parse(today), EndTime);

                // Need to Change to the oposite result < 0
                if (result < 0)
                    MessageBox.Show("Cannot insert attendance in the future");
                else
                {
                    var clientToken = new HttpClient();
                    HttpResponseMessage responseToken = await clientToken.GetAsync("http://localhost:43719/api/register/token");
                    string strToken = await responseToken.Content.ReadAsStringAsync();

                    int TokenResult = CheckTokenValidation(int.Parse(strToken));
                    if (TokenResult > 0)
                    {
                        var clientLessonTime = new HttpClient();
                        HttpResponseMessage responseLessonTime = await clientLessonTime.GetAsync("http://localhost:43719/api/lessonTime/GetLessonTime/" + int.Parse(SelectedItem));
                        string strLessonTime = await responseLessonTime.Content.ReadAsStringAsync();
                        string lessonTime = strLessonTime;
                        if (lessonTime.Contains("\""))
                            lessonTime = lessonTime.Substring(1, lessonTime.Length - 2);


                        var client1 = new HttpClient();
                        client1.DefaultRequestHeaders.Authorization = new AuthenticationHeaderValue("Bearer", Token);
                        var requestContent1 = new FormUrlEncodedContent(new[] {
                                new KeyValuePair<string, string>("StudentId", SpecifiedId.ToString()),
                                new KeyValuePair<string, string>("LessonId", SelectedItem),
                                new KeyValuePair<string, string>("CheckTimeStart", TimeSpan.Parse(hour).ToString()),
                                new KeyValuePair<string, string>("CheckTimeEnd",lessonTime),
                                    });
                        HttpResponseMessage response1 = await client1.PostAsync(
                        "http://localhost:43719/api/lessonAttending",
                         requestContent1);
                        if (response1.IsSuccessStatusCode)
                        {
                            MessageBox.Show("Success");
                            AttendedStudents();
                        }
                        else
                            MessageBox.Show("Failed");
                    }
                    else
                    {
                        MessageBox.Show("The Token has EXPIRED - Please Reconnect");

                    }
                }
            }
            catch
            {
                ////MessageBox.Show("You must Select a course and a student");
            }
        }
        public int CheckTokenValidation(int ExpireToken)
        {
            string hour = DateTime.Now.ToString().Substring(11);
            DateTime a = extime.AddMinutes(ExpireToken);
            string extimeperiod = a.ToString().Substring(11);
            return (TimeSpan.Compare(TimeSpan.Parse(extimeperiod), TimeSpan.Parse(hour)));
        }
        private async void LoadStudent(object sender, EventArgs e)
        {
            try
            {

                ListCurrentStudents.Items.Clear();
                string SelectedItem = CourseList.SelectedItem.ToString();
                SelectedItem = SelectedItem.Substring(4);
                int index = SelectedItem.IndexOf(' ');
                SelectedItem = SelectedItem.Substring(0, index);

                var clientLessonCode = new HttpClient();
                HttpResponseMessage responseLessonCode = await clientLessonCode.GetAsync("http://localhost:43719/api/lessonTime/GetLessonCode/" + int.Parse(SelectedItem));
                string strLessonCode = await responseLessonCode.Content.ReadAsStringAsync();
                int Code = int.Parse(strLessonCode);

                var clientCourseStudents = new HttpClient();
                HttpResponseMessage responseCourseStudents = await clientCourseStudents.GetAsync("http://localhost:43719/api/courseStudent/courseId/" + Code);
                string strCourseStudents = await responseCourseStudents.Content.ReadAsStringAsync();

                List<string> courseStudents = new List<string>();
                courseStudents = ((strCourseStudents.Substring(1, strCourseStudents.Length - 2).Split(',')).ToList<string>());

                foreach (string item in courseStudents)
                {
                    string tempItem = item.Substring(1, item.Length - 2);
                    int studentId = int.Parse(tempItem);

                    var clientstudentDetails = new HttpClient();
                    HttpResponseMessage responsestudentDetails = await clientstudentDetails.GetAsync("http://localhost:43719/api/member/studentId/" + studentId);
                    string strStudentDetails = await responsestudentDetails.Content.ReadAsStringAsync();
                    string studentDetails = strStudentDetails.Substring(1, strStudentDetails.Length - 2);
                    ListCurrentStudents.Items.Add(studentDetails);
                }
                AttendedStudents();
            }
            catch
            {
                MessageBox.Show("You must select one course to load");
            }
        }

        private void AttendedStudents_SelectedIndexChanged(object sender, EventArgs e)
        {

        }

        public async void AttendedStudents()
        {
            string SelectedItem = CourseList.SelectedItem.ToString();
            SelectedItem = SelectedItem.Substring(4);
            int index = SelectedItem.IndexOf(' ');
            SelectedItem = SelectedItem.Substring(0, index);

            Attended.Items.Clear();
            List<string> studentAttending = new List<string>();
            var clientList = new HttpClient();
            HttpResponseMessage responseList = await clientList.GetAsync("http://localhost:43719/api/lessonAttending/lessonId/" + int.Parse(SelectedItem));
            string strList = await responseList.Content.ReadAsStringAsync();
            if (!strList.Contains("[]"))
            {
                studentAttending = ((strList.Substring(1, strList.Length - 2).Split(',')).ToList<string>());

                foreach (string item in studentAttending)
                {

                    int studentId = int.Parse(item);


                    var clientstudentDetails = new HttpClient();
                    HttpResponseMessage responsestudentDetails = await clientstudentDetails.GetAsync("http://localhost:43719/api/member/studentId/" + studentId);
                    string strStudentDetails = await responsestudentDetails.Content.ReadAsStringAsync();
                    string studentDetails = strStudentDetails.Substring(1, strStudentDetails.Length - 2);

                    Attended.Items.Add(studentDetails);
                }
            }
        }
    }
}
