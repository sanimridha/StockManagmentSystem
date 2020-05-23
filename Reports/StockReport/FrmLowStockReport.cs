using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace CosmaticShop.Reports.StockReport
{
    public partial class FrmLowStockReport : Form
    {
        public FrmLowStockReport()
        {
            InitializeComponent();
        }

        private void FrmLowStockReport_Load(object sender, EventArgs e)
        {
            rptLowStock rpt = new rptLowStock();
            rpt.Refresh();
            crv.ReportSource = rpt;
        }
    }
}
