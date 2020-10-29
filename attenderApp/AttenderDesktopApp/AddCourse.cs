using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Net.Http.Headers;
using System.Windows.Forms;

namespace AttenderDesktopApp
{
    public partial class AddCourse : Form
    {
        public string Token;
        public string Mail;
        public string Password;
        public DateTime extime;
        public string Hello;


        public AddCourse(string Hello, string Mail, string Password, string Token, DateTime time)
        {
            InitializeComponent();
            this.Token = Token;
            this.Mail = Mail;
            this.Password = Password;
            this.extime = time;
            this.Hello = Hello;
        }

        private async void loadLecturers()
        {
            lecturerList.Items.Clear();

            var clientId = new HttpClient();
            HttpResponseMessage responseId = await clientId.GetAsync("http://localhost:43719/api/member/Iduser/" + Mail + "/Idpassword/" + Password);
            string stringId = await responseId.Content.ReadAsStringAsync();
            int Id = int.Parse(stringId);

            var clientUniId = new HttpClient();
            HttpResponseMessage responseUnirId = await clientUniId.GetAsync("http://localhost:43719/api/memberRole/GetUniversityById/" + Id);
            string stringUniId = await responseUnirId.Content.ReadAsStringAsync();
            int uniId = int.Parse(stringUniId);

            List<string> lecturers = new List<string>();

            var clientLecturers = new HttpClient();
            HttpResponseMessage responseLecturers = await clientLecturers.GetAsync("http://localhost:43719/api/member/GetAllLecturers/" + uniId);
            string strLecturers = await responseLecturers.Content.ReadAsStringAsync();

            lecturers = ((strLecturers.Substring(1, strLecturers.Length - 2).Split(',')).ToList<string>());
            foreach (string item in lecturers)
            {
                lecturerList.Items.Add(item.Substring(1, item.Length - 2));
            }
        }

        private async void loadDepartments()
        {

            dp.Items.Clear();

            var clientId = new HttpClient();
            HttpResponseMessage responseId = await clientId.GetAsync("http://localhost:43719/api/member/Iduser/" + Mail + "/Idpassword/" + Password);
            string stringId = await responseId.Content.ReadAsStringAsync();
            int Id = int.Parse(stringId);

            var clientUniId = new HttpClient();
            HttpResponseMessage responseUnirId = await clientUniId.GetAsync("http://localhost:43719/api/memberRole/GetUniversityById/" + Id);
            string stringUniId = await responseUnirId.Content.ReadAsStringAsync();
            int uniId = int.Parse(stringUniId);



            List<string> departments = new List<string>();
            var clientDepartment = new HttpClient();
            HttpResponseMessage responseDepartment = await clientDepartment.GetAsync("http://localhost:43719/api/department/GetDepartments/" + uniId);
            string stringDepartment = await responseDepartment.Content.ReadAsStringAsync();
            

            departments = ((stringDepartment.Substring(1, stringDepartment.Length - 2).Split(',')).ToList<string>());
            foreach (string item in departments)
            {
                dp.Items.Add(item.Substring(1, item.Length - 2));
            }
        }

        private async void add_Click(object sender, EventArgs e)
        {
            var clientToken = new HttpClient();
            HttpResponseMessage responseToken = await clientToken.GetAsync("http://localhost:43719/api/register/token");
            string strToken = await responseToken.Content.ReadAsStringAsync();
            int ExpireToken = int.Parse(strToken);
            if (IsTokenValid(ExpireToken) > 0)
            {
                try
                {
                    string SelectedLecture = lecturerList.SelectedItem.ToString();
                    SelectedLecture = SelectedLecture.Substring(2, SelectedLecture.IndexOf(':') - 2);

                    string SelectedDepartment = dp.SelectedItem.ToString();
                    SelectedDepartment = SelectedDepartment.Substring(2, SelectedDepartment.IndexOf(':') - 2);

                    //MessageBox.Show(SelectedDepartment + " " + SelectedLecture);

                    var client1 = new HttpClient();
                    client1.DefaultRequestHeaders.Authorization = new AuthenticationHeaderValue("Bearer", Token);
                    var requestContent1 = new FormUrlEncodedContent(new[] {
                                    new KeyValuePair<string, string>("Name", CourseName.Text),
                                    new KeyValuePair<string, string>("Code", Code.Text),
                                    new KeyValuePair<string, string>("LectureId", SelectedLecture),
                                    new KeyValuePair<string, string>("DepartmentId", SelectedDepartment),
                                        });
                    HttpResponseMessage response1 = await client1.PostAsync(
                    "http://localhost:43719/api/course",
                     requestContent1);
                    if (response1.IsSuccessStatusCode)
                    {

                        MessageBox.Show("Success");
                        loadCourses();
                    }

                    else
                    {
                        throw new Exception();

                    }
                }
                catch
                {
                    MessageBox.Show("You must fill all credentials right");

                }
            }
            else
            {
                MessageBox.Show("The Token has EXPIRED - Please Reconnect");

            }
        }

        private void AddCourse_Load(object sender, EventArgs e)
        {
            loadDepartments();
            loadLecturers();
            loadCourses();
        }

        private void dp_SelectedIndexChanged(object sender, EventArgs e)
        {

        }
        private async void loadCourses()
        {
            courseList.Items.Clear();
            List<string> courses = new List<string>();

            var clientCourses = new HttpClient();
            HttpResponseMessage responseCourses = await clientCourses.GetAsync("http://localhost:43719/api/course/GetAllCourses/all/");
            string stringCourses = await responseCourses.Content.ReadAsStringAsync();


            courses = ((stringCourses.Substring(1, stringCourses.Length - 2).Split(',')).ToList<string>());
            foreach (string item in courses)
            {
                courseList.Items.Add(item.Substring(1, item.Length - 2));
            }
         }

        private void CDate_TextChanged(object sender, EventArgs e)
        {

        }

        private async void button1_Click(object sender, EventArgs e)
        {
            var clientToken = new HttpClient();
            HttpResponseMessage responseToken = await clientToken.GetAsync("http://localhost:43719/api/register/token");
            string strToken = await responseToken.Content.ReadAsStringAsync();
            int ExpireToken = int.Parse(strToken);
            if (IsTokenValid(ExpireToken) > 0)
            {
                try
                {
                    string SelectedCourse = courseList.SelectedItem.ToString();
                    SelectedCourse = SelectedCourse.Substring(2, SelectedCourse.IndexOf(':') - 2);

                    var client1 = new HttpClient();
                    client1.DefaultRequestHeaders.Authorization = new AuthenticationHeaderValue("Bearer", Token);
                    var requestContent1 = new FormUrlEncodedContent(new[] {
                                    new KeyValuePair<string, string>("CourseId", SelectedCourse),
                                    new KeyValuePair<string, string>("LessonDate", CDate.Text),
                                    new KeyValuePair<string, string>("StartTime", CStart.Text),
                                    new KeyValuePair<string, string>("EndTime", CEnd.Text),
                                    new KeyValuePair<string, string>("ActualStartTime", CStart.Text),
                                    new KeyValuePair<string, string>("ClassRoom", CRoom.Text),
                                        });
                    HttpResponseMessage response1 = await client1.PostAsync(
                    "http://localhost:43719/api/lessonTime",
                     requestContent1);
                    if (response1.IsSuccessStatusCode)
                    {
                        MessageBox.Show("Success");
                    }
                    else
                    {
                        throw new Exception();
                    }

                }
                catch
                {
                    MessageBox.Show("You must fill all credentials right");
                }
            }
            else
            {
                MessageBox.Show("The Token has EXPIRED - Please Reconnect");

            }
        }

        private int IsTokenValid(int ExpireToken)
        {
            string hour = DateTime.Now.ToString().Substring(11);

            DateTime a = extime.AddMinutes(ExpireToken);
            string extimeperiod = a.ToString().Substring(11);

            return (TimeSpan.Compare(TimeSpan.Parse(extimeperiod), TimeSpan.Parse(hour)));
        }

        private void BackToAdmin_Click(object sender, EventArgs e)
        {
            admin adm = new admin(Hello, Mail, Password, Token, extime);
            this.Hide();
            adm.ShowDialog();
        }
    }
}
