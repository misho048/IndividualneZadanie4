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
    public partial class frmCreateEmployee : Form
    {
        private CreateEmployeeViewModel _createEmployeeViewModel = new CreateEmployeeViewModel();

        public frmCreateEmployee()
        {
            InitializeComponent();
            
        }

        private void btnCancel_Click(object sender, EventArgs e)
        {
            DialogResult = DialogResult.Cancel;
        }

        private void btnConfirm_Click(object sender, EventArgs e)
        {
            if (_createEmployeeViewModel.CreateEmployee(txtBoxTitle.Text, txtBoxName.Text, txtBoxSurname.Text,
                txtBoxPhoneNumber.Text, txtBoxEmail.Text, null))
            {
                DialogResult = DialogResult.OK;
            } 
            else
            {
                MessageBox.Show("ErrorHappend during creating new Employee");
            }
        }
    }
}
