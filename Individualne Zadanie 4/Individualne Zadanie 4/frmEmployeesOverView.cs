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
    public partial class frmEmployeesOverView : Form
    {
        private EmployeesOverviewViewModel _employeesOverviewViewModel = new EmployeesOverviewViewModel();
        private bool _selectEmployee;
        private bool _makeCollumns = true;
        public int SelectedId { private set; get; }


        public frmEmployeesOverView(bool selectEmployee)
        {
            _selectEmployee = selectEmployee;
            InitializeComponent();
        }


        private void btnAllEmployees_Click(object sender, EventArgs e)
        {
            LoadDGV(true);
        }


        private void frmEmployeesOverView_Load(object sender, EventArgs e)
        {
            if (_selectEmployee)
            {
                btnSelect.Visible = true;
            }
            else
            {
                btnSelect.Visible = false;
            }

            LoadDGV(true);


        }


        private void LoadDGV(bool haveDepartment)
        {
            if (haveDepartment)
            {
                dGVEmployeeOverview.DataSource = _employeesOverviewViewModel.GetAllEmployees();

                if (_makeCollumns)
                {

                    dGVEmployeeOverview.Columns.Add("DepartmentName", "Name of the Department");
                    dGVEmployeeOverview.Columns.Add("DepartmentCode", "Code of the Department");
                    _makeCollumns = false;
                }
                else
                {
                    dGVEmployeeOverview.Columns["DepartmentName"].Visible = true;
                    dGVEmployeeOverview.Columns["DepartmentCode"].Visible = true;
                }


                foreach (DataGridViewRow row in dGVEmployeeOverview.Rows)
                {
                    if (row.Cells["Id"].Value == null)
                    {
                        break;
                    }
                    else
                    {
                        (string depName, string depCode) depInfo = _employeesOverviewViewModel.GetDepartmentNameByEmployee((int)(row.Cells["Id"].Value));
                        row.Cells["DepartmentName"].Value = depInfo.depName;
                        row.Cells["DepartmentCode"].Value = depInfo.depCode;
                    }

                }
            }
            else
            {
                dGVEmployeeOverview.DataSource = _employeesOverviewViewModel.GetUnsignedEmployees();
                dGVEmployeeOverview.Columns["DepartmentName"].Visible = false;
                dGVEmployeeOverview.Columns["DepartmentCode"].Visible = false;

            }

            dGVEmployeeOverview.Columns["Id"].Visible = false;
            dGVEmployeeOverview.Columns["DepartmentId"].Visible = false;
        }


        private void btnUnsignedEmployees_Click(object sender, EventArgs e)
        {
            LoadDGV(false);
        }


        private void btnBack_Click_1(object sender, EventArgs e)
        {
            DialogResult = DialogResult.Cancel;
        }


        private void btnSelect_Click(object sender, EventArgs e)
        {
            SelectedId = (int)dGVEmployeeOverview.CurrentRow.Cells[0].Value;
            DialogResult = DialogResult.OK;
        }


        private void btnCreate_Click(object sender, EventArgs e)
        {
            frmCreateEditEmployee createEditEmployee = new frmCreateEditEmployee();
            createEditEmployee.ShowDialog();
            if (createEditEmployee.DialogResult == DialogResult.OK)
            {
                LoadDGV(true);
            }
        }


        private void btnEdit_Click(object sender, EventArgs e)
        {
            frmCreateEditEmployee createEditEmployee = new frmCreateEditEmployee((ModelEmployee)dGVEmployeeOverview.CurrentRow.DataBoundItem);
            createEditEmployee.ShowDialog();
            if (createEditEmployee.DialogResult == DialogResult.OK)
            {
                LoadDGV(true);
            }
        }


        private void btnDelete_Click(object sender, EventArgs e)
        {
            DialogResult dialogResult = MessageBox.Show($"!!Warning!!\n You are going to delete employee " +
                $"{dGVEmployeeOverview.CurrentRow.Cells["Name"].Value.ToString()} {dGVEmployeeOverview.CurrentRow.Cells["Surname"].Value.ToString()}" +
                $" Are you sure?", "Deleting Employee", MessageBoxButtons.YesNo);

            if (dialogResult == DialogResult.Yes)
            {
                if (_employeesOverviewViewModel.DeteleEmployee((ModelEmployee)dGVEmployeeOverview.CurrentRow.DataBoundItem))
                {
                    MessageBox.Show("Delete successful");
                }
                else
                {
                    MessageBox.Show("Delete failed");
                }
                LoadDGV(true);
            }
        }
    }
}
