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

namespace CosmaticShop.Forms.ExpensesForm
{
    public partial class FrmExpenses : Form
    {
        public FrmExpenses()
        {
            InitializeComponent();
            AutoScroll = true;
            btnUpdate.Visible = false;
            btnCancle.Visible = false;
        }

        private void FrmExpenses_Load(object sender, EventArgs e)
        {
            ComboHelper.ExpensesCategories(cmbUserType);
            RetriveList(string.Empty);
        }

        private void label1_Click(object sender, EventArgs e)
        {

        }

        private void txtSearch_TextChanged(object sender, EventArgs e)
        {
            RetriveList(txtSearch.Text.Trim());
        }

        private void dgvCategories_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {

        }

        private void txtCost_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (!char.IsControl(e.KeyChar) && !char.IsDigit(e.KeyChar) &&
        (e.KeyChar != '.'))
            {
                e.Handled = true;
            }

            // only allow one decimal point
            if ((e.KeyChar == '.') && ((sender as TextBox).Text.IndexOf('.') > -1))
            {
                e.Handled = true;
            }
        }



        private void btnClear_Click(object sender, EventArgs e)
        {
            ClearForm();
        }
        private void RetriveList(string searchvalue)
        {
            string query = string.Empty;
            if (string.IsNullOrEmpty(searchvalue))
            {
                query = "select ExpensesID[ID],Title [Expenses],ExpCategoryID,Name[Category], ExpDate[Date],TotalCost[Cost],Reason,Comments,UserName[Create By] from V_AllExpenses";
            }
            else
            {
                query = "select ExpensesID[ID],Title [Expenses],ExpCategoryID,Name[Category], ExpDate[Date],TotalCost[Cost],Reason,Comments,UserName[Create By] from V_AllExpenses" + "where (Title +' '+Name+' '+ Reason+' '+ Comments + ' ' + UserName) like '%"+searchvalue.Trim()+"%'";
            }
            DataTable dt = DatabaseAccess.Retrive(query);
            if (dt != null)
            {
                dgvCategories.DataSource = dt;
                dgvCategories.Columns[0].Visible = false; // ExpensesID
                dgvCategories.Columns[1].Width = 200; // Expenses
                dgvCategories.Columns[2].Visible = false; // ExpCategoryID
                dgvCategories.Columns[3].Width = 150; // Category
                dgvCategories.Columns[4].Width = 150; // Date
                dgvCategories.Columns[5].Width = 100; // Cost
                dgvCategories.Columns[6].Width = 200; // Reason
                dgvCategories.Columns[7].Width = 200; // Comments
                dgvCategories.Columns[8].Width = 100; // UserName
            }
            else
            {
                dgvCategories.DataSource = null;
            }
        }
        private void ClearForm()
        {
            txtTitle.Clear();
            cmbUserType.SelectedIndex = 0;
            txtCost.Clear();
            txtComments.Clear();
            txtreson.Clear();
        }
        private void EnableComponent()
        {
            btnCancle.Visible = true;
            btnUpdate.Visible = true;
            btnClear.Visible = false;
            btnSave1.Visible = false;
            dgvCategories.Enabled = false;
            txtSearch.Enabled = false;

        }

        private void DisableComponent()
        {
            btnCancle.Visible = false;
            btnUpdate.Visible = false;
            btnClear.Visible = true;
            btnSave1.Visible = true;
            dgvCategories.Enabled = true;
            txtSearch.Enabled = true;
            ClearForm();
            RetriveList(string.Empty);
        }

        private void btnCancle_Click(object sender, EventArgs e)
        {
            DisableComponent();
        }

        private void btnSave1_Click(object sender, EventArgs e)
        {
            try
            {
                ep.Clear();
                if (txtTitle.Text.Trim().Length == 0)
                {
                    ep.SetError(txtTitle, "Please Enter Expense Titel!");
                    txtTitle.Focus();
                    return;
                }
                if (cmbUserType.SelectedIndex == 0)
                {
                    ep.SetError(cmbUserType, "Please Select Category!");
                    cmbUserType.Focus();
                    return;
                }
                if (txtCost.Text.Trim().Length == 0)
                {
                    ep.SetError(txtCost, "Please Enter Cost Amount!");
                    txtCost.Focus();
                    return;
                }
                float cost = 0;
                float.TryParse(txtCost.Text.Trim(), out cost);
                if (cost == 0)
                {
                    ep.SetError(txtCost, "Please Enter Cost Amount!");
                    txtCost.Focus();
                    return;
                }
                if (txtreson.Text.Trim().Length == 0)
                {
                    ep.SetError(txtreson, "Please Enter Expense Reson!");
                    txtreson.Focus();
                    return;
                }

                string insertquery = string.Format("insert into ExpensesTable(EmployeeID,ExpCategoryID,Title,Reason,Comments,TotalCost,ExpDate) values ('{0}','{1}','{2}','{3}','{4}','{5}','{6}')", UserInfo.EmployeeID,cmbUserType.SelectedValue,txtTitle.Text.Trim(),txtreson.Text.Trim(),txtComments.Text.Trim(),txtCost.Text.Trim(),DateTime.Now.ToString("yyyy/MM/dd hh:mm"));
                bool result = DatabaseAccess.Insert(insertquery);
                if (result == true)
                {
                    MessageBox.Show("Save Successfully");
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

        private void btnUpdate_Click(object sender, EventArgs e)
        {
            try
            {
                ep.Clear();
                if (txtTitle.Text.Trim().Length == 0)
                {
                    ep.SetError(txtTitle, "Please Enter Expense Titel!");
                    txtTitle.Focus();
                    return;
                }
                if (cmbUserType.SelectedIndex == 0)
                {
                    ep.SetError(cmbUserType, "Please Select Category!");
                    cmbUserType.Focus();
                    return;
                }
                if (txtCost.Text.Trim().Length == 0)
                {
                    ep.SetError(txtCost, "Please Enter Cost Amount!");
                    txtCost.Focus();
                    return;
                }
                float cost = 0;
                float.TryParse(txtCost.Text.Trim(), out cost);
                if (cost == 0)
                {
                    ep.SetError(txtCost, "Please Enter Cost Amount!");
                    txtCost.Focus();
                    return;
                }
                if (txtreson.Text.Trim().Length == 0)
                {
                    ep.SetError(txtreson, "Please Enter Expense Reson!");
                    txtreson.Focus();
                    return;
                }

                string updatequery = string.Format("Update ExpensesTable set EmployeeID = '{0}',ExpCategoryID='{1}',Title='{2}',Reason='{3}',Comments='{4}',TotalCost='{5}',ExpDate='{6}' where ExpensesID='{7}'", UserInfo.EmployeeID, cmbUserType.SelectedValue, txtTitle.Text.Trim(), txtreson.Text.Trim(), txtComments.Text.Trim(), txtCost.Text.Trim(),DateTime.Now.ToString("yyyy/MM/dd hh:mm"), Convert.ToString(dgvCategories.CurrentRow.Cells[0].Value));
                bool result = DatabaseAccess.Update(updatequery);
                if (result == true)
                {
                    MessageBox.Show("Update Successfully");
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
                           txtTitle.Text = Convert.ToString(dgvCategories.CurrentRow.Cells[1].Value); // Expenses
                           cmbUserType.SelectedValue=  Convert.ToString(dgvCategories.CurrentRow.Cells[2].Value); // ExpCategoryID
                           Convert.ToString(dgvCategories.CurrentRow.Cells[3].Value); // Category
                           txtCost.Text=Convert.ToString(dgvCategories.CurrentRow.Cells[5].Value); // Cost
                           txtreson.Text=Convert.ToString(dgvCategories.CurrentRow.Cells[6].Value); // Reason
                           txtComments.Text=Convert.ToString(dgvCategories.CurrentRow.Cells[7].Value); // Comments
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
    }
}
