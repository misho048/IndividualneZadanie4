
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
   public  class RepositoryEmployee
    {

        public bool CreateEmployee (ModelEmployee employee)
        {
            bool isSuccessful = false;
            RepositoryManager.ExecuteSqlCommand((command) =>
            {
                command.CommandText = @"insert into [dbo].[Employee]
                        values (@Title,@Name,@Surname,@PhoneNumber,@Mail,@DepartmentID)";

                command.Parameters.Add("@Title", SqlDbType.NVarChar).Value = employee.Title;
                command.Parameters.Add("@Name", SqlDbType.NVarChar).Value = employee.Name;
                command.Parameters.Add("@Surname", SqlDbType.NVarChar).Value = employee.Surname;
                command.Parameters.Add("@PhoneNumber", SqlDbType.NVarChar).Value = employee.PhoneNumber;
                command.Parameters.Add("@Mail", SqlDbType.NVarChar).Value = employee.Mail;
                command.Parameters.Add("@DepartmentID", SqlDbType.Int).Value = employee.DepartmentId;

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
                        employee.DepartmentId = reader.IsDBNull(5) ? null : (int?)reader.GetInt32(5);
                        myListOfEmployees.Add(employee);
                    }
                }

            });
            return myListOfEmployees;     

        }

        

    }
}
