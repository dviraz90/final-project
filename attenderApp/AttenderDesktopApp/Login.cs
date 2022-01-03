using System;
using System.Net.Http;
using System.Collections.Generic;
using System.Text;
using System.Windows.Forms;
using System.IO;
using System.Security.Cryptography;

namespace AttenderDesktopApp
{
    public partial class Login : Form
    {
        public Login()
        {
            InitializeComponent();
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
        private void Form1_Load(object sender, EventArgs e)
        {

        }

        private async void button1_Click_1(object sender, EventArgs e)
        {
            string user = Email.Text;
            string password = Password.Text;
            string Token;
            password = ComputeSha256Hash(password);
            var client = new HttpClient();
            var requestContent = new FormUrlEncodedContent(new[] {
            new KeyValuePair<string, string>("username", user),
            new KeyValuePair<string, string>("password", password),
            new KeyValuePair<string, string>("grant_type", "password"),
                });
            try
            {
                HttpResponseMessage response = await client.PostAsync(
                "http://localhost:43719/login",
                 requestContent);
                HttpContent responseContent = response.Content;

                using (var reader = new StreamReader(await responseContent.ReadAsStreamAsync()))
                {
                    Token = (await reader.ReadToEndAsync());
                    Token = Token.Substring(17);
                    Token = Token.Substring(0, Token.Length - 41);
                }

                string Welcome = "Hello";

                if (Token != null)
                {
                    try
                    {
                        var client9 = new HttpClient();
                        HttpResponseMessage response9 = await client9.GetAsync("http://localhost:43719/api/member/user/" + user + "/password/" + password);
                        string Name = await response9.Content.ReadAsStringAsync();
                        Name = Name.Substring(1, Name.Length - 2);
                        Welcome += $" {Name} ";

                        DateTime time = DateTime.Now;

                        var client8 = new HttpClient();
                        HttpResponseMessage response8 = await client8.GetAsync("http://localhost:43719/api/member/Iduser/" + user + "/Idpassword/" + password);
                        string stringId = await response8.Content.ReadAsStringAsync();
                        int id = int.Parse(stringId);

                        var clientId = new HttpClient();
                        HttpResponseMessage responseId = await clientId.GetAsync("http://localhost:43719/api/memberRole/Roleid/" + id);
                        string role = await responseId.Content.ReadAsStringAsync();

                        if (role[1] == 'l')
                        {
                            MainPage fw = new MainPage(Welcome, user, password, Token, time);
                            this.Hide();
                            fw.ShowDialog();
                        }
                        if (role[1] == 'a')
                        {
                            admin ad = new admin(Welcome, user, password, Token, time);
                            this.Hide();
                            ad.ShowDialog();
                        }
                        if (role[1] == 'h')
                        {
                            HeadChoice hc = new HeadChoice(Welcome, user, password, Token, time);
                            this.Hide();
                            hc.ShowDialog();
                        }
                    }
                    catch
                    {
                        MessageBox.Show("Wrong credentials");
                    }
                }

                else
                {
                    MessageBox.Show("Mail or Password are Wrong!");
                }
            }
            catch
            {
                MessageBox.Show("Mail or Password are Wrong!");
            }
            
        }

        private void Password_TextChanged(object sender, EventArgs e)
        {
            Password.PasswordChar = '●';
        }
    }

}
