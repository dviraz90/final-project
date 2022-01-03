using _01_DAL;
using _02_BOL;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _03_BLL
{
    public class CourseManager
    {
        private LessonTimeManager LessonTimeBll = new LessonTimeManager();
        // Create;   
        public bool AddCourse(CourseModel newCourse)
        {
            using (AttenderEntities ef = new AttenderEntities())
            {
                Course course = new Course()
                {
                    //Id = newCourse.Id,
                    Name = newCourse.Name,
                    Code = newCourse.Code,
                    LectureId = newCourse.LectureId,
                    DepartmentId = newCourse.DepartmentId
                };
                ef.Courses.Add(course);
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
        public List<CourseModel> GetAllCourses()
        {
            List<CourseModel> courses = new List<CourseModel>();
            using (AttenderEntities ef = new AttenderEntities())
            {
                foreach (Course item in ef.Courses)
                {
                    courses.Add(new CourseModel()
                    {
                        Id = item.Id,
                        Name = item.Name,
                        Code = item.Code,
                        LectureId = item.LectureId,
                        DepartmentId = item.DepartmentId
                    });
                }
            }
            return courses;
        }
        public CourseModel GetCourseById(int id)
        {
            CourseModel course = null;
            using (AttenderEntities ef = new AttenderEntities())
            {
                Course item = ef.Courses.FirstOrDefault(a => a.Id == id);
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
                }
            }
            return course;
        }

        // update 
        public bool UpdateCourse(int id, CourseModel course)
        {
            using (AttenderEntities ef = new AttenderEntities())
            {
                Course updateCourse = ef.Courses.FirstOrDefault(a => a.Id == id);
                if (updateCourse == null) return false;

                //updateCourse.Id = course.Id;
                updateCourse.Name = course.Name;
                updateCourse.Code = course.Code;
                updateCourse.LectureId = course.LectureId;
                updateCourse.DepartmentId = course.DepartmentId;
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
        public bool DeleteCourse(int id)
        {
            using (AttenderEntities ef = new AttenderEntities())
            {
                Course deletedCourse = ef.Courses.FirstOrDefault(a => a.Id == id);
                if (deletedCourse == null) return false;
                ef.Courses.Remove(deletedCourse);
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

        //Get Courses By Lecturer Id
        public List<string> GetAllCourses(int id)
        {
            List<string> Courses = new List<string>();
            using (AttenderEntities ef = new AttenderEntities())
            {
                foreach (Course item in ef.Courses)
                {
                    if (item.LectureId == id)
                    {

                        Courses.Add(item.Id.ToString() + " " + item.Name);
                    }
                }
            }
            return Courses;
        }


        public string GetCourseNameById(int id, int lecturerId)
        {
            CourseModel course = null;
            using (AttenderEntities ef = new AttenderEntities())
            {
                Course item = ef.Courses.FirstOrDefault(a => a.Id == id && a.LectureId == lecturerId);
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
                }
            }
            return course.Name;
        }

        public int CheckIfLeccture(int LectureId, string date, string hour)
        {
            List<int> CourseIdis = new List<int>();
            CourseIdis = LessonTimeBll.GetAllLessonIdsNow(date, hour);

            List<CourseModel> courses = new List<CourseModel>();
            using (AttenderEntities ef = new AttenderEntities())
            {
                foreach(int CourseId in CourseIdis)
                {
                    foreach (Course item in ef.Courses)
                    {
                        if (CourseId == item.Id && LectureId == item.LectureId)
                            return CourseId;                   
                    }
                }
                
            }
            return 0;
        }

        public int CheckIfLecCourse(int courseId, int lecturerId)
        {
            using (AttenderEntities ef = new AttenderEntities())
            {
                Course item = ef.Courses.FirstOrDefault(a => a.Id == courseId && a.LectureId == lecturerId);
                if (item != null)
                {
                    return 1;
                }
            }
            return 0;
        }
        public List<string> GetAllCoursespp()
        {
            List<string> courses = new List<string>();
            using (AttenderEntities ef = new AttenderEntities())
            {
                foreach (Course item in ef.Courses)
                {
                    courses.Add("Id" + " " + item.Id + ":" + " " + item.Name);
                }
            }
            return courses;
        }
    }
}
