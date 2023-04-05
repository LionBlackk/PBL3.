using PhoneStoreManagement.BLL;
using PhoneStoreManagement.DAL;
using PhoneStoreManagement.DTO;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace PhoneStoreManagement
{
    public partial class FormAdd_EditAccount : Form
    {
        public int id;
        public FormAdd_EditAccount(int idAccount = 0)
        {
            InitializeComponent();
            id = idAccount;
        }
        public delegate void Mydel(string Role, string Name);
        public Mydel d { get; set; }
        public void setData()
        {
            Account acc = BLL_AccountsAdmin.Instance.getAccByID(id);
            if (acc != null)
            {
                lbIdAccount.Visible = true;
                txtIdAccount.Visible = true;
                txtIdAccount.Text = acc.IDAccount.ToString();
                txtIdAccount.Enabled = false;
                txtUserName.Text = acc.UserName;
                lbPassWord.Visible = false;
                txtPassWord.Text = acc.Password;
                txtPassWord.Visible = false;
                picHidePW.Visible = false;
                picShowPW.Visible = false;
                txtEmail.Text = acc.Email;
                cbbRole.Items.Clear();
                cbbRole.Items.AddRange(BLL_AccountsAdmin.Instance.setCBBRole().ToArray());
                cbbRole.SelectedIndex = acc.IDRole - 100;
                txtEmployee.Text = acc.IDEmployee.ToString();
            }
            else
            {
                lbIdAccount.Visible = false;
                txtIdAccount.Visible = false;
                cbbRole.Items.Clear();
                cbbRole.Items.AddRange(BLL_AccountsAdmin.Instance.setCBBRole().ToArray());
            }
        }
        public bool checkFormatEmail(string email)
        {
            Regex reg = new Regex(@"[^@]{2,64}@[^.]{2,253}\.[0-9a-z-.]{2,63}");
            return reg.IsMatch(email);
        }

        private void btnOk_Click(object sender, EventArgs e)
        {
            if (txtUserName.Text.Trim() == "" || txtEmail.Text.Trim() == "" || txtEmployee.Text.Trim() == "")
            {
                MessageBox.Show("Vui lòng nhập đầy đủ thông tin", "Error");
            }
            else if (!checkFormatEmail(txtEmail.Text.Trim()))
            {
                MessageBox.Show("Vui lòng nhập đúng định dạng của email", "Warning");
            }
            else if (!BLL_AccountsAdmin.Instance.checkIdEmployee(Convert.ToInt32(txtEmployee.Text)))
            {
                MessageBox.Show("Không có nhân viên này", "Error");
            }
            else
            {
                DTO_Role item = cbbRole.SelectedItem as DTO_Role;
                try
                {
                    Account acc = new Account()
                    {
                        IDAccount = id,
                        UserName = txtUserName.Text.Trim(),
                        Password = txtPassWord.Text.Trim(),
                        Email = txtEmail.Text.Trim(),
                        IDRole = Convert.ToInt32(item.IDRole),
                        IDEmployee = Convert.ToInt32(txtEmployee.Text),
                    };
                    BLL_AccountsAdmin.Instance.AddorUpdateAccount(acc);
                    d("ALL", "");
                    Dispose();
                }
                catch (FormatException e1)
                {
                    MessageBox.Show("Lỗi thông tin, vui lòng nhập đúng định dạng thông tin", "Error");
                }
            }
        }

        private void btnCancel_Click(object sender, EventArgs e)
        {
            Dispose();
        }

        private void picHidePW_Click(object sender, EventArgs e)
        {
            if (picHidePW.Visible == true)
            {
                txtPassWord.UseSystemPasswordChar = true;
                picHidePW.Visible = false;
                picShowPW.Visible = true;
            }
        }

        private void picShowPW_Click(object sender, EventArgs e)
        {
            if (picShowPW.Visible == true)
            {
                txtPassWord.UseSystemPasswordChar = false;
                picHidePW.Visible = true;
                picShowPW.Visible = false;
            }
        }

        private void btnResetPassWord_Click(object sender, EventArgs e)
        {
            DTO_Role item = cbbRole.SelectedItem as DTO_Role;
            Account acc = new Account()
            {
                IDAccount = id,
                UserName = txtUserName.Text.Trim(),
                Password = "",
                Email = txtEmail.Text.Trim(),
                IDRole = Convert.ToInt32(item.IDRole),
                IDEmployee = Convert.ToInt32(txtEmployee.Text),
            };
            BLL_AccountsAdmin.Instance.AddorUpdateAccount(acc);
            d("ALL", "");
            Dispose();
        }
    }
}
