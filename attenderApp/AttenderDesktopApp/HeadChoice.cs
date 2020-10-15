using System;
using System.Net.Http;
using System.Windows.Forms;

namespace AttenderDesktopApp
{
    public partial class HeadChoice : Form
    {
        public string Token;
        public string Mail;
        public string Password;
        public DateTime extime;
        string Welcome = "Hello";
        public HeadChoice(string Hello, string Mail, string Password, string Token, DateTime time)
        {
            InitializeComponent();
            this.Token = Token;
            this.Mail = Mail;
            this.Password = Password;
            this.extime = time;
        }

        private async void lecturer_Click(object sender, EventArgs e)
        {
            var clientName = new HttpClient();
            HttpResponseMessage responseName = await clientName.GetAsync("http://localhost:43719/api/member/GetName/Mail/" + Mail + "/Password/" + Password);
            string stringName = await responseName.Content.ReadAsStringAsync();
            string Name = stringName;
            Name = Name.Substring(1, Name.Length - 2);
            Welcome += $" {Name} ";

            MainPage fw = new MainPage(Welcome, Mail, Password, Token, extime);
            this.Hide();
            fw.ShowDialog();
        }

        private async void admin_Click(object sender, EventArgs e)
        {
            var clientName = new HttpClient();
            HttpResponseMessage responseName = await clientName.GetAsync("http://localhost:43719/api/member/GetName/Mail/" + Mail + "/Password/" + Password);
            string stringName = await responseName.Content.ReadAsStringAsync();

            string Name = stringName;
            Name = Name.Substring(1, Name.Length - 2);
            Welcome += $" {Name} ";
            admin ad = new admin(Welcome, Mail, Password, Token, extime);
            this.Hide();
            ad.ShowDialog();
        }
    }
}
