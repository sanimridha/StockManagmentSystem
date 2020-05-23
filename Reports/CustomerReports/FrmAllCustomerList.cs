using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace CosmaticShop.Reports.CustomerReports
{
    public partial class FrmAllCustomerList : Form
    {
        public FrmAllCustomerList()
        {
            InitializeComponent();
            rptAllCustomerList rpt = new rptAllCustomerList();
            crv.ReportSource = rpt;
        }

        private void FrmAllCustomer_Load(object sender, EventArgs e)
        {

        }
    }
}
