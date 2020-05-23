using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace CosmaticShop.Reports.SaleReport
{
    public partial class FrmWeeklySaleReport : Form
    {
        public FrmWeeklySaleReport()
        {
            InitializeComponent();
            rptDailySalesReport rpt = new rptDailySalesReport();
            rpt.SetParameterValue("@FromDate", DateTime.Now.AddDays(-7));
            rpt.SetParameterValue("@ToDate", DateTime.Now);
            rpt.SetParameterValue("@ReportName", "Weekly Sales Report");
            crv.ReportSource = rpt;
        }

        private void FrmWeeklySaleReport_Load(object sender, EventArgs e)
        {
        }
    }
}
