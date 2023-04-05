using PhoneStoreManagement.DAL;
using PhoneStoreManagement.DTO;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Windows;

namespace PhoneStoreManagement.BLL
{
    public class BLL_UCOrder
    {
        private static BLL_UCOrder _Instance;
        private Customer _customer;
        private Order_ _lastOrder;
        private Transaction_ _transaction;
        private BLL_UCOrder()
        {

        }
        public static BLL_UCOrder Instance
        {
            get
            {
                if (_Instance == null)
                {
                    _Instance = new BLL_UCOrder();
                }
                return _Instance;
            }
            private set { }
        }

        public Customer Customer { get => _customer; set => _customer = value; }
        public Order_ LastOrder { get => _lastOrder; set => _lastOrder = value; }
        public Transaction_ Transaction { get => _transaction; set => _transaction = value; }

        public void ConfirmCustomer(string NameCustomer, string Address, string Phone)
        {
            if (NameCustomer == "" || Address == "" || Phone == "")
            {
                MessageBox.Show("Hãy điền đầy đủ thông tin khách hàng", "Thông tin"); return;
            }
            using (var db = new DBManagement())
            {
                Customer customer = db.Customers.SingleOrDefault(p => p.Phone == Phone);
                if (customer == null)
                {
                    Customer newCustomer = new Customer { NameCustomer = NameCustomer, Address = Address, Phone = Phone };
                    _customer = newCustomer;
                    db.Customers.Add(newCustomer);
                    db.SaveChanges();
                    MessageBox.Show("Đã thêm khách hàng thành công", "Thêm khác hàng");
                }
                else
                {
                    MessageBox.Show("Đã tồn tại số điện thoại này! Vui lòng nhập số điện thoại khác!!", "Thêm khác hàng");
                }
            }
        }

        public void SetNewOrder(string IDEmployeeCreate, string IDEmployeeEdit, DateTime TimeOrder, DTO_TypeOrder typeOrder, string Phone = null)
        {
            using (var db = new DBManagement())
            {
                int idEmployeeCreate = Convert.ToInt32(IDEmployeeCreate);
                int? idEmployeeEdit = (IDEmployeeEdit.Equals("") == false) ? Convert.ToInt32(IDEmployeeEdit) : (int?)null;
                Customer = db.Customers.SingleOrDefault(p => p.Phone == Phone);
                Order_ order = new Order_
                {
                    IDCustomer = Customer.IDCustomer,
                    IDEmployeeCreate = idEmployeeCreate,
                    IDEmployeeEdit = idEmployeeEdit,
                    TimeOrder = TimeOrder,
                    Total = 0,
                    IDState = 1,
                    IDTypeOrder = typeOrder.IDTypeOrder
                };
                LastOrder = order;
                db.Order_.Add(order);
                db.SaveChanges();
                MessageBox.Show("Đã lên đơn thành công", "Đơn hàng");
            }
        }
        public void SetTransaction(bool typePayment, DateTime TimeOrder, string TotalApplyedDis, DTO_Discount discount)
        {
            DBManagement db = new DBManagement();
            Transaction_ transaction = db.Transaction_.SingleOrDefault(p => p.IDOrder == _lastOrder.IDOrder);
            if (transaction == null)
            {
                db.Transaction_.Add(new Transaction_
                {
                    IDOrder = LastOrder.IDOrder,
                    PaymentMethods = (typePayment == true) ? "Direct" : "Credit",
                    DateOfPayment = TimeOrder,
                    Price = Convert.ToInt32(TotalApplyedDis),
                    IDDiscount = discount.IDDiscount
                });
            }
            else
            {
                transaction.IDOrder = LastOrder.IDOrder;
                transaction.PaymentMethods = (typePayment) ? "Direct" : "Credit";
                transaction.DateOfPayment = TimeOrder;
                transaction.Price = Convert.ToInt32(TotalApplyedDis);
                transaction.IDDiscount = discount.IDDiscount;
            }
            _transaction = transaction;
            db.SaveChanges();
        }
        public Order_ GetLastOrder(DBManagement db, Customer customer = null)
        {
            if (customer != null)
            {
                var orders = db.Order_.Where(p => p.IDCustomer == customer.IDCustomer).OrderByDescending(p => p.IDOrder);
                Order_ lastOrder = orders.FirstOrDefault();
                _lastOrder = lastOrder;
                return lastOrder;
            }
            else
            {
                var orders = db.Order_.Where(p => p.IDCustomer == _customer.IDCustomer).OrderByDescending(p => p.IDOrder);
                Order_ lastOrder = orders.FirstOrDefault();
                _lastOrder = lastOrder;
                return lastOrder;
            }
        }
        public bool CheckOut(DBManagement db, Customer customer, Order_ lastOrder)
        {
            if (customer == null)
            {
                MessageBox.Show("Khách hàng không tồn tại", "Thanh toán"); return false;
            }
            if (lastOrder == null)
            {
                MessageBox.Show("Đơn hàng chưa được xác nhân", "Thanh toán"); return false;
            }
            if (BLL_ListPhoneChose.Instance.GetListPhoneChose().Count == 0)
            {
                MessageBox.Show("Bạn chưa chọn sản phẩm nào!", "Thanh toán"); return false;
            }
            int totalOrder = 0;
            if (lastOrder.OrderDetails != null)
            {
                lastOrder.OrderDetails.Clear();
            }
            foreach (DTO_PhoneChose i in BLL_ListPhoneChose.Instance.GetListPhoneChose())
            {
                int totalDetail = (i.Price * i.Quantity);
                lastOrder.OrderDetails.Add(new OrderDetail
                {
                    IDOrder = lastOrder.IDOrder,
                    IDPhone = i.IDPhone,
                    Quantity = i.Quantity,
                    Total = totalDetail
                });
                totalOrder += totalDetail;
            }
            lastOrder.Total = totalOrder;
            SubQuantity(lastOrder, db); return true;
        }
        public List<DTO_InfoOrder> GetListDTO_InfoOrder()
        {
            using (var db = new DBManagement())
            {
                List<DTO_InfoOrder> list = new List<DTO_InfoOrder>();
                foreach (DTO_PhoneChose i in BLL_ListPhoneChose.Instance.GetListPhoneChose())
                {
                    Phone phone = db.Phones.SingleOrDefault(p => p.IDPhone == i.IDPhone);
                    list.Add(new DTO_InfoOrder
                    {
                        IDPhone = phone.IDPhone,
                        Picture = phone.Picture,
                        NamePhone = phone.NamePhone,
                        NameBrand = phone.Brand.NameBrand,
                        Price = phone.Price,
                        Quantity = i.Quantity
                    });
                }
                return list;
            }
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
        public Customer GetCustomerByPhone(string Phone)
        {
            using (var db = new DBManagement())
            {
                Customer customer = db.Customers.SingleOrDefault(p => p.Phone.Equals(Phone));
                return customer;
            }
        }
        public void CheckOut(string Phone, bool clickBtnEdit)
        {
            using (var db = new DBManagement())
            {
                Customer customer = db.Customers.SingleOrDefault(p => p.Phone.Equals(Phone));
                if (customer == null) return;
                Order_ lastOrder = BLL_UCOrder.Instance.GetLastOrder(db, customer);
                if (lastOrder == null)
                {
                    MessageBox.Show("Khách hàng chưa được lên đơn hàng", "Đơn hàng"); return;
                }
                if (clickBtnEdit)
                {
                    BLL_UCOrder.Instance.LoadQuantity(lastOrder, db);
                }
                if (BLL_UCOrder.Instance.CheckOut(db, customer, lastOrder))
                {
                    MessageBox.Show("Thanh toán thành công", "Thanh toán");
                }
                else
                {
                    return;
                }
                db.SaveChanges();
            }
        }
        public void PrintOrder(string Phone)
        {
            using (var db = new DBManagement())
            {
                Customer customer = db.Customers.SingleOrDefault(p => p.Phone.Equals(Phone));
                if (customer == null)
                {
                    MessageBox.Show("Chưa có thông tin khách hàng", "In hóa đơn"); return;
                }
                var orders = db.Order_.Where(p => p.IDCustomer == customer.IDCustomer).OrderByDescending(p => p.IDOrder);
                Order_ lastOrder = orders.FirstOrDefault();
                if (lastOrder == null)
                {
                    MessageBox.Show("Chưa có thông tin đơn hàng của khách", "In hóa đơn"); return;
                }
                List<OrderDetail> listOrderDetail = db.OrderDetails.Where(p => p.IDOrder == lastOrder.IDOrder).ToList();
                using (FormReceipt printForm = new FormReceipt(lastOrder, listOrderDetail))
                {
                    printForm.ShowDialog();
                }
            }
        }
        
    }
}