using BookShopManagement.UserControls;
using PhoneStoreManagement.BLL;
using PhoneStoreManagement.DAL;
using PhoneStoreManagement.UserControls;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Management.Instrumentation;
using System.Security.Cryptography;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace PhoneStoreManagement
{
    public partial class FormSaler : Form
    {
        int PanelWidth;
        bool isCollapsed;
        public FormSaler()
        {
            InitializeComponent();
            SetUI();
        }
        private void SetUI()
        {
            PanelWidth = panelLeft.Width;
            isCollapsed = false;
            UC_Home uc = new UC_Home();
            addUserControl(uc);
            timerTime.Start();
            using (var db = new DBManagement())
            {
                Account account = BLL_Login.Instance.GetAccount();
                Employee employee = db.Employees.SingleOrDefault(p => p.IDEmployee == account.IDEmployee);
                Role role = db.Roles.SingleOrDefault(p => p.IDRole == account.IDRole);
                NameEmployee.Text = employee.NameEmployee;
                NameRole.Text = role.NameRole;
            }
        }
        private void timerSaler_Tick(object sender, EventArgs e)
        {
            if (isCollapsed)
            {
                panelLeft.Width = panelLeft.Width + 10;
                if (panelLeft.Width >= PanelWidth)
                {
                    timerSaler.Stop();
                    isCollapsed = false;
                }
            }
            else
            {
                panelLeft.Width = panelLeft.Width - 10;
                if (panelLeft.Width <= 75)
                {
                    timerSaler.Stop();
                    isCollapsed = true;
                }
            }
        }

        private void btnFromLoad_Click(object sender, EventArgs e)
        {
            // dùng để start timeSaler chạy panelleft
            timerSaler.Start();
        }
        private void moveSidePanel(Control btn)
        {
            panelSide.Top = btn.Top;
            panelSide.Height = btn.Height;
        }
        private void addUserControl(Control control)
        {
            panelControl.Controls.Clear();
            control.Dock = DockStyle.Fill;
            panelControl.Controls.Add(control);
        }

        private void timerTime_Tick(object sender, EventArgs e)
        {
            DateTime dt = DateTime.Now;
            labelTime.Text = dt.ToString("HH:mm:ss");
        }

        private void btnHome_Click(object sender, EventArgs e)
        {
            moveSidePanel(btnHome);
            UC_Home uc = new UC_Home();
            addUserControl(uc);
        }

        private void btnSetOrder_Click(object sender, EventArgs e)
        {
            moveSidePanel(btnSetOrder);
            UC_Order uc = new UC_Order();
            addUserControl(uc);
        }

        private void btnOut_Click(object sender, EventArgs e)
        {
            DialogResult result = MessageBox.Show("Bạn có muốn đăng xuất không? ", "Đăng xuất", MessageBoxButtons.OKCancel);
            if (result == DialogResult.OK)
            {
                timerTime.Stop();
                timerSaler.Stop();
                this.Hide();
                FormLogin formLogin = new FormLogin();
                formLogin.Show();
            }
        }

        private void btnSettings_Click(object sender, EventArgs e)
        {
            moveSidePanel(btnSettings);
            UC_Settings uc = new UC_Settings();
            uc.SetInfoUser();
            addUserControl(uc);
        }

        private void btnInfoOrders_Click(object sender, EventArgs e)
        {
            moveSidePanel(btnInfoOrders);
            UC_InfoOrdered uc = new UC_InfoOrdered();
            addUserControl(uc);
        }

        private void FormSaler_FormClosing(object sender, FormClosingEventArgs e)
        {
            BLL_ListPhoneChose.Instance.GetListPhoneChose().Clear();
        }
    }
}