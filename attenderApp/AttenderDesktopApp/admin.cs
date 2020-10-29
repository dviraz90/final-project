using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Net.Http.Headers;
using System.Security.Cryptography;
using System.Text;
using System.Text.RegularExpressions;
using System.Windows.Forms;

namespace AttenderDesktopApp
{
    public partial class admin : Form
    {
        public string Token;
        public string Mail;
        public string Password;
        public DateTime extime;
        public string Hello;

        public admin(string Hello, string Mail, string Password, string Token, DateTime time)
        {
            InitializeComponent();
            this.Token = Token;
            this.Mail = Mail;
            this.Password = Password;
            this.extime = time;
            this.Hello = Hello;
            Welcome.Text = Hello + "Wellcome To attender App - Admin";
        }

        private async void Add_Click(object sender, EventArgs e)
        {
            var clientToken = new HttpClient();
            HttpResponseMessage responseToken = await clientToken.GetAsync("http://localhost:43719/api/register/token");
            string strToken = await responseToken.Content.ReadAsStringAsync();

            if (IsTokenValid(strToken) > 0)
            {
                try
                {
                    var clientPassportValidation = new HttpClient();
                    HttpResponseMessage responsePassportValidation = await clientPassportValidation.GetAsync("http://localhost:43719/api/member/GetpassportValidation/" + Passport.Text);
                    string stringPassportValidation = await responsePassportValidation.Content.ReadAsStringAsync();
                    bool passportValidation = bool.Parse(stringPassportValidation);

                    var clientMailValidation = new HttpClient();
                    HttpResponseMessage responseMailValidation = await clientMailValidation.GetAsync("http://localhost:43719/api/member/GetMailtValidation/" + Doal.Text);
                    string stringMailValidation = await responsePassportValidation.Content.ReadAsStringAsync();
                    bool mailValidation = bool.Parse(stringMailValidation);

                    var clientLettersValidationFirst = new HttpClient();
                    HttpResponseMessage responseLettersValidationFirst = await clientLettersValidationFirst.GetAsync("http://localhost:43719/api/member/GetLettersValidation/first/" + First.Text);
                    string stringLettersValidationFirst = await responseLettersValidationFirst.Content.ReadAsStringAsync();
                    bool first = bool.Parse(stringLettersValidationFirst);

                    var clientLettersValidationLast = new HttpClient();
                    HttpResponseMessage responseLettersValidationLast = await clientLettersValidationLast.GetAsync("http://localhost:43719/api/member/GetLettersValidation/last/" + Last.Text);
                    string stringLettersValidationLast = await responseLettersValidationLast.Content.ReadAsStringAsync();
                    bool last = bool.Parse(stringLettersValidationLast);

                    if (passportValidation && mailValidation && first
                        && last && CheckPhone(Phone.Text) && (type.Text == "s" || type.Text == "l"))
                    {
                        var client = new HttpClient();
                        client.DefaultRequestHeaders.Authorization = new AuthenticationHeaderValue("Bearer", Token);

                        var requestContent = new FormUrlEncodedContent(new[] {
                            new KeyValuePair<string, string>("PassportNumber", Passport.Text),
                            new KeyValuePair<string, string>("FirstName", First.Text),
                            new KeyValuePair<string, string>("LastName", Last.Text),
                            new KeyValuePair<string, string>("Password", ComputeSha256Hash(Pass.Text)),
                            new KeyValuePair<string, string>("PhoneNumber", Phone.Text),
                            new KeyValuePair<string, string>("MacAddress", "11:22:33:44:55:66"),
                            new KeyValuePair<string, string>("Mail", Doal.Text),
                                });

                        HttpResponseMessage response = await client.PostAsync(
                            "http://localhost:43719/api/member",
                             requestContent);
                        HttpContent responseContent = response.Content;

                        // If added member successfully
                        if (response.IsSuccessStatusCode)
                        {
                            var clientMemberId = new HttpClient();
                            HttpResponseMessage responseMemberId = await clientMemberId.GetAsync("http://localhost:43719/api/member/GetIdByPassport/" + Passport.Text);
                            string stringMemberId = await responseMemberId.Content.ReadAsStringAsync();
                            int memberId = int.Parse(stringMemberId);

                            var clientId = new HttpClient();
                            HttpResponseMessage responseId = await clientId.GetAsync("http://localhost:43719/api/member/Iduser/" + Mail + "/Idpassword/" + Password);
                            string stringId = await responseId.Content.ReadAsStringAsync();
                            int Id = int.Parse(stringId);

                            var clientUniId = new HttpClient();
                            HttpResponseMessage responseUnirId = await clientUniId.GetAsync("http://localhost:43719/api/memberRole/GetUniversityById/" + Id);
                            string stringUniId = await responseUnirId.Content.ReadAsStringAsync();
                            int uniId = int.Parse(stringUniId);

                            var client1 = new HttpClient();
                            client1.DefaultRequestHeaders.Authorization = new AuthenticationHeaderValue("Bearer", Token);
                            var requestContent1 = new FormUrlEncodedContent(new[] {
                            new KeyValuePair<string, string>("MemberId", memberId.ToString()),
                            new KeyValuePair<string, string>("UniversityId", uniId.ToString()),
                            new KeyValuePair<string, string>("Role", type.Text),
                                });
                            HttpResponseMessage response1 = await client1.PostAsync(
                            "http://localhost:43719/api/memberRole",
                             requestContent1);
                            if (response1.IsSuccessStatusCode)
                            {
                                var client2 = new HttpClient();
                                client2.DefaultRequestHeaders.Authorization = new AuthenticationHeaderValue("Bearer", Token);
                                var requestContent2 = new FormUrlEncodedContent(new[] {
                                new KeyValuePair<string, string>("0","0"),
                                    });
                                HttpResponseMessage response2 = await client.PostAsync(
                                "http://localhost:43719/api/member/mail/passport/" + Passport.Text,
                                 requestContent2);
                                loadStudents();
                                loadLecturers();
                                MessageBox.Show("Added successfully.");
                            }
                        }
                    }
                    else
                        MessageBox.Show("One or more credentials are wrong ");
                }
                catch
                {
                    MessageBox.Show("One or more credentials are wrong ");
                }
            }
            else
            {
                MessageBox.Show("The Token has EXPIRED - Please Reconnect");
            }

        }

        private async void admin_Load(object sender, EventArgs e)
        {
            var clientId = new HttpClient();
            HttpResponseMessage responseId = await clientId.GetAsync("http://localhost:43719/api/member/Iduser/" + Mail + "/Idpassword/" + Password);
            string stringId = await responseId.Content.ReadAsStringAsync();
            int id = int.Parse(stringId);

            var clientRole = new HttpClient();
            HttpResponseMessage responseRole = await clientRole.GetAsync("http://localhost:43719/api/memberRole/Roleid/" + id);
            string stringRole = await responseRole.Content.ReadAsStringAsync();
            string role = stringRole;
            role = role.Substring(1, role.Length - 2);

            if (role == "h")
                ContinueLecturer.Visible = true;
            loadStudents();
            loadLecturers();
            loadCourses();
        }
        private async void loadStudents()
        {
            studentList.Items.Clear();

            var clientId = new HttpClient();
            HttpResponseMessage responseId = await clientId.GetAsync("http://localhost:43719/api/member/Iduser/" + Mail + "/Idpassword/" + Password);
            string stringId = await responseId.Content.ReadAsStringAsync();
            int Id = int.Parse(stringId);

            var clientUniId = new HttpClient();
            HttpResponseMessage responseUnirId = await clientUniId.GetAsync("http://localhost:43719/api/memberRole/GetUniversityById/" + Id);
            string stringUniId = await responseUnirId.Content.ReadAsStringAsync();
            int uniId = int.Parse(stringUniId);




            List<string> students = new List<string>();

            var clientStudents = new HttpClient();
            HttpResponseMessage responseStudents = await clientStudents.GetAsync("http://localhost:43719/api/member/GetAllStudents/" + uniId);
            string strStudents = await responseStudents.Content.ReadAsStringAsync();

            students = ((strStudents.Substring(1, strStudents.Length - 2).Split(',')).ToList<string>());


            foreach (string item in students)
            {
                studentList.Items.Add(item.Substring(1, item.Length - 2));
            }
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

        private async void loadCourses()
        {
            courseList.Items.Clear();
            List<string> courses = new List<string>();
            var clientAllCourses = new HttpClient();
            HttpResponseMessage responseAllCourses = await clientAllCourses.GetAsync("http://localhost:43719/api/course/GetAllCourses/all");
            string strAllCourses = await responseAllCourses.Content.ReadAsStringAsync();

            courses = ((strAllCourses.Substring(1, strAllCourses.Length - 2).Split(',')).ToList<string>());

            foreach (string item in courses)
            {
                courseList.Items.Add(item.Substring(1, item.Length - 2));
            }
        }

        private async void Delete_Student(object sender, EventArgs e)
        {
            var clientToken = new HttpClient();
            HttpResponseMessage responseToken = await clientToken.GetAsync("http://localhost:43719/api/register/token");
            string strToken = await responseToken.Content.ReadAsStringAsync();
            if (IsTokenValid(strToken) > 0)
            {
                try
                {
                    string SelectedItem = studentList.SelectedItem.ToString();
                    SelectedItem = SelectedItem.Substring(2, SelectedItem.IndexOf(':') - 2);

                    int memberId = Int32.Parse(SelectedItem);
                    string role = "s";

                    var clientId = new HttpClient();
                    HttpResponseMessage responseId = await clientId.GetAsync("http://localhost:43719/api/memberRole/GetIdByMemberId/memberId/" + memberId + "/role/" + role);
                    string strId = await responseId.Content.ReadAsStringAsync();
                    int id = int.Parse(strId);

                    var client = new HttpClient();
                    client.DefaultRequestHeaders.Authorization = new AuthenticationHeaderValue("Bearer", Token);
                    HttpResponseMessage response = await client.DeleteAsync(
                        "http://localhost:43719/api/memberRole/id/" + id);

                    if (response.IsSuccessStatusCode)
                    {
                        var clientDeleteFromAll = new HttpClient();
                        HttpResponseMessage responseDeleteFromAll = await clientDeleteFromAll.DeleteAsync("http://localhost:43719/api/courseStudent/DeleteStudentFromAll/" + memberId);
                        string strDeleteFromAll = await responseDeleteFromAll.Content.ReadAsStringAsync();
                        bool deleteFromAll = bool.Parse(strDeleteFromAll);

                        var clientDeleteAttending = new HttpClient();
                        HttpResponseMessage responseDeleteAttending = await clientDeleteFromAll.DeleteAsync("http://localhost:43719/api/lessonAttending/DeleteAttending/" + memberId);
                        string strDeleteAttending = await responseDeleteAttending.Content.ReadAsStringAsync();
                        bool deleteAttending = bool.Parse(strDeleteAttending);

                        if (deleteFromAll && deleteAttending)
                        {
                            var client1 = new HttpClient();
                            client1.DefaultRequestHeaders.Authorization = new AuthenticationHeaderValue("Bearer", Token);
                            HttpResponseMessage response1 = await client1.DeleteAsync(
                                "http://localhost:43719/api/member/id/" + memberId);
                            if (response1.IsSuccessStatusCode)
                            {
                                MessageBox.Show("Deleted succesfully");
                                loadStudents();
                            }
                        }
                    }
                }
                catch
                {
                    MessageBox.Show("You must select a student to delete");

                }
            }
            else
            {
                MessageBox.Show("The Token has EXPIRED - Please Reconnect");
            }

        }
        private int IsTokenValid(string strToken)
        {
            string hour = DateTime.Now.ToString().Substring(11);

            int ExpireToken = int.Parse(strToken);
            DateTime a = extime.AddMinutes(ExpireToken);
            string extimeperiod = a.ToString().Substring(11);

            return (TimeSpan.Compare(TimeSpan.Parse(extimeperiod), TimeSpan.Parse(hour)));
        }
        static string ComputeSha256Hash(string rawData)
        {
            // Create a SHA256   
            using (SHA256 sha256Hash = SHA256.Create())
            {
                // ComputeHash - returns byte array  
                byte[] bytes = sha256Hash.ComputeHash(Encoding.UTF8.GetBytes(rawData));

                // Convert byte array to a string   
                StringBuilder builder = new StringBuilder();
                for (int i = 0; i < bytes.Length; i++)
                {
                    builder.Append(bytes[i].ToString("x2"));
                }
                return builder.ToString();
            }
        }
        private bool CheckPhone(string value)
        {
            string input = value.ToString();
            string pattern = @"^(05[0-9])[0-9]{7}|(0[1-9])[0-9]{7}|1800[0-9]{6}$";
            Match match = Regex.Match(input, pattern);
            if (match.Success) return true;
            return false;
        }

        private async void connect_Students_To_Course(object sender, EventArgs e)
        {
            var clientToken = new HttpClient();
            HttpResponseMessage responseToken = await clientToken.GetAsync("http://localhost:43719/api/register/token");
            string strToken = await responseToken.Content.ReadAsStringAsync();

            if (IsTokenValid(strToken) > 0)
            {
                try
                {
                    string courseId = courseList.SelectedItem.ToString();
                    courseId = courseId.Substring(2, courseId.IndexOf(':') - 2);
                    int course = int.Parse(courseId);

                    string studentId = studentList.SelectedItem.ToString();
                    studentId = studentId.Substring(2, studentId.IndexOf(':') - 2);
                    int student = int.Parse(studentId);

                    var clientCheckIfExists = new HttpClient();
                    HttpResponseMessage responseCheckIfExists = await clientCheckIfExists.GetAsync("http://localhost:43719/api/courseStudent/CheckIfExists/studentId/" + student + "/courseId/" + course);
                    string strCheckIfExists = await responseCheckIfExists.Content.ReadAsStringAsync();
                    bool exists = true;
                    if (!responseCheckIfExists.IsSuccessStatusCode)
                        if (strCheckIfExists == "") exists = false;





                    if (!exists)
                    {
                        var client = new HttpClient();
                        client.DefaultRequestHeaders.Authorization = new AuthenticationHeaderValue("Bearer", Token);

                        var requestContent = new FormUrlEncodedContent(new[] {
                            new KeyValuePair<string, string>("StudentId", studentId),
                            new KeyValuePair<string, string>("CourseId", courseId),
                                });
                        HttpResponseMessage response = await client.PostAsync(
                            "http://localhost:43719/api/courseStudent",
                             requestContent);
                        HttpContent responseContent = response.Content;
                        if (response.IsSuccessStatusCode)
                            MessageBox.Show("Connected succesfully");
                    }
                    else
                        MessageBox.Show("The student is allready connected to the course");
                }
                catch
                {
                    MessageBox.Show("You must Choose a course and a student");

                }
                //MessageBox.Show("Course: " + courseId + " Student: " + studentId);
            }
            else
            {
                MessageBox.Show("The Token has EXPIRED - Please Reconnect");
            }
        }

        private void ReConnect_Click(object sender, EventArgs e)
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

        private void AddCourse_Click(object sender, EventArgs e)
        {
            AddCourse ac = new AddCourse(Hello, Mail, Password, Token, extime);
            this.Hide();
            ac.ShowDialog();
        }
    }
}