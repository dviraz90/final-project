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
    
    public partial class MemberRole
    {
        public int MemberId { get; set; }
        public int UniversityId { get; set; }
        public string Role { get; set; }
    
        public virtual Member Member { get; set; }
        public virtual University University { get; set; }
    }
}
