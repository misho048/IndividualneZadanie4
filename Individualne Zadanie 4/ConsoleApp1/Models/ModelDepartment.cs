using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Data.Models
{
    public class ModelDepartment
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string Code { get; set; }
        public EnumDepartmentsType.DepartmentType DepartmentType { get; set; }
        public int? SuperiorDepartment { get; set; }
        public int? ManagerEmployeeId { get; set; }

        public override string ToString()
        {

            return $"{Name} {Code}";
        }
    }
}
