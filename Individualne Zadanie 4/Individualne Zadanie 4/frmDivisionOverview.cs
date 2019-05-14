using Data.Models;
using System;
using System.Windows.Forms;

namespace Individualne_Zadanie_4
{
    public partial class frmDivisionOverview : Form
    {
        private DepartmentsViewModel _divisionOverviewViewModel = new DepartmentsViewModel();
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
            dGVOverview.DataSource = _divisionOverviewViewModel.GetModelDepartmentsOverviews(_superiorDepId);
            dGVOverview.Columns["Id"].Visible = false;
            dGVOverview.Columns["SuperiorDepartmentId"].Visible = false;
            dGVOverview.Columns["ManagerEmployeeId"].Visible = false;
        }

        private void btnAdd_Click(object sender, EventArgs e)
        {
            frmCreateDepartment createDepartment = new frmCreateDepartment(EnumDepartmentsType.DepartmentType.Division, _superiorDepId);
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
    }
}
