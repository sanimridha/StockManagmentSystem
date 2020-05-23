using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace CosmaticShop.Reports.ExpensesReport
{
    public partial class FrmCustomExpensesReport : Form
    {
        public FrmCustomExpensesReport(string FromDate, string ToDate)
        {
            InitializeComponent();
            rptExpensesReport rpt = new rptExpensesReport();
            rpt.SetParameterValue("@FromDate", FromDate);
            rpt.SetParameterValue("@ToDate", ToDate);
            rpt.SetParameterValue("@Name", "Custom Expenses Report");
            crv.ReportSource = rpt;
        }

        private void FrmCustomExpensesReport_Load(object sender, EventArgs e)
        {
            
        }
    }
}
