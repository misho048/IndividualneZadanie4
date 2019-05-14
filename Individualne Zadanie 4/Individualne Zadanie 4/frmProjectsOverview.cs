using Data.Models;
using System;
using System.Windows.Forms;

namespace Individualne_Zadanie_4
{
    public partial class frmProjectsOverview : Form
    {
        #region fields
        private DepartmentsViewModel _departmentsViewModel = new DepartmentsViewModel();
        private int _superiorDepId;
        #endregion

        public frmProjectsOverview(int superiorDepId)
        {

            InitializeComponent();
            _superiorDepId = superiorDepId;
            FillDGV();
        }

        #region buttonsClickEvents
        private void btnBack_Click(object sender, EventArgs e)
        {
            DialogResult = DialogResult.Cancel;
        }

        
        private void btnCreate_Click(object sender, EventArgs e)
        {
            frmCreateEditDepartment createDepartment = new frmCreateEditDepartment(EnumDepartmentsType.DepartmentType.Project, _superiorDepId);
            createDepartment.ShowDialog();
            if (createDepartment.DialogResult == DialogResult.OK)
            {
                FillDGV();
            }
        }


        private void btnSelect_Click(object sender, EventArgs e)
        {

            if (dGVOverview.CurrentCell == null)
            {
                MessageBox.Show("Invalid Selection");
            }
            else
            {
                frmDepartmentOverview frmDepartmentOverview = new frmDepartmentOverview((int)dGVOverview.CurrentRow.Cells["Id"].Value);
                frmDepartmentOverview.ShowDialog();

            }
        }


        private void btnEdit_Click(object sender, EventArgs e)
        {
            frmCreateEditDepartment frmCreateEditDepartment = new frmCreateEditDepartment(GetModel());


            frmCreateEditDepartment.ShowDialog();
            FillDGV();
        }

        
        private void btnDelete_Click(object sender, EventArgs e)
        {

            if (_departmentsViewModel.DeleteHigherDepartment(GetModel()))
            {
                FillDGV();

            }
            else
            {
                MessageBox.Show("Cannot delete Projects,\n" +
                    "Delete Departments first");
            }
        }
        #endregion

        private ModelDepartment GetModel()
        {
            return _departmentsViewModel.MakeDepartment((int)dGVOverview.CurrentRow.Cells["Id"].Value, (string)dGVOverview.CurrentRow.Cells["Name"].Value,
               (string)dGVOverview.CurrentRow.Cells["Code"].Value, (int?)dGVOverview.CurrentRow.Cells["SuperiorDepartmentId"].Value,
               (int?)dGVOverview.CurrentRow.Cells["ManagerEmployeeId"].Value);
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
