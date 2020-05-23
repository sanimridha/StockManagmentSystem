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

namespace CosmaticShop.Forms.SupplierForm
{
    public partial class FrmAllSuppliers : Form
    {
        public FrmAllSuppliers()
        {
            InitializeComponent();
        }

        private void RetriveList(string searchvalue)
        {
            string query = string.Empty;
            if (string.IsNullOrEmpty(searchvalue))
            {
                query = "select SupplierID [ID], Name [Supplier], ContactNo [Contact No], [Address], UserName [Created By], [Description] from v_SupplierList";
            }
            else
            {
                query = " select SupplierID [ID], Name [Supplier], ContactNo [Contact No], [Address], UserName [Created By], [Description] from v_SupplierList" +
                            " Where (Name + ' '+ ContactNo + ' ' + Address + ' ' + UserName) Like '%" + searchvalue.Trim() + "%'";
            }
            DataTable dt = DatabaseAccess.Retrive(query);
            if (dt != null)
            {
                dgvSuppliers.DataSource = dt;
                dgvSuppliers.Columns[0].Visible = false; // SupplierID
                dgvSuppliers.Columns[1].Width = 200; // Name
                dgvSuppliers.Columns[2].Width = 120; // ContactNo
                dgvSuppliers.Columns[3].Width = 250; // Address
                dgvSuppliers.Columns[4].Width = 100; // UserName
                dgvSuppliers.Columns[5].Width = 250; // Description

            }
            else
            {
                dgvSuppliers.DataSource = null;
            }
        }

        private void FrmAllSuppliers_Load(object sender, EventArgs e)
        {
            RetriveList(string.Empty);
        }

        private void TxtSearch_TextChanged(object sender, EventArgs e)
        {
            RetriveList(txtSearch.Text.Trim());
        }
    }
}
