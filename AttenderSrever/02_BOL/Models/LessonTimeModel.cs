using _02_BOL.Validations;
using System;
using System.ComponentModel.DataAnnotations;

namespace _02_BOL
{
    public class LessonTimeModel
    {
        public int Id { get; set; }

        [DigitsOnly] 
        public int CourseId { get; set; }

        [Required]
        public DateTime LessonDate { get; set; }

        [Required]
        public TimeSpan StartTime { get; set; }

        [Required]
        public TimeSpan EndTime { get; set; }

        [Required]
        public TimeSpan? ActualStartTime { get; set; }

        [MaxLength(20)]
        public string ClassRoom { get; set; }
    }
}
