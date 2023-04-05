using PhoneStoreManagement.DAL;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PhoneStoreManagement.DTO
{
    public class DTO_TypeOrder
    {
        private int _IDTypeOrder;
        private string _NameTypeOrder;

        public int IDTypeOrder { get => _IDTypeOrder; set => _IDTypeOrder = value; }
        public string NameTypeOrder { get => _NameTypeOrder; set => _NameTypeOrder = value; }
        public override string ToString()
        {
            return _NameTypeOrder;
        }
        public override bool Equals(object obj)
        {
            var item = obj as DTO_TypeOrder;
            if (item == null) return false;
            return item.IDTypeOrder == IDTypeOrder;
        }
    }
}
