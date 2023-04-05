using PagedList;
using PhoneStoreManagement.BLL;
using PhoneStoreManagement.DAL;
using PhoneStoreManagement.DTO;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Security.Principal;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Controls;
using System.Windows.Forms;

namespace PhoneStoreManagement.UserControls
{
    public partial class UC_InfoOrdered : System.Windows.Forms.UserControl
    {
        IPagedList<DTO_InfoOrdered> list;
        int pageNumber = 1;
        public UC_InfoOrdered()
        {
            InitializeComponent();
            ShowListOrdered(BLL_Login.Instance.GetAccount());
        }
        private async void ShowListOrdered(Account account, string phone = null)
        {
            pageNumber = 1;
            list = await BLL_InfoOrdered.Instance.GetInfoOrdered(account,phone);
            btnPrevious.Enabled = list.HasPreviousPage;
            btnNext.Enabled = list.HasNextPage;
            dataGridView1.DataSource = list.ToList();
            lbPageNumber.Text = string.Format("Trang {0}/{1}", pageNumber, list.PageCount);
        }

        private void btnFindOrder_Click(object sender, EventArgs e)
        {
            string Phone = txtPhoneCustomer.Text.Trim();
            Account account = BLL_Login.Instance.GetAccount();
            ShowListOrdered(account, Phone);
            dataGridView1.Refresh();
        }

        private async void btnPrevious_Click(object sender, EventArgs e)
        {
            if (list.HasPreviousPage)
            {
                string Phone = txtPhoneCustomer.Text.Trim();
                Account account = BLL_Login.Instance.GetAccount();
                list = await BLL_InfoOrdered.Instance.GetInfoOrdered(account, Phone, --pageNumber);
                btnPrevious.Enabled = list.HasPreviousPage;
                btnNext.Enabled = list.HasNextPage;
                dataGridView1.DataSource = list.ToList();
                lbPageNumber.Text = string.Format("Trang {0}/{1}", pageNumber, list.PageCount);
            }
        }

        private async void btnNext_Click(object sender, EventArgs e)
        {
            if (list.HasNextPage)
            {
                string Phone = txtPhoneCustomer.Text.Trim();
                Account account = BLL_Login.Instance.GetAccount();
                list = await BLL_InfoOrdered.Instance.GetInfoOrdered(account, Phone, ++pageNumber);
                btnPrevious.Enabled = list.HasPreviousPage;
                btnNext.Enabled = list.HasNextPage;
                dataGridView1.DataSource = list.ToList();
                lbPageNumber.Text = string.Format("Trang {0}/{1}", pageNumber, list.PageCount);
            }
        }
    }
}
