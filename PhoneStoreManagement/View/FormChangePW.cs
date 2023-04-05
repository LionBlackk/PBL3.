using PhoneStoreManagement.BLL;
using PhoneStoreManagement.DAL;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Security.Cryptography;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace PhoneStoreManagement
{
    public partial class FormChangePW : Form
    {
        public FormChangePW()
        {
            InitializeComponent();
        }

        private void btnConfirm_Click(object sender, EventArgs e)
        {
            if(BLL_ChangePassword.Instance.ConfirmPassword(txtUserName.Text, txtOldPassword.Text, txtNewPassword.Text))
            {
                this.Dispose();
            }
        }

        private void btnCancel_Click(object sender, EventArgs e)
        {
            this.Dispose();
        }
        private void picShowOldPW_Click(object sender, EventArgs e)
        {
            if (picShowOldPW.Visible == true)
            {
                txtOldPassword.UseSystemPasswordChar = false;
                picShowOldPW.Visible = false;
                picHideOldPW.Visible = true;
            }
        }

        private void picHideOldPW_Click(object sender, EventArgs e)
        {
            if(picHideOldPW.Visible == true)
            {
                txtOldPassword.UseSystemPasswordChar = true;
                picShowOldPW.Visible = true;
                picHideOldPW.Visible = false;
            }
        }

        private void picShowNewPW_Click(object sender, EventArgs e)
        {
            if (picShowNewPW.Visible == true)
            {
                txtNewPassword.UseSystemPasswordChar = false;
                picHideNewPW.Visible = true;
                picShowNewPW.Visible = false;
            }
        }

        private void picHideNewPW_Click(object sender, EventArgs e)
        {
            if (picHideNewPW.Visible == true)
            {
                txtNewPassword.UseSystemPasswordChar = true;
                picHideNewPW.Visible = false;
                picShowNewPW.Visible = true;
            }
        }
    }
}
