using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Net.Mail;
using System.Net;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using PhoneStoreManagement.DAL;
using PhoneStoreManagement.BLL;

namespace PhoneStoreManagement
{
    public partial class FormForgotPW : Form
    {
        public FormForgotPW()
        {
            InitializeComponent();
        }

        private void btnSend_Click(object sender, EventArgs e)
        {
            BLL_ForgotPassword.Instance.SendEmail(txtUser.Text, txtEmail.Text);
        }

        private void btnVerify_Click(object sender, EventArgs e)
        {
            if (BLL_ForgotPassword.Instance.Verify(txtVerify.Text))
            {
                MessageBox.Show("Xác minh thành công", "Xác minh"); this.Hide();
            }
        }
    }
}
