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

namespace PhoneStoreManagement.UserControls
{
    public partial class UC_Import : UserControl
    {
        private bool clickBtnImportNewPhone = false;
        public UC_Import()
        {
            InitializeComponent();
            SetCBB_Brand(cbbBrand);
            SetCBB_Brand(cbbImportBrand);
            SetCBB_Category();
            SetCBB_PhoneType(cbbPhoneType);
            SetCBB_PhoneType(cbbImportPhoneType);
            SetListProduct();
        }
        private void SetListProduct()
        {
            flowLayoutPanel1.Controls.Clear();
            foreach (UC_Product i in BLL_UCListProduct.Instance.ListUC(((DTO_Brand)cbbBrand.SelectedItem), (DTO_PhoneType)cbbPhoneType.SelectedItem, txtSearchPhone.Text))
            {
                flowLayoutPanel1.Controls.Add(i);
            }
        }
        private void SetCBB_Brand(ComboBox cbb)
        {
            cbb.Items.AddRange(BLL_PhonesAdmin.Instance.GetCBBBrand().ToArray());
            cbb.SelectedIndex = 0;
        }
        private void SetCBB_Category()
        {
            cbbCategory.Items.Clear();
            cbbCategory.Items.AddRange(BLL_Import.Instance.getCBBCategory().ToArray());
            cbbCategory.SelectedIndex = 0;
        }
        private void SetCBB_PhoneType(ComboBox cbb)
        {
            cbb.Items.Clear();
            cbb.Items.AddRange(BLL_Import.Instance.getCBBCPhoneType().ToArray());
            cbb.SelectedIndex = 0;
        }

        private void btnSearch_Click(object sender, EventArgs e)
        {
            flowLayoutPanel1.Controls.Clear();
            SetListProduct();
        }

        private void btnImportNewPhone_Click(object sender, EventArgs e)
        {
            clickBtnImportNewPhone = true;
            lbROM.Visible = true;
            lbRAM.Visible = true;
            lbBrand.Visible = true;
            lbPhoneType.Visible = true;
            lbOperating.Visible = true;
            RAM.Visible = true;
            ROM.Visible = true;
            cbbImportBrand.Visible = true;
            cbbImportPhoneType.Visible = true;
            txtOperating.Visible = true;
            cbbPhoneType.Visible = true;
            lbOperating.Visible = true;
            txtOperating.Visible = true;
            lbPicture.Visible = true;
            Picture.Visible = true;
            lbBattery.Visible = true;
            Battery.Visible = true;
            lbCamera.Visible = true;
            Camera.Visible = true;
            lbScreen.Visible = true;
            ScreenSize.Visible = true;
            lbIDPhone.Visible = false;
            IDPhone.Visible = false;
        }

        private void Update_Click(object sender, EventArgs e)
        {
            DialogResult result = MessageBox.Show("Bạn muốn cập nhật sản phẩm này không?", "Cập nhật sản phẩm", MessageBoxButtons.OKCancel);
            if (result == DialogResult.Cancel) return;
            try
            {
                if (clickBtnImportNewPhone == false)
                {
                    Phone phone = BLL_Import.Instance.getPhone(IDPhone.Text, txtImportPhone.Text);
                    if (phone == null)
                    {
                        MessageBox.Show("Không tìm thấy điện thoại này! Hãy nhập lại", "Nhập hàng"); return;
                    }
                    InventoryManagement inventory = BLL_Import.Instance.GetInventoryManagementByPhone(phone);
                    inventory.Quantity += Convert.ToInt32(Quantity.Text);
                    phone.Price = Convert.ToInt32(UnitPrice.Text);
                    BLL_Import.Instance.addOrupdateInventoryExist(inventory);
                    BLL_PhonesAdmin.Instance.addorupdatePhone(phone);
                    Account account = BLL_Login.Instance.GetAccount();
                    ImportManagement import = new ImportManagement
                    {
                        IDEmployee = account.IDEmployee,
                        IDPhone = phone.IDPhone,
                        ImportDate = TimeImport.Value,
                        Quantity = Convert.ToInt32(Quantity.Text),
                        UnitPrice = Convert.ToInt32(UnitPrice.Text),
                    };
                    BLL_Import.Instance.addImport(import);
                }
                else
                {
                    if(Picture.Image == null)
                    {
                        MessageBox.Show("Thiếu dữ liệu", "Cập nhật sản phẩm"); return;
                    }
                    MemoryStream ms = new MemoryStream();
                    Picture.Image.Save(ms, ImageFormat.Png);
                    Phone phone = new Phone()
                    {
                        NamePhone = txtImportPhone.Text,
                        RAM = Convert.ToInt32(RAM.Text),
                        ROM = Convert.ToInt32(ROM.Text),
                        CameraResolution = Convert.ToInt32(Camera.Text),
                        ScreenSize = ScreenSize.Text,
                        BateryCapacity = Convert.ToInt32(Battery.Text),
                        Operating = txtOperating.Text,
                        IDBrand = ((DTO_Brand)cbbImportBrand.SelectedItem).IDBrand,
                        IDPhoneType = ((DTO_PhoneType)cbbImportPhoneType.SelectedItem).IDPhoneType,
                        Price = Convert.ToInt32(UnitPrice.Text),
                        Picture = ms.ToArray()
                    };
                    BLL_PhonesAdmin.Instance.addorupdatePhone(phone);
                    Phone findPhone = BLL_PhonesAdmin.Instance.findPhone(phone.IDPhone);
                    BLL_PhonesAdmin.Instance.addInventory(findPhone);
                    //InventoryManagement inventory = new InventoryManagement
                    //{
                    //    IDPhone = findPhone.IDPhone,
                    //    Quantity = Convert.ToInt32(Quantity.Text),
                    //};
                    //BLL_Import.Instance.addOrupdateInventory(inventory);
                    BLL_Import.Instance.updateInventory(findPhone, Convert.ToInt32(Quantity.Text));
                    Account account = BLL_Login.Instance.GetAccount();
                    ImportManagement import = new ImportManagement
                    {
                        IDEmployee = account.IDEmployee,
                        IDPhone = phone.IDPhone,
                        ImportDate = TimeImport.Value,
                        Quantity = Convert.ToInt32(Quantity.Text),
                        UnitPrice = Convert.ToInt32(UnitPrice.Text),
                    };
                    BLL_Import.Instance.addImport(import);
                }
                MessageBox.Show("Nhập hàng thành công!", "Nhập hàng");
                SetListProduct();
            }
            catch(Exception ex)
            {
                MessageBox.Show("Nhập không đúng dữ liệu", "Cập nhật sản phẩm"); 
            }
            //có thể fix thêm là reload lại
        }

        private void btnChoosePicture_Click(object sender, EventArgs e)
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

        private void btnCancePicture_Click(object sender, EventArgs e)
        {
            if (Picture.Image == null) return;
            DialogResult result = MessageBox.Show("Bạn muốn xóa này ảnh không?", "Xóa ảnh", MessageBoxButtons.OKCancel);
            if (result == DialogResult.OK)
            {
                Picture.Image = null;
            }
        }
    }
}
