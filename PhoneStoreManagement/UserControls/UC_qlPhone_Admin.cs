using PhoneStoreManagement.BLL;
using PhoneStoreManagement;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using PhoneStoreManagement.DAL;
using System.Windows.Documents;
using PagedList;
using PhoneStoreManagement.DTO;

namespace BookShopManagement.UserControls
{
    public partial class UC_qlPhone_Admin : UserControl
    {
        IPagedList<DTO_ViewPhone> list;
        int pageNumber = 1;
        public UC_qlPhone_Admin()
        {
            InitializeComponent();
            setCBBBrand();
            cbbBrand.SelectedIndex = 0;
            ShowDGV("ALL", "");
        }
        public void setCBBBrand()
        {
            cbbBrand.Items.AddRange(BLL_PhonesAdmin.Instance.GetCBBBrand().ToArray());
        }
        public void setColumnPicture()
        {
            DataGridViewImageColumn dc = dataGridView1.Columns[10] as DataGridViewImageColumn;
            dc.ImageLayout = DataGridViewImageCellLayout.Zoom;
        }
        public async void ShowDGV(string Brand, string Name)
        {
            if (BLL_PhonesAdmin.Instance.getListPhone(Brand, Name) != null)
            {
                pageNumber = 1;
                list = await BLL_PhonesAdmin.Instance.getListPhone(Brand, Name);
                btnPrevious.Enabled = list.HasPreviousPage;
                btnNext.Enabled = list.HasNextPage;
                dataGridView1.DataSource = list.ToList();
                lbPageNumber.Text = string.Format("Trang {0}/{1}", pageNumber, list.PageCount);
            }
        }
        private void btnSearch_Click(object sender, EventArgs e)
        {
            pageNumber = 1;
            ShowDGV(cbbBrand.Text, txtSearch.Text);
        }

        private void btnAdd_Click(object sender, EventArgs e)
        {
            FormAdd_EditPhone f = new FormAdd_EditPhone();
            f.setData();
            f.d += new FormAdd_EditPhone.Mydel(ShowDGV);
            f.Show();
        }

        private void btnEdit_Click(object sender, EventArgs e)
        {
            if (dataGridView1.SelectedRows.Count == 0)
            {
                MessageBox.Show("Vui lòng chọn dữ liệu cần sửa thông tin", "Warning");
            }
            else if (dataGridView1.SelectedRows.Count > 1)
            {
                MessageBox.Show("Vui lòng chỉ chọn 1 dữ liệu để sửa thông tin", "Warning");
            }
            else
            {
                int idPhone = Convert.ToInt32(dataGridView1.SelectedRows[0].Cells[0].Value.ToString());
                FormAdd_EditPhone f = new FormAdd_EditPhone(idPhone);
                f.setData();
                f.d += new FormAdd_EditPhone.Mydel(ShowDGV);
                f.Show();
            }
        }

        private void btnDel_Click(object sender, EventArgs e)
        {
            if (dataGridView1.SelectedRows.Count == 0)
            {
                MessageBox.Show("Vui Lòng Chọn Dữ Liệu Cần Xoá");
            }
            else
            {
                DialogResult result = MessageBox.Show("Bạn muốn xoá dữ liệu này?", "Xoá", MessageBoxButtons.YesNo);
                if (result == DialogResult.Yes)
                {
                    List<int> listidPhone = new List<int>();
                    foreach (DataGridViewRow row in dataGridView1.SelectedRows)
                    {
                        listidPhone.Add(Convert.ToInt32(row.Cells[0].Value.ToString()));
                    }
                    BLL_PhonesAdmin.Instance.deletePhone_BLL(listidPhone);
                    ShowDGV("ALL", "");
                }
                else
                {
                    return;
                }
            }
        }

        private async void btnPrevious_Click(object sender, EventArgs e)
        {
            if (list.HasPreviousPage)
            {
                list = await BLL_PhonesAdmin.Instance.getListPhone(cbbBrand.Text, txtSearch.Text, --pageNumber);
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
                list = await BLL_PhonesAdmin.Instance.getListPhone(cbbBrand.Text, txtSearch.Text, ++pageNumber);
                btnPrevious.Enabled = list.HasPreviousPage;
                btnNext.Enabled = list.HasNextPage;
                dataGridView1.DataSource = list.ToList();
                lbPageNumber.Text = string.Format("Trang {0}/{1}", pageNumber, list.PageCount);
            }
        }
    }
}
