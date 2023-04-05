using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PhoneStoreManagement.DTO
{
    public class DTO_Receipt
    {
        private int _IDPhone;
        private string _NamePhone;
        private int _Quantity;
        private int _Price;
        private int _Total;

        public int IDPhone { get => _IDPhone; set => _IDPhone = value; }
        public string NamePhone { get => _NamePhone; set => _NamePhone = value; }
        public int Quantity { get => _Quantity; set => _Quantity = value; }
        public int Price { get => _Price; set => _Price = value; }
        public int Total { get => _Total; set => _Total = value; }
    }
}
