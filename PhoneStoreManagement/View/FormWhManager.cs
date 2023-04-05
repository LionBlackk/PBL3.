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
    public partial class FormWhManager : Form
    {
        int PanelWidth;
        bool isCollapsed;
        public FormWhManager()
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

        private void timerWHmanager_Tick(object sender, EventArgs e)
        {
            if (isCollapsed)
            {
                panelLeft.Width = panelLeft.Width + 10;
                if (panelLeft.Width >= PanelWidth)
                {
                    timerWHmanager.Stop();
                    isCollapsed = false;
                    this.Refresh();
                }
            }
            else
            {
                panelLeft.Width = panelLeft.Width - 10;
                if (panelLeft.Width <= 75)
                {
                    timerWHmanager.Stop();
                    isCollapsed = true;
                    this.Refresh();
                }
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

        private void btnFromLoad_Click(object sender, EventArgs e)
        {
            timerWHmanager.Start();
        }

        private void timerTime_Tick(object sender, EventArgs e)
        {
            DateTime dt = DateTime.Now;
            labelTime.Text = dt.ToString("HH:mm:ss");
        }

        private void btnOut_Click(object sender, EventArgs e)
        {
            DialogResult result = MessageBox.Show("Bạn có muốn đăng xuất không? ", "Đăng xuất", MessageBoxButtons.OKCancel);
            if (result == DialogResult.OK)
            {
                timerTime.Stop();
                timerWHmanager.Stop();
                this.Hide();
                FormLogin formLogin = new FormLogin();
                formLogin.Show();
            }
        }

        private void btnHome_Click(object sender, EventArgs e)
        {
            moveSidePanel(btnHome);
            UC_Home uc = new UC_Home();
            addUserControl(uc);
        }

        private void btnSettings_Click(object sender, EventArgs e)
        {
            moveSidePanel(btnSettings);
            UC_Settings uc = new UC_Settings();
            uc.SetInfoUser();
            addUserControl(uc);
        }

        private void btnInventory_Click(object sender, EventArgs e)
        {
            moveSidePanel(btnInventory);
            UC_InventoryManagement uc = new UC_InventoryManagement();
            addUserControl(uc);
        }

        private void btnImport_Click(object sender, EventArgs e)
        {
            moveSidePanel(btnImport);
            UC_Import uc = new UC_Import();
            addUserControl(uc);
        }

        private void btnExport_Click(object sender, EventArgs e)
        {
            moveSidePanel(btnExport);
            UC_Export uc = new UC_Export();
            addUserControl(uc);
        }

        private void btnListImport_Click(object sender, EventArgs e)
        {
            moveSidePanel(btnListImport);
            UC_ListImport uc = new UC_ListImport();
            addUserControl(uc);
        }
    }
}
