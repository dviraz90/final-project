using _02_BOL.Validations;
using System;
using System.ComponentModel.DataAnnotations;

namespace _02_BOL
{
    public class CourseStudentModel
    {
        public int Id { get; set; }

        [DigitsOnly] 
        public int StudentId { get; set; }

        [DigitsOnly] 
        public Nullable<int> CourseId { get; set; }
    }
}
