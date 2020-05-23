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
    public partial class FrmMonthlyExpensesReport : Form
    {
        public FrmMonthlyExpensesReport()
        {
            InitializeComponent();
            rptExpensesReport rpt = new rptExpensesReport();
            rpt.SetParameterValue("@FromDate", DateTime.Now.AddDays(-30));
            rpt.SetParameterValue("@ToDate", DateTime.Now);
            rpt.SetParameterValue("@Name", "Monthly Expenses Report");
            crv.ReportSource = rpt;
        }

        private void FrmMonthlyExpensesReport_Load(object sender, EventArgs e)
        {

        }
    }
}
