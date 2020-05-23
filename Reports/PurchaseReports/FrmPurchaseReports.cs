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
    public partial class FrmPurchaseReports : Form
    {
        public FrmPurchaseReports(int purchaseid)
        {
            InitializeComponent();
            rptPurchaseReport rpt = new rptPurchaseReport();
            rpt.SetParameterValue("@PurchaseID", purchaseid);
            crv.ReportSource = rpt;
        }

        private void crv_Load(object sender, EventArgs e)
        {

        }

        private void FrmPurchaseReports_Load(object sender, EventArgs e)
        {

        }
    }
}
