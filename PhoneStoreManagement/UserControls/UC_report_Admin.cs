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
using System.Windows.Documents;
using System.Windows.Forms;

namespace PhoneStoreManagement.UserControls
{
    public partial class UC_report_Admin : System.Windows.Forms.UserControl
    {
        IPagedList<DTO_Statistics_Phone> listPhone;
        IPagedList<DTO_Statistics_Employee> listEmployee;
        IPagedList<DTO_Statistics_TypeOrder> listTypeOrder;
        int pageNumber = 1;
        public UC_report_Admin()
        {
            InitializeComponent();
            setTotalRevenue();
            setTotalCustomer();
            setTotalPhoneSell();
            cbbStatistics.SelectedIndex = 0;
            dateStart.Value = new DateTime(2020, 1, 1);
        }
        public void setTotalRevenue()
        {
            lbTotalRevenue.Text = BLL_StatisticsAdmin.Instance.getTotalRevenue().ToString() + " đ";
        }
        public void setTotalCustomer()
        {
            lbTotalCustomer.Text = BLL_StatisticsAdmin.Instance.getTotalCustomer().ToString();
        }
        public void setTotalPhoneSell()
        {
            lbTotalPhoneSell.Text = BLL_StatisticsAdmin.Instance.getTotalPhoneSell().ToString();
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

        private void dateStart_ValueChanged(object sender, EventArgs e)
        {
            if (checkTimeOrder())
            {
                cbbStatistics_SelectedIndexChanged(this, EventArgs.Empty);
            }
            else
            {
                MessageBox.Show("Lỗi khoảng thời gian tìm kiếm", "error");
            }
        }

        private void dateEnd_ValueChanged(object sender, EventArgs e)
        {
            if (checkTimeOrder())
            {
                cbbStatistics_SelectedIndexChanged(this, EventArgs.Empty);
            }
            else
            {
                MessageBox.Show("Lỗi khoảng thời gian tìm kiếm", "Error");
            }
        }

        private async void cbbStatistics_SelectedIndexChanged(object sender, EventArgs e)
        {
            pageNumber = 1;
            if (cbbStatistics.SelectedIndex == 0)
            {
                dataGridView1.Dock = DockStyle.Fill;
                dataGridView1.Visible = true;
                dataGridView2.Visible = false;
                dataGridView3.Visible = false;
                listPhone = await BLL_StatisticsAdmin.Instance.getStatisticsByPhone(dateStart.Value, dateEnd.Value);
                btnPrevious.Enabled = listPhone.HasPreviousPage;
                btnNext.Enabled = listPhone.HasNextPage;
                dataGridView1.DataSource = listPhone.ToList();
                lbPageNumber.Text = string.Format("Trang {0}/{1}", pageNumber, listPhone.PageCount);
            }
            if (cbbStatistics.SelectedIndex == 1)
            {
                dataGridView2.Dock = DockStyle.Fill;
                dataGridView2.Visible = true;
                dataGridView1.Visible = false;
                dataGridView3.Visible = false;
                listEmployee = await BLL_StatisticsAdmin.Instance.getStatisticsByEmployee(dateStart.Value, dateEnd.Value);
                btnPrevious.Enabled = listEmployee.HasPreviousPage;
                btnNext.Enabled = listEmployee.HasNextPage;
                dataGridView2.DataSource = listEmployee.ToList();
                lbPageNumber.Text = string.Format("Trang {0}/{1}", pageNumber, listEmployee.PageCount);
            }
            if (cbbStatistics.SelectedIndex == 2)
            {
                dataGridView3.Dock = DockStyle.Fill;
                dataGridView3.Visible = true;
                dataGridView1.Visible = false;
                dataGridView2.Visible = false;
                listTypeOrder = await BLL_StatisticsAdmin.Instance.getStatisticsByTypeOrders(dateStart.Value, dateEnd.Value);
                btnPrevious.Enabled = listTypeOrder.HasPreviousPage;
                btnNext.Enabled = listTypeOrder.HasNextPage;
                dataGridView3.DataSource = listTypeOrder.ToList();
                lbPageNumber.Text = string.Format("Trang {0}/{1}", pageNumber, listTypeOrder.PageCount);
            }
        }

        private void btnChoose_Click(object sender, EventArgs e)
        {
            FormViewCustomer f = new FormViewCustomer();
            f.ShowDialog();
        }

        private async void btnPrevious_Click(object sender, EventArgs e)
        {
            if (listPhone.HasPreviousPage || listEmployee.HasPreviousPage || listTypeOrder.HasPreviousPage)
            {
                if (cbbStatistics.SelectedIndex == 0)
                {
                    dataGridView1.Dock = DockStyle.Fill;
                    dataGridView1.Visible = true;
                    dataGridView2.Visible = false;
                    dataGridView3.Visible = false;
                    listPhone = await BLL_StatisticsAdmin.Instance.getStatisticsByPhone(dateStart.Value, dateEnd.Value, --pageNumber);
                    btnPrevious.Enabled = listPhone.HasPreviousPage;
                    btnNext.Enabled = listPhone.HasNextPage;
                    dataGridView1.DataSource = listPhone.ToList();
                    lbPageNumber.Text = string.Format("Trang {0}/{1}", pageNumber, listPhone.PageCount);
                }
                if (cbbStatistics.SelectedIndex == 1)
                {
                    dataGridView2.Dock = DockStyle.Fill;
                    dataGridView2.Visible = true;
                    dataGridView1.Visible = false;
                    dataGridView3.Visible = false;
                    listEmployee = await BLL_StatisticsAdmin.Instance.getStatisticsByEmployee(dateStart.Value, dateEnd.Value, --pageNumber);
                    btnPrevious.Enabled = listEmployee.HasPreviousPage;
                    btnNext.Enabled = listEmployee.HasNextPage;
                    dataGridView2.DataSource = listEmployee.ToList();
                    lbPageNumber.Text = string.Format("Trang {0}/{1}", pageNumber, listEmployee.PageCount);
                }
                if (cbbStatistics.SelectedIndex == 2)
                {
                    dataGridView3.Dock = DockStyle.Fill;
                    dataGridView3.Visible = true;
                    dataGridView1.Visible = false;
                    dataGridView2.Visible = false;
                    listTypeOrder = await BLL_StatisticsAdmin.Instance.getStatisticsByTypeOrders(dateStart.Value, dateEnd.Value, --pageNumber);
                    btnPrevious.Enabled = listTypeOrder.HasPreviousPage;
                    btnNext.Enabled = listTypeOrder.HasNextPage;
                    dataGridView3.DataSource = listTypeOrder.ToList();
                    lbPageNumber.Text = string.Format("Trang {0}/{1}", pageNumber, listTypeOrder.PageCount);
                }
            }
        }

        private async void btnNext_Click(object sender, EventArgs e)
        {
            if (listPhone.HasNextPage || listEmployee.HasNextPage)
            {
                if (cbbStatistics.SelectedIndex == 0)
                {
                    dataGridView1.Dock = DockStyle.Fill;
                    dataGridView1.Visible = true;
                    dataGridView2.Visible = false;
                    dataGridView3.Visible = false;
                    listPhone = await BLL_StatisticsAdmin.Instance.getStatisticsByPhone(dateStart.Value, dateEnd.Value, ++pageNumber);
                    btnPrevious.Enabled = listPhone.HasPreviousPage;
                    btnNext.Enabled = listPhone.HasNextPage;
                    dataGridView1.DataSource = listPhone.ToList();
                    lbPageNumber.Text = string.Format("Trang {0}/{1}", pageNumber, listPhone.PageCount);
                }
                if (cbbStatistics.SelectedIndex == 1)
                {
                    dataGridView2.Dock = DockStyle.Fill;
                    dataGridView2.Visible = true;
                    dataGridView1.Visible = false;
                    dataGridView3.Visible = false;
                    listEmployee = await BLL_StatisticsAdmin.Instance.getStatisticsByEmployee(dateStart.Value, dateEnd.Value, ++pageNumber);
                    btnPrevious.Enabled = listEmployee.HasPreviousPage;
                    btnNext.Enabled = listEmployee.HasNextPage;
                    dataGridView2.DataSource = listEmployee.ToList();
                    lbPageNumber.Text = string.Format("Trang {0}/{1}", pageNumber, listEmployee.PageCount);
                }
                if (cbbStatistics.SelectedIndex == 2)
                {
                    dataGridView3.Dock = DockStyle.Fill;
                    dataGridView3.Visible = true;
                    dataGridView1.Visible = false;
                    dataGridView2.Visible = false;
                    listTypeOrder = await BLL_StatisticsAdmin.Instance.getStatisticsByTypeOrders(dateStart.Value, dateEnd.Value, ++pageNumber);
                    btnPrevious.Enabled = listTypeOrder.HasPreviousPage;
                    btnNext.Enabled = listTypeOrder.HasNextPage;
                    dataGridView3.DataSource = listTypeOrder.ToList();
                    lbPageNumber.Text = string.Format("Trang {0}/{1}", pageNumber, listTypeOrder.PageCount);
                }
            }
        }
    }
}
