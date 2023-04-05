using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PhoneStoreManagement.DTO
{
    public class DTO_InfoOrdered
    {
        private int _IDOrder;
        private string _NameCustomer;
        private string _PhoneCustomer;
        private string _AddressCustomer;
        private int _IDEmployeeCreate;
        private string _IDEmployeeEdit;
        private DateTime _TimeOrder;
        private string _ValueDiscount;
        private string _Total;
        private DTO_TypeOrder _TypeOrder;
        private DTO_State _StateOrder;

        public int IDOrder { get => _IDOrder; set => _IDOrder = value; }
        public string NameCustomer { get => _NameCustomer; set => _NameCustomer = value; }
        public string PhoneCustomer { get => _PhoneCustomer; set => _PhoneCustomer = value; }
        public string AddressCustomer { get => _AddressCustomer; set => _AddressCustomer = value; }
        public int IDEmployeeCreate { get => _IDEmployeeCreate; set => _IDEmployeeCreate = value; }
        public string IDEmployeeEdit { get => _IDEmployeeEdit; set => _IDEmployeeEdit = value; }
        public DateTime TimeOrder { get => _TimeOrder; set => _TimeOrder = value; }

        public string ValueDiscount { get => _ValueDiscount; set => _ValueDiscount = value; }
        public string Total { get => _Total; set => _Total = value; }
        public DTO_TypeOrder TypeOrder { get => _TypeOrder; set => _TypeOrder = value; }
        public DTO_State StateOrder { get => _StateOrder; set => _StateOrder = value; }
    }
}
