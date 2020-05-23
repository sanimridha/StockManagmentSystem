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
    public partial class FrmDailyExpenses : Form
    {
        public FrmDailyExpenses()
        {
            InitializeComponent();
            rptExpensesReport rpt = new rptExpensesReport();
            rpt.SetParameterValue("@FromDate", DateTime.Now);
            rpt.SetParameterValue("@ToDate", DateTime.Now);
            rpt.SetParameterValue("@Name", "Daily Expenses Report");
            crv.ReportSource = rpt;
        }

        private void FrmDailyExpenses_Load(object sender, EventArgs e)
        {

        }
    }
}
