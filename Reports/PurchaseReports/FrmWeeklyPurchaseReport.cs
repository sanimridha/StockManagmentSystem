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
    public partial class FrmWeeklyPurchaseReport : Form
    {
        public FrmWeeklyPurchaseReport()
        {
            InitializeComponent();
            rptAllPurchasesReporting rpt = new rptAllPurchasesReporting();
            rpt.SetParameterValue("@FromDate", DateTime.Now.AddDays(-7));
            rpt.SetParameterValue("@ToDate", DateTime.Now);
            rpt.SetParameterValue("@ReportName", "Weekly Purchase Report");
            crv.ReportSource = rpt;
        }

        private void FrmWeeklyPurchaseReport_Load(object sender, EventArgs e)
        {

        }
    }
}
