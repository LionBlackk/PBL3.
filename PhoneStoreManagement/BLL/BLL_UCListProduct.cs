using PhoneStoreManagement.DAL;
using PhoneStoreManagement.DTO;
using PhoneStoreManagement.UserControls;
using System;
using System.Collections.Generic;
using System.Drawing;
using System.IO;
using System.Linq;

namespace PhoneStoreManagement.BLL
{
    public class BLL_UCListProduct
    {
        private static BLL_UCListProduct _Instance;
        private int factor = 1000000;
        private BLL_UCListProduct()
        {

        }
        public static BLL_UCListProduct Instance
        {
            get
            {
                if (_Instance == null)
                {
                    _Instance = new BLL_UCListProduct();
                }
                return _Instance;
            }
            private set { }
        }
        public List<int> GetBound(string phoneTypeName)
        {
            List<int> list = new List<int>();
            for (int i = 0; i < phoneTypeName.Length; ++i)
            {
                string tmp = "";
                if (phoneTypeName[i] == ' ')
                {
                    while (Char.IsDigit(phoneTypeName[i + 1]))
                    {
                        tmp += phoneTypeName[i + 1];
                        i = i + 1;
                    }
                }
                if (tmp != "")
                {
                    list.Add(Int32.Parse(tmp));
                }
            }
            return list;
        }
        private List<Phone> GetPhoneType(DTO_PhoneType phoneType, DTO_Brand brand = null)
        {
            List<Phone> listPhone = new List<Phone>();
            using (var db = new DBManagement())
            {
                Category category = null;
                if (phoneType.IDPhoneType != 0)
                {
                    category = db.Categories.Where(p => (p.IDCategory == phoneType.IDCategory)).FirstOrDefault();
                }
                List<int> getBound = GetBound(phoneType.PhoneTypeName);
                if (brand == null && category.NameCategory.Equals("Theo mức giá"))
                {
                    if (phoneType.PhoneTypeName.Contains("Dưới"))
                    {
                        int boundAfter = getBound[0];
                        listPhone = db.Phones.Where(p => p.Price < boundAfter * factor).ToList();
                    }
                    else if (phoneType.PhoneTypeName.Contains("Trên"))
                    {
                        int boundBefore = getBound[0];
                        listPhone = db.Phones.Where(p => p.Price > boundBefore * factor).ToList();
                    }
                    else
                    {
                        int boundBefore = getBound[0];
                        int boundAfter = getBound[1];
                        listPhone = db.Phones.Where(p => p.Price <= boundAfter * factor && p.Price >= boundBefore * factor).ToList();
                    }
                }
                else if (category.NameCategory.Equals("Theo mức giá"))
                {
                    if (phoneType.PhoneTypeName.Contains("Dưới"))
                    {
                        int boundAfter = getBound[0];
                        listPhone = db.Phones.Where(p => (p.Price < boundAfter * factor && p.IDBrand == brand.IDBrand)).ToList();
                    }
                    else if (phoneType.PhoneTypeName.Contains("Trên"))
                    {
                        int boundBefore = getBound[0];
                        listPhone = db.Phones.Where(p => (p.Price > boundBefore * factor && p.IDBrand == brand.IDBrand)).ToList();
                    }
                    else
                    {
                        int boundBefore = getBound[0];
                        int boundAfter = getBound[1];
                        listPhone = db.Phones.Where(p => (p.Price <= boundAfter * factor && p.Price >= boundBefore * factor) && p.IDBrand == brand.IDBrand).ToList();
                    }
                }
                else if(category.NameCategory.Equals("Loại điện thoại"))
                {
                    if (phoneType.PhoneTypeName.Contains("Android"))
                    {
                        listPhone = db.Phones.Where(p => p.Operating.Contains("Android")).ToList();
                    }else if (phoneType.PhoneTypeName.Contains("iOS"))
                    {
                        listPhone = db.Phones.Where(p => p.Operating.Contains("iOS")).ToList();
                    }
                }else if(phoneType.PhoneTypeName.Equals("Chụp ảnh đẹp"))
                {
                    listPhone = db.Phones.Where(p => p.Operating.Contains("iOS")).ToList();
                }else if(phoneType.PhoneTypeName.Equals("Pin trâu"))
                {
                    listPhone = db.Phones.Where(p => p.Operating.Contains("Android")).ToList();
                }
                else if(brand != null)
                {
                    listPhone = db.Phones.Where(p => (p.IDPhoneType == phoneType.IDPhoneType && p.IDBrand == brand.IDBrand)).ToList();
                }
                else
                {
                    listPhone = db.Phones.Where(p => (p.IDPhoneType == phoneType.IDPhoneType)).ToList();
                }
            }
            return listPhone;
        }

        public List<UC_Product> ListUC(DTO_Brand brand, DTO_PhoneType phoneType, string NamePhone)
        {
            List<UC_Product> listUCProduct = new List<UC_Product>();
            using (var db = new DBManagement())
            {
                List<Phone> listPhone = new List<Phone>();
                NamePhone = NamePhone.Trim();
                if (brand.IDBrand.Equals("ALL") && phoneType.IDPhoneType == 0 && NamePhone == "")
                {
                    listPhone = db.Phones.Select(p => p).ToList();
                }
                else if (brand.IDBrand.Equals("ALL") && phoneType.IDPhoneType == 0 && NamePhone != "")
                {
                    listPhone = db.Phones.Where(p => p.NamePhone.Contains(NamePhone)).ToList();
                }
                else if (brand.IDBrand.CompareTo("ALL") == 0 && NamePhone == "")
                {
                    listPhone = GetPhoneType(phoneType);
                }
                else if (brand.IDBrand.CompareTo("ALL") == 0 && NamePhone != "")
                {
                    foreach (Phone i in GetPhoneType(phoneType))
                    {
                        if (i.NamePhone.Contains(NamePhone))
                        {
                            listPhone.Add(i);
                        }
                    }
                }
                else if (phoneType.IDPhoneType == 0 && NamePhone == "")
                {
                    listPhone = db.Phones.Where(p => p.IDBrand.Equals(brand.IDBrand)).ToList();
                }
                else if (phoneType.IDPhoneType == 0 && NamePhone != "")
                {
                    foreach (Phone i in db.Phones.Where(p => p.IDBrand.Equals(brand.IDBrand)).ToList())
                    {
                        if (i.NamePhone.Contains(NamePhone))
                        {
                            listPhone.Add(i);
                        }
                    }
                }
                else if (!brand.IDBrand.Equals("ALL") && phoneType.IDPhoneType != 0 && NamePhone == "")
                {
                    listPhone = GetPhoneType(phoneType, brand);
                }
                else if (!brand.IDBrand.Equals("ALL") && phoneType.IDPhoneType != 0 && NamePhone != "")
                {
                    foreach (Phone i in GetPhoneType(phoneType, brand))
                    {
                        if (i.NamePhone.Contains(NamePhone))
                        {
                            listPhone.Add(i);
                        }
                    }
                }
                foreach (Phone i in listPhone)
                {
                    UC_Product item = new UC_Product();
                    item.IDPhone.Text = i.IDPhone.ToString();
                    item.NamePhone.Text = i.NamePhone;
                    item.RAM.Text = "Bộ nhớ: " + i.RAM.ToString() + "GB RAM";
                    item.BateryCapacity.Text = "Pin: " + i.BateryCapacity.ToString() + " mAh";
                    item.ScreenSize.Text = "Màn hình: " + i.ScreenSize;
                    item.Price.Text = i.Price.ToString() + " ₫";
                    if (i.Picture != null && i.Picture.Length > 0)
                    {
                        MemoryStream ms = new MemoryStream(i.Picture);
                        item.Picture.Image = Image.FromStream(ms);
                    }
                    Phone phone = db.Phones.Where(p => p.IDPhone.Equals(i.IDPhone)).FirstOrDefault();
                    int count = 0;
                    foreach (InventoryManagement inventory in phone.InventoryManagements.Where(p => p.IDPhone == phone.IDPhone).ToList())
                    {
                        count += inventory.Quantity;
                    }
                    if (count == 0)
                    {
                        item.remain.Text = "Hết hàng";
                    }
                    else
                    {
                        item.remain.Text = "Còn lại: " + count.ToString();
                    }
                    listUCProduct.Add(item);
                }
            }
            return listUCProduct;
        }
    }
}
