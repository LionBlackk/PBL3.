using PhoneStoreManagement.DAL;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Mail;
using System.Net;
using System.Text;
using System.Threading.Tasks;
using System.Windows;

namespace PhoneStoreManagement.BLL
{
    public class BLL_ForgotPassword
    {
        private static BLL_ForgotPassword _Instance;
        private string randomCode;
        private BLL_ForgotPassword()
        {

        }

        public static BLL_ForgotPassword Instance 
        {
            get
            {
                if(_Instance == null)
                {
                    _Instance = new BLL_ForgotPassword(); 
                }
                return _Instance;
            }
            private set { }
        }

        public void SendEmail(string UserName, string Email)
        {
            if (UserName == "" || Email == "")
            {
                MessageBox.Show("Vui lòng nhập đầy đủ thông tin", "Gửi mã"); return;
            }
            DBManagement db = new DBManagement();
            Account account = db.Accounts.SingleOrDefault(p => p.UserName.Equals(UserName));
            if (account == null)
            {
                MessageBox.Show("Tên tài khoản hoặc Email không hợp lệ", "Gửi mã"); return;
            }
            Employee employee = db.Employees.SingleOrDefault(p => p.Email.Equals(Email) && account.IDEmployee == p.IDEmployee);
            if (employee == null)
            {
                MessageBox.Show("Tên tài khoản hoặc Email không hợp lệ", "Gửi mã"); return;
            }

            String from, to, pass, messageBody;
            Random rand = new Random();
            randomCode = (rand.Next(999999)).ToString();
            MailMessage message = new MailMessage();
            to = (Email).ToString();
            from = "lehoanglinh1051995@gmail.com";
            pass = "mxwsjbpddbiiqcai";
            messageBody = "Mã OTP của bạn là: " + randomCode;
            message.To.Add(to);
            message.From = new MailAddress(from);
            message.Body = messageBody;
            message.Subject = "Password Reseting Code";
            SmtpClient smtp = new SmtpClient("smtp.gmail.com");
            smtp.EnableSsl = true;
            smtp.Port = 587;
            smtp.DeliveryMethod = SmtpDeliveryMethod.Network;
            smtp.Credentials = new NetworkCredential(from, pass);

            try
            {
                smtp.Send(message);
                MessageBox.Show("Đã gửi mã thành công", "Gửi mã");
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }
        public bool Verify(string txtVerify)
        {
            if (txtVerify == "")
            {
                MessageBox.Show("Vui lòng nhập mã xác nhận", "Xác minh"); return false;
            }
            if (randomCode.Equals((txtVerify)))
            {
                FormResetPassword form = new FormResetPassword();
                form.ShowDialog();
                return true;
            }
            else
            {
                MessageBox.Show("Nhập mã sai", "Xác minh"); return false;
            }
        }
    }
}
