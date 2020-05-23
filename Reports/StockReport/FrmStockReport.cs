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
    public partial class FrmStockReport : Form
    {
        public FrmStockReport()
        {
            InitializeComponent();
            rptStockReport rpt = new rptStockReport();
            rpt.Refresh();
            crv.ReportSource = rpt;
        }

        private void FrmStockReport_Load(object sender, EventArgs e)
        {
            
        }
    }
}
