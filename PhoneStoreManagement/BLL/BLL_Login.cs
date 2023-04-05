using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using static System.Windows.Forms.VisualStyles.VisualStyleElement.StartPanel;
using System.Windows.Forms;
using PhoneStoreManagement.DAL;
using PhoneStoreManagement.UserControls;
using System.Security.Cryptography;
using PhoneStoreManagement.DTO;

namespace PhoneStoreManagement.BLL
{
    public class BLL_Login
    {
        private string _UserName;
        private string _Password;
        private static BLL_Login _Instance;
        private BLL_Login()
        {

        }
        public static BLL_Login Instance
        {
            get
            {
                if(_Instance == null)
                {
                    _Instance = new BLL_Login();
                }
                return _Instance;
            }
            private set { }
        }

        public string UserName { get => _UserName; set => _UserName = value; }
        public string Password { get => _Password; set => _Password = value; }
        public void SetInfoAccount(string userName, string passWord)
        {
            _UserName = userName;
            _Password = passWord;
        }
        public bool CheckLogin()
        {
            try
            {
                using (var db = new DBManagement())
                {
                    if (_UserName == "" || _Password == "")
                    {
                        MessageBox.Show("Đăng nhập không thành công", "Đăng nhập"); return false;
                    }
                    var UserName = db.Accounts.SingleOrDefault(p => p.UserName == _UserName);
                    if (UserName == null)
                    {
                        MessageBox.Show("Tên đăng nhập không tồn tại", "Đăng nhập"); return false;
                    }
                    string hashedPassword = hashPassword(_Password);
                    Account Account = db.Accounts.SingleOrDefault(p => p.UserName == _UserName && p.Password == hashedPassword);
                    if (Account == null)
                    {
                        MessageBox.Show("Mật khẩu đăng nhập không hợp lệ", "Đăng nhập"); return false;
                    }
                    else
                    {
                        MessageBox.Show("Đăng nhập thành công", "Đăng nhập");
                    }
                    Role Role = db.Roles.SingleOrDefault(p => p.IDRole == Account.IDRole);
                    if (Role.NameRole == "Admin")
                    {
                        FormAdmin formAdmin = new FormAdmin();
                        formAdmin.Show();
                    }
                    else if (Role.NameRole == "Saler")
                    {
                        FormSaler formSaler = new FormSaler();
                        formSaler.Show();
                    }
                    else if (Role.NameRole == "Warehouse Manager")
                    {
                        FormWhManager formWhManager = new FormWhManager();
                        formWhManager.Show();
                    }
                    return true;
                }
            }
            catch(Exception ex)
            {
                MessageBox.Show("Đăng nhập không thành công", "Đăng nhập");
                return false;
            }
        }
        public bool Register(string userName, string passWord, string ac_passWord, string email, DTO_Role dto_role, string idEmployee, string txtCheckAdmin)
        {
            using (var db = new DBManagement())
            {
                if (userName == "" || userName == "" || ac_passWord == "" || dto_role == null  || idEmployee == null)
                {
                    MessageBox.Show("Chưa điền đầy đủ thông tin", "Đăng kí"); 
                    return false;
                }
                bool isExistUserName = db.Accounts.SingleOrDefault(p => p.UserName.Equals(userName)) == null ? true : false;
                if (!isExistUserName)
                {
                    MessageBox.Show("Đã tồn tại tên tài khoản này!", "Đăng kí"); return false;
                }
                if (ac_passWord != passWord)
                {
                    MessageBox.Show("Không trùng khớp mật khẩu", "Đăng kí"); return false;
                }
                Role role = db.Roles.SingleOrDefault(p => p.IDRole == dto_role.IDRole);
                if (txtCheckAdmin != "9999" && role.NameRole == "Admin")
                {
                    MessageBox.Show("Xác nhận admin không hợp lệ", "Đăng kí"); return false;
                }
                string hashedPassword = hashPassword(passWord);
                var newAccount = new Account
                {
                    UserName = userName,
                    Password = hashedPassword,
                    Email = email,
                    IDRole = dto_role.IDRole,
                    IDEmployee = Convert.ToInt32(idEmployee)
                };
                Employee checkIDEmployee = db.Employees.SingleOrDefault(p => p.IDEmployee.ToString() == idEmployee);
                if (checkIDEmployee == null)
                {
                    MessageBox.Show("Không tồn tại mã nhân viên này", "Đăng kí"); return false;
                }
                db.Accounts.Add(newAccount);
                db.SaveChanges();
                return true;
            }
        }
        public string hashPassword(string password)
        {
            var sha = SHA256.Create();
            var asByteArray = Encoding.Default.GetBytes(password);
            var hashedPassword = sha.ComputeHash(asByteArray);
            return Convert.ToBase64String(hashedPassword);
        }
        public Account GetAccount()
        {
            using (var db = new DBManagement())
            {
                string hashedPassword = hashPassword(Password);
                Account account = db.Accounts.SingleOrDefault(p => p.UserName == UserName && p.Password == hashedPassword);
                return account;
            }
        }
    }
}
