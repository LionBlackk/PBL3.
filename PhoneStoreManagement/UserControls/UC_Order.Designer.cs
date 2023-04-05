namespace PhoneStoreManagement.UserControls
{
    partial class UC_Order
    {
        /// <summary> 
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary> 
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Component Designer generated code

        /// <summary> 
        /// Required method for Designer support - do not modify 
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.components = new System.ComponentModel.Container();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle1 = new System.Windows.Forms.DataGridViewCellStyle();
            this.gbThongtinKhachhang = new System.Windows.Forms.GroupBox();
            this.groupBox7 = new System.Windows.Forms.GroupBox();
            this.Phone = new System.Windows.Forms.TextBox();
            this.Address = new System.Windows.Forms.TextBox();
            this.label2 = new System.Windows.Forms.Label();
            this.NameCustomer = new System.Windows.Forms.TextBox();
            this.label3 = new System.Windows.Forms.Label();
            this.label1 = new System.Windows.Forms.Label();
            this.groupBox9 = new System.Windows.Forms.GroupBox();
            this.btnFindCustomer = new System.Windows.Forms.Button();
            this.btnEditOrder = new System.Windows.Forms.Button();
            this.btnConfirmCustomer = new System.Windows.Forms.Button();
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.btnConfirmOrder = new System.Windows.Forms.Button();
            this.groupBox8 = new System.Windows.Forms.GroupBox();
            this.label9 = new System.Windows.Forms.Label();
            this.IDEmployeeEdit = new System.Windows.Forms.TextBox();
            this.IDEmployeeCreate = new System.Windows.Forms.TextBox();
            this.label5 = new System.Windows.Forms.Label();
            this.groupBox3 = new System.Windows.Forms.GroupBox();
            this.rdCredit = new System.Windows.Forms.RadioButton();
            this.rdDirect = new System.Windows.Forms.RadioButton();
            this.label4 = new System.Windows.Forms.Label();
            this.cbbTypeOrder = new System.Windows.Forms.ComboBox();
            this.TimeOrder = new System.Windows.Forms.DateTimePicker();
            this.label7 = new System.Windows.Forms.Label();
            this.backgroundWorker1 = new System.ComponentModel.BackgroundWorker();
            this.colorDialog1 = new System.Windows.Forms.ColorDialog();
            this.label8 = new System.Windows.Forms.Label();
            this.label11 = new System.Windows.Forms.Label();
            this.backgroundWorker2 = new System.ComponentModel.BackgroundWorker();
            this.TotalApplyedDis = new System.Windows.Forms.TextBox();
            this.groupBox4 = new System.Windows.Forms.GroupBox();
            this.groupBox5 = new System.Windows.Forms.GroupBox();
            this.groupBox2 = new System.Windows.Forms.GroupBox();
            this.btnNewOrder = new System.Windows.Forms.Button();
            this.btnPrint = new System.Windows.Forms.Button();
            this.btnCheckout = new System.Windows.Forms.Button();
            this.groupBox6 = new System.Windows.Forms.GroupBox();
            this.cbbDiscount = new System.Windows.Forms.ComboBox();
            this.label6 = new System.Windows.Forms.Label();
            this.Total = new System.Windows.Forms.TextBox();
            this.label10 = new System.Windows.Forms.Label();
            this.btnChoose = new System.Windows.Forms.Button();
            this.dgvInfoOrder = new System.Windows.Forms.DataGridView();
            this.iDPhoneDataGridViewTextBoxColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.pictureDataGridViewImageColumn = new System.Windows.Forms.DataGridViewImageColumn();
            this.namePhoneDataGridViewTextBoxColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.nameBrandDataGridViewTextBoxColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.priceDataGridViewTextBoxColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.quantityDataGridViewTextBoxColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.dTOPhoneBindingSource = new System.Windows.Forms.BindingSource(this.components);
            this.gbThongtinKhachhang.SuspendLayout();
            this.groupBox7.SuspendLayout();
            this.groupBox9.SuspendLayout();
            this.groupBox1.SuspendLayout();
            this.groupBox8.SuspendLayout();
            this.groupBox3.SuspendLayout();
            this.groupBox4.SuspendLayout();
            this.groupBox5.SuspendLayout();
            this.groupBox2.SuspendLayout();
            this.groupBox6.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dgvInfoOrder)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.dTOPhoneBindingSource)).BeginInit();
            this.SuspendLayout();
            // 
            // gbThongtinKhachhang
            // 
            this.gbThongtinKhachhang.Controls.Add(this.groupBox7);
            this.gbThongtinKhachhang.Controls.Add(this.groupBox9);
            this.gbThongtinKhachhang.Dock = System.Windows.Forms.DockStyle.Left;
            this.gbThongtinKhachhang.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.gbThongtinKhachhang.Font = new System.Drawing.Font("Microsoft Sans Serif", 10.2F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.gbThongtinKhachhang.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(71)))), ((int)(((byte)(160)))));
            this.gbThongtinKhachhang.Location = new System.Drawing.Point(3, 16);
            this.gbThongtinKhachhang.Name = "gbThongtinKhachhang";
            this.gbThongtinKhachhang.Size = new System.Drawing.Size(631, 210);
            this.gbThongtinKhachhang.TabIndex = 0;
            this.gbThongtinKhachhang.TabStop = false;
            this.gbThongtinKhachhang.Text = "Thông tin khách hàng";
            // 
            // groupBox7
            // 
            this.groupBox7.Controls.Add(this.Phone);
            this.groupBox7.Controls.Add(this.Address);
            this.groupBox7.Controls.Add(this.label2);
            this.groupBox7.Controls.Add(this.NameCustomer);
            this.groupBox7.Controls.Add(this.label3);
            this.groupBox7.Controls.Add(this.label1);
            this.groupBox7.Dock = System.Windows.Forms.DockStyle.Top;
            this.groupBox7.Location = new System.Drawing.Point(3, 19);
            this.groupBox7.Name = "groupBox7";
            this.groupBox7.Size = new System.Drawing.Size(625, 121);
            this.groupBox7.TabIndex = 23;
            this.groupBox7.TabStop = false;
            // 
            // Phone
            // 
            this.Phone.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(71)))), ((int)(((byte)(160)))));
            this.Phone.Location = new System.Drawing.Point(196, 86);
            this.Phone.Name = "Phone";
            this.Phone.Size = new System.Drawing.Size(680, 23);
            this.Phone.TabIndex = 5;
            // 
            // Address
            // 
            this.Address.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(71)))), ((int)(((byte)(160)))));
            this.Address.Location = new System.Drawing.Point(196, 47);
            this.Address.Name = "Address";
            this.Address.Size = new System.Drawing.Size(680, 23);
            this.Address.TabIndex = 4;
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(81, 52);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(58, 17);
            this.label2.TabIndex = 1;
            this.label2.Text = "Địa chỉ";
            // 
            // NameCustomer
            // 
            this.NameCustomer.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(71)))), ((int)(((byte)(160)))));
            this.NameCustomer.Location = new System.Drawing.Point(196, 11);
            this.NameCustomer.Name = "NameCustomer";
            this.NameCustomer.Size = new System.Drawing.Size(680, 23);
            this.NameCustomer.TabIndex = 3;
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(30, 90);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(104, 17);
            this.label3.TabIndex = 2;
            this.label3.Text = "Số điện thoại";
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(8, 18);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(125, 17);
            this.label1.TabIndex = 0;
            this.label1.Text = "Tên khách hàng";
            // 
            // groupBox9
            // 
            this.groupBox9.Controls.Add(this.btnFindCustomer);
            this.groupBox9.Controls.Add(this.btnEditOrder);
            this.groupBox9.Controls.Add(this.btnConfirmCustomer);
            this.groupBox9.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.groupBox9.Location = new System.Drawing.Point(3, 128);
            this.groupBox9.Name = "groupBox9";
            this.groupBox9.Size = new System.Drawing.Size(625, 79);
            this.groupBox9.TabIndex = 23;
            this.groupBox9.TabStop = false;
            // 
            // btnFindCustomer
            // 
            this.btnFindCustomer.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(71)))), ((int)(((byte)(160)))));
            this.btnFindCustomer.Dock = System.Windows.Forms.DockStyle.Left;
            this.btnFindCustomer.Font = new System.Drawing.Font("Microsoft Sans Serif", 10.2F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnFindCustomer.ForeColor = System.Drawing.Color.White;
            this.btnFindCustomer.Location = new System.Drawing.Point(217, 19);
            this.btnFindCustomer.Name = "btnFindCustomer";
            this.btnFindCustomer.Size = new System.Drawing.Size(214, 57);
            this.btnFindCustomer.TabIndex = 23;
            this.btnFindCustomer.Text = "Tìm khách hàng";
            this.btnFindCustomer.TextImageRelation = System.Windows.Forms.TextImageRelation.TextBeforeImage;
            this.btnFindCustomer.UseVisualStyleBackColor = false;
            this.btnFindCustomer.Click += new System.EventHandler(this.btnFindCustomer_Click);
            // 
            // btnEditOrder
            // 
            this.btnEditOrder.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(71)))), ((int)(((byte)(160)))));
            this.btnEditOrder.Dock = System.Windows.Forms.DockStyle.Left;
            this.btnEditOrder.Font = new System.Drawing.Font("Microsoft Sans Serif", 10.2F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnEditOrder.ForeColor = System.Drawing.Color.White;
            this.btnEditOrder.Location = new System.Drawing.Point(3, 19);
            this.btnEditOrder.Name = "btnEditOrder";
            this.btnEditOrder.Size = new System.Drawing.Size(214, 57);
            this.btnEditOrder.TabIndex = 22;
            this.btnEditOrder.Text = "Sửa đơn hàng";
            this.btnEditOrder.TextImageRelation = System.Windows.Forms.TextImageRelation.TextBeforeImage;
            this.btnEditOrder.UseVisualStyleBackColor = false;
            this.btnEditOrder.Click += new System.EventHandler(this.btnEditOrder_Click);
            // 
            // btnConfirmCustomer
            // 
            this.btnConfirmCustomer.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(71)))), ((int)(((byte)(160)))));
            this.btnConfirmCustomer.Dock = System.Windows.Forms.DockStyle.Right;
            this.btnConfirmCustomer.Font = new System.Drawing.Font("Microsoft Sans Serif", 10.2F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnConfirmCustomer.ForeColor = System.Drawing.Color.White;
            this.btnConfirmCustomer.Location = new System.Drawing.Point(431, 19);
            this.btnConfirmCustomer.Name = "btnConfirmCustomer";
            this.btnConfirmCustomer.Size = new System.Drawing.Size(191, 57);
            this.btnConfirmCustomer.TabIndex = 18;
            this.btnConfirmCustomer.Text = "Xác nhận khách hàng";
            this.btnConfirmCustomer.TextImageRelation = System.Windows.Forms.TextImageRelation.TextBeforeImage;
            this.btnConfirmCustomer.UseVisualStyleBackColor = false;
            this.btnConfirmCustomer.Click += new System.EventHandler(this.btnConfirmCustomer_Click);
            // 
            // groupBox1
            // 
            this.groupBox1.Controls.Add(this.btnConfirmOrder);
            this.groupBox1.Controls.Add(this.groupBox8);
            this.groupBox1.Dock = System.Windows.Forms.DockStyle.Right;
            this.groupBox1.Font = new System.Drawing.Font("Microsoft Sans Serif", 10.2F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.groupBox1.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(71)))), ((int)(((byte)(160)))));
            this.groupBox1.Location = new System.Drawing.Point(683, 16);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size(872, 210);
            this.groupBox1.TabIndex = 1;
            this.groupBox1.TabStop = false;
            this.groupBox1.Text = "Thông tin khác";
            // 
            // btnConfirmOrder
            // 
            this.btnConfirmOrder.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(71)))), ((int)(((byte)(160)))));
            this.btnConfirmOrder.Dock = System.Windows.Forms.DockStyle.Right;
            this.btnConfirmOrder.Font = new System.Drawing.Font("Microsoft Sans Serif", 10.2F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnConfirmOrder.ForeColor = System.Drawing.Color.White;
            this.btnConfirmOrder.Location = new System.Drawing.Point(793, 19);
            this.btnConfirmOrder.Name = "btnConfirmOrder";
            this.btnConfirmOrder.Size = new System.Drawing.Size(76, 188);
            this.btnConfirmOrder.TabIndex = 20;
            this.btnConfirmOrder.Text = "Xác nhận đơn hàng";
            this.btnConfirmOrder.TextImageRelation = System.Windows.Forms.TextImageRelation.TextBeforeImage;
            this.btnConfirmOrder.UseVisualStyleBackColor = false;
            this.btnConfirmOrder.Click += new System.EventHandler(this.btnConfirmOrder_Click);
            // 
            // groupBox8
            // 
            this.groupBox8.Controls.Add(this.label9);
            this.groupBox8.Controls.Add(this.IDEmployeeEdit);
            this.groupBox8.Controls.Add(this.IDEmployeeCreate);
            this.groupBox8.Controls.Add(this.label5);
            this.groupBox8.Controls.Add(this.groupBox3);
            this.groupBox8.Controls.Add(this.label4);
            this.groupBox8.Controls.Add(this.cbbTypeOrder);
            this.groupBox8.Controls.Add(this.TimeOrder);
            this.groupBox8.Controls.Add(this.label7);
            this.groupBox8.Dock = System.Windows.Forms.DockStyle.Left;
            this.groupBox8.Location = new System.Drawing.Point(3, 19);
            this.groupBox8.Name = "groupBox8";
            this.groupBox8.Size = new System.Drawing.Size(793, 188);
            this.groupBox8.TabIndex = 19;
            this.groupBox8.TabStop = false;
            // 
            // label9
            // 
            this.label9.AutoSize = true;
            this.label9.Location = new System.Drawing.Point(2, 46);
            this.label9.Name = "label9";
            this.label9.Size = new System.Drawing.Size(144, 17);
            this.label9.TabIndex = 17;
            this.label9.Text = "Nhân viên sửa đơn";
            // 
            // IDEmployeeEdit
            // 
            this.IDEmployeeEdit.Enabled = false;
            this.IDEmployeeEdit.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(71)))), ((int)(((byte)(160)))));
            this.IDEmployeeEdit.Location = new System.Drawing.Point(184, 39);
            this.IDEmployeeEdit.Name = "IDEmployeeEdit";
            this.IDEmployeeEdit.Size = new System.Drawing.Size(280, 23);
            this.IDEmployeeEdit.TabIndex = 16;
            // 
            // IDEmployeeCreate
            // 
            this.IDEmployeeCreate.Enabled = false;
            this.IDEmployeeCreate.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(71)))), ((int)(((byte)(160)))));
            this.IDEmployeeCreate.Location = new System.Drawing.Point(184, 4);
            this.IDEmployeeCreate.Name = "IDEmployeeCreate";
            this.IDEmployeeCreate.Size = new System.Drawing.Size(280, 23);
            this.IDEmployeeCreate.TabIndex = 6;
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Location = new System.Drawing.Point(76, 88);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(77, 17);
            this.label5.TabIndex = 15;
            this.label5.Text = "Hình thức";
            // 
            // groupBox3
            // 
            this.groupBox3.Controls.Add(this.rdCredit);
            this.groupBox3.Controls.Add(this.rdDirect);
            this.groupBox3.Dock = System.Windows.Forms.DockStyle.Right;
            this.groupBox3.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(71)))), ((int)(((byte)(160)))));
            this.groupBox3.Location = new System.Drawing.Point(499, 19);
            this.groupBox3.Name = "groupBox3";
            this.groupBox3.Size = new System.Drawing.Size(291, 166);
            this.groupBox3.TabIndex = 11;
            this.groupBox3.TabStop = false;
            this.groupBox3.Text = "Phương thức thanh toán";
            // 
            // rdCredit
            // 
            this.rdCredit.AutoSize = true;
            this.rdCredit.Location = new System.Drawing.Point(30, 63);
            this.rdCredit.Name = "rdCredit";
            this.rdCredit.Size = new System.Drawing.Size(233, 21);
            this.rdCredit.TabIndex = 1;
            this.rdCredit.TabStop = true;
            this.rdCredit.Text = "Thanh toán qua thẻ tín dụng";
            this.rdCredit.UseVisualStyleBackColor = true;
            // 
            // rdDirect
            // 
            this.rdDirect.AutoSize = true;
            this.rdDirect.Location = new System.Drawing.Point(30, 27);
            this.rdDirect.Name = "rdDirect";
            this.rdDirect.Size = new System.Drawing.Size(174, 21);
            this.rdDirect.TabIndex = 0;
            this.rdDirect.TabStop = true;
            this.rdDirect.Text = "Thanh toán trực tiếp";
            this.rdDirect.UseVisualStyleBackColor = true;
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(6, 11);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(141, 17);
            this.label4.TabIndex = 3;
            this.label4.Text = "Nhân viên tạo đơn";
            // 
            // cbbTypeOrder
            // 
            this.cbbTypeOrder.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(71)))), ((int)(((byte)(160)))));
            this.cbbTypeOrder.FormattingEnabled = true;
            this.cbbTypeOrder.Location = new System.Drawing.Point(184, 82);
            this.cbbTypeOrder.Name = "cbbTypeOrder";
            this.cbbTypeOrder.Size = new System.Drawing.Size(280, 25);
            this.cbbTypeOrder.TabIndex = 12;
            // 
            // TimeOrder
            // 
            this.TimeOrder.CalendarTitleBackColor = System.Drawing.SystemColors.ControlText;
            this.TimeOrder.CalendarTitleForeColor = System.Drawing.Color.AliceBlue;
            this.TimeOrder.Format = System.Windows.Forms.DateTimePickerFormat.Short;
            this.TimeOrder.Location = new System.Drawing.Point(184, 122);
            this.TimeOrder.Name = "TimeOrder";
            this.TimeOrder.Size = new System.Drawing.Size(280, 23);
            this.TimeOrder.TabIndex = 10;
            // 
            // label7
            // 
            this.label7.AutoSize = true;
            this.label7.Location = new System.Drawing.Point(43, 129);
            this.label7.Name = "label7";
            this.label7.Size = new System.Drawing.Size(111, 17);
            this.label7.TabIndex = 6;
            this.label7.Text = "Thời gian mua\r\n";
            // 
            // label8
            // 
            this.label8.AutoSize = true;
            this.label8.Font = new System.Drawing.Font("Microsoft Sans Serif", 10.2F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label8.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(71)))), ((int)(((byte)(160)))));
            this.label8.Location = new System.Drawing.Point(7, 53);
            this.label8.Name = "label8";
            this.label8.Size = new System.Drawing.Size(85, 17);
            this.label8.TabIndex = 6;
            this.label8.Text = "Tổng cộng";
            // 
            // label11
            // 
            this.label11.Location = new System.Drawing.Point(0, 0);
            this.label11.Name = "label11";
            this.label11.Size = new System.Drawing.Size(100, 23);
            this.label11.TabIndex = 0;
            // 
            // TotalApplyedDis
            // 
            this.TotalApplyedDis.Enabled = false;
            this.TotalApplyedDis.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(71)))), ((int)(((byte)(160)))));
            this.TotalApplyedDis.Location = new System.Drawing.Point(125, 147);
            this.TotalApplyedDis.Name = "TotalApplyedDis";
            this.TotalApplyedDis.Size = new System.Drawing.Size(349, 26);
            this.TotalApplyedDis.TabIndex = 21;
            // 
            // groupBox4
            // 
            this.groupBox4.Controls.Add(this.groupBox1);
            this.groupBox4.Controls.Add(this.gbThongtinKhachhang);
            this.groupBox4.Dock = System.Windows.Forms.DockStyle.Top;
            this.groupBox4.Location = new System.Drawing.Point(0, 0);
            this.groupBox4.Name = "groupBox4";
            this.groupBox4.Size = new System.Drawing.Size(1558, 229);
            this.groupBox4.TabIndex = 23;
            this.groupBox4.TabStop = false;
            // 
            // groupBox5
            // 
            this.groupBox5.Controls.Add(this.dgvInfoOrder);
            this.groupBox5.Controls.Add(this.groupBox2);
            this.groupBox5.Dock = System.Windows.Forms.DockStyle.Fill;
            this.groupBox5.Font = new System.Drawing.Font("Microsoft Sans Serif", 10.2F, System.Drawing.FontStyle.Bold);
            this.groupBox5.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(71)))), ((int)(((byte)(160)))));
            this.groupBox5.Location = new System.Drawing.Point(0, 229);
            this.groupBox5.Name = "groupBox5";
            this.groupBox5.Size = new System.Drawing.Size(1558, 493);
            this.groupBox5.TabIndex = 24;
            this.groupBox5.TabStop = false;
            this.groupBox5.Text = "Thông tin đơn hàng:";
            // 
            // groupBox2
            // 
            this.groupBox2.Controls.Add(this.btnNewOrder);
            this.groupBox2.Controls.Add(this.btnPrint);
            this.groupBox2.Controls.Add(this.btnCheckout);
            this.groupBox2.Controls.Add(this.groupBox6);
            this.groupBox2.Controls.Add(this.label11);
            this.groupBox2.Controls.Add(this.btnChoose);
            this.groupBox2.Dock = System.Windows.Forms.DockStyle.Right;
            this.groupBox2.Location = new System.Drawing.Point(1276, 19);
            this.groupBox2.Name = "groupBox2";
            this.groupBox2.Size = new System.Drawing.Size(279, 471);
            this.groupBox2.TabIndex = 22;
            this.groupBox2.TabStop = false;
            this.groupBox2.Text = "groupBox2";
            // 
            // btnNewOrder
            // 
            this.btnNewOrder.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(71)))), ((int)(((byte)(160)))));
            this.btnNewOrder.Dock = System.Windows.Forms.DockStyle.Top;
            this.btnNewOrder.Font = new System.Drawing.Font("Microsoft Sans Serif", 10.2F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnNewOrder.ForeColor = System.Drawing.Color.White;
            this.btnNewOrder.Image = global::PhoneStoreManagement.Properties.Resources.new_50px;
            this.btnNewOrder.Location = new System.Drawing.Point(3, 187);
            this.btnNewOrder.Name = "btnNewOrder";
            this.btnNewOrder.Size = new System.Drawing.Size(273, 56);
            this.btnNewOrder.TabIndex = 26;
            this.btnNewOrder.Text = "Hóa đơn mới";
            this.btnNewOrder.TextImageRelation = System.Windows.Forms.TextImageRelation.TextBeforeImage;
            this.btnNewOrder.UseVisualStyleBackColor = false;
            this.btnNewOrder.Click += new System.EventHandler(this.btnNewOrder_Click);
            // 
            // btnPrint
            // 
            this.btnPrint.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(71)))), ((int)(((byte)(160)))));
            this.btnPrint.Dock = System.Windows.Forms.DockStyle.Top;
            this.btnPrint.Font = new System.Drawing.Font("Microsoft Sans Serif", 10.2F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnPrint.ForeColor = System.Drawing.Color.White;
            this.btnPrint.Image = global::PhoneStoreManagement.Properties.Resources.print_50px2;
            this.btnPrint.Location = new System.Drawing.Point(3, 131);
            this.btnPrint.Name = "btnPrint";
            this.btnPrint.Size = new System.Drawing.Size(273, 56);
            this.btnPrint.TabIndex = 25;
            this.btnPrint.Text = "In hóa đơn";
            this.btnPrint.TextImageRelation = System.Windows.Forms.TextImageRelation.TextBeforeImage;
            this.btnPrint.UseVisualStyleBackColor = false;
            this.btnPrint.Click += new System.EventHandler(this.btnPrint_Click);
            // 
            // btnCheckout
            // 
            this.btnCheckout.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(71)))), ((int)(((byte)(160)))));
            this.btnCheckout.Dock = System.Windows.Forms.DockStyle.Top;
            this.btnCheckout.Font = new System.Drawing.Font("Microsoft Sans Serif", 10.2F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnCheckout.ForeColor = System.Drawing.Color.White;
            this.btnCheckout.Image = global::PhoneStoreManagement.Properties.Resources.Checkmark_50px2;
            this.btnCheckout.Location = new System.Drawing.Point(3, 75);
            this.btnCheckout.Name = "btnCheckout";
            this.btnCheckout.Size = new System.Drawing.Size(273, 56);
            this.btnCheckout.TabIndex = 24;
            this.btnCheckout.Text = "Thanh toán";
            this.btnCheckout.TextImageRelation = System.Windows.Forms.TextImageRelation.TextBeforeImage;
            this.btnCheckout.UseVisualStyleBackColor = false;
            this.btnCheckout.Click += new System.EventHandler(this.btnCheckout_Click);
            // 
            // groupBox6
            // 
            this.groupBox6.Controls.Add(this.cbbDiscount);
            this.groupBox6.Controls.Add(this.label6);
            this.groupBox6.Controls.Add(this.label8);
            this.groupBox6.Controls.Add(this.Total);
            this.groupBox6.Controls.Add(this.label10);
            this.groupBox6.Controls.Add(this.TotalApplyedDis);
            this.groupBox6.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.groupBox6.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.groupBox6.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(71)))), ((int)(((byte)(160)))));
            this.groupBox6.Location = new System.Drawing.Point(3, 291);
            this.groupBox6.Name = "groupBox6";
            this.groupBox6.Size = new System.Drawing.Size(273, 177);
            this.groupBox6.TabIndex = 23;
            this.groupBox6.TabStop = false;
            this.groupBox6.Text = "Thanh toán";
            // 
            // cbbDiscount
            // 
            this.cbbDiscount.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(71)))), ((int)(((byte)(160)))));
            this.cbbDiscount.FormattingEnabled = true;
            this.cbbDiscount.Location = new System.Drawing.Point(125, 97);
            this.cbbDiscount.Name = "cbbDiscount";
            this.cbbDiscount.Size = new System.Drawing.Size(148, 28);
            this.cbbDiscount.TabIndex = 23;
            this.cbbDiscount.SelectedIndexChanged += new System.EventHandler(this.cbbDiscount_SelectedIndexChanged);
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.Font = new System.Drawing.Font("Microsoft Sans Serif", 10.2F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label6.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(71)))), ((int)(((byte)(160)))));
            this.label6.Location = new System.Drawing.Point(6, 154);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(86, 17);
            this.label6.TabIndex = 22;
            this.label6.Text = "Thành tiền";
            // 
            // Total
            // 
            this.Total.Enabled = false;
            this.Total.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(71)))), ((int)(((byte)(160)))));
            this.Total.Location = new System.Drawing.Point(125, 53);
            this.Total.Name = "Total";
            this.Total.Size = new System.Drawing.Size(349, 26);
            this.Total.TabIndex = 6;
            // 
            // label10
            // 
            this.label10.AutoSize = true;
            this.label10.Font = new System.Drawing.Font("Microsoft Sans Serif", 10.2F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label10.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(71)))), ((int)(((byte)(160)))));
            this.label10.Location = new System.Drawing.Point(20, 108);
            this.label10.Name = "label10";
            this.label10.Size = new System.Drawing.Size(72, 17);
            this.label10.TabIndex = 16;
            this.label10.Text = "Giảm giá";
            // 
            // btnChoose
            // 
            this.btnChoose.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(71)))), ((int)(((byte)(160)))));
            this.btnChoose.Dock = System.Windows.Forms.DockStyle.Top;
            this.btnChoose.Font = new System.Drawing.Font("Microsoft Sans Serif", 10.2F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnChoose.ForeColor = System.Drawing.Color.White;
            this.btnChoose.Image = global::PhoneStoreManagement.Properties.Resources.Add_Shopping_Cart_45px;
            this.btnChoose.Location = new System.Drawing.Point(3, 19);
            this.btnChoose.Name = "btnChoose";
            this.btnChoose.Size = new System.Drawing.Size(273, 56);
            this.btnChoose.TabIndex = 14;
            this.btnChoose.Text = "Lựa chọn sản phẩm";
            this.btnChoose.TextImageRelation = System.Windows.Forms.TextImageRelation.TextBeforeImage;
            this.btnChoose.UseVisualStyleBackColor = false;
            this.btnChoose.Click += new System.EventHandler(this.btnChoose_Click);
            // 
            // dgvInfoOrder
            // 
            this.dgvInfoOrder.AllowUserToAddRows = false;
            this.dgvInfoOrder.AllowUserToResizeColumns = false;
            this.dgvInfoOrder.AllowUserToResizeRows = false;
            this.dgvInfoOrder.AutoGenerateColumns = false;
            this.dgvInfoOrder.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.Fill;
            this.dgvInfoOrder.BackgroundColor = System.Drawing.SystemColors.Control;
            this.dgvInfoOrder.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.dgvInfoOrder.ColumnHeadersBorderStyle = System.Windows.Forms.DataGridViewHeaderBorderStyle.None;
            dataGridViewCellStyle1.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleCenter;
            dataGridViewCellStyle1.BackColor = System.Drawing.SystemColors.Control;
            dataGridViewCellStyle1.Font = new System.Drawing.Font("Microsoft Sans Serif", 10.2F, System.Drawing.FontStyle.Bold);
            dataGridViewCellStyle1.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(71)))), ((int)(((byte)(160)))));
            dataGridViewCellStyle1.SelectionBackColor = System.Drawing.SystemColors.Control;
            dataGridViewCellStyle1.SelectionForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(71)))), ((int)(((byte)(160)))));
            dataGridViewCellStyle1.WrapMode = System.Windows.Forms.DataGridViewTriState.True;
            this.dgvInfoOrder.ColumnHeadersDefaultCellStyle = dataGridViewCellStyle1;
            this.dgvInfoOrder.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dgvInfoOrder.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.iDPhoneDataGridViewTextBoxColumn,
            this.pictureDataGridViewImageColumn,
            this.namePhoneDataGridViewTextBoxColumn,
            this.nameBrandDataGridViewTextBoxColumn,
            this.priceDataGridViewTextBoxColumn,
            this.quantityDataGridViewTextBoxColumn});
            this.dgvInfoOrder.DataSource = this.dTOPhoneBindingSource;
            this.dgvInfoOrder.Dock = System.Windows.Forms.DockStyle.Left;
            this.dgvInfoOrder.EnableHeadersVisualStyles = false;
            this.dgvInfoOrder.GridColor = System.Drawing.SystemColors.ButtonFace;
            this.dgvInfoOrder.Location = new System.Drawing.Point(3, 19);
            this.dgvInfoOrder.Name = "dgvInfoOrder";
            this.dgvInfoOrder.RowHeadersVisible = false;
            this.dgvInfoOrder.RowHeadersWidth = 51;
            this.dgvInfoOrder.RowHeadersWidthSizeMode = System.Windows.Forms.DataGridViewRowHeadersWidthSizeMode.DisableResizing;
            this.dgvInfoOrder.RowTemplate.Height = 200;
            this.dgvInfoOrder.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.dgvInfoOrder.Size = new System.Drawing.Size(1277, 471);
            this.dgvInfoOrder.TabIndex = 0;
            // 
            // iDPhoneDataGridViewTextBoxColumn
            // 
            this.iDPhoneDataGridViewTextBoxColumn.DataPropertyName = "IDPhone";
            this.iDPhoneDataGridViewTextBoxColumn.FillWeight = 70F;
            this.iDPhoneDataGridViewTextBoxColumn.HeaderText = "Mã";
            this.iDPhoneDataGridViewTextBoxColumn.MinimumWidth = 6;
            this.iDPhoneDataGridViewTextBoxColumn.Name = "iDPhoneDataGridViewTextBoxColumn";
            // 
            // pictureDataGridViewImageColumn
            // 
            this.pictureDataGridViewImageColumn.DataPropertyName = "Picture";
            this.pictureDataGridViewImageColumn.FillWeight = 150F;
            this.pictureDataGridViewImageColumn.HeaderText = "Hình Ảnh";
            this.pictureDataGridViewImageColumn.ImageLayout = System.Windows.Forms.DataGridViewImageCellLayout.Zoom;
            this.pictureDataGridViewImageColumn.MinimumWidth = 6;
            this.pictureDataGridViewImageColumn.Name = "pictureDataGridViewImageColumn";
            // 
            // namePhoneDataGridViewTextBoxColumn
            // 
            this.namePhoneDataGridViewTextBoxColumn.DataPropertyName = "NamePhone";
            this.namePhoneDataGridViewTextBoxColumn.HeaderText = "Điện Thoại";
            this.namePhoneDataGridViewTextBoxColumn.MinimumWidth = 6;
            this.namePhoneDataGridViewTextBoxColumn.Name = "namePhoneDataGridViewTextBoxColumn";
            // 
            // nameBrandDataGridViewTextBoxColumn
            // 
            this.nameBrandDataGridViewTextBoxColumn.DataPropertyName = "NameBrand";
            this.nameBrandDataGridViewTextBoxColumn.HeaderText = "Hãng";
            this.nameBrandDataGridViewTextBoxColumn.MinimumWidth = 6;
            this.nameBrandDataGridViewTextBoxColumn.Name = "nameBrandDataGridViewTextBoxColumn";
            // 
            // priceDataGridViewTextBoxColumn
            // 
            this.priceDataGridViewTextBoxColumn.DataPropertyName = "Price";
            this.priceDataGridViewTextBoxColumn.HeaderText = "Giá";
            this.priceDataGridViewTextBoxColumn.MinimumWidth = 6;
            this.priceDataGridViewTextBoxColumn.Name = "priceDataGridViewTextBoxColumn";
            // 
            // quantityDataGridViewTextBoxColumn
            // 
            this.quantityDataGridViewTextBoxColumn.DataPropertyName = "Quantity";
            this.quantityDataGridViewTextBoxColumn.FillWeight = 110F;
            this.quantityDataGridViewTextBoxColumn.HeaderText = "Số Lượng";
            this.quantityDataGridViewTextBoxColumn.MinimumWidth = 6;
            this.quantityDataGridViewTextBoxColumn.Name = "quantityDataGridViewTextBoxColumn";
            // 
            // dTOPhoneBindingSource
            // 
            this.dTOPhoneBindingSource.DataSource = typeof(PhoneStoreManagement.DTO.DTO_InfoOrder);
            // 
            // UC_Order
            // 
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.None;
            this.Controls.Add(this.groupBox5);
            this.Controls.Add(this.groupBox4);
            this.Name = "UC_Order";
            this.Size = new System.Drawing.Size(1558, 722);
            this.gbThongtinKhachhang.ResumeLayout(false);
            this.groupBox7.ResumeLayout(false);
            this.groupBox7.PerformLayout();
            this.groupBox9.ResumeLayout(false);
            this.groupBox1.ResumeLayout(false);
            this.groupBox8.ResumeLayout(false);
            this.groupBox8.PerformLayout();
            this.groupBox3.ResumeLayout(false);
            this.groupBox3.PerformLayout();
            this.groupBox4.ResumeLayout(false);
            this.groupBox5.ResumeLayout(false);
            this.groupBox2.ResumeLayout(false);
            this.groupBox6.ResumeLayout(false);
            this.groupBox6.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dgvInfoOrder)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.dTOPhoneBindingSource)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.GroupBox gbThongtinKhachhang;
        private System.Windows.Forms.TextBox Phone;
        private System.Windows.Forms.TextBox Address;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.TextBox NameCustomer;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.GroupBox groupBox1;
        private System.Windows.Forms.DateTimePicker TimeOrder;
        private System.Windows.Forms.TextBox IDEmployeeCreate;
        private System.Windows.Forms.Label label7;
        private System.Windows.Forms.Label label4;
        private System.ComponentModel.BackgroundWorker backgroundWorker1;
        private System.Windows.Forms.ColorDialog colorDialog1;
        private System.Windows.Forms.GroupBox groupBox3;
        private System.Windows.Forms.RadioButton rdCredit;
        private System.Windows.Forms.RadioButton rdDirect;
        private System.Windows.Forms.Button btnChoose;
        private System.Windows.Forms.Label label8;
        private System.Windows.Forms.Label label11;
        private System.ComponentModel.BackgroundWorker backgroundWorker2;
        private System.Windows.Forms.Button btnConfirmCustomer;
        private System.Windows.Forms.TextBox TotalApplyedDis;
        private System.Windows.Forms.Button btnEditOrder;
        private System.Windows.Forms.ComboBox cbbTypeOrder;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.GroupBox groupBox4;
        private System.Windows.Forms.GroupBox groupBox5;
        private System.Windows.Forms.DataGridView dgvInfoOrder;
        private System.Windows.Forms.GroupBox groupBox2;
        private System.Windows.Forms.GroupBox groupBox6;
        private System.Windows.Forms.Label label6;
        private System.Windows.Forms.Button btnCheckout;
        private System.Windows.Forms.Button btnPrint;
        private System.Windows.Forms.GroupBox groupBox7;
        private System.Windows.Forms.GroupBox groupBox8;
        private System.Windows.Forms.Label label9;
        private System.Windows.Forms.TextBox IDEmployeeEdit;
        private System.Windows.Forms.TextBox Total;
        private System.Windows.Forms.Label label10;
        private System.Windows.Forms.GroupBox groupBox9;
        private System.Windows.Forms.Button btnConfirmOrder;
        private System.Windows.Forms.BindingSource dTOPhoneBindingSource;
        private System.Windows.Forms.DataGridViewTextBoxColumn iDPhoneDataGridViewTextBoxColumn;
        private System.Windows.Forms.DataGridViewImageColumn pictureDataGridViewImageColumn;
        private System.Windows.Forms.DataGridViewTextBoxColumn namePhoneDataGridViewTextBoxColumn;
        private System.Windows.Forms.DataGridViewTextBoxColumn nameBrandDataGridViewTextBoxColumn;
        private System.Windows.Forms.DataGridViewTextBoxColumn priceDataGridViewTextBoxColumn;
        private System.Windows.Forms.DataGridViewTextBoxColumn quantityDataGridViewTextBoxColumn;
        private System.Windows.Forms.Button btnFindCustomer;
        private System.Windows.Forms.Button btnNewOrder;
        private System.Windows.Forms.ComboBox cbbDiscount;
    }
}
