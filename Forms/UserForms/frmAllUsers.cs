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

namespace CosmaticShop.Forms.UserForms.UserForms
{
    public partial class frmAllUsers : Form
    {
        public frmAllUsers()
        {
            InitializeComponent();
        }
        private void FillGrid(String searchvalue)
        {
            string query = "SELECT [EmployeeID] [ID],[FullName] [Employee],[UserTypeID],[ContactNo] [Contact No],[Email] [Email Address],[CNIC] [CNIC],[Photo],[Address] [Permanent Address],[Description],[UserName],[Password],[IsActive] [Status] FROM [EmployeeTable] WHERE UserName is not null";
            if (!string.IsNullOrEmpty(searchvalue))
            {
                query = "SELECT [EmployeeID] [ID],[FullName] [Employee],[UserTypeID],[ContactNo] [Contact No],[Email] [Email Address],[CNIC] [CNIC],[Photo],[Address] [Permanent Address],[Description],[UserName],[Password],[IsActive] [Status] FROM [EmployeeTable] where (FullName+' ' + ContactNo+' ' + Email+' ' + CNIC+' ' + Address+' ' + Description) Like '%" + searchvalue + "%' AND UserName is not null";
            }
            DataTable dt = DatabaseAccess.Retrive(query);
            if (dt != null)
            {
                dgvAllUsers.DataSource = dt;
                if (dt.Rows.Count > 0)
                {

                    dgvAllUsers.Columns[0].Width = 100;  //EmployeeID
                    dgvAllUsers.Columns[1].Width = 150;   //Employee
                    dgvAllUsers.Columns[2].Visible = false;  //UserTypeID
                    dgvAllUsers.Columns[3].Width = 100;  //ContactNO
                    dgvAllUsers.Columns[4].Width = 150;   //Email
                    dgvAllUsers.Columns[5].Width = 100;  //CNIC
                    dgvAllUsers.Columns[6].Visible = false;  //Photo
                    dgvAllUsers.Columns[11].Width = 80;  //status
                    dgvAllUsers.Columns[7].Width = 250;  //Description
                    dgvAllUsers.Columns[8].Width = 200;  //Address
                    dgvAllUsers.Columns[9].Width = 80;   //Username
                    dgvAllUsers.Columns[10].Visible = false;  //Password

                }
            }
            else
            {
                dgvAllUsers.DataSource = null;
            }
        }

        private void FrmAllUsers_Load(object sender, EventArgs e)
        {
            FillGrid(string.Empty);
        }

        private void BtnFind_Click(object sender, EventArgs e)
        {
            FillGrid(txtSearch.Text.Trim());
        }

        private void RemoveToolStripMenuItem_Click(object sender, EventArgs e)
        {
            RemoveIser();
        }

        public void RemoveIser()
        {
            if(dgvAllUsers != null)
            {
                if(dgvAllUsers.SelectedRows.Count > 0)
                {
                    if(dgvAllUsers.SelectedRows.Count ==1)
                    {
                        

                        int employeeid = Convert.ToInt32(dgvAllUsers.CurrentRow.Cells[0].Value);
                        int usertypeid = Convert.ToInt32(dgvAllUsers.CurrentRow.Cells[2].Value);
                        if (usertypeid != 1)
                        {
                            string removequery = string.Format("update EmployeeTable set UserName = NULL where EmployeeID = '{0}'", employeeid);
                            bool result = DatabaseAccess.Update(removequery);
                            if (result == true)
                            {
                                MessageBox.Show("User Remove Successfully!");
                                FillGrid(txtSearch.Text.Trim());
                            }
                        }
                        else
                        {
                            MessageBox.Show("Admin can remove itself!");
                        }
                    }
                    else
                    {
                        MessageBox.Show("Please Select One Record!");
                    }
                }
                else
                {
                    MessageBox.Show("List Empty!");
                }
            }
            else
            {
                MessageBox.Show("List Empty!");
            }
        }
    }
}
