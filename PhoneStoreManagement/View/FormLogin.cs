using System;
using System.Windows.Forms;
using PhoneStoreManagement.BLL;

namespace PhoneStoreManagement
{
    public partial class FormLogin : Form
    {
        public FormLogin()
        {
            InitializeComponent();
        }
        private void butLogin_Click(object sender, EventArgs e)
        {
            BLL_Login.Instance.SetInfoAccount(userName.Text, passWord.Text);
            if (BLL_Login.Instance.CheckLogin())
            {
                this.Hide();
            }
        }

        private void butRegister_Click(object sender, EventArgs e)
        {
            FormRegister formRegister = new FormRegister();
            formRegister.ShowDialog();
        }

        private void btnOut_Click(object sender, EventArgs e)
        {
            DialogResult result = MessageBox.Show("Bạn có muốn thoát khỏi chương trình không?", "Thoát", MessageBoxButtons.OKCancel);
            if(result == DialogResult.OK)
            {
                this.Dispose();
            }
        }

        private void picShow_Click(object sender, EventArgs e)
        {
            if(picShow.Visible == true)
            {
                picShow.Visible = false;
                picHide.Visible = true;
                passWord.UseSystemPasswordChar = false;
            }
        }

        private void picHide_Click(object sender, EventArgs e)
        {
            if (picHide.Visible == true)
            {
                picHide.Visible = false;
                picShow.Visible = true;
                passWord.UseSystemPasswordChar = true;
            }
        }

        private void forgotPW_Click(object sender, EventArgs e)
        {
            FormForgotPW formForgotPW = new FormForgotPW();
            formForgotPW.ShowDialog();
        }
    }
}
