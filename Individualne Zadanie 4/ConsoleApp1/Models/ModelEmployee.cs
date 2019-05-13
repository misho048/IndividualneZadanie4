using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Data.Models
{
     public class ModelEmployee
    {
        public int Id { get; set; }
        public string Title { get; set; }
        public string Name { get; set; }
        public string Surname { get; set; }
        public string PhoneNumber { get; set; } 
        public string Mail { get; set; }
        public int? DepartmentId { get; set; }
    }
}
