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
    public partial class FrmPurchasesPaymentPending : Form
    {
        public FrmPurchasesPaymentPending()
        {
            InitializeComponent();
        }

        public void RetriveList(string searchvalue)
        {
            string query = string.Empty;
            if (string.IsNullOrEmpty(searchvalue))
            {
                query = " Select PT.PurchaseID[ID],PT.SupplierID,ST.Name [Supplier],ST.ContactNo,PT.PurchaseDate [Purchase Date]," +
                        " PT.TotalAmount [Total Amount],ISNULL(SPT.[Paid Amount],0) [Paid Amount], (PT.TotalAmount - ISNULL(SPT.[Paid Amount],0)) [Remaing Balance] From PurchaseTable PT INNER Join SupplierTable ST " +
                        " ON PT.SupplierID = ST.SupplierID " +
                        " LEFT OUTER Join (Select PurchaseID,SUM(PaidAmount)[Paid Amount] From SupplierPaymentTable Group By PurchaseID) SPT " +
                        " On PT.PurchaseID = SPT.PurchaseID " +
                        " Where PT.TotalAmount > ISNULL(SPT.[Paid Amount],0) ";
             }
            else
            {
                query = " Select PT.PurchaseID[ID],PT.SupplierID,ST.Name[Supplier],ST.ContactNo,PT.PurchaseDate[Purchase Date],"+ 
                        " PT.TotalAmount [Total Amount],ISNULL(SPT.[Paid Amount],0) [Paid Amount], (PT.TotalAmount - ISNULL(SPT.[Paid Amount],0)) [Remaing Balance] From PurchaseTable PT INNER Join SupplierTable ST " +
                        " ON PT.SupplierID = ST.SupplierID " +
                        " LEFT OUTER Join (Select PurchaseID,SUM(PaidAmount)[Paid Amount] From SupplierPaymentTable Group By PurchaseID) SPT " +
                        " On PT.PurchaseID = SPT.PurchaseID " +
                        " Where PT.TotalAmount > ISNULL(SPT.[Paid Amount],0)  AND (ST.Name +' '+ ST.ContactNo) like '%"+searchvalue.Trim()+"%' ";
            }
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
                dgvSuppliers.Columns[6].Width = 120; // Paid Amount
                dgvSuppliers.Columns[7].Width = 150; // Remaing Balance

            }
            else
            {
                dgvSuppliers.DataSource = null;
            }
            CalculateTotalAmount();
        }

        private void FrmPurchasesPaymentPending_Load(object sender, EventArgs e)
        {
            RetriveList(string.Empty);
        }

        private void txtSearch_TextChanged(object sender, EventArgs e)
        {
            RetriveList(txtSearch.Text.Trim());
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

        private void paymentToolStripMenuItem_Click(object sender, EventArgs e)
        {
            if (dgvSuppliers != null)
            {
                if (dgvSuppliers.Rows.Count > 0)
                {
                    if(dgvSuppliers.SelectedRows.Count == 1)
                    {
                        FrmPurchasePayment fpp = new FrmPurchasePayment(Convert.ToString(dgvSuppliers.CurrentRow.Cells[0].Value),
                            Convert.ToString(dgvSuppliers.CurrentRow.Cells[7].Value),
                             Convert.ToString(dgvSuppliers.CurrentRow.Cells[5].Value),this);
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
    }
}
