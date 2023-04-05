using PagedList;
using PhoneStoreManagement.DAL;
using PhoneStoreManagement.DTO;
using System;
using System.Collections.Generic;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace PhoneStoreManagement.BLL
{
    class BLL_PhonesAdmin
    {
        private static BLL_PhonesAdmin _Instance;
        public static BLL_PhonesAdmin Instance
        {
            get
            {
                if (_Instance == null)
                {
                    _Instance = new BLL_PhonesAdmin();
                }
                return _Instance;
            }
            private set { }
        }
        public List<DTO_Brand> GetCBBBrand()
        {
            using (DBManagement db = new DBManagement())
            {
                List<DTO_Brand> list = new List<DTO_Brand>();
                list.Add(new DTO_Brand
                {
                    IDBrand = "ALL",
                    NameBrand = "ALL"
                });
                foreach (Brand i in db.Brands)
                {
                    list.Add(new DTO_Brand
                    {
                        IDBrand = i.IDBrand,
                        NameBrand = i.NameBrand,
                    });
                }
                return list;
            }
        }
        public List<DTO_Brand> setCBBBrand()
        {
            using (DBManagement db = new DBManagement())
            {
                List<DTO_Brand> list = new List<DTO_Brand>();
                foreach (Brand i in db.Brands)
                {
                    list.Add(new DTO_Brand
                    {
                        IDBrand = i.IDBrand,
                        NameBrand = i.NameBrand,
                    });
                }
                return list;
            }
        }
        public List<DTO_PhoneType> setCBBPhoneType()
        {
            using (DBManagement db = new DBManagement())
            {
                List<DTO_PhoneType> list = new List<DTO_PhoneType>();
                foreach (PhoneType i in db.PhoneTypes)
                {
                    list.Add(new DTO_PhoneType
                    {
                        IDPhoneType = i.IDPhoneType,
                        PhoneTypeName = i.PhoneTypeName,
                        IDCategory = i.IDCategory,
                    });

                }
                return list;
            }
        }

        public Image getPicture(Phone phone)
        {
            MemoryStream ms = new MemoryStream(phone.Picture.ToArray());
            Image image = Image.FromStream(ms);
            return image;
        }
        public void setPicture(Phone phone, PictureBox picture)
        {
            MemoryStream ms = new MemoryStream(phone.Picture.ToArray());
            Image image = Image.FromStream(ms);
            picture.Image = image;
        }
        public async Task<IPagedList<DTO_ViewPhone>> getListPhone(string Brand, string Name, int pageNumber = 1, int pageSize = 5)
        {
            return await Task.Factory.StartNew(() =>
            {
                List<DTO_ViewPhone> data = new List<DTO_ViewPhone>();
                using (DBManagement db = new DBManagement())
                {
                    if (Brand == "ALL")
                    {
                        foreach (Phone p in db.Phones.Where(p => p.NamePhone.Contains(Name)))
                        {
                            Image image = getPicture(p);
                            DTO_ViewPhone view = new DTO_ViewPhone
                            {
                                IDPhone = p.IDPhone,
                                NamePhone = p.NamePhone,
                                RAM = p.RAM,
                                ROM = p.ROM,
                                Battery = p.BateryCapacity,
                                Camera = p.CameraResolution,
                                ScreenSize = p.ScreenSize,
                                Price = p.Price,
                                Operating = p.Operating,
                                Brand = p.Brand.NameBrand,
                                Picture = image,
                            };
                            data.Add(view);
                        }
                    }
                    else
                    {
                        foreach (Phone p in db.Phones.Where(p => p.NamePhone.Contains(Name) && p.Brand.NameBrand.Contains(Brand)))
                        {
                            Image image = getPicture(p);
                            DTO_ViewPhone view = new DTO_ViewPhone
                            {
                                IDPhone = p.IDPhone,
                                NamePhone = p.NamePhone,
                                RAM = p.RAM,
                                ROM = p.ROM,
                                Battery = p.BateryCapacity,
                                Camera = p.CameraResolution,
                                ScreenSize = p.ScreenSize,
                                Price = p.Price,
                                Operating = p.Operating,
                                Brand = p.Brand.NameBrand,
                                Picture = image,
                            };
                            data.Add(view);
                        }
                    }
                }
                return data.ToPagedList(pageNumber, pageSize);
            });
        }
        public Phone getPhoneByID(int id)
        {
            Phone data = new Phone();
            using (DBManagement db = new DBManagement())
            {
                foreach (Phone i in db.Phones)
                {
                    if (i.IDPhone == id)
                    {
                        data = i;
                        return data;
                    }
                }
            }
            return null;
        }
        public void addorupdatePhone(Phone s)
        {
            using (DBManagement db = new DBManagement())
            {
                var l1 = db.Phones.Where(p => p.IDPhone == s.IDPhone).FirstOrDefault();
                if (l1 != null)
                {
                    l1.NamePhone = s.NamePhone;
                    l1.ROM = s.ROM;
                    l1.RAM = s.RAM;
                    l1.ScreenSize = s.ScreenSize;
                    l1.BateryCapacity = s.BateryCapacity;
                    l1.CameraResolution = s.CameraResolution;
                    l1.Price = s.Price;
                    l1.Operating = s.Operating;
                    l1.Picture = s.Picture;
                    l1.IDBrand = s.IDBrand;
                    l1.IDPhoneType = s.IDPhoneType;
                    db.SaveChanges();
                }
                else
                {
                    db.Phones.Add(s);
                    db.SaveChanges();
                }
            }
        }
        public void addInventory(Phone s)
        {
            using (DBManagement db = new DBManagement())
            {
                InventoryManagement i = new InventoryManagement
                {
                    IDPhone = s.IDPhone,
                    Quantity = 0,
                };
                db.InventoryManagements.Add(i);
                db.SaveChanges();
            }
        }
        public bool checkExistPhoneInOrder(Phone phone)
        {
            using (DBManagement db = new DBManagement())
            {
                var s = db.OrderDetails.Where(p => p.IDPhone == phone.IDPhone);
                return s.Any();
            }
        }
        public bool checkExistPhoneInImport(Phone phone)
        {
            using (DBManagement db = new DBManagement())
            {
                var s = db.ImportManagements.Where(p => p.IDPhone == phone.IDPhone);
                return s.Any();
            }
        }
        public void deletePhone_BLL(List<int> del)
        {
            using (DBManagement db = new DBManagement())
            {
                foreach (int i in del)
                {
                    var s = db.Phones.Where(p => p.IDPhone == i).FirstOrDefault();
                    if (checkExistPhoneInOrder(s))
                    {
                        MessageBox.Show("Sản Phẩm này đang được lưu trong hoá đơn bán hàng", "Warning");
                        break;
                    }
                    else if (checkExistPhoneInImport(s))
                    {
                        MessageBox.Show("Sản Phẩm này đang được lưu trong hoá đơn nhập kho", "Warning");
                        break;
                    }
                    else
                    {
                        var inventory = db.InventoryManagements.Where(p => p.IDPhone == i).FirstOrDefault();
                        db.InventoryManagements.Remove(inventory);
                        db.Phones.Remove(s);
                        db.SaveChanges();
                    }
                }
            }
        }
        public Phone findPhone(int IDPhone)
        {
            using (DBManagement db = new DBManagement())
            {
                return db.Phones.SingleOrDefault(p => p.IDPhone == IDPhone);
            }
        }
    }
}
