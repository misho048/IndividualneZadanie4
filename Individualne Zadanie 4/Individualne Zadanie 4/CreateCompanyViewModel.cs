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
    class CreateCompanyViewModel
    {

        public BindingList<ModelEmployee> GetEmployees()
        {
            return new BindingList<ModelEmployee>(
            RepositoryManager.RepositoryEmployee.GetListOfEmployees());
        }

        public void DeleteEmplyee(ModelEmployee employee)
        {
            RepositoryManager.RepositoryEmployee.DeleteEmployee(employee.Id);
        }

    }
}
