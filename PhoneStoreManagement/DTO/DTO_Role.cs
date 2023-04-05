using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PhoneStoreManagement.DTO
{
    public class DTO_Role
    {
        private int _IDRole;
        private string _NameRole;

        public int IDRole { get => _IDRole; set => _IDRole = value; }
        public string NameRole { get => _NameRole; set => _NameRole = value; }

        public override string ToString()
        {
            return _NameRole;
        }
    }
}
