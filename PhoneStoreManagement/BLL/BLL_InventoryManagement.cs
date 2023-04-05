using PhoneStoreManagement.DAL;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using PhoneStoreManagement.DTO;
using PagedList;

namespace PhoneStoreManagement.BLL
{
    class BLL_InventoryManagement
    {
        private static BLL_InventoryManagement _Instance;
        public static BLL_InventoryManagement Instance
        {
            get
            {
                if (_Instance == null)
                {
                    _Instance = new BLL_InventoryManagement();
                }
                return _Instance;
            }
            private set { }
        }
        public async Task<IPagedList<DTO_Inventory>> getListInventory(string name, int pageNumber = 1, int pagesize = 15)
        {
            return await Task.Factory.StartNew(() =>
            {
                using (DBManagement db = new DBManagement())
                {
                    List<DTO_Inventory> list = new List<DTO_Inventory>();
                    list = db.InventoryManagements.Where(p => p.Phone.NamePhone.Contains(name))
                        .Select(p => new DTO_Inventory
                        {
                            IDInventory = p.IDInvenManagement,
                            NamePhone = p.Phone.NamePhone,
                            Quantity = p.Quantity,
                        })
                        .ToList();
                    return list.ToPagedList(pageNumber, pagesize);
                }
            });
        }
        public void LoadQuantity(Order_ order, DBManagement db = null)
        {
            foreach (OrderDetail i in order.OrderDetails)
            {
                InventoryManagement inventory = db.InventoryManagements.SingleOrDefault(p => p.IDPhone == i.IDPhone);
                inventory.Quantity += i.Quantity;
            }
        }
        public void SubQuantity(Order_ order, DBManagement db = null)
        {
            foreach (OrderDetail i in order.OrderDetails)
            {
                InventoryManagement inventory = db.InventoryManagements.SingleOrDefault(p => p.IDPhone == i.IDPhone);
                inventory.Quantity -= i.Quantity;
            }
        }
    }
}
