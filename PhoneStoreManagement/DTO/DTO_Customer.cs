using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PhoneStoreManagement.DTO
{
    class DTO_Customer
    {
        public int IDCustomer { get; set; }
        public string NameCustomer { get; set; }
        public string Address { get; set; }
        public string Phone { get; set; }
        public int NumberOfOrder { get; set; }
    }
}
