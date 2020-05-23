using CosmaticShop.DatabaseLayer;
using CosmaticShop.Reports.ExpensesReport;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace CosmaticShop.Forms.ExpensesForm
{
    public partial class FrmAllExpenses : Form
    {
        public FrmAllExpenses()
        {
            InitializeComponent();
        }

        private void RetriveList(string searchvalue)
        {
            string query = string.Empty;
            string totalcostquery = string.Empty;
            if (string.IsNullOrEmpty(searchvalue))
            {
                query = "select ExpensesID[ID],Title [Expenses],ExpCategoryID,Name[Category], ExpDate[Date],TotalCost[Cost],Reason,Comments,UserName[Create By] from V_AllExpenses where ExpDate > DATEADD(day,-1,'"+dtpFromDate.Value.ToString("yyyy/MM/dd")+"') and ExpDate < DATEADD(day,1,'"+dtpToDate.Value.ToString("yyy/MM/dd")+ "')";
                totalcostquery = "select SUM(TotalCost) from V_AllExpenses where ExpDate > DATEADD(day,-1,'" + dtpFromDate.Value.ToString("yyyy/MM/dd") + "') and ExpDate < DATEADD(day,1,'" + dtpToDate.Value.ToString("yyy/MM/dd") + "')";
            }
            else
            {
                query = "select ExpensesID[ID],Title [Expenses],ExpCategoryID,Name[Category], ExpDate[Date],TotalCost[Cost],Reason,Comments,UserName[Create By] from V_AllExpenses where (Title +' '+Name+' '+ Reason+' '+ Comments + ' ' + UserName) like '%" + searchvalue.Trim() + "%' and ExpDate > DATEADD(day,-1,'" + dtpFromDate.Value.ToString("yyyy/MM/dd") + "') and ExpDate < DATEADD(day,1,'" + dtpToDate.Value.ToString("yyy/MM/dd") + "')";
                totalcostquery = "select SUM(TotalCost) from V_AllExpenses where (Title +' '+Name+' '+ Reason+' '+ Comments + ' ' + UserName) like '%" + searchvalue.Trim() + "%' and ExpDate > DATEADD(day,-1,'" + dtpFromDate.Value.ToString("yyyy/MM/dd") + "') and ExpDate < DATEADD(day,1,'" + dtpToDate.Value.ToString("yyy/MM/dd") + "')";
            }
            DataTable dt = DatabaseAccess.Retrive(query);
            DataTable totalcostdt = DatabaseAccess.Retrive(totalcostquery);

            if (dt != null)
            {
                dgvAllExpenses.DataSource = dt;
                dgvAllExpenses.Columns[0].Visible = false; // ExpensesID
                dgvAllExpenses.Columns[1].Width = 200; // Expenses
                dgvAllExpenses.Columns[2].Visible = false; // ExpCategoryID
                dgvAllExpenses.Columns[3].Width = 150; // Category
                dgvAllExpenses.Columns[4].Width = 150; // Date
                dgvAllExpenses.Columns[5].Width = 100; // Cost
                dgvAllExpenses.Columns[6].Width = 200; // Reason
                dgvAllExpenses.Columns[7].Width = 200; // Comments
                dgvAllExpenses.Columns[8].Width = 100; // UserName
            }
            else
            {
                dgvAllExpenses.DataSource = null;
            }
            float totalcost = 0;
            if (totalcostdt != null)
            {
                float.TryParse(totalcostdt.Rows[0][0].ToString(), out totalcost);
                lblCost.Text = (totalcost == 0 ? "00:00" : totalcost.ToString()) + " Taka";
            }
            else
            {
                lblCost.Text = " 00:00 Taka";
            }
           
        }
        private void FrmAllExpenses_Load(object sender, EventArgs e)
        {
            RetriveList(string.Empty);
        }
        private void txtSearch_TextChanged(object sender, EventArgs e)
        {
            RetriveList(txtSearch.Text.Trim());
        }
        private void btnFind_Click(object sender, EventArgs e)
        {
            RetriveList(txtSearch.Text.Trim());
        }

        private void btnPrint_Click(object sender, EventArgs e)
        {
            FrmCustomExpensesReport frm = new FrmCustomExpensesReport(dtpFromDate.Value.ToString("yyyy/MM/dd"), dtpToDate.Value.ToString("yyyy/MM/dd"));
            frm.ShowDialog();
        }
    }
}
