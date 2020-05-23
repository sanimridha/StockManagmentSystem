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
    public partial class FrmCustomPurchaseReport : Form
    {
        public FrmCustomPurchaseReport(string FromDate, string ToDate)
        {
            InitializeComponent();
            rptAllPurchasesReporting rpt = new rptAllPurchasesReporting();
            rpt.SetParameterValue("@FromDate", FromDate);
            rpt.SetParameterValue("@ToDate", ToDate);
            rpt.SetParameterValue("@ReportName", "Custom Purchase Report");
            crv.ReportSource = rpt;
        }

        private void FrmCustomPurchaseReport_Load(object sender, EventArgs e)
        {

        }
    }
}
