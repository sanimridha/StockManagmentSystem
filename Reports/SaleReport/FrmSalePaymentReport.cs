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
    public partial class FrmSalePaymentReport : Form
    {
        public FrmSalePaymentReport( int CustomerPaymentID)
        {
            InitializeComponent();
            rptSalePaymentReport rpt = new rptSalePaymentReport();
            rpt.SetParameterValue("@CustomerPaymentID", CustomerPaymentID);
            crv.ReportSource = rpt;
        }
    }
}
