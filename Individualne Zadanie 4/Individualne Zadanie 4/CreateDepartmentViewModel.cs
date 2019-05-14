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
    class CreateDepartmentViewModel
    {
        private Logic.Logic _logic = new Logic.Logic(); 


        public ModelEmployee GetEmployee(int employeeId)
        {
            return RepositoryManager.RepositoryEmployee.GetEmployee(employeeId);
        }


        public bool CreateDepartment(string name,string code, int employeeId, 
            EnumDepartmentsType.DepartmentType departmentType,int? superiorDepartmentId)
        {

            return _logic.CreateDepartment(name, code, departmentType, employeeId, superiorDepartmentId);
        }


        public void SetDepartmentForEmployee(int employeeid, int departmentID)
        {
            RepositoryManager.RepositoryEmployee.SetDepartmentForEmployee(employeeid, departmentID);
        }


        public int GetLastAddedDepartmentId()
        {
            return RepositoryManager.RepositoryDepartment.GetLastAddedDepartmentId();
        }
    }
}
