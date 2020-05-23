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
    public partial class FrmCustomSaleReport : Form
    {
        public FrmCustomSaleReport(string FromDate, string ToDate)
        {
            InitializeComponent();
            rptDailySalesReport rpt = new rptDailySalesReport();
            rpt.SetParameterValue("@FromDate", FromDate);
            rpt.SetParameterValue("@ToDate", ToDate);
            rpt.SetParameterValue("@ReportName", "Custom Sales Report");
            crv.ReportSource = rpt;
        }

        private void FrmCustomSaleReport_Load(object sender, EventArgs e)
        {

        }
    }
}
