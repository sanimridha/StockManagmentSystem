using CosmaticShop.DatabaseLayer;
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
    public partial class FrmAllStock : Form
    {
        public FrmAllStock()
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
                            " Where (Name + ' '+ Category + ' ' + UserName) Like '%" + searchvalue.Trim() + "%'";

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
                dgvStock.Columns[6].Visible = false; // CurrentPurchaseUnitPrice
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
        private void FrmAllStock_Load(object sender, EventArgs e)
        {
            RetriveList(string.Empty);
        }

        private void TxtSearch_TextChanged(object sender, EventArgs e)
        {
            RetriveList(txtSearch.Text.Trim());
        }
    }
}
