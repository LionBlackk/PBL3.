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
using PagedList;
using PhoneStoreManagement.DTO;

namespace BookShopManagement.UserControls
{
    public partial class UC_qlStaff_Admin : UserControl
    {
        IPagedList<DTO_ViewEmployee> list;
        int pageNumber = 1;
        public UC_qlStaff_Admin()
        {
            InitializeComponent();
            setCBBRole();
            cbbRole.SelectedIndex = 0;
            ShowDGV("ALL", "");
        }
        public void setCBBRole()
        {
            cbbRole.Items.AddRange(BLL_EmployeesAdmin.Instance.GetCBBRole().ToArray());
        }
        private async void ShowDGV(string Role, string Name)
        {
            if (BLL_EmployeesAdmin.Instance.getListEmployee(Role, Name) != null)
            {
                pageNumber = 1;
                list = await BLL_EmployeesAdmin.Instance.getListEmployee(Role, Name);
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
            FormAdd_EditEmployee f = new FormAdd_EditEmployee();
            f.setData();
            f.d += new FormAdd_EditEmployee.Mydel(ShowDGV);
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
                int idEmp = Convert.ToInt32(dataGridView1.SelectedRows[0].Cells[0].Value.ToString());
                FormAdd_EditEmployee f = new FormAdd_EditEmployee(idEmp);
                f.setData();
                f.d += new FormAdd_EditEmployee.Mydel(ShowDGV);
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
                    List<int> listEmployee = new List<int>();
                    foreach (DataGridViewRow row in dataGridView1.SelectedRows)
                    {
                        listEmployee.Add(Convert.ToInt32(row.Cells[0].Value.ToString()));
                    }
                    BLL_EmployeesAdmin.Instance.deleteEmp_BLL(listEmployee);
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
                list = await BLL_EmployeesAdmin.Instance.getListEmployee(cbbRole.Text, txtSearch.Text, --pageNumber);
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
                list = await BLL_EmployeesAdmin.Instance.getListEmployee(cbbRole.Text, txtSearch.Text, ++pageNumber);
                btnPrevious.Enabled = list.HasPreviousPage;
                btnNext.Enabled = list.HasNextPage;
                dataGridView1.DataSource = list.ToList();
                lbPageNumber.Text = string.Format("Trang {0}/{1}", pageNumber, list.PageCount);
            }
        }
    }
}
