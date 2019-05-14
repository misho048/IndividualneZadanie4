using Data.Models;
using Data.Repositories;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Individualne_Zadanie_4
{
    class EmployeesEditViewModel
    {
        private Logic.Logic _logic = new Logic.Logic();


        public BindingList<ModelEmployee> GetAllEmployees()
        {
            return new BindingList<ModelEmployee>(RepositoryManager.RepositoryEmployee.GetListOfEmployees());
        }


        public (string departmentName, string departmentCode) GetDepartmentNameByEmployee(int employee)
        {
            return RepositoryManager.RepositoryDepartment.GetDepartmentNameByEmployee(employee);
        }


        public BindingList<ModelEmployee> GetUnsignedEmployees()
        {
            return new BindingList<ModelEmployee>(_logic.GetUnsignedEmployees());
        }


        public bool DeteleEmployee(ModelEmployee employee)
        {
            return RepositoryManager.RepositoryEmployee.DeleteEmployee(employee.Id);
        }
    }
}
