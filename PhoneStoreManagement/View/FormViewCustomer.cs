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
using System.Text;
using System.Threading.Tasks;
using System.Windows.Controls;
using System.Windows.Forms;

namespace PhoneStoreManagement
{
    public partial class FormViewCustomer : Form
    {
        IPagedList<DTO_Customer> list;
        int pageNumber = 1;
        public FormViewCustomer()
        {
            InitializeComponent();
            showDGV("");
        }
        public async void showDGV(string NameCustomer)
        {
            list = await BLL_StatisticsAdmin.Instance.GetListCustomers(NameCustomer);
            btnPrevious.Enabled = list.HasPreviousPage;
            btnNext.Enabled = list.HasNextPage;
            dataGridView1.DataSource = list.ToList();
            lbPageNumber.Text = string.Format("Trang {0}/{1}", pageNumber, list.PageCount);
        }
        private async void btnPrevious_Click(object sender, EventArgs e)
        {
            if (list.HasPreviousPage)
            {
                list = await BLL_StatisticsAdmin.Instance.GetListCustomers(txtSearch.Text,--pageNumber);
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
                list = await BLL_StatisticsAdmin.Instance.GetListCustomers(txtSearch.Text, ++pageNumber);
                btnPrevious.Enabled = list.HasPreviousPage;
                btnNext.Enabled = list.HasNextPage;
                dataGridView1.DataSource = list.ToList();
                lbPageNumber.Text = string.Format("Trang {0}/{1}", pageNumber, list.PageCount);
            }
        }

        private void btnSearch_Click(object sender, EventArgs e)
        {
            showDGV(txtSearch.Text);
        }
    }
}
