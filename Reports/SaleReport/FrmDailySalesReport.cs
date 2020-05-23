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
    public partial class FrmDailySalesReport : Form
    {
        public FrmDailySalesReport()
        {
            InitializeComponent();
            rptDailySalesReport rpt = new rptDailySalesReport();
            rpt.SetParameterValue("@FromDate", DateTime.Now);
            rpt.SetParameterValue("@ToDate", DateTime.Now);
            rpt.SetParameterValue("@ReportName", "Daily Sale Report");
            crv.ReportSource = rpt;
        }

        private void FrmDailySalesReport_Load(object sender, EventArgs e)
        {

        }
    }
}
