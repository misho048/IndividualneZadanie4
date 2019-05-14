using Data.Models;
using Data.Repositories;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Logic
{
   public  class Logic
    {
        public  bool CreateEmployee(string title, string name, string surname, string phoneNumber, string email, int? departmentId)
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
            foreach( var item in myEntryList)
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
                Id=id
            };

            return RepositoryManager.RepositoryEmployee.UpdateEmployee(employee);

        }


        public bool CreateDepartment(string name, string code, EnumDepartmentsType.DepartmentType departmentType,
            int? managerId,int? superiorDepartmentId)
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

    }
}
