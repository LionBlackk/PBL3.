using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PhoneStoreManagement.DTO
{
    public class DTO_Brand
    {
        private string _IDBrand;
        private string _NameBrand;

        public string IDBrand { get => _IDBrand; set => _IDBrand = value; }
        public string NameBrand { get => _NameBrand; set => _NameBrand = value; }
        public override string ToString()
        {
            return _NameBrand;
        }
    }
}
