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
    public partial class frmCreateEditEmployee : Form
    {
        #region fields
        private CreateEditEmployeeViewModel _createEmployeeViewModel = new CreateEditEmployeeViewModel();
        private ModelEmployee _employee;
        private bool _isCreate;
        #endregion


        #region constructors
        public frmCreateEditEmployee()
        {
            InitializeComponent();
            _isCreate = true;
        }


        public frmCreateEditEmployee(ModelEmployee employee)
        {
            InitializeComponent();
            _employee = employee;
            _isCreate = false;
            FillTxtBoxes();
        }
        #endregion


        #region buttonEvents
        private void btnCancel_Click(object sender, EventArgs e)
        {
            DialogResult = DialogResult.Cancel;
        }
        

        private void btnConfirm_Click(object sender, EventArgs e)
        {
            if (CheckCorrectInput())
            {
                if (_isCreate)
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
                else
                //Upadate
                {
                    if (_createEmployeeViewModel.UpdateEmployee(txtBoxTitle.Text, txtBoxName.Text, txtBoxSurname.Text,
                                   txtBoxPhoneNumber.Text, txtBoxEmail.Text, _employee.DepartmentId, _employee.Id))
                    {
                        DialogResult = DialogResult.OK;
                    }
                    else
                    {
                        MessageBox.Show("Updating failed");
                    }
                }



            }
            else
            {
                MessageBox.Show("Input Name,Surname or/and Email in wrong format or too short");
            }
        }
        #endregion


        #region methods
        private void FillTxtBoxes()
        {
            txtBoxEmail.Text = _employee.Email;
            txtBoxName.Text = _employee.Name;
            txtBoxSurname.Text = _employee.Surname;
            txtBoxTitle.Text = _employee.Title;
            txtBoxPhoneNumber.Text = _employee.PhoneNumber;

        }


        private bool CheckCorrectInput()
        {

            if ((txtBoxName.Text.ToString().Length < 3) || (txtBoxName.Text.ToString().Any(char.IsDigit)) ||
                (txtBoxSurname.Text.ToString().Length < 3) || (txtBoxSurname.Text.ToString().Any(char.IsDigit)) ||
                (txtBoxEmail.Text.ToString().Length < 3))
            {
                return false;
            }
            else
            {
                return true;
            }
        }
        #endregion
    }
}
