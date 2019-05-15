using Data.Models;
using System;
using System.Windows.Forms;

namespace Individualne_Zadanie_4
{
    public partial class frmCreateEditDepartment : Form
    {
        #region fields
        private CreateEditDepartmentViewModel _createEditDepartmentViewModel = new CreateEditDepartmentViewModel();
        private int _bossId;
        private int? _superiorDepId = null;
        private ModelDepartment _department = null;
        private EnumDepartmentsType.DepartmentType _departmentType;
        #endregion

        #region Constructors
        public frmCreateEditDepartment(EnumDepartmentsType.DepartmentType departmentType)
        {
            InitializeComponent();
            _departmentType = departmentType;

        }


        public frmCreateEditDepartment(EnumDepartmentsType.DepartmentType departmentType, int superiorDepId)
        {
            InitializeComponent();
            _superiorDepId = superiorDepId;
            _departmentType = departmentType;

        }


        public frmCreateEditDepartment(ModelDepartment department)
        {
            InitializeComponent();
            _department = department;
            FillTxtBoxes();
        }
        #endregion

        #region btnClickEvents
        private void BtnBack_Click(object sender, EventArgs e)
        {
            DialogResult = DialogResult.Cancel;
        }


        private void BtnConfirm_Click(object sender, EventArgs e)
        {
            if ((lblBossName.Text.Length > 2) && (txtBoxCode.Text.Length > 2) && (txtBoxName.Text.Length > 3))
            {
                if (_department == null)
                {
                    if (_createEditDepartmentViewModel.CreateDepartment(txtBoxName.Text, txtBoxCode.Text, _bossId, _departmentType, _superiorDepId))
                    {
                        _createEditDepartmentViewModel.SetDepartmentForEmployee(_bossId, _createEditDepartmentViewModel.GetLastAddedDepartmentId());
                        DialogResult = DialogResult.OK;
                    }
                    else
                    {
                        MessageBox.Show("Code already in Use try different one");
                    }
                }
                else
                {
                    if (_createEditDepartmentViewModel.UpdateDepartment(txtBoxName.Text, txtBoxCode.Text, _department.ManagerEmployeeId,
                           _department.DepartmentType, _department.SuperiorDepartmentId, _department.Id))
                    {
                        _createEditDepartmentViewModel.SetDepartmentForEmployee((int)_department.ManagerEmployeeId, _department.Id);
                        DialogResult = DialogResult.OK;
                    }
                    else
                    {
                        MessageBox.Show("Code already in Use try different one");
                    }
                }
            }
            else
            {
                MessageBox.Show("Select Boss First and fill Name and Code with valid names");
            }

        }


        private void Button1_Click(object sender, EventArgs e)
        {
            frmEmployeesEdit employeesOverView = new frmEmployeesEdit();

            if (_department != null)
            {
                _createEditDepartmentViewModel.SetDepartmentForEmployee((int)_department.ManagerEmployeeId, null);
                lblBossName.Text = "";

            }
            employeesOverView.ShowDialog();

            if (employeesOverView.DialogResult == DialogResult.OK)
            {
                _bossId = employeesOverView.SelectedId;

                if (_department != null)
                {
                    _department.ManagerEmployeeId = _bossId;
                }

                ModelEmployee boss = _createEditDepartmentViewModel.GetEmployee(_bossId);
                lblBossName.Text = $"{_departmentType.ToString()} Boss Name: {boss.Title} {boss.Name} {boss.Surname}";
                btnConfirm.Enabled = true;
            }
        }
        #endregion

        private void FillTxtBoxes()
        {
            txtBoxCode.Text = _department.Code;
            txtBoxName.Text = _department.Name;
            if (_department.ManagerEmployeeId != null)
            {
                ModelEmployee boss = _createEditDepartmentViewModel.GetEmployee((int)_department.ManagerEmployeeId);
                lblBossName.Text = $"{_department.DepartmentType.ToString()} Boss Name: {boss.Title} {boss.Name} {boss.Surname}";
            }



        }
    }
}
