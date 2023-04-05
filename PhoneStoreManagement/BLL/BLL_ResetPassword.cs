using PhoneStoreManagement.DAL;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;

namespace PhoneStoreManagement.BLL
{
    public class BLL_ResetPassword
    {
        private static BLL_ResetPassword _Instance;
        private BLL_ResetPassword()
        {

        }

        public static BLL_ResetPassword Instance
        {
            get
            {
                if (_Instance == null)
                {
                    _Instance = new BLL_ResetPassword();
                }
                return _Instance;
            }
            private set { }
        }
        public bool ConfirmPassword(string UserName, string NewPassword, string ConfirmPassword)
        {
            if (UserName == "" || NewPassword == "" || ConfirmPassword == "")
            {
                MessageBox.Show("Vui lòng nhập đầy đủ thông tin", "Xác nhận"); return false;
            }
            DBManagement db = new DBManagement();
            Account account = db.Accounts.SingleOrDefault(p => p.UserName.Equals(UserName));
            if (account == null)
            {
                MessageBox.Show("Không tìm thấy tên tài khoản", "Xác nhận"); return false;
            }
            if (!NewPassword.Equals(ConfirmPassword))
            {
                MessageBox.Show("Không trùng khớp mật khẩu","Xác nhận"); return false;
            }
            account.Password = BLL_Login.Instance.hashPassword(NewPassword);
            db.SaveChanges();
            MessageBox.Show("Thay đổi mật khẩu thành công", "Xác nhận"); return true;
        }
    }
}
