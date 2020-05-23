using CosmaticShop.DatabaseLayer;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace CosmaticShop.Forms.Employees
{
    public partial class testform : Form
    {
        FrmEmployeeSalary allemployees;
        HomeForm homeForm;
        public testform(string value, FrmEmployeeSalary FromEmployeeSalary)
        {
            InitializeComponent();
            allemployees = FromEmployeeSalary;
            txtSearch.Text = value;
        }

        private void FillGrid(String searchvalue)
        {
            string query = "SELECT [EmployeeID] [ID],[FullName] [Employee],[UserTypeID],[ContactNo] [Contact No],[Email] [Email Address],[CNIC] [CNIC],[Photo],[Address] [Permanent Address],[Description],[UserName],[Password],[IsActive] [Status],[Salary],[JoiningDate] FROM [EmployeeTable]";
            if (!string.IsNullOrEmpty(searchvalue))
            {
                query = "SELECT [EmployeeID] [ID],[FullName] [Employee],[UserTypeID],[ContactNo] [Contact No],[Email] [Email Address],[CNIC] [CNIC],[Photo],[Address] [Permanent Address],[Description],[UserName],[Password],[IsActive] [Status],[Salary],[JoiningDate]  FROM [EmployeeTable] where (FullName+' ' + ContactNo+' ' + Email+' ' + CNIC+' ' + Address+' ' + Description) Like '%" + searchvalue + "%'";
            }
            DataTable dt = DatabaseAccess.Retrive(query);
            if (dt != null)
            {
                dgvEmployees.DataSource = dt;
                if (dt.Rows.Count > 0)
                {

                    dgvEmployees.Columns[0].Width = 100;  //EmployeeID
                    dgvEmployees.Columns[1].Width = 150;   //Employee
                    dgvEmployees.Columns[2].Visible = false;  //UserTypeID
                    dgvEmployees.Columns[3].Width = 100;  //ContactNO
                    dgvEmployees.Columns[4].Width = 150;   //Email
                    dgvEmployees.Columns[5].Width = 100;  //CNIC
                    dgvEmployees.Columns[6].Visible = false;  //Photo
                    dgvEmployees.Columns[11].Width = 80;  //status
                    dgvEmployees.Columns[7].Width = 250;  //Description
                    dgvEmployees.Columns[8].Width = 200;  //Address
                    dgvEmployees.Columns[9].Visible = false;   //Username
                    dgvEmployees.Columns[10].Visible = false;  //Password
                    dgvEmployees.Columns[12].Width = 100;  //Salary
                    dgvEmployees.Columns[13].Width = 120;  //joiningdate

                }
            }
            else
            {
                dgvEmployees.DataSource = null;
            }
        }

        private void Testform_Load(object sender, EventArgs e)
        {
            FillGrid(txtSearch.Text.Trim());
        }

        private void TxtSearch_TextChanged(object sender, EventArgs e)
        {
            FillGrid(txtSearch.Text.Trim());
        }

        private void TxtSearch_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
            {
                if (dgvEmployees.Rows.Count > 0)
                {
                    if (dgvEmployees.SelectedRows.Count == 1)
                    {
                        SelecteEmployee();
                    }
                    else
                    {
                        dgvEmployees.Rows[3].Selected = true;
                        SelecteEmployee();
                    }
                }
            }
        }
        private void SelecteEmployee()
        {
            if (allemployees != null)
            {
                allemployees.lblHavetoPay.Text =Convert.ToInt32( dgvEmployees.CurrentRow.Cells[12].Value).ToString();
                allemployees.lblEmployeeName.Text = Convert.ToString(dgvEmployees.CurrentRow.Cells[1].Value);
                allemployees.lblContructNo.Text = Convert.ToString(dgvEmployees.CurrentRow.Cells[3].Value);
                allemployees.txtJoiningDate.Text = Convert.ToDateTime(dgvEmployees.CurrentRow.Cells[13].Value).ToString();
                allemployees.txtActiveStatus.Text = Convert.ToBoolean(dgvEmployees.CurrentRow.Cells[11].Value).ToString();
                
                



                this.Close();
            }
        }
    }
}
