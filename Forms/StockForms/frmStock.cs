using CosmaticShop.DatabaseLayer;
using CosmaticShop.SourceCode;
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
    public partial class frmStock : Form
    {
        public frmStock()
        {
            InitializeComponent();
        }

        private void RetriveList(string searchvalue)
        {
            string query = string.Empty;
            if (string.IsNullOrEmpty(searchvalue))
            {
                query = "select ItemID [ID], IsActive [Status], Name [Product], CategoryID, Category, Qty, CurrentPurchaseUnitPrice [Purchase Unit Price], SaleUnitPrice [Sale Unit Price], ManuDate [Manu Date], ExpDate [Exp Date], UserName [Created By] from v_StockList";
            }
            else
            {
                query = "select ItemID [ID], Name [Product], CategoryID, Category, Qty, CurrentPurchaseUnitPrice [Purchase Unit Price], SaleUnitPrice [Sale Unit Price], ManuDate [Manu Date], ExpDate [Exp Date], IsActive [Status], UserName [Created By] from v_StockList " +
                            " Where (Name + ' '+ Category + ' ' + UserName) Like '%"+ searchvalue.Trim()+ "%'";

            }
            DataTable dt = DatabaseAccess.Retrive(query);
            if (dt != null)
            {
                dgvStock.DataSource = dt;
                dgvStock.Columns[0].Visible = false; // ItemID
                dgvStock.Columns[1].Width = 50; // Status
                dgvStock.Columns[2].Width = 150; // Name
                dgvStock.Columns[3].Visible = false; // CategoryID
                dgvStock.Columns[4].Width = 100; // Category
                dgvStock.Columns[5].Width = 80; // Qty
                dgvStock.Columns[6].Width = 80; // CurrentPurchaseUnitPrice
                dgvStock.Columns[7].Width = 80; // SaleUnitPrice
                dgvStock.Columns[8].Width = 120; // ManuDate
                dgvStock.Columns[9].Width = 120; // ExpDate
                dgvStock.Columns[10].Width = 100; // UserName
                
            }
            else
            {
                dgvStock.DataSource = null;
            }
        }
        private void ClearForm()
        {
            txtItem.Clear();
            cmbCategory.SelectedIndex = 0;
            chkStatus.Checked = true;
        }
        private void EnableComponent()
        {
            btnCancel.Visible = true;
            btnUpdate.Visible = true;
            btnClear.Visible = false;
            btnSave.Visible = false;
            dgvStock.Enabled = false;
            txtSearch.Enabled = false;

        }

        private void DisableComponent()
        {
            btnCancel.Visible = false;
            btnUpdate.Visible = false;
            btnClear.Visible = true;
            btnSave.Visible = true;
            dgvStock.Enabled = true;
            txtSearch.Enabled = true;
            ClearForm();
            RetriveList(string.Empty);
        }

        private void FrmStock_Load(object sender, EventArgs e)
        {
            ComboHelper.Categories(cmbCategory);
            chkStatus.Checked = true;
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
                if (txtItem.Text.Trim().Length == 0)
                {
                    ep.SetError(txtItem, "Please Enter Item Name!");
                    txtItem.Focus();
                    return;
                }
                if (cmbCategory.SelectedIndex == 0)
                {
                    ep.SetError(cmbCategory, "Please Select Category");
                    cmbCategory.Focus();
                    return;
                }

                DataTable dt = DatabaseAccess.Retrive("select * from StockTable where CategoryID = '" + cmbCategory.SelectedValue + "' and Name = '" + txtItem.Text.Trim() + "'");
                if (dt != null)
                {
                    if (dt.Rows.Count > 0)
                    {
                        ep.SetError(txtItem, "Already Exist!");
                        txtItem.Focus();
                        txtItem.SelectAll();
                        return;
                    }
                }
                string insertquery = string.Format("insert into StockTable(CategoryID,EmployeeID,Name,IsActive,ManuDate,ExpDate) values('{0}','{1}','{2}','{3}','{4}','{5}')",
                cmbCategory.SelectedValue, UserInfo.EmployeeID, txtItem.Text.Trim(), chkStatus.Checked,dtpManuDate.Value.ToString("yyyy/MM/dd"),dtpExpDate.Value.ToString("yyyy/MM/dd"));
                bool result = DatabaseAccess.Insert(insertquery);
                if (result == true)
                {
                    MessageBox.Show("Save Successfully");
                    RetriveList(string.Empty);
                    ClearForm();
                }
                else
                {
                    MessageBox.Show("Please Provide correct details, try again");
                }
            }
            catch 
            {

                MessageBox.Show("Please Provide correct details, try again");
            }
        }

        private void BtnUpdate_Click(object sender, EventArgs e)
        {
            try
            {
                ep.Clear();
                if (txtItem.Text.Trim().Length == 0)
                {
                    ep.SetError(txtItem, "Please Enter Item Name!");
                    txtItem.Focus();
                    return;
                }
                if (cmbCategory.SelectedIndex == 0)
                {
                    ep.SetError(cmbCategory, "Please Select Category");
                    cmbCategory.Focus();
                    return;
                }

                DataTable dt = DatabaseAccess.Retrive("select * from StockTable where CategoryID = '" + cmbCategory.SelectedValue + "' and Name = '" + txtItem.Text.Trim() + "' and ItemID != '"+Convert.ToString(dgvStock.CurrentRow.Cells[0].Value)+"'");
                if (dt != null)
                {
                    if (dt.Rows.Count > 0)
                    {
                        ep.SetError(txtItem, "Already Exist!");
                        txtItem.Focus();
                        txtItem.SelectAll();
                        return;
                    }
                }
                string updatequery = string.Format("update StockTable set CategoryID = '{0}',EmployeeID = '{1}',Name = '{2}',IsActive = '{3}',ManuDate= '{5}',ExpDate = '{6}' where ItemID = '{4}'",
                cmbCategory.SelectedValue, UserInfo.EmployeeID, txtItem.Text.Trim(), chkStatus.Checked,Convert.ToString(dgvStock.CurrentRow.Cells[0].Value),dtpManuDate.Value.ToString("yyyy/MM/dd"),dtpExpDate.Value.ToString("yyyy/MM/dd"));
                bool result = DatabaseAccess.Insert(updatequery);
                if (result == true)
                {
                    MessageBox.Show("Updated Successfully");
                    DisableComponent();
                }
                else
                {
                    MessageBox.Show("Please Provide correct details, try again");
                }
            }
            catch
            {

                MessageBox.Show("Please Provide correct details, try again");
            }
        }

        private void EditToolStripMenuItem_Click(object sender, EventArgs e)
        {
            try
            {
                if (dgvStock != null)
                {
                    if (dgvStock.Rows.Count > 0)
                    {
                        if (dgvStock.SelectedRows.Count == 1)
                        {
                            txtItem.Text = Convert.ToString(dgvStock.CurrentRow.Cells[2].Value);
                            cmbCategory.SelectedValue = Convert.ToString(dgvStock.CurrentRow.Cells[3].Value);
                            chkStatus.Checked = Convert.ToBoolean(dgvStock.CurrentRow.Cells[1].Value);
                            try
                            {
                                dtpManuDate.Value = Convert.ToDateTime(dgvStock.CurrentRow.Cells[8].Value);
                            }
                            catch (Exception)
                            {
                                dtpManuDate.Value = DateTime.Now;
                            }
                            try
                            {
                                dtpExpDate.Value = Convert.ToDateTime(dgvStock.CurrentRow.Cells[9].Value);
                            }
                            catch (Exception)
                            {
                                dtpExpDate.Value = DateTime.Now;
                            }
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

        private void label3_Click(object sender, EventArgs e)
        {

        }

        private void label5_Click(object sender, EventArgs e)
        {

        }

        private void dateTimePicker1_ValueChanged(object sender, EventArgs e)
        {

        }
    }
}
