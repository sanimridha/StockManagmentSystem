using CosmaticShop.DatabaseLayer;
using CosmaticShop.Forms.SaleForms;
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
    public partial class FrmSearchCustomers : Form
    {
        public FrmNewSale NewSaleForm;
        public FrmSearchCustomers(string searchvalue, FrmNewSale FormNewSale)
        {
            InitializeComponent();
            NewSaleForm = FormNewSale;
            txtSearch.Text = searchvalue;
            RetriveList(searchvalue);
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
                            " Where (Name + ' '+ ContactNo + ' ' + Address + ' ' + UserName) Like '%" + searchvalue.Trim() + "%'";
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

        private void TxtSearch_TextChanged(object sender, EventArgs e)
        {
            RetriveList(txtSearch.Text.Trim());
        }
        private void SelecteCustomer()
        {
            if (NewSaleForm != null)
            {
                NewSaleForm.supplierID = Convert.ToString(dgvCustomers.CurrentRow.Cells[0].Value);
                NewSaleForm.lblCustomerName.Text = Convert.ToString(dgvCustomers.CurrentRow.Cells[1].Value);
                NewSaleForm.lblContactNo.Text = Convert.ToString(dgvCustomers.CurrentRow.Cells[2].Value);
                this.Close();
            }
        }

        private void DgvCustomers_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
            {
                if (dgvCustomers.Rows.Count > 0)
                {
                    if (dgvCustomers.SelectedRows.Count == 1)
                    {
                        SelecteCustomer();
                    }
                    else
                    {
                        dgvCustomers.Rows[0].Selected = true;
                        SelecteCustomer();
                    }
                }
            }
        }

        private void EditToolStripMenuItem_Click(object sender, EventArgs e)
        {
            if (dgvCustomers != null)
            {
                if (dgvCustomers.Rows.Count > 0)
                {
                    if (dgvCustomers.SelectedRows.Count == 1)
                    {
                        SelecteCustomer();
                    }
                    else
                    {
                        dgvCustomers.Rows[0].Selected = true;
                        SelecteCustomer();
                    }
                }
            }
        }

        private void FrmSearchCustomers_Activated(object sender, EventArgs e)
        {
            dgvCustomers.Focus();
        }
    }
}
