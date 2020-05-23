using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace CosmaticShop.Reports.SupplierReport
{
    public partial class FrmSupplierReport : Form
    {
        public FrmSupplierReport()
        {
            InitializeComponent();
            rptAllSupplierList rpt = new rptAllSupplierList();
            crv.ReportSource = rpt;
        }

        private void FrmSupplierReport_Load(object sender, EventArgs e)
        {

        }
    }
}
