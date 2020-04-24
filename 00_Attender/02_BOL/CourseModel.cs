using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _02_BOL
{
   public class CourseModel
    {
        public string Name { get; set; }
        public string Code { get; set; }
        public int LectureId { get; set; }
        public int DepartmentId { get; set; }
    }
}
