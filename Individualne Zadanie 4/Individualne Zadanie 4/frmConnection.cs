using com.rusanu.dataconnectiondialog;
using Logic;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Data.SqlClient;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Individualne_Zadanie_4
{
    public partial class frmConnection : Form
    {
        private Connections _connections = new Connections();

        public frmConnection()
        {
            InitializeComponent();
            CheckConnection();
        }

        private void CheckConnection()
        {

            //SqlConnectionStringBuilder scsb = new SqlConnectionStringBuilder();
            //scsb.IntegratedSecurity = true;
            //scsb.InitialCatalog = "master";
            // Display the connection dialog
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
                   else
                    {
                        frmChooseCompany chooseCompany = new frmChooseCompany();
                        chooseCompany.ShowDialog();
                    }
                }
            }

        }
    }
}
