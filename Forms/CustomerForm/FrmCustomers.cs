using CosmaticShop.DatabaseLayer;
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

namespace CosmaticShop.Forms.CustomerForm
{
    public partial class FrmCustomers : Form
    {
        public FrmCustomers()
        {
            InitializeComponent();
        }

        private void RetriveList(string searchvalue)
        {
            string query = string.Empty;
            if (string.IsNullOrEmpty(searchvalue))
            {
                query = "select CustomerID [ID], Name [Customer], ContactNo [Contact No], [Address], UserName [Created By], [Description] from v_CustomerList";
            }
            else
            {
                query = " select CustomerID [ID], Name [Customer], ContactNo [Contact No], [Address], UserName [Created By], [Description] from v_CustomerList" +
                            " Where (Name + ' '+ ContactNo + ' ' + Address + ' ' + UserName) Like '%"+searchvalue.Trim()+"%'";
            }
            DataTable dt = DatabaseAccess.Retrive(query);
            if (dt != null)
            {
                dgvCustomers.DataSource = dt;
                dgvCustomers.Columns[0].Visible = false; // CustomerID
                dgvCustomers.Columns[1].Width = 200; // Name
                dgvCustomers.Columns[2].Width = 120; // ContactNo
                dgvCustomers.Columns[3].Width = 250; // Address
                dgvCustomers.Columns[4].Width = 100; // UserName
                dgvCustomers.Columns[5].Width = 250; // Description
                dgvCustomers.Rows[1].Selected = true;


            }
            else
            {
                dgvCustomers.DataSource = null;
            }
        }
        private void ClearForm()
        {
            txtCustomer.Clear();
            txtContactNo.Clear();
            txtDescription.Clear();
            txtAddress.Clear();
        }
        private void EnableComponent()
        {
            btnCancel.Visible = true;
            btnUpdate.Visible = true;
            btnClear.Visible = false;
            btnSave.Visible = false;
            dgvCustomers.Enabled = false;
            txtSearch.Enabled = false;

        }

        private void DisableComponent()
        {
            btnCancel.Visible = false;
            btnUpdate.Visible = false;
            btnClear.Visible = true;
            btnSave.Visible = true;
            dgvCustomers.Enabled = true;
            txtSearch.Enabled = true;
            ClearForm();
            RetriveList(string.Empty);
        }

        private void FrmCustomers_Load(object sender, EventArgs e)
        {
            DisableComponent();
            RetriveList(string.Empty);
        }

        private void BtnClear_Click(object sender, EventArgs e)
        {
            ClearForm();
        }

        private void BtnCancel_Click(object sender, EventArgs e)
        {
            DisableComponent();
        }

        private void BtnSave_Click(object sender, EventArgs e)
        {
            try
            {
                ep.Clear();
                if (txtCustomer.Text.Trim().Length == 0)
                {
                    ep.SetError(txtCustomer, "Please Enter Customer Titel!");
                    txtCustomer.Focus();
                    return;
                }

                if (txtContactNo.Text.Trim().Length == 0)
                {
                    ep.SetError(txtContactNo, "Please Enter Contact No!");
                    txtContactNo.Focus();
                    return;
                }

                if (txtAddress.Text.Trim().Length == 0)
                {
                    ep.SetError(txtAddress, "Please Enter Permanent Address!");
                    txtAddress.Focus();
                    return;
                }

                DataTable dt = DatabaseAccess.Retrive("select * from CustomerTable where name ='" + txtCustomer.Text.Trim() + "' and ContactNo = '" + txtContactNo.Text.Trim() + "'");
                if (dt != null)
                {
                    if (dt.Rows.Count > 0)
                    {
                        ep.SetError(txtCustomer, "Already Exist!");
                        txtCustomer.Focus();
                        return;
                    }
                }

                string insertquery = string.Format("insert into CustomerTable(EmployeeID,Name,ContactNo,Address,Description) values ('{0}','{1}','{2}','{3}','{4}')",
                    UserInfo.EmployeeID, txtCustomer.Text.Trim(), txtContactNo.Text.Trim(), txtAddress.Text.Trim(), txtDescription.Text.Trim());
                bool result = DatabaseAccess.Insert(insertquery);
                if (result == true)
                {
                    MessageBox.Show("Save Successfully");
                    RetriveList(string.Empty);
                    ClearForm();
                }
                else
                {
                    MessageBox.Show("Please Provide Correct Details, And try Again!");
                }
            }
            catch
            {
                MessageBox.Show("Please Provide Correct Details, And try Again!");
            }
        }

        private void BtnUpdate_Click(object sender, EventArgs e)
        {
            try
            {
                ep.Clear();
                if (txtCustomer.Text.Trim().Length == 0)
                {
                    ep.SetError(txtCustomer, "Please Enter Customer Titel!");
                    txtCustomer.Focus();
                    return;
                }

                if (txtContactNo.Text.Trim().Length == 0)
                {
                    ep.SetError(txtContactNo, "Please Enter Contact No!");
                    txtContactNo.Focus();
                    return;
                }

                if (txtAddress.Text.Trim().Length == 0)
                {
                    ep.SetError(txtAddress, "Please Enter Permanent Address!");
                    txtAddress.Focus();
                    return;
                }

                DataTable dt = DatabaseAccess.Retrive("select * from CustomerTable where name ='" + txtCustomer.Text.Trim() + "' and ContactNo = '" + txtContactNo.Text.Trim() + "' AND CustomerID !=  '" + Convert.ToString(dgvCustomers.CurrentRow.Cells[0].Value) + "'");
                if (dt != null)
                {
                    if (dt.Rows.Count > 0)
                    {
                        ep.SetError(txtCustomer, "Already Exist!");
                        txtCustomer.Focus();
                        return;
                    }
                }

                string updatequery = string.Format("update CustomerTable set EmployeeID = '{0}',Name = '{1}',ContactNo = '{2}',Address = '{3}',Description = '{4}' where CustomerID = '{5}'",
                    UserInfo.EmployeeID, txtCustomer.Text.Trim(), txtContactNo.Text.Trim(), txtAddress.Text.Trim(), txtDescription.Text.Trim(), Convert.ToString(dgvCustomers.CurrentRow.Cells[0].Value));
                bool result = DatabaseAccess.Insert(updatequery);
                if (result == true)
                {
                    MessageBox.Show("Updated Successfully");
                    DisableComponent();
                }
                else
                {
                    MessageBox.Show("Please Provide Correct Details, And try Again!");
                }
            }
            catch
            {
                MessageBox.Show("Please Provide Correct Details, And try Again!");
            }
        }

        private void EditToolStripMenuItem_Click(object sender, EventArgs e)
        {
            try
            {
                if (dgvCustomers != null)
                {
                    if (dgvCustomers.Rows.Count > 0)
                    {
                        if (dgvCustomers.SelectedRows.Count == 1)
                        {
                            txtCustomer.Text = Convert.ToString(dgvCustomers.CurrentRow.Cells[1].Value); // Name
                            txtContactNo.Text = Convert.ToString(dgvCustomers.CurrentRow.Cells[2].Value); // Contact
                            txtAddress.Text = Convert.ToString(dgvCustomers.CurrentRow.Cells[3].Value); // Address
                            txtDescription.Text = Convert.ToString(dgvCustomers.CurrentRow.Cells[5].Value); // Description

                            EnableComponent();
                        }
                        else
                        {
                            MessageBox.Show("Please Select One Record");
                        }
                    }
                    else
                    {
                        MessageBox.Show("List is Empty");
                    }
                }
            }
            catch
            {
                MessageBox.Show("Please Select One Record");
            }
        }

        private void TxtSearch_TextChanged(object sender, EventArgs e)
        {
            RetriveList(txtSearch.Text.Trim());
        }
    }
}
