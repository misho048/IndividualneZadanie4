
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
    public partial class frmChooseCompany : Form
    {
        ChooseCompanyViewModel _chooseCompanyViewModel = new ChooseCompanyViewModel();

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
            cmbCompanies.DataSource = _chooseCompanyViewModel.GetCompanies();
        }
    }
}
