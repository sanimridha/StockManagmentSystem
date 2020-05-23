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
    public partial class FrmAllPurchasePaymentHistory : Form
    {
        public FrmAllPurchasePaymentHistory()
        {
            InitializeComponent();
            rptSupplierWisePurchasePaymentHistory rpt = new rptSupplierWisePurchasePaymentHistory();
            crv.ReportSource = rpt;

        }

        private void FrmAllPurchasePaymentHistory_Load(object sender, EventArgs e)
        {

        }
    }
}
