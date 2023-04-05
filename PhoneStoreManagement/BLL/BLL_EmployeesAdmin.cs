using PagedList;
using PhoneStoreManagement.DAL;
using PhoneStoreManagement.DTO;
using System;
using System.Collections.Generic;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace PhoneStoreManagement.BLL
{
    class BLL_EmployeesAdmin
    {
        private static BLL_EmployeesAdmin _Instance;
        public static BLL_EmployeesAdmin Instance
        {
            get
            {
                if (_Instance == null)
                {
                    _Instance = new BLL_EmployeesAdmin();
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
        public string getRoleById(int id)
        {
            DBManagement db = new DBManagement();
            string NameRole = "";
            int countRole = BLL_AccountsAdmin.Instance.getListAccByID(id).Count;
            if (countRole > 0)
            {
                foreach (Account acc in db.Accounts.Where(p => p.IDEmployee == id))
                {
                    if (NameRole == "")
                    {
                        NameRole = acc.Role.NameRole;
                    }
                    else
                    {
                        if (acc.Role.NameRole == "Admin")
                        {
                            if (!NameRole.Contains("Admin"))
                            {
                                NameRole = acc.Role.NameRole + ", " + NameRole;
                            }
                        }
                        else
                        {
                            NameRole = NameRole + ", " + acc.Role.NameRole;
                        }
                    }
                }
            }
            else
            {
                NameRole = "Chưa Xác Định";
            }
            return NameRole;
        }
        public Image getPicture(Employee employee)
        {
            using (DBManagement db = new DBManagement())
            {
                MemoryStream ms = new MemoryStream(employee.Picture.ToArray());
                Image image = Image.FromStream(ms);
                return image;
            }
        }
        public void setPicture(Employee employee, PictureBox picture)
        {
            using (DBManagement db = new DBManagement())
            {
                MemoryStream ms = new MemoryStream(employee.Picture.ToArray());
                Image image = Image.FromStream(ms);
                picture.Image = image;
            }
        }
        public async Task<IPagedList<DTO_ViewEmployee>> getListEmployee(string Role, string Name, int pageNumber = 1, int pageSize = 5)
        {
            return await Task.Factory.StartNew(() =>
            {
                List<DTO_ViewEmployee> data = new List<DTO_ViewEmployee>();
                DBManagement db = new DBManagement();
                string nameRole;
                if (Role == "ALL")
                {
                    var list = db.Employees.Where(p => p.NameEmployee.Contains(Name));
                    foreach (var emp in list)
                    {
                        nameRole = getRoleById(emp.IDEmployee);
                        DTO_ViewEmployee view = new DTO_ViewEmployee
                        {
                            ID_Employee = emp.IDEmployee,
                            FullName = emp.NameEmployee,
                            BirthDay = (DateTime)emp.BirthDay,
                            Gender = (bool)emp.Gender,
                            Address = emp.Address,
                            Phone = emp.Phone,
                            Picture = getPicture(emp),
                            Role = nameRole
                        };
                        data.Add(view);
                    }
                }

                else if (Role != "ALL")
                {
                    var l2 = db.Accounts.Where(p => p.Role.NameRole == Role && p.Employee.NameEmployee.Contains(Name));
                    List<int> IDEmployees = new List<int>();
                    foreach (Account i in l2.ToList())
                    {
                        IDEmployees.Add(i.IDEmployee);
                    }
                    foreach (int i in IDEmployees)
                    {
                        Employee employee = getEmpByID(i);
                        nameRole = getRoleById(i);
                        DTO_ViewEmployee view = new DTO_ViewEmployee
                        {
                            ID_Employee = employee.IDEmployee,
                            FullName = employee.NameEmployee,
                            BirthDay = (DateTime)employee.BirthDay,
                            Gender = (bool)employee.Gender,
                            Address = employee.Address,
                            Phone = employee.Phone,
                            Picture = getPicture(employee),
                            Role = nameRole,
                        };
                        data.Add(view);
                    }
                }
                return data.ToPagedList(pageNumber, pageSize);
            });
        }
        public Employee getEmpByID(int id)
        {
            using (DBManagement db = new DBManagement())
            {

                Employee data = new Employee();
                foreach (Employee i in db.Employees)
                {
                    if (i.IDEmployee == id)
                    {
                        data = i;
                        return data;
                    }
                }
            }
            return null;
        }
        public void addorupdateEmployee(Employee s)
        {
            using (DBManagement db = new DBManagement())
            {
                var l1 = db.Employees.Where(p => p.IDEmployee == s.IDEmployee).FirstOrDefault();
                if (l1 != null)
                {
                    l1.NameEmployee = s.NameEmployee;
                    l1.Gender = s.Gender;
                    l1.BirthDay = s.BirthDay;
                    l1.Address = s.Address;
                    l1.Phone = s.Phone;
                    l1.Email = s.Email;
                    l1.Picture = s.Picture;
                    db.SaveChanges();
                }
                else
                {
                    db.Employees.Add(s);
                    db.SaveChanges();
                }
            }
        }
        public bool checkExistEmpInAccount(Employee employee)
        {
            using (DBManagement db = new DBManagement())
            {
                var list = db.Accounts.Where(p => p.IDEmployee == employee.IDEmployee);
                return list.Any();
            }
        }
        public bool checkExistEmpInOrder(Employee employee)
        {
            using (DBManagement db = new DBManagement())
            {
                string nameRole = getRoleById(employee.IDEmployee);
                var list = db.Order_.Where(p => (p.IDEmployeeCreate == employee.IDEmployee || p.IDEmployeeEdit == employee.IDEmployee) && nameRole.Contains("Saler"));
                return list.Any();
            }
        }
        public bool checkExistEmpInImport(Employee employee)
        {
            using (DBManagement db = new DBManagement())
            {
                string nameRole = getRoleById(employee.IDEmployee);
                var list = db.ImportManagements.Where(p => p.IDImManagement == employee.IDEmployee && nameRole.Contains("Warehouse Manager"));
                return list.Any();
            }
        }
        /* public Employee FindEmployee(int id)
         {
             using(DBManagement db = new DBManagement())
             {
                 foreach(Employee e in db.Employees)
                 {
                     if (e.i)
                 }
             }
         }*/
        public void deleteEmp_BLL(List<int> del)
        {
            using (DBManagement db = new DBManagement())
            {
                foreach (int i in del)
                {
                    var employee = db.Employees.FirstOrDefault(p => p.IDEmployee == i);
                    if (checkExistEmpInAccount(employee))
                    {
                        MessageBox.Show("Vui lòng xoá tài khoản của nhân viên này trước", "Warning");
                        break;
                    }
                    else if (checkExistEmpInOrder(employee))
                    {
                        MessageBox.Show("Nếu muốn xoá, bạn phải sửa thông tin các đơn hàng liên quan đến người này", "Warning");
                        break;
                    }
                    else if (checkExistEmpInImport(employee))
                    {
                        MessageBox.Show("Nếu muốn xoá, bạn phải sửa thông tin các đơn nhập liên quan đến người này", "Warning");
                        break;
                    }
                    else
                    {
                        var s = db.Employees.Where(p => p.IDEmployee == i).FirstOrDefault();
                        db.Employees.Remove(s);
                        db.SaveChanges();
                    }
                }
            }
        }
    }
}
