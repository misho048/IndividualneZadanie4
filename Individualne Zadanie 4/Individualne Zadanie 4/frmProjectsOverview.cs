using Data.Models;
using System;
using System.Windows.Forms;

namespace Individualne_Zadanie_4
{
    public partial class frmProjectsOverview : Form
    {
        private DepartmentsViewModel _departmentsViewModel = new DepartmentsViewModel();
        private int _superiorDepId;


        public frmProjectsOverview(int superiorDepId)
        {
            
            InitializeComponent();
            _superiorDepId = superiorDepId;
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

        }

        private void btnCreate_Click(object sender, EventArgs e)
        {
            frmCreateDepartment createDepartment = new frmCreateDepartment(EnumDepartmentsType.DepartmentType.Project, _superiorDepId);
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
                frmDepartmentOverview frmDepartmentOverview= new frmDepartmentOverview((int)dGVOverview.CurrentRow.Cells["Id"].Value);
                frmDepartmentOverview.ShowDialog();

            }
        }
    }
}
