using PhoneStoreManagement.BLL;
using PhoneStoreManagement.DAL;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace PhoneStoreManagement
{
    public partial class FormResetPassword : Form
    {
        public FormResetPassword()
        {
            InitializeComponent();
        }

        private void btnConfirm_Click(object sender, EventArgs e)
        {
            if(BLL_ResetPassword.Instance.ConfirmPassword(txtUserName.Text, txtNewPW.Text, txtConfirmPW.Text))
            {
                this.Dispose();
            }
        }

        private void btnCancel_Click(object sender, EventArgs e)
        {
            this.Dispose();
        }

        private void picShowNew_Click(object sender, EventArgs e)
        {
            if(picShowNew.Visible == true)
            {
                picShowNew.Visible = false;
                picHideNew.Visible = true;
                txtNewPW.UseSystemPasswordChar = false;
            }
        }

        private void picHideNew_Click(object sender, EventArgs e)
        {
            if(picHideNew.Visible == true)
            {
                picHideNew.Visible = false;
                picShowNew.Visible = true;
                txtNewPW.UseSystemPasswordChar = true;
            }
        }

        private void picShowCF_Click(object sender, EventArgs e)
        {
            if (picShowCF.Visible == true)
            {
                picShowCF.Visible = false;
                picHideCF.Visible = true;
                txtConfirmPW.UseSystemPasswordChar = false;
            }
        }

        private void picHideCF_Click(object sender, EventArgs e)
        {
            if (picHideCF.Visible == true)
            {
                picHideCF.Visible = false;
                picShowCF.Visible = true;
                txtConfirmPW.UseSystemPasswordChar = true;
            }
        }
    }
}
