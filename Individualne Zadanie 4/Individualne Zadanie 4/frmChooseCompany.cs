using Data.Models;
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
            frmCreateDepartment createCompany = new frmCreateDepartment(EnumDepartmentsType.DepartmentType.Company);
            createCompany.ShowDialog();
            if (createCompany.DialogResult == DialogResult.OK)
            {
                fillCmb();
            }
        }



        private void btnConfirm_Click(object sender, EventArgs e)
        {
            ModelDepartment department = (ModelDepartment)cmbCompanies.SelectedItem;
            frmDivisionOverview frmDivision = new frmDivisionOverview(department.Id);
            frmDivision.ShowDialog();
        }

        

        private void frmChooseCompany_Load(object sender, EventArgs e)
        {
            
            if (!_connections.HasDatabase())
            {
            _chooseCompanyViewModel.CheckConnection();
            }
            fillCmb();
        }

       
        private void fillCmb()
        {
            cmbCompanies.DataSource = _chooseCompanyViewModel.GetCompanies();
        }
    }
}
