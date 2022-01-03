using _01_DAL;
using _02_BOL;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _03_BLL
{
    public class LessonAttendingManager
    {
        // Create;
        public bool AddLessonAttending(LessonAttendingModel newLessonAttending)
        {
            using (AttenderEntities ef = new AttenderEntities())
            {
                LessonAttending lessonAttending = new LessonAttending()
                {
                    //Id = newLessonAttending.Id,
                    LessonId = newLessonAttending.LessonId,
                    StudentId = newLessonAttending.StudentId,
                    CheckTimeStart = newLessonAttending.CheckTimeStart,
                    CheckTimeEnd = newLessonAttending.CheckTimeEnd

                };
                ef.LessonAttendings.Add(lessonAttending);

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
        public List<LessonAttendingModel> GetAllLessonAttending()
        {
            List<LessonAttendingModel> lessonAttendings = new List<LessonAttendingModel>();
            using (AttenderEntities ef = new AttenderEntities())
            {
                foreach (LessonAttending item in ef.LessonAttendings)
                {
                    lessonAttendings.Add(new LessonAttendingModel()
                    {
                        Id = item.Id,
                        LessonId = item.LessonId,
                        StudentId = item.StudentId,
                        CheckTimeStart = item.CheckTimeStart,
                        CheckTimeEnd = item.CheckTimeEnd
                    });
                }
            }
            return lessonAttendings;
        }

        public LessonAttendingModel GetLessonAttendingById(int id)
        {

            LessonAttendingModel lessonAttending = null;
            using (AttenderEntities ef = new AttenderEntities())
            {
                LessonAttending item = ef.LessonAttendings.FirstOrDefault(a => a.Id == id);
                if (item != null)
                {
                    lessonAttending = new LessonAttendingModel()
                    {
                        Id = item.Id,
                        LessonId = item.LessonId,
                        StudentId = item.StudentId,
                        CheckTimeStart = item.CheckTimeStart,
                        CheckTimeEnd = item.CheckTimeEnd

                    };
                }
            }
            return lessonAttending;
        }

        // update 

        public bool UpdateLessonAttending(int id, LessonAttendingModel lesoonAttending)
        {
            using (AttenderEntities ef = new AttenderEntities())
            {
                LessonAttending updateLessonAttending = ef.LessonAttendings.FirstOrDefault(a => a.Id == id);
                if (updateLessonAttending == null) return false;

                updateLessonAttending.LessonId = lesoonAttending.LessonId;
                updateLessonAttending.StudentId = lesoonAttending.StudentId;
                updateLessonAttending.CheckTimeStart = lesoonAttending.CheckTimeStart;
                updateLessonAttending.CheckTimeEnd = lesoonAttending.CheckTimeEnd;
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
        public bool DeleteLessonAttending(int id)
        {
            using (AttenderEntities ef = new AttenderEntities())
            {
                LessonAttending deletedLessonAttending = ef.LessonAttendings.FirstOrDefault(a => a.Id == id);
                if (deletedLessonAttending == null) return false;
                ef.LessonAttendings.Remove(deletedLessonAttending);
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
        public List<LessonAttendingModel> GetStudentsAttending(int lessonId)
        {
            List<LessonAttendingModel> lessonAttendings = new List<LessonAttendingModel>();
            using (AttenderEntities ef = new AttenderEntities())
            {
                foreach (LessonAttending item in ef.LessonAttendings)
                {
                    if (item.LessonId == lessonId)
                    {
                        lessonAttendings.Add(new LessonAttendingModel()
                        {
                            Id = item.Id,
                            LessonId = item.LessonId,
                            StudentId = item.StudentId,
                            CheckTimeStart = item.CheckTimeStart,
                            CheckTimeEnd = item.CheckTimeEnd
                        });
                    }

                }
            }
            return lessonAttendings;
        }

        public bool DeleteStudentFromAttending(int studentId)
        {
            using (AttenderEntities ef = new AttenderEntities())
            {
                try
                {
                    ef.Database.ExecuteSqlCommand($"DELETE FROM [dbo].[LessonAttending] WHERE StudentId = {studentId}");
                }
                catch
                {
                    return false;
                }
            }
            return true;
        }


        //Read 
        public List<int> GetStudentsAttendingpp(int lessonId)
        {
            List<int> idis = new List<int>();
            using (AttenderEntities ef = new AttenderEntities())
            {
                foreach (LessonAttending item in ef.LessonAttendings)
                {
                    if (item.LessonId == lessonId)
                    {
                        idis.Add(item.StudentId);                       
                    }

                }
            }
            return idis;
        }
    }
}