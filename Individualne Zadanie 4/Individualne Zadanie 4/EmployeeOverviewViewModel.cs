using Data.Models;
using Data.Repositories;
using System.ComponentModel;

namespace Individualne_Zadanie_4
{
    class EmployeeOverviewViewModel
    {
        public BindingList<ModelEmployee> GetEmployeesInDepartment(int departmentId)
        {
            return new BindingList<ModelEmployee>(
                RepositoryManager.RepositoryEmployee.GetListOfEmployeesByDepartment(departmentId));
        }


        public void SetDepartmentForEmployee(int employeeId, int? departmentId)
        {
            RepositoryManager.RepositoryEmployee.SetDepartmentForEmployee(employeeId, departmentId);
        }


        public bool IsManager(int employeeId)
        {
            return RepositoryManager.RepositoryEmployee.IsManager(employeeId);
        }

    }
}
