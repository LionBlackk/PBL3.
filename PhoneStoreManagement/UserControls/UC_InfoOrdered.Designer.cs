namespace PhoneStoreManagement.UserControls
{
    partial class UC_InfoOrdered
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
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle2 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle3 = new System.Windows.Forms.DataGridViewCellStyle();
            this.backgroundWorker1 = new System.ComponentModel.BackgroundWorker();
            this.backgroundWorker2 = new System.ComponentModel.BackgroundWorker();
            this.panel1 = new System.Windows.Forms.Panel();
            this.label1 = new System.Windows.Forms.Label();
            this.txtPhoneCustomer = new System.Windows.Forms.TextBox();
            this.btnFindOrder = new System.Windows.Forms.Button();
            this.dataGridView1 = new System.Windows.Forms.DataGridView();
            this.lbPageNumber = new System.Windows.Forms.Label();
            this.btnNext = new System.Windows.Forms.Button();
            this.btnPrevious = new System.Windows.Forms.Button();
            this.iDOrderDataGridViewTextBoxColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.nameCustomerDataGridViewTextBoxColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.phoneCustomerDataGridViewTextBoxColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.addressCustomerDataGridViewTextBoxColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.iDEmployeeCreateDataGridViewTextBoxColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.iDEmployeeEditDataGridViewTextBoxColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.timeOrderDataGridViewTextBoxColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.valueDiscountDataGridViewTextBoxColumn1 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.totalDataGridViewTextBoxColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.typeOrderDataGridViewTextBoxColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.stateOrderDataGridViewTextBoxColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.dTOInfoOrderedBindingSource1 = new System.Windows.Forms.BindingSource(this.components);
            this.panel1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dataGridView1)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.dTOInfoOrderedBindingSource1)).BeginInit();
            this.SuspendLayout();
            // 
            // panel1
            // 
            this.panel1.Controls.Add(this.lbPageNumber);
            this.panel1.Controls.Add(this.btnNext);
            this.panel1.Controls.Add(this.btnPrevious);
            this.panel1.Controls.Add(this.label1);
            this.panel1.Controls.Add(this.txtPhoneCustomer);
            this.panel1.Controls.Add(this.btnFindOrder);
            this.panel1.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.panel1.Location = new System.Drawing.Point(0, 653);
            this.panel1.Margin = new System.Windows.Forms.Padding(4);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(1283, 68);
            this.panel1.TabIndex = 1;
            // 
            // label1
            // 
            this.label1.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Microsoft Sans Serif", 11.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label1.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(71)))), ((int)(((byte)(160)))));
            this.label1.Location = new System.Drawing.Point(623, 21);
            this.label1.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(134, 24);
            this.label1.TabIndex = 21;
            this.label1.Text = "Số điện thoại";
            // 
            // txtPhoneCustomer
            // 
            this.txtPhoneCustomer.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.txtPhoneCustomer.Font = new System.Drawing.Font("Microsoft Sans Serif", 10.2F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtPhoneCustomer.Location = new System.Drawing.Point(776, 17);
            this.txtPhoneCustomer.Margin = new System.Windows.Forms.Padding(4);
            this.txtPhoneCustomer.Name = "txtPhoneCustomer";
            this.txtPhoneCustomer.Size = new System.Drawing.Size(213, 27);
            this.txtPhoneCustomer.TabIndex = 20;
            // 
            // btnFindOrder
            // 
            this.btnFindOrder.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(71)))), ((int)(((byte)(160)))));
            this.btnFindOrder.Dock = System.Windows.Forms.DockStyle.Right;
            this.btnFindOrder.Font = new System.Drawing.Font("Microsoft Sans Serif", 10.2F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnFindOrder.ForeColor = System.Drawing.Color.White;
            this.btnFindOrder.Location = new System.Drawing.Point(1028, 0);
            this.btnFindOrder.Margin = new System.Windows.Forms.Padding(4);
            this.btnFindOrder.Name = "btnFindOrder";
            this.btnFindOrder.Size = new System.Drawing.Size(255, 68);
            this.btnFindOrder.TabIndex = 19;
            this.btnFindOrder.Text = "Tìm đơn hàng";
            this.btnFindOrder.TextImageRelation = System.Windows.Forms.TextImageRelation.TextBeforeImage;
            this.btnFindOrder.UseVisualStyleBackColor = false;
            this.btnFindOrder.Click += new System.EventHandler(this.btnFindOrder_Click);
            // 
            // dataGridView1
            // 
            this.dataGridView1.AutoGenerateColumns = false;
            this.dataGridView1.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.Fill;
            this.dataGridView1.BackgroundColor = System.Drawing.SystemColors.Control;
            this.dataGridView1.BorderStyle = System.Windows.Forms.BorderStyle.None;
            dataGridViewCellStyle1.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleCenter;
            dataGridViewCellStyle1.BackColor = System.Drawing.SystemColors.Control;
            dataGridViewCellStyle1.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            dataGridViewCellStyle1.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(71)))), ((int)(((byte)(160)))));
            dataGridViewCellStyle1.SelectionBackColor = System.Drawing.SystemColors.Control;
            dataGridViewCellStyle1.SelectionForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(71)))), ((int)(((byte)(160)))));
            dataGridViewCellStyle1.WrapMode = System.Windows.Forms.DataGridViewTriState.True;
            this.dataGridView1.ColumnHeadersDefaultCellStyle = dataGridViewCellStyle1;
            this.dataGridView1.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dataGridView1.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.iDOrderDataGridViewTextBoxColumn,
            this.nameCustomerDataGridViewTextBoxColumn,
            this.phoneCustomerDataGridViewTextBoxColumn,
            this.addressCustomerDataGridViewTextBoxColumn,
            this.iDEmployeeCreateDataGridViewTextBoxColumn,
            this.iDEmployeeEditDataGridViewTextBoxColumn,
            this.timeOrderDataGridViewTextBoxColumn,
            this.valueDiscountDataGridViewTextBoxColumn1,
            this.totalDataGridViewTextBoxColumn,
            this.typeOrderDataGridViewTextBoxColumn,
            this.stateOrderDataGridViewTextBoxColumn});
            this.dataGridView1.DataSource = this.dTOInfoOrderedBindingSource1;
            dataGridViewCellStyle2.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleCenter;
            dataGridViewCellStyle2.BackColor = System.Drawing.SystemColors.Control;
            dataGridViewCellStyle2.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            dataGridViewCellStyle2.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(71)))), ((int)(((byte)(160)))));
            dataGridViewCellStyle2.SelectionBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(71)))), ((int)(((byte)(160)))));
            dataGridViewCellStyle2.SelectionForeColor = System.Drawing.SystemColors.Control;
            dataGridViewCellStyle2.WrapMode = System.Windows.Forms.DataGridViewTriState.False;
            this.dataGridView1.DefaultCellStyle = dataGridViewCellStyle2;
            this.dataGridView1.Dock = System.Windows.Forms.DockStyle.Top;
            this.dataGridView1.EnableHeadersVisualStyles = false;
            this.dataGridView1.Location = new System.Drawing.Point(0, 0);
            this.dataGridView1.Margin = new System.Windows.Forms.Padding(4);
            this.dataGridView1.Name = "dataGridView1";
            dataGridViewCellStyle3.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleCenter;
            dataGridViewCellStyle3.BackColor = System.Drawing.SystemColors.Control;
            dataGridViewCellStyle3.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            dataGridViewCellStyle3.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(71)))), ((int)(((byte)(160)))));
            dataGridViewCellStyle3.SelectionBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(71)))), ((int)(((byte)(160)))));
            dataGridViewCellStyle3.SelectionForeColor = System.Drawing.SystemColors.Control;
            dataGridViewCellStyle3.WrapMode = System.Windows.Forms.DataGridViewTriState.True;
            this.dataGridView1.RowHeadersDefaultCellStyle = dataGridViewCellStyle3;
            this.dataGridView1.RowHeadersVisible = false;
            this.dataGridView1.RowHeadersWidth = 51;
            this.dataGridView1.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.dataGridView1.Size = new System.Drawing.Size(1283, 646);
            this.dataGridView1.TabIndex = 3;
            // 
            // lbPageNumber
            // 
            this.lbPageNumber.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left)));
            this.lbPageNumber.AutoSize = true;
            this.lbPageNumber.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lbPageNumber.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(71)))), ((int)(((byte)(160)))));
            this.lbPageNumber.Location = new System.Drawing.Point(145, 20);
            this.lbPageNumber.Name = "lbPageNumber";
            this.lbPageNumber.Size = new System.Drawing.Size(62, 25);
            this.lbPageNumber.TabIndex = 50;
            this.lbPageNumber.Text = "Page";
            // 
            // btnNext
            // 
            this.btnNext.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left)));
            this.btnNext.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(71)))), ((int)(((byte)(160)))));
            this.btnNext.Font = new System.Drawing.Font("Microsoft Sans Serif", 13.8F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnNext.ForeColor = System.Drawing.Color.White;
            this.btnNext.Location = new System.Drawing.Point(295, 8);
            this.btnNext.Name = "btnNext";
            this.btnNext.Size = new System.Drawing.Size(120, 47);
            this.btnNext.TabIndex = 49;
            this.btnNext.Text = ">";
            this.btnNext.TextImageRelation = System.Windows.Forms.TextImageRelation.TextBeforeImage;
            this.btnNext.UseVisualStyleBackColor = false;
            this.btnNext.Click += new System.EventHandler(this.btnNext_Click);
            // 
            // btnPrevious
            // 
            this.btnPrevious.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left)));
            this.btnPrevious.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(71)))), ((int)(((byte)(160)))));
            this.btnPrevious.Font = new System.Drawing.Font("Microsoft Sans Serif", 13.8F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnPrevious.ForeColor = System.Drawing.Color.White;
            this.btnPrevious.Location = new System.Drawing.Point(3, 8);
            this.btnPrevious.Name = "btnPrevious";
            this.btnPrevious.Size = new System.Drawing.Size(120, 47);
            this.btnPrevious.TabIndex = 48;
            this.btnPrevious.Text = "<";
            this.btnPrevious.TextImageRelation = System.Windows.Forms.TextImageRelation.TextBeforeImage;
            this.btnPrevious.UseVisualStyleBackColor = false;
            this.btnPrevious.Click += new System.EventHandler(this.btnPrevious_Click);
            // 
            // iDOrderDataGridViewTextBoxColumn
            // 
            this.iDOrderDataGridViewTextBoxColumn.DataPropertyName = "IDOrder";
            this.iDOrderDataGridViewTextBoxColumn.HeaderText = "Mã đơn hàng";
            this.iDOrderDataGridViewTextBoxColumn.MinimumWidth = 6;
            this.iDOrderDataGridViewTextBoxColumn.Name = "iDOrderDataGridViewTextBoxColumn";
            // 
            // nameCustomerDataGridViewTextBoxColumn
            // 
            this.nameCustomerDataGridViewTextBoxColumn.DataPropertyName = "NameCustomer";
            this.nameCustomerDataGridViewTextBoxColumn.HeaderText = "Khách hàng";
            this.nameCustomerDataGridViewTextBoxColumn.MinimumWidth = 6;
            this.nameCustomerDataGridViewTextBoxColumn.Name = "nameCustomerDataGridViewTextBoxColumn";
            // 
            // phoneCustomerDataGridViewTextBoxColumn
            // 
            this.phoneCustomerDataGridViewTextBoxColumn.DataPropertyName = "PhoneCustomer";
            this.phoneCustomerDataGridViewTextBoxColumn.HeaderText = "Điện thoại";
            this.phoneCustomerDataGridViewTextBoxColumn.MinimumWidth = 6;
            this.phoneCustomerDataGridViewTextBoxColumn.Name = "phoneCustomerDataGridViewTextBoxColumn";
            // 
            // addressCustomerDataGridViewTextBoxColumn
            // 
            this.addressCustomerDataGridViewTextBoxColumn.DataPropertyName = "AddressCustomer";
            this.addressCustomerDataGridViewTextBoxColumn.HeaderText = "Địa chỉ";
            this.addressCustomerDataGridViewTextBoxColumn.MinimumWidth = 6;
            this.addressCustomerDataGridViewTextBoxColumn.Name = "addressCustomerDataGridViewTextBoxColumn";
            // 
            // iDEmployeeCreateDataGridViewTextBoxColumn
            // 
            this.iDEmployeeCreateDataGridViewTextBoxColumn.DataPropertyName = "IDEmployeeCreate";
            this.iDEmployeeCreateDataGridViewTextBoxColumn.HeaderText = "Nhân viên tạo đơn";
            this.iDEmployeeCreateDataGridViewTextBoxColumn.MinimumWidth = 6;
            this.iDEmployeeCreateDataGridViewTextBoxColumn.Name = "iDEmployeeCreateDataGridViewTextBoxColumn";
            // 
            // iDEmployeeEditDataGridViewTextBoxColumn
            // 
            this.iDEmployeeEditDataGridViewTextBoxColumn.DataPropertyName = "IDEmployeeEdit";
            this.iDEmployeeEditDataGridViewTextBoxColumn.HeaderText = "Nhân viên sửa đơn";
            this.iDEmployeeEditDataGridViewTextBoxColumn.MinimumWidth = 6;
            this.iDEmployeeEditDataGridViewTextBoxColumn.Name = "iDEmployeeEditDataGridViewTextBoxColumn";
            // 
            // timeOrderDataGridViewTextBoxColumn
            // 
            this.timeOrderDataGridViewTextBoxColumn.DataPropertyName = "TimeOrder";
            this.timeOrderDataGridViewTextBoxColumn.HeaderText = "Thời gian mua hàng";
            this.timeOrderDataGridViewTextBoxColumn.MinimumWidth = 6;
            this.timeOrderDataGridViewTextBoxColumn.Name = "timeOrderDataGridViewTextBoxColumn";
            // 
            // valueDiscountDataGridViewTextBoxColumn1
            // 
            this.valueDiscountDataGridViewTextBoxColumn1.DataPropertyName = "ValueDiscount";
            this.valueDiscountDataGridViewTextBoxColumn1.HeaderText = "Giảm giá";
            this.valueDiscountDataGridViewTextBoxColumn1.MinimumWidth = 6;
            this.valueDiscountDataGridViewTextBoxColumn1.Name = "valueDiscountDataGridViewTextBoxColumn1";
            // 
            // totalDataGridViewTextBoxColumn
            // 
            this.totalDataGridViewTextBoxColumn.DataPropertyName = "Total";
            this.totalDataGridViewTextBoxColumn.HeaderText = "Thành tiền";
            this.totalDataGridViewTextBoxColumn.MinimumWidth = 6;
            this.totalDataGridViewTextBoxColumn.Name = "totalDataGridViewTextBoxColumn";
            // 
            // typeOrderDataGridViewTextBoxColumn
            // 
            this.typeOrderDataGridViewTextBoxColumn.DataPropertyName = "TypeOrder";
            this.typeOrderDataGridViewTextBoxColumn.HeaderText = "Loại đơn hàng";
            this.typeOrderDataGridViewTextBoxColumn.MinimumWidth = 6;
            this.typeOrderDataGridViewTextBoxColumn.Name = "typeOrderDataGridViewTextBoxColumn";
            // 
            // stateOrderDataGridViewTextBoxColumn
            // 
            this.stateOrderDataGridViewTextBoxColumn.DataPropertyName = "StateOrder";
            this.stateOrderDataGridViewTextBoxColumn.HeaderText = "Trạng thái đơn hàng";
            this.stateOrderDataGridViewTextBoxColumn.MinimumWidth = 6;
            this.stateOrderDataGridViewTextBoxColumn.Name = "stateOrderDataGridViewTextBoxColumn";
            this.stateOrderDataGridViewTextBoxColumn.Resizable = System.Windows.Forms.DataGridViewTriState.True;
            // 
            // dTOInfoOrderedBindingSource1
            // 
            this.dTOInfoOrderedBindingSource1.DataSource = typeof(PhoneStoreManagement.DTO.DTO_InfoOrdered);
            // 
            // UC_InfoOrdered
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.Controls.Add(this.dataGridView1);
            this.Controls.Add(this.panel1);
            this.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.Name = "UC_InfoOrdered";
            this.Size = new System.Drawing.Size(1283, 721);
            this.panel1.ResumeLayout(false);
            this.panel1.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dataGridView1)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.dTOInfoOrderedBindingSource1)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion
        private System.ComponentModel.BackgroundWorker backgroundWorker1;
        private System.ComponentModel.BackgroundWorker backgroundWorker2;
        private System.Windows.Forms.Panel panel1;
        private System.Windows.Forms.Button btnFindOrder;
        private System.Windows.Forms.TextBox txtPhoneCustomer;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.DataGridView dataGridView1;
        private System.Windows.Forms.BindingSource dTOInfoOrderedBindingSource1;
        private System.Windows.Forms.DataGridViewTextBoxColumn iDOrderDataGridViewTextBoxColumn;
        private System.Windows.Forms.DataGridViewTextBoxColumn nameCustomerDataGridViewTextBoxColumn;
        private System.Windows.Forms.DataGridViewTextBoxColumn phoneCustomerDataGridViewTextBoxColumn;
        private System.Windows.Forms.DataGridViewTextBoxColumn addressCustomerDataGridViewTextBoxColumn;
        private System.Windows.Forms.DataGridViewTextBoxColumn iDEmployeeCreateDataGridViewTextBoxColumn;
        private System.Windows.Forms.DataGridViewTextBoxColumn iDEmployeeEditDataGridViewTextBoxColumn;
        private System.Windows.Forms.DataGridViewTextBoxColumn timeOrderDataGridViewTextBoxColumn;
        private System.Windows.Forms.DataGridViewTextBoxColumn valueDiscountDataGridViewTextBoxColumn1;
        private System.Windows.Forms.DataGridViewTextBoxColumn totalDataGridViewTextBoxColumn;
        private System.Windows.Forms.DataGridViewTextBoxColumn typeOrderDataGridViewTextBoxColumn;
        private System.Windows.Forms.DataGridViewTextBoxColumn stateOrderDataGridViewTextBoxColumn;
        private System.Windows.Forms.Label lbPageNumber;
        private System.Windows.Forms.Button btnNext;
        private System.Windows.Forms.Button btnPrevious;
    }
}
