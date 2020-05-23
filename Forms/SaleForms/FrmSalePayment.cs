using CosmaticShop.DatabaseLayer;
using CosmaticShop.Reports.SaleReport;
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

namespace CosmaticShop.Forms.SaleForms
{
    public partial class FrmSalePayment : Form
    {
        public string SaleID = string.Empty;
        public string TotalAmount = string.Empty;
        FrmSalePaymentPending SalePaymentPendingFrom;
        public FrmSalePayment(string saleid, string remaingbalance, string totalamount, FrmSalePaymentPending FromPurchasesPaymentPending)
        {
            InitializeComponent();
            lblRPB.Text = remaingbalance;
            txtAmount.Text = remaingbalance;
            lblRCB.Text = remaingbalance;
            this.SaleID = saleid;
            this.TotalAmount = totalamount;
            SalePaymentPendingFrom = FromPurchasesPaymentPending;
        }

        private void txtAmount_KeyPress(object sender, KeyPressEventArgs e)
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

        private void txtAmount_TextChanged(object sender, EventArgs e)
        {
            try
            {
                float remaingbalance = 0;
                float.TryParse(lblRPB.Text.Trim(), out remaingbalance);

                float paidamount = 0;
                float.TryParse(txtAmount.Text.Trim(), out paidamount);

                lblRCB.Text = (remaingbalance - paidamount).ToString();

            }
            catch
            {
                lblRCB.Text = "0";
            }
        }

        private void btnPaid_Click(object sender, EventArgs e)
        {
            ep.Clear();

            float remaingbalance = 0;
            float.TryParse(lblRPB.Text.Trim(), out remaingbalance);

            float paidamount = 0;
            float.TryParse(txtAmount.Text.Trim(), out paidamount);
            float remaingcurrentbalance = remaingbalance - paidamount;

            if (paidamount == 0)
            {
                ep.SetError(txtAmount, "Please Enter Paid Amount");
                txtAmount.Focus();
                return;
            }

            if (remaingcurrentbalance < 0)
            {
                ep.SetError(txtAmount, "Paid Amount Must be Equal Or Less Then Remaing Balance");
                txtAmount.Focus();
                return;
            }

            string paymentquery = string.Format("insert into CustomerPaymentTable(SaleID,EmoloyeeID,PaidDate,TotalAmount,PaidAmount,BalanceAmount) values ('{0}','{1}','{2}','{3}','{4}','{5}')",
                                                                                                        SaleID, UserInfo.EmployeeID, DateTime.Now.ToString("yyyy/MM/dd"), TotalAmount, paidamount, remaingcurrentbalance);
            bool result = DatabaseAccess.Insert(paymentquery);
            if (result == true)
            {
                SalePaymentPendingFrom.RetriveList(string.Empty);
                string salepaymentid = DatabaseAccess.Retrive("select Max(CustomerPaymentID) from CustomerPaymentTable").Rows[0][0].ToString();
                FrmSalePaymentReport fppr = new FrmSalePaymentReport(Convert.ToInt32(salepaymentid));
                fppr.ShowDialog();


                MessageBox.Show("Amount Paid Successfully");
                this.Close();
            }
            else
            {
                MessageBox.Show("Please Probide Correct Details And try Again");
            }
        }
    }
}
