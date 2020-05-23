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
    public partial class FrmSalePaymentHistoryReport : Form
    {
        public FrmSalePaymentHistoryReport(int SaleID)
        {
            InitializeComponent();
            FrmSalePaidHistoryReport rpt = new FrmSalePaidHistoryReport();
            rpt.SetParameterValue("@SaleID", SaleID);
            crv.ReportSource = rpt;
        }


        private void FrmSalePaymentHistoryReport_Load(object sender, EventArgs e)
        {

        }
    }
}
