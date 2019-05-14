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
    class DepartmentsViewModel
    {
        public BindingList<ModelDepartmentsOverview> GetModelDepartmentsOverviews (int superiorDepId)
        {
            return new BindingList<ModelDepartmentsOverview>
                (RepositoryManager.RepositoryDepartmentsOverview.GetListofDepOverviews(superiorDepId));
        }
    }
}
