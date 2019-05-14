using Data.Models;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;

namespace Data.Repositories
{
    public class RepositoryDepartmentsOverview
    {
        public List<ModelDepartmentsOverview> GetListofDepOverviews(int superiorDepId)
        {
            List<ModelDepartmentsOverview> myListOfDepOverviews = new List<ModelDepartmentsOverview>();
            RepositoryManager.ExecuteSqlCommand((command) =>
            {
                command.CommandText = @"select d.*,e.Name,e.Surname 
                                        from Department as d
                                        left join Employee as e on e.DepartmentId=d.Id
                                        where d.SuperiorDepartmentId = @superiorDepId";

                command.Parameters.Add("@superiorDepId", SqlDbType.Int).Value = superiorDepId;
                using (SqlDataReader reader = command.ExecuteReader())
                {
                    while (reader.Read())
                    {
                        ModelDepartmentsOverview depOverview = new ModelDepartmentsOverview
                        {
                            Id = reader.GetInt32(0),
                            Name = reader.GetString(1),
                            Code = reader.GetString(2),
                            SuperiorDepartmentId = reader.IsDBNull(4) ? null : (int?)reader.GetInt32(4),
                            ManagerEmployeeId = reader.IsDBNull(5) ? null : (int?)reader.GetInt32(5),
                            ManagerName = reader.GetString(6),
                            ManagerSurname = reader.GetString(7)
                        };
                        myListOfDepOverviews.Add(depOverview);
                    }
                }

            });
            return myListOfDepOverviews;
        }
    }
}
