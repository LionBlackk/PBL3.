using PhoneStoreManagement.BLL;
using PhoneStoreManagement.DAL;
using PhoneStoreManagement.DTO;
using PhoneStoreManagement.UserControls;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace PhoneStoreManagement
{
    public partial class FormDetailProduct : Form
    {
        public FormDetailProduct()
        {
            InitializeComponent();
        }
        public void SetInfo(Phone phone)
        {
            using (var db = new DBManagement())
            {
                NameBrand.Text = phone.Brand.NameBrand;
                NamePhone.Text = phone.NamePhone;
                IDPhone.Text = phone.IDPhone.ToString();
                RAM.Text = phone.RAM.ToString();
                Operating.Text = phone.Operating;
                BateryCapacity.Text = phone.BateryCapacity.ToString();
                Remain.Text = phone.InventoryManagements.SingleOrDefault(p => p.IDPhone == phone.IDPhone).Quantity.ToString();
                Quantity.Text = "1";
                MemoryStream ms = new MemoryStream(phone.Picture);
                Picture.Image = Image.FromStream(ms);
            }
        }
        private void btnCancel_Click(object sender, EventArgs e)
        {
            this.Dispose();
        }

        private void btnBuy_Click(object sender, EventArgs e)
        {
            BLL_DetailProduct.Instance.Buy(IDPhone.Text, Quantity.Text);
            this.Close();
        }
    }
}
