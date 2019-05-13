using Data.Models;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Individualne_Zadanie_4
{
    public partial class frmCreateCompany : Form
    {
        private CreateCompanyViewModel _createCompanyViewModel = new CreateCompanyViewModel();

        public frmCreateCompany()
        {
            InitializeComponent();
        }

        private void btnBack_Click(object sender, EventArgs e)
        {
            if (cmbEmployees.Enabled == false)
            {
                _createCompanyViewModel.DeleteEmplyee((ModelEmployee)cmbEmployees.SelectedItem);
            }
            DialogResult = DialogResult.Cancel;
        }

        private void btnConfirm_Click(object sender, EventArgs e)
        {

            DialogResult = DialogResult.OK;
        }

        private void frmCreateCompany_Load(object sender, EventArgs e)
        {
            cmbEmployees.DataSource = _createCompanyViewModel.GetEmployees();

        }

        private void button1_Click(object sender, EventArgs e)
        {
            frmCreateEmployee createEmployee = new frmCreateEmployee();
            createEmployee.ShowDialog();
            if (createEmployee.DialogResult == DialogResult.OK)
            {
                cmbEmployees.DataSource = _createCompanyViewModel.GetEmployees();
                cmbEmployees.SelectedIndex = cmbEmployees.Items.Count - 1;
                cmbEmployees.Enabled = false;
                btnCreateBoss.Enabled = false;
            }
        }
    }
}
