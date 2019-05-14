using Data.Models;
using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;



namespace Data.Repositories
{
    public class RepositoryDepartment
    {

        public bool CreateDepartment(ModelDepartment department, ModelEmployee employee)
        {
            bool isSuccessful = false;
            RepositoryManager.ExecuteSqlCommand((command) =>
            {
                command.CommandText = @"insert into  [dbo].[Department] 
                                       values (@Name,@Code,@DepartmentType,null,@manager)";


                command.Parameters.Add("@Name", SqlDbType.NVarChar).Value = department.Name;
                command.Parameters.Add("@Code", SqlDbType.NVarChar).Value = department.Code;
                command.Parameters.Add("@DepartmentType", SqlDbType.NVarChar).Value = EnumDepartmentsType.DepartmentType.Company;

                if (command.ExecuteNonQuery() > 0)
                {
                    isSuccessful = true;
                }


            });
            return isSuccessful;
        }


        public List<ModelDepartment> GetListOfDepartments(EnumDepartmentsType.DepartmentType departmentType)
        {
            List<ModelDepartment> myListOfCompanies = new List<ModelDepartment>();
            RepositoryManager.ExecuteSqlCommand((command) =>
            {
                command.CommandText = @"select * from [dbo].[Department]
                                            where DepartmentType=@DepartmentType";
                command.Parameters.Add("@DepartmentType", SqlDbType.NVarChar).Value = departmentType.ToString();
                using (SqlDataReader reader = command.ExecuteReader())
                {
                    while (reader.Read())
                    {
                        ModelDepartment company = new ModelDepartment();
                        company.Id = reader.GetInt32(0);
                        company.Name = reader.GetString(1);
                        company.Code = reader.GetString(2);
                        company.DepartmentType = departmentType;
                        company.SuperiorDepartment = reader.IsDBNull(4) ? null : (int?)reader.GetInt32(4);
                        company.ManagerEmployeeId = reader.IsDBNull(5) ? null : (int?)reader.GetInt32(5);
                        myListOfCompanies.Add(company);
                    }
                }

            });
            return myListOfCompanies;
        }


        public (string departmentName, string departmentCode) GetDepartmentNameByEmployee(int employeeID)
        {
            (string departmentName, string departmentCode) ret = ("", "");
            RepositoryManager.ExecuteSqlCommand((command) =>
            {
                command.CommandText = @"select d.Name,d.Code
                                            from Department as d
                                            left join  Employee as e on e.DepartmentId=d.Id
                                            where e.Id = @Id";
                command.Parameters.Add("@Id", SqlDbType.Int).Value = employeeID;

                using (SqlDataReader reader = command.ExecuteReader())
                {
                    if (reader.Read())
                    {
                        ret.departmentName = reader.GetString(0);
                        ret.departmentCode = reader.GetString(1);
                    }
                }




            });
            return ret;
        }

    }
}
