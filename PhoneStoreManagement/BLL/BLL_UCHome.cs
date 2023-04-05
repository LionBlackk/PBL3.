using PhoneStoreManagement.DAL;
using PhoneStoreManagement.DTO;
using System.Collections.Generic;
using System.Linq;
using System.Windows.Forms;

namespace PhoneStoreManagement.BLL
{
    public class BLL_UCHome
    {
        private static BLL_UCHome _Instance;
        private BLL_UCHome()
        {

        }

        public static BLL_UCHome Instance
        {
            get
            {
                if (_Instance == null)
                {
                    _Instance = new BLL_UCHome();
                }
                return _Instance;
            }
            private set { }
        }
        public void SetCBBBrand(ComboBox cbbBrand)
        {
            List<DTO_Brand> list = new List<DTO_Brand>();
            cbbBrand.Items.Add(new DTO_Brand { IDBrand = "ALL", NameBrand = "ALL" });
            cbbBrand.SelectedIndex = 0;
            using (var db = new DBManagement())
            {
                foreach (Brand i in db.Brands)
                {
                    list.Add(new DTO_Brand { IDBrand = i.IDBrand, NameBrand = i.NameBrand });
                }
                cbbBrand.Items.AddRange(list.ToArray());
            }
        }
        public void SetCBBCategory(ComboBox cbbCategory)
        {
            List<DTO_Category> list = new List<DTO_Category>();
            cbbCategory.Items.Clear();
            cbbCategory.Items.Add(new DTO_Category { IDCategory = 0, NameCategory = "ALL" });
            cbbCategory.SelectedIndex = 0;
            using (var db = new DBManagement())
            {
                foreach (Category i in db.Categories)
                {
                    list.Add(new DTO_Category { IDCategory = i.IDCategory, NameCategory = i.NameCategory });
                }
                cbbCategory.Items.AddRange(list.ToArray());
            }
        }
        public void SetCBBPhoneType(ComboBox cbbCategory, ComboBox cbbPhoneType, string idCategory)
        {
            List<DTO_PhoneType> list = new List<DTO_PhoneType>();
            cbbPhoneType.Items.Clear();
            cbbPhoneType.Items.Add(new DTO_PhoneType { IDPhoneType = 0, PhoneTypeName = "ALL" });
            cbbPhoneType.SelectedIndex = 0;
            using (var db = new DBManagement())
            {
                if (idCategory != null)
                {
                    foreach (PhoneType i in db.PhoneTypes.Where(p => p.IDCategory == ((DTO_Category)cbbCategory.SelectedItem).IDCategory).ToList())
                    {
                        list.Add(new DTO_PhoneType { IDPhoneType = i.IDPhoneType, PhoneTypeName = i.PhoneTypeName, IDCategory = (int)i.IDCategory });
                    }
                }
                else
                {
                    foreach (PhoneType i in db.PhoneTypes)
                    {
                        list.Add(new DTO_PhoneType { IDPhoneType = i.IDPhoneType, PhoneTypeName = i.PhoneTypeName, IDCategory = (int)i.IDCategory });
                    }
                }
                cbbPhoneType.Items.AddRange(list.ToArray());
            }
        }
    }
}
