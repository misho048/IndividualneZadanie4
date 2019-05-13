using Logic;
using System;
using System.Windows.Forms;

namespace Individualne_Zadanie_4
{
    public partial class frmChooseCompany : Form
    {
        private Connections _connections = new Connections();
        private ChooseCompanyViewModel _chooseCompanyViewModel = new ChooseCompanyViewModel();


        public frmChooseCompany()
        {
            InitializeComponent();
        }

        private void button2_Click(object sender, EventArgs e)
        {
            Close();
        }

        private void btnCreateCompany_Click(object sender, EventArgs e)
        {
            frmCreateCompany createCompany = new frmCreateCompany();
            createCompany.ShowDialog();
        }



        private void btnConfirm_Click(object sender, EventArgs e)
        {

        }

        private void frmChooseCompany_Load(object sender, EventArgs e)
        {
            
            if (!_connections.HasDatabase())
            {
            _chooseCompanyViewModel.CheckConnection();
            }
            cmbCompanies.DataSource = _chooseCompanyViewModel.GetCompanies();
        }

       
    }
}
