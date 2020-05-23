using CosmaticShop.DatabaseLayer;
using CosmaticShop.Forms.CustomerForm;
using CosmaticShop.Reports.SaleReport;
using CosmaticShop.SourceCode;
using CosmaticShop.SourceCode.SourceCode;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace CosmaticShop.Forms.SaleForms
{
    public partial class FrmNewSale : Form   
    {
        public string supplierID = string.Empty;
        public FrmNewSale()
        {
            InitializeComponent();
            btnUpdate.Visible = false;
            btnCancel.Visible = false;
            SetColumnsWidth();
            lblContucttxt.Visible = false;
            txtContactNo.Visible = false;
            lblName.Visible = false;
            lblAddress.Visible = false;
            txtAddress.Visible = false;
            txtCustomer.Visible = false;
            btnSave1.Visible = false;
        }
        private void SetColumnsWidth()
        {
            dgvSaleCart.Columns[1].Width = 120;
            dgvSaleCart.Columns[3].Width = 100;
            dgvSaleCart.Columns[4].Width = 80;
            dgvSaleCart.Columns[5].Width = 80;
            dgvSaleCart.Columns[6].Width = 80;
        }


        private void ClearProductGroup()
        {
            cmbProduct.SelectedIndex = 0;
            txtPerQty.Clear();
        }

        private void EnableProductComponent()
        {
            btnCancel.Visible = true;
            btnUpdate.Visible = true;
            btnClear.Visible = false;
            btnAdd.Visible = false;
            dgvSaleCart.Enabled = false;
            txtSearch.Enabled = false;

        }

        private void DisableProductComponent()
        {
            btnCancel.Visible = false;
            btnUpdate.Visible = false;
            btnClear.Visible = true;
            btnAdd.Visible = true;
            dgvSaleCart.Enabled = true;
            txtSearch.Enabled = true;
            ClearProductGroup();
            GetProductDetails(Convert.ToString(cmbProduct.SelectedValue));
            CalculateTotalAmount();

        }

        private void ReSetForm()
        {
            btnCancel.Visible = false;
            btnUpdate.Visible = false;
            btnClear.Visible = true;
            btnAdd.Visible = true;
            dgvSaleCart.Enabled = true;
            txtSearch.Enabled = true;
            supplierID = string.Empty;
            lblCustomerName.Text = "";
            lblContactNo.Text = "";
            chkisPayment.Checked = true;
            GetProductDetails(Convert.ToString(cmbProduct.SelectedValue));
            CalculateTotalAmount();
            ClearProductGroup();
            dgvSaleCart.Rows.Clear();

        }
        private void CalculateTotalAmount()
        {
            try
            {
                if (dgvSaleCart != null)
                {
                    if (dgvSaleCart.Rows.Count > 0)
                    {
                        float totalamount = 0;

                        foreach (DataGridViewRow item in dgvSaleCart.Rows)
                        {
                            float amount = 0;

                            float.TryParse(item.Cells[6].Value.ToString(), out amount);
                            totalamount = totalamount + amount;
                        }
                        lblTotalItemCost.Text = totalamount.ToString();

                    }
                    else
                    {
                        lblTotalItemCost.Text = "0.00";
                    }
                }
                else
                {
                    lblTotalItemCost.Text = "0.00";
                }
            }
            catch
            {
                lblTotalItemCost.Text = "!Error";
            }
        }
        private void Deletepurchase(string purchaseid)
        {
            DataTable dt = DatabaseAccess.Retrive("select ItemID,Qty form PurchaseDetailTable where PurchaseID = '" + purchaseid + "'");
            if (dt != null)
            {
                foreach (DataRow item in dt.Rows)
                {
                    string stockupdatequery = string.Format("update StockTable set Qty= Qty - '{0}' where ItemID='{1}'",
                                                                       Convert.ToString(item[1]),
                                                                       Convert.ToString(item[0]));
                    DatabaseAccess.Update(stockupdatequery);
                }
            }
            string purchasedetailsquery = "delete from PurchaseDetailTable where PurchaseID = '" + purchaseid + "'";
            DatabaseAccess.Delete(purchasedetailsquery);


            string purchaseheaderquery = "delete from PurchaseTable where PurchaseID = '" + purchaseid + "'";
            DatabaseAccess.Delete(purchaseheaderquery);
        }
        private void FrmNewSale_Load(object sender, EventArgs e)
        {
            ComboHelper.Categories(cmbCategory);
        }

        private void CmbProduct_SelectedIndexChanged(object sender, EventArgs e)
        {
            GetProductDetails(Convert.ToString(cmbProduct.SelectedValue));
        }
        private void GetProductDetails(string proudctid)
        {
            try
            {
                string query = string.Format("select Qty,SaleUnitPrice from StockTable where ItemID ='" + proudctid.Trim() + "' ");
                DataTable dt = DatabaseAccess.Retrive(query);

                if (dt != null)
                {
                    lblCurrentQty.Text = dt.Rows[0][0].ToString();
                    lblSaleUnitePrice.Text = dt.Rows[0][1].ToString();


                    txtSaleUnitPrice.Text = dt.Rows[0][1].ToString();
                    
                }
                else
                {
                    lblCurrentQty.Text = "0";
                    lblSaleUnitePrice.Text = "0";                    
                }
            }
            catch
            {
                lblCurrentQty.Text = "0";
                lblSaleUnitePrice.Text = "0";

               
                
            }
        }
        private void CalculateCost()
        {
            try
            {
                int qty = 0;

                int.TryParse(txtPerQty.Text.Trim(), out qty);

                float purunitprice = 0;
                float.TryParse(txtSaleUnitPrice.Text.Trim(), out purunitprice);
                lblItemCost.Text = Convert.ToString(qty * purunitprice);
            }
            catch
            {
                lblItemCost.Text = "0";
            }
        }


        private void BtnAdd_Click(object sender, EventArgs e)
        {
            ep.Clear();

            if (cmbCategory.SelectedIndex == 0)
            {
                ep.SetError(cmbCategory, "Please Select Category!");
                cmbCategory.Focus();
                return;
            }

            if (cmbProduct.SelectedIndex == 0)
            {
                ep.SetError(cmbProduct, "Please Select Product!");
                cmbProduct.Focus();
                return;
            }

            string categoryid = Convert.ToString(cmbCategory.SelectedValue);
            string categoryname = cmbCategory.Text;

            string productid = Convert.ToString(cmbProduct.SelectedValue);
            string productName = cmbProduct.Text;

            int qty = 0;
            int.TryParse(txtPerQty.Text.Trim(), out qty);

            float salenitprice = 0;
            float.TryParse(txtSaleUnitPrice.Text.Trim(), out salenitprice);

            float itemcost = 0;
            float.TryParse(lblItemCost.Text.Trim(), out itemcost);

            if (qty == 0)
            {
                ep.SetError(txtPerQty, "Please Enter Purchase Quantity!");
                txtPerQty.Focus();
                txtPerQty.SelectAll();
                return;
            }

            int currentQty = Convert.ToInt32(lblCurrentQty.Text);
            int perQty = Convert.ToInt32(txtPerQty.Text);
            if (currentQty < perQty)
            {
                ep.SetError(txtPerQty, "You can't Purchase more then Current Quantity" + lblCurrentQty.Text);
                txtPerQty.Focus();
                txtPerQty.SelectAll();
                return;
            }


            if (salenitprice == 0)
            {
                ep.SetError(txtSaleUnitPrice, "Please Enter Sale Unit Price!");
                txtSaleUnitPrice.Focus();
                txtSaleUnitPrice.SelectAll();
                return;
            }

            foreach (DataGridViewRow checkitem in dgvSaleCart.Rows)
            {
                if (Convert.ToInt32(checkitem.Cells[0].Value.ToString()) == Convert.ToInt32(productid) &&
                    Convert.ToInt32(checkitem.Cells[2].Value.ToString()) == Convert.ToInt32(categoryid))
                {
                    ep.SetError(cmbProduct, "Product Alredy Exist in Purchase Cart!");
                    cmbProduct.Focus();
                    checkitem.Selected = true;
                    dgvSaleCart.ClearSelection();
                    return;
                }
            }
            DataGridViewRow additem = new DataGridViewRow();
            additem.CreateCells(dgvSaleCart);

            additem.Cells[0].Value = productid;
            additem.Cells[1].Value = productName;

            additem.Cells[2].Value = categoryid;
            additem.Cells[3].Value = categoryname;

            additem.Cells[4].Value = qty;

            additem.Cells[5].Value = salenitprice;
            additem.Cells[6].Value = itemcost;
            dgvSaleCart.Rows.Add(additem);

            DisableProductComponent();
        }

        private void BtnClear_Click(object sender, EventArgs e)
        {
            ClearProductGroup();
        }

        private void BtnUpdate_Click(object sender, EventArgs e)
        {
            ep.Clear();

            if (cmbCategory.SelectedIndex == 0)
            {
                ep.SetError(cmbCategory, "Please Select Category!");
                cmbCategory.Focus();
                return;
            }

            if (cmbProduct.SelectedIndex == 0)
            {
                ep.SetError(cmbProduct, "Please Select Product!");
                cmbProduct.Focus();
                return;
            }

            string categoryid = Convert.ToString(cmbCategory.SelectedValue);
            string categoryname = cmbCategory.Text;

            string productid = Convert.ToString(cmbProduct.SelectedValue);
            string productName = cmbProduct.Text;

            int qty = 0;
            int.TryParse(txtPerQty.Text.Trim(), out qty);


            float salenitprice = 0;
            float.TryParse(txtSaleUnitPrice.Text.Trim(), out salenitprice);

            float itemcost = 0;
            float.TryParse(lblItemCost.Text.Trim(), out itemcost);

            if (qty == 0)
            {
                ep.SetError(txtPerQty, "Please Enter Purchase Quantity!");
                txtPerQty.Focus();
                txtPerQty.SelectAll();
                return;
            }
            int currentQty = Convert.ToInt32(lblCurrentQty.Text);
            int perQty = Convert.ToInt32(txtPerQty.Text);
            if (currentQty < perQty)
            {
                ep.SetError(txtPerQty, "You can't Purchase more then Current Quantity" + lblCurrentQty.Text);
                txtPerQty.Focus();
                txtPerQty.SelectAll();
                return;
            }

            if (salenitprice == 0)
            {
                ep.SetError(txtSaleUnitPrice, "Please Enter Sale Unit Price!");
                txtSaleUnitPrice.Focus();
                txtSaleUnitPrice.SelectAll();
                return;
            }


            dgvSaleCart.CurrentRow.Cells[0].Value = productid;
            dgvSaleCart.CurrentRow.Cells[1].Value = productName;
            dgvSaleCart.CurrentRow.Cells[2].Value = categoryid;
            dgvSaleCart.CurrentRow.Cells[3].Value = categoryname;
            dgvSaleCart.CurrentRow.Cells[4].Value = qty;
            dgvSaleCart.CurrentRow.Cells[5].Value = salenitprice;
            dgvSaleCart.CurrentRow.Cells[6].Value = itemcost;
            DisableProductComponent();
        }

        private void BtnCancel_Click(object sender, EventArgs e)
        {
            DisableProductComponent();
        }

        private void BtnPurchaseConfirm_Click(object sender, EventArgs e)
        {
            try
            {
                ep.Clear();
                if (string.IsNullOrEmpty(supplierID))
                {
                    ep.SetError(txtSearch, "Please Search Supplier");
                    txtSearch.Focus();
                    return;
                }

                int supplierid = 0;
                int.TryParse(supplierID, out supplierid);
                if (supplierid == 0)
                {
                    ep.SetError(txtSearch, "Please Search Supplier");
                    txtSearch.Focus();
                    return;
                }


                if (lblCustomerName.Text.Trim().Length == 0)
                {
                    ep.SetError(txtSearch, "Please Search Supplier");
                    txtSearch.Focus();
                    return;
                }

                if (dgvSaleCart == null)
                {
                    ep.SetError(btnAdd, "Please Purchase some Product");
                    cmbProduct.Focus();
                    return;
                }
                if (dgvSaleCart.Rows.Count < 1)
                {
                    ep.SetError(btnAdd, "Please Purchase some Product");
                    cmbProduct.Focus();
                    return;
                }
                if (dgvSaleCart.Rows.Count > 0)
                {
                    CalculateTotalAmount();
                    float totalamount = 0;
                    float.TryParse(lblTotalItemCost.Text.Trim(), out totalamount);
                    if (totalamount == 0)
                    {
                        ep.SetError(btnAdd, "Please Purchase some Product");
                        cmbProduct.Focus();
                        return;
                    }

                    string purchaseheaderquery = string.Format("insert into SaleTable (EmployeeID,CustomerID,SaleDate,TotalAmount,Comments) values ('{0}','{1}','{2}','{3}','{4}')", UserInfo.EmployeeID, supplierid, DateTime.Now.ToString("yyyy/MM/dd"), totalamount, txtComment.Text.Trim());
                    bool purchaseresult = DatabaseAccess.Insert(purchaseheaderquery);
                    string purchaseid = string.Empty;
                    if (purchaseresult == true)
                    {
                        purchaseid = DatabaseAccess.Retrive("select max(SaleID) from SaleTable").Rows[0][0].ToString();
                        foreach (DataGridViewRow product in dgvSaleCart.Rows)
                        {
                            string productquery = string.Format("insert into SaleDetailTable(SaleID,ItemID,Qty,UnitPrice) values ('{0}','{1}','{2}','{3}')", purchaseid, Convert.ToString(product.Cells[0].Value), Convert.ToString(product.Cells[4].Value), Convert.ToString(product.Cells[5].Value));
                            try
                            {
                                bool purchasedetailsresult = DatabaseAccess.Insert(productquery);
                                if (purchasedetailsresult == false)
                                {
                                    Deletepurchase(purchaseid);
                                    MessageBox.Show("Un-Expedted Issue is occure Please Try Again!");
                                    return;
                                }
                                string stockupdatequery = string.Format("update StockTable set SaleUnitPrice = '{0}', Qty= Qty - '{1}' where ItemID='{3}'",
                                                                        Convert.ToString(product.Cells[5].Value),
                                                                        Convert.ToString(product.Cells[4].Value),
                                                                        Convert.ToString(product.Cells[6].Value),
                                                                        Convert.ToString(product.Cells[0].Value));
                                DatabaseAccess.Update(stockupdatequery);
                            }
                            catch
                            {
                                Deletepurchase(purchaseid);
                                MessageBox.Show("Un-Expedted Issue is occure Please Try Again!");
                                return;
                            }
                        }
                        string message = "Purchese is Confirmed";
                        if (chkisPayment.Checked == true)
                        {
                            string paymentquery = string.Format("insert into CustomerPaymentTable(SaleID,EmoloyeeID,PaidDate,TotalAmount,PaidAmount,BalanceAmount) values ('{0}','{1}','{2}','{3}','{4}','{5}')",
                                                                                                        purchaseid, UserInfo.EmployeeID, DateTime.Now.ToString("yyyy/MM/dd"), totalamount, totalamount, "0");
                            bool result = DatabaseAccess.Insert(paymentquery);
                            if (result == true)
                            {
                                message = message + "With Payment";
                            }
                        }
                        FrmSaleReport frm = new FrmSaleReport(Convert.ToInt32(purchaseid));
                        frm.Show();
                        ReSetForm();
                        MessageBox.Show(message);
                    }
                    else
                    {
                        MessageBox.Show("Please Provide Correct Details/ Re-Login!");
                        return;
                    }

                }
                else
                {

                    ep.SetError(btnAdd, "Please Purchase some Product");
                    cmbProduct.Focus();
                    return;
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "System Message");
            }
        }

        private void BtnPurchaseCancle_Click(object sender, EventArgs e)
        {
            ReSetForm();
        }

        private void TxtSearch_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
            {
                FrmSearchCustomers searchCustomer = new FrmSearchCustomers(txtSearch.Text.Trim(), this);
                searchCustomer.ShowDialog();
            }
        }

        private void CmbCategory_SelectedIndexChanged(object sender, EventArgs e)
        {
            ComboHelper.Products(cmbProduct, Convert.ToString(cmbCategory.SelectedValue));
        }

        private void TxtPerQty_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (!char.IsControl(e.KeyChar) && !char.IsDigit(e.KeyChar) &&
              (e.KeyChar != '.'))
            {
                e.Handled = true;
            }
        }

        private void TxtSaleUnitPrice_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (!char.IsControl(e.KeyChar) && !char.IsDigit(e.KeyChar) &&
              (e.KeyChar != '.'))
            {
                e.Handled = true;
            }
        }

        private void TxtPerQty_TextChanged(object sender, EventArgs e)
        {
            CalculateCost();
        }

        private void TxtSaleUnitPrice_TextChanged(object sender, EventArgs e)
        {
            CalculateCost();
        }

        private void DeleteToolStripMenuItem_Click(object sender, EventArgs e)
        {
            try
            {
                if (dgvSaleCart != null)
                {
                    if (dgvSaleCart.Rows.Count > 0)
                    {
                        if (dgvSaleCart.SelectedRows.Count == 1)
                        {
                            if (MessageBox.Show("Are You Sure Delete This Selected Record!", "Confirmation", MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.Yes)
                            {
                                dgvSaleCart.Rows.Remove(dgvSaleCart.SelectedRows[0]);
                                CalculateTotalAmount();
                            }
                        }
                        else
                        {
                            MessageBox.Show("Please select One Record");
                        }
                    }
                    else
                    {
                        MessageBox.Show("Purchase Cart is empty!");
                    }
                }
            }
            catch
            {
                MessageBox.Show("Please try Again!");
            }
        }

        private void EditToolStripMenuItem_Click(object sender, EventArgs e)
        {
            try
            {
                if (dgvSaleCart != null)
                {
                    if (dgvSaleCart.Rows.Count > 0)
                    {
                        if (dgvSaleCart.SelectedRows.Count == 1)
                        {
                            DataGridViewRow currentrow = dgvSaleCart.CurrentRow;

                            cmbCategory.SelectedValue = currentrow.Cells[2].Value;
                            cmbProduct.SelectedValue = currentrow.Cells[0].Value;
                            txtPerQty.Text = Convert.ToString(currentrow.Cells[4].Value);
                            txtSaleUnitPrice.Text = Convert.ToString(currentrow.Cells[5].Value);
                            lblItemCost.Text = Convert.ToString(currentrow.Cells[6].Value);
                            EnableProductComponent();
                        }
                        else
                        {
                            MessageBox.Show("Please select One Record");
                        }
                    }
                    else
                    {
                        MessageBox.Show("Purchase Cart is empty!");
                    }
                }
            }
            catch
            {

                MessageBox.Show("Please try Again!");
            }
        }

        private void TxtSearch_TextChanged(object sender, EventArgs e)
        {
            
        }

        private void chkisPayment_CheckedChanged(object sender, EventArgs e)
        {

        }

        private void Enable()
        {
            lblName.Visible = true;
            lblAddress.Visible = true;
            lblContactNo.Visible = true;
            txtAddress.Visible = true;
            txtContactNo.Visible = true;
            txtCustomer.Visible = true;
            btnSave1.Visible = true;

        }
        private void Enable2()
        {
            lblSearchCustomer.Visible = false;
          
            txtSearch.Visible = false;
            //lblCustoName.Visible = false;
            //txtCustomer.Visible = false;
            lblContuct1.Visible = false;
            lblContactNo.Visible = false;
            lblCustomerName.Visible = false;
            //lblAddress.Visible = false;
            //txtAddress.Visible = false;
            button1.Visible = false;
        }
        private void dis()
        {
            lblSearchCustomer.Visible = true;

            txtSearch.Visible = true;
            //lblCustoName.Visible = false;
            //txtCustomer.Visible = false;
            lblContuct1.Visible = true;
            lblContactNo.Visible = true;
            lblCustomerName.Visible = true;
            //lblAddress.Visible = false;
            //txtAddress.Visible = false;
            button1.Visible = true;
            lblContucttxt.Visible = false;
            txtContactNo.Visible = false;
            lblName.Visible = false;
            lblAddress.Visible = false;
            txtAddress.Visible = false;
            txtCustomer.Visible = false;
            btnSave1.Visible = false;
        }


        private void button1_Click(object sender, EventArgs e)
        {
            Enable();
            Enable2();
        }

        private void button2_Click(object sender, EventArgs e)
        {
            try
            {
                ep.Clear();
                if (txtCustomer.Text.Trim().Length == 0)
                {
                    ep.SetError(txtCustomer, "Please Enter Customer Titel!");
                    txtCustomer.Focus();
                    return;
                }

                if (txtContactNo.Text.Trim().Length == 0)
                {
                    ep.SetError(txtContactNo, "Please Enter Contact No!");
                    txtContactNo.Focus();
                    return;
                }

                if (txtAddress.Text.Trim().Length == 0)
                {
                    ep.SetError(txtAddress, "Please Enter Permanent Address!");
                    txtAddress.Focus();
                    return;
                }

                DataTable dt = DatabaseAccess.Retrive("select * from CustomerTable where name ='" + txtCustomer.Text.Trim() + "' and ContactNo = '" + txtContactNo.Text.Trim() + "'");
                if (dt != null)
                {
                    if (dt.Rows.Count > 0)
                    {
                        ep.SetError(txtCustomer, "Already Exist!");
                        txtCustomer.Focus();
                        return;
                    }
                }

                string insertquery = string.Format("insert into CustomerTable(EmployeeID,Name,ContactNo,Address) values ('{0}','{1}','{2}','{3}')",
                    UserInfo.EmployeeID, txtCustomer.Text.Trim(), txtContactNo.Text.Trim(), txtAddress.Text.Trim());
                bool result = DatabaseAccess.Insert(insertquery);
                if (result == true)
                {
                    MessageBox.Show("Save Successfully");
                    dis();
                    //RetriveList(string.Empty);
                    //ClearForm();
                }
                else
                {
                    MessageBox.Show("Please Provide Correct Details, And try Again!");
                }
            }
            catch
            {
                MessageBox.Show("Please Provide Correct Details, And try Again!");
            }
        }
    }
}
