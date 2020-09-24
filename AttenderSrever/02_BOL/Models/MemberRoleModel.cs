using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.ComponentModel.DataAnnotations;
using System.Threading.Tasks;
using _02_BOL.Validations;

namespace _02_BOL
{
    public class MemberRoleModel
    {       
        public int Id { get; set; }

        [Required] [DigitsOnly]
        public int MemberId { get; set; }

        [Required] [DigitsOnly]
        public int UniversityId { get; set; }

        [Required]
        public string Role { get; set; }
    }
}
