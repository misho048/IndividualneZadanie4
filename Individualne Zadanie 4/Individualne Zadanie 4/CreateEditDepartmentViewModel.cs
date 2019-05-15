using Data.Models;
using Data.Repositories;

namespace Individualne_Zadanie_4
{
    class CreateEditDepartmentViewModel
    {
        private Logic.Logic _logic = new Logic.Logic();


        public ModelEmployee GetEmployee(int employeeId)
        {
            return RepositoryManager.RepositoryEmployee.GetEmployee(employeeId);
        }


        public bool CreateDepartment(string name, string code, int employeeId,
            EnumDepartmentsType.DepartmentType departmentType, int? superiorDepartmentId)
        {

            return _logic.CreateDepartment(name, code, departmentType, employeeId, superiorDepartmentId);
        }


        public bool UpdateDepartment(string name, string code, int? managerId,
            EnumDepartmentsType.DepartmentType departmentType, int? superiorDepartmentId, int id)
        {
            return _logic.UpdateDepartment(name, code, managerId, departmentType, superiorDepartmentId, id);
        }


        public void SetDepartmentForEmployee(int employeeid, int? departmentID)
        {
            RepositoryManager.RepositoryEmployee.SetDepartmentForEmployee(employeeid, departmentID);
        }


        public int GetLastAddedDepartmentId()
        {
            return RepositoryManager.RepositoryDepartment.GetLastAddedDepartmentId();
        }
    }
}
