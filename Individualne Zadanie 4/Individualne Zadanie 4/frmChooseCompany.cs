using Data.Models;
using System;
using System.Windows.Forms;

namespace Individualne_Zadanie_4
{
    public partial class FrmChooseCompany : Form
    {

        private ChooseCompanyViewModel _chooseCompanyViewModel = new ChooseCompanyViewModel();


        public FrmChooseCompany()
        {
            InitializeComponent();
        }

        private void Button2_Click(object sender, EventArgs e)
        {
            Close();
        }

        private void BtnCreateCompany_Click(object sender, EventArgs e)
        {
            frmCreateEditDepartment createCompany = new frmCreateEditDepartment(EnumDepartmentsType.DepartmentType.Company);
            createCompany.ShowDialog();
            if (createCompany.DialogResult == DialogResult.OK)
            {
                FillCmb();
            }
        }



        private void BtnConfirm_Click(object sender, EventArgs e)
        {
            ModelDepartment department = (ModelDepartment)cmbCompanies.SelectedItem;
            FrmDivisionOverview frmDivision = new FrmDivisionOverview(department.Id);
            frmDivision.ShowDialog();
        }



        private void FrmChooseCompany_Load(object sender, EventArgs e)
        {

            FillCmb();
        }


        private void FillCmb()
        {

            cmbCompanies.DataSource = _chooseCompanyViewModel.GetCompanies();
            if (cmbCompanies.Items.Count == 0)
            {
                btnConfirm.Enabled = false;
                btnEditCompany.Enabled = false;
                btnDelete.Enabled = false;
            }
            else
            {
                btnConfirm.Enabled = true;
                btnDelete.Enabled = true;
                btnEditCompany.Enabled = true;
            }
        }

        private void BtnEditCompany_Click(object sender, EventArgs e)
        {
            frmCreateEditDepartment frmCreateEditDepartment = new frmCreateEditDepartment((ModelDepartment)cmbCompanies.SelectedItem);
            frmCreateEditDepartment.ShowDialog();
            FillCmb();
        }

        private void BtnDelete_Click(object sender, EventArgs e)
        {
            if (_chooseCompanyViewModel.DeleteCompany((ModelDepartment)cmbCompanies.SelectedItem))
            {
                FillCmb();

            }
            else
            {
                MessageBox.Show("Cannot delete Company\n" +
               "First delete divisions");
            }
        }
    }
}
