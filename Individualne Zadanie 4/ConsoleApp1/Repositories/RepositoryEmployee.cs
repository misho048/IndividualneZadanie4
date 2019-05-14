
using Data.Models;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;

namespace Data.Repositories
{
    public  class RepositoryEmployee
    {

        public bool CreateEmployee (ModelEmployee employee)
        {
            bool isSuccessful = false;
            RepositoryManager.ExecuteSqlCommand((command) =>
            {
                if (employee.DepartmentId == null)
                {
                    command.CommandText = @"insert into [dbo].[Employee]
                        values (@Title,@Name,@Surname,@PhoneNumber,@Mail,null)";
                }
                else
                {

                    command.CommandText = @"insert into [dbo].[Employee]
                        values (@Title,@Name,@Surname,@PhoneNumber,@Mail,@DepartmentID)";
                    command.Parameters.Add("@DepartmentID", SqlDbType.Int).Value = employee.DepartmentId;
                }

                command.Parameters.Add("@Title", SqlDbType.NVarChar).Value = employee.Title;
                command.Parameters.Add("@Name", SqlDbType.NVarChar).Value = employee.Name;
                command.Parameters.Add("@Surname", SqlDbType.NVarChar).Value = employee.Surname;
                command.Parameters.Add("@PhoneNumber", SqlDbType.NVarChar).Value = employee.PhoneNumber;
                command.Parameters.Add("@Mail", SqlDbType.NVarChar).Value = employee.Email;


                if (command.ExecuteNonQuery() > 0)
                {
                    isSuccessful = true;
                }
            });

            return isSuccessful;
        }


        public List<ModelEmployee> GetListOfEmployees() {

        List<ModelEmployee> myListOfEmployees = new List<ModelEmployee>();
            RepositoryManager.ExecuteSqlCommand((command) =>
            {
                command.CommandText = @"select * from [dbo].[Employee]";
                using (SqlDataReader reader = command.ExecuteReader())
                {
                    while (reader.Read())
                    {
                        ModelEmployee employee = new ModelEmployee();
                        employee.Id = reader.GetInt32(0);
                        employee.Title = reader.IsDBNull(1) ? "" : reader.GetString(1);
                        employee.Name = reader.GetString(2);
                        employee.Surname = reader.GetString(3);
                        employee.PhoneNumber = reader.IsDBNull(4) ? "" : reader.GetString(4);
                        employee.Email = reader.GetString(5);
                        employee.DepartmentId = reader.IsDBNull(6) ? null : (int?)reader.GetInt32(6);
                        myListOfEmployees.Add(employee);
                        
                    }
                }

            });
            return myListOfEmployees;     

        }
        

        public bool DeleteEmployee (int employeeId)
        {
            bool isSuccessful = false;
            RepositoryManager.ExecuteSqlCommand((command) =>
            {
               command.CommandText= @"update [dbo].[Employee]
                                           set DepartmentId=null
                                           where Id = @Id
                                           delete from [dbo].[Employee]
                                           where Id = @Id";

                command.Parameters.Add("@Id", SqlDbType.Int).Value = employeeId;


                if (command.ExecuteNonQuery() > 0)
                {
                    isSuccessful = true;
                }
            });

            return isSuccessful;
        }


        public void SetDepartmentForEmployee(int employeeId,int departmentId)
        {
            RepositoryManager.ExecuteSqlCommand((command) =>
            {
            command.CommandText = @"update [dbo].[Employee]
                                           set DepartmentId=@DepartmentId
                                           where Id = @Id";  

                command.Parameters.Add("@Id", SqlDbType.Int).Value = employeeId;
                command.ExecuteNonQuery();
            });

        }       


        public ModelEmployee GetEmployee(int employeeId)
        {
            ModelEmployee employee = new ModelEmployee();

            RepositoryManager.ExecuteSqlCommand((command) =>
            {
                command.CommandText = @"select * 
                                            from Employee as e 
                                            where e.ID = @Id";

                command.Parameters.Add("@Id", SqlDbType.Int).Value = employeeId;

               using(SqlDataReader reader = command.ExecuteReader())
                {
                    if (reader.Read())
                    {
                        
                        employee.Id = reader.GetInt32(0);
                        employee.Title = reader.IsDBNull(1) ? "" : reader.GetString(1);
                        employee.Name = reader.GetString(2);
                        employee.Surname = reader.GetString(3);
                        employee.PhoneNumber = reader.IsDBNull(4) ? "" : reader.GetString(4);
                        employee.Email = reader.GetString(5);
                        employee.DepartmentId = reader.IsDBNull(6) ? null : (int?)reader.GetInt32(6);
                    }
                }

               
            });
            return employee;

        }


        public bool UpdateEmployee (ModelEmployee employee)
        {
            bool isSuccessful = false;
            RepositoryManager.ExecuteSqlCommand((command) =>
            {
                if (employee.DepartmentId == null)
                {
                    command.CommandText = @"update Employee
                                            set Name=@Name,Surname=@Surname,Title=@Title,
                                                PhoneNumber=@PhoneNumber,Mail=@Email
                                            where id =@Id";
                }
                else
                {

                    command.CommandText = @"update Employee
                                            set Name=@Name,Surname=@Surname,Title=@Title,
                                                PhoneNumber=@PhoneNumber,Mail=@Email,DepartmentId=@DepartmentID
                                            where id =@Id";

                    command.Parameters.Add("@DepartmentID", SqlDbType.Int).Value = employee.DepartmentId;
                }

                command.Parameters.Add("@Title", SqlDbType.NVarChar).Value = employee.Title;
                command.Parameters.Add("@Name", SqlDbType.NVarChar).Value = employee.Name;
                command.Parameters.Add("@Surname", SqlDbType.NVarChar).Value = employee.Surname;
                command.Parameters.Add("@PhoneNumber", SqlDbType.NVarChar).Value = employee.PhoneNumber;
                command.Parameters.Add("@Email", SqlDbType.NVarChar).Value = employee.Email;
                command.Parameters.Add("@Id", SqlDbType.Int).Value = employee.Id;

                if (command.ExecuteNonQuery() > 0)
                {
                    isSuccessful = true;
                }
            });

            return isSuccessful;
        }
    }
}
