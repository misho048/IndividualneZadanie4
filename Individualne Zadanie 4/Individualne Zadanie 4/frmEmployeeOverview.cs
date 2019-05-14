using System;
using System.Windows.Forms;

namespace Individualne_Zadanie_4
{
    public partial class frmEmployeeOverview : Form
    {
        #region fields
        private EmployeeOverviewViewModel _employeeOverviewViewModel = new EmployeeOverviewViewModel();
        private int _superiorDepId;
        #endregion


        public frmEmployeeOverview(int superiorDepId)
        {
            _superiorDepId = superiorDepId;
            InitializeComponent();
            FillDGV();
        }

        #region buttonEvents
        private void btnDelete_Click(object sender, EventArgs e)
        {
            _employeeOverviewViewModel.SetDepartmentForEmployee((int)dGVOverview.CurrentRow.Cells["Id"].Value, null);
            FillDGV();
        }


        private void btnBack_Click(object sender, EventArgs e)
        {
            DialogResult = DialogResult.Cancel;
        }


        private void btnCreate_Click(object sender, EventArgs e)
        {
            frmEmployeesEdit frmEmployees = new frmEmployeesEdit();
            frmEmployees.ShowDialog();
            if (frmEmployees.DialogResult == DialogResult.OK)
            {
                _employeeOverviewViewModel.SetDepartmentForEmployee(frmEmployees.SelectedId, _superiorDepId);

            }
            FillDGV();
        }
        #endregion


        private void FillDGV()
        {
            dGVOverview.DataSource = _employeeOverviewViewModel.GetEmployeesInDepartment(_superiorDepId);
            dGVOverview.Columns["Id"].Visible = false;
            dGVOverview.Columns["DepartmentId"].Visible = false;

        }
    }
}
