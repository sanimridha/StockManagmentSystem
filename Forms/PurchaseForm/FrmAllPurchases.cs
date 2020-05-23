using CosmaticShop.DatabaseLayer;
using CosmaticShop.Reports.PurchaseReports;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace CosmaticShop.Forms.PurchaseForm
{
    public partial class FrmAllPurchases : Form
    {
        public FrmAllPurchases()
        {
            InitializeComponent();
        }

        public void RetriveList(string FromDate, string ToDate)
        {
            string query = " SELECT PurchaseID[ID],SupplierID,Name[Supplier],ContactNo[Contact No],PurchaseDate[Purchase Date],"+
                "TotalAmount[Total Amount],Comments,UserName[Created By] FROM V_AllPurchases where PurchaseDate > DATEADD(day,-1,'"+ FromDate + "') And PurchaseDate < DATEADD(day,1,'"+ ToDate + "')";
            
            DataTable dt = DatabaseAccess.Retrive(query);
            if (dt != null)
            {
                dgvSuppliers.DataSource = dt;
                dgvSuppliers.Columns[0].Width = 80; // PurchaseID
                dgvSuppliers.Columns[1].Visible = false; // SupplierID
                dgvSuppliers.Columns[2].Width = 150; // Supplier
                dgvSuppliers.Columns[3].Width = 80; // ContactNo
                dgvSuppliers.Columns[4].Width = 100; // PurchaseDate
                dgvSuppliers.Columns[5].Width = 120; // TotalAmount
                dgvSuppliers.Columns[6].Width = 120; // Comments
                dgvSuppliers.Columns[7].Width = 100; // Created By

            }
            else
            {
                dgvSuppliers.DataSource = null;
            }
            CalculateTotalAmount();
        }

        private void CalculateTotalAmount()
        {
            decimal totalamount = 0;
            if (dgvSuppliers != null)
            {
                if (dgvSuppliers.Rows.Count > 0)
                {
                    foreach (DataGridViewRow item in dgvSuppliers.Rows)
                    {
                        //float remainingbalance = 0;
                        //float.TryParse(item.Cells[7].Value.ToString(), out remainingbalance);
                        //totalamount = totalamount + remainingbalance;

                        totalamount = totalamount + Convert.ToDecimal(item.Cells[5].Value);

                    }
                }
            }
            lblTotalAmount.Text = totalamount.ToString();
        }

        private void FrmAllPurchases_Load(object sender, EventArgs e)
        {
            RetriveList(dtpFromDate.Value.ToString("yyyy/MM/dd"), dtpToDate.Value.ToString("yyyy/MM/dd"));
        }

        private void btnFind_Click(object sender, EventArgs e)
        {
            RetriveList(dtpFromDate.Value.ToString("yyyy/MM/dd"), dtpToDate.Value.ToString("yyyy/MM/dd"));
        }

        private void contextMenuStrip1_Opening(object sender, CancelEventArgs e)
        {

        }

        private void purchaseReportToolStripMenuItem_Click(object sender, EventArgs e)
        {
            try
            {
                int purchaseid = 0;
                int.TryParse(dgvSuppliers.CurrentRow.Cells[0].Value.ToString(), out purchaseid);
                FrmPurchaseReports frm = new FrmPurchaseReports(Convert.ToInt32(purchaseid));
                frm.Show();
            }
            catch 
            {
                MessageBox.Show("Please Select One Record!");
            }
        }

        private void paymentDetailsToolStripMenuItem_Click(object sender, EventArgs e)
        {
            if (dgvSuppliers != null)
            {
                if (dgvSuppliers.Rows.Count > 0)
                {
                    if (dgvSuppliers.SelectedRows.Count == 1)
                    {
                        FrmPurchasePaymentHistoryReport fpphr = new FrmPurchasePaymentHistoryReport(Convert.ToInt32(dgvSuppliers.CurrentRow.Cells[0].Value.ToString()));
                        fpphr.ShowDialog();
                    }
                    else
                    {
                        MessageBox.Show("Please Select One Record");
                    }
                }
                else
                {
                    MessageBox.Show("List is Empty!");
                }
            }
        }

        private void btnPrint_Click(object sender, EventArgs e)
        {
            FrmCustomPurchaseReport frm = new FrmCustomPurchaseReport(dtpFromDate.Value.ToString("yyyy/MM/dd"), dtpToDate.Value.ToString("yyyy/MM/dd"));
            frm.ShowDialog();
        }
    }
}
