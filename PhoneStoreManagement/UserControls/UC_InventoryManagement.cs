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
using System.Xml.Linq;

namespace PhoneStoreManagement.UserControls
{
    public partial class UC_InventoryManagement : System.Windows.Forms.UserControl
    {
        IPagedList<DTO_Inventory> list;
        int pageNumber = 1;
        public UC_InventoryManagement()
        {
            InitializeComponent();
            showDGV("");
        }
        public async void showDGV(string name)
        {
            if (BLL_InventoryManagement.Instance.getListInventory(name) != null)
            {
                pageNumber = 1;
                list = await BLL_InventoryManagement.Instance.getListInventory(name);
                btnPrevious.Enabled = list.HasPreviousPage;
                btnNext.Enabled = list.HasNextPage;
                dataGridView1.DataSource = list.ToList();
                lbPageNumber.Text = string.Format("Trang {0}/{1}", pageNumber, list.PageCount);
            }
        }
        private void btnSearch_Click(object sender, EventArgs e)
        {
            showDGV(txbSearch.Text);
        }

        private async void btnPrevious_Click(object sender, EventArgs e)
        {
            if (list.HasPreviousPage)
            {
                list = await BLL_InventoryManagement.Instance.getListInventory(txbSearch.Text, --pageNumber);
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
                list = await BLL_InventoryManagement.Instance.getListInventory(txbSearch.Text, ++pageNumber);
                btnPrevious.Enabled = list.HasPreviousPage;
                btnNext.Enabled = list.HasNextPage;
                dataGridView1.DataSource = list.ToList();
                lbPageNumber.Text = string.Format("Trang {0}/{1}", pageNumber, list.PageCount);
            }
        }
    }
}
