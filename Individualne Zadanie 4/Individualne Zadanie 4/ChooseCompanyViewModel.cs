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
    class ChooseCompanyViewModel
    {

        public BindingList<ModelDepartment> GetCompanies ()
        {
            return new BindingList<ModelDepartment>(
            RepositoryManager.RepositoryDepartment.GetListOfDepartments(EnumDepartmentsType.DepartmentType.Company));
        }


    }
}
