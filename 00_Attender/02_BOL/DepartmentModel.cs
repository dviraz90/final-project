using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _02_BOL
{
    public class DepartmentModel
    {
        public string Name { get; set; }
        public Nullable<int> DepartmentManager { get; set; }
        public int UniversityId { get; set; }
    }
}
