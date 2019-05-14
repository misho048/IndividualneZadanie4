using com.rusanu.dataconnectiondialog;
using Data.Models;
using Data.Repositories;
using Logic;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Individualne_Zadanie_4
{
    class ChooseCompanyViewModel
    {
        private Logic.Logic _logic = new Logic.Logic();

        public BindingList<ModelDepartment> GetCompanies ()
        {
            return new BindingList<ModelDepartment>(
            RepositoryManager.RepositoryDepartment.GetListOfDepartments(EnumDepartmentsType.DepartmentType.Company));
        }
        
        
        public bool DeleteCompany(ModelDepartment department)
        {
            return _logic.DeleteHigherDepartment(department);
        }
               

    }
}
