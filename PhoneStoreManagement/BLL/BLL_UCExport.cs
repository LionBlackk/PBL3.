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
    class BLL_UCExport
    {
        private static BLL_UCExport _Instance;
        public static BLL_UCExport Instance
        {
            get
            {
                if (_Instance == null)
                {
                    _Instance = new BLL_UCExport();
                }
                return _Instance;
            }
            private set { }
        }
        public List<DTO_Discount> setCBBDiscount()
        {
            using (var db = new DBManagement())
            {
                List<DTO_Discount> list = db.Discounts.Select(p => new DTO_Discount
                {
                    IDDiscount = p.IDDiscount,
                    ValueDiscount = p.ValueDiscount,
                }).ToList();
                return list;
            }
        }
        public List<DTO_TypeOrder> setCBBTypeOrder()
        {
            using (var db = new DBManagement())
            {
                List<DTO_TypeOrder> list = db.TypeOrders.Select(p => new DTO_TypeOrder
                {
                    IDTypeOrder = p.IDTypeOrder,
                    NameTypeOrder = p.NameTypeOrder,
                }).ToList();
                return list;
            }
        }
        public List<DTO_State> setCBBState()
        {
            List<DTO_State> listState = new List<DTO_State>();
            using (var db = new DBManagement())
            {
                foreach (State i in db.States)
                {
                    listState.Add(new DTO_State
                    {
                        IDState = i.IDState,
                        NameState = i.NameState
                    });
                }
            }
            return listState;
        }
        public DTO_InfoOrdered getInfoOrderedById(int id)
        {
            DTO_InfoOrdered dto;
            using (DBManagement db = new DBManagement())
            {
                var order = db.Order_.Where(p => p.IDOrder == id).SingleOrDefault();
                if (order != null)
                {
                    Transaction_ transaction = db.Transaction_.SingleOrDefault(p1 => p1.IDOrder == order.IDOrder);
                    TypeOrder typeOrderDB = db.TypeOrders.SingleOrDefault(p => p.IDTypeOrder == order.IDTypeOrder);
                    DTO_TypeOrder typeOrderDTO = new DTO_TypeOrder
                    {
                        IDTypeOrder = typeOrderDB.IDTypeOrder,
                        NameTypeOrder = typeOrderDB.NameTypeOrder
                    };
                    State stateDB = db.States.SingleOrDefault(p => p.IDState == order.IDState);
                    DTO_State stateOrder = new DTO_State
                    {
                        IDState = stateDB.IDState,
                        NameState = stateDB.NameState
                    };
                    dto = new DTO_InfoOrdered
                    {
                        IDOrder = id,
                        NameCustomer = order.Customer.NameCustomer,
                        AddressCustomer = order.Customer.Address,
                        PhoneCustomer = order.Customer.Phone,
                        IDEmployeeCreate = (int)order.IDEmployeeCreate,
                        IDEmployeeEdit = (order.IDEmployeeCreate != null) ? order.IDEmployeeEdit.ToString() : null,
                        TimeOrder = order.TimeOrder,
                        Total = order.Total.ToString(),
                        TypeOrder = typeOrderDTO,
                        StateOrder = stateOrder,
                        ValueDiscount = db.Discounts.SingleOrDefault(p => p.IDDiscount == transaction.IDDiscount).ValueDiscount + "%",
                    };
                    return dto;
                }
            }
            return null;
        }
        public async Task<IPagedList<DTO_InfoOrdered>> GetInfoOrdered(int pageNumber = 1, int pageSize = 10)
        {
            return await Task.Factory.StartNew(() =>
            {
                List<DTO_InfoOrdered> listInfoOrdered = new List<DTO_InfoOrdered>();
                using (var db = new DBManagement())
                {
                    foreach (Order_ i in db.Order_)
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
                                NameCustomer = i.Customer.NameCustomer,
                                PhoneCustomer = i.Customer.Phone,
                                AddressCustomer = i.Customer.Address,
                                IDEmployeeCreate = (int)i.IDEmployeeCreate,
                                IDEmployeeEdit = (i.IDEmployeeEdit == null) ? "" : i.IDEmployeeEdit.ToString(),
                                TimeOrder = i.TimeOrder,
                                ValueDiscount = discount.ValueDiscount + "%",
                                Total = transaction.Price + "₫",
                                TypeOrder = typeOrderDTO,
                                StateOrder = stateOrder,
                            }
                        );
                    }
                    return listInfoOrdered.ToPagedList(pageNumber, pageSize);
                }
            });
        }
        public Transaction_ GetTransactionById(int id)
        {
            using (DBManagement db = new DBManagement())
            {
                Transaction_ transaction = db.Transaction_.SingleOrDefault(p1 => p1.IDOrder == id);
                return transaction;
            }
        }
        public Discount GetDiscount(Transaction_ transaction)
        {
            using (DBManagement db = new DBManagement())
            {
                Discount ValueDiscount = db.Discounts.SingleOrDefault(p => p.IDDiscount == transaction.IDDiscount);
                return ValueDiscount;
            }
        }
        public void UpdateInfoOrder(DTO_InfoOrdered order)
        {
            using (DBManagement db = new DBManagement())
            {
                var orderUpdate = db.Order_.Where(p => p.IDOrder == order.IDOrder).SingleOrDefault();
                orderUpdate.Customer.NameCustomer = order.NameCustomer;
                orderUpdate.Customer.Phone = order.PhoneCustomer;
                orderUpdate.Customer.Address = order.AddressCustomer;
                orderUpdate.IDState = order.StateOrder.IDState;
                db.SaveChanges();
            }
        }
    }
}
