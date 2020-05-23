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
    public partial class FrmPurchasePaymentHistoryReport : Form
    {
        public FrmPurchasePaymentHistoryReport(int PurchaseID)
        {
            InitializeComponent();
            rptPurchasePaymentList rpt = new rptPurchasePaymentList();
            rpt.SetParameterValue("@PurchaseID", PurchaseID);
            crv.ReportSource = rpt;
        }

        private void FrmPurchasePaymentHistoryReport_Load(object sender, EventArgs e)
        {

        }
    }
}
