using System;
using System.Windows.Forms;

namespace Individualne_Zadanie_4
{
    public partial class frmEmployeeOverview : Form
    {
        private EmployeeOverviewViewModel _employeeOverviewViewModel = new EmployeeOverviewViewModel();
        private int _superiorDepId;
        public frmEmployeeOverview(int superiorDepId)
        {
            _superiorDepId = superiorDepId;
            InitializeComponent();
            FillDGV();
        }

        private void label1_Click(object sender, EventArgs e)
        {

        }

        private void btnDelete_Click(object sender, EventArgs e)
        {

        }

        private void btnEdit_Click(object sender, EventArgs e)
        {

        }

        private void btnSelect_Click(object sender, EventArgs e)
        {

        }

        private void btnBack_Click(object sender, EventArgs e)
        {
            DialogResult = DialogResult.Cancel;
        }

        private void dGVOverview_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {

        }


        private void btnCreate_Click(object sender, EventArgs e)
        {
            frmEmployeesOverView
        }

        private void FillDGV()
        {
            dGVOverview.DataSource = _employeeOverviewViewModel.GetEmployeesInDepartment(_superiorDepId);
            dGVOverview.Columns["Id"].Visible = false;
            dGVOverview.Columns["DepartmentId"].Visible = false;

        }
    }
}
