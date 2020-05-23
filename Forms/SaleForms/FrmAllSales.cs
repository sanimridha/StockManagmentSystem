using CosmaticShop.DatabaseLayer;
using CosmaticShop.Reports.SaleReport;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace CosmaticShop.Forms.SaleForms
{
    public partial class FrmAllSales : Form
    {
        public FrmAllSales()
        {
            InitializeComponent();
        }
        public void RetriveList(string FromDate, string ToDate)
        {
            string query = " SELECT SaleID[ID],CustomerID,Name[Customer],ContactNo[Contact No],SaleDate[Sale Date]," +
                           " TotalAmount[Total Amount],Comments,UserName[Created By] FROM V_AllSales where SaleDate > DATEADD(day,-1,'" + FromDate + "') And SaleDate < DATEADD(day,1,'" + ToDate + "')";

            DataTable dt = DatabaseAccess.Retrive(query);
            if (dt != null)
            {
                dgvSuppliers.DataSource = dt;
                dgvSuppliers.Columns[0].Width = 80; // SaleID
                dgvSuppliers.Columns[1].Visible = false; // CustomerID
                dgvSuppliers.Columns[2].Width = 150; // Customer
                dgvSuppliers.Columns[3].Width = 80; // ContactNo
                dgvSuppliers.Columns[4].Width = 100; // SaleDate
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

        private void FrmAllSales_Load(object sender, EventArgs e)
        {
            RetriveList(dtpFromDate.Value.ToString("yyyy/MM/dd"), dtpToDate.Value.ToString("yyyy/MM/dd"));
        }

        private void purchaseReportToolStripMenuItem_Click(object sender, EventArgs e)
        {
            try
            {
                int purchaseid = 0;
                int.TryParse(dgvSuppliers.CurrentRow.Cells[0].Value.ToString(), out purchaseid);
                FrmSaleReport frm = new FrmSaleReport(Convert.ToInt32(purchaseid));
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
                        FrmSalePaymentHistoryReport fpphr = new FrmSalePaymentHistoryReport(Convert.ToInt32(dgvSuppliers.CurrentRow.Cells[0].Value.ToString()));
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

        private void btnFind_Click(object sender, EventArgs e)
        {
            RetriveList(dtpFromDate.Value.ToString("yyyy/MM/dd"), dtpToDate.Value.ToString("yyyy/MM/dd"));
        }

        private void btnPrint_Click(object sender, EventArgs e)
        {
            FrmCustomSaleReport frm = new FrmCustomSaleReport(dtpFromDate.Value.ToString("yyyy/MM/dd"), dtpToDate.Value.ToString("yyyy/MM/dd"));
            frm.ShowDialog();
        }
    }
}
