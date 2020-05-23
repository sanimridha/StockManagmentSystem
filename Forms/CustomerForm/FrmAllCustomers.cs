using CosmaticShop.DatabaseLayer;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace CosmaticShop.Forms.CustomerForm
{
    public partial class FrmAllCustomers : Form
    {
        public FrmAllCustomers()
        {
            InitializeComponent();
        }

        private void RetriveList(string searchvalue)
        {
            string query = string.Empty;
            if (string.IsNullOrEmpty(searchvalue))
            {
                query = "select CustomerID [ID], Name [Customer], ContactNo [Contact No], [Address], UserName [Created By], [Description] from v_CustomerList";
            }
            else
            {
                query = " select CustomerID [ID], Name [Customer], ContactNo [Contact No], [Address], UserName [Created By], [Description] from v_CustomerList" +
                            " Where (Name + ' '+ ContactNo + ' ' + Address + ' ' + UserName) Like '%" + searchvalue.Trim() + "%'";
            }
            DataTable dt = DatabaseAccess.Retrive(query);
            if (dt != null)
            {
                dgvCustomers.DataSource = dt;
                dgvCustomers.Columns[0].Visible = false; // CustomerID
                dgvCustomers.Columns[1].Width = 200; // Name
                dgvCustomers.Columns[2].Width = 120; // ContactNo
                dgvCustomers.Columns[3].Width = 250; // Address
                dgvCustomers.Columns[4].Width = 100; // UserName
                dgvCustomers.Columns[5].Width = 250; // Description

            }
            else
            {
                dgvCustomers.DataSource = null;
            }
        }

        private void FrmAllCustomers_Load(object sender, EventArgs e)
        {
            RetriveList(string.Empty);
        }

        private void TxtSearch_TextChanged(object sender, EventArgs e)
        {
            RetriveList(txtSearch.Text.Trim());
        }
    }
}
