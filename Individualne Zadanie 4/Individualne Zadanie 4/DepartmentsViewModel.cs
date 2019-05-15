using Data.Models;
using Data.Repositories;
using System.ComponentModel;

namespace Individualne_Zadanie_4
{
    class DepartmentsViewModel
    {
        private Logic.Logic _logic = new Logic.Logic();

        public BindingList<ModelDepartmentsOverview> GetModelDepartmentsOverviews(int superiorDepId)
        {
            return new BindingList<ModelDepartmentsOverview>
                (RepositoryManager.RepositoryDepartmentsOverview.GetListofDepOverviews(superiorDepId));
        }

        public ModelDepartment MakeDepartment(int id, string name, string code,
            int? superiorDepartmentId, int? managerEmployeeId)
        {
            ModelDepartment model = new ModelDepartment
            {
                Id = id,
                Name = name,
                Code = code,
                DepartmentType = EnumDepartmentsType.DepartmentType.Department,
                SuperiorDepartmentId = superiorDepartmentId,
                ManagerEmployeeId = managerEmployeeId
            };
            return model;
        }

        public bool DeleteDepartment(int departmentId)
        {
            return RepositoryManager.RepositoryDepartment.DeleteDepartment(departmentId);
        }

        public bool DeleteHigherDepartment(ModelDepartment department)
        {
            return _logic.DeleteHigherDepartment(department);
        }
    }
}
