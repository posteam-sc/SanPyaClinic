namespace POS
{
    partial class frmDoctorList
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(frmDoctorList));
            this.dgvDoctorList = new System.Windows.Forms.DataGridView();
            this.Column6 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Column1 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Degree = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Specialisation = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Column2 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Column5 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.ForPhysioTrain = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.ChargesPerPatient = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.PhysicoCharges = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Column3 = new System.Windows.Forms.DataGridViewLinkColumn();
            this.Column9 = new System.Windows.Forms.DataGridViewLinkColumn();
            this.Column4 = new System.Windows.Forms.DataGridViewLinkColumn();
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.btnClearSearch = new System.Windows.Forms.Button();
            this.lblSearchTitle = new System.Windows.Forms.Label();
            this.btnSearch = new System.Windows.Forms.Button();
            this.txtSearch = new System.Windows.Forms.TextBox();
            this.btnAddNewCustomer = new System.Windows.Forms.Button();
            this.rdoPhysio = new System.Windows.Forms.RadioButton();
            this.rdoDoctor = new System.Windows.Forms.RadioButton();
            ((System.ComponentModel.ISupportInitialize)(this.dgvDoctorList)).BeginInit();
            this.groupBox1.SuspendLayout();
            this.SuspendLayout();
            // 
            // dgvDoctorList
            // 
            this.dgvDoctorList.AllowUserToAddRows = false;
            this.dgvDoctorList.AllowUserToResizeColumns = false;
            this.dgvDoctorList.BackgroundColor = System.Drawing.SystemColors.Window;
            this.dgvDoctorList.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dgvDoctorList.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.Column6,
            this.Column1,
            this.Degree,
            this.Specialisation,
            this.Column2,
            this.Column5,
            this.ForPhysioTrain,
            this.ChargesPerPatient,
            this.PhysicoCharges,
            this.Column3,
            this.Column9,
            this.Column4});
            this.dgvDoctorList.Location = new System.Drawing.Point(34, 124);
            this.dgvDoctorList.Margin = new System.Windows.Forms.Padding(3, 6, 3, 6);
            this.dgvDoctorList.Name = "dgvDoctorList";
            this.dgvDoctorList.Size = new System.Drawing.Size(1236, 415);
            this.dgvDoctorList.TabIndex = 12;
            this.dgvDoctorList.CellClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.dgvDoctorList_CellClick);
            this.dgvDoctorList.DataBindingComplete += new System.Windows.Forms.DataGridViewBindingCompleteEventHandler(this.dgvDoctorList_DataBindingComplete);
            // 
            // Column6
            // 
            this.Column6.DataPropertyName = "Id";
            this.Column6.HeaderText = "ID";
            this.Column6.Name = "Column6";
            this.Column6.Visible = false;
            // 
            // Column1
            // 
            this.Column1.DataPropertyName = "Name";
            this.Column1.HeaderText = "Name";
            this.Column1.Name = "Column1";
            this.Column1.Width = 180;
            // 
            // Degree
            // 
            this.Degree.DataPropertyName = "Degree";
            this.Degree.HeaderText = "Degree";
            this.Degree.Name = "Degree";
            // 
            // Specialisation
            // 
            this.Specialisation.DataPropertyName = "Specialisation";
            this.Specialisation.HeaderText = "Specialisation";
            this.Specialisation.Name = "Specialisation";
            // 
            // Column2
            // 
            this.Column2.DataPropertyName = "PhoneNumber";
            this.Column2.HeaderText = "Phone Number";
            this.Column2.Name = "Column2";
            this.Column2.Width = 120;
            // 
            // Column5
            // 
            this.Column5.DataPropertyName = "Email";
            this.Column5.HeaderText = "Email";
            this.Column5.Name = "Column5";
            this.Column5.Width = 150;
            // 
            // ForPhysioTrain
            // 
            this.ForPhysioTrain.DataPropertyName = "ForPhysioTrain";
            this.ForPhysioTrain.HeaderText = "For Physio Train";
            this.ForPhysioTrain.Name = "ForPhysioTrain";
            this.ForPhysioTrain.Width = 150;
            // 
            // ChargesPerPatient
            // 
            this.ChargesPerPatient.DataPropertyName = "ChargesPerPatient";
            this.ChargesPerPatient.HeaderText = "Charges Per Patient";
            this.ChargesPerPatient.Name = "ChargesPerPatient";
            this.ChargesPerPatient.Width = 200;
            // 
            // PhysicoCharges
            // 
            this.PhysicoCharges.DataPropertyName = "PhysicoCharges";
            this.PhysicoCharges.HeaderText = "Physico Charges";
            this.PhysicoCharges.Name = "PhysicoCharges";
            this.PhysicoCharges.Visible = false;
            this.PhysicoCharges.Width = 150;
            // 
            // Column3
            // 
            this.Column3.HeaderText = "";
            this.Column3.Name = "Column3";
            this.Column3.Text = "Detail";
            this.Column3.UseColumnTextForLinkValue = true;
            this.Column3.VisitedLinkColor = System.Drawing.Color.Blue;
            this.Column3.Width = 80;
            // 
            // Column9
            // 
            this.Column9.HeaderText = "";
            this.Column9.Name = "Column9";
            this.Column9.Text = "Edit";
            this.Column9.UseColumnTextForLinkValue = true;
            this.Column9.Width = 80;
            // 
            // Column4
            // 
            this.Column4.HeaderText = "";
            this.Column4.Name = "Column4";
            this.Column4.Text = "Delete";
            this.Column4.UseColumnTextForLinkValue = true;
            this.Column4.Width = 80;
            // 
            // groupBox1
            // 
            this.groupBox1.Controls.Add(this.btnClearSearch);
            this.groupBox1.Controls.Add(this.lblSearchTitle);
            this.groupBox1.Controls.Add(this.btnSearch);
            this.groupBox1.Controls.Add(this.txtSearch);
            this.groupBox1.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(79)))), ((int)(((byte)(55)))), ((int)(((byte)(46)))));
            this.groupBox1.Location = new System.Drawing.Point(155, 33);
            this.groupBox1.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Padding = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.groupBox1.Size = new System.Drawing.Size(646, 71);
            this.groupBox1.TabIndex = 14;
            this.groupBox1.TabStop = false;
            this.groupBox1.Text = "Search By";
            // 
            // btnClearSearch
            // 
            this.btnClearSearch.BackColor = System.Drawing.Color.Transparent;
            this.btnClearSearch.FlatAppearance.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(231)))), ((int)(((byte)(202)))), ((int)(((byte)(125)))));
            this.btnClearSearch.FlatAppearance.BorderSize = 0;
            this.btnClearSearch.FlatAppearance.MouseDownBackColor = System.Drawing.Color.Transparent;
            this.btnClearSearch.FlatAppearance.MouseOverBackColor = System.Drawing.Color.Transparent;
            this.btnClearSearch.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnClearSearch.Image = ((System.Drawing.Image)(resources.GetObject("btnClearSearch.Image")));
            this.btnClearSearch.Location = new System.Drawing.Point(504, 19);
            this.btnClearSearch.Margin = new System.Windows.Forms.Padding(3, 6, 3, 6);
            this.btnClearSearch.Name = "btnClearSearch";
            this.btnClearSearch.Size = new System.Drawing.Size(75, 46);
            this.btnClearSearch.TabIndex = 16;
            this.btnClearSearch.UseVisualStyleBackColor = false;
            this.btnClearSearch.Click += new System.EventHandler(this.btnClearSearch_Click);
            // 
            // lblSearchTitle
            // 
            this.lblSearchTitle.AutoSize = true;
            this.lblSearchTitle.Location = new System.Drawing.Point(39, 33);
            this.lblSearchTitle.Name = "lblSearchTitle";
            this.lblSearchTitle.Size = new System.Drawing.Size(35, 13);
            this.lblSearchTitle.TabIndex = 15;
            this.lblSearchTitle.Text = "Name";
            // 
            // btnSearch
            // 
            this.btnSearch.BackColor = System.Drawing.Color.Transparent;
            this.btnSearch.FlatAppearance.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(231)))), ((int)(((byte)(202)))), ((int)(((byte)(125)))));
            this.btnSearch.FlatAppearance.BorderSize = 0;
            this.btnSearch.FlatAppearance.MouseDownBackColor = System.Drawing.Color.Transparent;
            this.btnSearch.FlatAppearance.MouseOverBackColor = System.Drawing.Color.Transparent;
            this.btnSearch.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnSearch.Image = ((System.Drawing.Image)(resources.GetObject("btnSearch.Image")));
            this.btnSearch.Location = new System.Drawing.Point(406, 19);
            this.btnSearch.Margin = new System.Windows.Forms.Padding(3, 6, 3, 6);
            this.btnSearch.Name = "btnSearch";
            this.btnSearch.Size = new System.Drawing.Size(75, 46);
            this.btnSearch.TabIndex = 6;
            this.btnSearch.UseVisualStyleBackColor = false;
            this.btnSearch.Click += new System.EventHandler(this.btnSearch_Click);
            // 
            // txtSearch
            // 
            this.txtSearch.Location = new System.Drawing.Point(129, 29);
            this.txtSearch.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.txtSearch.Name = "txtSearch";
            this.txtSearch.Size = new System.Drawing.Size(262, 20);
            this.txtSearch.TabIndex = 5;
            // 
            // btnAddNewCustomer
            // 
            this.btnAddNewCustomer.BackColor = System.Drawing.Color.Transparent;
            this.btnAddNewCustomer.FlatAppearance.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(231)))), ((int)(((byte)(202)))), ((int)(((byte)(125)))));
            this.btnAddNewCustomer.FlatAppearance.BorderSize = 0;
            this.btnAddNewCustomer.FlatAppearance.MouseDownBackColor = System.Drawing.Color.Transparent;
            this.btnAddNewCustomer.FlatAppearance.MouseOverBackColor = System.Drawing.Color.Transparent;
            this.btnAddNewCustomer.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnAddNewCustomer.ForeColor = System.Drawing.SystemColors.ControlText;
            this.btnAddNewCustomer.Image = global::POS.Properties.Resources.Add_New_Doctor;
            this.btnAddNewCustomer.Location = new System.Drawing.Point(863, 32);
            this.btnAddNewCustomer.Margin = new System.Windows.Forms.Padding(3, 6, 3, 6);
            this.btnAddNewCustomer.Name = "btnAddNewCustomer";
            this.btnAddNewCustomer.Size = new System.Drawing.Size(215, 79);
            this.btnAddNewCustomer.TabIndex = 13;
            this.btnAddNewCustomer.UseVisualStyleBackColor = false;
            this.btnAddNewCustomer.Click += new System.EventHandler(this.btnAddNewCustomer_Click);
            // 
            // rdoPhysio
            // 
            this.rdoPhysio.AutoSize = true;
            this.rdoPhysio.Font = new System.Drawing.Font("Zawgyi-One", 9F);
            this.rdoPhysio.Location = new System.Drawing.Point(34, 74);
            this.rdoPhysio.Name = "rdoPhysio";
            this.rdoPhysio.Size = new System.Drawing.Size(61, 24);
            this.rdoPhysio.TabIndex = 16;
            this.rdoPhysio.Text = "Physio";
            this.rdoPhysio.UseVisualStyleBackColor = true;
            this.rdoPhysio.CheckedChanged += new System.EventHandler(this.rdoPhysio_CheckedChanged);
            // 
            // rdoDoctor
            // 
            this.rdoDoctor.AutoSize = true;
            this.rdoDoctor.Checked = true;
            this.rdoDoctor.Font = new System.Drawing.Font("Zawgyi-One", 9F);
            this.rdoDoctor.Location = new System.Drawing.Point(34, 33);
            this.rdoDoctor.Name = "rdoDoctor";
            this.rdoDoctor.Size = new System.Drawing.Size(64, 24);
            this.rdoDoctor.TabIndex = 15;
            this.rdoDoctor.TabStop = true;
            this.rdoDoctor.Text = "Doctor";
            this.rdoDoctor.UseVisualStyleBackColor = true;
            this.rdoDoctor.CheckedChanged += new System.EventHandler(this.rdoDoctor_CheckedChanged);
            // 
            // frmDoctorList
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(223)))), ((int)(((byte)(223)))), ((int)(((byte)(223)))));
            this.ClientSize = new System.Drawing.Size(1284, 560);
            this.Controls.Add(this.rdoPhysio);
            this.Controls.Add(this.rdoDoctor);
            this.Controls.Add(this.dgvDoctorList);
            this.Controls.Add(this.groupBox1);
            this.Controls.Add(this.btnAddNewCustomer);
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.Name = "frmDoctorList";
            this.Text = "Doctor List";
            this.Load += new System.EventHandler(this.frmDoctorList_Load);
            ((System.ComponentModel.ISupportInitialize)(this.dgvDoctorList)).EndInit();
            this.groupBox1.ResumeLayout(false);
            this.groupBox1.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.DataGridView dgvDoctorList;
        private System.Windows.Forms.GroupBox groupBox1;
        private System.Windows.Forms.Button btnClearSearch;
        private System.Windows.Forms.Label lblSearchTitle;
        private System.Windows.Forms.Button btnSearch;
        private System.Windows.Forms.TextBox txtSearch;
        private System.Windows.Forms.Button btnAddNewCustomer;
        private System.Windows.Forms.RadioButton rdoPhysio;
        private System.Windows.Forms.RadioButton rdoDoctor;
        private System.Windows.Forms.DataGridViewTextBoxColumn Column6;
        private System.Windows.Forms.DataGridViewTextBoxColumn Column1;
        private System.Windows.Forms.DataGridViewTextBoxColumn Degree;
        private System.Windows.Forms.DataGridViewTextBoxColumn Specialisation;
        private System.Windows.Forms.DataGridViewTextBoxColumn Column2;
        private System.Windows.Forms.DataGridViewTextBoxColumn Column5;
        private System.Windows.Forms.DataGridViewTextBoxColumn ForPhysioTrain;
        private System.Windows.Forms.DataGridViewTextBoxColumn ChargesPerPatient;
        private System.Windows.Forms.DataGridViewTextBoxColumn PhysicoCharges;
        private System.Windows.Forms.DataGridViewLinkColumn Column3;
        private System.Windows.Forms.DataGridViewLinkColumn Column9;
        private System.Windows.Forms.DataGridViewLinkColumn Column4;
    }
}