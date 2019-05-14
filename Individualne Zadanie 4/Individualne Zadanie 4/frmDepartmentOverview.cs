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
    public partial class frmDepartmentOverview : Form
    {
        private DepartmentsViewModel _departmentsViewModel = new DepartmentsViewModel();
        private int _superiorDepId;

        public frmDepartmentOverview(int superiorDepId)
        {
            _superiorDepId = superiorDepId;
            InitializeComponent();
            FillDGV();
        }
        

        private void btnBack_Click(object sender, EventArgs e)
        {
            DialogResult = DialogResult.Cancel;
        }

        private void FillDGV()
        {
            dGVOverview.DataSource = _departmentsViewModel.GetModelDepartmentsOverviews(_superiorDepId);
            dGVOverview.Columns["Id"].Visible = false;
            dGVOverview.Columns["SuperiorDepartmentId"].Visible = false;
            dGVOverview.Columns["ManagerEmployeeId"].Visible = false;


            if (dGVOverview.Rows.Count == 1)
            {
                btnSelect.Enabled = false;
                btnEdit.Enabled = false;
            }
            else
            {
                btnSelect.Enabled = true;
                btnEdit.Enabled = true;
            }

        }

        private void btnCreate_Click(object sender, EventArgs e)
        {
            frmCreateEditDepartment createDepartment = new frmCreateEditDepartment(EnumDepartmentsType.DepartmentType.Department, _superiorDepId);
            createDepartment.ShowDialog();
            if (createDepartment.DialogResult == DialogResult.OK)
            {
                FillDGV();
            }
        }

        private void btnBack_Click_1(object sender, EventArgs e)
        {
            DialogResult = DialogResult.Cancel;
        }

        private void btnSelect_Click(object sender, EventArgs e)
        {
            frmEmployeeOverview employeeOverview = new frmEmployeeOverview((int)dGVOverview.CurrentRow.Cells["Id"].Value);
            employeeOverview.ShowDialog();

        }

        private void btnEdit_Click(object sender, EventArgs e)
        {
            
            frmCreateEditDepartment frmCreateEditDepartment = new frmCreateEditDepartment(
                _departmentsViewModel.MakeDepartment((int)dGVOverview.CurrentRow.Cells["Id"].Value, (string)dGVOverview.CurrentRow.Cells["Name"].Value,
                (string)dGVOverview.CurrentRow.Cells["Code"].Value,(int?)dGVOverview.CurrentRow.Cells["SuperiorDepartmentId"].Value,
                (int?)dGVOverview.CurrentRow.Cells["ManagerEmployeeId"].Value));


            frmCreateEditDepartment.ShowDialog();
            FillDGV();
        }
    }
}
