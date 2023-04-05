using PhoneStoreManagement.DAL;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PhoneStoreManagement.DTO
{
    public class DTO_InfoOrder
    {
        private int _IDPhone;
        private byte[] _Picture;
        private string _NamePhone;
        private string _NameBrand;
        private int _Price;
        private int _Quantity;

        public int IDPhone { get => _IDPhone; set => _IDPhone = value; }
        public byte[] Picture { get => _Picture; set => _Picture = value; }
        public string NamePhone { get => _NamePhone; set => _NamePhone = value; }
        public string NameBrand { get => _NameBrand; set => _NameBrand = value; }
        public int Price { get => _Price; set => _Price = value; }
        public int Quantity { get => _Quantity; set => _Quantity = value; }
    }
}
