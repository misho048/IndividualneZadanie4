using Data.Models;
using System;
using System.Windows.Forms;

namespace Individualne_Zadanie_4
{
    public partial class frmDivisionOverview : Form
    {
        private DepartmentsViewModel _departmentsViewModel = new DepartmentsViewModel();
        private int _superiorDepId;

        public frmDivisionOverview(int companyId)
        {
            _superiorDepId = companyId;
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

        private void btnAdd_Click(object sender, EventArgs e)
        {
            frmCreateEditDepartment createDepartment = new frmCreateEditDepartment(EnumDepartmentsType.DepartmentType.Division, _superiorDepId);
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
                frmProjectsOverview frmProjects = new frmProjectsOverview((int)dGVOverview.CurrentRow.Cells["Id"].Value);
                frmProjects.ShowDialog();              
                
            }

        }

        private void btnEdit_Click(object sender, EventArgs e)
        {
            frmCreateEditDepartment frmCreateEditDepartment = new frmCreateEditDepartment(
               _departmentsViewModel.MakeDepartment((int)dGVOverview.CurrentRow.Cells["Id"].Value, (string)dGVOverview.CurrentRow.Cells["Name"].Value,
               (string)dGVOverview.CurrentRow.Cells["Code"].Value, (int?)dGVOverview.CurrentRow.Cells["SuperiorDepartmentId"].Value,
               (int?)dGVOverview.CurrentRow.Cells["ManagerEmployeeId"].Value));


            frmCreateEditDepartment.ShowDialog();
            FillDGV();
        }
    }
}
