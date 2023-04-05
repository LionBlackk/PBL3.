using PagedList;
using PhoneStoreManagement.DAL;
using PhoneStoreManagement.DTO;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;

namespace PhoneStoreManagement.BLL
{
    class BLL_AccountsAdmin
    {
        private static BLL_AccountsAdmin _Instance;
        public static BLL_AccountsAdmin Instance
        {
            get
            {
                if (_Instance == null)
                {
                    _Instance = new BLL_AccountsAdmin();
                }
                return _Instance;
            }
            private set { }
        }
        public List<DTO_Role> GetCBBRole()
        {
            using (DBManagement db = new DBManagement())
            {
                List<DTO_Role> list = new List<DTO_Role>();
                list.Add(new DTO_Role
                {
                    IDRole = 0,
                    NameRole = "ALL"
                });
                foreach (Role i in db.Roles)
                {
                    list.Add(new DTO_Role
                    {
                        IDRole = i.IDRole,
                        NameRole = i.NameRole
                    });
                }
                return list;
            }
        }
        public List<DTO_Role> setCBBRole()
        {
            using (DBManagement db = new DBManagement())
            {
                List<DTO_Role> list = new List<DTO_Role>();
                foreach (Role i in db.Roles)
                {
                    list.Add(new DTO_Role
                    {
                        IDRole = i.IDRole,
                        NameRole = i.NameRole
                    });
                }
                return list;
            }
        }
        public async Task<IPagedList<DTO_ViewAccount>> getListAccount(string Role, string Name,int pageNumber = 1, int pageSize = 10)
        {
            return await Task.Factory.StartNew(() =>
            {
                List<DTO_ViewAccount> data = new List<DTO_ViewAccount>();
                DBManagement db = new DBManagement();
                if (Role == "ALL")
                {
                    data = db.Accounts.Where(p => p.Employee.NameEmployee.Contains(Name))
                        .Select(p => new DTO_ViewAccount { IdAccount = p.IDAccount, UserName = p.UserName, Password = p.Password, Email = p.Email, Employee = p.Employee.NameEmployee, Role = p.Role.NameRole })
                        .ToList();
                }

                else if (Role != "ALL")
                {
                    data = db.Accounts.Where(p => p.Role.NameRole.Contains(Role) && p.Employee.NameEmployee.Contains(Name)).
                                 Select(p => new DTO_ViewAccount { IdAccount = p.IDAccount, UserName = p.UserName, Password = p.Password, Email = p.Email, Employee = p.Employee.NameEmployee, Role = p.Role.NameRole })
                        .ToList();
                }
                return data.ToPagedList(pageNumber, pageSize);
            });
        }
        public Account getAccByID(int id)
        {
            Account data = new Account();
            using (DBManagement db = new DBManagement())
            {
                foreach (Account i in db.Accounts)
                {
                    if (i.IDAccount == id)
                    {
                        data = i;
                        return data;
                    }
                }
            }
            return null;
        }
        public List<Account> getListAccByID(int id)
        {
            List<Account> data = new List<Account>();
            using (DBManagement db = new DBManagement())
            {
                foreach (Account i in db.Accounts)
                {
                    if (i.IDEmployee == id)
                    {
                        data.Add(i);
                    }
                }
            }
            return data;
        }
        public bool checkIdEmployee(int id)
        {
            using (DBManagement db = new DBManagement())
            {
                Employee e = db.Employees.Where(p => p.IDEmployee == id).SingleOrDefault();
                if (e == null)
                {
                    return false;
                }
                else
                {
                    return true;

                }
            }
        }
        public void AddorUpdateAccount(Account acc)
        {
            using (DBManagement db = new DBManagement())
            {
                var list = db.Accounts.Where(p => p.IDAccount == acc.IDAccount).FirstOrDefault();
                if (list != null)
                {
                    list.UserName = acc.UserName;
                    list.Password = (acc.Password != null && acc.Password != "") ? acc.Password : BLL_Login.Instance.hashPassword("123456");
                    list.Email = acc.Email;
                    list.IDRole = acc.IDRole;
                    list.IDEmployee = acc.IDEmployee;
                    db.SaveChanges();
                }
                else
                {
                    acc.Password = BLL_Login.Instance.hashPassword(acc.Password);
                    db.Accounts.Add(acc);
                    db.SaveChanges();
                }
            }
        }

        public void deleteAccount_BLL(List<int> del)
        {
            using (DBManagement db = new DBManagement())
            {
                foreach (int i in del)
                {
                    var s = db.Accounts.Where(p => p.IDAccount == i).FirstOrDefault();
                    db.Accounts.Remove(s);
                    db.SaveChanges();
                }
            }
        }
    }
}
