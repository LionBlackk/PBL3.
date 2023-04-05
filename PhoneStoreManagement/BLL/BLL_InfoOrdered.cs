using PagedList;
using PhoneStoreManagement.DAL;
using PhoneStoreManagement.DTO;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PhoneStoreManagement.BLL
{
    public class BLL_InfoOrdered
    {
        private static BLL_InfoOrdered _Instance;
        private BLL_InfoOrdered()
        {

        }
        public static BLL_InfoOrdered Instance
        {
            get
            {
                if(_Instance == null)
                {
                    _Instance = new BLL_InfoOrdered();
                }
                return _Instance;
            }
            private set { }
        }
        public async Task<IPagedList<DTO_InfoOrdered>> GetInfoOrdered(Account account, string PhoneCustomer = null, int pageNumber = 1, int pageSize = 15)
        {
            return await Task.Factory.StartNew(() =>
            {
                using (var db = new DBManagement())
                {
                    List<DTO_InfoOrdered> listInfoOrdered = new List<DTO_InfoOrdered>();
                    Employee employee = db.Employees.SingleOrDefault(p => p.IDEmployee == account.IDEmployee);
                    foreach (Order_ i in db.Order_)
                    {
                        if (i.IDEmployeeEdit != null && i.IDEmployeeEdit == employee.IDEmployee || (i.IDEmployeeCreate == employee.IDEmployee && i.IDEmployeeEdit == null))
                        {
                            Customer customer = db.Customers.SingleOrDefault(p => p.IDCustomer == i.IDCustomer);
                            if (PhoneCustomer == null || (PhoneCustomer != null && customer.Phone.Contains(PhoneCustomer)))
                            {
                                Transaction_ transaction = db.Transaction_.SingleOrDefault(p1 => p1.IDOrder == i.IDOrder);
                                if (transaction == null) continue;
                                TypeOrder typeOrderDB = db.TypeOrders.SingleOrDefault(p => p.IDTypeOrder == i.IDTypeOrder);
                                Discount discount = db.Discounts.SingleOrDefault(p => p.IDDiscount == transaction.IDDiscount);
                                DTO_TypeOrder typeOrderDTO = new DTO_TypeOrder
                                {
                                    IDTypeOrder = typeOrderDB.IDTypeOrder,
                                    NameTypeOrder = typeOrderDB.NameTypeOrder
                                };
                                State stateDB = db.States.SingleOrDefault(p => p.IDState == i.IDState);
                                DTO_State stateOrder = new DTO_State
                                {
                                    IDState = stateDB.IDState,
                                    NameState = stateDB.NameState
                                };
                                listInfoOrdered.Add(
                                    new DTO_InfoOrdered
                                    {
                                        IDOrder = i.IDOrder,
                                        NameCustomer = customer.NameCustomer,
                                        PhoneCustomer = customer.Phone,
                                        AddressCustomer = customer.Address,
                                        IDEmployeeCreate = (int)i.IDEmployeeCreate,
                                        IDEmployeeEdit = (i.IDEmployeeEdit == null) ? "" : i.IDEmployeeEdit.ToString(),
                                        TimeOrder = i.TimeOrder,
                                        ValueDiscount = discount.ValueDiscount + "%",
                                        Total = transaction.Price + "₫",
                                        TypeOrder = typeOrderDTO,
                                        StateOrder = stateOrder
                                    }
                                );
                            }
                        }
                    }
                    return listInfoOrdered.ToPagedList(pageNumber, pageSize);
                }
            });
        }
    }
}
