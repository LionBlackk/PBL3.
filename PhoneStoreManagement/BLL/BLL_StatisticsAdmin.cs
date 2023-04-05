using PagedList;
using PhoneStoreManagement.DAL;
using PhoneStoreManagement.DTO;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.InteropServices;
using System.Text;
using System.Threading.Tasks;

namespace PhoneStoreManagement.BLL
{
    class BLL_StatisticsAdmin
    {
        private static BLL_StatisticsAdmin _Instance;
        public static BLL_StatisticsAdmin Instance
        {
            get
            {
                if (_Instance == null)
                {
                    _Instance = new BLL_StatisticsAdmin();
                }
                return _Instance;
            }
            private set { }
        }

        public int getTotalRevenue()
        {
            int total = 0;
            using (DBManagement db = new DBManagement())
            {
                foreach (Order_ order in db.Order_.Select(p => p))
                {
                    total += order.Total;
                }
                return total;
            }
        }
        public int getTotalCustomer()
        {
            using (DBManagement db = new DBManagement())
            {
                return db.Customers.Select(p => p).Count();
            }
        }
        public int getTotalPhoneSell()
        {
            int total = 0;
            using (DBManagement db = new DBManagement())
            {
                foreach (OrderDetail od in db.OrderDetails.Select(p => p))
                {
                    total += od.Quantity;
                }
                return total;
            }
        }
        public int getNumberOfOrderbyId(int idCustomer)
        {
            int result = 0;
            using (DBManagement db = new DBManagement())
            {
                foreach (Order_ order in db.Order_.ToList())
                {
                    if (order.IDCustomer == idCustomer)
                    {
                        result++;
                    }
                }
                return result;
            }
        }
        public async Task<IPagedList<DTO_Statistics_Phone>> getStatisticsByPhone(DateTime fromDate, DateTime toDate, int pageNumber = 1, int pageSize = 12)
        {
            return await Task.Factory.StartNew(() =>
            {
                using (DBManagement db = new DBManagement())
                {
                    List<DTO_Statistics_Phone> list = new List<DTO_Statistics_Phone>();
                    list = db.Phones
                        .GroupJoin(
                            db.OrderDetails.Where(o => o != null && o.Order_.TimeOrder >= fromDate && o.Order_.TimeOrder <= toDate),
                            p => p.IDPhone,
                            od => od.IDPhone,
                            (p, od) => new { Phones = p, OrderDetails = od.DefaultIfEmpty() })
                        .Select(g => new DTO_Statistics_Phone
                        {
                            PhoneName = g.Phones.NamePhone,
                            Quantity = g.OrderDetails.Sum(o => o != null ? o.Quantity : 0),
                            Total = g.OrderDetails.Sum(o => o != null ? o.Total : 0),
                        }).ToList();
                    return list.ToPagedList(pageNumber, pageSize);
                }
            });
        }
        public async Task<IPagedList<DTO_Statistics_Employee>> getStatisticsByEmployee(DateTime fromDate, DateTime toDate, int pageNumber = 1, int pageSize = 12)
        {
            return await Task.Factory.StartNew(() =>
            {
                using (DBManagement db = new DBManagement())
                {
                    List<DTO_Statistics_Employee> list = new List<DTO_Statistics_Employee> ();
                    List<Employee> employees = new List<Employee> ();
                    foreach(Employee e in db.Employees.ToList())
                    {
                        string role = BLL_EmployeesAdmin.Instance.getRoleById(e.IDEmployee);
                        if (role.Contains("Saler")) employees.Add(e);
                    }
                    list = employees
                        .GroupJoin(db.Order_.Where(o => o != null && o.TimeOrder >= fromDate && o.TimeOrder <= toDate),
                                   e => e.IDEmployee,
                                   o => o.IDEmployeeCreate,
                                   (e, o) => new { Employee = e, Orders = o.DefaultIfEmpty() })
                        .Select(g => new DTO_Statistics_Employee
                        {
                            FullName = g.Employee.NameEmployee,
                            NumberOfOrder = g.Orders.Count(o => o != null),
                            Total = g.Orders.Sum(o => o != null ? o.Total : 0)
                        }).ToList();

                    return list.ToPagedList(pageNumber, pageSize);
                }
            });
        }
        public async Task<IPagedList<DTO_Statistics_TypeOrder>> getStatisticsByTypeOrders(DateTime fromDate, DateTime toDate, int pageNumber = 1, int pageSize = 12)
        {
            return await Task.Factory.StartNew(() =>
            {
                using (DBManagement db = new DBManagement())
                {
                    List<DTO_Statistics_TypeOrder> list = new List<DTO_Statistics_TypeOrder>();
                    list = db.TypeOrders
                        .GroupJoin(
                            db.Order_.Where(o => o != null && o.TimeOrder >= fromDate && o.TimeOrder <= toDate),
                            to => to.IDTypeOrder,
                            o => o.IDTypeOrder,
                            (to, o) => new { TypeOrders = to, Orders = o.DefaultIfEmpty() })
                        .Select(g => new DTO_Statistics_TypeOrder
                        {
                            NameTypeOrder = g.TypeOrders.NameTypeOrder,
                            NumbersOfOrder = g.Orders.Count(),
                            Total = g.Orders.Sum(o => o != null ? o.Total : 0)
                        }).ToList();
                    return list.ToPagedList(pageNumber, pageSize);
                }
            });
        }
        public async Task<IPagedList<DTO_Customer>> GetListCustomers(string nameCustomer, int pageNumber = 1, int pageSize = 10)
        {
            return await Task.Factory.StartNew(() =>
            {
                List<DTO_Customer> list = new List<DTO_Customer>();
                using (DBManagement db = new DBManagement())
                {
                    foreach (Customer cus in db.Customers.Where(p => p.NameCustomer.Contains(nameCustomer)).ToList())
                    {
                        int orders = getNumberOfOrderbyId(cus.IDCustomer);
                        DTO_Customer dc = new DTO_Customer
                        {
                            IDCustomer = cus.IDCustomer,
                            NameCustomer = cus.NameCustomer,
                            Address = cus.Address,
                            Phone = cus.Phone,
                            NumberOfOrder = orders,
                        };
                        list.Add(dc);
                    }
                    return list.ToPagedList(pageNumber, pageSize);
                }
            });
        }
    }
}
