using PhoneStoreManagement.BLL;
using PhoneStoreManagement.DAL;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Drawing.Imaging;
using System.IO;
using System.Linq;
using System.Security.Cryptography;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Forms;
using MessageBox = System.Windows.Forms.MessageBox;

namespace PhoneStoreManagement.UserControls
{
    public partial class UC_Settings : UserControl
    {
        public UC_Settings()
        {
            InitializeComponent();
        }
        public void SetInfoUser()
        {
            using (var db = new DBManagement())
            {
                Account account = BLL_Login.Instance.GetAccount();
                Role role = db.Roles.SingleOrDefault(p => p.IDRole == account.IDRole);
                Employee employee = db.Employees.SingleOrDefault(p => p.IDEmployee == account.IDEmployee);
                IDEmployee.Text = account.IDEmployee.ToString();
                NameRole.Text = role.NameRole;
                NameEmployee.Text = employee?.NameEmployee;
                BirthDay.Value = (employee?.BirthDay) ?? DateTime.Now;
                rdMale.Checked = employee?.Gender == true;
                rdFemale.Checked = employee?.Gender == false;
                Phone.Text = employee?.Phone;
                Email.Text = account.Email;
                if (employee?.Picture != null)
                {
                    MemoryStream ms = new MemoryStream(employee.Picture);
                    Picture.Image = Image.FromStream(ms);
                }
            }
        }

        private void btnChoose_Click(object sender, EventArgs e)
        {
            DialogResult result = openFileDialog1.ShowDialog();

            if (result == DialogResult.OK)
            {
                try
                {
                    Image img = Image.FromFile(openFileDialog1.FileName);
                    Picture.Image = img;
                }
                catch (Exception)
                {
                    MessageBox.Show("Chọn ảnh bị lỗi rồi!", "Error");
                }
            }
        }

        private void btnConfirm_Click(object sender, EventArgs e)
        {
            DialogResult result = MessageBox.Show("Bạn muốn thay đổi thông tin không?", "Thay đổi thông tin", MessageBoxButtons.OKCancel);
            if (result == DialogResult.OK)
            {
                BLL_UCSetting.Instance.ConfirmSetting(IDEmployee.Text, NameEmployee.Text, BirthDay.Value, rdMale.Checked, Phone.Text, Email.Text, Picture.Image);
                MessageBox.Show("Đã thay đổi thông tin thành công", "Thay đổi thông tin");
            }
        }

        private void btnCancelImage_Click(object sender, EventArgs e)
        {
            if (Picture.Image == null) return;
            DialogResult result = MessageBox.Show("Bạn muốn xóa này ảnh không?", "Xóa ảnh", MessageBoxButtons.OKCancel);
            if (result == DialogResult.OK)
            {
                Picture.Image = null;
                MessageBox.Show("Đã xóa ảnh thành công", "Xóa ảnh");
            }
        }

        private void btnChangePassword_Click(object sender, EventArgs e)
        {
            FormChangePW f = new FormChangePW();
            f.ShowDialog();
        }
    }
}
