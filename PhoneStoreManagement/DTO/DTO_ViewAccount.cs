using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PhoneStoreManagement.DTO
{
    class DTO_ViewAccount
    {
        public int IdAccount { get; set; }
        public string UserName { get; set; }
        public string Password { get; set; }
        public string Email { get; set; }
        public string Employee { get; set; }
        public string Role { get; set; }
    }
}
