using com.rusanu.dataconnectiondialog;
using Logic;
using System.Data.SqlClient;

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
                        frmChooseCompany chooseCompany = new frmChooseCompany();
                        chooseCompany.ShowDialog();
                    Close();
                  
                }
            }

        }
    }
}
