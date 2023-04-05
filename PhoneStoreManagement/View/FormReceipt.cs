using Microsoft.Reporting.WinForms;
using PhoneStoreManagement.BLL;
using PhoneStoreManagement.DAL;
using System;
using System.Collections.Generic;
using System.Windows.Forms;

namespace PhoneStoreManagement
{
    public partial class FormReceipt : Form
    {
        List<OrderDetail> _list;
        Order_ _order;
        public FormReceipt(Order_ order, List<OrderDetail> list)
        {
            InitializeComponent();
            _list = list;
            _order = order;
        }

      private void FormReceipt_Load(object sender, EventArgs e)
        {
            if(_list == null || _order == null)
            {
                MessageBox.Show("Chưa có thông tin cụ thể", "In hóa đơn"); return;
            }
            try
            {
                this.reportViewer1.LocalReport.ReportPath = "C:\\Users\\DELL\\Documents\\PBL3Demo3\\PBL3\\PBL3\\PhoneStoreManagement\\PhoneStoreManagement\\View\\Receipt.rdlc";
                if (BLL_Receipt.Instance.GetListDTO_Receipt(_order, _list) == null)
                {
                    MessageBox.Show("Chưa được thanh toán đơn hàng", "In hóa đơn"); return;
                }
                var source = new ReportDataSource("Receipt", BLL_Receipt.Instance.GetListDTO_Receipt(_order, _list));
                reportViewer1.LocalReport.DataSources.Clear();
                reportViewer1.LocalReport.DataSources.Add(source);
                this.reportViewer1.LocalReport.SetParameters(BLL_Receipt.Instance.GetReportParemeters());
                this.reportViewer1.RefreshReport();
            }
            catch(Exception ex)
            {
                MessageBox.Show("Bị lỗi", "In hóa đơn");
            }
        }
    }
}
