using CosmaticShop.DatabaseLayer;
using CosmaticShop.SourceCode;
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
    public partial class FrmEmployee : Form
    {
        public FrmEmployee()
        {
            InitializeComponent();
        }
        private void FillGrid(String searchvalue)
        {
            string query = "SELECT [EmployeeID] [ID],[FullName] [Employee],[UserTypeID],[ContactNo] [Contact No],[Email] [Email Address],[CNIC] [CNIC],[Photo],[Address] [Permanent Address],[Description],[UserName],[Password],[IsActive] [Status],[Salary] FROM [EmployeeTable]";
            if (!string.IsNullOrEmpty(searchvalue))
            {
                query = "SELECT [EmployeeID] [ID],[FullName] [Employee],[UserTypeID],[ContactNo] [Contact No],[Email] [Email Address],[CNIC] [CNIC],[Photo],[Address] [Permanent Address],[Description],[UserName],[Password],[IsActive] [Status],[Salary] FROM [EmployeeTable] where (FullName+' ' + ContactNo+' ' + Email+' ' + CNIC+' ' + Address+' ' + Description) Like '%" + searchvalue + "%'";
            }
            DataTable dt = DatabaseAccess.Retrive(query);
            if (dt != null)
            {
                dgvEmployees.DataSource = dt;
                if (dt.Rows.Count > 0)
                {
                    
                    dgvEmployees.Columns[0].Width = 100;  //EmployeeID
                    dgvEmployees.Columns[1].Width = 150;   //Employee
                    dgvEmployees.Columns[2].Visible = false;  //UserTypeID
                    dgvEmployees.Columns[3].Width = 100;  //ContactNO
                    dgvEmployees.Columns[4].Width = 150;   //Email
                    dgvEmployees.Columns[5].Width = 100;  //CNIC
                    dgvEmployees.Columns[6].Visible = false;  //Photo
                    dgvEmployees.Columns[11].Width = 80;  //status
                    dgvEmployees.Columns[7].Width = 250;  //Description
                    dgvEmployees.Columns[8].Width = 200;  //Address
                    dgvEmployees.Columns[9].Visible = false;   //Username
                    dgvEmployees.Columns[10].Visible = false;  //Password
                    dgvEmployees.Columns[11].Visible = false;  //Salary

                }
            }
            else
            {
                dgvEmployees.DataSource = null;
            }
        }

        private void GroupBox1_Enter(object sender, EventArgs e)
        {

        }

        private void FrmEmployee_Load(object sender, EventArgs e)
        {
            ComboHelper.FillUserTypes(cmbUserType);
            FillGrid(string.Empty);
        }

        private void BtnAdd_Click(object sender, EventArgs e)
        {
            ofd_EmployeePic.Title = "Select Employee Passport Size Photo";
            ofd_EmployeePic.Filter = "Image Files (*.bmp;*.jpg;*.jpeg,*.png)|*.BMP;*.JPG;*.JPEG;*.PNG";
            if(ofd_EmployeePic.ShowDialog() == DialogResult.OK)
            {
                picEmp.ImageLocation = ofd_EmployeePic.FileName;
            }
        }

        private void BtnRemove_Click(object sender, EventArgs e)
        {
            picEmp.Image = null;
        }
        private void ClearForm()
        {
            txtFullName.Clear();
            cmbUserType.SelectedIndex = 0;
            TxtContactNo.Clear();
            txtCNIC.Clear();
            txtAddress.Clear();
            txtEmail.Clear();
            txtDescription.Clear();
            txtSalary.Clear();
            picEmp.Image = null;
        }
        private void EnableComponents()
        {
            btnCancel.Enabled = true;
            btnUpdate.Enabled = true;
            dgvEmployees.Enabled = false;
            btnSave.Enabled = false;
            txtSearch.Enabled = false;
        }

        private void RestComponents()
        {
            btnCancel.Enabled = false;
            btnUpdate.Enabled = false;
            dgvEmployees.Enabled = true;
            btnSave.Enabled = true;
            txtSearch.Enabled = true;
            ClearForm();
            FillGrid(String.Empty);
            txtSearch.Clear();
            txtSalary.Clear();
        }

       

        private void BtnClear_Click(object sender, EventArgs e)
        {
            ClearForm();
        }

        private void BtnCancel_Click(object sender, EventArgs e)
        {
            RestComponents();
        }

        private void BtnSave_Click(object sender, EventArgs e)
        {
            try
            {
                ep.Clear();
                if (txtFullName.Text.Trim().Length == 0)
                {
                    ep.SetError(txtFullName, "Please Employee Full Name!");
                    txtFullName.Focus();
                    return;
                }
                if (cmbUserType.SelectedIndex == 0)
                {
                    ep.SetError(cmbUserType, "Select Employee Type");
                    cmbUserType.Focus();
                    return;
                }
                if (TxtContactNo.Text.Trim().Length == 0)
                {
                    ep.SetError(TxtContactNo, "Please Employee Contact No!");
                    TxtContactNo.Focus();
                    return;
                }
                if (txtEmail.Text.Trim().Length == 0)
                {
                    ep.SetError(txtEmail, "Please Employee Email Address!");
                    txtEmail.Focus();
                    return;
                }
                if (txtSalary.Text.Trim().Length == 0)
                {
                    ep.SetError(txtSalary, "Please Employee Salary");
                    txtSalary.Focus();
                    return;
                }
                if (txtAddress.Text.Trim().Length == 0)
                {
                    ep.SetError(txtAddress, "Please Employee Address!");
                    txtAddress.Focus();
                    return;
                }
                DataTable dt = DatabaseAccess.Retrive(string.Format("select * from EmployeeTable where ContactNo = '{0}' and FullName = '{1}'", TxtContactNo.Text.Trim(), txtFullName.Text.Trim()));
                if (dt != null)
                {
                    if (dt.Rows.Count > 0)
                    {
                        ep.SetError(txtFullName, "Already Registerd!");
                        txtFullName.Focus();
                        return;
                    }
                }

                string image64Bit = string.Empty;
                if (picEmp.Image != null)
                {
                    image64Bit = DatabaseAccess.ImageToBase64(picEmp.Image, System.Drawing.Imaging.ImageFormat.Png);
                }

                string insertquery = string.Format("insert into EmployeeTable(FullName,UserTypeID,ContactNo,Email,CNIC,photo,Address,Description,IsActive,Salary,JoiningDate)" +
                                                              " Values('{0}','{1}','{2}','{3}','{4}','{5}','{6}','{7}','{8}','{9}','{10}')",
                                                              txtFullName.Text.Trim(), cmbUserType.SelectedValue, TxtContactNo.Text.Trim(), txtEmail.Text.Trim(), txtCNIC.Text.Trim(), image64Bit, txtAddress.Text.Trim(), txtDescription.Text.Trim(), true, txtSalary.Text.Trim(),DateTime.Now);
                bool result = DatabaseAccess.Insert(insertquery);
                if (result == true)
                {
                    RestComponents();
                    MessageBox.Show("Registerd Successfully!");
                }
                else
                {
                    MessageBox.Show("Registeration faild!");
                }
            }
            catch (Exception)
            {
                MessageBox.Show("Registeration faild! Please Try Again.");


            }
        }

        private void TsmiEdit_Click(object sender, EventArgs e)
        {
            if (dgvEmployees != null)
            {
                if (dgvEmployees.Rows.Count > 0)
                {
                    if (dgvEmployees.SelectedRows.Count == 1)
                    {
                        txtFullName.Text = Convert.ToString(dgvEmployees.CurrentRow.Cells[1].Value); //Employee
                        cmbUserType.SelectedValue = Convert.ToString(dgvEmployees.CurrentRow.Cells[2].Value);//UserTypeID
                        TxtContactNo.Text = Convert.ToString(dgvEmployees.CurrentRow.Cells[3].Value);  //ContactNO
                        txtEmail.Text = Convert.ToString(dgvEmployees.CurrentRow.Cells[4].Value);   //Email
                        txtCNIC.Text = Convert.ToString(dgvEmployees.CurrentRow.Cells[5].Value);  //CNIC
                        picEmp.Image = DatabaseAccess.Base64ToImage(Convert.ToString(dgvEmployees.CurrentRow.Cells[6].Value));  //Photo
                        txtAddress.Text = Convert.ToString(dgvEmployees.CurrentRow.Cells[8].Value); //Address
                        txtDescription.Text = Convert.ToString(dgvEmployees.CurrentRow.Cells[7].Value);  //Description
                        txtSalary.Text = Convert.ToString(dgvEmployees.CurrentRow.Cells[11].Value);  //Salary
                        EnableComponents();

                    }
                    else
                    {
                        MessageBox.Show("Please Select One Record", "Warning", MessageBoxButtons.OK, MessageBoxIcon.Warning);

                    }
                }
            }
        }

        private void BtnUpdate_Click(object sender, EventArgs e)
        {
            try
            {
                ep.Clear();
                if (txtFullName.Text.Trim().Length == 0)
                {
                    ep.SetError(txtFullName, "Please Employee Full Name!");
                    txtFullName.Focus();
                    return;
                }
                if (cmbUserType.SelectedIndex == 0)
                {
                    ep.SetError(cmbUserType, "Select Employee Type");
                    cmbUserType.Focus();
                    return;
                }
                if (TxtContactNo.Text.Trim().Length == 0)
                {
                    ep.SetError(TxtContactNo, "Please Employee Contact No!");
                    TxtContactNo.Focus();
                    return;
                }
                if (txtEmail.Text.Trim().Length == 0)
                {
                    ep.SetError(txtEmail, "Please Employee Email Address!");
                    txtEmail.Focus();
                    return;
                }
                if (txtAddress.Text.Trim().Length == 0)
                {
                    ep.SetError(txtAddress, "Please Employee Address!");
                    txtAddress.Focus();
                    return;
                }
                DataTable dt = DatabaseAccess.Retrive(string.Format("select * from EmployeeTable where ContactNo = '{0}' and FullName = '{1}' and EmployeeID != '{2}'", TxtContactNo.Text.Trim(), txtFullName.Text.Trim(),Convert.ToString(dgvEmployees.CurrentRow.Cells[0].Value)));
                if (dt != null)
                {
                    if (dt.Rows.Count > 0)
                    {
                        ep.SetError(txtFullName, "Already Registerd!");
                        txtFullName.Focus();
                        return;
                    }
                }

                string image64Bit = string.Empty;
                if (picEmp.Image != null)
                {
                    image64Bit = DatabaseAccess.ImageToBase64(picEmp.Image, System.Drawing.Imaging.ImageFormat.Png);
                }

                string updatequery = string.Format("update EmployeeTable set FullName = '{0}',UserTypeID = '{1}',ContactNo = '{2}',Email = '{3}',CNIC = '{4}',photo = '{5}',Address = '{6}',Description = '{7}',IsActive = '{8}' ,Salary = '{9}', " +
                    " where EmployeeID = '{9}'",
                     txtFullName.Text.Trim(), cmbUserType.SelectedValue, TxtContactNo.Text.Trim(), txtEmail.Text.Trim(), txtCNIC.Text.Trim(), image64Bit, txtAddress.Text.Trim(), txtDescription.Text.Trim(), txtSalary.Text.Trim(), true, Convert.ToString(dgvEmployees.CurrentRow.Cells[0].Value));
                bool result = DatabaseAccess.Insert(updatequery);
                if (result == true)
                {
                    RestComponents();
                    MessageBox.Show("Updated Successfully!");
                }
                else
                {
                    MessageBox.Show("Updation faild!");
                }
            }
            catch (Exception)
            {
                MessageBox.Show("Updation faild! Please Try Again.");


            }
        }

        private void TxtSearch_TextChanged(object sender, EventArgs e)
        {
            FillGrid(txtSearch.Text.Trim());
        }

        private void ContextMenuStrip1_Opening(object sender, CancelEventArgs e)
        {
            if(dgvEmployees.Rows.Count > 0)
            {
                if(dgvEmployees.SelectedRows.Count == 1)
                {
                    tsmiStatus.Visible = true;
                    bool status = Convert.ToBoolean(dgvEmployees.CurrentRow.Cells[11].Value);
                    if(status == false)
                    {
                        tsmiStatus.Text = "Active";
                    }
                    else
                    {
                        tsmiStatus.Text = "De-Active";
                    }

                }
                else
                {
                    tsmiStatus.Visible = false;
                }

            }
            else
            {
                tsmiStatus.Visible = false;
            }
        }

        private void TsmiStatus_Click(object sender, EventArgs e)
        {
            if (dgvEmployees.Rows.Count > 0)
            {
                if (dgvEmployees.SelectedRows.Count == 1)
                {
                    tsmiStatus.Visible = true;
                    bool changestatus = false;
                    if (tsmiStatus.Text == "Active")
                    {
                        changestatus = true;
                    }
                    else 
                    {
                        changestatus = false; 
                    }

                    string changestatusquery = string.Format("update EmployeeTable set IsActive = '{0}' where EmployeeID = '{1}'",
                        changestatus, Convert.ToString(dgvEmployees.CurrentRow.Cells[0].Value));
                    bool result = DatabaseAccess.Update(changestatusquery);
                    if(result)
                    {
                        RestComponents();
                        MessageBox.Show("Starus is Changed!");
                    }
                    else
                    {
                        MessageBox.Show("Please Try Again!");
                    }
                }
                else
                {
                    MessageBox.Show("Please Select One Record!");
                }

            }
            
        }
    }
}
