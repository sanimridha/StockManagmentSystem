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

namespace CosmaticShop.Forms.StockForms
{
    public partial class FrmCategory : Form
    {
        public FrmCategory()
        {
            InitializeComponent();
            btnUpdate.Visible = false;
            btnCancle.Visible = false;
        }
        private void RetriveList(string searchvalue)
        {
            string query = string.Empty;
            if (string.IsNullOrEmpty(searchvalue))
            {
                query = "select CategoryID [ID],Name [Category],UserName [Create By] from V_AllCategory";
            }
            else
            {
                query = "select CategoryID [ID],Name [Category],UserName [Create By] from V_AllCategory where Name like '%"+searchvalue+"%'";
            }
            DataTable dt = DatabaseAccess.Retrive(query);
            if(dt != null)
            {
                dgvCategories.DataSource = dt;
                dgvCategories.Columns[0].Visible = false; // CategoryID
                dgvCategories.Columns[1].Width = 200; // Category
                dgvCategories.Columns[2].AutoSizeMode = DataGridViewAutoSizeColumnMode.Fill; // User Name
                dgvCategories.Rows[1].Selected = true;
            }
            else
            {
                dgvCategories.DataSource = null;
            }
        }

        private void FrmCategory_Load(object sender, EventArgs e)
        {
            RetriveList(string.Empty);
        }

        private void btnSave_Click(object sender, EventArgs e)
        {
            try
            {
                ep.Clear();
                if (txtCategory.Text.Trim().Length == 0)
                {
                    ep.SetError(txtCategory, "Please Enter Category Name");
                    txtCategory.Focus();
                    return;
                }
                DataTable dt = DatabaseAccess.Retrive("select * from CategeryTable where name = '" + txtCategory.Text.Trim() + "'");
                if (dt != null)
                {
                    if (dt.Rows.Count > 0)
                    {
                        ep.SetError(txtCategory, "Alredy Exist!");
                        txtCategory.Focus();
                        return;
                    }
                }
                string insertquery = string.Format("Insert into CategeryTable (Name,EmployeeID) values ('{0}','{1}')", txtCategory.Text.Trim(), UserInfo.EmployeeID);
                bool result = DatabaseAccess.Insert(insertquery);
                if (result == true)
                {
                    MessageBox.Show("Save Successfully.");
                    txtCategory.Clear();
                    RetriveList(string.Empty);
                    return;
                }
                else
                {
                    MessageBox.Show("Please Enter Corect Details, Please try Again!");
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("System Messege :"+ex.Message);
            }
        }

        private void ClearForm()
        {
            txtCategory.Clear();
        }
        private void EnableComponent()
        {
            btnCancle.Visible = true;
            btnUpdate.Visible = true;
            btnClear.Visible = false;
            btnSave.Visible = false;
            dgvCategories.Enabled = false;
            txtSearch.Enabled = false;

        }

        private void DisableComponent()
        {
            btnCancle.Visible = false;
            btnUpdate.Visible = false;
            btnClear.Visible = true;
            btnSave.Visible = true;
            dgvCategories.Enabled = true;
            txtSearch.Enabled = true;
            ClearForm();
            RetriveList(string.Empty);
        }

        private void txtSearch_TextChanged(object sender, EventArgs e)
        {
            RetriveList(txtSearch.Text.Trim());

        }

        private void editToolStripMenuItem_Click(object sender, EventArgs e)
        {
            try
            {
                if (dgvCategories != null)
                {
                    if (dgvCategories.Rows.Count > 0)
                    {
                        if (dgvCategories.SelectedRows.Count == 1)
                        {
                            txtCategory.Text = Convert.ToString(dgvCategories.CurrentRow.Cells[1].Value);
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

        private void btnCancle_Click(object sender, EventArgs e)
        {
            DisableComponent();
        }

        private void btnUpdate_Click(object sender, EventArgs e)
        {
            try
            {
                ep.Clear();
                if (txtCategory.Text.Trim().Length == 0)
                {
                    ep.SetError(txtCategory, "Please Enter Category Name");
                    txtCategory.Focus();
                    return;
                }
                DataTable dt = DatabaseAccess.Retrive("select * from CategeryTable where name = '" + txtCategory.Text.Trim() + "' And CategoryID !='"+Convert.ToString(dgvCategories.CurrentRow.Cells[0].Value)+"'");
                if (dt != null)
                {
                    if (dt.Rows.Count > 0)
                    {
                        ep.SetError(txtCategory, "Alredy Exist!");
                        txtCategory.Focus();
                        return;
                    }
                }
                string updatetquery = string.Format("Update CategeryTable Set Name = '{0}',EmployeeID='{1}' where CategoryID = '{2}'", txtCategory.Text.Trim(), UserInfo.EmployeeID, Convert.ToString(dgvCategories.CurrentRow.Cells[0].Value));
                bool result = DatabaseAccess.Insert(updatetquery);
                if (result == true)
                {
                    MessageBox.Show("Updated Successfully.");
                    DisableComponent();
                    return;
                }
                else
                {
                    MessageBox.Show("Please Enter Corect Details, Please try Again!");
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("System Messege :" + ex.Message);
            }
        }
    }
}
