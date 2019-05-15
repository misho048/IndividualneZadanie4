using Data.Models;
using Data.Repositories;
using System.Collections.Generic;

namespace Logic
{
    public class Logic
    {
        public bool CreateEmployee(string title, string name, string surname, string phoneNumber, string email, int? departmentId)
        {
            ModelEmployee employee = new ModelEmployee
            {
                Title = title,
                Name = name,
                Surname = surname,
                PhoneNumber = phoneNumber,
                Email = email,
                DepartmentId = departmentId
            };

            return RepositoryManager.RepositoryEmployee.CreateEmployee(employee);

        }


        public List<ModelEmployee> GetUnsignedEmployees()
        {
            List<ModelEmployee> myEntryList = new List<ModelEmployee>(RepositoryManager.RepositoryEmployee.GetListOfEmployees());
            List<ModelEmployee> ret = new List<ModelEmployee>();
            foreach (var item in myEntryList)
            {
                if (item.DepartmentId == null)
                {
                    ret.Add(item);
                }
            }
            return ret;

        }


        public bool UpdateEmployee(string title, string name, string surname, string phoneNumber, string email, int? departmentId, int id)
        {
            ModelEmployee employee = new ModelEmployee
            {
                Title = title,
                Name = name,
                Surname = surname,
                PhoneNumber = phoneNumber,
                Email = email,
                DepartmentId = departmentId,
                Id = id
            };



            return RepositoryManager.RepositoryEmployee.UpdateEmployee(employee);

        }


        public bool CreateDepartment(string name, string code, EnumDepartmentsType.DepartmentType departmentType,
            int? managerId, int? superiorDepartmentId)
        {
            ModelDepartment department = new ModelDepartment
            {
                Name = name,
                Code = code,
                SuperiorDepartmentId = superiorDepartmentId,
                ManagerEmployeeId = managerId,
                DepartmentType = departmentType
            };


            return RepositoryManager.RepositoryDepartment.CreateDepartment(department);

        }


        public bool UpdateDepartment(string name, string code, int? managerId, EnumDepartmentsType.DepartmentType departmentType,
            int? superiorDepartmentId, int id)
        {
            ModelDepartment department = new ModelDepartment
            {
                Id = id,
                Name = name,
                Code = code,
                SuperiorDepartmentId = superiorDepartmentId,
                ManagerEmployeeId = managerId,
                DepartmentType = departmentType
            };
            return RepositoryManager.RepositoryDepartment.UpdateDepartment(department);
        }


        public bool DeleteHigherDepartment(ModelDepartment department)
        {
            if (RepositoryManager.RepositoryDepartment.GetNumberOfInferiorDepartments(department.Id) != 0)
            {
                return false;
            }
            else
            {
                RepositoryManager.RepositoryEmployee.SetDepartmentForEmployee((int)department.ManagerEmployeeId, null);
                if (RepositoryManager.RepositoryDepartment.DeleteDepartment(department.Id))
                {
                    return true;
                }
            }
            return false;
        }
    }
}
