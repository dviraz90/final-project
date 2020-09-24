using _01_DAL;
using _02_BOL;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _03_BLL
{
    public class LessonTimeManager
    {
        // Create;
        public bool AddLessonTime(LessonTimeModel newLessonTime)
        {
            using (AttenderEntities ef = new AttenderEntities())
            {
                LessonTime lessonTime = new LessonTime()
                {
                    //Id = newLessonTime.Id,
                    CourseId = newLessonTime.CourseId,
                    LessonDate = newLessonTime.LessonDate,
                    StartTime = newLessonTime.StartTime,
                    EndTime = newLessonTime.EndTime,
                    ActualStartTime = newLessonTime.ActualStartTime,
                    ClassRoom = newLessonTime.ClassRoom
                };
                ef.LessonTimes.Add(lessonTime);
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
        public List<LessonTimeModel> GetAllLessonTimes()
        {
            List<LessonTimeModel> lessonTimes = new List<LessonTimeModel>();
            using (AttenderEntities ef = new AttenderEntities())
            {
                foreach (LessonTime item in ef.LessonTimes)
                {
                    lessonTimes.Add(new LessonTimeModel()
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
            return lessonTimes;
        }
        public LessonTimeModel GetLessonTimeById(int id)
        {

            LessonTimeModel lessonTime = null;
            using (AttenderEntities ef = new AttenderEntities())
            {
                LessonTime item = ef.LessonTimes.FirstOrDefault(a => a.Id == id);
                if (item != null)
                {
                    lessonTime = new LessonTimeModel()
                    {
                        Id = item.Id,
                        CourseId = item.CourseId,
                        LessonDate = item.LessonDate,
                        StartTime = item.StartTime,
                        EndTime = item.EndTime,
                        ActualStartTime = item.ActualStartTime,
                        ClassRoom = item.ClassRoom
                    };
                }
            }
            return lessonTime;
        }


        // update 
        public bool UpdateLessonTime(int id, LessonTimeModel lessonTime)
        {
            using (AttenderEntities ef = new AttenderEntities())
            {
                LessonTime updateLessonTime = ef.LessonTimes.FirstOrDefault(a => a.Id == id);
                if (updateLessonTime == null) return false;

                //updateLessonTime.CourseId = lessonTime.CourseId;
                updateLessonTime.LessonDate = lessonTime.LessonDate;
                updateLessonTime.StartTime = lessonTime.StartTime;
                updateLessonTime.EndTime = lessonTime.EndTime;
                updateLessonTime.ActualStartTime = lessonTime.ActualStartTime;
                updateLessonTime.ClassRoom = lessonTime.ClassRoom;
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
        public bool DeleteLessonTime(int id)
        {
            using (AttenderEntities ef = new AttenderEntities())
            {
                LessonTime deletedLessonTime = ef.LessonTimes.FirstOrDefault(a => a.Id == id);
                if (deletedLessonTime == null) return false;
                ef.LessonTimes.Remove(deletedLessonTime);
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

        public string GetLessonDateByLessonId(int id)
        {
            LessonTimeModel lessonAttending = null;
            using (AttenderEntities ef = new AttenderEntities())
            {
                LessonTime item = ef.LessonTimes.FirstOrDefault(a => a.Id == id);
                if (item != null)
                {
                    lessonAttending = new LessonTimeModel()
                    {
                        Id = item.Id,
                        CourseId = item.CourseId,
                        LessonDate = item.LessonDate,
                        StartTime = item.StartTime,
                        EndTime = item.EndTime,
                        ActualStartTime = item.ActualStartTime,
                        ClassRoom = item.ClassRoom

                    };
                }
            }
            return lessonAttending.LessonDate.ToString();
        }

        public string GetLessonTimeByLessonId(int id)
        {
            LessonTimeModel lessonTime = null;
            using (AttenderEntities ef = new AttenderEntities())
            {
                LessonTime item = ef.LessonTimes.FirstOrDefault(a => a.Id == id);
                if (item != null)
                {
                    lessonTime = new LessonTimeModel()
                    {
                        Id = item.Id,
                        CourseId = item.CourseId,
                        LessonDate = item.LessonDate,
                        StartTime = item.StartTime,
                        EndTime = item.EndTime,
                        ActualStartTime = item.ActualStartTime,
                        ClassRoom = item.ClassRoom

                    };
                }
            }
            return lessonTime.EndTime.ToString();
        }


        public int CheckWhatLessonIsNow(string date, string hour)
        {
            LessonTimeModel lessonTime = null;
            DateTime rdate = DateTime.Parse(date);
            TimeSpan rhour = TimeSpan.Parse(hour);
            using (AttenderEntities ef = new AttenderEntities())
            {
                LessonTime item = ef.LessonTimes.FirstOrDefault(a => a.LessonDate == rdate
                && a.StartTime <= rhour && a.EndTime >= rhour);

                if (item != null)
                {
                    lessonTime = new LessonTimeModel()
                    {
                        Id = item.Id,
                        CourseId = item.CourseId,
                        LessonDate = item.LessonDate,
                        StartTime = item.StartTime,
                        EndTime = item.EndTime,
                        ActualStartTime = TimeSpan.Parse(hour),
                        ClassRoom = item.ClassRoom

                    };
                    return lessonTime.CourseId;
                }
            }
            return -1;
        }


        public int GetLessonCodeByLessonId(int id)
        {
            LessonTimeModel lessonTime = null;
            using (AttenderEntities ef = new AttenderEntities())
            {
                LessonTime item = ef.LessonTimes.FirstOrDefault(a => a.Id == id);
                if (item != null)
                {
                    lessonTime = new LessonTimeModel()
                    {
                        Id = item.Id,
                        CourseId = item.CourseId,
                        LessonDate = item.LessonDate,
                        StartTime = item.StartTime,
                        EndTime = item.EndTime,
                        ActualStartTime = item.ActualStartTime,
                        ClassRoom = item.ClassRoom

                    };
                }
            }
            return lessonTime.CourseId;
        }


        public int CheckLessonIdIsNow(string date, string hour, int lecturerId)
        {
            DateTime rdate = DateTime.Parse(date);
            TimeSpan rhour = TimeSpan.Parse(hour);
            List<int> lessonTimes = new List<int>();
            lessonTimes = GetAllLessonIdsNow(date, hour);

            foreach (int CourseId in lessonTimes)
            {
                int ans = CheckIfLecCourse(CourseId, lecturerId);
                if (ans == 1)
                {
                    using (AttenderEntities ef = new AttenderEntities())
                    {
                        LessonTime item = ef.LessonTimes.FirstOrDefault(a => a.LessonDate == rdate
                                        && a.StartTime <= rhour && a.EndTime >= rhour && a.CourseId == CourseId);
                        return item.Id;
                    }
                }
            }
            
            return -1;
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

        //Read 
        public List<int> GetAllLessonIdsNow(string date, string hour)
        {
            DateTime rdate = DateTime.Parse(date);
            TimeSpan rhour = TimeSpan.Parse(hour);
            List<int> lessonTimes = new List<int>();
            using (AttenderEntities ef = new AttenderEntities())
            {
                foreach (LessonTime item in ef.LessonTimes)
                {
                    if(item.LessonDate == rdate && item.StartTime <= rhour && item.EndTime>=rhour)
                        lessonTimes.Add(item.CourseId);
                }
            }
            return lessonTimes;
        }
    }
}