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

namespace CosmaticShop.Forms.SupplierForm
{
    public partial class FrmSupplier : Form
    {
        public FrmSupplier()
        {
            InitializeComponent();
        }

        private void RetriveList(string searchvalue)
        {
            string query = string.Empty;
            if (string.IsNullOrEmpty(searchvalue))
            {
                query = "select SupplierID [ID], Name [Supplier], ContactNo [Contact No], [Address], UserName [Created By], [Description] from v_SupplierList";
            }
            else
            {
                query = " select SupplierID [ID], Name [Supplier], ContactNo [Contact No], [Address], UserName [Created By], [Description] from v_SupplierList" +
                            " Where (Name + ' '+ ContactNo + ' ' + Address + ' ' + UserName) Like '%"+ searchvalue.Trim()+ "%'";
            }
            DataTable dt = DatabaseAccess.Retrive(query);
            if (dt != null)
            {
                dgvSuppliers.DataSource = dt;
                dgvSuppliers.Columns[0].Visible = false; // SupplierID
                dgvSuppliers.Columns[1].Width = 200; // Name
                dgvSuppliers.Columns[2].Width = 120; // ContactNo
                dgvSuppliers.Columns[3].Width = 250; // Address
                dgvSuppliers.Columns[4].Width = 100; // UserName
                dgvSuppliers.Columns[5].Width = 250; // Description
                dgvSuppliers.Rows[1].Selected = true;

            }
            else
            {
                dgvSuppliers.DataSource = null;
            }
        }
        private void ClearForm()
        {
            txtSupplier.Clear();
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
            dgvSuppliers.Enabled = false;
            txtSearch.Enabled = false;

        }

        private void DisableComponent()
        {
            btnCancel.Visible = false;
            btnUpdate.Visible = false;
            btnClear.Visible = true;
            btnSave.Visible = true;
            dgvSuppliers.Enabled = true;
            txtSearch.Enabled = true;
            ClearForm();
            RetriveList(string.Empty);
        }

        private void FrmSupplier_Load(object sender, EventArgs e)
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
                if (txtSupplier.Text.Trim().Length == 0)
                {
                    ep.SetError(txtSupplier, "Please Enter Supplier Titel!");
                    txtSupplier.Focus();
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

                DataTable dt = DatabaseAccess.Retrive("select * from SupplierTable where name ='" + txtSupplier.Text.Trim() + "' and ContactNo = '" + txtContactNo.Text.Trim() + "'");
                if(dt != null)
                {
                    if(dt.Rows.Count > 0)
                    {
                        ep.SetError(txtSupplier, "Already Exist!");
                        txtSupplier.Focus();
                        return;
                    }
                }

                string insertquery = string.Format("insert into SupplierTable(EmployeeID,Name,ContactNo,Address,Description) values ('{0}','{1}','{2}','{3}','{4}')", 
                    UserInfo.EmployeeID, txtSupplier.Text.Trim(), txtContactNo.Text.Trim(), txtAddress.Text.Trim(), txtDescription.Text.Trim());
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
                if (txtSupplier.Text.Trim().Length == 0)
                {
                    ep.SetError(txtSupplier, "Please Enter Supplier Titel!");
                    txtSupplier.Focus();
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

                DataTable dt = DatabaseAccess.Retrive("select * from SupplierTable where name ='" + txtSupplier.Text.Trim() + "' and ContactNo = '" + txtContactNo.Text.Trim() + "' AND SupplierID !=  '"+Convert.ToString(dgvSuppliers.CurrentRow.Cells[0].Value)+"'");
                if (dt != null)
                {
                    if (dt.Rows.Count > 0)
                    {
                        ep.SetError(txtSupplier, "Already Exist!");
                        txtSupplier.Focus();
                        return;
                    }
                }

                string updatequery = string.Format("update SupplierTable set EmployeeID = '{0}',Name = '{1}',ContactNo = '{2}',Address = '{3}',Description = '{4}' where SupplierID = '{5}'",
                    UserInfo.EmployeeID, txtSupplier.Text.Trim(), txtContactNo.Text.Trim(), txtAddress.Text.Trim(), txtDescription.Text.Trim(),Convert.ToString(dgvSuppliers.CurrentRow.Cells[0].Value));
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
                if (dgvSuppliers != null)
                {
                    if (dgvSuppliers.Rows.Count > 0)
                    {
                        if (dgvSuppliers.SelectedRows.Count == 1)
                        {
                            txtSupplier.Text = Convert.ToString(dgvSuppliers.CurrentRow.Cells[1].Value); // Name
                            txtContactNo.Text = Convert.ToString(dgvSuppliers.CurrentRow.Cells[2].Value); // Contact
                            txtAddress.Text = Convert.ToString(dgvSuppliers.CurrentRow.Cells[3].Value); // Address
                            txtDescription.Text = Convert.ToString(dgvSuppliers.CurrentRow.Cells[5].Value); // Description
                            
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
