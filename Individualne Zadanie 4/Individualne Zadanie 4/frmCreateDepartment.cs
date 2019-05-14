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
    public partial class frmCreateDepartment : Form
    {
        private CreateDepartmentViewModel _createDepartmentViewModel = new CreateDepartmentViewModel();
        private int _bossId;
        private int? _superiorDepId = null;
        private EnumDepartmentsType.DepartmentType _departmentType;

        public frmCreateDepartment(EnumDepartmentsType.DepartmentType departmentType)
        {
            InitializeComponent();
            _departmentType = departmentType;
            btnConfirm.Enabled = false;
        }
        public frmCreateDepartment(EnumDepartmentsType.DepartmentType departmentType, int superiorDepId)
        {
            InitializeComponent();
            _superiorDepId = superiorDepId;
            _departmentType = departmentType;
            btnConfirm.Enabled = false;
        }


        private void btnBack_Click(object sender, EventArgs e)
        {
            DialogResult = DialogResult.Cancel;
        }

        private void btnConfirm_Click(object sender, EventArgs e)
        {
            if (_createDepartmentViewModel.CreateDepartment(txtBoxName.Text, txtBoxCode.Text, _bossId, _departmentType, _superiorDepId))
            {
                _createDepartmentViewModel.SetDepartmentForEmployee(_bossId, _createDepartmentViewModel.GetLastAddedDepartmentId());
                DialogResult = DialogResult.OK;
            }
            else
            {
                MessageBox.Show("Code already in Use try different one");
            }

        }

        private void frmCreateCompany_Load(object sender, EventArgs e)
        {
            btnConfirm.Enabled = false;

        }

        private void button1_Click(object sender, EventArgs e)
        {
            frmEmployeesOverView employeesOverView = new frmEmployeesOverView();
            employeesOverView.ShowDialog();
            if (employeesOverView.DialogResult == DialogResult.OK)
            {
                _bossId = employeesOverView.SelectedId;
                ModelEmployee boss = _createDepartmentViewModel.GetEmployee(_bossId);
                lblBossName.Text = $"{_departmentType.ToString()} Boss Name: {boss.Title} {boss.Name} {boss.Surname}";
                btnConfirm.Enabled = true;
            }
        }
    }
}
