using PagedList;
using PhoneStoreManagement.DAL;
using PhoneStoreManagement.DTO;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace PhoneStoreManagement.BLL
{
    class BLL_UCListImport
    {
        private static BLL_UCListImport _Instance;
        public static BLL_UCListImport Instance
        {
            get
            {
                if (_Instance == null)
                {
                    _Instance = new BLL_UCListImport();
                }
                return _Instance;
            }
            private set { }
        }
        public async Task<IPagedList<DTO_ListImport>> GetListImport(DateTime fromDate, DateTime toDate, string namePhone, int pageNumber = 1, int pageSize = 10)
        {
            return await Task.Factory.StartNew(() =>
            {
                using (DBManagement db = new DBManagement())
                {
                    List<DTO_ListImport> list = new List<DTO_ListImport>();
                    list = db.ImportManagements
                        .Where(p => p.ImportDate >= fromDate && p.ImportDate <= toDate && p.Phone.NamePhone.Contains(namePhone))
                        .Select(p => new DTO_ListImport
                        {
                            IdImport = p.IDImManagement,
                            NameEmployee = p.Employee.NameEmployee,
                            NamePhone = p.Phone.NamePhone,
                            Quantity = p.Quantity,
                            DateImport = p.ImportDate,
                            Price = p.UnitPrice * p.Quantity,
                        }).ToList();
                    return list.ToPagedList(pageNumber, pageSize);
                }
            });
        }
    }
}
