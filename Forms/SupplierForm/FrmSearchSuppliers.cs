using CosmaticShop.DatabaseLayer;
using CosmaticShop.Forms.PurchaseForm;
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
    public partial class FrmSearchSuppliers : Form
    {
        FrmNewPurchase NewPurchaseFrom;
        public FrmSearchSuppliers(string value, FrmNewPurchase NewPurchase)
        {
            InitializeComponent();
            NewPurchaseFrom = NewPurchase;
            txtSearch.Text = value;
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
                            " Where (Name + ' '+ ContactNo + ' ' + Address + ' ' + UserName) Like '%" + searchvalue.Trim() + "%'";
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

        private void FrmSearchSuppliers_Load(object sender, EventArgs e)
        {
            RetriveList(txtSearch.Text.Trim());
        }

        private void txtSearch_TextChanged(object sender, EventArgs e)
        {
            RetriveList(txtSearch.Text.Trim());
        }

        private void FrmSearchSuppliers_Activated(object sender, EventArgs e)
        {
            dgvSuppliers.Focus();
        }

        private void dgvSuppliers_KeyDown(object sender, KeyEventArgs e)
        {
            if(e.KeyCode == Keys.Enter)
            {
                if(dgvSuppliers.Rows.Count > 0)
                {
                    if(dgvSuppliers.SelectedRows.Count == 1)
                    {
                        SelecteSupplier();
                    }
                    else
                    {
                        dgvSuppliers.Rows[0].Selected = true;
                        SelecteSupplier();
                    }
                }
            }
        }

        private void SelecteSupplier()
        {
            if (NewPurchaseFrom != null)
            {
                NewPurchaseFrom.supplierID = Convert.ToString(dgvSuppliers.CurrentRow.Cells[0].Value);
                NewPurchaseFrom.lblSupplyerName.Text = Convert.ToString(dgvSuppliers.CurrentRow.Cells[1].Value);
                NewPurchaseFrom.lblContructNo.Text = Convert.ToString(dgvSuppliers.CurrentRow.Cells[2].Value);
                this.Close();
            }
        }
    }
}
