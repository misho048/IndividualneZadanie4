using Data.Models;
using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;



namespace Data.Repositories
{
    public class RepositoryDepartment
    {

        public bool CreateDepartment(ModelDepartment department)
        {
            bool isSuccessful = false;
            RepositoryManager.ExecuteSqlCommand((command) =>
            {

                command.CommandText = @"insert into  [dbo].[Department] 
                                       values (@Name,@Code,@DepartmentType,@SuperiorDepartmentId,@ManagerId)";

                command.Parameters.Add("@SuperiorDepartmentId", SqlDbType.Int).Value = department.SuperiorDepartmentId ?? (Object)DBNull.Value;
                command.Parameters.Add("@Name", SqlDbType.NVarChar).Value = department.Name;
                command.Parameters.Add("@Code", SqlDbType.NVarChar).Value = department.Code;
                command.Parameters.Add("@DepartmentType", SqlDbType.NVarChar).Value = department.DepartmentType.ToString();
                command.Parameters.Add("@ManagerId", SqlDbType.Int).Value = department.ManagerEmployeeId ?? (Object)DBNull.Value;

                if (command.ExecuteNonQuery() > 0)
                {
                    isSuccessful = true;
                }

            });
            return isSuccessful;
        }


        public bool UpdateDepartment(ModelDepartment department)
        {
            bool isSuccessful = false;
            RepositoryManager.ExecuteSqlCommand((command) =>
            {

                command.CommandText = @"update Department
                                        set Name=@Name,Code=@Code,DepartmentType=@DepartmentType,
                                            SuperiorDepartmentId=@SuperiorDepartmentId, ManagerEmployeeId=@ManagerEmpoyeeId
                                        where Id=@Id";

                command.Parameters.Add("@SuperiorDepartmentId", SqlDbType.Int).Value = department.SuperiorDepartmentId ?? (Object)DBNull.Value;
                command.Parameters.Add("@Name", SqlDbType.NVarChar).Value = department.Name;
                command.Parameters.Add("@Code", SqlDbType.NVarChar).Value = department.Code;
                command.Parameters.Add("@DepartmentType", SqlDbType.NVarChar).Value = department.DepartmentType.ToString();
                command.Parameters.Add("@ManagerEmpoyeeId", SqlDbType.Int).Value = department.ManagerEmployeeId ?? (Object)DBNull.Value;
                command.Parameters.Add("@Id", SqlDbType.Int).Value = department.Id;

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
                        company.SuperiorDepartmentId = reader.IsDBNull(4) ? null : (int?)reader.GetInt32(4);
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


        public int GetLastAddedDepartmentId()
        {
            int ret = 0;
            RepositoryManager.ExecuteSqlCommand((command) =>
            {
                command.CommandText = @"select max(id)
                                        from Department";
                ret = (int)command.ExecuteScalar();
            });
            return ret;
        }


        public bool DeleteDepartment(int departmentId)
        {
            bool isSuccessful = false;
            RepositoryManager.ExecuteSqlCommand((command) =>
            {

                command.CommandText = @"delete from Department 
                                        where Id=@Id";

                command.Parameters.Add("@Id", SqlDbType.Int).Value = departmentId;

                if (command.ExecuteNonQuery() > 0)
                {
                    isSuccessful = true;
                }

            });
            return isSuccessful;
        }


        public int GetNumberOfInferiorDepartments(int departmentId)
        {
            int ret = 0;
            RepositoryManager.ExecuteSqlCommand((command) =>
            {
                command.CommandText = @"select count(*)
                                        from Department
                                        where SuperiorDepartmentId =@departmentId";
                command.Parameters.Add("@departmentId", SqlDbType.Int).Value = departmentId;
                ret = (int)command.ExecuteScalar();
            });
            return ret;
        }


        
    }
}
