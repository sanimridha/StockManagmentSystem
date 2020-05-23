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
    public partial class FrmWeeklyExpensesReport : Form
    {
        public FrmWeeklyExpensesReport()
        {
            InitializeComponent();
            rptExpensesReport rpt = new rptExpensesReport();
            rpt.SetParameterValue("@FromDate", DateTime.Now.AddDays(-7));
            rpt.SetParameterValue("@ToDate", DateTime.Now);
            rpt.SetParameterValue("@Name", "Weekly Expenses Report");
            crv.ReportSource = rpt;
        }

        private void FrmWeeklyExpensesReport_Load(object sender, EventArgs e)
        {

        }
    }
}
