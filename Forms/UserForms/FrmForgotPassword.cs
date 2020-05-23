using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Net;
using System.Net.Mail;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace CosmaticShop.Forms.UserForms.UserForms
{
    public partial class FrmForgotPassword : Form
    {
        public FrmForgotPassword()
        {
            InitializeComponent();
        }

        public string ForgotPassWord(string email)
        {
            string message = String.Empty;
            try
            {
                DataTable dt = DatabaseLayer.DatabaseAccess.Retrive("select top 1 UserName,Password from EmployeeTable where Email = '" + email.Trim()+"'");
                if(dt != null)
                {
                    string recevier = email;
                    string subject = "Password Recovery";

                    var senderEmail = new MailAddress("hrs.shuvo.bd@gmail.com", "Cosmatic Shop");
                    var receverEmail = new MailAddress(recevier, "User");
                    var password = "01831701171";
                    var sub = dt.Rows[0][0].ToString() + "Login Details";
                    var body = "User Name: " +  dt.Rows[0][0].ToString () + "\n Password: " + dt.Rows[0][1].ToString();
                    var smtp = new SmtpClient
                    {
                        Host = "smtp.gmail.com",
                        Port = 587,
                        EnableSsl = true,
                        DeliveryMethod = SmtpDeliveryMethod.Network,
                        Credentials = new NetworkCredential(senderEmail.Address,password)
                    };

                    using (var mess = new MailMessage(senderEmail, receverEmail)
                    {
                        Subject = subject,
                        Body = body,
                    })
                    {
                        smtp.Send(mess);
                    }
                    message = " Login Details Send Successfully, Please Cheake Email Address.";
                }
                else
                {
                    message = " Please Enter Corect Email Address! ";
                }
            }
            catch (Exception ex)
            {
                message = ex.Message;
            }
            return message;
        }

        private void btnSendEmail_Click(object sender, EventArgs e)
        {
            ep.Clear();
            if(txtEmailAddress.Text.Length == 0)
            {
                ep.SetError(txtEmailAddress, "Please Enter Email Address");
                txtEmailAddress.Focus();
                return;
            }
           string message = ForgotPassWord(txtEmailAddress.Text.Trim());
            MessageBox.Show(message);
        }
    }
}
