using _02_BOL.Validations;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _02_BOL
{
    public class CourseModel
    {
        public int Id { get; set; }

        [LettersOnly][MaxLength(50)] [MinLength(2)]
        public string Name { get; set; }

        [MaxLength(10)] [MinLength(2)]
        public string Code { get; set; }

        [DigitsOnly] 
        public int LectureId { get; set; }

        [DigitsOnly] 
        public int DepartmentId { get; set; }
    }
}
