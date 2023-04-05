using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PhoneStoreManagement.DTO
{
    class DTO_ListImport
    {
        public int IdImport { get; set; }
        public string NameEmployee { get; set; }
        public string NamePhone { get; set; }
        public int Quantity { get; set; }
        public DateTime DateImport { get; set; }
        public int Price { get; set; }
    }
}
