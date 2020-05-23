using CosmaticShop.Forms.Employees.Employees;
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
    public partial class FrmCreateUser : Form
    {
        public int EmployeeID = 0;
        public FrmCreateUser()
        {
            InitializeComponent();
        }

        private void BtnFind_Click(object sender, EventArgs e)
        {
            frmSearchEmployee frm = new frmSearchEmployee(txtSearch.Text.Trim(),this);
            frm.ShowDialog();

        }

        private void BtnClose_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void BtnRegister_Click(object sender, EventArgs e)
        {
            try
            {
                ep.Clear();
                if (EmployeeID == 0)
                {
                    ep.SetError(btnFind, "Please First Find Employee!");
                    txtSearch.Focus();
                    return;
                }
                if (txtUserName.Text.Trim().Length == 0)
                {
                    ep.SetError(txtUserName, "Please Enter a User Name!");
                    txtUserName.Focus();
                    return;
                }
                if (txtPassword.Text.Trim().Length == 0)
                {
                    ep.SetError(txtPassword, "Please Enter Password!");
                    txtPassword.Focus();
                    return;
                }
                if (txtConfirmPassword.Text.Trim().Length == 0)
                {
                    ep.SetError(txtConfirmPassword, "Please Confirm Your Password!");
                    txtConfirmPassword.Focus();
                    return;
                }
                if (txtPassword.Text != txtConfirmPassword.Text)
                {
                    ep.SetError(txtConfirmPassword, "Not Match!");
                    txtConfirmPassword.Focus();
                    txtConfirmPassword.SelectAll();
                    return;
                }
                DataTable dt = DatabaseLayer.DatabaseAccess.Retrive(string.Format("select * from EmployeeTable where UserName = '{0}' AND EmployeeID != '{1}'",
                    txtUserName.Text.Trim(), EmployeeID));
                if (dt != null)
                {
                    if (dt.Rows.Count > 0)
                    {
                        ep.SetError(txtUserName, "User Name Exists!");
                        txtUserName.Focus();
                        txtUserName.SelectAll();
                        return;
                    }
                }

                string createuser = string.Format("update EmployeeTable set UserName = '{0}', Password = '{1}' where EmployeeID = '{2}'", txtUserName.Text.Trim(), txtPassword.Text.Trim(), EmployeeID);
                bool result = DatabaseLayer.DatabaseAccess.Update(createuser);
                if (result == true)
                {
                    MessageBox.Show("User Created Successfully!");
                    EmployeeID = 0;
                    lblFullName.Text = "";
                    lblContactNo.Text = "";
                    picEmp.Image = null;
                    lblCNIC.Text = "";
                    txtUserName.Clear();
                    txtPassword.Clear();
                    txtConfirmPassword.Clear();
                }
                else
                {
                    MessageBox.Show("Please Try Again!");
                }
            }
            catch
            {

                MessageBox.Show("Please Try Again!");  
            }

        }
    }
}
