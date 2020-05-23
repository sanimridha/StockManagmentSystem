using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace CosmaticShop.Reports.PurchaseReports
{
    public partial class FrmPurchasePaymentReport : Form
    {
        public FrmPurchasePaymentReport(int SupplierPaymentID)
        {
            InitializeComponent();
            rptPurchasePayment rpt = new rptPurchasePayment();
            rpt.SetParameterValue("@SupplierPaymentID", SupplierPaymentID);
            crv.ReportSource = rpt;
        }

        private void FrmPurchasePaymentReport_Load(object sender, EventArgs e)
        {

        }
    }
}
