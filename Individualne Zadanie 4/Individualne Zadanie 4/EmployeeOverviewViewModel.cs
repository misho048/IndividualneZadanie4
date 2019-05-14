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
    class EmployeeOverviewViewModel
    {
        public BindingList<ModelEmployee> GetEmployeesInDepartment(int departmentId)
        {
            return new BindingList<ModelEmployee>(
                RepositoryManager.RepositoryEmployee.GetListOfEmployeesByDepartment(departmentId));
        }

    }
}
