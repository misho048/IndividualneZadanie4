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
        private Connections _connections = new Connections();


        public BindingList<ModelDepartment> GetCompanies ()
        {
            return new BindingList<ModelDepartment>(
            RepositoryManager.RepositoryDepartment.GetListOfDepartments(EnumDepartmentsType.DepartmentType.Company));
        }


        public void CheckConnection()
        {

            DataConnectionDialog dlg = new DataConnectionDialog(_connections.GetSqlConnectionStringBuilder());
            if (DialogResult.OK == dlg.ShowDialog())
            {
                // Use the connection properties
                using (SqlConnection conn = new SqlConnection(dlg.ConnectionStringBuilder.ConnectionString))
                {
                    if (!_connections.HasDatabase())
                    {
                        _connections.SaveConnectionString(conn.ConnectionString);
                        dlg.ConnectionStringBuilder.InitialCatalog = _connections.GenerateDBName();
                        _connections.SaveConnectionString(dlg.ConnectionStringBuilder.ConnectionString);
                        _connections.GenerateTables();
                    }


                }

            }

        }

    }
}
