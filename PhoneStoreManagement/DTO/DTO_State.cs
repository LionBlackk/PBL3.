using PhoneStoreManagement.DAL;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PhoneStoreManagement.DTO
{
    public class DTO_State
    {
        private int _IDState;
        private string _NameState;

        public int IDState { get => _IDState; set => _IDState = value; }
        public string NameState { get => _NameState; set => _NameState = value; }

        public override string ToString()
        {
            return NameState;
        }

        public override bool Equals(object obj)
        {
            var item = obj as DTO_State;
            if (item == null) return false;
            return item.IDState == IDState;
        }
    }
}
