using System.ComponentModel.DataAnnotations;
using _02_BOL.Validations;

namespace _02_BOL
{
    public class MemberModel
    {
        public int Id { get; set; }

        [Id]
        public string PassportNumber { get; set; }

        [LettersOnly] [MaxLength(50)]
        public string FirstName { get; set; }

        [LettersOnly] [MaxLength(50)]
        public string LastName { get; set; }

        [Required] [MaxLength(64)] [MinLength(64)]
        public string Password { get; set; }

        [PhoneNumber]
        public string PhoneNumber { get; set; }

        [IsMacAddressValide]
        public string MacAddress { get; set; }

        [IsMailValide][MaxLength(50)]
        public string Mail { get; set; }
    }
}