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
    public partial class FrmMonthlySalesReport : Form
    {
        public FrmMonthlySalesReport()
        {
            InitializeComponent();
            rptDailySalesReport rpt = new rptDailySalesReport();
            rpt.SetParameterValue("@FromDate", DateTime.Now.AddDays(-30));
            rpt.SetParameterValue("@ToDate", DateTime.Now);
            rpt.SetParameterValue("@ReportName", "Monthly Sales Report");
            crv.ReportSource = rpt;
        }

        private void FrmMonthlySalesReport_Load(object sender, EventArgs e)
        {

        }
    }
}
