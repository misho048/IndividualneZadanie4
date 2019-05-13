using Data.Models;
using Data.Repositories;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Logic
{
   public static class Logic
    {
        public static bool CreateEmployee(string title, string name, string surname, string phoneNumber, string email, int? departmentId)
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
    }
}
