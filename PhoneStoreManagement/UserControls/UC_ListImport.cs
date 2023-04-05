using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using PagedList;
using PhoneStoreManagement.BLL;
using PhoneStoreManagement.DAL;
using PhoneStoreManagement.DTO;

namespace PhoneStoreManagement.UserControls
{
    public partial class UC_ListImport : UserControl
    {
        IPagedList<DTO_ListImport> list;
        int pageNumber = 1;
        public UC_ListImport()
        {
            InitializeComponent();
            dateStart.Value = new DateTime(2020, 1, 1);
            ShowDGV(new DateTime(2020, 1, 1), DateTime.Now, "");
        }
        public bool checkTimeOrder()
        {
            if (dateStart.Value > dateEnd.Value)
            {
                return false;
            }
            else
            {
                return true;
            }
        }
        public async void ShowDGV(DateTime fromDate, DateTime toDate, string phoneName)
        {
            if (BLL_UCListImport.Instance.GetListImport(fromDate, toDate, phoneName) != null)
            {
                pageNumber = 1;
                list = await BLL_UCListImport.Instance.GetListImport(fromDate, toDate, phoneName);
                btnPrevious.Enabled = list.HasPreviousPage;
                btnNext.Enabled = list.HasNextPage;
                dataGridView1.DataSource = list.ToList();
                lbPageNumber.Text = string.Format("Trang {0}/{1}", pageNumber, list.PageCount);
            }
        }
        private void btnSearch_Click(object sender, EventArgs e)
        {
            if (checkTimeOrder())
            {
                ShowDGV(dateStart.Value, dateEnd.Value, txtSearch.Text);
            }
            else
            {
                MessageBox.Show("Lỗi khoảng thời gian tìm kiếm", "Error");
            }
        }

        private async void btnPrevious_Click(object sender, EventArgs e)
        {
            if (list.HasPreviousPage)
            {
                list = await BLL_UCListImport.Instance.GetListImport(dateStart.Value, dateEnd.Value, txtSearch.Text, --pageNumber);
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
                list = await BLL_UCListImport.Instance.GetListImport(dateStart.Value, dateEnd.Value, txtSearch.Text, ++pageNumber);
                btnPrevious.Enabled = list.HasPreviousPage;
                btnNext.Enabled = list.HasNextPage;
                dataGridView1.DataSource = list.ToList();
                lbPageNumber.Text = string.Format("Trang {0}/{1}", pageNumber, list.PageCount);
            }
        }
    }
}
