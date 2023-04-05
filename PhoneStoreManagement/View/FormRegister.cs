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
using PhoneStoreManagement.DTO;
using PhoneStoreManagement.BLL;



namespace PhoneStoreManagement
{
    public partial class FormRegister : Form
    {
        public FormRegister()
        {
            InitializeComponent();
            SetUI();
            SetCBBRole();
        }
        private void SetUI()
        {
            lbCheckAdmin.Visible = false;
            txtCheckAdmin.Visible = false;
            picHideAdmin.Visible = false;
            picShowAdmin.Visible = false;
        }
        private void SetCBBRole()
        {
            DBManagement db = new DBManagement();
            cbbRole.Items.Clear();
            List<DTO_Role> listRole = new List<DTO_Role>();
            foreach (Role i in db.Roles.Select(p => p))
            {
                listRole.Add(new DTO_Role { IDRole = i.IDRole, NameRole = i.NameRole });
            }
            cbbRole.Items.AddRange(listRole.ToArray());
        }



        private void btnCancel_Click(object sender, EventArgs e)
        {
            this.Dispose();
        }



        private void btnConfirm_Click(object sender, EventArgs e)
        {
            if (BLL_Login.Instance.Register(userName.Text, passWord.Text, confirmPW.Text, Email.Text, ((DTO_Role)cbbRole.SelectedItem), IDEmployee.Text, txtCheckAdmin.Text))
            {
                MessageBox.Show("Đăng kí thành công!", "Đăng kí");
                this.Hide();
            }
        }



        private void picShowPW_Click(object sender, EventArgs e)
        {
            if (picShowPW.Visible == true)
            {
                passWord.UseSystemPasswordChar = false;
                picHidePW.Visible = true;
                picShowPW.Visible = false;
            }
        }



        private void picHidePW_Click(object sender, EventArgs e)
        {
            if (picHidePW.Visible == true)
            {
                passWord.UseSystemPasswordChar = true;
                picHidePW.Visible = false;
                picShowPW.Visible = true;
            }
        }



        private void picShowCFPW_Click(object sender, EventArgs e)
        {
            if (picShowCFPW.Visible == true)
            {
                confirmPW.UseSystemPasswordChar = false;
                picHideCFPW.Visible = true;
                picShowCFPW.Visible = false;
            }
        }



        private void picHideCFPW_Click(object sender, EventArgs e)
        {
            if (picHideCFPW.Visible == true)
            {
                confirmPW.UseSystemPasswordChar = true;
                picHideCFPW.Visible = false;
                picShowCFPW.Visible = true;
            }
        }



        private void cbbRole_SelectedIndexChanged(object sender, EventArgs e)
        {
            DTO_Role role = (DTO_Role)cbbRole.SelectedItem;
            if (role.NameRole == "Admin")
            {
                lbCheckAdmin.Visible = true;
                txtCheckAdmin.Visible = true;
                picHideAdmin.Visible = true;
                picShowAdmin.Visible = true;
            }
            else
            {
                lbCheckAdmin.Visible = false;
                txtCheckAdmin.Visible = false;
            }
        }



        private void picHideAdmin_Click(object sender, EventArgs e)
        {
            if (picHideAdmin.Visible == true)
            {
                txtCheckAdmin.UseSystemPasswordChar = true;
                picHideAdmin.Visible = false;
                picShowAdmin.Visible = true;
            }
        }



        private void picShowAdmin_Click(object sender, EventArgs e)
        {
            if (picShowAdmin.Visible == true)
            {
                txtCheckAdmin.UseSystemPasswordChar = false;
                picHideAdmin.Visible = true;
                picShowAdmin.Visible = false;
            }
        }
    }
}