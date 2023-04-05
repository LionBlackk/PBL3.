using PhoneStoreManagement.DAL;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;

namespace PhoneStoreManagement.BLL
{
    public class BLL_ChangePassword
    {
        private static BLL_ChangePassword _Instance;
        private BLL_ChangePassword()
        {

        }

        public static BLL_ChangePassword Instance
        {
            get
            {
                if (_Instance == null)
                {
                    _Instance = new BLL_ChangePassword();
                }
                return _Instance;
            }
            private set { }
        }
        public bool ConfirmPassword(string UserName, string OldPassword, string NewPassword)
        {
            if (UserName == "" || OldPassword == "" || NewPassword == "")
            {
                MessageBox.Show("Chưa nhập đủ thông tin", "Vui lòng nhập lại"); return false;
            }
            using (var db = new DBManagement())
            {
                Account account = db.Accounts.SingleOrDefault(p => p.UserName == UserName);
                string hashedOldPassword = BLL_Login.Instance.hashPassword(OldPassword);
                if (account == null)
                {
                    MessageBox.Show("Tên tài khoản không hợp lệ", "Vui lòng nhập lại"); return false;
                }
                else
                {
                    if (!account.Password.Equals(hashedOldPassword))
                    {
                        MessageBox.Show("Mật khẩu không hợp lệ", "Vui lòng nhập lại"); return false;
                    }
                }
                string hashedNewPassword = BLL_Login.Instance.hashPassword(NewPassword);
                account.Password = hashedNewPassword;
                BLL_Login.Instance.UserName = UserName;
                BLL_Login.Instance.Password = NewPassword;
                db.SaveChanges();
                MessageBox.Show("Đổi mật khẩu thành công", "Đổi mật khẩu");
                return true;
            }
        }
    }
}
