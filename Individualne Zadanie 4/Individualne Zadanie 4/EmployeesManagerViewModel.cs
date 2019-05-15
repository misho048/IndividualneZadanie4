using Data.Models;
using Data.Repositories;
using System.ComponentModel;

namespace Individualne_Zadanie_4
{
    class EmployeesManagerViewModel
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

        public bool IsEmployeeManager (int employeeId)
        {
            return RepositoryManager.RepositoryEmployee.IsManager(employeeId);
        }
    }
}
