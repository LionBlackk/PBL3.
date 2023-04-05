using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PhoneStoreManagement.DTO
{
    public class DTO_Category
    {
        private int _IDCategory;
        private string _NameCategory;

        public int IDCategory { get => _IDCategory; set => _IDCategory = value; }
        public string NameCategory { get => _NameCategory; set => _NameCategory = value; }
        public override string ToString()
        {
            return _NameCategory;
        }
    }
}
