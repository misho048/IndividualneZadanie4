using Data.Repositories;
using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Logic
{
   public class Connections
    {
        private string DB_NAME = "CompanyOrganization";
        

        public void SaveConnectionString(string connectionString)
        {
            Data.Properties.Settings.Default.ConnectionString = connectionString;
            Data.Properties.Settings.Default.Save();
        }


        public bool HasDatabase()
        {
            bool ret = false;

            if (GetDataBaseName() == DB_NAME)
            {
                ret = true;
            }
            return ret;
        }


        public SqlConnectionStringBuilder GetSqlConnectionStringBuilder(string initialCatalog)
        {
            SqlConnectionStringBuilder scsb = new SqlConnectionStringBuilder();
            scsb.IntegratedSecurity = true;
            scsb.InitialCatalog = initialCatalog;
            return scsb;
        }
              
        
        public SqlConnectionStringBuilder GetSqlConnectionStringBuilder()
        {

            return GetSqlConnectionStringBuilder("master");
        }


        public string GenerateDBName()
        {
            string ret = "";

            if (GenerateDB())
            {
                ret = GetDataBaseName();
            }
            return ret;
        }


        public bool GenerateDB()
        {
            bool ret = false;
            RepositoryManager.ExecuteSqlCommand((command) =>
            {
                command.CommandText = @"IF  NOT EXISTS (SELECT [name] FROM [sys].[databases] WHERE [name] = N'CompanyOrganization')
                                        BEGIN
                                            CREATE DATABASE[CompanyOrganization]
                                        END";
                if (command.ExecuteNonQuery() != 0)
                {
                    ret = true;
                };
            });
            return ret;
        }
 

        public bool GenerateTables()
        {
            bool ret = false;
            RepositoryManager.ExecuteSqlCommand((command) =>
            {
                command.CommandText = @"IF NOT EXISTS (SELECT [name] FROM sys.tables WHERE [name] = 'Department')
	                                    BEGIN
		                                    create table Department(
                                            Id int Identity(1,1) not null primary key,
                                            Name varchar(50) not null,
                                            Code varchar (20) not null unique,
                                            DepartmentType varchar (20) not null,
                                            SuperiorDepartmentId int foreign key references Department(Id)
                                            ) 
	                                    END

                                    IF NOT EXISTS (SELECT [name] FROM sys.tables WHERE [name] = 'Employee')
	                                    BEGIN
		                                        ( Id int Identity(1,1) primary key,
                                                 Title varchar(4),
                                                 Name varchar(20) not null,
                                                 Surname varchar(20) not null,
                                                 PhoneNumber varchar(15),
                                                 Mail varchar(50) not null,
                                                 DepartmentId int  foreign key references Department(Id) 
                                                 )

                                                 alter table Department
                                                    add ManagerEmployeeId int  foreign key  references Employee(Id)      
	                                    END
                                   ";
                if (command.ExecuteNonQuery() != 0)
                {
                    ret = true;
                }
            });
            return ret;
        }


        public string GetDataBaseName()
        {
            string ret = "";
            RepositoryManager.ExecuteSqlCommand((command) =>
            {
                command.CommandText = @"SELECT [name] FROM [sys].[databases] WHERE[name] = N'CompanyOrganization'";
                ret = (string)command.ExecuteScalar();
            });
            return ret;
        }

    }
}
