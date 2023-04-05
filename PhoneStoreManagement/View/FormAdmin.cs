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
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace PhoneStoreManagement
{
    public partial class FormAdmin : Form
    {
        int PanelWidth;
        bool isCollapsed;
        public FormAdmin()
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

        private void timeradmin_Tick(object sender, EventArgs e)
        {
            if (isCollapsed)
            {
                panelLeft.Width = panelLeft.Width + 10;
                if (panelLeft.Width >= PanelWidth)
                {
                    timeradmin.Stop();
                    isCollapsed = false;
                    this.Refresh();
                }
            }
            else
            {
                panelLeft.Width = panelLeft.Width - 10;
                if (panelLeft.Width <= 75)
                {
                    timeradmin.Stop();
                    isCollapsed = true;
                    this.Refresh();
                }
            }
        }

        private void btnOut_Click(object sender, EventArgs e)
        {
            DialogResult result = MessageBox.Show("Bạn có muốn đăng xuất không? ", "Đăng xuất", MessageBoxButtons.OKCancel);
            if (result == DialogResult.OK)
            {
                timerTime.Stop();
                timeradmin.Stop();
                this.Hide();
                FormLogin formLogin = new FormLogin();
                formLogin.Show();
            }
        }
        private void moveSidePanel(Control btn)
        {
            panelSide.Top = btn.Top;
            panelSide.Height = btn.Height;
        }
        private void addUserControl(Control control)
        {
            control.Dock = DockStyle.Fill;
            panelControl.Controls.Clear();
            panelControl.Controls.Add(control);
        }

        private void btnHome_Click(object sender, EventArgs e)
        {
            moveSidePanel(btnHome);
            UC_Home uc = new UC_Home();
            addUserControl(uc);
        }

        private void btnPhone_Click(object sender, EventArgs e)
        {
            moveSidePanel(btnPhone);
            UC_qlPhone_Admin uc = new UC_qlPhone_Admin();
            addUserControl(uc);
        }

        private void btnEmp_Click(object sender, EventArgs e)
        {
            moveSidePanel(btnEmp);
            UC_qlStaff_Admin uc = new UC_qlStaff_Admin();
            addUserControl(uc);
        }

        private void btnAcc_Click(object sender, EventArgs e)
        {
            moveSidePanel(btnAcc);
            UC_qlAccount_Admin uc = new UC_qlAccount_Admin();
            addUserControl(uc);
        }

        private void btnSettings_Click(object sender, EventArgs e)
        {
            moveSidePanel(btnSettings);
            UC_Settings uc = new UC_Settings();
            uc.SetInfoUser();
            addUserControl(uc);
        }

        private void timerTime_Tick(object sender, EventArgs e)
        {
            DateTime dt = DateTime.Now;
            labelTime.Text = dt.ToString("HH:mm:ss");
        }

        private void btnFromLoad_Click_1(object sender, EventArgs e)
        {
            timeradmin.Start();
        }

        private void btnReport_Click(object sender, EventArgs e)
        {
            moveSidePanel(btnReport);
            UC_report_Admin uc = new UC_report_Admin();
            addUserControl(uc);
        }
    }
}
