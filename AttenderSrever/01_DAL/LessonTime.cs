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
    
    public partial class LessonTime
    {
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2214:DoNotCallOverridableMethodsInConstructors")]
        public LessonTime()
        {
            this.LessonAttendings = new HashSet<LessonAttending>();
        }
    
        public int Id { get; set; }
        public int CourseId { get; set; }
        public System.DateTime LessonDate { get; set; }
        public System.TimeSpan StartTime { get; set; }
        public System.TimeSpan EndTime { get; set; }
        public Nullable<System.TimeSpan> ActualStartTime { get; set; }
        public string ClassRoom { get; set; }
    
        public virtual Course Course { get; set; }
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<LessonAttending> LessonAttendings { get; set; }
    }
}
