using PhoneStoreManagement.BLL;
using PhoneStoreManagement.DAL;
using PhoneStoreManagement.DTO;
using PhoneStoreManagement.UserControls;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Drawing.Text;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace PhoneStoreManagement
{
    public partial class FormChooseProduct : Form
    {
        private const int COLUMN_ID_INDEX = 0;
        private const int COLUMN_QUANTITY_INDEX = 2;
        private bool acceptClear = true;
        public FormChooseProduct()
        {
            InitializeComponent();
            SetCBB_Brand();
            SetCBB_Category();
            SetCBB_PhoneType();
            SetListProduct();
            SetHandlerPhoneChose();
            LoadDGV();
        }
        private void SetListProduct()
        {
            foreach (UC_Product i in BLL_UCListProduct.Instance.ListUC(((DTO_Brand)cbbBrand.SelectedItem), (DTO_PhoneType)cbbPhoneType.SelectedItem, txtNamePhone.Text))
            {
                flowLayoutPanel1.Controls.Add(i);
            }
        }
        private void SetCBB_Brand()
        {
            List<DTO_Brand> list = new List<DTO_Brand>();
            cbbBrand.Items.Add(new DTO_Brand { IDBrand = "ALL", NameBrand = "ALL" });
            cbbBrand.SelectedIndex = 0;
            using (var db = new DBManagement())
            {
                foreach (Brand i in db.Brands)
                {
                    list.Add(new DTO_Brand { IDBrand = i.IDBrand, NameBrand = i.NameBrand });
                }
                cbbBrand.Items.AddRange(list.ToArray());
            }
        }
        private void SetCBB_Category()
        {
            List<DTO_Category> list = new List<DTO_Category>();
            cbbCategory.Items.Clear();
            cbbCategory.Items.Add(new DTO_Category { IDCategory = 0, NameCategory = "ALL" });
            cbbCategory.SelectedIndex = 0;
            using (var db = new DBManagement())
            {
                foreach (Category i in db.Categories)
                {
                    list.Add(new DTO_Category { IDCategory = i.IDCategory, NameCategory = i.NameCategory });
                }
                cbbCategory.Items.AddRange(list.ToArray());
            }
        }
        private void SetCBB_PhoneType()
        {
            List<DTO_PhoneType> list = new List<DTO_PhoneType>();
            cbbPhoneType.Items.Clear();
            cbbPhoneType.Items.Add(new DTO_PhoneType { IDPhoneType = 0, PhoneTypeName = "ALL" });
            cbbPhoneType.SelectedIndex = 0;
            using (var db = new DBManagement())
            {
                foreach (PhoneType i in db.PhoneTypes)
                {
                    list.Add(new DTO_PhoneType { IDPhoneType = i.IDPhoneType, PhoneTypeName = i.PhoneTypeName, IDCategory = (int)i.IDCategory });
                }
                cbbPhoneType.Items.AddRange(list.ToArray());
            }
        }

        private void cbbCategory_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (cbbCategory.SelectedIndex != 0)
            {
                cbbPhoneType.Items.Clear();
                using (var db = new DBManagement())
                {
                    cbbPhoneType.Items.Add(new DTO_PhoneType { IDPhoneType = 0, PhoneTypeName = "ALL" });
                    cbbPhoneType.SelectedIndex = 0;
                    foreach (PhoneType i in db.PhoneTypes.Where(p => p.IDCategory == ((DTO_Category)cbbCategory.SelectedItem).IDCategory).ToList())
                    {
                        cbbPhoneType.Items.Add(new DTO_PhoneType { IDPhoneType = i.IDPhoneType, PhoneTypeName = i.PhoneTypeName, IDCategory = (int)i.IDCategory });
                    }
                }
            }
            else
            {
                List<DTO_PhoneType> list = new List<DTO_PhoneType>();
                cbbPhoneType.Items.Clear();
                cbbPhoneType.Items.Add(new DTO_PhoneType { IDPhoneType = 0, PhoneTypeName = "ALL" });
                cbbPhoneType.SelectedIndex = 0;
                using (var db = new DBManagement())
                {
                    foreach (PhoneType i in db.PhoneTypes)
                    {
                        list.Add(new DTO_PhoneType { IDPhoneType = i.IDPhoneType, PhoneTypeName = i.PhoneTypeName, IDCategory = (int)i.IDCategory });
                    }
                    cbbPhoneType.Items.AddRange(list.ToArray());
                }
            }
        }

        private void btnSearch_Click(object sender, EventArgs e)
        {
            flowLayoutPanel1.Controls.Clear();
            SetListProduct();
        }
        public void LoadDGV()
        {
            BindingSource bs = new BindingSource();
            bs.DataSource = BLL_ListPhoneChose.Instance.GetListPhoneChose();
            dgvChoosed.DataSource = bs;
            bs.ResetBindings(false);
        }
        private void OnPhoneChoseAdded(object sender, EventArgs e)
        {
            LoadDGV();
        }
        private void SetHandlerPhoneChose()
        {
            BLL_ListPhoneChose.PhoneChoseAdded += OnPhoneChoseAdded;
        }

        private void btnAccept_Click(object sender, EventArgs e)
        {
            acceptClear = false;
            this.Close();
        }
        private void dgvChoosed_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            using (var db = new DBManagement())
            {
                if (dgvChoosed.Columns[e.ColumnIndex].Name == "Addition")
                {
                    foreach (DataGridViewRow i in dgvChoosed.SelectedRows)
                    {
                        int IDPhone = Convert.ToInt32(i.Cells[COLUMN_ID_INDEX].Value.ToString());
                        InventoryManagement inventory = db.InventoryManagements.SingleOrDefault(p => p.IDPhone == IDPhone);
                        int quantity = Convert.ToInt32(i.Cells[COLUMN_QUANTITY_INDEX].Value.ToString());
                        if (inventory.Quantity > Convert.ToInt32(i.Cells[COLUMN_QUANTITY_INDEX].Value.ToString()))
                        {
                            i.Cells[COLUMN_QUANTITY_INDEX].Value = (Convert.ToInt32(i.Cells[COLUMN_QUANTITY_INDEX].Value.ToString()) + 1).ToString();
                        }
                        else
                        {
                            MessageBox.Show("Không đủ số lượng trong kho", "Số lượng");
                        }
                    }
                }
                if (dgvChoosed.Columns[e.ColumnIndex].Name == "Subtraction")
                {
                    foreach (DataGridViewRow i in dgvChoosed.SelectedRows)
                    {
                        i.Cells[COLUMN_QUANTITY_INDEX].Value = (Convert.ToInt32(i.Cells[COLUMN_QUANTITY_INDEX].Value.ToString()) - 1).ToString();
                        if (Convert.ToInt32(i.Cells[COLUMN_QUANTITY_INDEX].Value.ToString()) <= 0)
                        {
                            dgvChoosed.Rows.Remove(i);
                        }
                    }
                }
            }
        }

        private void FormChooseProduct_FormClosing(object sender, FormClosingEventArgs e)
        {
            this.Dispose();
            if (acceptClear)
            {
                BLL_ListPhoneChose.Instance.GetListPhoneChose().Clear();
            }
        }
    }
}