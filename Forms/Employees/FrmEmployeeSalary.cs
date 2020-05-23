using CosmaticShop.DatabaseLayer;
using CosmaticShop.Forms.Employees.Employees;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace CosmaticShop.Forms.Employees
{
    public  partial class FrmEmployeeSalary : Form
    {
        

        FrmAllEmployees allEmployees;
        string EmployeeID;
        public FrmEmployeeSalary()
        {
            InitializeComponent();
            
            txtRemaining.ReadOnly = true;
            dateTimePicker.Visible = false;

        }

        public void DateToIntCalculation() {

            string sDate = dateTimePicker.Value.ToString("dd");
            int firstJoin = Convert.ToInt32(sDate);
            int nowDate = Convert.ToInt32(DateTime.Now.ToString("dd"));

            //txtMonthlySalary.Text = Convert.ToString(firstJoin);
            //txtRemaining.Text = Convert.ToString(nowDate);

            if(nowDate == 1)
            {
                ////do whatever include database operations;
                
            }
            else
            {
                ep.SetError(lblHavetoPay, "salary has already paid!");
                lblHavetoPay.Text = "0000";
            }

        }
        public void calculate()
        {

            try
            {
                //float remaingbalance = 0;
                //float.TryParse(lblHavetoPay.Text.Trim(), out remaingbalance);

                //float payment = 0;
                //float.TryParse(txtMonthlySalary.Text.Trim(), out payment);
                //float due = remaingbalance - payment;

                //lblHavetoPay.Text = due.ToString();

                //totalamount = totalamount - Convert.ToDecimal(item.Cells[5].Value)

                //double mm = (Convert.ToDouble(txtMonthlySalary.Text) - 0);
                double MonthlySalary = Convert.ToDouble(txtMonthlySalary.Text);
                double haveto = Convert.ToDouble(lblHavetoPay.Text);

                double due= haveto - MonthlySalary;
                txtRemaining.Text = Convert.ToDouble(due).ToString();

            }
            catch
            {
                //lblHavetoPay.Text = txtRemaining.Text;
            }
        }

        //private void GetEmployeeDetails(string EmployeeID)
        //{
        //    try
        //    {
        //        string query = string.Format("select Salary from EmployeeTable where EmployeeID ='" + EmployeeID.Trim() + "' ");
        //        DataTable dt = DatabaseAccess.Retrive(query);

        //        if (dt != null)
        //        {
        //            lblHavetoPay.Text = dt.Rows[0][0].ToString();
                    
        //        }
        //        else
        //        {
        //            lblHavetoPay.Text = "0";
                    
        //        }
        //    }
        //    catch
        //    {
        //        lblHavetoPay.Text = "0";
        //    }
        //}
        private void TxtSearch_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
            {
                testform employeeSalary = new testform(txtSearch.Text.Trim(), this);
                employeeSalary.ShowDialog();
                logic();
                DateToIntCalculation();         //monthly payment condition
            }
        }
        private void logic() {
            try
            {
                dateTimePicker.Value = Convert.ToDateTime(txtJoiningDate.Text);
                

                //if (dt != null)
                //{
                // if (dt.Rows.Count > 0)
                //{
                //ep.SetError(lblEmployeeName, "Already Exist!");
                //txtSearch.Focus();
                //return;
                //}
                //}
                ep.Clear();

                //bool active = Convert.ToBoolean(txtActiveStatus.Text);
                if (txtActiveStatus.Text == "False")
                {
                    //ep.SetError(txtSearch, "Employee is not Active!");
                    lblHavetoPay.Text = "0000";
                    lblHavetoPay.Focus();
                    return;
                }
                else
                { 

                    
                    DateTime a = Convert.ToDateTime( txtJoiningDate.Text);
                    DateTime b = a.AddDays(30);

                    List<DateTime> dt = new List<DateTime>();

                    for (DateTime i = a; i <= b; i.AddDays(30))
                    {
                        dt.Add(i);
                        
                    }
                    dt.Add(Convert.ToDateTime(txtJoiningDate));
                    
                }
                //if (txtContactNo.Text.Trim().Length == 0)
                //{
                //    ep.SetError(txtContactNo, "Please Enter Contact No!");
                //    txtContactNo.Focus();
                //    return;
                //}

                //if (txtAddress.Text.Trim().Length == 0)
                //{
                //    ep.SetError(txtAddress, "Please Enter Permanent Address!");
                //    txtAddress.Focus();
                //    return;
                //}

                //DataTable dt = DatabaseAccess.Retrive("select * from SupplierTable where name ='" + txtSupplier.Text.Trim() + "' and ContactNo = '" + txtContactNo.Text.Trim() + "'");
                //if (dt != null)
                //{
                //    if (dt.Rows.Count > 0)
                //    {
                //        ep.SetError(txtSupplier, "Already Exist!");
                //        txtSupplier.Focus();
                //        return;
                //    }
                //}

                //string insertquery = string.Format("insert into SupplierTable(EmployeeID,Name,ContactNo,Address,Description) values ('{0}','{1}','{2}','{3}','{4}')",
                //    UserInfo.EmployeeID, txtSupplier.Text.Trim(), txtContactNo.Text.Trim(), txtAddress.Text.Trim(), txtDescription.Text.Trim());
                //bool result = DatabaseAccess.Insert(insertquery);
                //if (result == true)
                //{
                //    MessageBox.Show("Save Successfully");
                //    RetriveList(string.Empty);
                //    ClearForm();
                //}
                //else
                //{
                //    MessageBox.Show("Please Provide Correct Details, And try Again!");
                //}
            }
            catch
            {
                MessageBox.Show("Please Provide Correct Details, And try Again!");
            }
        }

        private void FrmEmployeeSalary_Load(object sender, EventArgs e)
        {
            
        }

        private void BtnClear_Click(object sender, EventArgs e)
        {
            txtSearch.Text = "";
            txtRemaining.Text = "";
            txtMonthlySalary.Text = "";
            lblContructNo.Text = "";
            lblEmployeeName.Text = "";
            lblHavetoPay.Text = "";
            txtActiveStatus.Text = "";
            txtJoiningDate.Text = "";
        }

        private void TxtMonthlySalary_TextChanged_1(object sender, EventArgs e)
        {

            try
            {
                calculate();
                //txtRemaining.Text = (Convert.ToDouble(lblHavetoPay.Text) - Convert.ToDouble(txtMonthlySalary.Text)).ToString();
            }
            catch 
            {

               
            }
        }

        
    }
}
