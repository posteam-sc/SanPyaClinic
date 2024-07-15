namespace POS
{
    partial class TransactionDetailForm
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

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(TransactionDetailForm));
            this.label1 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.dgvTransactionDetail = new System.Windows.Forms.DataGridView();
            this.Column1 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Column2 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Column3 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Column4 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Column5 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Column9 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Column6 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Column7 = new System.Windows.Forms.DataGridViewLinkColumn();
            this.Column8 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.tlpCash = new System.Windows.Forms.TableLayoutPanel();
            this.lblTotalTax = new System.Windows.Forms.Label();
            this.label4 = new System.Windows.Forms.Label();
            this.lblDis = new System.Windows.Forms.Label();
            this.lblDiscount = new System.Windows.Forms.Label();
            this.lblt = new System.Windows.Forms.Label();
            this.label10 = new System.Windows.Forms.Label();
            this.lblPaymentMethod1 = new System.Windows.Forms.Label();
            this.lblTotal = new System.Windows.Forms.Label();
            this.lblR = new System.Windows.Forms.Label();
            this.lblRecieveAmunt = new System.Windows.Forms.Label();
            this.label6 = new System.Windows.Forms.Label();
            this.lblServiceCharges = new System.Windows.Forms.Label();
            this.label7 = new System.Windows.Forms.Label();
            this.lblConsultantFees = new System.Windows.Forms.Label();
            this.lblSalePerson = new System.Windows.Forms.Label();
            this.lblDate = new System.Windows.Forms.Label();
            this.lblTime = new System.Windows.Forms.Label();
            this.btnPrint = new System.Windows.Forms.Button();
            this.tlpCredit = new System.Windows.Forms.TableLayoutPanel();
            this.lblOutstandingAmount = new System.Windows.Forms.Label();
            this.lblPrevTitle = new System.Windows.Forms.Label();
            this.label5 = new System.Windows.Forms.Label();
            this.lblCustomerName = new System.Windows.Forms.Label();
            this.lbAdvanceSearch = new System.Windows.Forms.LinkLabel();
            this.btnUpdate = new System.Windows.Forms.Button();
            this.cboCustomer = new System.Windows.Forms.ComboBox();
            this.label8 = new System.Windows.Forms.Label();
            this.lblDoctor = new System.Windows.Forms.Label();
            this.label11 = new System.Windows.Forms.Label();
            this.lblGroup = new System.Windows.Forms.Label();
            this.lnkAssignStaff = new System.Windows.Forms.LinkLabel();
            this.lblShift = new System.Windows.Forms.Label();
            ((System.ComponentModel.ISupportInitialize)(this.dgvTransactionDetail)).BeginInit();
            this.tlpCash.SuspendLayout();
            this.tlpCredit.SuspendLayout();
            this.SuspendLayout();
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.BackColor = System.Drawing.Color.Transparent;
            this.label1.ForeColor = System.Drawing.SystemColors.ControlText;
            this.label1.Location = new System.Drawing.Point(23, 6);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(80, 20);
            this.label1.TabIndex = 0;
            this.label1.Text = "Sale Person :";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.BackColor = System.Drawing.Color.Transparent;
            this.label2.ForeColor = System.Drawing.SystemColors.ControlText;
            this.label2.Location = new System.Drawing.Point(648, 61);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(43, 20);
            this.label2.TabIndex = 1;
            this.label2.Text = "Date :";
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.BackColor = System.Drawing.Color.Transparent;
            this.label3.ForeColor = System.Drawing.SystemColors.ControlText;
            this.label3.Location = new System.Drawing.Point(647, 93);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(44, 20);
            this.label3.TabIndex = 2;
            this.label3.Text = "Time :";
            // 
            // dgvTransactionDetail
            // 
            this.dgvTransactionDetail.AllowUserToAddRows = false;
            this.dgvTransactionDetail.AllowUserToResizeColumns = false;
            this.dgvTransactionDetail.AllowUserToResizeRows = false;
            this.dgvTransactionDetail.BackgroundColor = System.Drawing.SystemColors.Window;
            this.dgvTransactionDetail.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dgvTransactionDetail.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.Column1,
            this.Column2,
            this.Column3,
            this.Column4,
            this.Column5,
            this.Column9,
            this.Column6,
            this.Column7,
            this.Column8});
            this.dgvTransactionDetail.Location = new System.Drawing.Point(22, 140);
            this.dgvTransactionDetail.Margin = new System.Windows.Forms.Padding(3, 5, 3, 5);
            this.dgvTransactionDetail.Name = "dgvTransactionDetail";
            this.dgvTransactionDetail.RowHeadersVisible = false;
            this.dgvTransactionDetail.Size = new System.Drawing.Size(1027, 333);
            this.dgvTransactionDetail.TabIndex = 3;
            this.dgvTransactionDetail.CellClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.dgvTransactionDetail_CellClick);
            this.dgvTransactionDetail.DataBindingComplete += new System.Windows.Forms.DataGridViewBindingCompleteEventHandler(this.dgvTransactionDetail_DataBindingComplete);
            // 
            // Column1
            // 
            this.Column1.HeaderText = "Product Code";
            this.Column1.Name = "Column1";
            this.Column1.Width = 120;
            // 
            // Column2
            // 
            this.Column2.HeaderText = "Product Name";
            this.Column2.Name = "Column2";
            this.Column2.Width = 200;
            // 
            // Column3
            // 
            this.Column3.HeaderText = "Qty";
            this.Column3.Name = "Column3";
            // 
            // Column4
            // 
            this.Column4.HeaderText = "Unit Price";
            this.Column4.Name = "Column4";
            this.Column4.Width = 120;
            // 
            // Column5
            // 
            this.Column5.HeaderText = "DiscountPercent";
            this.Column5.Name = "Column5";
            this.Column5.Width = 120;
            // 
            // Column9
            // 
            this.Column9.HeaderText = "Tax Percent";
            this.Column9.Name = "Column9";
            // 
            // Column6
            // 
            this.Column6.HeaderText = "Cost";
            this.Column6.Name = "Column6";
            this.Column6.Width = 120;
            // 
            // Column7
            // 
            this.Column7.HeaderText = "";
            this.Column7.Name = "Column7";
            this.Column7.Text = "Delete";
            this.Column7.UseColumnTextForLinkValue = true;
            // 
            // Column8
            // 
            this.Column8.DataPropertyName = "Id";
            this.Column8.HeaderText = "Id";
            this.Column8.Name = "Column8";
            this.Column8.Visible = false;
            // 
            // tlpCash
            // 
            this.tlpCash.BackColor = System.Drawing.Color.Transparent;
            this.tlpCash.ColumnCount = 2;
            this.tlpCash.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 38.43283F));
            this.tlpCash.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 61.56717F));
            this.tlpCash.Controls.Add(this.lblTotalTax, 1, 5);
            this.tlpCash.Controls.Add(this.label4, 0, 5);
            this.tlpCash.Controls.Add(this.lblDis, 0, 4);
            this.tlpCash.Controls.Add(this.lblDiscount, 1, 4);
            this.tlpCash.Controls.Add(this.lblt, 0, 1);
            this.tlpCash.Controls.Add(this.label10, 0, 0);
            this.tlpCash.Controls.Add(this.lblPaymentMethod1, 1, 0);
            this.tlpCash.Controls.Add(this.lblTotal, 1, 1);
            this.tlpCash.Controls.Add(this.lblR, 0, 6);
            this.tlpCash.Controls.Add(this.lblRecieveAmunt, 1, 6);
            this.tlpCash.Controls.Add(this.label6, 0, 3);
            this.tlpCash.Controls.Add(this.lblServiceCharges, 1, 3);
            this.tlpCash.Controls.Add(this.label7, 0, 2);
            this.tlpCash.Controls.Add(this.lblConsultantFees, 1, 2);
            this.tlpCash.ForeColor = System.Drawing.SystemColors.ControlText;
            this.tlpCash.Location = new System.Drawing.Point(16, 484);
            this.tlpCash.Margin = new System.Windows.Forms.Padding(3, 5, 3, 5);
            this.tlpCash.Name = "tlpCash";
            this.tlpCash.RowCount = 7;
            this.tlpCash.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 14.28531F));
            this.tlpCash.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 14.28531F));
            this.tlpCash.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 14.28816F));
            this.tlpCash.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 14.28531F));
            this.tlpCash.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 14.28531F));
            this.tlpCash.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 14.28531F));
            this.tlpCash.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 14.28531F));
            this.tlpCash.Size = new System.Drawing.Size(453, 195);
            this.tlpCash.TabIndex = 4;
            this.tlpCash.Visible = false;
            // 
            // lblTotalTax
            // 
            this.lblTotalTax.AutoSize = true;
            this.lblTotalTax.Location = new System.Drawing.Point(177, 135);
            this.lblTotalTax.Name = "lblTotalTax";
            this.lblTotalTax.Size = new System.Drawing.Size(13, 20);
            this.lblTotalTax.TabIndex = 13;
            this.lblTotalTax.Text = "-";
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(3, 135);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(77, 20);
            this.label4.TabIndex = 13;
            this.label4.Text = "Tax Amount";
            // 
            // lblDis
            // 
            this.lblDis.AutoSize = true;
            this.lblDis.Location = new System.Drawing.Point(3, 108);
            this.lblDis.Name = "lblDis";
            this.lblDis.Size = new System.Drawing.Size(104, 20);
            this.lblDis.TabIndex = 1;
            this.lblDis.Text = "Discount Amount";
            // 
            // lblDiscount
            // 
            this.lblDiscount.AutoSize = true;
            this.lblDiscount.Location = new System.Drawing.Point(177, 108);
            this.lblDiscount.Name = "lblDiscount";
            this.lblDiscount.Size = new System.Drawing.Size(13, 20);
            this.lblDiscount.TabIndex = 4;
            this.lblDiscount.Text = "-";
            // 
            // lblt
            // 
            this.lblt.AutoSize = true;
            this.lblt.Location = new System.Drawing.Point(3, 27);
            this.lblt.Name = "lblt";
            this.lblt.Size = new System.Drawing.Size(37, 20);
            this.lblt.TabIndex = 0;
            this.lblt.Text = "Total";
            // 
            // label10
            // 
            this.label10.AutoSize = true;
            this.label10.Location = new System.Drawing.Point(3, 0);
            this.label10.Name = "label10";
            this.label10.Size = new System.Drawing.Size(103, 20);
            this.label10.TabIndex = 6;
            this.label10.Text = "Payment Method";
            // 
            // lblPaymentMethod1
            // 
            this.lblPaymentMethod1.AutoSize = true;
            this.lblPaymentMethod1.Location = new System.Drawing.Point(177, 0);
            this.lblPaymentMethod1.Name = "lblPaymentMethod1";
            this.lblPaymentMethod1.Size = new System.Drawing.Size(13, 20);
            this.lblPaymentMethod1.TabIndex = 7;
            this.lblPaymentMethod1.Text = "-";
            // 
            // lblTotal
            // 
            this.lblTotal.AutoSize = true;
            this.lblTotal.Location = new System.Drawing.Point(177, 27);
            this.lblTotal.Name = "lblTotal";
            this.lblTotal.Size = new System.Drawing.Size(13, 20);
            this.lblTotal.TabIndex = 5;
            this.lblTotal.Text = "-";
            // 
            // lblR
            // 
            this.lblR.AutoSize = true;
            this.lblR.Location = new System.Drawing.Point(3, 162);
            this.lblR.Name = "lblR";
            this.lblR.Size = new System.Drawing.Size(99, 20);
            this.lblR.TabIndex = 2;
            this.lblR.Text = "Recived Amount";
            // 
            // lblRecieveAmunt
            // 
            this.lblRecieveAmunt.AutoSize = true;
            this.lblRecieveAmunt.Location = new System.Drawing.Point(177, 162);
            this.lblRecieveAmunt.Name = "lblRecieveAmunt";
            this.lblRecieveAmunt.Size = new System.Drawing.Size(13, 20);
            this.lblRecieveAmunt.TabIndex = 3;
            this.lblRecieveAmunt.Text = "-";
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.Location = new System.Drawing.Point(3, 81);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(95, 20);
            this.label6.TabIndex = 1;
            this.label6.Text = "Service Charges";
            // 
            // lblServiceCharges
            // 
            this.lblServiceCharges.AutoSize = true;
            this.lblServiceCharges.Location = new System.Drawing.Point(177, 81);
            this.lblServiceCharges.Name = "lblServiceCharges";
            this.lblServiceCharges.Size = new System.Drawing.Size(13, 20);
            this.lblServiceCharges.TabIndex = 4;
            this.lblServiceCharges.Text = "-";
            // 
            // label7
            // 
            this.label7.AutoSize = true;
            this.label7.Location = new System.Drawing.Point(3, 54);
            this.label7.Name = "label7";
            this.label7.Size = new System.Drawing.Size(96, 20);
            this.label7.TabIndex = 1;
            this.label7.Text = "Consultant Fees";
            // 
            // lblConsultantFees
            // 
            this.lblConsultantFees.AutoSize = true;
            this.lblConsultantFees.Location = new System.Drawing.Point(177, 54);
            this.lblConsultantFees.Name = "lblConsultantFees";
            this.lblConsultantFees.Size = new System.Drawing.Size(13, 20);
            this.lblConsultantFees.TabIndex = 4;
            this.lblConsultantFees.Text = "-";
            // 
            // lblSalePerson
            // 
            this.lblSalePerson.AutoSize = true;
            this.lblSalePerson.BackColor = System.Drawing.Color.Transparent;
            this.lblSalePerson.ForeColor = System.Drawing.SystemColors.ControlText;
            this.lblSalePerson.Location = new System.Drawing.Point(150, 6);
            this.lblSalePerson.Name = "lblSalePerson";
            this.lblSalePerson.Size = new System.Drawing.Size(13, 20);
            this.lblSalePerson.TabIndex = 6;
            this.lblSalePerson.Text = "-";
            // 
            // lblDate
            // 
            this.lblDate.AutoSize = true;
            this.lblDate.BackColor = System.Drawing.Color.Transparent;
            this.lblDate.ForeColor = System.Drawing.SystemColors.ControlText;
            this.lblDate.Location = new System.Drawing.Point(697, 61);
            this.lblDate.Name = "lblDate";
            this.lblDate.Size = new System.Drawing.Size(13, 20);
            this.lblDate.TabIndex = 7;
            this.lblDate.Text = "-";
            // 
            // lblTime
            // 
            this.lblTime.AutoSize = true;
            this.lblTime.BackColor = System.Drawing.Color.Transparent;
            this.lblTime.ForeColor = System.Drawing.SystemColors.ControlText;
            this.lblTime.Location = new System.Drawing.Point(696, 93);
            this.lblTime.Name = "lblTime";
            this.lblTime.Size = new System.Drawing.Size(13, 20);
            this.lblTime.TabIndex = 8;
            this.lblTime.Text = "-";
            // 
            // btnPrint
            // 
            this.btnPrint.BackColor = System.Drawing.Color.Transparent;
            this.btnPrint.FlatAppearance.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(223)))), ((int)(((byte)(223)))), ((int)(((byte)(223)))));
            this.btnPrint.FlatAppearance.BorderSize = 0;
            this.btnPrint.FlatAppearance.MouseDownBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(223)))), ((int)(((byte)(223)))), ((int)(((byte)(223)))));
            this.btnPrint.FlatAppearance.MouseOverBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(223)))), ((int)(((byte)(223)))), ((int)(((byte)(223)))));
            this.btnPrint.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnPrint.Image = global::POS.Properties.Resources.print_big;
            this.btnPrint.Location = new System.Drawing.Point(818, 484);
            this.btnPrint.Margin = new System.Windows.Forms.Padding(3, 5, 3, 5);
            this.btnPrint.Name = "btnPrint";
            this.btnPrint.Size = new System.Drawing.Size(111, 34);
            this.btnPrint.TabIndex = 9;
            this.btnPrint.UseVisualStyleBackColor = false;
            this.btnPrint.Click += new System.EventHandler(this.btnPrint_Click);
            // 
            // tlpCredit
            // 
            this.tlpCredit.BackColor = System.Drawing.Color.Transparent;
            this.tlpCredit.ColumnCount = 2;
            this.tlpCredit.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 38.40206F));
            this.tlpCredit.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 61.59794F));
            this.tlpCredit.Controls.Add(this.lblOutstandingAmount, 1, 0);
            this.tlpCredit.Controls.Add(this.lblPrevTitle, 0, 0);
            this.tlpCredit.ForeColor = System.Drawing.SystemColors.ControlText;
            this.tlpCredit.Location = new System.Drawing.Point(16, 689);
            this.tlpCredit.Margin = new System.Windows.Forms.Padding(3, 5, 3, 5);
            this.tlpCredit.Name = "tlpCredit";
            this.tlpCredit.RowCount = 1;
            this.tlpCredit.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 50F));
            this.tlpCredit.Size = new System.Drawing.Size(453, 31);
            this.tlpCredit.TabIndex = 10;
            this.tlpCredit.Visible = false;
            // 
            // lblOutstandingAmount
            // 
            this.lblOutstandingAmount.AutoSize = true;
            this.lblOutstandingAmount.Location = new System.Drawing.Point(176, 0);
            this.lblOutstandingAmount.Name = "lblOutstandingAmount";
            this.lblOutstandingAmount.Size = new System.Drawing.Size(13, 20);
            this.lblOutstandingAmount.TabIndex = 7;
            this.lblOutstandingAmount.Text = "-";
            // 
            // lblPrevTitle
            // 
            this.lblPrevTitle.AutoSize = true;
            this.lblPrevTitle.Location = new System.Drawing.Point(3, 0);
            this.lblPrevTitle.Name = "lblPrevTitle";
            this.lblPrevTitle.Size = new System.Drawing.Size(128, 20);
            this.lblPrevTitle.TabIndex = 6;
            this.lblPrevTitle.Text = "Used Prepaid Amount";
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Location = new System.Drawing.Point(23, 98);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(104, 20);
            this.label5.TabIndex = 11;
            this.label5.Text = "Customer Name :";
            // 
            // lblCustomerName
            // 
            this.lblCustomerName.AutoSize = true;
            this.lblCustomerName.Location = new System.Drawing.Point(43, 115);
            this.lblCustomerName.Name = "lblCustomerName";
            this.lblCustomerName.Size = new System.Drawing.Size(13, 20);
            this.lblCustomerName.TabIndex = 12;
            this.lblCustomerName.Text = "-";
            this.lblCustomerName.Visible = false;
            // 
            // lbAdvanceSearch
            // 
            this.lbAdvanceSearch.AutoSize = true;
            this.lbAdvanceSearch.LinkColor = System.Drawing.SystemColors.ControlText;
            this.lbAdvanceSearch.Location = new System.Drawing.Point(440, 93);
            this.lbAdvanceSearch.Name = "lbAdvanceSearch";
            this.lbAdvanceSearch.Size = new System.Drawing.Size(97, 20);
            this.lbAdvanceSearch.TabIndex = 20;
            this.lbAdvanceSearch.TabStop = true;
            this.lbAdvanceSearch.Text = "Advance Search";
            this.lbAdvanceSearch.Visible = false;
            this.lbAdvanceSearch.LinkClicked += new System.Windows.Forms.LinkLabelLinkClickedEventHandler(this.lbAdvanceSearch_LinkClicked);
            // 
            // btnUpdate
            // 
            this.btnUpdate.FlatAppearance.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(231)))), ((int)(((byte)(202)))), ((int)(((byte)(125)))));
            this.btnUpdate.FlatAppearance.BorderSize = 0;
            this.btnUpdate.FlatAppearance.MouseDownBackColor = System.Drawing.Color.Transparent;
            this.btnUpdate.FlatAppearance.MouseOverBackColor = System.Drawing.Color.Transparent;
            this.btnUpdate.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnUpdate.Image = global::POS.Properties.Resources.update_small;
            this.btnUpdate.Location = new System.Drawing.Point(341, 93);
            this.btnUpdate.Name = "btnUpdate";
            this.btnUpdate.Size = new System.Drawing.Size(75, 34);
            this.btnUpdate.TabIndex = 19;
            this.btnUpdate.UseVisualStyleBackColor = true;
            this.btnUpdate.Click += new System.EventHandler(this.btnUpdate_Click);
            // 
            // cboCustomer
            // 
            this.cboCustomer.FormattingEnabled = true;
            this.cboCustomer.Location = new System.Drawing.Point(154, 95);
            this.cboCustomer.Name = "cboCustomer";
            this.cboCustomer.Size = new System.Drawing.Size(181, 28);
            this.cboCustomer.TabIndex = 18;
            // 
            // label8
            // 
            this.label8.AutoSize = true;
            this.label8.BackColor = System.Drawing.Color.Transparent;
            this.label8.ForeColor = System.Drawing.SystemColors.ControlText;
            this.label8.Location = new System.Drawing.Point(23, 39);
            this.label8.Name = "label8";
            this.label8.Size = new System.Drawing.Size(89, 20);
            this.label8.TabIndex = 0;
            this.label8.Text = "Doctor Name :";
            // 
            // lblDoctor
            // 
            this.lblDoctor.AutoSize = true;
            this.lblDoctor.BackColor = System.Drawing.Color.Transparent;
            this.lblDoctor.ForeColor = System.Drawing.SystemColors.ControlText;
            this.lblDoctor.Location = new System.Drawing.Point(150, 39);
            this.lblDoctor.Name = "lblDoctor";
            this.lblDoctor.Size = new System.Drawing.Size(13, 20);
            this.lblDoctor.TabIndex = 6;
            this.lblDoctor.Text = "-";
            // 
            // label11
            // 
            this.label11.AutoSize = true;
            this.label11.BackColor = System.Drawing.Color.Transparent;
            this.label11.ForeColor = System.Drawing.SystemColors.ControlText;
            this.label11.Location = new System.Drawing.Point(23, 67);
            this.label11.Name = "label11";
            this.label11.Size = new System.Drawing.Size(59, 20);
            this.label11.TabIndex = 0;
            this.label11.Text = "Physio   :";
            // 
            // lblGroup
            // 
            this.lblGroup.AutoSize = true;
            this.lblGroup.BackColor = System.Drawing.Color.Transparent;
            this.lblGroup.ForeColor = System.Drawing.SystemColors.ControlText;
            this.lblGroup.Location = new System.Drawing.Point(150, 67);
            this.lblGroup.Name = "lblGroup";
            this.lblGroup.Size = new System.Drawing.Size(13, 20);
            this.lblGroup.TabIndex = 6;
            this.lblGroup.Text = "-";
            // 
            // lnkAssignStaff
            // 
            this.lnkAssignStaff.AutoSize = true;
            this.lnkAssignStaff.Location = new System.Drawing.Point(212, 67);
            this.lnkAssignStaff.Name = "lnkAssignStaff";
            this.lnkAssignStaff.Size = new System.Drawing.Size(95, 20);
            this.lnkAssignStaff.TabIndex = 45;
            this.lnkAssignStaff.TabStop = true;
            this.lnkAssignStaff.Text = "Assign Staff List";
            this.lnkAssignStaff.LinkClicked += new System.Windows.Forms.LinkLabelLinkClickedEventHandler(this.lnkAssignStaff_LinkClicked);
            // 
            // lblShift
            // 
            this.lblShift.AutoSize = true;
            this.lblShift.BackColor = System.Drawing.Color.Transparent;
            this.lblShift.ForeColor = System.Drawing.SystemColors.ControlText;
            this.lblShift.Location = new System.Drawing.Point(179, 67);
            this.lblShift.Name = "lblShift";
            this.lblShift.Size = new System.Drawing.Size(0, 20);
            this.lblShift.TabIndex = 46;
            // 
            // TransactionDetailForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 20F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(223)))), ((int)(((byte)(223)))), ((int)(((byte)(223)))));
            this.ClientSize = new System.Drawing.Size(1100, 731);
            this.Controls.Add(this.lblShift);
            this.Controls.Add(this.lnkAssignStaff);
            this.Controls.Add(this.lbAdvanceSearch);
            this.Controls.Add(this.btnUpdate);
            this.Controls.Add(this.cboCustomer);
            this.Controls.Add(this.lblCustomerName);
            this.Controls.Add(this.label5);
            this.Controls.Add(this.tlpCredit);
            this.Controls.Add(this.btnPrint);
            this.Controls.Add(this.lblTime);
            this.Controls.Add(this.lblDate);
            this.Controls.Add(this.lblGroup);
            this.Controls.Add(this.lblDoctor);
            this.Controls.Add(this.lblSalePerson);
            this.Controls.Add(this.tlpCash);
            this.Controls.Add(this.dgvTransactionDetail);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.label11);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.label8);
            this.Controls.Add(this.label1);
            this.Font = new System.Drawing.Font("Zawgyi-One", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.Margin = new System.Windows.Forms.Padding(3, 5, 3, 5);
            this.Name = "TransactionDetailForm";
            this.Text = "Transaction Detail";
            this.Load += new System.EventHandler(this.TransactionDetailForm_Load);
            ((System.ComponentModel.ISupportInitialize)(this.dgvTransactionDetail)).EndInit();
            this.tlpCash.ResumeLayout(false);
            this.tlpCash.PerformLayout();
            this.tlpCredit.ResumeLayout(false);
            this.tlpCredit.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.DataGridView dgvTransactionDetail;
        private System.Windows.Forms.TableLayoutPanel tlpCash;
        private System.Windows.Forms.Label lblt;
        private System.Windows.Forms.Label lblDis;
        private System.Windows.Forms.Label lblR;
        private System.Windows.Forms.Label lblRecieveAmunt;
        private System.Windows.Forms.Label lblDiscount;
        private System.Windows.Forms.Label lblTotal;
        private System.Windows.Forms.Label lblSalePerson;
        private System.Windows.Forms.Label lblDate;
        private System.Windows.Forms.Label lblTime;
        private System.Windows.Forms.Button btnPrint;
        private System.Windows.Forms.Label label10;
        private System.Windows.Forms.Label lblPaymentMethod1;
        private System.Windows.Forms.TableLayoutPanel tlpCredit;
        private System.Windows.Forms.Label lblPrevTitle;
        private System.Windows.Forms.Label lblOutstandingAmount;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.Label lblCustomerName;
        private System.Windows.Forms.Label lblTotalTax;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.LinkLabel lbAdvanceSearch;
        private System.Windows.Forms.Button btnUpdate;
        private System.Windows.Forms.ComboBox cboCustomer;
        private System.Windows.Forms.DataGridViewTextBoxColumn Column1;
        private System.Windows.Forms.DataGridViewTextBoxColumn Column2;
        private System.Windows.Forms.DataGridViewTextBoxColumn Column3;
        private System.Windows.Forms.DataGridViewTextBoxColumn Column4;
        private System.Windows.Forms.DataGridViewTextBoxColumn Column5;
        private System.Windows.Forms.DataGridViewTextBoxColumn Column9;
        private System.Windows.Forms.DataGridViewTextBoxColumn Column6;
        private System.Windows.Forms.DataGridViewLinkColumn Column7;
        private System.Windows.Forms.DataGridViewTextBoxColumn Column8;
        private System.Windows.Forms.Label label6;
        private System.Windows.Forms.Label lblServiceCharges;
        private System.Windows.Forms.Label label7;
        private System.Windows.Forms.Label lblConsultantFees;
        private System.Windows.Forms.Label label8;
        private System.Windows.Forms.Label lblDoctor;
        private System.Windows.Forms.Label label11;
        private System.Windows.Forms.Label lblGroup;
        private System.Windows.Forms.LinkLabel lnkAssignStaff;
        private System.Windows.Forms.Label lblShift;
    }
}