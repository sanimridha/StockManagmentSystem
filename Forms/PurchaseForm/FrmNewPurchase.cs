using CosmaticShop.DatabaseLayer;
using CosmaticShop.Forms.SupplierForm;
using CosmaticShop.Reports.PurchaseReports;
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

namespace CosmaticShop.Forms.PurchaseForm
{
    public partial class FrmNewPurchase : Form
    {
        public string supplierID = string.Empty;
        public FrmNewPurchase()
        {
            InitializeComponent();
            btnUpdate.Visible = false;
            btnCancel.Visible = false;
            SetColumnsWidth();
        }

        private void SetColumnsWidth()
        {
            dgvPurchaseCart.Columns[1].Width = 120;
            dgvPurchaseCart.Columns[3].Width = 100;
            dgvPurchaseCart.Columns[4].Width = 80;
            dgvPurchaseCart.Columns[5].Width = 80;
            dgvPurchaseCart.Columns[6].Width = 80;
            dgvPurchaseCart.Columns[7].Width = 100;
        }

        private void txtSearch_KeyDown(object sender, KeyEventArgs e)
        {
            if(e.KeyCode == Keys.Enter)
            {
                FrmSearchSuppliers searchSuppliers = new FrmSearchSuppliers(txtSearch.Text.Trim(), this);
                searchSuppliers.ShowDialog();
            }
        }

        private void checkBox1_CheckedChanged(object sender, EventArgs e)
        {

        }

        private void FrmNewPurchase_Load(object sender, EventArgs e)
        {
            ComboHelper.Categories(cmbCategory);
        }

        private void cmbCategory_SelectedIndexChanged(object sender, EventArgs e)
        {
            ComboHelper.Products(cmbProduct,Convert.ToString(cmbCategory.SelectedValue));
        }

        private void cmbProduct_SelectedIndexChanged(object sender, EventArgs e)
        {
            GetProductDetails(Convert.ToString(cmbProduct.SelectedValue));
        }
        private void GetProductDetails(string proudctid)
        {
            try
            {
                string query = string.Format("select Qty,SaleUnitPrice,CurrentPurchaseUnitPrice from StockTable where ItemID ='" + proudctid.Trim() + "' ");
                DataTable dt = DatabaseAccess.Retrive(query);

                if (dt != null)
                {
                    lblCurrentQty.Text = dt.Rows[0][0].ToString();
                    lblSaleUnitePrice.Text = dt.Rows[0][1].ToString();
                    lblCurrentPurchaseUnitePrice.Text = dt.Rows[0][2].ToString();


                    txtSaleUnitPrice.Text = dt.Rows[0][1].ToString();
                    txtPerUnitPrice.Text = dt.Rows[0][2].ToString();
                }
                else
                {
                    lblCurrentQty.Text = "0";
                    lblSaleUnitePrice.Text = "0";
                    lblCurrentPurchaseUnitePrice.Text = "0";

                    txtSaleUnitPrice.Text = "0";
                    txtPerUnitPrice.Text = "0";
                }
            }
            catch 
            {
                lblCurrentQty.Text = "0";
                lblSaleUnitePrice.Text = "0";
                lblCurrentPurchaseUnitePrice.Text = "0";

                txtSaleUnitPrice.Text = "0";
                txtPerUnitPrice.Text = "0";
            }
        }

        private void CalculateCost()
        {
            try
            {
                int qty = 0;

                int.TryParse(txtPerQty.Text.Trim(), out qty);

                float purunitprice = 0;
                float.TryParse(txtPerUnitPrice.Text.Trim(), out purunitprice);
                lblItemCost.Text = Convert.ToString(qty * purunitprice);
            }
            catch 
            {

                lblItemCost.Text = "0";
            }
        }

        private void txtPerQty_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (!char.IsControl(e.KeyChar) && !char.IsDigit(e.KeyChar) &&
              (e.KeyChar != '.'))
            {
                e.Handled = true;
            }           
        }

        private void txtPerUnitPrice_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (!char.IsControl(e.KeyChar) && !char.IsDigit(e.KeyChar))
            {
                e.Handled = true;
            }
        }

        private void txtSaleUnitPrice_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (!char.IsControl(e.KeyChar) && !char.IsDigit(e.KeyChar) &&
              (e.KeyChar != '.'))
            {
                e.Handled = true;
            }
        }

        private void txtPerQty_TextChanged(object sender, EventArgs e)
        {
            CalculateCost();
        }

        private void txtPerUnitPrice_TextChanged(object sender, EventArgs e)
        {
            CalculateCost();
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
            dgvPurchaseCart.Enabled = false;
            txtSearch.Enabled = false;

        }

        private void DisableProductComponent()
        {
            btnCancel.Visible = false;
            btnUpdate.Visible = false;
            btnClear.Visible = true;
            btnAdd.Visible = true;
            dgvPurchaseCart.Enabled = true;
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
            dgvPurchaseCart.Enabled = true;
            txtSearch.Enabled = true;
            supplierID = string.Empty;
            lblSupplyerName.Text = "";
            lblContructNo.Text = "";
            chkisPayment.Checked = true;
            GetProductDetails(Convert.ToString(cmbProduct.SelectedValue));
            CalculateTotalAmount();
            ClearProductGroup();
            dgvPurchaseCart.Rows.Clear();

        }
        private void btnAdd_Click(object sender, EventArgs e)
        {
            ep.Clear();

            if(cmbCategory.SelectedIndex == 0)
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

            string categoryid =Convert.ToString(cmbCategory.SelectedValue);
            string categoryname = cmbCategory.Text;

            string productid = Convert.ToString(cmbProduct.SelectedValue);
            string productName = cmbProduct.Text;

            int qty = 0;
            int.TryParse(txtPerQty.Text.Trim(), out qty);

            float purunitprice = 0;
            float.TryParse(txtPerUnitPrice.Text.Trim(), out purunitprice);

            float salenitprice = 0;
            float.TryParse(txtSaleUnitPrice.Text.Trim(), out salenitprice);

            float itemcost = 0;
            float.TryParse(lblItemCost.Text.Trim(), out itemcost);

            if(qty == 0)
            {
                ep.SetError(txtPerQty, "Please Enter Purchase Quantity!");
                txtPerQty.Focus();
                txtPerQty.SelectAll();
                return;
            }
            if (purunitprice == 0)
            {
                ep.SetError(txtPerUnitPrice, "Please Enter Purchase Unit Price!");
                txtPerUnitPrice.Focus();
                txtPerUnitPrice.SelectAll();
                return;
            }

            if (salenitprice == 0)
            {
                ep.SetError(txtSaleUnitPrice, "Please Enter Sale Unit Price!");
                txtSaleUnitPrice.Focus();
                txtSaleUnitPrice.SelectAll();
                return;
            }

            foreach (DataGridViewRow checkitem in dgvPurchaseCart.Rows)
            {
                if (Convert.ToInt32(checkitem.Cells[0].Value.ToString()) == Convert.ToInt32(productid)&&
                    Convert.ToInt32(checkitem.Cells[2].Value.ToString()) == Convert.ToInt32(categoryid))
                {
                    ep.SetError(cmbProduct, "Product Alredy Exist in Purchase Cart!");
                    cmbProduct.Focus();
                    checkitem.Selected = true;
                    dgvPurchaseCart.ClearSelection();
                    return;
                }
            }
            DataGridViewRow additem = new DataGridViewRow();
            additem.CreateCells(dgvPurchaseCart);

            additem.Cells[0].Value = productid;
            additem.Cells[1].Value = productName;

            additem.Cells[2].Value = categoryid;
            additem.Cells[3].Value = categoryname;

            additem.Cells[4].Value = qty;
            additem.Cells[5].Value = purunitprice;

            additem.Cells[6].Value = salenitprice;
            additem.Cells[7].Value = itemcost;
            dgvPurchaseCart.Rows.Add(additem);

            DisableProductComponent();
        }

        private void btnClear_Click(object sender, EventArgs e)
        {
            ClearProductGroup();
        }

        private void btnCancel_Click(object sender, EventArgs e)
        {
            DisableProductComponent();
        }

        private void deleteToolStripMenuItem_Click(object sender, EventArgs e)
        {
            try
            {
                if (dgvPurchaseCart != null)
                {
                    if (dgvPurchaseCart.Rows.Count > 0)
                    {
                        if (dgvPurchaseCart.SelectedRows.Count == 1)
                        {
                            if (MessageBox.Show("Are You Sure Delete This Selected Record!", "Confirmation", MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.Yes)
                            {
                                dgvPurchaseCart.Rows.Remove(dgvPurchaseCart.SelectedRows[0]);
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

        private void editToolStripMenuItem_Click(object sender, EventArgs e)
        {
            try
            {
                if (dgvPurchaseCart != null)
                {
                    if (dgvPurchaseCart.Rows.Count > 0)
                    {
                        if (dgvPurchaseCart.SelectedRows.Count == 1)
                        {
                            DataGridViewRow currentrow = dgvPurchaseCart.CurrentRow;

                            cmbCategory.SelectedValue = currentrow.Cells[2].Value;
                            cmbProduct.SelectedValue = currentrow.Cells[0].Value;
                            txtPerQty.Text =Convert.ToString( currentrow.Cells[4].Value);
                            txtPerUnitPrice.Text = Convert.ToString(currentrow.Cells[5].Value);
                            txtSaleUnitPrice.Text = Convert.ToString(currentrow.Cells[6].Value);
                            lblItemCost.Text = Convert.ToString(currentrow.Cells[7].Value);
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

        private void btnUpdate_Click(object sender, EventArgs e)
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

            float purunitprice = 0;
            float.TryParse(txtPerUnitPrice.Text.Trim(), out purunitprice);

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
            if (purunitprice == 0)
            {
                ep.SetError(txtPerUnitPrice, "Please Enter Purchase Unit Price!");
                txtPerUnitPrice.Focus();
                txtPerUnitPrice.SelectAll();
                return;
            }

            if (salenitprice == 0)
            {
                ep.SetError(txtSaleUnitPrice, "Please Enter Sale Unit Price!");
                txtSaleUnitPrice.Focus();
                txtSaleUnitPrice.SelectAll();
                return;
            }


            dgvPurchaseCart.CurrentRow.Cells[0].Value = productid;
            dgvPurchaseCart.CurrentRow.Cells[1].Value = productName;
            dgvPurchaseCart.CurrentRow.Cells[2].Value = categoryid;
            dgvPurchaseCart.CurrentRow.Cells[3].Value = categoryname;
            dgvPurchaseCart.CurrentRow.Cells[4].Value = qty;
            dgvPurchaseCart.CurrentRow.Cells[5].Value = purunitprice;
            dgvPurchaseCart.CurrentRow.Cells[6].Value = salenitprice;
            dgvPurchaseCart.CurrentRow.Cells[7].Value = itemcost;
            DisableProductComponent();
        }
        private void CalculateTotalAmount()
        {
            try
            {
                if(dgvPurchaseCart != null)
                {
                    if (dgvPurchaseCart.Rows.Count > 0)
                    {
                        float totalamount = 0;

                        foreach (DataGridViewRow item in dgvPurchaseCart.Rows)
                        {
                            float amount = 0;

                            float.TryParse(item.Cells[7].Value.ToString(), out amount);
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

        private void btnPurchaseCancle_Click(object sender, EventArgs e)
        {
            ReSetForm();
        }

        private void btnPurchaseConfirm_Click(object sender, EventArgs e)
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


                if (lblSupplyerName.Text.Trim().Length == 0)
                {
                    ep.SetError(txtSearch, "Please Search Supplier");
                    txtSearch.Focus();
                    return;
                }

                if(dgvPurchaseCart == null )
                {
                    ep.SetError(btnAdd, "Please Purchase some Product");
                    cmbProduct.Focus();
                    return;                  
                }
                if (dgvPurchaseCart.Rows.Count < 1)
                {
                    ep.SetError(btnAdd, "Please Purchase some Product");
                    cmbProduct.Focus();
                    return;
                }
                if (dgvPurchaseCart.Rows.Count > 0)
                {
                    CalculateTotalAmount();
                    float totalamount = 0;
                    float.TryParse(lblTotalItemCost.Text.Trim(), out totalamount);
                    if(totalamount == 0)
                    {
                        ep.SetError(btnAdd, "Please Purchase some Product");
                        cmbProduct.Focus();
                        return;
                    }

                    string purchaseheaderquery = string.Format("insert into PurchaseTable (EmployeeID,SupplierID,PurchaseDate,TotalAmount,Comments) values ('{0}','{1}','{2}','{3}','{4}')",UserInfo.EmployeeID,supplierid,DateTime.Now.ToString("yyyy/MM/dd"),totalamount,txtComment.Text.Trim());
                    bool purchaseresult = DatabaseAccess.Insert(purchaseheaderquery);
                    string purchaseid = string.Empty;
                    if(purchaseresult == true)
                    {
                        purchaseid = DatabaseAccess.Retrive("select max(PurchaseID) from PurchaseTable").Rows[0][0].ToString();
                        foreach (DataGridViewRow product in dgvPurchaseCart.Rows)
                        {
                            string productquery = string.Format("insert into PurchaseDetailTable(PurchaseID,ItemID,Qty,UnitPrice) values ('{0}','{1}','{2}','{3}')", purchaseid,Convert.ToString(product.Cells[0].Value), Convert.ToString(product.Cells[4].Value), Convert.ToString(product.Cells[5].Value));
                            try
                            {
                                bool purchasedetailsresult = DatabaseAccess.Insert(productquery);
                                if(purchasedetailsresult == false)
                                {
                                    Deletepurchase(purchaseid);
                                    MessageBox.Show("Un-Expedted Issue is occure Please Try Again!");
                                    return;
                                }
                                string stockupdatequery = string.Format("update StockTable set CurrentPurchaseUnitPrice = '{0}', Qty= Qty + '{1}',SaleUnitPrice='{2}' where ItemID='{3}'",
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
                        if(chkisPayment.Checked == true)
                        {
                            string paymentquery = string.Format("insert into SupplierPaymentTable(PurchaseID,EmployeeId,PaymentDate,TotalAmount,PaidAmount,BalanceAmount) values ('{0}','{1}','{2}','{3}','{4}','{5}')",
                                                                                                        purchaseid,UserInfo.EmployeeID,DateTime.Now.ToString("yyyy/MM/dd"),totalamount,totalamount,"0");
                            bool result = DatabaseAccess.Insert(paymentquery);
                            if (result == true)
                            {
                                message = message + "With Payment";
                            }
                        }
                        FrmPurchaseReports frm = new FrmPurchaseReports(Convert.ToInt32(purchaseid));
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
                MessageBox.Show(ex.Message,"System Message");
            }
        }

        private void Deletepurchase(string purchaseid)
        {
            DataTable dt = DatabaseAccess.Retrive("select ItemID,Qty form PurchaseDetailTable where PurchaseID = '" + purchaseid + "'");
            if(dt != null)
            {
                foreach (DataRow item in dt.Rows)
                {
                    string stockupdatequery = string.Format("update StockTable set Qty= Qty - '{0}' where ItemID='{1}'",
                                                                       Convert.ToString(item[1]),
                                                                       Convert.ToString(item[0]));
                    DatabaseAccess.Update(stockupdatequery);
                }
            }
            string purchasedetailsquery = "delete from PurchaseDetailTable where PurchaseID = '"+ purchaseid + "'";
            DatabaseAccess.Delete(purchasedetailsquery);

           
            string purchaseheaderquery = "delete from PurchaseTable where PurchaseID = '" + purchaseid + "'";
           DatabaseAccess.Delete(purchaseheaderquery);
        }

        
    }
}
