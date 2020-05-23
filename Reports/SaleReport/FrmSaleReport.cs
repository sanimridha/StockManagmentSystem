using CosmaticShop.Resources;
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
    public partial class FrmSaleReport : Form
    {
        public FrmSaleReport(int saleid)
        {
            InitializeComponent();
            rptSaleReport rpt = new rptSaleReport();
            rpt.SetParameterValue("@SaleID", saleid);
            crv.ReportSource = rpt;
        }

        private void Crv_Load(object sender, EventArgs e)
        {

        }
    }
}
