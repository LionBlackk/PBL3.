using PhoneStoreManagement.DAL;
using PhoneStoreManagement.DTO;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;

namespace PhoneStoreManagement.BLL
{
    public class BLL_DetailProduct
    {
        private static BLL_DetailProduct _Instance;
        private BLL_DetailProduct()
        {

        }

        public static BLL_DetailProduct Instance 
        {
            get
            {
                if(_Instance == null)
                {
                    _Instance = new BLL_DetailProduct();    
                }
                return _Instance;
            }
            private set { }
        }
        public void Buy(string IDPhone,string Quantity)
        {
            DTO_PhoneChose phoneChose = new DTO_PhoneChose();
            using (var db = new DBManagement())
            {
                Phone phone = db.Phones.SingleOrDefault(p => p.IDPhone.ToString().Equals(IDPhone));
                InventoryManagement inventory = phone.InventoryManagements.SingleOrDefault(p => p.IDPhone == phone.IDPhone);
                if (inventory.Quantity == 0)
                {
                    MessageBox.Show("Sản phẩm hết hàng", "Mua hàng"); return;
                }
                else if (inventory.Quantity < Convert.ToInt32(Quantity))
                {
                    MessageBox.Show("Số lượng sản phẩm trong kho không đủ", "Mua hàng"); return;
                }
                phoneChose.IDPhone = phone.IDPhone;
                phoneChose.NamePhone = phone.NamePhone;
                phoneChose.Quantity = Convert.ToInt32(Quantity);
                phoneChose.Price = (int)phone.Price;
                //inventory.Quantity -= Convert.ToInt32(Quantity);
                //db.SaveChanges();
            }
            BLL_ListPhoneChose.Instance.AddPhoneChose(phoneChose);
        }
    }
}
