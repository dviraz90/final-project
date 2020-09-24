using _02_BOL.Validations;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _02_BOL
{
    public class UniversityModel
    {
      
        public int Id { get; set; }

        [Required, MinLength(2), MaxLength(50)] [LettersOnly]
        public string Name { get; set; }

        [Required, MinLength(2), MaxLength(50)] [LettersOnly]
        public string Country { get; set; }

        [Required, MinLength(2), MaxLength(50)] [LettersOnly]
        public string City { get; set; }

        [Required, MinLength(2), MaxLength(50) ,LettersOnly]
        public string Address { get; set; }

        [Required, MinLength(4), MaxLength(9)] [DigitsOnly]
        
        public string Zip { get; set; }

        [Required, MinLength(4), MaxLength(50)] [LettersOnly]
        public string Site { get; set; }

        [Required] [PhoneNumber]
        public string PhoneNumber { get; set; }
    }
}
