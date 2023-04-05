using PhoneStoreManagement.BLL;
using PhoneStoreManagement.DAL;
using PhoneStoreManagement.DTO;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Drawing.Imaging;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace PhoneStoreManagement
{
    public partial class FormAdd_EditPhone : Form
    {
        int id;
        public FormAdd_EditPhone(int idPhone = 0)
        {
            InitializeComponent();
            id = idPhone;
            setCBBBrand();
            setCBBPhoneType();
        }
        public delegate void Mydel(string Brand, string Name);
        public Mydel d { get; set; }
        public void setData()
        {
            Phone Phone = BLL_PhonesAdmin.Instance.getPhoneByID(id);
            if (Phone != null)
            {
                lbIdPhone.Visible = true;
                txtIdPhone.Visible = true;
                txtIdPhone.Text = Phone.IDPhone.ToString();
                txtIdPhone.Enabled = false;
                txtNamePhone.Text = Phone.NamePhone;
                txtRAM.Text = Phone.RAM.ToString();
                txtROM.Text = Phone.ROM.ToString();
                txtScreenSize.Text = Phone.ScreenSize.ToString();
                txtCamera.Text = Phone.CameraResolution.ToString();
                txtCapacity.Text = Phone.BateryCapacity.ToString();
                txtPrice.Text = Phone.Price.ToString();
                txtOperating.Text = Phone.Operating.ToString();
                BLL_PhonesAdmin.Instance.setPicture(Phone, picturePhone);
                cbbBrand.Text = Phone.IDBrand;
                cbbPhoneType.SelectedIndex = Convert.ToInt32(Phone.IDPhoneType - 1);
            }
            else
            {
                lbIdPhone.Visible = false;
                txtIdPhone.Visible = false;
            }
        }
        public void setCBBBrand()
        {
            cbbBrand.Items.Clear();
            cbbBrand.Items.AddRange(BLL_PhonesAdmin.Instance.setCBBBrand().ToArray());
        }
        public void setCBBPhoneType()
        {
            cbbPhoneType.Items.Clear();
            cbbPhoneType.Items.AddRange(BLL_PhonesAdmin.Instance.setCBBPhoneType().ToArray());
        }

        private void btnChoose_Click(object sender, EventArgs e)
        {
            DialogResult result = openFileDialog1.ShowDialog();
            if (result == DialogResult.OK)
            {
                Image img = Image.FromFile(openFileDialog1.FileName);
                picturePhone.Image = img;
            }
            else
            {
                MessageBox.Show("Chọn hình ảnh thất bại", "Error");
            }
        }
        private void btnCancel_Click(object sender, EventArgs e)
        {
            Dispose();
        }

        private void btnOk_Click(object sender, EventArgs e)
        {
            if (txtNamePhone.Text.Trim() == "" || txtRAM.Text.Trim() == "" || txtROM.Text.Trim() == ""
                || txtCamera.Text.Trim() == "" || txtCapacity.Text.Trim() == "" || txtScreenSize.Text.Trim() == ""
                || txtPrice.Text.Trim() == "" || txtOperating.Text.Trim() == "")
            {
                MessageBox.Show("Vui lòng nhập đầy đủ thông tin", "Error");
            }
            else if (picturePhone.Image == null)
            {
                MessageBox.Show("Vui lòng chọn hình ảnh", "Error");
            }
            else
            {
                MemoryStream ms = new MemoryStream();
                picturePhone.Image.Save(ms, ImageFormat.Png);
                DTO_Brand itemBrand = cbbBrand.SelectedItem as DTO_Brand;
                DTO_PhoneType itemPhoneType = cbbPhoneType.SelectedItem as DTO_PhoneType;
                try
                {
                    Phone phone = new Phone()
                    {
                        IDPhone = id,
                        NamePhone = txtNamePhone.Text.Trim(),
                        RAM = Convert.ToInt32(txtRAM.Text.Trim()),
                        ROM = Convert.ToInt32(txtROM.Text.Trim()),
                        CameraResolution = Convert.ToInt32(txtCamera.Text.Trim()),
                        ScreenSize = txtScreenSize.Text.Trim(),
                        BateryCapacity = Convert.ToInt32(txtCapacity.Text.Trim()),
                        Price = Convert.ToInt32(txtPrice.Text.Trim()),
                        Operating = txtOperating.Text.Trim(),
                        IDBrand = itemBrand.IDBrand,
                        IDPhoneType = Convert.ToInt32(itemPhoneType.IDPhoneType),
                        Picture = ms.ToArray()
                    };
                    BLL_PhonesAdmin.Instance.addorupdatePhone(phone);
                    d("ALL", "");
                    Dispose();
                }
                catch (FormatException e1)
                {
                    MessageBox.Show("Lỗi thông tin, vui lòng nhập đúng định dạng thông tin", "Error");
                }

            }
        }
    }
}
