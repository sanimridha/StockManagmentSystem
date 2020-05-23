using CosmaticShop.Forms;
using CosmaticShop.Forms.CustomerForm;
using CosmaticShop.Forms.Employees;
using CosmaticShop.Forms.ExpensesForm;
using CosmaticShop.Forms.PurchaseForm;
using CosmaticShop.Forms.SaleForms;
using CosmaticShop.Forms.StockForms;
using CosmaticShop.Forms.SupplierForm;
using CosmaticShop.Forms.UserForms;
using CosmaticShop.Forms.UserForms.UserForms;
using CosmaticShop.Reports.CustomerReports;
using CosmaticShop.Reports.ExpensesReport;
using CosmaticShop.Reports.PurchaseReports;
using CosmaticShop.Reports.SaleReport;
using CosmaticShop.Reports.StockReport;
using CosmaticShop.Reports.SupplierReport;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace CosmaticShop
{
    public partial class HomeForm : Form
    {
        public StartupForm StartUp;
        public FrmAllEmployees AllEmployeesForm;
        public FrmAllStock AllStockForm;
        public FrmAllSuppliers AllSupplierForm;
        public FrmAllCustomers AllCustomerForm;
        public FrmExpenses ExpensesFrom;
        public FrmAllExpenses AllExpensesFrom;
        
        public HomeForm()
        {
            InitializeComponent();
            tChangeTime.Start();
            StartUp = new StartupForm();
            StartUp.TopLevel = false;
            StartUp.Dock = DockStyle.Fill;
            StartUp.FormBorderStyle = FormBorderStyle.None;
            panelParent.Controls.Add(StartUp);
            StartUp.Show();
            Logout();
            panelParent.AutoScroll = true;
        }

        private void Logout()
        {
            msHomeForm.Enabled = false;
            tsbtnAllExpenses.Enabled = false;
            tsbtnLogOut.Visible = false;
            tsbtnNewExpenses.Enabled = false;
            tsbtnNewPurchase.Enabled = false;
            tsbbtnNewSale.Enabled = false;
            tsbtnPurchasePayment.Enabled = false;
            tsbtnSalePayment.Enabled = false;
            tsbtnStock.Enabled = false;
            tsbtnReports.Enabled = false;
            tsbtnLogin.Visible = true;

        }

        public void Login()
        {
            msHomeForm.Enabled = true;
            tsbtnAllExpenses.Enabled = true;
            tsbtnLogOut.Visible = true;
            tsbtnNewExpenses.Enabled = true;
            tsbtnNewPurchase.Enabled = true;
            tsbbtnNewSale.Enabled = true;
            tsbtnPurchasePayment.Enabled = true;
            tsbtnSalePayment.Enabled = true;
            tsbtnStock.Enabled = true;
            tsbtnReports.Enabled = true;
            tsbtnLogin.Visible = false;

        }
        private void ExitToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Application.Exit();
        }

        private void LogoutToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Application.Restart(); 
        }
        private void userTypeToolStripMenuItem_Click(object sender, EventArgs e)
        {
            FrmUserType user = new FrmUserType();
            user.ShowDialog();
        }

        private void employeeRegistrationToolStripMenuItem_Click(object sender, EventArgs e)
        {
            FrmEmployee emply = new FrmEmployee();
            emply.ShowDialog();
        }

        private void toolStripButton9_Click(object sender, EventArgs e)
        {
           
        }

        private void panelParent_Paint(object sender, PaintEventArgs e)
        {

        }

        private void tChangeTime_Tick(object sender, EventArgs e)
        {
            tsslblCurrentTime.Text = DateTime.Now.ToString("dddd dd MMMM yyyy : hh:mm:ss tt");
        }

        private void toolStripSplitButton1_ButtonClick(object sender, EventArgs e)
        {

        }

        private void toolStripSplitButton1_ButtonClick_1(object sender, EventArgs e)
        {

        }


        private void tsbtnLogin_Click(object sender, EventArgs e)
        {
            FrmUserLogin frml = new FrmUserLogin(this);
            frml.ShowDialog();
        }

        private void BtnLogout(object sender, EventArgs e)
        {
            Application.Restart();
        }

        private void tsmibtnChangePassword_Click(object sender, EventArgs e)
        {
            FrmPasswordChange fpc = new FrmPasswordChange();
            fpc.ShowDialog();
        }

        private void newUserToolStripMenuItem_Click(object sender, EventArgs e)
        {
            FrmCreateUser fcu = new FrmCreateUser();
            fcu.ShowDialog();
        }

        private void allUsersToolStripMenuItem_Click(object sender, EventArgs e)
        {
            frmAllUsers fau = new frmAllUsers();
            fau.ShowDialog();
        }

        private void newCategoryToolStripMenuItem_Click(object sender, EventArgs e)
        {
            FrmCategory fc = new FrmCategory();
            fc.ShowDialog();
        }

        private void newExpensesToolStripMenuItem_Click(object sender, EventArgs e)
        {
            if(ExpensesFrom == null)
            {
                ExpensesFrom = new FrmExpenses();
            }
            ExpensesFrom.TopLevel = false;
            panelParent.Controls.Add(ExpensesFrom);
            ExpensesFrom.Dock = DockStyle.Fill;
            ExpensesFrom.BringToFront();
            ExpensesFrom.FormBorderStyle = FormBorderStyle.None;
            ExpensesFrom.Show();
        }

        private void expensesCategoryToolStripMenuItem1_Click(object sender, EventArgs e)
        {
            FrmExpensesCategory fec = new FrmExpensesCategory();
            fec.ShowDialog();
        }

        private void newProductToolStripMenuItem_Click(object sender, EventArgs e)
        {
            frmStock fs = new frmStock();
            fs.ShowDialog();
        }

        private void allExpensesToolStripMenuItem_Click(object sender, EventArgs e)
        {
            if (AllExpensesFrom == null)
            {
                AllExpensesFrom = new FrmAllExpenses();
            }
            AllExpensesFrom.TopLevel = false;
            panelParent.Controls.Add(AllExpensesFrom);
            AllExpensesFrom.Dock = DockStyle.Fill;
            AllExpensesFrom.BringToFront();
            AllExpensesFrom.FormBorderStyle = FormBorderStyle.None;
            AllExpensesFrom.Show();
        }

        private void newSupplierToolStripMenuItem_Click(object sender, EventArgs e)
        {
            FrmSupplier fs = new FrmSupplier();
            fs.ShowDialog();
        }

        private void allSupplieruToolStripMenuItem_Click(object sender, EventArgs e)
        {           
                if (AllSupplierForm == null)
                {
                    AllSupplierForm = new FrmAllSuppliers();
                }

                AllSupplierForm.TopLevel = false;
                panelParent.Controls.Add(AllSupplierForm);
                AllSupplierForm.FormBorderStyle = FormBorderStyle.None;
                AllSupplierForm.Dock = DockStyle.Fill;
                AllSupplierForm.BringToFront();
                AllSupplierForm.Show();         
        }

        private void newCustomerToolStripMenuItem_Click(object sender, EventArgs e)
        {
            FrmCustomers fc = new FrmCustomers();
            fc.ShowDialog();
        }

        private void tsbtnNewPurchase_Click(object sender, EventArgs e)
        {
            newPurchaseToolStripMenuItem_Click(sender, e);
        }

        private void allCustomerToolStripMenuItem_Click(object sender, EventArgs e)
        {
            if (AllCustomerForm == null)
            {
                AllCustomerForm = new FrmAllCustomers();
            }

            AllCustomerForm.TopLevel = false;
            panelParent.Controls.Add(AllCustomerForm);
            AllCustomerForm.FormBorderStyle = FormBorderStyle.None;
            AllCustomerForm.Dock = DockStyle.Fill;
            AllCustomerForm.BringToFront();
            AllCustomerForm.Show();
        }

        private void allEmployeesToolStripMenuItem_Click(object sender, EventArgs e)
        {
            if (AllEmployeesForm == null)
            {
                AllEmployeesForm = new FrmAllEmployees();
            }

            AllEmployeesForm.TopLevel = false;
            panelParent.Controls.Add(AllEmployeesForm);
            AllEmployeesForm.FormBorderStyle = FormBorderStyle.None;
            AllEmployeesForm.Dock = DockStyle.Fill;
            AllEmployeesForm.BringToFront();
            AllEmployeesForm.Show();
            
        }

        private void allStockToolStripMenuItem_Click(object sender, EventArgs e)
        {
            if (AllStockForm == null)
            {
                AllStockForm = new FrmAllStock();
            }

            AllStockForm.TopLevel = false;
            panelParent.Controls.Add(AllStockForm);
            AllStockForm.FormBorderStyle = FormBorderStyle.None;
            AllStockForm.Dock = DockStyle.Fill;
            AllStockForm.BringToFront();
            AllStockForm.Show();
        }

        private void newPurchaseToolStripMenuItem_Click(object sender, EventArgs e)
        {
            FrmNewPurchase fnp = new FrmNewPurchase();
            fnp.ShowDialog();
        }

        private void purchasePaymentToolStripMenuItem_Click(object sender, EventArgs e)
        {
            FrmPurchasesPaymentPending fpp = new FrmPurchasesPaymentPending();
            fpp.ShowDialog();
        }

        private void newSaleToolStripMenuItem_Click(object sender, EventArgs e)
        {
            FrmNewSale fs = new FrmNewSale();
            fs.ShowDialog();
        }

        private void paymentHistoryToolStripMenuItem_Click(object sender, EventArgs e)
        {
            FrmAllPurchasePaymentHistory frm = new FrmAllPurchasePaymentHistory();
            frm.ShowDialog();
        }

        private void allPurchasesToolStripMenuItem_Click(object sender, EventArgs e)
        {
            FrmAllPurchases frm = new FrmAllPurchases();
            frm.ShowDialog();
        }

        private void salePaymentToolStripMenuItem_Click(object sender, EventArgs e)
        {
            FrmSalePaymentPending fspp = new FrmSalePaymentPending();
            fspp.ShowDialog();
        }

        private void allSalesToolStripMenuItem_Click(object sender, EventArgs e)
        {
            FrmAllSales frm = new FrmAllSales();
            frm.ShowDialog();
        }

        private void dailySaleReportToolStripMenuItem1_Click(object sender, EventArgs e)
        {
            FrmDailySalesReport fdsr = new FrmDailySalesReport();
            fdsr.ShowDialog();
        }

        private void weeklySaleReportToolStripMenuItem1_Click(object sender, EventArgs e)
        {
            FrmWeeklySaleReport frm = new FrmWeeklySaleReport();
            frm.ShowDialog();
        }

        private void monthlySaleReportToolStripMenuItem1_Click(object sender, EventArgs e)
        {
            FrmMonthlySalesReport frm = new FrmMonthlySalesReport();
            frm.ShowDialog();
        }

        private void customeSaleReportToolStripMenuItem_Click(object sender, EventArgs e)
        {
            FrmAllSales frm = new FrmAllSales();
            frm.Text = "Custom Base Sale Report";
            frm.ShowDialog();
        }

        private void purchaseDailyReportToolStripMenuItem_Click(object sender, EventArgs e)
        {
            FrmDailyPurchaseReport frm = new FrmDailyPurchaseReport();
            frm.ShowDialog();
        }

        private void purchaseWeeklyReportToolStripMenuItem_Click(object sender, EventArgs e)
        {
            FrmWeeklyPurchaseReport frm = new FrmWeeklyPurchaseReport();
            frm.ShowDialog();
        }

        private void purchaseMonthlyReportToolStripMenuItem_Click(object sender, EventArgs e)
        {
            FrmMonthlyPurchaseReport frm = new FrmMonthlyPurchaseReport();
            frm.ShowDialog();
        }

        private void purchaseCustomeReportToolStripMenuItem_Click(object sender, EventArgs e)
        {
            FrmAllPurchases frm = new FrmAllPurchases();
            frm.Text = "Custom Purchase Report";
            frm.ShowDialog();
        }

        private void allSupplierListToolStripMenuItem_Click(object sender, EventArgs e)
        {
            FrmSupplierReport frm = new FrmSupplierReport();
            frm.ShowDialog();
        }

        private void allCustomerListToolStripMenuItem_Click(object sender, EventArgs e)
        {
            FrmAllCustomerList frm = new FrmAllCustomerList();
            frm.ShowDialog();
        }

        private void dailyExpensesReportToolStripMenuItem_Click(object sender, EventArgs e)
        {
            FrmDailyExpenses frm = new FrmDailyExpenses();
            frm.ShowDialog();
        }

        private void monthlyExpensesReportToolStripMenuItem_Click(object sender, EventArgs e)
        {
            FrmMonthlyExpensesReport frm = new FrmMonthlyExpensesReport();
            frm.ShowDialog();
        }

        private void weeklyExpensesReportToolStripMenuItem_Click(object sender, EventArgs e)
        {
            FrmWeeklyExpensesReport frm = new FrmWeeklyExpensesReport();
            frm.ShowDialog();
        }

        private void expensesCustomReportToolStripMenuItem_Click(object sender, EventArgs e)
        {
            FrmAllExpenses frm = new FrmAllExpenses();
            frm.Text = "Custom Expenses Report";
            frm.ShowDialog();
        }

        private void allStockReportToolStripMenuItem1_Click(object sender, EventArgs e)
        {
            FrmStockReport frm = new FrmStockReport();
            frm.ShowDialog();
        }

        private void stockExpiryReportToolStripMenuItem1_Click(object sender, EventArgs e)
        {
            FrmExpStockReport frm = new FrmExpStockReport();
            frm.ShowDialog();
        }

        private void stockLowReportToolStripMenuItem1_Click(object sender, EventArgs e)
        {
            FrmLowStockReport frm = new FrmLowStockReport();
            frm.ShowDialog();
        }

        private void HomeForm_Load(object sender, EventArgs e)
        {

        }

        private void tsbbtnNewSale_Click(object sender, EventArgs e)
        {
            newSaleToolStripMenuItem_Click(sender, e);
        }

        private void tsbtnSalePayment_Click(object sender, EventArgs e)
        {
            salePaymentToolStripMenuItem_Click(sender, e);
        }

        private void tsbtnPurchasePayment_Click(object sender, EventArgs e)
        {
            purchasePaymentToolStripMenuItem_Click(sender, e);
        }

        private void stockReportToolStripMenuItem_Click(object sender, EventArgs e)
        {
            allStockToolStripMenuItem_Click(sender, e);
        }

        private void allStockToolStripMenuItem1_Click(object sender, EventArgs e)
        {
            allStockReportToolStripMenuItem1_Click(sender, e);
        }

        private void newProductToolStripMenuItem1_Click(object sender, EventArgs e)
        {
            newProductToolStripMenuItem_Click(sender, e);
        }

        private void tsbtnNewExpenses_Click(object sender, EventArgs e)
        {
            newExpensesToolStripMenuItem_Click(sender, e);
        }

        private void tsbtnAllExpenses_Click(object sender, EventArgs e)
        {
            allExpensesToolStripMenuItem_Click(sender, e);
        }

        private void EmployeeSalaryToolStripMenuItem_Click(object sender, EventArgs e)
        {
            FrmEmployeeSalary frmEmployeeSalary = new FrmEmployeeSalary();
            frmEmployeeSalary.ShowDialog();
        }

        
    }
}
