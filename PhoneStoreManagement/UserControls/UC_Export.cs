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
using System.Windows.Documents;
using System.Windows.Forms;

namespace PhoneStoreManagement.UserControls
{
    public partial class UC_Export : UserControl
    {
        IPagedList<DTO_InfoOrdered> list;
        int pageNumber = 1;
        public UC_Export()
        {
            InitializeComponent();
            SetCBBState();
            SetCBBDiscount();
            SetCBBTypeOrder();
            ShowListOrders();
        }
        private void SetCBBState()
        {
            cbbState.Items.Clear();
            cbbState.Items.AddRange(BLL_UCExport.Instance.setCBBState().ToArray());
        }
        private void SetCBBDiscount()
        {
            cbbDiscount.Items.Clear();
            cbbDiscount.Items.AddRange(BLL_UCExport.Instance.setCBBDiscount().ToArray());
        }
        private void SetCBBTypeOrder()
        {
            cbbTypeOrder.Items.Clear();
            cbbTypeOrder.Items.AddRange(BLL_UCExport.Instance.setCBBTypeOrder().ToArray());
        }
        private void resetUI()
        {
            txtMa.Text = "";
            txtKhachHang.Text = "";
            txtAddress.Text = "";
            txtEmpCreate.Text = "";
            txtEmpEdit.Text = "";
            txtPhone.Text = "";
            dateOrder.Value = DateTime.Now;
            txtTotal.Text = "";
            cbbTypeOrder.SelectedIndex = 0;
            cbbDiscount.Text = "";
            cbbState.SelectedIndex = 0;
        }
        private void setUI(DTO_InfoOrdered data)
        {
            txtMa.Text = data.IDOrder.ToString();
            txtKhachHang.Text = data.NameCustomer.ToString();
            txtAddress.Text = data.AddressCustomer.ToString();
            txtEmpCreate.Text = data.IDEmployeeCreate.ToString();
            txtEmpEdit.Text = data.IDEmployeeEdit.ToString();
            txtPhone.Text = data.PhoneCustomer.ToString();
            dateOrder.Value = data.TimeOrder;
            txtTotal.Text = data.Total.ToString();
            cbbTypeOrder.Text = data.TypeOrder.ToString();
            cbbDiscount.Text = "";
            cbbDiscount.Text = data.ValueDiscount.ToString();
            cbbState.SelectedIndex = data.StateOrder.IDState - 1;
        }
        private async void ShowListOrders()
        {
            if (BLL_UCExport.Instance.GetInfoOrdered() != null)
            {
                pageNumber = 1;
                list = await BLL_UCExport.Instance.GetInfoOrdered();
                btnPrevious.Enabled = list.HasPreviousPage;
                btnNext.Enabled = list.HasNextPage;
                dgvInfoOrders.DataSource = list.ToList();
                lbPageNumber.Text = string.Format("Trang {0}/{1}", pageNumber, list.PageCount);
            }
        }
        private void btnAccept_Click(object sender, EventArgs e)
        {
            DialogResult result = MessageBox.Show("Bạn muốn cập nhật đơn hàng không?", "Cập nhật đơn hàng", MessageBoxButtons.OKCancel);
            if (result == DialogResult.OK)
            {
                try
                {
                    Transaction_ transaction = BLL_UCExport.Instance.GetTransactionById(Convert.ToInt32(txtMa.Text));
                    Discount discount = BLL_UCExport.Instance.GetDiscount(transaction);
                    DTO_State state = cbbState.SelectedItem as DTO_State;
                    DTO_TypeOrder type = cbbTypeOrder.SelectedItem as DTO_TypeOrder;
                    DTO_InfoOrdered i = new DTO_InfoOrdered
                    {
                        IDOrder = Convert.ToInt32(txtMa.Text),
                        NameCustomer = txtKhachHang.Text,
                        AddressCustomer = txtAddress.Text,
                        PhoneCustomer = txtPhone.Text,
                        IDEmployeeCreate = Convert.ToInt32(txtEmpCreate.Text),
                        IDEmployeeEdit = txtEmpEdit.Text == "" ? null : txtEmpEdit.Text,
                        TimeOrder = dateOrder.Value,
                        Total = txtTotal.Text,
                        ValueDiscount = discount.ToString(),
                        StateOrder = state,
                        TypeOrder = type,
                    };
                    BLL_UCExport.Instance.UpdateInfoOrder(i);
                    ShowListOrders();
                    resetUI();
                    MessageBox.Show("Cập nhật đơn hàng thành công", "Cập nhật đơn hàng");
                }
                catch (Exception ex)
                {
                    return;
                }
            }

        }

        private void dgvInfoOrders_RowHeaderMouseClick(object sender, DataGridViewCellMouseEventArgs e)
        {
            int id = Convert.ToInt32(dgvInfoOrders.SelectedRows[0].Cells[0].Value.ToString());
            DTO_InfoOrdered order = BLL_UCExport.Instance.getInfoOrderedById(id);
            setUI(order);
        }

        private async void btnPrevious_Click(object sender, EventArgs e)
        {
            if (list.HasPreviousPage)
            {
                list = await BLL_UCExport.Instance.GetInfoOrdered(--pageNumber);
                btnPrevious.Enabled = list.HasPreviousPage;
                btnNext.Enabled = list.HasNextPage;
                dgvInfoOrders.DataSource = list.ToList();
                lbPageNumber.Text = string.Format("Trang {0}/{1}", pageNumber, list.PageCount);
            }
        }

        private async void btnNext_Click(object sender, EventArgs e)
        {
            if (list.HasNextPage)
            {
                list = await BLL_UCExport.Instance.GetInfoOrdered(++pageNumber);
                btnPrevious.Enabled = list.HasPreviousPage;
                btnNext.Enabled = list.HasNextPage;
                dgvInfoOrders.DataSource = list.ToList();
                lbPageNumber.Text = string.Format("Trang {0}/{1}", pageNumber, list.PageCount);
            }
        }
    }
}
