using PhoneStoreManagement.DAL;
using PhoneStoreManagement.DTO;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PhoneStoreManagement.BLL
{
    public class BLL_Import
    {
        private static BLL_Import _Instance;
        private BLL_Import()
        {

        }

        public static BLL_Import Instance 
        { 
            get
            {
                if(_Instance == null)
                {
                    _Instance = new BLL_Import();    
                }
                return _Instance;
            }
            private set { }
        }
        public List<DTO_Category> getCBBCategory()
        {
            using (var db = new DBManagement())
            {
                List<DTO_Category> list = new List<DTO_Category>();
                list.Add(new DTO_Category { IDCategory = 0, NameCategory = "ALL" });
                foreach (Category i in db.Categories)
                {
                    list.Add(new DTO_Category { IDCategory = i.IDCategory, NameCategory = i.NameCategory });
                }
                return list;
            }
        }
        public List<DTO_PhoneType> getCBBCPhoneType()
        {
            using (var db = new DBManagement())
            {
                List<DTO_PhoneType> list = new List<DTO_PhoneType>();
                list.Add(new DTO_PhoneType { IDPhoneType = 0, PhoneTypeName = "ALL" });
                foreach (PhoneType i in db.PhoneTypes)
                {
                    list.Add(new DTO_PhoneType { IDPhoneType = i.IDPhoneType, PhoneTypeName = i.PhoneTypeName, IDCategory = (int)i.IDCategory });
                }
                return list;
            }
        }
        public void addImport(ImportManagement i)
        {
            using (DBManagement db = new DBManagement())
            {
                db.ImportManagements.Add(i);
                db.SaveChanges();
            }
        }
        public void addOrupdateInventoryExist(InventoryManagement inventory)
        {
            using (DBManagement db = new DBManagement())
            {
                var l1 = db.InventoryManagements.Where(p => p.IDPhone == inventory.IDPhone).FirstOrDefault();
                if (l1 != null)
                {
                    l1.Quantity = inventory.Quantity;
                    db.SaveChanges();
                }
                else
                {
                    db.InventoryManagements.Add(inventory);
                    db.SaveChanges();
                }
            }
            
        }
        public void updateInventory(Phone phone, int Quantity)
        {
            using (DBManagement db = new DBManagement())
            {
                InventoryManagement inventory = db.InventoryManagements.SingleOrDefault(p => p.IDPhone == phone.IDPhone);
                if (inventory != null)
                {
                    inventory.Quantity += Quantity;
                }
                db.SaveChanges();
            }
        }    
        public Phone getPhone(string IDPhone, string NamePhone)
        {
            using (var db = new DBManagement())
            {
                return db.Phones.SingleOrDefault(p => p.IDPhone.ToString().Equals(IDPhone) && p.NamePhone.Equals(NamePhone));
            }
        }
        public InventoryManagement GetInventoryManagementByPhone(Phone phone)
        {
            using (var db = new DBManagement())
            {
                return db.InventoryManagements.SingleOrDefault(p => p.IDPhone == phone.IDPhone);
            }
        }
    }
}
