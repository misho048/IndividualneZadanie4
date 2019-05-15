﻿using Data.Models;
using System;
using System.Windows.Forms;

namespace Individualne_Zadanie_4
{
    public partial class frmEmployeesEdit : Form
    {
        #region fields
        private EmployeesEditViewModel _employeesOverviewViewModel = new EmployeesEditViewModel();

        private bool _makeCollumns = true;
        #endregion

        /// <summary>
        /// readonlyproperty for selected employee ID
        /// </summary>
        public int SelectedId { private set; get; }


        #region formEvents and buttonEvents
        public frmEmployeesEdit()
        {
            InitializeComponent();
        }

        private void BtnAllEmployees_Click(object sender, EventArgs e)
        {
            LoadDGV(true);
        }


        private void FrmEmployeesOverView_Load(object sender, EventArgs e)
        {
            LoadDGV(true);
        }


        private void BtnUnsignedEmployees_Click(object sender, EventArgs e)
        {
            LoadDGV(false);
        }


        private void BtnBack_Click_1(object sender, EventArgs e)
        {
            DialogResult = DialogResult.Cancel;
        }


        private void BtnSelect_Click(object sender, EventArgs e)
        {
            if (dGVOverview.CurrentCell == null)
            {
                MessageBox.Show("Invalid Selection");
            }
            else
            {
                SelectedId = (int)dGVOverview.CurrentRow.Cells["Id"].Value;
                DialogResult = DialogResult.OK;

            }
        }


        private void BtnCreate_Click(object sender, EventArgs e)
        {
            frmCreateEditEmployee createEditEmployee = new frmCreateEditEmployee();
            createEditEmployee.ShowDialog();
            if (createEditEmployee.DialogResult == DialogResult.OK)
            {
                LoadDGV(true);
            }
        }


        private void BtnEdit_Click(object sender, EventArgs e)
        {
            if (dGVOverview.CurrentCell == null)
            {
                MessageBox.Show("Invalid Selection");
            }
            else
            {

                frmCreateEditEmployee createEditEmployee = new frmCreateEditEmployee((ModelEmployee)dGVOverview.CurrentRow.DataBoundItem);
                createEditEmployee.ShowDialog();
                if (createEditEmployee.DialogResult == DialogResult.OK)
                {
                    LoadDGV(true);
                }
            }
        }


        private void BtnDelete_Click(object sender, EventArgs e)
        {
            if (dGVOverview.CurrentCell == null)
            {
                MessageBox.Show("Invalid Selection");
            }
            else
            {
                DialogResult dialogResult = MessageBox.Show($"!!Warning!!\n You are going to delete employee " +
                $"{dGVOverview.CurrentRow.Cells["Name"].Value.ToString()} {dGVOverview.CurrentRow.Cells["Surname"].Value.ToString()}" +
                $" Are you sure?", "Deleting Employee", MessageBoxButtons.YesNo);

                if (dialogResult == DialogResult.Yes)
                {
                    if (_employeesOverviewViewModel.DeteleEmployee((ModelEmployee)dGVOverview.CurrentRow.DataBoundItem))
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
        #endregion

        /// <summary>
        /// Loads data for DataGridView
        /// </summary>
        /// <param name="haveDepartment"></param>
        private void LoadDGV(bool haveDepartment)
        {
            if (haveDepartment)
            {
                dGVOverview.DataSource = _employeesOverviewViewModel.GetAllEmployees();

                if (_makeCollumns)
                {

                    dGVOverview.Columns.Add("DepartmentName", "Name of the Department");
                    dGVOverview.Columns.Add("DepartmentCode", "Code of the Department");
                    _makeCollumns = false;
                }
                else
                {
                    dGVOverview.Columns["DepartmentName"].Visible = true;
                    dGVOverview.Columns["DepartmentCode"].Visible = true;
                }


                foreach (DataGridViewRow row in dGVOverview.Rows)
                {
                    if (row.Cells["Id"].Value == null)
                    {
                        break;
                    }
                    else
                    {
                        (string depName, string depCode) = _employeesOverviewViewModel.GetDepartmentNameByEmployee((int)(row.Cells["Id"].Value));
                        row.Cells["DepartmentName"].Value = depName;
                        row.Cells["DepartmentCode"].Value = depCode;
                    }

                }
            }
            else
            {
                dGVOverview.DataSource = _employeesOverviewViewModel.GetUnsignedEmployees();
                dGVOverview.Columns["DepartmentName"].Visible = false;
                dGVOverview.Columns["DepartmentCode"].Visible = false;

            }

            dGVOverview.Columns["Id"].Visible = false;
            dGVOverview.Columns["DepartmentId"].Visible = false;
        }

    }
}
