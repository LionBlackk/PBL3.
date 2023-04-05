using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PhoneStoreManagement.DTO
{
    class DTO_ViewEmployee
    {
        public int ID_Employee { get; set; }
        public string FullName { get; set; }
        public DateTime BirthDay { get; set; }
        public bool Gender { get; set; }
        public string Address { get; set; }
        public string Phone { get; set; }
        public string Role { get; set; }
        public Image Picture { get; set; }
    }
}
