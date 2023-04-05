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
using System.Windows.Forms;

namespace PhoneStoreManagement.UserControls
{
    public partial class UC_qlAccount_Admin : UserControl
    {
        IPagedList<DTO_ViewAccount> list;
        int pageNumber = 1;
        public UC_qlAccount_Admin()
        {
            InitializeComponent();
            setCBBRole();
            cbbRole.SelectedIndex = 0;
            ShowDGV("ALL", "");
        }
        public void setCBBRole()
        {
            cbbRole.Items.AddRange(BLL_AccountsAdmin.Instance.GetCBBRole().ToArray());
        }
        private async void ShowDGV(string Role, string Name)
        {
            if (BLL_AccountsAdmin.Instance.getListAccount(Role, Name) != null)
            {
                pageNumber = 1;
                list = await BLL_AccountsAdmin.Instance.getListAccount(Role, Name);
                btnPrevious.Enabled = list.HasPreviousPage;
                btnNext.Enabled = list.HasNextPage;
                dataGridView1.DataSource = list.ToList();
                lbPageNumber.Text = string.Format("Trang {0}/{1}", pageNumber, list.PageCount);
            }
        }

        private void btnSearch_Click(object sender, EventArgs e)
        {
            pageNumber = 1;
            ShowDGV(cbbRole.Text, txtSearch.Text);
        }

        private void btnAdd_Click(object sender, EventArgs e)
        {
            FormAdd_EditAccount f = new FormAdd_EditAccount();
            f.setData();
            f.d += new FormAdd_EditAccount.Mydel(ShowDGV);
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
                int idAccount = Convert.ToInt32(dataGridView1.SelectedRows[0].Cells[0].Value.ToString());
                FormAdd_EditAccount f = new FormAdd_EditAccount(idAccount);
                f.setData();
                f.d += new FormAdd_EditAccount.Mydel(ShowDGV);
                f.Show();
            }
        }

        private void btnDel_Click(object sender, EventArgs e)
        {
            if (dataGridView1.SelectedRows.Count == 0)
            {
                MessageBox.Show("Vui lòng chọn dữ liệu cần xoá", "Warning");
            }
            else
            {
                DialogResult result = MessageBox.Show("Bạn muốn xoá dữ liệu này?", "Xoá", MessageBoxButtons.YesNo);
                if (result == DialogResult.Yes)
                {
                    List<int> lstIdAccount = new List<int>();
                    foreach (DataGridViewRow row in dataGridView1.SelectedRows)
                    {
                        lstIdAccount.Add(Convert.ToInt32(row.Cells[0].Value.ToString()));
                    }
                    BLL_AccountsAdmin.Instance.deleteAccount_BLL(lstIdAccount);
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
                list = await BLL_AccountsAdmin.Instance.getListAccount(cbbRole.Text, txtSearch.Text, --pageNumber);
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
                list = await BLL_AccountsAdmin.Instance.getListAccount(cbbRole.Text, txtSearch.Text, ++pageNumber);
                btnPrevious.Enabled = list.HasPreviousPage;
                btnNext.Enabled = list.HasNextPage;
                dataGridView1.DataSource = list.ToList();
                lbPageNumber.Text = string.Format("Trang {0}/{1}", pageNumber, list.PageCount);
            }
        }
    }
}
