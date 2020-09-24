using _02_BOL.Validations;
using System;
using System.ComponentModel.DataAnnotations;

namespace _02_BOL
{
    public class DepartmentModel
    {
        public int Id { get; set; }

        [LettersOnly][MaxLength(50)]  [MinLength(2)]
        public string Name { get; set; }

        [DigitsOnly] 
        public Nullable<int> DepartmentManager { get; set; }

        [DigitsOnly] 
        public int UniversityId { get; set; }
    }
}
