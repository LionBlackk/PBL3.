using PhoneStoreManagement.DAL;
using System;
using System.Drawing;
using System.Drawing.Imaging;
using System.IO;
using System.Linq;
using System.Windows;

namespace PhoneStoreManagement.BLL
{
    public class BLL_UCSetting
    {
        private static BLL_UCSetting _Instance;

        private BLL_UCSetting()
        {

        }
        public static BLL_UCSetting Instance
        {
            get
            {
                if (_Instance == null)
                {
                    _Instance = new BLL_UCSetting();
                }
                return _Instance;
            }
            private set { }
        }
        public void ConfirmSetting(string IDEmployee, string NameEmployee, DateTime BirthDay, bool rdMale, string Phone, string Email, Image picture)
        {
            using (var db = new DBManagement())
            {
                Employee employee = db.Employees.SingleOrDefault(p => p.IDEmployee.ToString().Equals(IDEmployee));
                employee.NameEmployee = NameEmployee;
                employee.BirthDay = BirthDay;
                employee.Gender = rdMale;
                employee.Phone = Phone;
                employee.Email = Email;
                using (MemoryStream ms = new MemoryStream())
                {
                    if (picture != null)
                    {
                        picture.Save(ms, ImageFormat.Png);
                        employee.Picture = ms.ToArray();
                    }
                    else
                    {
                        employee.Picture = null;
                    }
                }
                db.SaveChanges();
                MessageBox.Show("Bạn đã thay đổi thông tin thành công", "Cài đặt"); return;
            }
        }
    }
}
