using CosmaticShop.DatabaseLayer;
using CosmaticShop.Forms.UserForms.UserForms;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace CosmaticShop.Forms.Employees.Employees
{
    public partial class frmSearchEmployee : Form
    {
        public FrmCreateUser CreateUserForm { get; set; }
        public frmSearchEmployee(string searchvalue, FrmCreateUser createUserForm)
        {
            InitializeComponent();
            CreateUserForm = createUserForm;
            FillGrid(searchvalue);
        }
        private void FillGrid(String searchvalue)
        {
            string query = "SELECT [EmployeeID] [ID],[FullName] [Employee],[UserTypeID],[ContactNo] [Contact No],[Email] [Email Address],[CNIC] [CNIC],[Photo],[Address] [Permanent Address],[Description],[UserName],[Password],[IsActive] [Status] FROM [EmployeeTable]";
            if (!string.IsNullOrEmpty(searchvalue))
            {
                query = "SELECT [EmployeeID] [ID],[FullName] [Employee],[UserTypeID],[ContactNo] [Contact No],[Email] [Email Address],[CNIC] [CNIC],[Photo],[Address] [Permanent Address],[Description],[UserName],[Password],[IsActive] [Status] FROM [EmployeeTable] where (FullName+' ' + ContactNo+' ' + Email+' ' + CNIC+' ' + Address+' ' + Description) Like '%" + searchvalue + "%'";
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

                }
            }
            else
            {
                dgvEmployees.DataSource = null;
            }
        }
        private void FrmSearchEmployee_Load(object sender, EventArgs e)
        {

        }

        private void BtnFind_Click(object sender, EventArgs e)
        {
            FillGrid(txtSearch.Text.Trim());
        }

        public void SelectEmployee()
        {
            if(dgvEmployees != null)
            {
                if(dgvEmployees.Rows.Count > 0)
                {
                    if(dgvEmployees.SelectedRows.Count == 1)
                    {
                        if(CreateUserForm != null)
                        {
                            CreateUserForm.EmployeeID = Convert.ToInt32 (dgvEmployees.CurrentRow.Cells[0].Value); //EmployeeID
                            CreateUserForm.lblFullName.Text = Convert.ToString (dgvEmployees.CurrentRow.Cells[1].Value); //Employee
                            CreateUserForm.lblContactNo.Text = Convert.ToString (dgvEmployees.CurrentRow.Cells[3].Value); //ContactNO
                            CreateUserForm.lblCNIC.Text = Convert.ToString (dgvEmployees.CurrentRow.Cells[5].Value); //CNIC
                            string value = dgvEmployees.CurrentRow.Cells[6].Value != DBNull.Value ? Convert.ToString (dgvEmployees.CurrentRow.Cells[6].Value) : string.Empty; //Photo
                            if(!string.IsNullOrEmpty(value))
                            {
                                CreateUserForm.picEmp.Image = DatabaseAccess.Base64ToImage(value);
                            }
                            else
                            {
                                CreateUserForm.picEmp.Image = null;
                            }

                            CreateUserForm.txtUserName.Text = Convert.ToString (dgvEmployees.CurrentRow.Cells[9].Value); //Username
                            CreateUserForm.txtPassword.Text = Convert.ToString (dgvEmployees.CurrentRow.Cells[10].Value); //Password
                            CreateUserForm.txtConfirmPassword.Text = Convert.ToString(dgvEmployees.CurrentRow.Cells[10].Value); //Confirm Password
                            this.Close();
                        }
                    }
                    else
                    {
                        MessageBox.Show("Please Select One Record!");
                    }
                }
                else
                {
                    MessageBox.Show("List is Empty!");
                }
            }
            else
            {
                MessageBox.Show("List is Empty!");
            }
        }

        private void DgvEmployees_CellDoubleClick(object sender, DataGridViewCellEventArgs e)
        {
            SelectEmployee();
        }

        private void DgvEmployees_CellContentDoubleClick(object sender, DataGridViewCellEventArgs e)
        {
            SelectEmployee();
        }

        private void DgvEmployees_KeyDown(object sender, KeyEventArgs e)
        {
            if(e.KeyCode == Keys.Enter)
            {
                SelectEmployee();
            }
        }

        private void SelectToolStripMenuItem_Click(object sender, EventArgs e)
        {
            SelectEmployee();
        }

        private void TxtSearch_TextChanged(object sender, EventArgs e)
        {

        }

        private void Label4_Click(object sender, EventArgs e)
        {

        }
    }
}
