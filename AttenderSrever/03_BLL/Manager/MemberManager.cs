using _02_BOL;
using System.Collections.Generic;
using System.Linq;
using System;
using System.Net.Mail;
using System.Net;
using System.Security.Cryptography;
using System.Text;
using _01_DAL;

namespace _03_BLL
{
    public class MemberManager
    {
        MemberModel member;
        CourseModel course;
        MemberRoleModel memberRole;
        MemberRoleManager memberRoleBll = new MemberRoleManager();
        // Create;
        public bool AddMember(MemberModel newMember)
        {
            using (AttenderEntities ef = new AttenderEntities())
            {
                Member member = new Member()
                {
                    //Id = newMember.Id,
                    PassportNumber = newMember.PassportNumber,
                    FirstName = newMember.FirstName,
                    LastName = newMember.LastName,
                    Password = newMember.Password,
                    PhoneNumber = newMember.PhoneNumber,
                    MacAddress = newMember.MacAddress,
                    Mail = newMember.Mail
                };
                ef.Members.Add(member);
                try
                {
                    ef.SaveChanges();
                }
                catch
                {
                    return false;
                }
            }
            return true;
        }

        //Read 
        public List<MemberModel> GetAllMembers()
        {
            List<MemberModel> members = new List<MemberModel>();
            using (AttenderEntities ef = new AttenderEntities())
            {
                foreach (Member item in ef.Members)
                {
                    members.Add(new MemberModel()
                    {
                        Id = item.Id,
                        PassportNumber = item.PassportNumber,
                        FirstName = item.FirstName,
                        LastName = item.LastName,
                        Password = item.Password,
                        PhoneNumber = item.PhoneNumber,
                        MacAddress = item.MacAddress,
                        Mail = item.Mail,
                    });
                }
            }
            return members;
        }
        public MemberModel GetMemberById(int id)
        {

            MemberModel member = null;
            using (AttenderEntities ef = new AttenderEntities())
            {
                Member item = ef.Members.FirstOrDefault(a => a.Id == id);
                if (item != null)
                {
                    member = new MemberModel()
                    {
                        Id = item.Id,
                        PassportNumber = item.PassportNumber,
                        FirstName = item.FirstName,
                        LastName = item.LastName,
                        Password = item.Password,
                        PhoneNumber = item.PhoneNumber,
                        MacAddress = item.MacAddress,
                        Mail = item.Mail
                    };
                }
            }
            return member;
        }



        // update 
        public bool UpdateMember(int id, MemberModel member)
        {
            using (AttenderEntities ef = new AttenderEntities())
            {
                Member updateMember = ef.Members.FirstOrDefault(a => a.Id == id);
                if (updateMember == null) return false;

                //updateMember.Id = member.Id;
                updateMember.PassportNumber = member.PassportNumber;
                updateMember.FirstName = member.FirstName;
                updateMember.LastName = member.LastName;
                updateMember.Password = member.Password;
                updateMember.PhoneNumber = member.PhoneNumber;
                updateMember.MacAddress = member.MacAddress;
                updateMember.Mail = member.Mail;
                try
                {
                    ef.SaveChanges();
                }
                catch
                {
                    return false;
                }
            }
            return true;
        }

        // delete
        public bool DeleteMember(int id)
        {
            using (AttenderEntities ef = new AttenderEntities())
            {
                Member deleteMember = ef.Members.FirstOrDefault(a => a.Id == id);
                if (deleteMember == null) return false;
                ef.Members.Remove(deleteMember);
                try
                {
                    ef.SaveChanges();
                }
                catch
                {
                    return false;
                }
            }
            return true;
        }


        // Checking validation of Mail & password
        public string CheckValidation(string Email, string Password)
        {
            using (AttenderEntities ef = new AttenderEntities())
            {
                Member item = ef.Members.FirstOrDefault(a => a.Mail == Email && a.Password == Password);
                if (item != null)
                {
                    member = new MemberModel()
                    {
                        Id = item.Id,
                        PassportNumber = item.PassportNumber,
                        FirstName = item.FirstName,
                        LastName = item.LastName,
                        Password = item.Password,
                        PhoneNumber = item.PhoneNumber,
                        MacAddress = item.MacAddress,
                        Mail = item.Mail
                    };
                }
                if (item != null)
                {
                    MemberRole item1 = ef.MemberRoles.FirstOrDefault(a => a.MemberId == member.Id);
                    if (item1 != null)
                    {
                        memberRole = new MemberRoleModel()
                        {
                            Id = item1.Id,
                            MemberId = item1.MemberId,
                            UniversityId = item1.UniversityId,
                            Role = item1.Role
                        };
                    }
                    return memberRole.Role;
                }
            }
            return null;
        }

        // recieving password and mail
        public string getPassAndMail(string Email, string Password)
        {
            string str = "";
            using (AttenderEntities ef = new AttenderEntities())
            {
                Member item = ef.Members.FirstOrDefault(a => a.Mail == Email && a.Password == Password);
                if (item != null)
                {
                    member = new MemberModel()
                    {
                        Id = item.Id,
                        PassportNumber = item.PassportNumber,
                        FirstName = item.FirstName,
                        LastName = item.LastName,
                        Password = item.Password,
                        PhoneNumber = item.PhoneNumber,
                        MacAddress = item.MacAddress,
                        Mail = item.Mail
                    };
                    str = item.Password;
                    str += item.Mail;
                }
            }
            return str;
        }

        // recieving name of person by mail & password
        public string getName(string Email, string Password)
        {
            using (AttenderEntities ef = new AttenderEntities())
            {
                Member item = ef.Members.FirstOrDefault(a => a.Mail == Email && a.Password == Password);
                if (item != null)
                {
                    member = new MemberModel()
                    {
                        Id = item.Id,
                        PassportNumber = item.PassportNumber,
                        FirstName = item.FirstName,
                        LastName = item.LastName,
                        Password = item.Password,
                        PhoneNumber = item.PhoneNumber,
                        MacAddress = item.MacAddress,
                        Mail = item.Mail
                    };
                    return member.FirstName;
                }
            }
            return null;
        }

        // Sending Mail by passportId
        public void SendMailsByPassportId(string passportId)
        {
            System.Net.Mail.MailMessage mailMessage = new System.Net.Mail.MailMessage();

            using (AttenderEntities ef = new AttenderEntities())
            {
                Member member = ef.Members.FirstOrDefault(a => a.PassportNumber == passportId);
                if (member != null)
                {
                    MemberRole role = ef.MemberRoles.FirstOrDefault(a => a.MemberId == member.Id);
                    if (role != null)
                    {
                        memberRole = new MemberRoleModel()
                        {
                            Id = role.Id,
                            MemberId = role.MemberId,
                            UniversityId = role.UniversityId,
                            Role = role.Role
                        };
                    }
                    if (role.Role == "s")
                    {
                        Random rnd = new Random();
                        int num = rnd.Next();
                        string res = num.ToString();
                        string hashedData = ComputeSha256Hash(res);

                        // updating password in the database with hashed password
                        UpdatePassword(member.Id, member, hashedData);

                        mailMessage.To.Add(member.Mail);
                        mailMessage.Subject = "Attender Registration";
                        mailMessage.Body = "Dear " + member.FirstName + " " + member.LastName + "," + Environment.NewLine +
                                            "Please follow the instructions and enter your credentials in the website bellow:"
                                            + Environment.NewLine + "Your disposable password is: " + res + Environment.NewLine + "http://localhost:43719/";

                        mailMessage.From = new MailAddress("attenderproject@gmail.com", "Attender App");

                        mailMessage.Attachments.Add(new System.Net.Mail.Attachment("C:\\Users\\barpi\\Desktop\\Attender\\Instrutions Finding Mac address.pdf"));

                        SmtpClient stmpMail = new SmtpClient();
                        stmpMail.Host = "smtp.gmail.com";
                        stmpMail.Credentials = new NetworkCredential("attenderproject@gmail.com", "Attender");
                        stmpMail.EnableSsl = true;
                        stmpMail.Port = 587;

                        try
                        {
                            stmpMail.Send(mailMessage);
                        }
                        catch (Exception ex)
                        {
                            Console.WriteLine(ex.Message.ToString());
                        }
                    }
                }

            }
        }


        // Sending Mails
        public void SendMails()
        {
            System.Net.Mail.MailMessage mailMessage = new System.Net.Mail.MailMessage();

            using (AttenderEntities ef = new AttenderEntities())
            {
                foreach (Member item in ef.Members)
                {
                    MemberRole role = ef.MemberRoles.FirstOrDefault(a => a.MemberId == item.Id);
                    if (role != null)
                    {
                        memberRole = new MemberRoleModel()
                        {
                            Id = role.Id,
                            MemberId = role.MemberId,
                            UniversityId = role.UniversityId,
                            Role = role.Role
                        };
                    }
                    if (role.Role == "s")
                    {
                        Random rnd = new Random();
                        int num = rnd.Next();
                        string res = num.ToString();
                        string hashedData = ComputeSha256Hash(res);

                        // updating password in the database with hashed password
                        UpdatePassword(item.Id, item, hashedData);

                        mailMessage.To.Add(item.Mail);
                        mailMessage.Subject = "Attender Registration";
                        mailMessage.Body = "Dear " + item.FirstName + " " + item.LastName + "," + Environment.NewLine +
                                            "Please follow the instructions and enter your credentials in the website bellow:"
                                            + Environment.NewLine + "Your disposable password is: " + res + Environment.NewLine + "http://localhost:43719/";

                        mailMessage.From = new MailAddress("attenderproject@gmail.com", "Attender App");

                        mailMessage.Attachments.Add(new System.Net.Mail.Attachment("C:\\Users\\barpi\\Desktop\\Attender\\Instrutions Finding Mac address.pdf"));

                        SmtpClient stmpMail = new SmtpClient();
                        stmpMail.Host = "smtp.gmail.com";
                        stmpMail.Credentials = new NetworkCredential("attenderproject@gmail.com", "Attender");
                        stmpMail.EnableSsl = true;
                        stmpMail.Port = 587;

                        try
                        {
                            stmpMail.Send(mailMessage);
                        }
                        catch (Exception ex)
                        {
                            Console.WriteLine(ex.Message.ToString());
                        }
                    }
                }
            }
        }

        // Creating SHA256 password
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

        // Updating password
        public bool UpdatePassword(int id, Member member, string password)
        {
            using (AttenderEntities ef = new AttenderEntities())
            {
                Member updateMember = ef.Members.FirstOrDefault(a => a.Id == id);
                if (updateMember == null) return false;

                updateMember.PassportNumber = member.PassportNumber;
                updateMember.FirstName = member.FirstName;
                updateMember.LastName = member.LastName;
                updateMember.Password = password;
                updateMember.PhoneNumber = member.PhoneNumber;
                updateMember.MacAddress = member.MacAddress;
                updateMember.Mail = member.Mail;
                try
                {
                    ef.SaveChanges();
                }
                catch
                {
                    return false;
                }
            }
            return true;
        }


        // Checking if registration is valid
        public bool CheckRegistration(string Passport, string Password, string Mac)
        {
            string hashedData = ComputeSha256Hash(Password);
            string disablePassword = ComputeSha256Hash("Used");

            using (AttenderEntities ef = new AttenderEntities())
            {
                Member updateMember = ef.Members.FirstOrDefault(a => a.PassportNumber == Passport && a.Password == hashedData);
                Member member = updateMember;
                if (updateMember != null)
                {
                    updateMember.PassportNumber = member.PassportNumber;
                    updateMember.FirstName = member.FirstName;
                    updateMember.LastName = member.LastName;
                    updateMember.Password = disablePassword;
                    updateMember.PhoneNumber = member.PhoneNumber;
                    updateMember.MacAddress = Mac;
                    updateMember.Mail = member.Mail;
                    try
                    {
                        ef.SaveChanges();
                        return true;
                    }
                    catch
                    {
                        return false;
                    }
                }
                else
                {
                    return false;
                }
            }
        }


        // recieving Id
        public int getId(string Email, string Password)
        {
            using (AttenderEntities ef = new AttenderEntities())
            {
                Member item = ef.Members.FirstOrDefault(a => a.Mail == Email && a.Password == Password);
                if (item != null)
                {
                    member = new MemberModel()
                    {
                        Id = item.Id,
                        PassportNumber = item.PassportNumber,
                        FirstName = item.FirstName,
                        LastName = item.LastName,
                        Password = item.Password,
                        PhoneNumber = item.PhoneNumber,
                        MacAddress = item.MacAddress,
                        Mail = item.Mail
                    };
                }
            }
            return member.Id;
        }

        // recieving course Id
        public int getCourseId(string Name)
        {
            using (AttenderEntities ef = new AttenderEntities())
            {
                Course item = ef.Courses.FirstOrDefault(a => a.Name == Name);
                if (item != null)
                {
                    course = new CourseModel()
                    {
                        Id = item.Id,
                        Name = item.Name,
                        Code = item.Code,
                        LectureId = item.LectureId,
                        DepartmentId = item.DepartmentId
                    };
                    return course.Id;
                }
            }
            return 0;
        }


        //Read 
        public List<LessonTimeModel> GetAllCourses(int id)
        {
            List<LessonTimeModel> courses = new List<LessonTimeModel>();
            using (AttenderEntities ef = new AttenderEntities())
            {
                foreach (LessonTime item in ef.LessonTimes)
                {
                    if (item.CourseId == id)
                    {
                        courses.Add(new LessonTimeModel()
                        {
                            Id = item.Id,
                            CourseId = item.CourseId,
                            LessonDate = item.LessonDate,
                            StartTime = item.StartTime,
                            EndTime = item.EndTime,
                            ActualStartTime = item.ActualStartTime,
                            ClassRoom = item.ClassRoom
                        });
                    }
                }
            }
            return courses;
        }
        // recieving Id by Passport Number
        public int getIdByPassport(string passport)
        {
            using (AttenderEntities ef = new AttenderEntities())
            {
                Member item = ef.Members.FirstOrDefault(a => a.PassportNumber == passport);
                if (item != null)
                {
                    member = new MemberModel()
                    {
                        Id = item.Id,
                        PassportNumber = item.PassportNumber,
                        FirstName = item.FirstName,
                        LastName = item.LastName,
                        Password = item.Password,
                        PhoneNumber = item.PhoneNumber,
                        MacAddress = item.MacAddress,
                        Mail = item.Mail
                    };
                }
            }
            return member.Id;
        }
        // recieving student Id by Mac address
        public int getStudentIdByMac(string mac)
        {
            using (AttenderEntities ef = new AttenderEntities())
            {
                Member item = ef.Members.FirstOrDefault(a => a.MacAddress == mac);
                if (item != null)
                {
                    member = new MemberModel()
                    {
                        Id = item.Id,
                        PassportNumber = item.PassportNumber,
                        FirstName = item.FirstName,
                        LastName = item.LastName,
                        Password = item.Password,
                        PhoneNumber = item.PhoneNumber,
                        MacAddress = item.MacAddress,
                        Mail = item.Mail
                    };
                }
            }
            return member.Id;
        }

        public string GetMemberInfoById(int id)
        {
            MemberModel member = null;
            using (AttenderEntities ef = new AttenderEntities())
            {
                Member item = ef.Members.FirstOrDefault(a => a.Id == id);
                if (item != null)
                {
                    member = new MemberModel()
                    {
                        Id = item.Id,
                        PassportNumber = item.PassportNumber,
                        FirstName = item.FirstName,
                        LastName = item.LastName,
                        Password = item.Password,
                        PhoneNumber = item.PhoneNumber,
                        MacAddress = item.MacAddress,
                        Mail = item.Mail
                    };
                    return member.FirstName + " " + member.LastName + " " + member.PassportNumber;
                }
            }
            return "No person";
        }


        //Read 
        public List<string> GetAllCoursesIdName(int id)
        {
            List<string> courses = new List<string>();
            using (AttenderEntities ef = new AttenderEntities())
            {
                foreach (LessonTime item in ef.LessonTimes)
                {
                    if (item.CourseId == id)
                    {
                        courses.Add("Id: " + item.Id + " Date: " + item.LessonDate);                         
                    }
                }
            }
            return courses;
        }
        public string GetMemberDetailsById(int id)
        {

            MemberModel member = null;
            using (AttenderEntities ef = new AttenderEntities())
            {
                Member item = ef.Members.FirstOrDefault(a => a.Id == id);
                if (item != null)
                {
                    member = new MemberModel()
                    {
                        Id = item.Id,
                        PassportNumber = item.PassportNumber,
                        FirstName = item.FirstName,
                        LastName = item.LastName,
                        Password = item.Password,
                        PhoneNumber = item.PhoneNumber,
                        MacAddress = item.MacAddress,
                        Mail = item.Mail
                    };
                }
            }
            return $"{member.PassportNumber}" + " " + $"{member.FirstName}" + " " + $"{member.LastName}";

        }
        // Gets list of students
        public List<string> GetAllStudents(int uni)
        {
            List<string> members = new List<string>();
            using (AttenderEntities ef = new AttenderEntities())
            {
                foreach (Member item in ef.Members)
                {
                    string role = memberRoleBll.GetRoleById(item.Id);
                    int uniId = memberRoleBll.GetUniversityById(item.Id);
                    if (role == "s" && uniId == uni)
                    {
                        members.Add("Id" + " " + item.Id + ":" + " " + item.FirstName + " " + item.LastName);
                    }

                }
            }
            return members;
        }

        // Gets list of lecturers
        public List<string> GetAllLecturers(int uni)
        {
            List<string> members = new List<string>();
            using (AttenderEntities ef = new AttenderEntities())
            {
                foreach (Member item in ef.Members)
                {
                    string role = memberRoleBll.GetRoleById(item.Id);
                    int uniId = memberRoleBll.GetUniversityById(item.Id);
                    if ((role == "l" || role == "h") && uniId == uni)
                    {
                        members.Add("Id" + " " + item.Id + ":" + " " + item.FirstName + " " + item.LastName);
                    }

                }
            }
            return members;
        }
    }
}