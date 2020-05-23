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
    public partial class FrmUserLogin : Form
    {
        private HomeForm FormHome;
        public FrmUserLogin(HomeForm homeForm)
        {
            InitializeComponent();
            FormHome = homeForm;
            lblError.Visible = false;
        }

        private void btnLogin_Click(object sender, EventArgs e)
        {
            Login();
        }
        private void Login()
        {
            ep.Clear();
            if (txtUserName.Text.Trim().Length == 0)
            {
                ep.SetError(txtUserName, "Plese Enter Corect User Name!");
                txtUserName.Focus();
                return;
            }
            if (txtPassword.Text.Trim().Length == 0)
            {
                ep.SetError(txtPassword, "Plese Enter Corect Password!");
                txtPassword.Focus();
                return;
            }
            DataTable dt = DatabaseLayer.DatabaseAccess.Retrive(
                string.Format("select EmployeeID,UserTypeID,Email,Password from EmployeeTable where UserName = '{0}' And Password ='{1}'", txtUserName.Text.Trim(), txtPassword.Text.Trim()));

            if (dt != null)
            {
                if (dt.Rows.Count == 1)
                {
                    UserInfo.EmployeeID = Convert.ToInt32(dt.Rows[0][0]);
                    UserInfo.UserTypeID = Convert.ToInt32(dt.Rows[0][1]);
                    UserInfo.Email = Convert.ToString(dt.Rows[0][2]);
                    UserInfo.Password = Convert.ToString(dt.Rows[0][3]);

                    lblError.Visible = false;
                    FormHome.Login();
                    this.Close();
                }
                else
                {
                    lblError.Visible = true;
                }
            }
            else
            {
                lblError.Visible = true;
            }
        }

        private void btnClose_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void txtUserName_KeyDown(object sender, KeyEventArgs e)
        {
            if(e.KeyCode == Keys.Enter)
            {
                Login();
            }
        }

        private void lblForgatePassward_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
            FrmForgotPassword ffp = new FrmForgotPassword();
            ffp.ShowDialog();
        }
    }
}
