using CosmaticShop.SourceCode.SourceCode;
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
    public partial class FrmPasswordChange : Form
    {
        public FrmPasswordChange()
        {
            InitializeComponent();
        }

        private void btnChange_Click(object sender, EventArgs e)
        {
            ep.Clear();
            if(txtOldPass.Text.Trim().Length == 0)
            {
                ep.SetError(txtOldPass, "Please Enter Old Password!");
                txtOldPass.Focus();
                return;
            }
            if(txtNewpass.Text.Trim().Length == 0)
            {
                ep.SetError(txtNewpass, "Please Enter New Password!");
                txtNewpass.Focus();
                return;
            }
            if(txtConfirmPass.Text.Trim().Length == 0)
            {
                ep.SetError(txtConfirmPass, "Please Enter Confirm Password!");
                txtConfirmPass.Focus();
                return;
            }
            if(txtNewpass.Text.Trim() != txtConfirmPass.Text.Trim())
            {
                ep.SetError(txtConfirmPass, "Password Not Match1");
                txtConfirmPass.Focus();
                txtConfirmPass.SelectAll();
                return;
            }
            if (txtOldPass.Text.Trim() != UserInfo.Password)
            {
                ep.SetError(txtOldPass, "Old Password is Incorrect!");
                txtOldPass.Focus();
                txtOldPass.SelectAll();
                return;
            }
                string updatepassword = string.Format("Update EmployeeTable set Password = '{0}' where EmployeeID = '{1}'", txtNewpass.Text.Trim(), UserInfo.EmployeeID);
            bool result = DatabaseLayer.DatabaseAccess.Update(updatepassword);
            if(result == true)
            {
                MessageBox.Show("Password Change Successfully");
                UserInfo.Password = txtNewpass.Text.Trim();
                txtOldPass.Clear();
                txtNewpass.Clear();
                txtConfirmPass.Clear();
                Application.Restart();
            }
            else
            {
                MessageBox.Show("Please Try Again!");
            }
        }
    }
}
