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
    public partial class FrmDailyPurchaseReport : Form
    {
        public FrmDailyPurchaseReport()
        {
            InitializeComponent();
            rptAllPurchasesReporting rpt = new rptAllPurchasesReporting();
            rpt.SetParameterValue("@FromDate", DateTime.Now);
            rpt.SetParameterValue("@ToDate", DateTime.Now);
            rpt.SetParameterValue("@ReportName", "Daily Purchase Report");
            crv.ReportSource = rpt;
        }

        private void FrmDailyPurchaseReport_Load(object sender, EventArgs e)
        {

        }
    }
}
