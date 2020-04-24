using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _02_BOL
{
    public class LessomTimeModel
    {
        public int CourseId { get; set; }
        public System.DateTime LessonDate { get; set; }
        public System.TimeSpan StartTime { get; set; }
        public System.TimeSpan EndTime { get; set; }
        public Nullable<System.TimeSpan> ActualStartTime { get; set; }
        public string ClassRoom { get; set; }

    }
}
