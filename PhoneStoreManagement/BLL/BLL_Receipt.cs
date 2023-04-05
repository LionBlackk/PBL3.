using Microsoft.Reporting.WinForms;
using PhoneStoreManagement.DAL;
using PhoneStoreManagement.DTO;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PhoneStoreManagement.BLL
{
    public class BLL_Receipt
    {
        private static BLL_Receipt _Instance;
        private Customer _customer;
        private Transaction_ _transaction;
        private Discount _discount;
        private Order_ _order;
        private BLL_Receipt()
        {

        }
        public static BLL_Receipt Instance
        {
            get
            {
                if (_Instance == null)
                {
                    _Instance = new BLL_Receipt();
                }
                return _Instance;
            }
            private set { }
        }
        public List<DTO_Receipt> GetListDTO_Receipt(Order_ order, List<OrderDetail> list)
        {
            List<DTO_Receipt> receipt = new List<DTO_Receipt>();
            using (var db = new DBManagement())
            {
                _order = order;
                _transaction = db.Transaction_.SingleOrDefault(p => p.IDOrder == order.IDOrder);
                if (_transaction == null) return null;
                _customer = db.Customers.SingleOrDefault(p => p.IDCustomer == order.IDCustomer);
                _discount = db.Discounts.SingleOrDefault(p => p.IDDiscount == _transaction.IDDiscount);
                foreach (OrderDetail i in list)
                {
                    Phone phone = db.Phones.SingleOrDefault(p => p.IDPhone == i.IDPhone);
                    receipt.Add(new DTO_Receipt
                    {
                        IDPhone = phone.IDPhone,
                        NamePhone = phone.NamePhone,
                        Quantity = i.Quantity,
                        Price = phone.Price,
                        Total = i.Total
                    });
                }
            }
            return receipt;
        }
        public List<ReportParameter> GetReportParemeters() 
        {
            List<ReportParameter> list = new List<ReportParameter>
            {
                    new Microsoft.Reporting.WinForms.ReportParameter("pNameCustomer",_customer.NameCustomer),
                    new Microsoft.Reporting.WinForms.ReportParameter("pAddress",_customer.Address),
                    new Microsoft.Reporting.WinForms.ReportParameter("pPhone",_customer.Phone),
                    new Microsoft.Reporting.WinForms.ReportParameter("pIDOrder",_order.IDOrder.ToString()),
                    new Microsoft.Reporting.WinForms.ReportParameter("pTimeOrder",_order.TimeOrder.ToString("dd/MM/yyyy")),
                    new Microsoft.Reporting.WinForms.ReportParameter("pTotal",_order.Total.ToString() + "₫"),
                    new Microsoft.Reporting.WinForms.ReportParameter("pDiscount", _discount.ValueDiscount + "%"),
                    new Microsoft.Reporting.WinForms.ReportParameter("pTotalApplyedDis", _transaction.Price.ToString() + "₫")
            };
            return list;
        }
    }
}
