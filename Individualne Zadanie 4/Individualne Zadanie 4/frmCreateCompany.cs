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
            DialogResult = DialogResult.Cancel;
        }

        private void btnConfirm_Click(object sender, EventArgs e)
        {

            DialogResult = DialogResult.OK;
        }

        private void frmCreateCompany_Load(object sender, EventArgs e)
        {


        }

        private void button1_Click(object sender, EventArgs e)
        {
            frmEmployeesOverView employeesOverView = new frmEmployeesOverView(true);
            employeesOverView.ShowDialog();
            if (employeesOverView.DialogResult == DialogResult.OK)
            {
                ModelEmployee boss = _createCompanyViewModel.GetEmployee(employeesOverView.SelectedId);
                lblBossName.Text = $"Boss Name: {boss.Title} {boss.Name} {boss.Surname}";
        }
        }
    }
}
