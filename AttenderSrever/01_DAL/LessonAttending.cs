//------------------------------------------------------------------------------
// <auto-generated>
//     This code was generated from a template.
//
//     Manual changes to this file may cause unexpected behavior in your application.
//     Manual changes to this file will be overwritten if the code is regenerated.
// </auto-generated>
//------------------------------------------------------------------------------

namespace _01_DAL
{
    using System;
    using System.Collections.Generic;
    
    public partial class LessonAttending
    {
        public int Id { get; set; }
        public int LessonId { get; set; }
        public int StudentId { get; set; }
        public System.TimeSpan CheckTimeStart { get; set; }
        public Nullable<System.TimeSpan> CheckTimeEnd { get; set; }
    
        public virtual LessonTime LessonTime { get; set; }
        public virtual Member Member { get; set; }
    }
}
