using _02_BOL.Validations;
using System;
using System.ComponentModel.DataAnnotations;

namespace _02_BOL
{
    public class LessonAttendingModel
    {
        public int Id { get; set; }

        [DigitsOnly]
        public int LessonId { get; set; }

        [DigitsOnly] 
        public int StudentId { get; set; }

        //[Required]
        public System.TimeSpan CheckTimeStart { get; set; }

        //[Required]
        public Nullable<System.TimeSpan> CheckTimeEnd { get; set; }
    }
}
