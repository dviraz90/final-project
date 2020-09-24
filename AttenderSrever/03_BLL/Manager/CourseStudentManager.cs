using _01_DAL;
using _02_BOL;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _03_BLL
{
    public class CourseStudentManager
    {


        // Create;
        public bool AddCourseStudent(CourseStudentModel newCourseStudent)
        {
            using (AttenderEntities ef = new AttenderEntities())
            {
                CourseStudent courseStudents = new CourseStudent()
                {
                    //Id = newCourseStudent.Id,
                    StudentId = newCourseStudent.StudentId,
                    CourseId = newCourseStudent.CourseId
                };
                //ef.CourseStudents.Add(courseStudents);
                try
                {
                    ef.Database.ExecuteSqlCommand($"INSERT INTO [dbo].[CourseStudents] ([StudentId],[CourseId]) VALUES ({courseStudents.StudentId} , {courseStudents.CourseId})");
                    //ef.SaveChanges();
                }
                catch
                {
                    return false;
                }
            }
            return true;
        }
        //Read 
        public List<CourseStudentModel> GetAllCourseStudent()
        {
            List<CourseStudentModel> courseStudents = new List<CourseStudentModel>();
            using (AttenderEntities ef = new AttenderEntities())
            {
                foreach (CourseStudent item in ef.CourseStudents)
                {
                    courseStudents.Add(new CourseStudentModel()
                    {
                        Id = item.Id,
                        StudentId = item.StudentId,
                        CourseId = item.CourseId
                    });
                }
            }
            return courseStudents;
        }
        public CourseStudentModel GetCourseStudentById(int id)
        {
            CourseStudentModel courseStudents = null;
            using (AttenderEntities ef = new AttenderEntities())
            {
                CourseStudent item = ef.CourseStudents.FirstOrDefault(a => a.Id == id);
                if (item != null)
                {
                    courseStudents = new CourseStudentModel()
                    {
                        Id = item.Id,
                        StudentId = item.StudentId,
                        CourseId = item.CourseId
                    };
                }
            }
            return courseStudents;
        }

        // update 
        public bool UpdateCourseStudent(int id, CourseStudentModel courseStudents)
        {
            using (AttenderEntities ef = new AttenderEntities())
            {
                CourseStudent updateCourseStudents = ef.CourseStudents.FirstOrDefault(a => a.Id == id);
                if (updateCourseStudents == null) return false;

                updateCourseStudents.StudentId = courseStudents.StudentId;
                updateCourseStudents.CourseId = courseStudents.CourseId;
                try
                {
                    ef.Database.ExecuteSqlCommand($"UPDATE [dbo].[CourseStudents] SET [StudentId] = {updateCourseStudents.StudentId},[CourseId] = {updateCourseStudents.CourseId} WHERE [Id] = {id}");
                    //ef.SaveChanges();
                }
                catch
                {
                    return false;
                }
            }
            return true;
        }

        // delete
        public bool DeleteCourseStudent(int id)
        {
            using (AttenderEntities ef = new AttenderEntities())
            {
                CourseStudent deletedCourseStudents = ef.CourseStudents.FirstOrDefault(a => a.Id == id);
                if (deletedCourseStudents == null) return false;
                ef.CourseStudents.Remove(deletedCourseStudents);
                try
                {
                    ef.Database.ExecuteSqlCommand($"DELETE FROM [dbo].[CourseStudents] WHERE Id = {id}");
                    //ef.SaveChanges();
                }
                catch
                {
                    return false;
                }
            }
            return true;
        }


        //Read 
        public List<string> GetAllCurrentStudents(int courseId)
        {
            List<CourseStudentModel> courseStudents = new List<CourseStudentModel>();
            List<string> students = new List<string>();
            using (AttenderEntities ef = new AttenderEntities())
            {
                foreach (CourseStudent item in ef.CourseStudents)
                {
                    if (item.CourseId == courseId)
                    {
                        courseStudents.Add(new CourseStudentModel()
                        {
                            StudentId = item.StudentId,
                        });
                        students.Add(item.StudentId.ToString());
                    }
                }
            }
            return students;
        }

        public bool CheckIfExists(int studentId, int courseId)
        {
            using (AttenderEntities ef = new AttenderEntities())
            {
                CourseStudent item = ef.CourseStudents.FirstOrDefault(a => a.StudentId == studentId && a.CourseId == courseId);
                if (item != null)
                {
                    return true;
                }
            }
            return false;
        }


        public bool DeleteStudentFromAll(int studentId)
        {
            using (AttenderEntities ef = new AttenderEntities())
            {
                try
                {
                    ef.Database.ExecuteSqlCommand($"DELETE FROM [dbo].[CourseStudents] WHERE StudentId = {studentId}");
                }
                catch
                {
                    return false;
                }
            }
            return true;
        }

    }
}