using PhoneStoreManagement.BLL;
using PhoneStoreManagement.DTO;
using System;
using System.Windows.Forms;

namespace PhoneStoreManagement.UserControls
{
    public partial class UC_Home : UserControl
    {
        public UC_Home()
        {
            InitializeComponent();
            SetCBB_Brand();
            SetCBB_Category();
            SetCBB_PhoneType();
            SetHome();
        }
        private void SetHome()
        {
            foreach (UC_Product i in BLL_UCListProduct.Instance.ListUC(((DTO_Brand)cbbBrand.SelectedItem), (DTO_PhoneType)cbbPhoneType.SelectedItem,txtNamePhone.Text)) 
            {
                flowLayoutPanel1.Controls.Add(i);
            }
        }
        private void SetCBB_Brand()
        {
            BLL_UCHome.Instance.SetCBBBrand(cbbBrand);
        }
        private void SetCBB_Category()
        {
            BLL_UCHome.Instance.SetCBBCategory(cbbCategory);
        }
        private void SetCBB_PhoneType(string idCategory = null)
        {
            BLL_UCHome.Instance.SetCBBPhoneType(cbbCategory, cbbPhoneType, idCategory);
        }
        private void cbbCategory_SelectedIndexChanged(object sender, EventArgs e)
        {
            if(cbbCategory.SelectedIndex != 0)
            {
                SetCBB_PhoneType(((DTO_Category)cbbCategory.SelectedItem).IDCategory.ToString());
            }
            else
            {
                SetCBB_PhoneType();
            }
        }

        private void btnSearch_Click(object sender, EventArgs e)
        {
            flowLayoutPanel1.Controls.Clear();
            SetHome();
        }
    }
}
