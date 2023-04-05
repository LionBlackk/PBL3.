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
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace PhoneStoreManagement
{
    public partial class FormAdd_EditEmployee : Form
    {
        private int id;
        public FormAdd_EditEmployee(int idEmployee = 0)
        {
            InitializeComponent();
            id = idEmployee;
        }
        public delegate void Mydel(string Role, string Name);
        public Mydel d { get; set; }
        public void setData()
        {
            Employee emp = BLL_EmployeesAdmin.Instance.getEmpByID(id);
            if (emp != null)
            {
                lbIdEmployee.Visible = true;
                txtIdEmp.Visible = true;
                txtIdEmp.Text = emp.IDEmployee.ToString();
                txtIdEmp.Enabled = false;
                txtFullName.Text = emp.NameEmployee;
                txtAddress.Text = emp.Address;
                txtPhone.Text = emp.Phone;
                txtEmail.Text = emp.Email;
                DTBirthday.Value = (DateTime)emp.BirthDay;
                if ((bool)emp.Gender)
                {
                    rbMale.Checked = true;
                    rbFemale.Checked = false;
                }
                else
                {
                    rbMale.Checked = false;
                    rbFemale.Checked = true;
                }
                BLL_EmployeesAdmin.Instance.setPicture(emp, pictureEmployee);
            }
            else
            {
                lbIdEmployee.Visible = false;
                txtIdEmp.Visible = false;
                rbMale.Checked = true;
            }
        }

        private void btnCancel_Click(object sender, EventArgs e)
        {
            Dispose();
        }
        public bool checkFormatEmail(string email)
        {
            Regex reg = new Regex(@"[^@]{2,64}@[^.]{2,253}\.[0-9a-z-.]{2,63}");
            return reg.IsMatch(email);
        }
        private void btnOk_Click(object sender, EventArgs e)
        {
            if (txtFullName.Text.Trim() == "" || txtAddress.Text.Trim() == "" || txtEmail.Text.Trim() == "" || txtPhone.Text.Trim() == "")
            {
                MessageBox.Show("Vui lòng nhập đầy đủ thông tin", "Error");
            }
            else if (pictureEmployee.Image == null)
            {
                MessageBox.Show("Vui lòng chọn hình ảnh", "Error");
            }
            else if (!checkFormatEmail(txtEmail.Text.Trim()))
            {
                MessageBox.Show("Vui lòng nhập đúng định dạng của email", "Warning");
            }
            else
            {
                bool gender = rbMale.Checked ? true : false;
                MemoryStream ms = new MemoryStream();
                pictureEmployee.Image.Save(ms, ImageFormat.Png);
                try
                {
                    Employee employee = new Employee()
                    {
                        IDEmployee = id,
                        NameEmployee = txtFullName.Text.Trim(),
                        Email = txtEmail.Text.Trim(),
                        Phone = txtPhone.Text.Trim(),
                        Address = txtAddress.Text.Trim(),
                        BirthDay = DTBirthday.Value,
                        Gender = gender,
                        Picture = ms.ToArray()
                    };
                    BLL_EmployeesAdmin.Instance.addorupdateEmployee(employee);
                    d("ALL", "");
                    Dispose();
                }
                catch (FormatException e1)
                {
                    MessageBox.Show("Lỗi thông tin, vui lòng nhập đúng định dạng thông tin", "Error");
                }
            }
        }

        private void btnChoose_Click(object sender, EventArgs e)
        {
            DialogResult result = openFileDialog1.ShowDialog();
            if (result == DialogResult.OK)
            {
                Image img = Image.FromFile(openFileDialog1.FileName);
                pictureEmployee.Image = img;
            }
            else
            {
                MessageBox.Show("Chọn hình ảnh thất bại", "Error");
            }
        }
    }
}
