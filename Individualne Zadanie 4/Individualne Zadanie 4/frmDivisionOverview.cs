using Data.Models;
using System;
using System.Windows.Forms;

namespace Individualne_Zadanie_4
{
    public partial class FrmDivisionOverview : Form
    {
        #region fields
        private DepartmentsViewModel _departmentsViewModel = new DepartmentsViewModel();
        private int _superiorDepId;
        #endregion


        public FrmDivisionOverview(int companyId)
        {
            _superiorDepId = companyId;
            InitializeComponent();
            FillDGV();
        }


        #region ButtonClickEvents
        private void BtnBack_Click(object sender, EventArgs e)
        {
            DialogResult = DialogResult.Cancel;
        }


        private void BtnAdd_Click(object sender, EventArgs e)
        {
            FrmCreateEditDepartment createDepartment = new FrmCreateEditDepartment(EnumDepartmentsType.DepartmentType.Division, _superiorDepId);
            createDepartment.ShowDialog();
            if (createDepartment.DialogResult == DialogResult.OK)
            {
                FillDGV();
            }
        }


        private void BtnSelect_Click(object sender, EventArgs e)
        {
            if (dGVOverview.CurrentCell == null)
            {
                MessageBox.Show("Invalid Selection");
            }
            else
            {
                frmProjectsOverview frmProjects = new frmProjectsOverview((int)dGVOverview.CurrentRow.Cells["Id"].Value);
                frmProjects.ShowDialog();

            }

        }


        private void BtnEdit_Click(object sender, EventArgs e)
        {
            FrmCreateEditDepartment frmCreateEditDepartment = new FrmCreateEditDepartment(GetModel());


            frmCreateEditDepartment.ShowDialog();
            FillDGV();
        }


        private void BtnDelete_Click(object sender, EventArgs e)
        {
            if (_departmentsViewModel.DeleteHigherDepartment(GetModel()))
            {
                FillDGV();
            }
            else
            {
                MessageBox.Show("Cannot delete Division,\n" +
                 "delete Projets First");

            }
        }
        #endregion


        #region Methods
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


        private ModelDepartment GetModel()
        {
            return _departmentsViewModel.MakeDepartment((int)dGVOverview.CurrentRow.Cells["Id"].Value, (string)dGVOverview.CurrentRow.Cells["Name"].Value,
               (string)dGVOverview.CurrentRow.Cells["Code"].Value, (int?)dGVOverview.CurrentRow.Cells["SuperiorDepartmentId"].Value,
               (int?)dGVOverview.CurrentRow.Cells["ManagerEmployeeId"].Value);
        }
        #endregion
    }
}
