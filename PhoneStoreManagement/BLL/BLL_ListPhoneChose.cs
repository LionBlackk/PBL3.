using PhoneStoreManagement.DAL;
using PhoneStoreManagement.DTO;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PhoneStoreManagement.BLL
{
    public class BLL_ListPhoneChose
    {
        private static BLL_ListPhoneChose _Instance;
        //Tạo một event PhoneChoseAdded trong class BLL_ListPhoneChose để thông báo rằng đã thêm một sản phẩm vào danh sách các sản phẩm đã chọn.
        public static event EventHandler PhoneChoseAdded;
        private BLL_ListPhoneChose()
        {

        }

        public static BLL_ListPhoneChose Instance
        {
            get
            {
                if (_Instance == null)
                {
                    _Instance = new BLL_ListPhoneChose();
                }
                return _Instance;
            }
            private set { }
        }

        private List<DTO_PhoneChose> ListPhoneChose = new List<DTO_PhoneChose>();
        public void AddPhoneChose(DTO_PhoneChose phoneChose)
        {
            if (phoneChose.Quantity == 0) return;
            DTO_PhoneChose isExistPhoneChose = ListPhoneChose.Find(p => p.IDPhone == phoneChose.IDPhone);
            if (isExistPhoneChose == null)
            {
                ListPhoneChose.Add(phoneChose);
            }
            else
            {
                isExistPhoneChose.Quantity += phoneChose.Quantity;
            }
            PhoneChoseAdded?.Invoke(this, EventArgs.Empty);
        }
        public List<DTO_PhoneChose> GetListPhoneChose()
        {
            return ListPhoneChose;
        }
        public void SetListPhoneChoseByDGV(DBManagement db, int idPhone, int quantity)
        {
            Phone phone = db.Phones.SingleOrDefault(p => p.IDPhone == idPhone);
            if (!BLL_ListPhoneChose.Instance.GetListPhoneChose().Exists(p => p.IDPhone == phone.IDPhone))
            {
                BLL_ListPhoneChose.Instance.AddPhoneChose(new DTO_PhoneChose
                {
                    IDPhone = phone.IDPhone,
                    NamePhone = phone.NamePhone,
                    Price = phone.Price,
                    Quantity = quantity
                });
            }
        }
        public void SetListPhoneChoseByOrderDetail(DBManagement db, Order_ order)
        {
            foreach (OrderDetail i in order.OrderDetails)
            {
                Phone phone = db.Phones.SingleOrDefault(p => p.IDPhone == i.IDPhone);
                BLL_ListPhoneChose.Instance.AddPhoneChose(new DTO_PhoneChose
                {
                    IDPhone = phone.IDPhone,
                    NamePhone = phone.NamePhone,
                    Price = phone.Price,
                    Quantity = i.Quantity
                });
            }
        }
    }
}
