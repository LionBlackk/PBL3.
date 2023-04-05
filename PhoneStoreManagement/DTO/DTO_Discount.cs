using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PhoneStoreManagement.DTO
{
    public class DTO_Discount
    {
        private int _IDDiscount;
        private int _ValueDiscount;

        public int IDDiscount { get => _IDDiscount; set => _IDDiscount = value; }
        public int ValueDiscount { get => _ValueDiscount; set => _ValueDiscount = value; }
        public override string ToString()
        {
            return _ValueDiscount + "%";
        }
        public override bool Equals(object obj)
        {
            var item = obj as DTO_Discount;
            if (item == null) return false;
            return item.IDDiscount == IDDiscount;   
        }
    }
}
