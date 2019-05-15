using Data.Models;
using System;
using System.Windows.Forms;

namespace Individualne_Zadanie_4
{
    public partial class FrmDepartmentOverview : Form
    {
        #region fields
        private DepartmentsViewModel _departmentsViewModel = new DepartmentsViewModel();
        private int _superiorDepId;
        #endregion
        public FrmDepartmentOverview(int superiorDepId)
        {
            _superiorDepId = superiorDepId;
            InitializeComponent();
            FillDGV();
        }

        #region ButtonsClickEvents      
        private void BtnCreate_Click(object sender, EventArgs e)
        {
            frmCreateEditDepartment createDepartment = new frmCreateEditDepartment(EnumDepartmentsType.DepartmentType.Department, _superiorDepId);
            createDepartment.ShowDialog();
            if (createDepartment.DialogResult == DialogResult.OK)
            {
                FillDGV();
            }
        }


        private void BtnBack_Click_1(object sender, EventArgs e)
        {
            DialogResult = DialogResult.Cancel;
        }


        private void BtnSelect_Click(object sender, EventArgs e)
        {
            FrmEmployeeOverview employeeOverview = new FrmEmployeeOverview((int)dGVOverview.CurrentRow.Cells["Id"].Value);
            employeeOverview.ShowDialog();

        }


        private void BtnEdit_Click(object sender, EventArgs e)
        {

            frmCreateEditDepartment frmCreateEditDepartment = new frmCreateEditDepartment(
                _departmentsViewModel.MakeDepartment((int)dGVOverview.CurrentRow.Cells["Id"].Value, (string)dGVOverview.CurrentRow.Cells["Name"].Value,
                (string)dGVOverview.CurrentRow.Cells["Code"].Value, (int?)dGVOverview.CurrentRow.Cells["SuperiorDepartmentId"].Value,
                (int?)dGVOverview.CurrentRow.Cells["ManagerEmployeeId"].Value));


            frmCreateEditDepartment.ShowDialog();
            FillDGV();
        }


        private void BtnDelete_Click(object sender, EventArgs e)
        {
            if (_departmentsViewModel.DeleteDepartment((int)dGVOverview.CurrentRow.Cells["Id"].Value))
            {
                FillDGV();

            }
            else
            {
                MessageBox.Show("Cannot delete Department,\n" +
                "Delete Employees First");
            }
        }
        #endregion

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
                btnDelete.Enabled = false;
            }
            else
            {
                btnSelect.Enabled = true;
                btnEdit.Enabled = true;
                btnDelete.Enabled = true;
            }

        }
    }
}
