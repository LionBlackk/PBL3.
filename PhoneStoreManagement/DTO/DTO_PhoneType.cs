using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PhoneStoreManagement.DTO
{
    public class DTO_PhoneType
    {
        private int _IDPhoneType;
        private string _PhoneTypeName;
        private int _IDCategory;
        public int IDPhoneType { get => _IDPhoneType; set => _IDPhoneType = value; }
        public string PhoneTypeName { get => _PhoneTypeName; set => _PhoneTypeName = value; }
        public int IDCategory { get => _IDCategory; set => _IDCategory = value; }

        public override string ToString()
        {
            return PhoneTypeName;
        }
    }
}
