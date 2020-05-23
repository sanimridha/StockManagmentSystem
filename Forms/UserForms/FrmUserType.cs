using CosmaticShop.DatabaseLayer;
using System;
using System.Data;
using System.Windows.Forms;

namespace CosmaticShop.Forms.UserForms
{
    public partial class FrmUserType : Form
    {
        public FrmUserType()
        {
            InitializeComponent();
        }
        private void FillGrid(String searchvalue)
        {
            string query = "Select UserTypeID [ID], UserType [User Type] From UserTypeTable";
            if (!string.IsNullOrEmpty(searchvalue))
            {
                query = "Select UserTypeID [ID], UserType [User Type] From UserTypeTable where UserType Like '%"+searchvalue+"%'";
            }
            DataTable dt = DatabaseAccess.Retrive(query);
            if (dt != null)
            {
                dgvUserType.DataSource = dt;
                if (dt.Rows.Count > 0)
                {
                    dgvUserType.Columns[0].Width = 100;
                    dgvUserType.Columns[1].AutoSizeMode = DataGridViewAutoSizeColumnMode.Fill;
                }
            }
            else
            {
                dgvUserType.DataSource = null;
            }
        }

        private void ClearForm()
        {
            txtUserType.Clear();
        }


        //Clear button Click  Event
        private void btnClear_Click(object sender, EventArgs e)
        {
            ClearForm();
            FillGrid(String.Empty);
            txtSearh.Clear();


        }

        private void FrmUserType_Load(object sender, EventArgs e)
        {
            FillGrid(String.Empty);
        }

        private void txtSearh_TextChanged(object sender, EventArgs e)
        {
            FillGrid(txtSearh.Text.Trim());
        }


        // Save Click Event Or Save Action Method
        private void btnSave_Click(object sender, EventArgs e)
        {
            ep.Clear();
            if(txtUserType.Text.Trim().Length == 0)
            {
                ep.SetError(txtUserType, "Please Enter User Type Titel!");
                txtUserType.Focus();
                return;
            }
            DataTable dt = DatabaseAccess.Retrive("Select * from UserTypeTable Where UserType like = '"+txtUserType.Text.Trim()+"'");
            if(dt != null)
            {
                if (dt.Rows.Count > 0)
                {
                    ep.SetError(txtUserType, "Alredy Register!");
                    txtUserType.Focus();
                    txtUserType.SelectAll();
                    return;
                }
            }
            string insertquery = string.Format("insert into UserTypeTable(UserType) values ('" + txtUserType.Text.Trim() + "')");
            bool result = DatabaseAccess.Insert(insertquery);
            if(result == true)
            {
                btnClear_Click(sender, e);
                MessageBox.Show("Save Successfully!");
            }
            else
            {
                ep.SetError(btnSave, "Please Try Again");
                txtUserType.Focus();
            }

        }

        private void EnableComponents()
        {
            btnCancle.Enabled = true;
            btnUpdate.Enabled = true;
            dgvUserType.Enabled = false;
            btnSave.Enabled = false;
            txtSearh.Enabled = false;
        }

        private void RestComponents()
        {
            btnCancle.Enabled = false;
            btnUpdate.Enabled = false;
            dgvUserType.Enabled = true;
            btnSave.Enabled = true;
            txtSearh.Enabled = true;
            ClearForm();
            FillGrid(String.Empty);
            txtSearh.Clear();
        }

        private void tsmiEdit_Click(object sender, EventArgs e)
        {
            if(dgvUserType != null)
            {
                if(dgvUserType.Rows.Count > 0)
                {
                    if(dgvUserType.SelectedRows.Count == 1)
                    {
                        txtUserType.Text = Convert.ToString(dgvUserType.CurrentRow.Cells[1].Value);
                        EnableComponents();

                    }
                    else
                    {
                        MessageBox.Show("Please Select One Record", "Warning", MessageBoxButtons.OK, MessageBoxIcon.Warning);

                    }
                }
            }
        }

        private void btnUpdate_Click(object sender, EventArgs e)
        {
            ep.Clear();
            if (txtUserType.Text.Trim().Length == 0)
            {
                ep.SetError(txtUserType, "Please Enter User Type Titel!");
                txtUserType.Focus();
                return;
            }
            DataTable dt = DatabaseAccess.Retrive("Select * from UserTypeTable Where UserType like = '" + txtUserType.Text.Trim() + "' Where UserTypeID != '" + Convert.ToString(dgvUserType.CurrentRow.Cells[0].Value) + "'");
            if (dt != null)
            {
                if (dt.Rows.Count > 0)
                {
                    ep.SetError(txtUserType, "Alredy Register!");
                    txtUserType.Focus();
                    txtUserType.SelectAll();
                    return;
                }
            }
            string insertquery = string.Format("Update UserTypeTable set UserType ='" + txtUserType.Text.Trim() + "' Where UserTypeID='"+Convert.ToString(dgvUserType.CurrentRow.Cells[0].Value)+"'");
            bool result = DatabaseAccess.Update(insertquery);
            if (result == true)
            {
                RestComponents();
                MessageBox.Show("Update Successfully!");
            }
            else
            {
                ep.SetError(btnUpdate, "Please Try Again");
                txtUserType.Focus();
            }
        }

        private void btnCancle_Click(object sender, EventArgs e)
        {
            RestComponents();

        }
    }
}
