using CosmaticShop.DatabaseLayer;
using CosmaticShop.Forms.PurchaseForm;
using CosmaticShop.Reports.PurchaseReports;
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
    public partial class FrmSalePaymentPending : Form
    {
        public FrmSalePaymentPending()
        {
            InitializeComponent();
        }

        public void RetriveList(string searchvalue)
        {
            string query = string.Empty;
            if (string.IsNullOrEmpty(searchvalue))
            {
                query = " Select  ST.SaleID[ID], ST.CustomerID,CT.Name [Customer],CT.ContactNo, ST.SaleDate [Sale Date]," +
                        "  ST.TotalAmount [Total Amount],ISNULL(CPT.[Paid Amount],0) [Paid Amount], ( ST.TotalAmount - ISNULL(CPT.[Paid Amount],0)) [Remaing Balance] From SaleTable  ST INNER Join CustomerTable CT " +
                        " ON  ST.CustomerID = CT.CustomerID " +
                        " LEFT OUTER Join (Select SaleID,SUM(PaidAmount)[Paid Amount] From CustomerPaymentTable Group By SaleID) CPT " +
                        " On  ST.SaleID = CPT.SaleID " +
                        " Where  ST.TotalAmount > ISNULL(CPT.[Paid Amount],0) ";
            }
            else
            {
                query = "Select  ST.SaleID[ID], ST.CustomerID,CT.Name [Customer],CT.ContactNo, ST.SaleDate [Sale Date]," +
                        "  ST.TotalAmount [Total Amount],ISNULL(CPT.[Paid Amount],0) [Paid Amount], ( ST.TotalAmount - ISNULL(CPT.[Paid Amount],0)) [Remaing Balance] From SaleTable  ST INNER Join CustomerTable CT " +
                        " ON  ST.CustomerID = CT.CustomerID " +
                        " LEFT OUTER Join (Select SaleID,SUM(PaidAmount)[Paid Amount] From CustomerPaymentTable Group By SaleID) CPT " +
                        " On  ST.SaleID = CPT.SaleID " +
                        " Where  ST.TotalAmount > ISNULL(CPT.[Paid Amount],0) AND (CT.Name +' '+ CT.ContactNo) like '%" + searchvalue.Trim() + "%' ";
                                    }
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
                dgvSuppliers.Columns[6].Width = 120; // Paid Amount
                dgvSuppliers.Columns[7].Width = 150; // Remaing Balance

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

                        totalamount = totalamount + Convert.ToDecimal(item.Cells[7].Value);

                    }
                }
            }
            lblTotalAmount.Text = totalamount.ToString();
        }

        private void FrmSalePaymentPending_Load(object sender, EventArgs e)
        {
            RetriveList(string.Empty);
        }

        private void contextMenuStrip1_Opening(object sender, CancelEventArgs e)
        {

        }

        private void paymentToolStripMenuItem_Click(object sender, EventArgs e)
        {
            if (dgvSuppliers != null)
            {
                if (dgvSuppliers.Rows.Count > 0)
                {
                    if (dgvSuppliers.SelectedRows.Count == 1)
                    {
                        FrmSalePayment fpp = new FrmSalePayment(Convert.ToString(dgvSuppliers.CurrentRow.Cells[0].Value),
                            Convert.ToString(dgvSuppliers.CurrentRow.Cells[7].Value),
                             Convert.ToString(dgvSuppliers.CurrentRow.Cells[5].Value), this);
                        fpp.ShowDialog();
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

        private void paymentDetailsToolStripMenuItem_Click(object sender, EventArgs e)
        {
            if (dgvSuppliers != null)
            {
                if (dgvSuppliers.Rows.Count > 0)
                {
                    if (dgvSuppliers.SelectedRows.Count == 1)
                    {
                        //FrmSalePaidHistoryReport fsphr = new FrmPurchasePaymentHistoryReport(Convert.ToInt32(dgvSuppliers.CurrentRow.Cells[0].Value.ToString()));
                        //fsphr.ShowDialog();
                        FrmSalePaymentHistoryReport frm = new FrmSalePaymentHistoryReport(Convert.ToInt32(dgvSuppliers.CurrentRow.Cells[0].Value.ToString()));
                        frm.ShowDialog();
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

        private void txtSearch_TextChanged(object sender, EventArgs e)
        {
            RetriveList(txtSearch.Text.Trim());
        }
    }
}
