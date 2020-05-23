using CosmaticShop.DatabaseLayer;
using CosmaticShop.Reports.PurchaseReports;
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

namespace CosmaticShop.Forms.PurchaseForm
{
    public partial class FrmPurchasePayment : Form
    {
        public string PurchaseID = string.Empty;
        public string TotalAmount = string.Empty;
        FrmPurchasesPaymentPending PurchasesPaymentPendingFrom;
        public FrmPurchasePayment(string purchaseid, string remaingbalance, string totalamount, FrmPurchasesPaymentPending FromPurchasesPaymentPending)
        {
            InitializeComponent();
            lblRPB.Text = remaingbalance;
            txtPayment.Text = remaingbalance;
            lblRCB.Text = remaingbalance;
            this.PurchaseID = purchaseid;
            this.TotalAmount = totalamount;
            PurchasesPaymentPendingFrom = FromPurchasesPaymentPending;
        }

        private void label3_Click(object sender, EventArgs e)
        {

        }

        private void btnSave_Click(object sender, EventArgs e)
        {
            ep.Clear();

            float remaingbalance = 0;
            float.TryParse(lblRPB.Text.Trim(), out remaingbalance);

            float payment = 0;
            float.TryParse(txtPayment.Text.Trim(), out payment);
            float remaingcurrentbalance= remaingbalance - payment;

            if(payment == 0)
            {
                ep.SetError(txtPayment, "Please Enter Payment Amount");
                txtPayment.Focus();
                return;
            }

            if (remaingcurrentbalance < 0)
            {
                ep.SetError(txtPayment, "Payment Amount Must be Equal Or Less Then Remaing Balance");
                txtPayment.Focus();
                return;
            }

            string paymentquery = string.Format("insert into SupplierPaymentTable(PurchaseID,EmployeeId,PaymentDate,TotalAmount,PaidAmount,BalanceAmount) values ('{0}','{1}','{2}','{3}','{4}','{5}')",
                                                                                                        PurchaseID, UserInfo.EmployeeID, DateTime.Now.ToString("yyyy/MM/dd"), TotalAmount, payment,remaingcurrentbalance);
            bool result = DatabaseAccess.Insert(paymentquery);
            if (result == true)
            {
                PurchasesPaymentPendingFrom.RetriveList(string.Empty);
                string purchasepaymentid = DatabaseAccess.Retrive("select Max(SupplierPaymentID) from SupplierPaymentTable").Rows[0][0].ToString();
                FrmPurchasePaymentReport fppr = new FrmPurchasePaymentReport(Convert.ToInt32(purchasepaymentid));
                fppr.ShowDialog();


                MessageBox.Show("Payment Successfully");
                this.Close();
            }
            else
            {
                MessageBox.Show("Please Probide Correct Details And try Again");
            }
        }

        private void txtPayment_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (!char.IsControl(e.KeyChar) && !char.IsDigit(e.KeyChar) && (e.KeyChar != '.'))

            {
                e.Handled = true;
            }

            // only allow one decimal point
            if ((e.KeyChar == '.') && ((sender as TextBox).Text.IndexOf('.') > -1))
            {
                e.Handled = true;
            }
        }

        private void FrmPurchasePayment_Load(object sender, EventArgs e)
        {

        }

        private void txtPayment_TextChanged(object sender, EventArgs e)
        {
            try
            {
                float remaingbalance = 0;
                float.TryParse(lblRPB.Text.Trim(), out remaingbalance);

                float payment = 0;
                float.TryParse(txtPayment.Text.Trim(), out payment);

                lblRCB.Text = (remaingbalance - payment).ToString();

            }
            catch
            {
                lblRCB.Text = "0";
            }
        }
    }
}
