using BookShopManagement.UserControls;
using PhoneStoreManagement.BLL;
using PhoneStoreManagement.DAL;
using PhoneStoreManagement.DTO;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Security.Cryptography;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;


namespace PhoneStoreManagement.UserControls
{
    public partial class UC_Product : UserControl
    {
        public UC_Product()
        {
            InitializeComponent();
        }
        private void UC_Product_Click(object sender, EventArgs e)
        {
            using (var db = new DBManagement())
            {
                Phone phone = db.Phones.SingleOrDefault(p => p.IDPhone.ToString().Equals(IDPhone.Text));
                FormDetailProduct detailPhone = new FormDetailProduct();
                detailPhone.SetInfo(phone);
                detailPhone.ShowDialog();
            }
        }
    }
}
