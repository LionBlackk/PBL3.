using PhoneStoreManagement.BLL;
using PhoneStoreManagement.DAL;
using PhoneStoreManagement.DTO;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Windows.Forms;

namespace PhoneStoreManagement.UserControls
{
    public partial class UC_Order : UserControl
    {
        private bool clickBtnEdit = false;
        public UC_Order()
        {
            InitializeComponent();
            SetUI();
            SetTypeOrder();
            SetCBBDiscount();
            SetHandlerCheckOut();
        }
        private void btnFindCustomer_Click(object sender, EventArgs e)
        {
            if (Phone.Text == "")
            {
                MessageBox.Show("Hãy nhập số điện thoại để tìm kiếm", "Tìm khách hàng"); return;
            }
            Customer customer = BLL_UCOrder.Instance.GetCustomerByPhone(Phone.Text);
            if (customer != null)
            {
                NameCustomer.Text = customer.NameCustomer;
                Address.Text = customer.Address;
                Phone.Text = customer.Phone;

            }
            else
            {
                MessageBox.Show("Không tìm thấy khách hàng này!", "Tìm khách hàng");
                ResetControl();
            }
        }
        private void btnConfirmCustomer_Click(object sender, EventArgs e)
        {
            BLL_UCOrder.Instance.ConfirmCustomer(NameCustomer.Text, Address.Text, Phone.Text);
        }
        private void btnConfirmOrder_Click(object sender, EventArgs e)
        {
            if (cbbTypeOrder.SelectedItem == null || (rdCredit.Checked == false && rdDirect.Checked == false))
            {
                MessageBox.Show("Hãy điền đầy đủ thông tin", "Thông tin"); return;
            }
            if (TimeOrder.Value < DateTime.Now)
            {
                TimeOrder.Value = DateTime.Now;
            }
            if (NameCustomer.Text == "" || Address.Text == "" || Phone.Text == "")
            {
                MessageBox.Show("Hãy load dữ liệu khách hàng trước", "Đơn hàng"); return;
            }
            BLL_UCOrder.Instance.SetNewOrder(IDEmployeeCreate.Text, IDEmployeeEdit.Text, TimeOrder.Value, ((DTO_TypeOrder)cbbTypeOrder.SelectedItem), Phone.Text);
        }
        private void btnChoose_Click(object sender, EventArgs e)
        {
            FormChooseProduct form = new FormChooseProduct();
            using (var db = new DBManagement())
            {
                if (dgvInfoOrder.Rows.Count > 0)
                {
                    foreach (DataGridViewRow i in dgvInfoOrder.Rows)
                    {
                        int idPhone = Convert.ToInt32(i.Cells[0].Value.ToString());
                        int quantity = Convert.ToInt32(i.Cells[5].Value.ToString());
                        BLL_ListPhoneChose.Instance.SetListPhoneChoseByDGV(db, idPhone, quantity);
                    }
                }
                form.ShowDialog();
                SetDGVInfo(db);
                LoadCheckOut();
            }
        }
        private void SetDGVInfo(DBManagement db = null)
        {
            BindingSource bs = new BindingSource();
            bs.DataSource = BLL_UCOrder.Instance.GetListDTO_InfoOrder();
            dgvInfoOrder.DataSource = bs;
            bs.ResetBindings(false);
        }
        private void SetTypeOrder()
        {
            using (var db = new DBManagement())
            {
                foreach (TypeOrder i in db.TypeOrders.ToList())
                {
                    cbbTypeOrder.Items.Add(new DTO_TypeOrder { IDTypeOrder = i.IDTypeOrder, NameTypeOrder = i.NameTypeOrder });
                }
            }
        }
        private void SetUI()
        {
            using (var db = new DBManagement())
            {
                // với IDEmployeeCreate, IDEmployeeEdit đăng nhập vào có sẵn IDEmployeeCreate, còn nếu có rồi thì đè lên IDEmployeeEdit
                Account account = BLL_Login.Instance.GetAccount();

                Employee employee = db.Employees.SingleOrDefault(p => p.IDEmployee == account.IDEmployee);
                if (IDEmployeeCreate.Text == "")
                {
                    IDEmployeeCreate.Text = employee.IDEmployee.ToString();
                }
                else
                {
                    IDEmployeeEdit.Text = employee.IDEmployee.ToString();
                }
            }
        }
        private void SetCBBDiscount()
        {
            using (var db = new DBManagement())
            {
                foreach (Discount i in db.Discounts)
                {
                    cbbDiscount.Items.Add(new DTO_Discount
                    {
                        IDDiscount = i.IDDiscount,
                        ValueDiscount = i.ValueDiscount
                    });
                }
                cbbDiscount.SelectedIndex = 0;
            }
        }
        private void ResetControl()
        {
            NameCustomer.Text = "";
            Address.Text = "";
            Phone.Text = "";
            IDEmployeeEdit.Text = "";
            cbbTypeOrder.SelectedItem = null;
            rdCredit.Checked = false;
            rdDirect.Checked = false;
            cbbDiscount.SelectedIndex = 0;
            Total.Text = "";
            TotalApplyedDis.Text = "";
            dgvInfoOrder.Rows.Clear();
        }
        private void SetUIEditOrder(DBManagement db, Customer customer, Order_ lastOrder, Account account)
        {
            NameCustomer.Text = customer.NameCustomer;
            Address.Text = customer.Address;
            Phone.Text = customer.Phone;
            IDEmployeeCreate.Text = lastOrder.IDEmployeeCreate.ToString();
            IDEmployeeEdit.Text = account.IDEmployee.ToString();
            lastOrder.IDEmployeeEdit = Convert.ToInt32(IDEmployeeEdit.Text);
            TypeOrder typeOrder = db.TypeOrders.SingleOrDefault(p => p.IDTypeOrder == lastOrder.IDTypeOrder);
            cbbTypeOrder.SelectedIndex = cbbTypeOrder.Items.IndexOf(new DTO_TypeOrder { IDTypeOrder = typeOrder.IDTypeOrder, NameTypeOrder = typeOrder.NameTypeOrder });
            TimeOrder.Value = lastOrder.TimeOrder;
            var transactions = db.Transaction_.Where(p => p.IDOrder == lastOrder.IDOrder).OrderByDescending(p => p.IDTransaction);
            Transaction_ lastTransaction = transactions.FirstOrDefault();
            if (lastTransaction == null) return;
            if (lastTransaction.PaymentMethods.Equals("Credit"))
            {
                rdCredit.Checked = true;
            }
            else
            {
                rdDirect.Checked = true;
            }
            cbbDiscount.SelectedIndex = cbbDiscount.Items.IndexOf(new DTO_Discount { IDDiscount = lastTransaction.IDDiscount });

            BLL_ListPhoneChose.Instance.SetListPhoneChoseByOrderDetail(db, lastOrder);
            SetDGVInfo(db);
            LoadCheckOut();
            BLL_ListPhoneChose.Instance.GetListPhoneChose().Clear();
        }
        private void btnEditOrder_Click(object sender, EventArgs e)
        {
            if (Phone.Text == "")
            {
                MessageBox.Show("Hãy nhập số điện thoại để tìm kiếm", "Tìm khách hàng"); return;
            }
            using (var db = new DBManagement())
            {
                try
                {
                    Customer customer = db.Customers.SingleOrDefault(p => p.Phone == Phone.Text);
                    if (customer != null)
                    {
                        Account account = BLL_Login.Instance.GetAccount();
                        Order_ lastOrder = BLL_UCOrder.Instance.GetLastOrder(db, customer);
                        if (lastOrder == null)
                        {
                            MessageBox.Show("Chưa có đơn hàng", "Sửa đơn hàng"); return;
                        }
                        SetUIEditOrder(db, customer, lastOrder, account);
                        clickBtnEdit = true;
                        db.SaveChanges();
                    }
                    else
                    {
                        MessageBox.Show("Không tìm thấy khách hàng này!", "Tìm khách hàng");
                    }
                }
                catch (Exception)
                {
                    MessageBox.Show("Hãy load thông tin khách hàng trước", "Thông tin");
                }
            }
        }

        private void btnCheckout_Click(object sender, EventArgs e)
        {
            BLL_UCOrder.Instance.CheckOut(Phone.Text, clickBtnEdit);
            BLL_UCOrder.Instance.SetTransaction(rdDirect.Checked, TimeOrder.Value, TotalApplyedDis.Text, ((DTO_Discount)cbbDiscount.SelectedItem));
        }
        private void btnPrint_Click(object sender, EventArgs e)
        {
            BLL_UCOrder.Instance.PrintOrder(Phone.Text);
        }
        private void LoadCheckOut()
        {
            using (var db = new DBManagement())
            {
                if (BLL_ListPhoneChose.Instance.GetListPhoneChose().Count == 0)
                {
                    foreach (DataGridViewRow i in dgvInfoOrder.Rows)
                    {
                        int idPhone = Convert.ToInt32(i.Cells[0].Value.ToString());
                        int quantity = Convert.ToInt32(i.Cells[5].Value.ToString());
                        Phone phone = db.Phones.SingleOrDefault(p => p.IDPhone == idPhone);
                        BLL_ListPhoneChose.Instance.AddPhoneChose(new DTO_PhoneChose
                        {
                            IDPhone = phone.IDPhone,
                            NamePhone = phone.NamePhone,
                            Price = phone.Price,
                            Quantity = quantity
                        });
                    }
                }
                int total = 0;
                foreach (DTO_PhoneChose i in BLL_ListPhoneChose.Instance.GetListPhoneChose())
                {
                    total += (i.Price * i.Quantity);
                }
                Total.Text = total.ToString();
                int ValueDiscount = ((DTO_Discount)cbbDiscount.SelectedItem).ValueDiscount;
                TotalApplyedDis.Text = (Convert.ToInt32(Total.Text) * (1 - ValueDiscount * 1.0 / 100)).ToString();
            }
        }
        private void EventCheckOut(object sender, EventArgs e)
        {
            LoadCheckOut();
        }
        private void SetHandlerCheckOut()
        {
            BLL_ListPhoneChose.PhoneChoseAdded += EventCheckOut;
        }
        private void btnNewOrder_Click(object sender, EventArgs e)
        {
            ResetControl();
            BLL_ListPhoneChose.Instance.GetListPhoneChose().Clear();
        }
        private void cbbDiscount_SelectedIndexChanged(object sender, EventArgs e)
        {
            LoadCheckOut();
        }
    }
}