﻿namespace POS
{
    partial class Sales
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
            this.components = new System.ComponentModel.Container();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle1 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle2 = new System.Windows.Forms.DataGridViewCellStyle();
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(Sales));
            this.dgvSalesItem = new System.Windows.Forms.DataGridView();
            this.Column11 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Column1 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Column2 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Column3 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Column4 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Column5 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Column7 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Column6 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Column8 = new System.Windows.Forms.DataGridViewLinkColumn();
            this.Column13 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.tableLayoutPanel2 = new System.Windows.Forms.TableLayoutPanel();
            this.btnSave = new System.Windows.Forms.Button();
            this.btnLoadDraft = new System.Windows.Forms.Button();
            this.btnPaid = new System.Windows.Forms.Button();
            this.btnCancel = new System.Windows.Forms.Button();
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.cboProductName = new System.Windows.Forms.ComboBox();
            this.dgvSearchProductList = new System.Windows.Forms.DataGridView();
            this.Column12 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Column9 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Column10 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.btnSearch = new System.Windows.Forms.Button();
            this.label9 = new System.Windows.Forms.Label();
            this.tableLayoutPanel1 = new System.Windows.Forms.TableLayoutPanel();
            this.label4 = new System.Windows.Forms.Label();
            this.label5 = new System.Windows.Forms.Label();
            this.lblTotal = new System.Windows.Forms.Label();
            this.lblDiscountTotal = new System.Windows.Forms.Label();
            this.lblTaxTotal = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.label6 = new System.Windows.Forms.Label();
            this.txtAdditionalDiscount = new System.Windows.Forms.TextBox();
            this.label7 = new System.Windows.Forms.Label();
            this.cboPaymentMethod = new System.Windows.Forms.ComboBox();
            this.label12 = new System.Windows.Forms.Label();
            this.lblTotalQty = new System.Windows.Forms.Label();
            this.label8 = new System.Windows.Forms.Label();
            this.txtExtraTax = new System.Windows.Forms.TextBox();
            this.label15 = new System.Windows.Forms.Label();
            this.lblServiceCharges = new System.Windows.Forms.TextBox();
            this.label14 = new System.Windows.Forms.Label();
            this.lblPatient = new System.Windows.Forms.Label();
            this.btnAddNewCustomer = new System.Windows.Forms.Button();
            this.label11 = new System.Windows.Forms.Label();
            this.lblEmail = new System.Windows.Forms.Label();
            this.label13 = new System.Windows.Forms.Label();
            this.lblNRIC = new System.Windows.Forms.Label();
            this.label10 = new System.Windows.Forms.Label();
            this.lblPhoneNumber = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.lblCustomerName = new System.Windows.Forms.Label();
            this.lbAdvanceSearch = new System.Windows.Forms.LinkLabel();
            this.cboCustomer = new System.Windows.Forms.ComboBox();
            this.label1 = new System.Windows.Forms.Label();
            this.lblDoc = new System.Windows.Forms.Label();
            this.cboDoctor = new System.Windows.Forms.ComboBox();
            this.btnAddNewDoctor = new System.Windows.Forms.Button();
            this.rdoSale = new System.Windows.Forms.RadioButton();
            this.rdoPhysio = new System.Windows.Forms.RadioButton();
            this.rdoDoctor = new System.Windows.Forms.RadioButton();
            this.chkPhysio = new System.Windows.Forms.CheckBox();
            this.toolTip1 = new System.Windows.Forms.ToolTip(this.components);
            this.lblAssignStaff = new System.Windows.Forms.Label();
            this.cboAssign = new System.Windows.Forms.ComboBox();
            this.lnkAssignStaff = new System.Windows.Forms.LinkLabel();
            ((System.ComponentModel.ISupportInitialize)(this.dgvSalesItem)).BeginInit();
            this.tableLayoutPanel2.SuspendLayout();
            this.groupBox1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dgvSearchProductList)).BeginInit();
            this.tableLayoutPanel1.SuspendLayout();
            this.SuspendLayout();
            // 
            // dgvSalesItem
            // 
            this.dgvSalesItem.AllowUserToDeleteRows = false;
            this.dgvSalesItem.BackgroundColor = System.Drawing.SystemColors.Window;
            dataGridViewCellStyle1.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle1.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(196)))), ((int)(((byte)(196)))), ((int)(((byte)(196)))));
            dataGridViewCellStyle1.Font = new System.Drawing.Font("Zawgyi-One", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            dataGridViewCellStyle1.ForeColor = System.Drawing.SystemColors.WindowText;
            dataGridViewCellStyle1.SelectionBackColor = System.Drawing.SystemColors.Highlight;
            dataGridViewCellStyle1.SelectionForeColor = System.Drawing.SystemColors.HighlightText;
            dataGridViewCellStyle1.WrapMode = System.Windows.Forms.DataGridViewTriState.True;
            this.dgvSalesItem.ColumnHeadersDefaultCellStyle = dataGridViewCellStyle1;
            this.dgvSalesItem.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dgvSalesItem.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.Column11,
            this.Column1,
            this.Column2,
            this.Column3,
            this.Column4,
            this.Column5,
            this.Column7,
            this.Column6,
            this.Column8,
            this.Column13});
            this.dgvSalesItem.GridColor = System.Drawing.SystemColors.Control;
            this.dgvSalesItem.Location = new System.Drawing.Point(12, 325);
            this.dgvSalesItem.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.dgvSalesItem.MultiSelect = false;
            this.dgvSalesItem.Name = "dgvSalesItem";
            dataGridViewCellStyle2.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle2.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(196)))), ((int)(((byte)(196)))), ((int)(((byte)(196)))));
            dataGridViewCellStyle2.Font = new System.Drawing.Font("Zawgyi-One", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            dataGridViewCellStyle2.ForeColor = System.Drawing.SystemColors.WindowText;
            dataGridViewCellStyle2.SelectionBackColor = System.Drawing.SystemColors.Highlight;
            dataGridViewCellStyle2.SelectionForeColor = System.Drawing.SystemColors.HighlightText;
            dataGridViewCellStyle2.WrapMode = System.Windows.Forms.DataGridViewTriState.True;
            this.dgvSalesItem.RowHeadersDefaultCellStyle = dataGridViewCellStyle2;
            this.dgvSalesItem.RowHeadersVisible = false;
            this.dgvSalesItem.Size = new System.Drawing.Size(672, 353);
            this.dgvSalesItem.TabIndex = 1;
            this.dgvSalesItem.CellClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.dgvSalesItem_CellClick);
            this.dgvSalesItem.CellEndEdit += new System.Windows.Forms.DataGridViewCellEventHandler(this.dgvSalesItem_CellEndEdit);
            this.dgvSalesItem.CellValueChanged += new System.Windows.Forms.DataGridViewCellEventHandler(this.dgvSalesItem_CellValueChanged);
            this.dgvSalesItem.KeyDown += new System.Windows.Forms.KeyEventHandler(this.dgvSalesItem_KeyDown);
            // 
            // Column11
            // 
            this.Column11.DataPropertyName = "SKU";
            this.Column11.HeaderText = "Barcode";
            this.Column11.Name = "Column11";
            this.Column11.Width = 80;
            // 
            // Column1
            // 
            this.Column1.DataPropertyName = "ProductCode";
            this.Column1.HeaderText = "Product Code";
            this.Column1.Name = "Column1";
            // 
            // Column2
            // 
            this.Column2.HeaderText = "Qty";
            this.Column2.Name = "Column2";
            this.Column2.Width = 40;
            // 
            // Column3
            // 
            this.Column3.HeaderText = "Product Name";
            this.Column3.Name = "Column3";
            this.Column3.ReadOnly = true;
            // 
            // Column4
            // 
            this.Column4.HeaderText = "Unit Price";
            this.Column4.Name = "Column4";
            this.Column4.ReadOnly = true;
            this.Column4.Width = 80;
            // 
            // Column5
            // 
            this.Column5.HeaderText = "Discount Percent";
            this.Column5.Name = "Column5";
            this.Column5.Width = 55;
            // 
            // Column7
            // 
            this.Column7.DataPropertyName = "TaxRate";
            this.Column7.HeaderText = "Tax";
            this.Column7.Name = "Column7";
            this.Column7.ReadOnly = true;
            this.Column7.Width = 55;
            // 
            // Column6
            // 
            this.Column6.HeaderText = "Cost";
            this.Column6.Name = "Column6";
            this.Column6.ReadOnly = true;
            // 
            // Column8
            // 
            this.Column8.HeaderText = "";
            this.Column8.Name = "Column8";
            this.Column8.Text = "Delete";
            this.Column8.UseColumnTextForLinkValue = true;
            this.Column8.VisitedLinkColor = System.Drawing.Color.Blue;
            this.Column8.Width = 50;
            // 
            // Column13
            // 
            this.Column13.DataPropertyName = "ID";
            this.Column13.HeaderText = "ID";
            this.Column13.Name = "Column13";
            this.Column13.Visible = false;
            // 
            // tableLayoutPanel2
            // 
            this.tableLayoutPanel2.BackColor = System.Drawing.Color.Transparent;
            this.tableLayoutPanel2.ColumnCount = 2;
            this.tableLayoutPanel2.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 44.65649F));
            this.tableLayoutPanel2.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 55.34351F));
            this.tableLayoutPanel2.Controls.Add(this.btnSave, 0, 1);
            this.tableLayoutPanel2.Controls.Add(this.btnLoadDraft, 1, 1);
            this.tableLayoutPanel2.Controls.Add(this.btnPaid, 1, 0);
            this.tableLayoutPanel2.Controls.Add(this.btnCancel, 0, 0);
            this.tableLayoutPanel2.Location = new System.Drawing.Point(808, 518);
            this.tableLayoutPanel2.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.tableLayoutPanel2.Name = "tableLayoutPanel2";
            this.tableLayoutPanel2.RowCount = 2;
            this.tableLayoutPanel2.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 51.85185F));
            this.tableLayoutPanel2.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 48.14815F));
            this.tableLayoutPanel2.Size = new System.Drawing.Size(270, 107);
            this.tableLayoutPanel2.TabIndex = 5;
            // 
            // btnSave
            // 
            this.btnSave.FlatAppearance.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(223)))), ((int)(((byte)(223)))), ((int)(((byte)(223)))));
            this.btnSave.FlatAppearance.BorderSize = 0;
            this.btnSave.FlatAppearance.MouseDownBackColor = System.Drawing.Color.Transparent;
            this.btnSave.FlatAppearance.MouseOverBackColor = System.Drawing.Color.Transparent;
            this.btnSave.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnSave.Image = global::POS.Properties.Resources.saveasdraft_big2;
            this.btnSave.Location = new System.Drawing.Point(3, 59);
            this.btnSave.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.btnSave.Name = "btnSave";
            this.btnSave.Size = new System.Drawing.Size(114, 37);
            this.btnSave.TabIndex = 7;
            this.btnSave.UseVisualStyleBackColor = true;
            this.btnSave.Click += new System.EventHandler(this.btnSave_Click);
            // 
            // btnLoadDraft
            // 
            this.btnLoadDraft.FlatAppearance.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(223)))), ((int)(((byte)(223)))), ((int)(((byte)(223)))));
            this.btnLoadDraft.FlatAppearance.BorderSize = 0;
            this.btnLoadDraft.FlatAppearance.MouseDownBackColor = System.Drawing.Color.Transparent;
            this.btnLoadDraft.FlatAppearance.MouseOverBackColor = System.Drawing.Color.Transparent;
            this.btnLoadDraft.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnLoadDraft.Image = global::POS.Properties.Resources.loaddraft_big2;
            this.btnLoadDraft.Location = new System.Drawing.Point(123, 59);
            this.btnLoadDraft.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.btnLoadDraft.Name = "btnLoadDraft";
            this.btnLoadDraft.Size = new System.Drawing.Size(137, 37);
            this.btnLoadDraft.TabIndex = 8;
            this.btnLoadDraft.UseVisualStyleBackColor = true;
            this.btnLoadDraft.Click += new System.EventHandler(this.btnLoadDraft_Click);
            // 
            // btnPaid
            // 
            this.btnPaid.FlatAppearance.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(223)))), ((int)(((byte)(223)))), ((int)(((byte)(223)))));
            this.btnPaid.FlatAppearance.BorderSize = 0;
            this.btnPaid.FlatAppearance.MouseDownBackColor = System.Drawing.Color.Transparent;
            this.btnPaid.FlatAppearance.MouseOverBackColor = System.Drawing.Color.Transparent;
            this.btnPaid.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnPaid.ForeColor = System.Drawing.Color.Transparent;
            this.btnPaid.Image = global::POS.Properties.Resources.paid_big2;
            this.btnPaid.Location = new System.Drawing.Point(123, 4);
            this.btnPaid.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.btnPaid.Name = "btnPaid";
            this.btnPaid.Size = new System.Drawing.Size(136, 40);
            this.btnPaid.TabIndex = 5;
            this.btnPaid.UseVisualStyleBackColor = true;
            this.btnPaid.Click += new System.EventHandler(this.btnPaid_Click);
            // 
            // btnCancel
            // 
            this.btnCancel.FlatAppearance.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(223)))), ((int)(((byte)(223)))), ((int)(((byte)(223)))));
            this.btnCancel.FlatAppearance.BorderSize = 0;
            this.btnCancel.FlatAppearance.MouseDownBackColor = System.Drawing.Color.Transparent;
            this.btnCancel.FlatAppearance.MouseOverBackColor = System.Drawing.Color.Transparent;
            this.btnCancel.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnCancel.Image = global::POS.Properties.Resources.cancel_big2;
            this.btnCancel.Location = new System.Drawing.Point(3, 4);
            this.btnCancel.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.btnCancel.Name = "btnCancel";
            this.btnCancel.Size = new System.Drawing.Size(114, 40);
            this.btnCancel.TabIndex = 6;
            this.btnCancel.UseVisualStyleBackColor = true;
            this.btnCancel.Click += new System.EventHandler(this.btnCancel_Click);
            // 
            // groupBox1
            // 
            this.groupBox1.BackColor = System.Drawing.Color.Transparent;
            this.groupBox1.Controls.Add(this.cboProductName);
            this.groupBox1.Controls.Add(this.dgvSearchProductList);
            this.groupBox1.Controls.Add(this.btnSearch);
            this.groupBox1.Controls.Add(this.label9);
            this.groupBox1.Font = new System.Drawing.Font("Zawgyi-One", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.groupBox1.Location = new System.Drawing.Point(711, 118);
            this.groupBox1.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Padding = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.groupBox1.Size = new System.Drawing.Size(459, 236);
            this.groupBox1.TabIndex = 6;
            this.groupBox1.TabStop = false;
            this.groupBox1.Text = "Search Product Code By Product Name";
            // 
            // cboProductName
            // 
            this.cboProductName.FormattingEnabled = true;
            this.cboProductName.Location = new System.Drawing.Point(71, 40);
            this.cboProductName.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.cboProductName.Name = "cboProductName";
            this.cboProductName.Size = new System.Drawing.Size(223, 28);
            this.cboProductName.TabIndex = 9;
            this.cboProductName.KeyDown += new System.Windows.Forms.KeyEventHandler(this.cboProductName_KeyDown);
            // 
            // dgvSearchProductList
            // 
            this.dgvSearchProductList.AllowUserToAddRows = false;
            this.dgvSearchProductList.AllowUserToDeleteRows = false;
            this.dgvSearchProductList.AllowUserToOrderColumns = true;
            this.dgvSearchProductList.AllowUserToResizeColumns = false;
            this.dgvSearchProductList.AllowUserToResizeRows = false;
            this.dgvSearchProductList.BackgroundColor = System.Drawing.SystemColors.Window;
            this.dgvSearchProductList.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dgvSearchProductList.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.Column12,
            this.Column9,
            this.Column10});
            this.dgvSearchProductList.Location = new System.Drawing.Point(6, 88);
            this.dgvSearchProductList.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.dgvSearchProductList.Name = "dgvSearchProductList";
            this.dgvSearchProductList.RowHeadersVisible = false;
            this.dgvSearchProductList.Size = new System.Drawing.Size(445, 136);
            this.dgvSearchProductList.TabIndex = 11;
            this.dgvSearchProductList.CellClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.dgvSearchProductList_CellClick);
            this.dgvSearchProductList.KeyDown += new System.Windows.Forms.KeyEventHandler(this.dgvSearchProductList_KeyDown);
            // 
            // Column12
            // 
            this.Column12.DataPropertyName = "Id";
            this.Column12.HeaderText = "Id";
            this.Column12.Name = "Column12";
            this.Column12.Visible = false;
            // 
            // Column9
            // 
            this.Column9.DataPropertyName = "ProductCode";
            this.Column9.HeaderText = "Product Code";
            this.Column9.Name = "Column9";
            this.Column9.Width = 120;
            // 
            // Column10
            // 
            this.Column10.DataPropertyName = "Name";
            this.Column10.HeaderText = "Product Name";
            this.Column10.Name = "Column10";
            this.Column10.Width = 290;
            // 
            // btnSearch
            // 
            this.btnSearch.BackColor = System.Drawing.Color.Transparent;
            this.btnSearch.FlatAppearance.BorderSize = 0;
            this.btnSearch.FlatAppearance.MouseDownBackColor = System.Drawing.Color.Transparent;
            this.btnSearch.FlatAppearance.MouseOverBackColor = System.Drawing.Color.Transparent;
            this.btnSearch.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnSearch.ForeColor = System.Drawing.Color.Transparent;
            this.btnSearch.Image = global::POS.Properties.Resources.search_small;
            this.btnSearch.Location = new System.Drawing.Point(310, 27);
            this.btnSearch.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.btnSearch.Name = "btnSearch";
            this.btnSearch.Size = new System.Drawing.Size(75, 53);
            this.btnSearch.TabIndex = 10;
            this.btnSearch.UseVisualStyleBackColor = true;
            this.btnSearch.Click += new System.EventHandler(this.btnSearch_Click);
            // 
            // label9
            // 
            this.label9.AutoSize = true;
            this.label9.Location = new System.Drawing.Point(2, 44);
            this.label9.Name = "label9";
            this.label9.Size = new System.Drawing.Size(48, 20);
            this.label9.TabIndex = 0;
            this.label9.Text = "&Name :";
            // 
            // tableLayoutPanel1
            // 
            this.tableLayoutPanel1.BackColor = System.Drawing.Color.Transparent;
            this.tableLayoutPanel1.ColumnCount = 4;
            this.tableLayoutPanel1.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 55.40541F));
            this.tableLayoutPanel1.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 44.59459F));
            this.tableLayoutPanel1.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Absolute, 87F));
            this.tableLayoutPanel1.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Absolute, 168F));
            this.tableLayoutPanel1.Controls.Add(this.label4, 0, 1);
            this.tableLayoutPanel1.Controls.Add(this.label5, 0, 2);
            this.tableLayoutPanel1.Controls.Add(this.lblTotal, 1, 0);
            this.tableLayoutPanel1.Controls.Add(this.lblDiscountTotal, 1, 1);
            this.tableLayoutPanel1.Controls.Add(this.lblTaxTotal, 1, 2);
            this.tableLayoutPanel1.Controls.Add(this.label3, 0, 0);
            this.tableLayoutPanel1.Controls.Add(this.label6, 2, 0);
            this.tableLayoutPanel1.Controls.Add(this.txtAdditionalDiscount, 3, 0);
            this.tableLayoutPanel1.Controls.Add(this.label7, 2, 1);
            this.tableLayoutPanel1.Controls.Add(this.cboPaymentMethod, 3, 1);
            this.tableLayoutPanel1.Controls.Add(this.label12, 0, 3);
            this.tableLayoutPanel1.Controls.Add(this.lblTotalQty, 1, 3);
            this.tableLayoutPanel1.Controls.Add(this.label8, 0, 4);
            this.tableLayoutPanel1.Controls.Add(this.txtExtraTax, 1, 4);
            this.tableLayoutPanel1.Controls.Add(this.label15, 2, 2);
            this.tableLayoutPanel1.Controls.Add(this.lblServiceCharges, 3, 2);
            this.tableLayoutPanel1.Controls.Add(this.label14, 2, 3);
            this.tableLayoutPanel1.Controls.Add(this.lblPatient, 3, 3);
            this.tableLayoutPanel1.ForeColor = System.Drawing.SystemColors.ControlText;
            this.tableLayoutPanel1.Location = new System.Drawing.Point(711, 364);
            this.tableLayoutPanel1.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.tableLayoutPanel1.Name = "tableLayoutPanel1";
            this.tableLayoutPanel1.RowCount = 5;
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 24.99875F));
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 24.99875F));
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 24.99875F));
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 25.00375F));
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 30F));
            this.tableLayoutPanel1.Size = new System.Drawing.Size(451, 152);
            this.tableLayoutPanel1.TabIndex = 4;
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(3, 30);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(76, 18);
            this.label4.TabIndex = 1;
            this.label4.Text = "Total Discount";
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Location = new System.Drawing.Point(3, 60);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(53, 18);
            this.label5.TabIndex = 2;
            this.label5.Text = "Total Tax";
            // 
            // lblTotal
            // 
            this.lblTotal.AutoSize = true;
            this.lblTotal.Location = new System.Drawing.Point(111, 0);
            this.lblTotal.Name = "lblTotal";
            this.lblTotal.Size = new System.Drawing.Size(14, 18);
            this.lblTotal.TabIndex = 6;
            this.lblTotal.Text = "0";
            // 
            // lblDiscountTotal
            // 
            this.lblDiscountTotal.AutoSize = true;
            this.lblDiscountTotal.Location = new System.Drawing.Point(111, 30);
            this.lblDiscountTotal.Name = "lblDiscountTotal";
            this.lblDiscountTotal.Size = new System.Drawing.Size(14, 18);
            this.lblDiscountTotal.TabIndex = 7;
            this.lblDiscountTotal.Text = "0";
            // 
            // lblTaxTotal
            // 
            this.lblTaxTotal.AutoSize = true;
            this.lblTaxTotal.Location = new System.Drawing.Point(111, 60);
            this.lblTaxTotal.Name = "lblTaxTotal";
            this.lblTaxTotal.Size = new System.Drawing.Size(14, 18);
            this.lblTaxTotal.TabIndex = 8;
            this.lblTaxTotal.Text = "0";
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(3, 0);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(53, 18);
            this.label3.TabIndex = 0;
            this.label3.Text = "Sub Total";
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.Location = new System.Drawing.Point(198, 0);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(52, 30);
            this.label6.TabIndex = 3;
            this.label6.Text = "Discount Amount";
            // 
            // txtAdditionalDiscount
            // 
            this.txtAdditionalDiscount.Location = new System.Drawing.Point(285, 4);
            this.txtAdditionalDiscount.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.txtAdditionalDiscount.Name = "txtAdditionalDiscount";
            this.txtAdditionalDiscount.Size = new System.Drawing.Size(109, 25);
            this.txtAdditionalDiscount.TabIndex = 2;
            this.txtAdditionalDiscount.Text = "0";
            this.txtAdditionalDiscount.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.txtAdditionalDiscount_KeyPress);
            // 
            // label7
            // 
            this.label7.AutoSize = true;
            this.label7.Location = new System.Drawing.Point(198, 30);
            this.label7.Name = "label7";
            this.label7.Size = new System.Drawing.Size(53, 30);
            this.label7.TabIndex = 10;
            this.label7.Text = "Payment Method";
            // 
            // cboPaymentMethod
            // 
            this.cboPaymentMethod.FormattingEnabled = true;
            this.cboPaymentMethod.Location = new System.Drawing.Point(285, 34);
            this.cboPaymentMethod.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.cboPaymentMethod.Name = "cboPaymentMethod";
            this.cboPaymentMethod.Size = new System.Drawing.Size(109, 26);
            this.cboPaymentMethod.TabIndex = 4;
            this.cboPaymentMethod.SelectedIndexChanged += new System.EventHandler(this.cboPaymentMethod_SelectedIndexChanged);
            // 
            // label12
            // 
            this.label12.AutoSize = true;
            this.label12.Location = new System.Drawing.Point(3, 90);
            this.label12.Name = "label12";
            this.label12.Size = new System.Drawing.Size(53, 18);
            this.label12.TabIndex = 2;
            this.label12.Text = "Total Qty";
            this.label12.Click += new System.EventHandler(this.label12_Click);
            // 
            // lblTotalQty
            // 
            this.lblTotalQty.AutoSize = true;
            this.lblTotalQty.Location = new System.Drawing.Point(111, 90);
            this.lblTotalQty.Name = "lblTotalQty";
            this.lblTotalQty.Size = new System.Drawing.Size(14, 18);
            this.lblTotalQty.TabIndex = 8;
            this.lblTotalQty.Text = "0";
            // 
            // label8
            // 
            this.label8.AutoSize = true;
            this.label8.Location = new System.Drawing.Point(3, 120);
            this.label8.Name = "label8";
            this.label8.Size = new System.Drawing.Size(66, 18);
            this.label8.TabIndex = 6;
            this.label8.Text = "Tax Amount";
            this.label8.Visible = false;
            // 
            // txtExtraTax
            // 
            this.txtExtraTax.Location = new System.Drawing.Point(111, 124);
            this.txtExtraTax.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.txtExtraTax.Name = "txtExtraTax";
            this.txtExtraTax.Size = new System.Drawing.Size(33, 25);
            this.txtExtraTax.TabIndex = 3;
            this.txtExtraTax.Text = "0";
            this.txtExtraTax.Visible = false;
            this.txtExtraTax.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.txtExtraTax_KeyPress);
            // 
            // label15
            // 
            this.label15.AutoSize = true;
            this.label15.Location = new System.Drawing.Point(198, 60);
            this.label15.Name = "label15";
            this.label15.Size = new System.Drawing.Size(48, 30);
            this.label15.TabIndex = 6;
            this.label15.Text = "Service Charges";
            // 
            // lblServiceCharges
            // 
            this.lblServiceCharges.Location = new System.Drawing.Point(285, 63);
            this.lblServiceCharges.Name = "lblServiceCharges";
            this.lblServiceCharges.Size = new System.Drawing.Size(110, 25);
            this.lblServiceCharges.TabIndex = 11;
            this.lblServiceCharges.Text = "0";
            this.lblServiceCharges.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.lblServiceCharges_KeyPress);
            // 
            // label14
            // 
            this.label14.AutoSize = true;
            this.label14.Location = new System.Drawing.Point(198, 90);
            this.label14.Name = "label14";
            this.label14.Size = new System.Drawing.Size(63, 30);
            this.label14.TabIndex = 6;
            this.label14.Text = "Consultant Fees";
            // 
            // lblPatient
            // 
            this.lblPatient.AutoSize = true;
            this.lblPatient.Location = new System.Drawing.Point(285, 90);
            this.lblPatient.Name = "lblPatient";
            this.lblPatient.Size = new System.Drawing.Size(14, 18);
            this.lblPatient.TabIndex = 12;
            this.lblPatient.Text = "0";
            // 
            // btnAddNewCustomer
            // 
            this.btnAddNewCustomer.BackColor = System.Drawing.Color.Transparent;
            this.btnAddNewCustomer.FlatAppearance.BorderSize = 0;
            this.btnAddNewCustomer.FlatAppearance.MouseDownBackColor = System.Drawing.Color.Transparent;
            this.btnAddNewCustomer.FlatAppearance.MouseOverBackColor = System.Drawing.Color.Transparent;
            this.btnAddNewCustomer.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnAddNewCustomer.ForeColor = System.Drawing.SystemColors.ControlText;
            this.btnAddNewCustomer.Image = global::POS.Properties.Resources.new_cust;
            this.btnAddNewCustomer.Location = new System.Drawing.Point(341, 214);
            this.btnAddNewCustomer.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.btnAddNewCustomer.Name = "btnAddNewCustomer";
            this.btnAddNewCustomer.Size = new System.Drawing.Size(93, 29);
            this.btnAddNewCustomer.TabIndex = 35;
            this.btnAddNewCustomer.UseVisualStyleBackColor = true;
            this.btnAddNewCustomer.Click += new System.EventHandler(this.btnAddNewCustomer_Click);
            // 
            // label11
            // 
            this.label11.AutoSize = true;
            this.label11.BackColor = System.Drawing.Color.Transparent;
            this.label11.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(79)))), ((int)(((byte)(55)))), ((int)(((byte)(46)))));
            this.label11.Location = new System.Drawing.Point(374, 292);
            this.label11.Name = "label11";
            this.label11.Size = new System.Drawing.Size(39, 18);
            this.label11.TabIndex = 34;
            this.label11.Text = "Email :";
            // 
            // lblEmail
            // 
            this.lblEmail.AutoSize = true;
            this.lblEmail.BackColor = System.Drawing.Color.Transparent;
            this.lblEmail.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(79)))), ((int)(((byte)(55)))), ((int)(((byte)(46)))));
            this.lblEmail.Location = new System.Drawing.Point(419, 291);
            this.lblEmail.Name = "lblEmail";
            this.lblEmail.Size = new System.Drawing.Size(12, 18);
            this.lblEmail.TabIndex = 33;
            this.lblEmail.Text = "-";
            // 
            // label13
            // 
            this.label13.AutoSize = true;
            this.label13.BackColor = System.Drawing.Color.Transparent;
            this.label13.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(79)))), ((int)(((byte)(55)))), ((int)(((byte)(46)))));
            this.label13.Location = new System.Drawing.Point(373, 263);
            this.label13.Name = "label13";
            this.label13.Size = new System.Drawing.Size(40, 18);
            this.label13.TabIndex = 32;
            this.label13.Text = "NRIC :";
            // 
            // lblNRIC
            // 
            this.lblNRIC.AutoSize = true;
            this.lblNRIC.BackColor = System.Drawing.Color.Transparent;
            this.lblNRIC.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(79)))), ((int)(((byte)(55)))), ((int)(((byte)(46)))));
            this.lblNRIC.Location = new System.Drawing.Point(419, 263);
            this.lblNRIC.Name = "lblNRIC";
            this.lblNRIC.Size = new System.Drawing.Size(12, 18);
            this.lblNRIC.TabIndex = 31;
            this.lblNRIC.Text = "-";
            // 
            // label10
            // 
            this.label10.AutoSize = true;
            this.label10.BackColor = System.Drawing.Color.Transparent;
            this.label10.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(79)))), ((int)(((byte)(55)))), ((int)(((byte)(46)))));
            this.label10.Location = new System.Drawing.Point(12, 295);
            this.label10.Name = "label10";
            this.label10.Size = new System.Drawing.Size(91, 18);
            this.label10.TabIndex = 30;
            this.label10.Text = "Phone Number   :";
            // 
            // lblPhoneNumber
            // 
            this.lblPhoneNumber.AutoSize = true;
            this.lblPhoneNumber.BackColor = System.Drawing.Color.Transparent;
            this.lblPhoneNumber.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(79)))), ((int)(((byte)(55)))), ((int)(((byte)(46)))));
            this.lblPhoneNumber.Location = new System.Drawing.Point(105, 295);
            this.lblPhoneNumber.Name = "lblPhoneNumber";
            this.lblPhoneNumber.Size = new System.Drawing.Size(12, 18);
            this.lblPhoneNumber.TabIndex = 29;
            this.lblPhoneNumber.Text = "-";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.BackColor = System.Drawing.Color.Transparent;
            this.label2.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(79)))), ((int)(((byte)(55)))), ((int)(((byte)(46)))));
            this.label2.Location = new System.Drawing.Point(12, 263);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(89, 18);
            this.label2.TabIndex = 28;
            this.label2.Text = "Customer Code :";
            // 
            // lblCustomerName
            // 
            this.lblCustomerName.AutoSize = true;
            this.lblCustomerName.BackColor = System.Drawing.Color.Transparent;
            this.lblCustomerName.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(79)))), ((int)(((byte)(55)))), ((int)(((byte)(46)))));
            this.lblCustomerName.Location = new System.Drawing.Point(105, 263);
            this.lblCustomerName.Name = "lblCustomerName";
            this.lblCustomerName.Size = new System.Drawing.Size(12, 18);
            this.lblCustomerName.TabIndex = 27;
            this.lblCustomerName.Text = "-";
            // 
            // lbAdvanceSearch
            // 
            this.lbAdvanceSearch.AutoSize = true;
            this.lbAdvanceSearch.BackColor = System.Drawing.Color.Transparent;
            this.lbAdvanceSearch.Font = new System.Drawing.Font("Zawgyi-One", 8.25F, System.Drawing.FontStyle.Underline, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lbAdvanceSearch.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(79)))), ((int)(((byte)(55)))), ((int)(((byte)(46)))));
            this.lbAdvanceSearch.LinkBehavior = System.Windows.Forms.LinkBehavior.AlwaysUnderline;
            this.lbAdvanceSearch.LinkColor = System.Drawing.Color.FromArgb(((int)(((byte)(79)))), ((int)(((byte)(55)))), ((int)(((byte)(46)))));
            this.lbAdvanceSearch.Location = new System.Drawing.Point(435, 219);
            this.lbAdvanceSearch.Name = "lbAdvanceSearch";
            this.lbAdvanceSearch.Size = new System.Drawing.Size(86, 18);
            this.lbAdvanceSearch.TabIndex = 26;
            this.lbAdvanceSearch.TabStop = true;
            this.lbAdvanceSearch.Text = "Advance Search";
            this.lbAdvanceSearch.Visible = false;
            this.lbAdvanceSearch.LinkClicked += new System.Windows.Forms.LinkLabelLinkClickedEventHandler(this.lbAdvanceSearch_LinkClicked);
            // 
            // cboCustomer
            // 
            this.cboCustomer.FormattingEnabled = true;
            this.cboCustomer.Location = new System.Drawing.Point(110, 217);
            this.cboCustomer.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.cboCustomer.Name = "cboCustomer";
            this.cboCustomer.Size = new System.Drawing.Size(223, 26);
            this.cboCustomer.TabIndex = 25;
            this.cboCustomer.SelectedIndexChanged += new System.EventHandler(this.cboCustomer_SelectedIndexChanged);
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.BackColor = System.Drawing.Color.Transparent;
            this.label1.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(79)))), ((int)(((byte)(55)))), ((int)(((byte)(46)))));
            this.label1.Location = new System.Drawing.Point(13, 220);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(93, 18);
            this.label1.TabIndex = 24;
            this.label1.Text = "Select Customer :";
            // 
            // lblDoc
            // 
            this.lblDoc.AutoSize = true;
            this.lblDoc.BackColor = System.Drawing.Color.Transparent;
            this.lblDoc.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(79)))), ((int)(((byte)(55)))), ((int)(((byte)(46)))));
            this.lblDoc.Location = new System.Drawing.Point(13, 135);
            this.lblDoc.Name = "lblDoc";
            this.lblDoc.Size = new System.Drawing.Size(79, 18);
            this.lblDoc.TabIndex = 24;
            this.lblDoc.Text = "Select Doctor :";
            // 
            // cboDoctor
            // 
            this.cboDoctor.FormattingEnabled = true;
            this.cboDoctor.Location = new System.Drawing.Point(110, 132);
            this.cboDoctor.Name = "cboDoctor";
            this.cboDoctor.Size = new System.Drawing.Size(223, 26);
            this.cboDoctor.TabIndex = 36;
            this.cboDoctor.SelectedValueChanged += new System.EventHandler(this.cboDoctor_SelectedValueChanged);
            // 
            // btnAddNewDoctor
            // 
            this.btnAddNewDoctor.BackColor = System.Drawing.Color.Transparent;
            this.btnAddNewDoctor.FlatAppearance.BorderSize = 0;
            this.btnAddNewDoctor.FlatAppearance.MouseDownBackColor = System.Drawing.Color.Transparent;
            this.btnAddNewDoctor.FlatAppearance.MouseOverBackColor = System.Drawing.Color.Transparent;
            this.btnAddNewDoctor.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnAddNewDoctor.ForeColor = System.Drawing.SystemColors.ControlText;
            this.btnAddNewDoctor.Image = global::POS.Properties.Resources.new_doc3;
            this.btnAddNewDoctor.Location = new System.Drawing.Point(341, 132);
            this.btnAddNewDoctor.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.btnAddNewDoctor.Name = "btnAddNewDoctor";
            this.btnAddNewDoctor.Size = new System.Drawing.Size(93, 29);
            this.btnAddNewDoctor.TabIndex = 35;
            this.btnAddNewDoctor.UseVisualStyleBackColor = true;
            this.btnAddNewDoctor.Click += new System.EventHandler(this.btnAddNewDoctor_Click);
            // 
            // rdoSale
            // 
            this.rdoSale.AutoSize = true;
            this.rdoSale.BackColor = System.Drawing.Color.Transparent;
            this.rdoSale.Location = new System.Drawing.Point(341, 69);
            this.rdoSale.Name = "rdoSale";
            this.rdoSale.Size = new System.Drawing.Size(46, 22);
            this.rdoSale.TabIndex = 37;
            this.rdoSale.Text = "Sale";
            this.rdoSale.UseVisualStyleBackColor = false;
            this.rdoSale.CheckedChanged += new System.EventHandler(this.rdoSale_CheckedChanged);
            // 
            // rdoPhysio
            // 
            this.rdoPhysio.AutoSize = true;
            this.rdoPhysio.BackColor = System.Drawing.Color.Transparent;
            this.rdoPhysio.Location = new System.Drawing.Point(157, 69);
            this.rdoPhysio.Name = "rdoPhysio";
            this.rdoPhysio.Size = new System.Drawing.Size(102, 22);
            this.rdoPhysio.TabIndex = 38;
            this.rdoPhysio.Text = "Physio or X-Ray";
            this.rdoPhysio.UseVisualStyleBackColor = false;
            this.rdoPhysio.CheckedChanged += new System.EventHandler(this.rdoPhysio_CheckedChanged);
            // 
            // rdoDoctor
            // 
            this.rdoDoctor.AutoSize = true;
            this.rdoDoctor.BackColor = System.Drawing.Color.Transparent;
            this.rdoDoctor.Checked = true;
            this.rdoDoctor.Location = new System.Drawing.Point(49, 69);
            this.rdoDoctor.Name = "rdoDoctor";
            this.rdoDoctor.Size = new System.Drawing.Size(58, 22);
            this.rdoDoctor.TabIndex = 39;
            this.rdoDoctor.TabStop = true;
            this.rdoDoctor.Text = "Doctor";
            this.rdoDoctor.UseVisualStyleBackColor = false;
            this.rdoDoctor.CheckedChanged += new System.EventHandler(this.rdoDoctor_CheckedChanged);
            // 
            // chkPhysio
            // 
            this.chkPhysio.AutoSize = true;
            this.chkPhysio.BackColor = System.Drawing.Color.Transparent;
            this.chkPhysio.Location = new System.Drawing.Point(110, 102);
            this.chkPhysio.Name = "chkPhysio";
            this.chkPhysio.Size = new System.Drawing.Size(116, 22);
            this.chkPhysio.TabIndex = 40;
            this.chkPhysio.Text = "Doctor with Physio";
            this.chkPhysio.UseVisualStyleBackColor = false;
            this.chkPhysio.CheckedChanged += new System.EventHandler(this.chkPhysio_CheckedChanged);
            // 
            // toolTip1
            // 
            this.toolTip1.ToolTipTitle = "Home";
            // 
            // lblAssignStaff
            // 
            this.lblAssignStaff.AutoSize = true;
            this.lblAssignStaff.BackColor = System.Drawing.Color.Transparent;
            this.lblAssignStaff.Location = new System.Drawing.Point(12, 175);
            this.lblAssignStaff.Name = "lblAssignStaff";
            this.lblAssignStaff.Size = new System.Drawing.Size(78, 18);
            this.lblAssignStaff.TabIndex = 42;
            this.lblAssignStaff.Text = "Select Assign :";
            // 
            // cboAssign
            // 
            this.cboAssign.FormattingEnabled = true;
            this.cboAssign.Items.AddRange(new object[] {
            "Select Assign",
            "AM",
            "PM"});
            this.cboAssign.Location = new System.Drawing.Point(110, 175);
            this.cboAssign.Name = "cboAssign";
            this.cboAssign.Size = new System.Drawing.Size(223, 26);
            this.cboAssign.TabIndex = 43;
            this.cboAssign.SelectedIndexChanged += new System.EventHandler(this.cboAssign_SelectedIndexChanged);
            // 
            // lnkAssignStaff
            // 
            this.lnkAssignStaff.AutoSize = true;
            this.lnkAssignStaff.Location = new System.Drawing.Point(350, 178);
            this.lnkAssignStaff.Name = "lnkAssignStaff";
            this.lnkAssignStaff.Size = new System.Drawing.Size(85, 18);
            this.lnkAssignStaff.TabIndex = 44;
            this.lnkAssignStaff.TabStop = true;
            this.lnkAssignStaff.Text = "Assign Staff List";
            this.lnkAssignStaff.LinkClicked += new System.Windows.Forms.LinkLabelLinkClickedEventHandler(this.lnkAssignStaff_LinkClicked);
            // 
            // Sales
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 18F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.SystemColors.Control;
            this.BackgroundImage = global::POS.Properties.Resources.pos_bg4;
            this.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.ClientSize = new System.Drawing.Size(1176, 741);
            this.Controls.Add(this.lnkAssignStaff);
            this.Controls.Add(this.cboAssign);
            this.Controls.Add(this.lblAssignStaff);
            this.Controls.Add(this.chkPhysio);
            this.Controls.Add(this.rdoDoctor);
            this.Controls.Add(this.rdoPhysio);
            this.Controls.Add(this.rdoSale);
            this.Controls.Add(this.cboDoctor);
            this.Controls.Add(this.btnAddNewDoctor);
            this.Controls.Add(this.btnAddNewCustomer);
            this.Controls.Add(this.label11);
            this.Controls.Add(this.lblEmail);
            this.Controls.Add(this.label13);
            this.Controls.Add(this.lblNRIC);
            this.Controls.Add(this.label10);
            this.Controls.Add(this.lblPhoneNumber);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.lblCustomerName);
            this.Controls.Add(this.lbAdvanceSearch);
            this.Controls.Add(this.cboCustomer);
            this.Controls.Add(this.lblDoc);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.groupBox1);
            this.Controls.Add(this.tableLayoutPanel2);
            this.Controls.Add(this.tableLayoutPanel1);
            this.Controls.Add(this.dgvSalesItem);
            this.Font = new System.Drawing.Font("Zawgyi-One", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.Name = "Sales";
            this.Text = "Sales";
            this.Activated += new System.EventHandler(this.Sales_Activated);
            this.Load += new System.EventHandler(this.Sales_Load);
            ((System.ComponentModel.ISupportInitialize)(this.dgvSalesItem)).EndInit();
            this.tableLayoutPanel2.ResumeLayout(false);
            this.groupBox1.ResumeLayout(false);
            this.groupBox1.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dgvSearchProductList)).EndInit();
            this.tableLayoutPanel1.ResumeLayout(false);
            this.tableLayoutPanel1.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.DataGridView dgvSalesItem;
        private System.Windows.Forms.TableLayoutPanel tableLayoutPanel1;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.Label label6;
        private System.Windows.Forms.Label lblTotal;
        private System.Windows.Forms.Label lblDiscountTotal;
        private System.Windows.Forms.Label lblTaxTotal;
        private System.Windows.Forms.Label label7;
        private System.Windows.Forms.ComboBox cboPaymentMethod;
        private System.Windows.Forms.TableLayoutPanel tableLayoutPanel2;
        private System.Windows.Forms.Button btnCancel;
        private System.Windows.Forms.Button btnSave;
        private System.Windows.Forms.Button btnLoadDraft;
        private System.Windows.Forms.Button btnPaid;
        private System.Windows.Forms.Label label8;
        private System.Windows.Forms.GroupBox groupBox1;
        private System.Windows.Forms.Button btnSearch;
        private System.Windows.Forms.Label label9;
        private System.Windows.Forms.DataGridView dgvSearchProductList;
        private System.Windows.Forms.ComboBox cboProductName;
        private System.Windows.Forms.TextBox txtAdditionalDiscount;
        private System.Windows.Forms.TextBox txtExtraTax;
        private System.Windows.Forms.DataGridViewTextBoxColumn Column12;
        private System.Windows.Forms.DataGridViewTextBoxColumn Column9;
        private System.Windows.Forms.DataGridViewTextBoxColumn Column10;
        private System.Windows.Forms.Button btnAddNewCustomer;
        private System.Windows.Forms.Label label11;
        private System.Windows.Forms.Label lblEmail;
        private System.Windows.Forms.Label label13;
        private System.Windows.Forms.Label lblNRIC;
        private System.Windows.Forms.Label label10;
        private System.Windows.Forms.Label lblPhoneNumber;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label lblCustomerName;
        private System.Windows.Forms.LinkLabel lbAdvanceSearch;
        private System.Windows.Forms.ComboBox cboCustomer;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label label12;
        private System.Windows.Forms.Label lblTotalQty;
        private System.Windows.Forms.DataGridViewTextBoxColumn Column11;
        private System.Windows.Forms.DataGridViewTextBoxColumn Column1;
        private System.Windows.Forms.DataGridViewTextBoxColumn Column2;
        private System.Windows.Forms.DataGridViewTextBoxColumn Column3;
        private System.Windows.Forms.DataGridViewTextBoxColumn Column4;
        private System.Windows.Forms.DataGridViewTextBoxColumn Column5;
        private System.Windows.Forms.DataGridViewTextBoxColumn Column7;
        private System.Windows.Forms.DataGridViewTextBoxColumn Column6;
        private System.Windows.Forms.DataGridViewLinkColumn Column8;
        private System.Windows.Forms.DataGridViewTextBoxColumn Column13;
        private System.Windows.Forms.Label label15;
        private System.Windows.Forms.Label lblDoc;
        private System.Windows.Forms.ComboBox cboDoctor;
        private System.Windows.Forms.Button btnAddNewDoctor;
        private System.Windows.Forms.RadioButton rdoSale;
        private System.Windows.Forms.RadioButton rdoPhysio;
        private System.Windows.Forms.RadioButton rdoDoctor;
        private System.Windows.Forms.TextBox lblServiceCharges;
        private System.Windows.Forms.Label label14;
        private System.Windows.Forms.CheckBox chkPhysio;
        private System.Windows.Forms.ToolTip toolTip1;
        private System.Windows.Forms.Label lblAssignStaff;
        private System.Windows.Forms.ComboBox cboAssign;
        private System.Windows.Forms.LinkLabel lnkAssignStaff;
        private System.Windows.Forms.Label lblPatient;
    }
}